CREATE DATABASE FACTURACION_REPOSITORY
GO

USE FACTURACION_REPOSITORY
GO

CREATE TABLE FormaPago (
    id_forma_pago INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL
);

CREATE TABLE Articulo (
    id_articulo INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL
    
);

CREATE TABLE Factura (
    id_factura INT IDENTITY(1,1) PRIMARY KEY,
    nro_factura INT NOT NULL UNIQUE,
    fecha DATE NOT NULL,
    id_forma_pago INT NOT NULL,
    cliente NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Factura_FormaPago FOREIGN KEY (id_forma_pago) 
        REFERENCES FormaPago(id_forma_pago)
);

CREATE TABLE DetalleFactura (
    id_detalle_factura INT IDENTITY(1,1) PRIMARY KEY,
    id_factura INT NOT NULL,
    id_articulo INT NOT NULL,
    cantidad INT NOT NULL,
    CONSTRAINT FK_DetalleFactura_Factura FOREIGN KEY (id_factura) 
        REFERENCES Factura(id_factura)
        ON DELETE CASCADE, -- si se borra la factura, se borran sus detalles
    CONSTRAINT FK_DetalleFactura_Articulo FOREIGN KEY (id_articulo) 
        REFERENCES Articulo(id_articulo)
);

-- Inserts --

INSERT INTO FormaPago (nombre) VALUES ('Efectivo');
INSERT INTO FormaPago (nombre) VALUES ('Tarjeta de Crédito');
INSERT INTO FormaPago (nombre) VALUES ('Tarjeta de Débito');
INSERT INTO FormaPago (nombre) VALUES ('Transferencia Bancaria');
INSERT INTO FormaPago (nombre) VALUES ('Cheque');
INSERT INTO FormaPago (nombre) VALUES ('MercadoPago');
INSERT INTO FormaPago (nombre) VALUES ('PayPal');
INSERT INTO FormaPago (nombre) VALUES ('Criptomoneda');

INSERT INTO Articulo (nombre, precio_unitario) VALUES ('Mouse Inalámbrico', 2500.00);
INSERT INTO Articulo (nombre, precio_unitario) VALUES ('Teclado Mecánico', 15000.00);
INSERT INTO Articulo (nombre, precio_unitario) VALUES ('Monitor 24 pulgadas', 80000.00);
INSERT INTO Articulo (nombre, precio_unitario) VALUES ('Notebook Lenovo i5', 350000.00);
INSERT INTO Articulo (nombre, precio_unitario) VALUES ('Disco SSD 1TB', 60000.00);
INSERT INTO Articulo (nombre, precio_unitario) VALUES ('Impresora HP', 90000.00);
INSERT INTO Articulo (nombre, precio_unitario) VALUES ('Auriculares Bluetooth', 12000.00);
INSERT INTO Articulo (nombre, precio_unitario) VALUES ('Silla Gamer', 70000.00);

INSERT INTO Factura (nro_factura, fecha, id_forma_pago, cliente) VALUES (1001, '2025-01-05', 1, 'Juan Pérez');
INSERT INTO Factura (nro_factura, fecha, id_forma_pago, cliente) VALUES (1002, '2025-01-07', 2, 'María López');
INSERT INTO Factura (nro_factura, fecha, id_forma_pago, cliente) VALUES (1003, '2025-01-08', 3, 'Carlos Gómez');
INSERT INTO Factura (nro_factura, fecha, id_forma_pago, cliente) VALUES (1004, '2025-01-10', 4, 'Ana Torres');
INSERT INTO Factura (nro_factura, fecha, id_forma_pago, cliente) VALUES (1005, '2025-01-12', 5, 'Pedro Martínez');
INSERT INTO Factura (nro_factura, fecha, id_forma_pago, cliente) VALUES (1006, '2025-01-15', 6, 'Lucía Fernández');
INSERT INTO Factura (nro_factura, fecha, id_forma_pago, cliente) VALUES (1007, '2025-01-17', 7, 'Esteban Ramírez');
INSERT INTO Factura (nro_factura, fecha, id_forma_pago, cliente) VALUES (1008, '2025-01-20', 8, 'Marta Sánchez');


-- Factura 1001
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (1, 1, 2); -- 2 Mouse
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (1, 2, 1); -- 1 Teclado

-- Factura 1002
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (2, 3, 1); -- 1 Monitor
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (2, 7, 2); -- 2 Auriculares

-- Factura 1003
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (3, 4, 1); -- 1 Notebook
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (3, 5, 2); -- 2 SSD

-- Factura 1004
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (4, 6, 1); -- 1 Impresora
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (4, 8, 1); -- 1 Silla Gamer

-- Factura 1005
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (5, 1, 5); -- 5 Mouse
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (5, 3, 2); -- 2 Monitores

-- Factura 1006
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (6, 2, 3); -- 3 Teclados
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (6, 7, 1); -- 1 Auricular

-- Factura 1007
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (7, 4, 2); -- 2 Notebooks
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (7, 5, 3); -- 3 SSD

-- Factura 1008
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (8, 6, 1); -- 1 Impresora
INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (8, 8, 2); -- 2 Sillas Gamer

---------------- Stored Procedures
CREATE PROCEDURE SelectAllFacturas
AS
BEGIN
    SELECT F.*, FP.nombre FROM Factura F JOIN FormaPago FP ON F.id_forma_pago = FP.id_forma_pago
END;
GO
--
CREATE PROCEDURE SelectFacturaById
    @IdFactura int
AS
BEGIN
    SELECT * FROM Factura F WHERE id_factura = @IdFactura
END;
GO
--
CREATE PROCEDURE CreateNewFactura
    @NroFactura int,
    @Fecha datetime, 
    @IdFormaPago int, 
    @Cliente NVARCHAR(100)
AS
BEGIN
    INSERT INTO Factura (nro_factura, fecha, id_forma_pago, cliente) VALUES (@NroFactura, @Fecha, @IdFormaPago, @Cliente);
END;
GO
--
CREATE PROCEDURE UpdateFactura
    @IdFactura int,
    @NroFactura int,
    @Fecha datetime, 
    @IdFormaPago int, 
    @Cliente NVARCHAR(100)
AS
BEGIN
    UPDATE Factura SET nro_factura = @NroFactura, fecha = @Fecha, id_forma_pago = @IdFormaPago, cliente = @Cliente WHERE id_factura = @IdFactura;
END;
GO
--
CREATE PROCEDURE DeleteFacturaById
    @IdFactura int
AS
BEGIN
    DELETE FROM Factura WHERE id_factura = @IdFactura
END;
GO

-----------------------------------------------------------------------

CREATE PROCEDURE SelectAllDetallesFacturas
AS
BEGIN
    SELECT * FROM DetalleFactura
END;
GO
--
CREATE PROCEDURE GetDetallesFacturaById
    @IdFactura int
AS
BEGIN
    SELECT * FROM DetalleFactura D WHERE D.id_factura = @IdFactura
END;
GO
--
CREATE PROCEDURE CreateNewDetalleFactura
    @IdFactura int,
    @IdArticulo int, 
    @Cantidad int
AS
BEGIN
    INSERT INTO DetalleFactura (id_factura, id_articulo, cantidad) VALUES (@IdFactura, @IdArticulo, @Cantidad );
END;
GO
--
CREATE PROCEDURE UpdateDetalleFactura
    @IdDetalleFactura int,
    @IdFactura int,
    @IdArticulo int, 
    @Cantidad int
AS
BEGIN
    UPDATE DetalleFactura SET id_factura = @IdFactura, id_articulo = @IdArticulo, cantidad = @Cantidad WHERE id_detalle_factura = @IdDetalleFactura;
END;
GO
--
CREATE PROCEDURE DeleteDetalleFacturaById
    @IdDetalleFactura int
AS
BEGIN
    DELETE FROM DetalleFactura WHERE id_detalle_factura = @IdDetalleFactura;
END;
GO
------------------------------------------

CREATE PROCEDURE SelectAllArticulos
AS
BEGIN
    SELECT * FROM Articulo
END;
GO
--
CREATE PROCEDURE SelectArticuloById
    @IdArticulo int
AS
BEGIN
    SELECT * FROM Articulo WHERE id_articulo = @IdArticulo
END;
GO
--
CREATE PROCEDURE CreateNewArticulo
    @Nombre NVARCHAR(100), 
    @PrecioUnitario int
AS
BEGIN
    INSERT INTO Articulo (nombre, precio_unitario) VALUES (@Nombre, @PrecioUnitario);
END;
GO
--
CREATE PROCEDURE UpdateArticulo
    @IdArticulo int,
    @Nombre NVARCHAR(100), 
    @PrecioUnitario int
AS
BEGIN
    UPDATE Articulo SET nombre = @Nombre, precio_unitario = @PrecioUnitario WHERE id_articulo = @IdArticulo;
END;
GO
--
CREATE PROCEDURE DeleteArticuloById
    @IdArticulo int
AS
BEGIN
    DELETE FROM Articulo WHERE id_articulo = @IdArticulo;
END;
GO
