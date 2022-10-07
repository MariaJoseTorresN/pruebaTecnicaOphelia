--Obtener la lista de precios de todos los productos--
SELECT nombre, precio FROM Productos

--Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)--
SELECT productoId, nombre, cantidad FROM Productos
WHERE cantidad <= 5

--Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000
SELECT * FROM Clientes cli, Facturas fac
WHERE cli.clienteId = fac.clienteId
AND DATEDIFF(YEAR, cli.fechaNacimiento, GETDATE()) < 35
AND fac.fecha BETWEEN '2000-02-01' AND '2000-05-25'

--Obtener el valor total vendido por cada producto en el año 2000--
SELECT pro.nombre, fac.precioTotal FROM Facturas fac, Productos pro, Compras com
WHERE fac.facturaId = com.facturaId
AND pro.productoId = com.productoId
AND fac.fecha BETWEEN '2000-01-01' AND '2000-12-31'

--Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar en qué fecha podría volver a comprar--
DECLARE @vecesCompra int
SET @vecesCompra = (SELECT COUNT(cli.clienteId)
FROM Facturas fac, Clientes cli
WHERE cli.clienteId = 1
AND cli.clienteId = fac.clienteId)
SELECT cli.cedula, MAX(fac.fecha) AS Ultima_Fecha, DATEDIFF(YEAR, MIN(fac.fecha), MAX(fac.fecha)) / @vecesCompra AS Frecuencia, DATEADD(DAY,DATEDIFF(YEAR, MIN(fac.fecha), MAX(fac.fecha)) / @vecesCompra, MAX(fac.fecha)) AS Prediccion
FROM Facturas fac, Clientes cli
WHERE cli.clienteId = 1
AND cli.clienteId = fac.clienteId
GROUP BY cli.cedula