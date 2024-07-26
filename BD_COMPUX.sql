use master
go

if DB_ID('BD_COMPUX') is not null
begin
	drop database BD_COMPUX
end 
go

create database BD_COMPUX
go

use BD_COMPUX
go


create table TipoEmpleado(
	Id int primary key identity,
	Tipo varchar(20) default 'Sin Tipo'
)
go

insert into TipoEmpleado(Tipo) values ('Vendedor'), ('Administrador');

create table Empleados(
	Id int primary key identity,
	Nombres varchar(20) default '',
	Apellidos varchar(20) default '',
	DNI varchar(10) default '',
	Dirreccion varchar(100) default '',
	FechaNacimiento date default 'Sin fecha',
	Sueldo money default 0 check(Sueldo >= 0),
	FechaIngreso date default GETDATE() check (FechaIngreso <= GETDATE()),
	Correo  varchar(100) unique default '',
	Clave varchar(100) default '',
	IdTipoEmpleado int references TipoEmpleado(Id),
	FechaModificacion date default GETDATE() check (FechaModificacion <= GETDATE()),
	Estado bit default 1
)
go

INSERT INTO Empleados (Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, Sueldo, IdTipoEmpleado, Correo, Clave)
VALUES
('COMPUX', 'X', 'X', 'X', '1985-05-15', 0.00, 1, 'compuxV@gmail.com', 'compux'),
('COMPUX', 'X', 'X', 'X', '1985-05-15', 0.00, 2, 'compuxA@gmail.com', 'compux'),
('Juan', 'Gómez', '12345678', 'Av. Arequipa 123', '1985-05-15', 1800.00, 1, 'juan.gomez@example.com', 'clave123'),
('María', 'López', '87654321', 'Calle San Martín 456', '1990-10-20', 2000.00, 2, 'maria.lopez@example.com', 'clave456'),
('Carlos', 'Martínez', '56781234', 'Jr. Tacna 789', '1988-02-28', 1600.00, 1, 'carlos.martinez@example.com', 'clave789'),
('Ana', 'Rodríguez', '34567890', 'Av. Garcilaso 234', '1993-09-10', 1700.00, 2, 'ana.rodriguez@example.com', 'clave101'),
('Luis', 'Pérez', '98765432', 'Calle Lima 567', '1987-04-25', 1900.00, 1, 'luis.perez@example.com', 'clave202'),
('Laura', 'Gutiérrez', '23456789', 'Av. Brasil 890', '1995-07-12', 1500.00, 2, 'laura.gutierrez@example.com', 'clave303'),
('Pedro', 'Sánchez', '45678901', 'Jr. Puno 123', '1983-11-05', 1800.00, 1, 'pedro.sanchez@example.com', 'clave404'),
('Elena', 'Herrera', '67890123', 'Av. Amazonas 456', '1989-06-18', 1700.00, 2, 'elena.herrera@example.com', 'clave505'),
('Jorge', 'Chávez', '89012345', 'Calle Huancavelica 789', '1992-02-20', 1600.00, 1, 'jorge.chavez@example.com', 'clave606'),
('Carolina', 'Flores', '54321098', 'Av. Argentina 234', '1991-08-15', 2000.00, 2, 'carolina.flores@example.com', 'clave707'),
('Diego', 'Ramírez', '67890543', 'Jr. Cusco 567', '1986-03-30', 1900.00, 1, 'diego.ramirez@example.com', 'clave808'),
('Fernanda', 'García', '10987654', 'Av. Callao 890', '1994-12-02', 1800.00, 2, 'fernanda.garcia@example.com', 'clave909'),
('Roberto', 'Alvarez', '11223344', 'Calle Junín 123', '1990-09-15', 1700.00, 1, 'roberto.alvarez@example.com', 'clave010'),
('Susana', 'Vega', '22334455', 'Av. La Marina 456', '1988-04-20', 1600.00, 2, 'susana.vega@example.com', 'clave011'),
('Raúl', 'Mendoza', '33445566', 'Jr. Trujillo 789', '1993-11-25', 1500.00, 1, 'raul.mendoza@example.com', 'clave012'),
('Carmen', 'Ortega', '44556677', 'Av. Los Incas 234', '1987-06-18', 1900.00, 2, 'carmen.ortega@example.com', 'clave013'),
('Miguel', 'Gómez', '55667788', 'Calle Ayacucho 567', '1991-03-20', 1800.00, 1, 'miguel.gomez@example.com', 'clave014'),
('Paola', 'Suárez', '66778899', 'Av. España 890', '1985-08-10', 1700.00, 2, 'paola.suarez@example.com', 'clave015'),
('Andrés', 'Torres', '77889900', 'Jr. Iquitos 123', '1994-02-05', 1600.00, 1, 'andres.torres@example.com', 'clave016'),
('Valeria', 'Castañeda', '88990011', 'Av. San Borja 456', '1992-12-12', 1500.00, 2, 'valeria.castaneda@example.com', 'clave017'),
('Daniel', 'Ramos', '99001122', 'Calle Arequipa 789', '1983-01-01', 1800.00, 1, 'daniel.ramos@example.com', 'clave018'),
('Lucía', 'Villanueva', '00112233', 'Av. Pardo 890', '1995-11-11', 2000.00, 2, 'lucia.villanueva@example.com', 'clave019'),
('Esteban', 'Morales', '11223344', 'Jr. Ayacucho 123', '1990-05-05', 1700.00, 1, 'esteban.morales@example.com', 'clave020'),
('Sofía', 'Navarro', '22334455', 'Calle Libertad 456', '1988-08-08', 1600.00, 2, 'sofia.navarro@example.com', 'clave021'),
('Victor', 'Paredes', '33445566', 'Av. Grau 789', '1993-12-12', 1500.00, 1, 'victor.paredes@example.com', 'clave022'),
('Adriana', 'Silva', '44556677', 'Jr. San Martin 890', '1987-02-02', 1900.00, 2, 'adriana.silva@example.com', 'clave023'),
('Ricardo', 'Espinoza', '55667788', 'Av. Angamos 123', '1991-10-10', 1800.00, 1, 'ricardo.espinoza@example.com', 'clave024'),
('Natalia', 'Reyes', '66778899', 'Calle Lince 456', '1985-06-06', 1700.00, 2, 'natalia.reyes@example.com', 'clave025'),
('Manuel', 'Ortega', '77889900', 'Jr. Callao 789', '1994-01-01', 1600.00, 1, 'manuel.ortega@example.com', 'clave026'),
('Diana', 'Mendoza', '88990011', 'Av. San Juan 890', '1992-07-07', 1500.00, 2, 'diana.mendoza@example.com', 'clave027'),
('Jose', 'Carrasco', '99001122', 'Calle Cusco 123', '1983-03-03', 1800.00, 1, 'jose.carrasco@example.com', 'clave028'),
('Angela', 'Campos', '00112233', 'Av. Belgrano 456', '1995-09-09', 2000.00, 2, 'angela.campos@example.com', 'clave029'),
('Gonzalo', 'Castro', '11223344', 'Jr. Lima 789', '1990-12-12', 1700.00, 1, 'gonzalo.castro@example.com', 'clave030'),
('Patricia', 'Blanco', '22334455', 'Av. Sucre 890', '1988-05-05', 1600.00, 2, 'patricia.blanco@example.com', 'clave031'),
('Oscar', 'Pérez', '33445566', 'Calle Larco 123', '1993-08-08', 1500.00, 1, 'oscar.perez@example.com', 'clave032'),
('Verónica', 'Fuentes', '44556677', 'Jr. Salaverry 234', '1987-11-11', 1900.00, 2, 'veronica.fuentes@example.com', 'clave033'),
('Hugo', 'Valencia', '55667788', 'Av. Las Flores 345', '1991-02-02', 1800.00, 1, 'hugo.valencia@example.com', 'clave034'),
('Gabriela', 'Miranda', '66778899', 'Calle Independencia 456', '1985-04-04', 1700.00, 2, 'gabriela.miranda@example.com', 'clave035'),
('Mario', 'Santana', '77889900', 'Jr. Ancash 567', '1994-06-06', 1600.00, 1, 'mario.santana@example.com', 'clave036'),
('Daniela', 'Cruz', '88990011', 'Av. Abancay 678', '1992-09-09', 1500.00, 2, 'daniela.cruz@example.com', 'clave037'),
('Andrés', 'Lara', '99001122', 'Calle Miraflores 789', '1983-08-08', 1800.00, 1, 'andres.lara@example.com', 'clave038');
GO

create table Clientes(
	Id int primary key identity,
	Nombres varchar(20) default '',
	Apellidos varchar(20) default '',
	DNI varchar(10) default '',
	Dirreccion varchar(100) default '',
	FechaNacimiento date default 'Sin fecha',
	FechaModificacion date default GETDATE() check (FechaModificacion <= GETDATE()),
	Estado bit default 1
)
go

-- Insertando datos en la tabla Clientes
INSERT INTO Clientes (Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento)
VALUES 
('Carlos', 'Pérez', '23456789', 'Calle Lima 789', '1980-07-25'),
('Luisa', 'Martínez', '45678901', 'Av. Tacna 234', '1992-03-12'),
('José', 'García', '67890123', 'Jr. Arequipa 567', '1985-11-05'),
('María', 'Sánchez', '89012345', 'Av. Puno 901', '1991-04-18'),
('Juan', 'Herrera', '54321098', 'Calle Amazonas 123', '1983-09-30'),
('Ana', 'Chávez', '67890543', 'Av. Huancavelica 456', '1995-12-02'),
('Pedro', 'Flores', '10987654', 'Jr. Argentina 789', '1987-09-15'),
('Laura', 'Ramírez', '34567890', 'Av. Cusco 234', '1993-02-20'),
('Jorge', 'García', '98765432', 'Calle Callao 567', '1989-08-15'),
('Carolina', 'Alvarez', '23456789', 'Av. Junín 890', '1992-03-30'),
('Diego', 'Vega', '45678901', 'Jr. La Marina 123', '1986-10-20'),
('Fernanda', 'Mendoza', '67890123', 'Av. Trujillo 456', '1994-07-05'),
('Roberto', 'Ortega', '89012345', 'Calle Los Incas 789', '1988-12-12'),
('Susana', 'Gómez', '54321098', 'Av. Ayacucho 123', '1991-06-25'),
('Raúl', 'Suárez', '67890543', 'Jr. España 456', '1995-01-10'),
('Carmen', 'Torres', '10987654', 'Av. Iquitos 789', '1987-11-15'),
('Miguel', 'Castañeda', '34567890', 'Calle San Borja 234', '1993-04-30'),
('Paola', 'López', '98765432', 'Av. San Isidro 567', '1989-09-05'),
('Andrés', 'Martín', '23456789', 'Jr. Miraflores 890', '1992-02-15'),
('Valeria', 'Gutiérrez', '45678901', 'Av. Surco 123', '1986-07-20');
go

create table Proveedores(
	Id int primary key identity,
	Nombre varchar(20) default '',
	RUC varchar(15) default '',
	Dirreccion varchar(100) default '',
	FechaModificacion date default GETDATE() check (FechaModificacion <= GETDATE()),
	Estado bit default 1
)
go

-- Insertando datos en la tabla Proveedores
INSERT INTO Proveedores (Nombre, RUC, Dirreccion)
VALUES 
('Distribuidora A', '20123456789', 'Av. Industrial 123'),
('Mayorista B', '20987654321', 'Calle Comercial 456'),
('Proveedor C', '21345678901', 'Jr. Proveedores 789'),
('Suministros D', '23456789012', 'Av. Suministros 234'),
('Importadora E', '24567890123', 'Calle Importación 567'),
('Exportadora F', '25678901234', 'Jr. Exportación 890'),
('Distribuidora G', '26789012345', 'Av. Distribución 123'),
('Mayorista H', '27890123456', 'Calle Mayor 456'),
('Proveedor I', '28901234567', 'Jr. Proveedoría 789'),
('Suministros J', '29012345678', 'Av. Suministro 234'),
('Importadora K', '30123456789', 'Calle Importadora 567'),
('Exportadora L', '31234567890', 'Jr. Exportador 890'),
('Distribuidora M', '32345678901', 'Av. Distribuidora 123'),
('Mayorista N', '33456789012', 'Calle Mayorista 456'),
('Proveedor O', '34567890123', 'Jr. Proveedor 789'),
('Suministros P', '35678901234', 'Av. Suministros 234'),
('Importadora Q', '36789012345', 'Calle Importadora 567'),
('Exportadora R', '37890123456', 'Jr. Exportadora 890'),
('Distribuidora S', '38901234567', 'Av. Distribuidora 123'),
('Mayorista T', '39012345678', 'Calle Mayorista 456');
go

create table Productos(
	Id int primary key identity,
	Nombre varchar(30) default '',
	Descripcion varchar(60) default '',
	Precio money default 0 check(Precio >= 0),
	Cantidad int default 0 check(Cantidad >= 0),
	FechaEntrada date default GETDATE() check (FechaEntrada <= GETDATE()),
	IdProveedores int references Proveedores(Id),
	FechaModificacion date default GETDATE() check (FechaModificacion <= GETDATE()),
	Estado bit default 1
)
go

INSERT INTO Productos (Nombre, Descripcion, Precio, Cantidad, FechaEntrada, IdProveedores)
VALUES 
('Laptop', 'Marca HP, 8GB RAM, SSD 256GB', 2500.00, 10, '2024-06-22', 1),
('Impresora', 'Impresora láser a color', 800.00, 5, '2024-06-22', 2),
('Monitor', 'Monitor LED 24 pulgadas', 400.00, 8, '2024-06-22', 3),
('Teclado', 'Teclado inalámbrico', 100.00, 15, '2024-06-22', 1),
('Mouse', 'Mouse óptico', 50.00, 20, '2024-06-22', 2),
('Disco Duro Externo', '1TB USB 3.0', 120.00, 12, '2024-06-22', 3),
('Audífonos', 'Audífonos Bluetooth', 80.00, 18, '2024-06-22', 1),
('Cámara Web', '1080p con micrófono integrado', 60.00, 25, '2024-06-22', 2),
('Tablet', 'Tablet Android 10 pulgadas', 300.00, 7, '2024-06-22', 3),
('Smartphone', 'Smartphone Android 5.5 pulgadas', 500.00, 10, '2024-06-22', 1),
('Router', 'Router inalámbrico', 80.00, 30, '2024-06-22', 1),
('Switch', 'Switch de 8 puertos', 70.00, 25, '2024-06-22', 2),
('Impresora Multifuncional', 'Impresora, copiadora y escáner', 600.00, 10, '2024-06-22', 3),
('Proyector', 'Proyector HD', 800.00, 8, '2024-06-22', 1),
('Altavoces', 'Altavoces estéreo', 150.00, 15, '2024-06-22', 2),
('Teclado Gamer', 'Teclado mecánico RGB', 120.00, 20, '2024-06-22', 3),
('Mouse Gamer', 'Mouse gaming con DPI ajustable', 100.00, 22, '2024-06-22', 1),
('Disco SSD', 'SSD 500GB SATA', 200.00, 12, '2024-06-22', 2),
('Tarjeta de Video', 'Tarjeta gráfica 4GB GDDR5', 300.00, 10, '2024-06-22', 3),
('Memoria RAM', 'Memoria RAM DDR4 16GB', 150.00, 18, '2024-06-22', 1),
('Laptop', 'Marca Dell, 16GB RAM, SSD 512GB', 3200.00, 12, '2024-06-23', 2),
('Impresora 3D', 'Impresora 3D de alta precisión', 1500.00, 3, '2024-06-23', 3),
('Monitor Curvo', 'Monitor LED 27 pulgadas curvo', 500.00, 6, '2024-06-23', 1),
('Teclado Mecánico', 'Teclado mecánico con retroiluminación', 130.00, 10, '2024-06-23', 2),
('Mouse Ergonómico', 'Mouse ergonómico con botones', 90.00, 25, '2024-06-23', 3),
('Disco Duro SSD', '2TB SSD NVMe', 400.00, 8, '2024-06-23', 1),
('Auriculares', 'Auriculares con cancelación de ruido', 200.00, 14, '2024-06-23', 2),
('Cámara de Seguridad', 'Cámara IP de alta resolución', 100.00, 30, '2024-06-23', 3),
('Tablet Pro', 'Tablet iOS 11 pulgadas', 600.00, 5, '2024-06-23', 1),
('Smartwatch', 'Smartwatch con monitor de actividad', 250.00, 20, '2024-06-23', 2),
('Router Gaming', 'Router de alta velocidad para juegos', 150.00, 15, '2024-06-23', 3),
('Switch Administrable', 'Switch de 24 puertos administrable', 250.00, 10, '2024-06-23', 1),
('Impresora Fotográfica', 'Impresora para fotografías de alta calidad', 700.00, 7, '2024-06-23', 2),
('Proyector 4K', 'Proyector 4K UHD', 1200.00, 6, '2024-06-23', 3),
('Altavoces Bluetooth', 'Altavoces inalámbricos', 180.00, 10, '2024-06-23', 1),
('Teclado Compacto', 'Teclado compacto inalámbrico', 90.00, 18, '2024-06-23', 2),
('Mouse Vertical', 'Mouse vertical ergonómico', 70.00, 20, '2024-06-23', 3),
('Disco Duro Interno', '3TB HDD SATA', 100.00, 15, '2024-06-23', 1),
('Tarjeta de Sonido', 'Tarjeta de sonido 7.1', 150.00, 12, '2024-06-23', 2),
('Memoria RAM', 'Memoria RAM DDR4 32GB', 300.00, 10, '2024-06-23', 3),
('Laptop Gaming', 'Laptop Gaming ASUS, 32GB RAM, SSD 1TB', 4500.00, 5, '2024-06-24', 1),
('Impresora Matricial', 'Impresora matricial de 24 pines', 500.00, 8, '2024-06-24', 2),
('Monitor 4K', 'Monitor LED 32 pulgadas 4K', 600.00, 7, '2024-06-24', 3),
('Teclado Multimedia', 'Teclado con teclas multimedia', 70.00, 25, '2024-06-24', 1),
('Mouse Trackball', 'Mouse con bola de seguimiento', 80.00, 18, '2024-06-24', 2),
('Disco Duro NAS', '4TB HDD para NAS', 200.00, 10, '2024-06-24', 3),
('Auriculares Gamer', 'Auriculares con micrófono y luces RGB', 120.00, 15, '2024-06-24', 1),
('Cámara DSLR', 'Cámara réflex digital', 1000.00, 4, '2024-06-24', 2),
('Tablet Kids', 'Tablet resistente para niños', 150.00, 12, '2024-06-24', 3),
('Smartphone Pro', 'Smartphone Android 6.7 pulgadas', 800.00, 8, '2024-06-24', 1),
('Router Mesh', 'Sistema de router mesh', 250.00, 20, '2024-06-24', 2),
('Switch PoE', 'Switch de 16 puertos PoE', 300.00, 9, '2024-06-24', 3);
Go

create table Ventas(
	Id int primary key identity,
	IdClientes int references Clientes(Id),
	IdEmpleados int references Empleados(Id),
	FechaVenta date default GETDATE(),
	FechaModificacion date default GETDATE() check (FechaModificacion <= GETDATE()),
	Estado bit default 1
)
go


-- Insertando datos en la tabla Ventas
INSERT INTO Ventas (IdClientes, IdEmpleados, FechaVenta)
VALUES 
(1, 1, '2024-01-01'),
(2, 2, '2024-02-01'),
(3, 3, '2024-03-01'),
(4, 4, '2024-04-01'),
(5, 5, '2024-05-01'),
(6, 6, '2024-06-01'),
(7, 7, '2024-07-01'),
(8, 8, '2024-07-01'),
(9, 9, '2024-07-01'),
(10, 10, '2024-02-01'),
(11, 11, '2024-01-01'),
(12, 4, '2024-03-01'),
(13, 5, '2024-04-01'),
(14, 6, '2024-05-01'),
(15, 7, '2024-06-01'),
(16, 8, '2024-04-01'),
(17, 9, '2024-03-01'),
(18, 11, '2024-02-01'),
(4, 15, '2024-01-01'),
(5, 12, '2024-02-01');
go

create table VentasDetalles(
	Id int primary key identity,
	IdVentas int references Ventas(Id),
	IdProductos int references Productos(Id),
	Cantidad int default 0 check (Cantidad >= 0),
	Monto money default 0 check (Monto >= 0),
	FechaModificacion date default GETDATE() check (FechaModificacion <= GETDATE()),
	Estado bit default 1
)
go

-- Insertando datos en la tabla VentasDetalles
INSERT INTO VentasDetalles (IdVentas, IdProductos, Cantidad, Monto)
VALUES 
(1, 1, 2, 5000.00),
(1, 2, 1, 800.00),
(2, 3, 1, 400.00),
(2, 4, 1, 100.00),
(3, 5, 1, 50.00),
(3, 6, 1, 120.00),
(4, 7, 1, 80.00),
(4, 8, 1, 60.00),
(5, 9, 1, 300.00),
(5, 10, 1, 500.00),
(6, 11, 1, 80.00),
(6, 12, 1, 70.00),
(7, 13, 1, 600.00),
(7, 14, 1, 800.00),
(8, 15, 1, 150.00),
(8, 16, 1, 120.00),
(9, 17, 1, 100.00),
(9, 18, 1, 200.00),
(10, 19, 1, 300.00),
(10, 20, 1, 150.00);
go




--- PROCEDURES DE CLIENTES
create or alter proc ListarClientesAll
as
	select Id, Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, FechaModificacion, Estado from Clientes
go
create or alter proc ListarClientesBusqueda
@Nombre varchar(20)
as
	select Id, Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, FechaModificacion, Estado from Clientes
	where Nombres like @Nombre +'%'
go

create or alter proc CrearCliente
@Nombres varchar(20),
@Apellidos varchar(20),
@DNI varchar(10),
@Dirreccion varchar(100),
@FechaNacimiento date,
@Estado bit
as
	insert into Clientes(Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, FechaModificacion, Estado)
	values (@Nombres, @Apellidos, @DNI, @Dirreccion, @FechaNacimiento, GETDATE(), @Estado)
go

create or alter proc BuscarClienteId
@Id int
as
	select Id, Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, FechaModificacion, Estado from Clientes
	where Id = @Id
go

create or alter proc EditarCliente
@Id int,
@Nombres varchar(20),
@Apellidos varchar(20),
@DNI varchar(10),
@Dirreccion varchar(100),
@FechaNacimiento date,
@Estado bit
as
	update Clientes set Nombres = @Nombres, Apellidos = @Apellidos, DNI = @DNI, Dirreccion = @Dirreccion, FechaNacimiento = @FechaNacimiento, FechaModificacion = GETDATE(), Estado = @Estado
	where Id = @Id
go
create or alter proc EliminarClienteId
@Id int
as
	delete from Clientes
	where Id = @Id
go
-- PROCEUDRES DE TIPOS EMPLEADO
create or alter proc ListarTiposEmpleadoAll
as
	select Id, Tipo from TipoEmpleado
go

-- PROCEDURES DE EMPLEADOS

create or alter proc ListarEmpleadosAll
as
	select e.Id, Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, Sueldo, FechaIngreso, Correo, Clave, te.Tipo, FechaModificacion, Estado from Empleados e join TipoEmpleado te on e.IdTipoEmpleado = te.Id
go
create or alter proc ListarEmpleadosBusqueda
@Nombre varchar(20)
as
	select e.Id, Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, Sueldo, FechaIngreso, Correo, Clave, te.Tipo, FechaModificacion, Estado from Empleados e join TipoEmpleado te on e.IdTipoEmpleado = te.Id
	where Nombres like @Nombre +'%'
go
create or alter proc CrearEmpleado
@Nombres varchar(20),
@Apellidos varchar(20),
@DNI varchar(10),
@Dirreccion varchar(100),
@FechaNacimiento date,
@Sueldo money,
@FechaIngreso date,
@Correo  varchar(100),
@Clave varchar(100),
@IdTipoEmpleado int,
@Estado bit
as
	insert into Empleados(Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, Sueldo, FechaIngreso, Correo, Clave, IdTipoEmpleado, FechaModificacion, Estado)
	values (@Nombres, @Apellidos, @DNI, @Dirreccion, @FechaNacimiento, @Sueldo, @FechaIngreso, @Correo, @Clave, @IdTipoEmpleado, GETDATE(), @Estado)
go 

create or alter proc BuscarEmpleadoId
@Id int
as
	select Id, Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, Sueldo, FechaIngreso, Correo, Clave, IdTipoEmpleado, FechaModificacion, Estado from Empleados
	where Id = @Id
go


create or alter proc BuscarEmpleadoDId
@Id int
as
	select e.Id, Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, Sueldo, FechaIngreso, Correo, Clave, te.Tipo, FechaModificacion, Estado from Empleados e join TipoEmpleado te on e.IdTipoEmpleado = te.Id
	where e.Id = @Id
go

create or alter proc EditarEmpleado
@Id int,
@Nombres varchar(20),
@Apellidos varchar(20),
@DNI varchar(10),
@Dirreccion varchar(100),
@FechaNacimiento date,
@Sueldo money,
@FechaIngreso date,
@Correo  varchar(100),
@Clave varchar(100),
@IdTipoEmpleado int,
@Estado bit
as 
	update Empleados set Nombres = @Nombres, Apellidos = @Apellidos, DNI = @DNI, Dirreccion = @Dirreccion, FechaNacimiento = @FechaNacimiento, Sueldo = @Sueldo, FechaIngreso = @FechaIngreso, Correo = @Correo, Clave = @Clave, IdTipoEmpleado = @IdTipoEmpleado, FechaModificacion = GETDATE(), Estado = @Estado
	where Id = @Id
go

create or alter proc EliminarEmpleadoId
@Id int
as
	delete from Empleados
	where Id = @Id
go

-- PROCEDURES DE PROVEEDORES
create or alter proc ListarProveedoresAll
as
	select Id, Nombre, RUC, Dirreccion, FechaModificacion, Estado from Proveedores
go
create or alter proc ListarProveedoresBusqueda
@Nombre varchar(20)
as
	select Id, Nombre, RUC, Dirreccion, FechaModificacion, Estado from Proveedores
	where Nombre like @Nombre +'%'
go

create or alter proc CrearProveedor
@Nombre varchar(20),
@RUC varchar(15),
@Dirreccion varchar(100),
@Estado bit
as
	insert into Proveedores(Nombre, RUC, Dirreccion, FechaModificacion, Estado)
	values (@Nombre, @RUC, @Dirreccion, GETDATE(), @Estado)
go

create or alter proc BuscarProveedorId
@Id int
as
	select Id, Nombre, RUC, Dirreccion, FechaModificacion, Estado from Proveedores
	where Id = @Id
go

create or alter proc EditarProveedor
@Id int,
@Nombre varchar(20),
@RUC varchar(15),
@Dirreccion varchar(100),
@Estado bit
as
	update Proveedores set Nombre = @Nombre, RUC = @RUC, Dirreccion = @Dirreccion, FechaModificacion = GETDATE(), Estado = @Estado
	where Id = @Id
go

create or alter proc EliminarProveedorId
@Id int
as
	Delete from Proveedores
	where Id = @Id
go

-- PROCEDURES DE PRODUCTOS
create or alter proc ListarProductosAll
as
	select p.Id, p.Nombre, Descripcion, Precio, Cantidad, FechaEntrada, pro.Nombre, p.FechaModificacion, p.Estado from Productos p join Proveedores pro on p.IdProveedores = pro.Id
go

create or alter proc ListarProductosBusqueda
@Nombre varchar(30)
as
	select p.Id, p.Nombre, Descripcion, Precio, Cantidad, FechaEntrada, pro.Nombre, p.FechaModificacion, p.Estado from Productos p join Proveedores pro on p.IdProveedores = pro.Id
	where p.Nombre like @Nombre +'%'
go

create or alter proc CrearProducto
@Nombre varchar(30),
@Descripcion varchar(40),
@Precio money,
@Cantidad int,
@IdProveedores int,
@Estado bit
as
	insert into Productos(Nombre, Descripcion, Precio, Cantidad, FechaEntrada, IdProveedores, FechaModificacion, Estado)
	values(@Nombre, @Descripcion, @Precio, @Cantidad, GETDATE(), @IdProveedores, GETDATE(), @Estado)
go

create or alter proc EditarProducto
@Id int,
@Nombre varchar(30),
@Descripcion varchar(40),
@Precio money,
@Cantidad int,
@IdProveedores int,
@Estado bit
as
	update Productos set Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Cantidad = @Cantidad, IdProveedores = @IdProveedores, FechaModificacion = GETDATE(), Estado = @Estado
	where Id = @Id
go

create or alter proc buscarProductoId
@Id int
as
	select Id, Nombre, Descripcion, Precio, Cantidad, FechaEntrada, IdProveedores, FechaModificacion, Estado from Productos
	where Id = @Id
go

create or alter proc buscarProductoDId
@Id int
as
	select p.Id, p.Nombre, Descripcion, Precio, Cantidad, FechaEntrada, pro.Nombre, p.FechaModificacion, p.Estado from Productos p join Proveedores pro on p.IdProveedores = pro.Id
	where p.Id = @Id
go

create or alter proc EliminarProductoId
@Id int
as
	delete from Productos where Id = @Id
go

--PROC VENTAS
create or alter proc CrearVenta
@IdCliente int,
@IdEmpleado int
as 
	insert into Ventas(IdClientes, IdEmpleados, FechaVenta, FechaModificacion, Estado)
	values(@IdCliente, @IdEmpleado, GETDATE(), GETDATE(), 1)

	select @@IDENTITY as Id
go

create or alter proc CrearVentaDetalle
@IdVenta int,
@IdProducto int,
@Cantidad int
as
	insert into VentasDetalles(IdVentas, IdProductos, Cantidad, Monto, FechaModificacion, Estado)
	values(@IdVenta, @IdProducto, @Cantidad, (SELECT Precio FROM Productos WHERE Id = @IdProducto) * @Cantidad, GETDATE(), 1)
go

--Proc Login 
create or alter proc sp_LoginEmpleado(
@Correo varchar (100),
@Clave varchar (100)
)
as
begin
	select e.Id, Nombres, Apellidos, DNI, Dirreccion, FechaNacimiento, Sueldo, FechaIngreso, Correo, Clave, te.Tipo, FechaModificacion, Estado from Empleados e join TipoEmpleado te on e.IdTipoEmpleado = te.Id
	where Correo = @Correo and Clave = @Clave
end
go

--Proc ResporteVentas

create or alter proc RegistroVentas
@FechaInicio date,
@FechaFin date
as
	SELECT Ventas.Id, Empleados.Nombres + ' ' + Empleados.Apellidos as Empleado, Clientes.Nombres + ' ' +Clientes.Apellidos AS Cliente, Productos.Nombre, Productos.Precio, VentasDetalles.Cantidad, VentasDetalles.Monto, Ventas.FechaVenta
	FROM Ventas INNER JOIN
	VentasDetalles ON Ventas.Id = VentasDetalles.IdVentas INNER JOIN
    Empleados ON Ventas.IdEmpleados = Empleados.Id INNER JOIN
    Clientes ON Ventas.IdClientes = Clientes.Id INNER JOIN
    Productos ON VentasDetalles.IdProductos = Productos.Id
	where Ventas.FechaVenta between @FechaInicio and @FechaFin
go

create or alter proc RegistroVentasMonto
@FechaInicio date,
@FechaFin date
as
	select v.Id, SUM(vd.Monto) 
	from Ventas v join VentasDetalles vd on v.Id = vd.IdVentas
	where FechaVenta between @FechaInicio and @FechaFin
	group by v.Id
go

--Proc Dashboard

create or alter proc DashboardDatosCantidad
as
	select (select COUNT(*) from Clientes) as Clientes, (select COUNT(*) from Productos) as Productos, (select COUNT(*) from Proveedores) as Proveedores, (select COUNT(*) from Empleados) as Empleados, (select COUNT(*) from Ventas) as Ventas
go

create or alter proc DashboardDatosSuma
as
	select (select SUM(Monto) from VentasDetalles) as Ventas, (select SUM(Sueldo) from Empleados) as Sueldos, (select SUM(Precio * Cantidad) from Productos) as Productos
go

create or alter proc DashboardDatosVentas
as
	select MONTH(FechaVenta), SUM(Monto)  
	from Ventas v join VentasDetalles vd on v.Id = vd.IdVentas
	where YEAR(FechaVenta) = YEAR(GETDATE()) and  MONTH(FechaVenta) between 1 and 12
	group by MONTH(FechaVenta)
go