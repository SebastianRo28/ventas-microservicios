CREATE DATABASE BD_COMPRAVENTA
GO

USE DATABASE BD_COMPRAVENTA

-- PRODUCTOS
CREATE TABLE Productos (
    Id_producto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_producto NVARCHAR(200) NOT NULL,
    NroLote NVARCHAR(50) NOT NULL,
    Fec_registro DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Costo DECIMAL(18,2) NOT NULL,
    PrecioVenta DECIMAL(18,2) NOT NULL
);
GO

INSERT INTO Productos
(
    Nombre_producto,
    NroLote,
    Fec_registro,
    Costo,
    PrecioVenta
)
VALUES
(
    'Laptop Lenovo ThinkPad',
    'LTP-001',
    SYSUTCDATETIME(),
    2500.00,
    3200.00
);

-- COMPRA CAB
CREATE TABLE CompraCab (
    Id_CompraCab INT IDENTITY(1,1) PRIMARY KEY,
    FecRegistro DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    SubTotal DECIMAL(18,2) NOT NULL,
    Igv DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL
);
GO

-- COMPRA DET
CREATE TABLE CompraDet (
    Id_CompraDet INT IDENTITY(1,1) PRIMARY KEY,
    Id_CompraCab INT NOT NULL,
    Id_producto INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Sub_Total DECIMAL(18,2) NOT NULL,
    Igv DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_CompraDet_CompraCab FOREIGN KEY (Id_CompraCab) REFERENCES CompraCab(Id_CompraCab),
    CONSTRAINT FK_CompraDet_Productos FOREIGN KEY (Id_producto) REFERENCES Productos(Id_producto)
);
GO

-- VENTA CAB
CREATE TABLE VentaCab (
    Id_VentaCab INT IDENTITY(1,1) PRIMARY KEY,
    FecRegistro DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    SubTotal DECIMAL(18,2) NOT NULL,
    Igv DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL
);
GO

-- VENTA DET
CREATE TABLE VentaDet (
    Id_VentaDet INT IDENTITY(1,1) PRIMARY KEY,
    Id_VentaCab INT NOT NULL,
    Id_producto INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Sub_Total DECIMAL(18,2) NOT NULL,
    Igv DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_VentaDet_VentaCab FOREIGN KEY (Id_VentaCab) REFERENCES VentaCab(Id_VentaCab),
    CONSTRAINT FK_VentaDet_Productos FOREIGN KEY (Id_producto) REFERENCES Productos(Id_producto)
);
GO

-- MOVIMIENTO CAB
CREATE TABLE MovimientoCab (
    Id_MovimientoCab INT IDENTITY(1,1) PRIMARY KEY,
    Fec_registro DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Id_TipoMovimiento INT NOT NULL, -- 1 Entrada, 2 Salida
    Id_DocumentoOrigen INT NOT NULL  -- Id_CompraCab o Id_VentaCab dependiendo del tipo
);
GO

-- MOVIMIENTO DET
CREATE TABLE MovimientoDet (
    Id_MovimientoDet INT IDENTITY(1,1) PRIMARY KEY,
    Id_MovimientoCab INT NOT NULL,
    Id_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    CONSTRAINT FK_MovDet_MovCab FOREIGN KEY (Id_MovimientoCab) REFERENCES MovimientoCab(Id_MovimientoCab),
    CONSTRAINT FK_MovDet_Producto FOREIGN KEY (Id_Producto) REFERENCES Productos(Id_producto)
);
GO


SELECT * FROM Productos


SELECT * FROM MovimientoCab