-- Active: 1685988887588@@127.0.0.1@3306@WebPage
DROP IF EXISTS Datos;
CREATE DATABASE Datos;
Use Datos;
-- Tabla para almacenar la información de los clientes
CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(200),
    NumFijo VARCHAR(15),
    NumMovil VARCHAR(15),
    Email VARCHAR(100)
);

-- Tabla para almacenar la información de los vehículos
CREATE TABLE Vehiculos (
    Placa VARCHAR(10) PRIMARY KEY,
    IdCliente INT,
    Marca VARCHAR(50),
    Modelo VARCHAR(50),
    Color VARCHAR(50),
    KM INT,
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente) ON DELETE CASCADE
);

-- Tabla para almacenar la información de la inspección del vehículo
CREATE TABLE Inspeccion (
    NroOrden INT PRIMARY KEY,
    Placa VARCHAR(10),
    f_Izquierda VARCHAR(50),
    t_Izquierda VARCHAR(50),
    f_derecha VARCHAR(50),
    t_derecha VARCHAR(50),
    marca VARCHAR(50),
    estado VARCHAR(50),
    techo VARCHAR(50),
    muebles VARCHAR(50),
    tapetes VARCHAR(50),
    otros VARCHAR(200),
    FOREIGN KEY (Placa) REFERENCES Vehiculos(Placa) ON DELETE CASCADE
);

-- Tabla para almacenar la información del personal del taller
CREATE TABLE Personal (
    IdEmpl INT PRIMARY KEY,
    NombreEmpl VARCHAR(100) NOT NULL,
    TelEmpl VARCHAR(15),
    MovilEmpl VARCHAR(15),
    Especialidad VARCHAR(100)
);

-- Tabla para almacenar la información del diagnóstico del cliente
CREATE TABLE DiagnosticoCliente (
    NroOrden INT PRIMARY KEY,
    IdEmpl INT,
    Diagnostico TEXT,
    FOREIGN KEY (NroOrden) REFERENCES Inspeccion(NroOrden) ON DELETE CASCADE,
    FOREIGN KEY (IdEmpl) REFERENCES Personal(IdEmpl) ON DELETE CASCADE
);

-- Tabla para almacenar la información de la autorización de reparación
CREATE TABLE AutorizacionReparacion (
    NroOrden INT PRIMARY KEY,
    Estado VARCHAR(50),
    Repuesto VARCHAR(100),
    MarcaRepuesto VARCHAR(50),
    Cantidad INT,
    VU FLOAT,
    VT FLOAT,
    ValorTotalRepuesto FLOAT,
    ValorManoObra FLOAT,
    ValorTotalReparacion FLOAT,
    FOREIGN KEY (NroOrden) REFERENCES Inspeccion(NroOrden) ON DELETE CASCADE
);

-- Tabla para almacenar la información de la entrega del vehículo
CREATE TABLE EntregaVehiculo (
    NroOrden INT PRIMARY KEY,
    FechaEntrega DATETIME,
    FOREIGN KEY (NroOrden) REFERENCES Inspeccion(NroOrden) ON DELETE CASCADE
);
