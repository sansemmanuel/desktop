create database DESPACHO
go

use DESPACHO
go

CREATE TABLE Empleados (
    EmpleadoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    ApellidoPaterno NVARCHAR(50) NOT NULL,
    ApellidoMaterno NVARCHAR(50) NOT NULL,
    Edad INT,
    FechaNacimiento DATE,
    Genero NVARCHAR(10),
    EstadoCivil NVARCHAR(20),
    RFC NVARCHAR(13),
    Direccion NVARCHAR(100),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20),
    Puesto NVARCHAR(50),
    FechaAlta DATE,
    FechaBaja DATE
);
go
