--Obtener la lista de precios de todos los productos--
SELECT nombre, precio FROM Producto

--Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)--
SELECT producto_id, nombre, cantidad FROM Producto
WHERE cantidad <= 5

--Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000
SELECT * FROM Cliente cli, Factura fac
WHERE cli.cliente_id = fac.cliente_id
AND DATEDIFF(YEAR, cli.fecha_nacimiento, GETDATE()) < 35
AND fac.fecha BETWEEN '2000-02-01' AND '2000-05-25'

--Obtener el valor total vendido por cada producto en el año 2000--
SELECT pro.nombre, fac.precioTotal FROM Factura fac, Producto pro, Compra com
WHERE fac.factura_id = com.factura_id
AND pro.producto_id = com.producto_id
AND fac.fecha BETWEEN '2000-01-01' AND '2000-12-31'

--Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar en qué fecha podría volver a comprar--
DECLARE @vecesCompra int
SET @vecesCompra = (SELECT COUNT(cli.cliente_id)
FROM Factura fac, Cliente cli
WHERE cli.cliente_id = 3
AND cli.cliente_id = fac.cliente_id)
SELECT cli.cedula, MAX(fac.fecha) AS Ultima_Fecha, DATEDIFF(YEAR, MIN(fac.fecha), MAX(fac.fecha)) / @vecesCompra AS Frecuencia, DATEADD(DAY,DATEDIFF(YEAR, MIN(fac.fecha), MAX(fac.fecha)) / @vecesCompra, MAX(fac.fecha)) AS Prediccion
FROM Factura fac, Cliente cli
WHERE cli.cliente_id = 3
AND cli.cliente_id = fac.cliente_id
GROUP BY cli.cedula
