--Poblacion Cliente--
INSERT INTO Cliente(cliente_id,cedula,nombre,apellido,fecha_nacimiento,celular,correo)
VALUES(1,'6348932703','Juana','Martin',CAST('1993-01-25' AS date),'3103258943','juana.matin@gmail.com')
INSERT INTO Cliente(cliente_id,cedula,nombre,apellido,fecha_nacimiento,celular,correo)
VALUES(2,'7229954013','Raul','Alvarez',CAST('1982-10-10' AS date),'3018475839','raul.alvarez@hotmail.com')
INSERT INTO Cliente(cliente_id,cedula,nombre,apellido,fecha_nacimiento,celular,correo)
VALUES(3,'8671952603','Sara','Ospina',CAST('1965-01-23' AS date),'3115792949','sara.ospina@yahoo.com')
INSERT INTO Cliente(cliente_id,cedula,nombre,apellido,fecha_nacimiento,celular,correo)
VALUES(4,'1093275036','Manuel','Morales',CAST('2000-06-15' AS date),'3026581070','manuel.morales@hotmail.com')

SELECT * FROM Cliente

--Poblacion Producto--
INSERT INTO Producto(producto_id,nombre,precio,cantidad)
VALUES(1, 'Undertale', CAST(12000.00 AS Decimal(10, 2)), 50)
INSERT INTO Producto(producto_id,nombre,precio,cantidad)
VALUES(2, 'GTAV', CAST(200000.00 AS Decimal(10, 2)), 70)
INSERT INTO Producto(producto_id,nombre,precio,cantidad)
VALUES(3, 'SonicMania', CAST(65000.00 AS Decimal(10, 2)), 5)
INSERT INTO Producto(producto_id,nombre,precio,cantidad)
VALUES(4, 'BeatSaber', CAST(40000.00 AS Decimal(10, 2)), 10)
INSERT INTO Producto(producto_id,nombre,precio,cantidad)
VALUES(5, 'FIFA23', CAST(280000.00 AS Decimal(10, 2)), 30)

SELECT * FROM Producto

--Poblacion Factura--
INSERT INTO Factura(factura_id,cliente_id,fecha,precioTotal)
VALUES(1, 1, CAST('2022-09-20' AS date),CAST(265000.00 AS Decimal(10, 2)))
INSERT INTO Factura(factura_id,cliente_id,fecha,precioTotal)
VALUES(2, 3, CAST('2022-09-24' AS date),CAST(160000.00 AS Decimal(10, 2)))
INSERT INTO Factura(factura_id,cliente_id,fecha,precioTotal)
VALUES(3, 2, CAST('2022-10-01' AS date),CAST(465000.00 AS Decimal(10, 2)))
INSERT INTO Factura(factura_id,cliente_id,fecha,precioTotal)
VALUES(4, 4, CAST('2000-04-07' AS date),CAST(80000.00 AS Decimal(10, 2)))
INSERT INTO Factura(factura_id,cliente_id,fecha,precioTotal)
VALUES(5, 3, CAST('2000-08-08' AS date),CAST(200000.00 AS Decimal(10, 2)))

SELECT * FROM Factura

--Poblacion Compra--
INSERT INTO Compra(compra_id,factura_id,producto_id,precio,cantidad)
VALUES(1, 1, 2, CAST(200000.00 AS Decimal(10, 2)), 1)
INSERT INTO Compra(compra_id,factura_id,producto_id,precio,cantidad)
VALUES(2, 1, 3, CAST(65000.00 AS Decimal(10, 2)), 1)
INSERT INTO Compra(compra_id,factura_id,producto_id,precio,cantidad)
VALUES(3, 2, 1, CAST(12000.00 AS Decimal(10, 2)), 1)
INSERT INTO Compra(compra_id,factura_id,producto_id,precio,cantidad)
VALUES(4, 3, 4, CAST(40000.00 AS Decimal(10, 2)), 1)
INSERT INTO Compra(compra_id,factura_id,producto_id,precio,cantidad)
VALUES(5, 3, 5, CAST(280000.00 AS Decimal(10, 2)), 1)
INSERT INTO Compra(compra_id,factura_id,producto_id,precio,cantidad)
VALUES(6, 3, 3, CAST(65000.00 AS Decimal(10, 2)), 1)
INSERT INTO Compra(compra_id,factura_id,producto_id,precio,cantidad)
VALUES(7, 4, 4, CAST(40000.00 AS Decimal(10, 2)), 2)
INSERT INTO Compra(compra_id,factura_id,producto_id,precio,cantidad)
VALUES(8, 5, 2, CAST(100000.00 AS Decimal(10, 2)), 2)

SELECT * FROM Compra