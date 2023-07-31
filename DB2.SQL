-- Active: 1685988887588@@127.0.0.1@3306@WebPage
DROP IF EXISTS Registro;
CREATE DATABASE Registro;
USE Registro;
-- Tabla de Clientes
CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Direccion VARCHAR(200),
    NumFijo VARCHAR(15),
    NumMovil VARCHAR(15),
    Email VARCHAR(100)
);

-- Tabla de Personal
CREATE TABLE Personal (
    IdEmpleado INT PRIMARY KEY,
    NombreEmpleado VARCHAR(100),
    TelEmpleado VARCHAR(15),
    MovilEmpleado VARCHAR(15),
    Especialidad VARCHAR(100)
);

-- Tabla de Vehiculos
CREATE TABLE Vehiculos (
    Placa VARCHAR(15) PRIMARY KEY,
    Marca VARCHAR(50),
    Modelo VARCHAR(50),
    Color VARCHAR(50),
    KM INT
);

-- Tabla de Inspeccion de Vehiculos
CREATE TABLE InspeccionVehiculos (
    NroOrden INT PRIMARY KEY,
    IdCliente INT,
    Placa VARCHAR(15),
    Puertas VARCHAR(100),
    Cabina VARCHAR(100),
    DiagnosticoCliente TEXT,
    IdEmpleado INT,
    DiagnosticoTaller TEXT,
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
    FOREIGN KEY (Placa) REFERENCES Vehiculos(Placa),
    FOREIGN KEY (IdEmpleado) REFERENCES Personal(IdEmpleado)
);

-- Tabla de Proveedores
CREATE TABLE Proveedores (
    IdProveedor INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Contacto VARCHAR(100),
    Telefono VARCHAR(15),
    Email VARCHAR(100)
);

-- Tabla de Repuestos
CREATE TABLE Repuestos (
    IdRepuesto INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Marca VARCHAR(50),
    Descripcion TEXT,
    Precio DECIMAL(10, 2)
);

-- Tabla de Empleados Adicionales
CREATE TABLE EmpleadosAdicionales (
    IdEmpleado INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Cargo VARCHAR(100),
    Telefono VARCHAR(15),
    Email VARCHAR(100)
);

-- Tabla de Facturas
CREATE TABLE Facturas (
    NroFactura INT PRIMARY KEY,
    Fecha DATE,
    TotalFactura DECIMAL(10, 2),
    IdCliente INT,
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
);

-- Tabla de Pagos
CREATE TABLE Pagos (
    NroFactura INT,
    FechaPago DATE,
    MontoPago DECIMAL(10, 2),
    PRIMARY KEY (NroFactura, FechaPago),
    FOREIGN KEY (NroFactura) REFERENCES Facturas(NroFactura)
);

-- Tabla de Historial de Estado del Vehiculo
CREATE TABLE HistorialEstadoVehiculo (
    NroOrden INT,
    FechaEstado DATE,
    EstadoActual VARCHAR(100),
    Descripcion TEXT,
    PRIMARY KEY (NroOrden, FechaEstado),
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden)
);

-- Tabla de Comentarios y Notas
CREATE TABLE ComentariosNotas (
    NroOrden INT,
    Fecha DATE,
    Autor VARCHAR(100),
    Comentario TEXT,
    PRIMARY KEY (NroOrden, Fecha),
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden)
);

-- Tabla de Servicios
CREATE TABLE Servicios (
    IdServicio INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT,
    Tarifa DECIMAL(10, 2)
);

-- Tabla de Categorias de Repuestos
CREATE TABLE CategoriasRepuestos (
    IdCategoria INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT
);

-- Tabla de Historial de Reparaciones
CREATE TABLE HistorialReparaciones (
    NroOrden INT,
    FechaReparacion DATE,
    Descripcion TEXT,
    MontoTotal DECIMAL(10, 2),
    PRIMARY KEY (NroOrden, FechaReparacion),
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden)
);

-- Tabla de Mantenimientos Programados
CREATE TABLE MantenimientosProgramados (
    IdMantenimiento INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT,
    Periodicidad VARCHAR(100)
);

-- Tabla de Citas de Servicio
CREATE TABLE CitasServicio (
    IdCita INT PRIMARY KEY,
    Fecha DATE,
    Hora TIME,
    IdCliente INT,
    IdServicio INT,
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
    FOREIGN KEY (IdServicio) REFERENCES Servicios(IdServicio)
);

-- Tabla de Marcas de Vehiculos
CREATE TABLE MarcasVehiculos (
    IdMarca INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT
);

-- Tabla de Modelos de Vehiculos
CREATE TABLE ModelosVehiculos (
    IdModelo INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT,
    IdMarca INT,
    FOREIGN KEY (IdMarca) REFERENCES MarcasVehiculos(IdMarca)
);

-- Tabla de Estados de Reparacion
CREATE TABLE EstadosReparacion (
    IdEstado INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT
);

-- Tabla de Registro de Autorizacion de Reparacion
CREATE TABLE AutorizacionReparacion (
    NroOrden INT,
    Responsable VARCHAR(100),
    Estado VARCHAR(100),
    Repuesto VARCHAR(100),
    MarcaRepuesto VARCHAR(50),
    Cantidad INT,
    VU DECIMAL(10, 2),
    VT DECIMAL(10, 2),
    ValorTotalRepuesto DECIMAL(10, 2),
    ValorManoObra DECIMAL(10, 2),
    ValorTotalReparacion DECIMAL(10, 2),
    PRIMARY KEY (NroOrden, Repuesto),
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden)
);

-- Tabla de Seguimiento de Reparacion
CREATE TABLE SeguimientoReparacion (
    NroOrden INT,
    FechaEvento DATE,
    Descripcion TEXT,
    IdEstado INT,
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden),
    FOREIGN KEY (IdEstado) REFERENCES EstadosReparacion(IdEstado)
);

-- Tabla de Servicios Realizados por Mecanico
CREATE TABLE ServiciosRealizadosPorMecanico (
    IdServicioRealizado INT PRIMARY KEY,
    IdMecanico INT,
    IdServicio INT,
    Fecha DATE,
    HorasTrabajadas DECIMAL(5, 2),
    FOREIGN KEY (IdMecanico) REFERENCES Personal(IdEmpleado),
    FOREIGN KEY (IdServicio) REFERENCES Servicios(IdServicio)
);

-- Tabla de Calificaciones de Servicio
CREATE TABLE CalificacionesServicio (
    IdCalificacion INT PRIMARY KEY,
    NroOrden INT,
    IdCliente INT,
    Puntuacion DECIMAL(2, 1),
    Comentario TEXT,
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden),
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
);

-- Tabla de Reservas de Repuestos
CREATE TABLE ReservasRepuestos (
    IdReserva INT PRIMARY KEY,
    IdRepuesto INT,
    Cantidad INT,
    FechaReserva DATE,
    FOREIGN KEY (IdRepuesto) REFERENCES Repuestos(IdRepuesto)
);

-- Tabla de Alertas y Recordatorios
CREATE TABLE AlertasRecordatorios (
    IdAlerta INT PRIMARY KEY,
    Tipo VARCHAR(100),
    FechaHora DATETIME,
    Descripcion TEXT
);

-- Tabla de Costos de Reparación Detallados
CREATE TABLE CostosReparacionDetallados (
    IdCosto INT PRIMARY KEY,
    NroOrden INT,
    Descripcion TEXT,
    Monto DECIMAL(10, 2),
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden)
);

-- Tabla de Historial de Facturación de Clientes
CREATE TABLE HistorialFacturacionClientes (
    IdFactura INT PRIMARY KEY,
    IdCliente INT,
    FechaFactura DATE,
    MontoTotal DECIMAL(10, 2),
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
);

-- Tabla de Eventos de Seguimiento
CREATE TABLE EventosSeguimiento (
    IdEvento INT PRIMARY KEY,
    NroOrden INT,
    TipoEvento VARCHAR(100),
    FechaEvento DATE,
    Descripcion TEXT,
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden)
);

-- Tabla de Comentarios de Clientes
CREATE TABLE ComentariosClientes (
    IdComentario INT PRIMARY KEY,
    NroOrden INT,
    IdCliente INT,
    Fecha DATE,
    Comentario TEXT,
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden),
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
);

-- Tabla de Registro de Seguimiento de Clientes
CREATE TABLE RegistroSeguimientoClientes (
    IdRegistroSeguimiento INT PRIMARY KEY,
    IdCliente INT,
    Fecha DATE,
    TipoComunicacion VARCHAR(100),
    Detalle TEXT,
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
);

-- Tabla de Técnicos Especializados
CREATE TABLE TecnicosEspecializados (
    IdTecnicoEspecializado INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Especialidad VARCHAR(100),
    Experiencia VARCHAR(200)
);

-- Tabla de Vehículos en Espera
CREATE TABLE VehiculosEnEspera (
    IdVehiculoEspera INT PRIMARY KEY,
    NroOrden INT,
    FechaIngreso DATE,
    MotivoEspera TEXT,
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden)
);

-- Tabla de Tareas de Mantenimiento Programado
CREATE TABLE TareasMantenimientoProgramado (
    IdTareaMantenimiento INT PRIMARY KEY,
    IdVehiculo INT,
    IdMantenimientoProgramado INT,
    FechaProgramada DATE,
    Realizada BOOLEAN,
    FOREIGN KEY (IdVehiculo) REFERENCES Vehiculos(IdVehiculo),
    FOREIGN KEY (IdMantenimientoProgramado) REFERENCES MantenimientosProgramados(IdMantenimiento)
);


-- Tabla de Cotizaciones de Servicios
CREATE TABLE CotizacionesServicios (
    IdCotizacion INT PRIMARY KEY,
    NroOrden INT,
    FechaCotizacion DATE,
    Detalle TEXT,
    MontoTotal DECIMAL(10, 2),
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden)
);

-- Tabla de Categorías de Mantenimientos Programados
CREATE TABLE CategoriasMantenimientosProgramados (
    IdCategoriaMantenimiento INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT
);

-- Tabla de Registros de Mantenimiento por Vehículo
CREATE TABLE RegistrosMantenimientoVehiculo (
    IdRegistroMantenimiento INT PRIMARY KEY,
    IdVehiculo INT,
    IdMantenimientoProgramado INT,
    FechaMantenimiento DATE,
    FOREIGN KEY (IdVehiculo) REFERENCES Vehiculos(IdVehiculo),
    FOREIGN KEY (IdMantenimientoProgramado) REFERENCES MantenimientosProgramados(IdMantenimiento)
);

-- Tabla de Repuestos Utilizados en Reparaciones
CREATE TABLE RepuestosUtilizados (
    IdRepuestoUtilizado INT PRIMARY KEY,
    NroOrden INT,
    IdRepuesto INT,
    Cantidad INT,
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden),
    FOREIGN KEY (IdRepuesto) REFERENCES Repuestos(IdRepuesto)
);

-- Tabla de Facturas por Servicios
CREATE TABLE FacturasServicios (
    IdFacturaServicio INT PRIMARY KEY,
    NroFactura INT,
    IdServicio INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    FOREIGN KEY (NroFactura) REFERENCES Facturas(NroFactura),
    FOREIGN KEY (IdServicio) REFERENCES Servicios(IdServicio)
);

-- Tabla de Citas Canceladas
CREATE TABLE CitasCanceladas (
    IdCitaCancelada INT PRIMARY KEY,
    IdCita INT,
    MotivoCancelacion TEXT,
    FOREIGN KEY (IdCita) REFERENCES CitasServicio(IdCita)
);

-- Tabla de Registro de Seguimiento de Repuestos
CREATE TABLE RegistroSeguimientoRepuestos (
    IdRegistroSeguimientoRepuesto INT PRIMARY KEY,
    NroOrden INT,
    IdRepuesto INT,
    Fecha DATE,
    Estado VARCHAR(100),
    Cantidad INT,
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden),
    FOREIGN KEY (IdRepuesto) REFERENCES Repuestos(IdRepuesto)
);

-- Tabla de Historial de Pagos de Clientes
CREATE TABLE HistorialPagosClientes (
    IdHistorialPago INT PRIMARY KEY,
    IdCliente INT,
    FechaPago DATE,
    MontoPago DECIMAL(10, 2),
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
);

-- Tabla de Mantenimientos Realizados por Técnico
CREATE TABLE MantenimientosRealizadosPorTecnico (
    IdMantenimientoRealizado INT PRIMARY KEY,
    IdTecnico INT,
    IdMantenimientoProgramado INT,
    Fecha DATE,
    FOREIGN KEY (IdTecnico) REFERENCES TecnicosEspecializados(IdTecnicoEspecializado),
    FOREIGN KEY (IdMantenimientoProgramado) REFERENCES MantenimientosProgramados(IdMantenimiento)
);

-- Tabla de Detalles de Inspección de Vehículos
CREATE TABLE DetallesInspeccionVehiculo (
    IdDetalleInspeccion INT PRIMARY KEY,
    NroOrden INT,
    Detalle TEXT,
    FOREIGN KEY (NroOrden) REFERENCES InspeccionVehiculos(NroOrden)
);

-- Tabla de Historial de Precios de Repuestos
CREATE TABLE HistorialPreciosRepuestos (
    IdHistorialPrecio INT PRIMARY KEY,
    IdRepuesto INT,
    FechaActualizacion DATE,
    PrecioAnterior DECIMAL(10, 2),
    PrecioNuevo DECIMAL(10, 2),
    FOREIGN KEY (IdRepuesto) REFERENCES Repuestos(IdRepuesto)
);

-- Tabla de Registro de Entrada de Repuestos
CREATE TABLE RegistroEntradaRepuestos (
    IdRegistroEntrada INT PRIMARY KEY,
    IdProveedor INT,
    FechaEntrada DATE,
    IdRepuesto INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedor),
    FOREIGN KEY (IdRepuesto) REFERENCES Repuestos(IdRepuesto)
);

-- Tabla de Registro de Salida de Repuestos
CREATE TABLE RegistroSalidaRepuestos (
    IdRegistroSalida INT PRIMARY KEY,
    IdEmpleado INT,
    FechaSalida DATE,
    IdRepuesto INT,
    Cantidad INT,
    FOREIGN KEY (IdEmpleado) REFERENCES Personal(IdEmpleado),
    FOREIGN KEY (IdRepuesto) REFERENCES Repuestos(IdRepuesto)
);

-- Tabla de Registro de Mantenimiento de Flota de Vehículos
CREATE TABLE RegistroMantenimientoFlota (
    IdRegistroMantenimientoFlota INT PRIMARY KEY,
    IdVehiculo INT,
    IdMantenimientoProgramado INT,
    FechaMantenimiento DATE,
    KilometrajeActual INT,
    FOREIGN KEY (IdVehiculo) REFERENCES Vehiculos(IdVehiculo),
    FOREIGN KEY (IdMantenimientoProgramado) REFERENCES MantenimientosProgramados(IdMantenimiento)
);

-- Tabla de Alertas de Mantenimiento
CREATE TABLE AlertasMantenimiento (
    IdAlertaMantenimiento INT PRIMARY KEY,
    IdVehiculo INT,
    IdMantenimientoProgramado INT,
    FechaAlerta DATE,
    FOREIGN KEY (IdVehiculo) REFERENCES Vehiculos(IdVehiculo),
    FOREIGN KEY (IdMantenimientoProgramado) REFERENCES MantenimientosProgramados(IdMantenimiento)
);

-- Tabla de Gastos de Mantenimiento de Vehículos
CREATE TABLE GastosMantenimientoVehiculo (
    IdGastoMantenimiento INT PRIMARY KEY,
    IdVehiculo INT,
    FechaGasto DATE,
    Descripcion TEXT,
    MontoGasto DECIMAL(10, 2),
    FOREIGN KEY (IdVehiculo) REFERENCES Vehiculos(IdVehiculo)
);

-- Tabla de Registro de Kilometraje de Vehículos
CREATE TABLE RegistroKilometrajeVehiculo (
    IdRegistroKilometraje INT PRIMARY KEY,
    IdVehiculo INT,
    FechaRegistro DATE,
    Kilometraje INT,
    FOREIGN KEY (IdVehiculo) REFERENCES Vehiculos(IdVehiculo)
);
