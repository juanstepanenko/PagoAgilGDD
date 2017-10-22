USE [GD2C2017]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- CREACION DE SCHEMA --
-- Comprueba si no existe ninguno, sino existe lo crea.

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'AMBDA')
BEGIN
	EXEC ('CREATE SCHEMA AMBDA AUTHORIZATION gd')
END

-- FIN CREACION DE SCHEMA --

-- ELIMINACION DE TABLAS NECESARIAS --
-- Si existe, lo elimina

IF OBJECT_ID('[AMBDA].[FacturaxPago]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[FacturaxPago]

IF OBJECT_ID('[AMBDA].[RolxFunc]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[RolxFunc]

IF OBJECT_ID('[AMBDA].[RolxUsuario]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[RolxUsuario]

IF OBJECT_ID('[AMBDA].[SucursalxUsuario]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[SucursalxUsuario]

IF OBJECT_ID('[AMBDA].[Rendicion]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Rendicion]

IF OBJECT_ID('[AMBDA].[Renglon]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Renglon]

IF OBJECT_ID('[AMBDA].[Devolucion]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Devolucion]

IF OBJECT_ID('[AMBDA].[Factura]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Factura]

IF OBJECT_ID('[AMBDA].[RegistroPago]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[RegistroPago]

IF OBJECT_ID('[AMBDA].[MedioDePago]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[MedioDePago]

IF OBJECT_ID('[AMBDA].[Usuario]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Usuario]

IF OBJECT_ID('[AMBDA].[Sucursal]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Sucursal]

IF OBJECT_ID('[AMBDA].[Rol]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Rol]

IF OBJECT_ID('[AMBDA].[Funcionalidad]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Funcionalidad]

IF OBJECT_ID('[AMBDA].[Empresa]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Empresa]

IF OBJECT_ID('[AMBDA].[Rubro]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Rubro]

IF OBJECT_ID('[AMBDA].[Cliente]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Cliente]

-- FIN ELIMINACION DE TABLAS --

-- ELIMINACION DE PROCESOS, FUNCIONES, VISTAS Y TRIGGERS NECESARIOS
-- Si existe, lo elimina

-------------------------------------------
-----Creación de tablas y foreign keys-----
-------------------------------------------

CREATE TABLE [AMBDA].[Cliente](
	[clie_dni] [numeric](18, 0),
	[clie_mail] [nvarchar](255), --unique TODO
	[clie_nombre] [nvarchar](255),
	[clie_apellido] [nvarchar](255),
	[clie_direccion] [nvarchar](255),
	[clie_cod_postal] [nvarchar](255),
	[clie_fecha_nacimiento] [datetime],
	[clie_telefono] [numeric](18, 0),
	[clie_habilitado] [bit] NOT NULL DEFAULT 1,
 PRIMARY KEY (clie_dni)
)

CREATE TABLE [AMBDA].[Rubro](
	[rubr_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[rubr_descripcion] [nvarchar](50),
	PRIMARY KEY (rubr_id)
)

CREATE TABLE [AMBDA].[Empresa](
	[empr_cuit] [nvarchar](50),
	[empr_nombre] [nvarchar](255),
	[empr_direccion] [nvarchar](255),
	[empr_rubro] [numeric](18, 0),
	[empr_habilitada] [bit] NOT NULL DEFAULT 1,
	PRIMARY KEY (empr_cuit),
	FOREIGN KEY (empr_rubro) REFERENCES AMBDA.Rubro (rubr_id)
 )

CREATE TABLE [AMBDA].[Factura](
	[fact_nro] [numeric](18, 0) IDENTITY(1,1),
	[fact_fecha] [datetime],
	[fact_total] [numeric](18, 2),
	[fact_fecha_venc] [datetime],
	[fact_cliente] [numeric](18, 0),
	[fact_empresa] [nvarchar](50),
	[fact_cobrada] [bit] NOT NULL DEFAULT 0,
	[fact_rendida] [bit] NOT NULL DEFAULT 0,
	PRIMARY KEY (fact_nro),
	FOREIGN KEY (fact_cliente) REFERENCES AMBDA.Cliente (clie_dni),
	FOREIGN KEY (fact_empresa) REFERENCES AMBDA.Empresa (empr_cuit)
 )

CREATE TABLE [AMBDA].[Devolucion](
	[devo_id] [numeric](18, 0) IDENTITY(1,1),
	[devo_motivo] [nvarchar](255),
	[devo_fecha] [datetime],
	[devo_factura] [numeric](18, 0),
	PRIMARY KEY (devo_id),
	FOREIGN KEY (devo_factura) REFERENCES AMBDA.Factura (fact_nro)
 )

 CREATE TABLE [AMBDA].[Renglon](
	[reng_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[reng_monto] [numeric](18, 2),
	[reng_cantidad] [numeric](18, 0),
	[reng_factura] [numeric](18, 0),
	[reng_item] [numeric](18, 0),
	PRIMARY KEY (reng_id),
	FOREIGN KEY (reng_factura) REFERENCES AMBDA.Factura (fact_nro)
 )

 CREATE TABLE [AMBDA].[Rendicion](
	[rend_nro] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[rend_fecha] [datetime],
	[rend_cant_facturas] [numeric](18, 0),
	[rend_factura] [numeric](18, 0),
	[rend_importe_total] [numeric](18, 2),
	[rend_porcentaje] [numeric](18, 0),
	[rend_empresa] [nvarchar](50),
	PRIMARY KEY (rend_nro),
	FOREIGN KEY (rend_factura) REFERENCES AMBDA.Factura (fact_nro),
	FOREIGN KEY (rend_empresa) REFERENCES AMBDA.Empresa (empr_cuit)
 )

 CREATE TABLE [AMBDA].[MedioDePago](
	[medi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[medi_descripcion] [nvarchar](255),
 PRIMARY KEY (medi_id)
)

CREATE TABLE [AMBDA].[Sucursal](
	[sucu_cod_postal] [numeric](18, 0),
	[sucu_nombre] [nvarchar](255),
	[sucu_direccion] [nvarchar](255),
	[sucu_habilitada] [bit] NOT NULL DEFAULT 1,
 PRIMARY KEY (sucu_cod_postal)
 )

 CREATE TABLE [AMBDA].[Usuario](
	[usua_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[usua_username] [nvarchar](255),
	[usua_password] [nvarchar](255), --- SE LE PONE DEFAULT?
	[usua_habilitado] [bit] NOT NULL DEFAULT 1,
	[usua_intentos_fallidos] [int] NOT NULL DEFAULT 0,
	PRIMARY KEY (usua_id)
)

CREATE TABLE [AMBDA].[Rol](
	[rol_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[rol_nombre] [nvarchar](255) NOT NULL,
	[rol_habilitado] [bit] NOT NULL DEFAULT 1,
 PRIMARY KEY (rol_id)
 )

 CREATE TABLE [AMBDA].[Funcionalidad](
	[func_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[func_descripcion] [nvarchar](255) NOT NULL,
 PRIMARY KEY (func_id)
 )

 CREATE TABLE [AMBDA].[RolxFunc](
	[func_id] [numeric](18, 0),
	[rol_id] [numeric](18, 0),
	PRIMARY KEY (func_id, rol_id),
	FOREIGN KEY (func_id) REFERENCES AMBDA.Funcionalidad (func_id),
	FOREIGN KEY (rol_id) REFERENCES AMBDA.Rol (rol_id)
)

CREATE TABLE [AMBDA].[RolxUsuario](
	[usua_id] [numeric](18, 0),
	[rol_id] [numeric](18, 0),
	PRIMARY KEY (usua_id, rol_id),
	FOREIGN KEY (usua_id) REFERENCES AMBDA.Usuario (usua_id),
	FOREIGN KEY (rol_id) REFERENCES AMBDA.Rol (rol_id)
)

CREATE TABLE [AMBDA].[SucursalxUsuario](
	[usua_id] [numeric](18, 0),
	[sucu_cod_postal] [numeric](18, 0),
	PRIMARY KEY (usua_id, sucu_cod_postal),
	FOREIGN KEY (usua_id) REFERENCES AMBDA.Usuario (usua_id),
	FOREIGN KEY (sucu_cod_postal) REFERENCES AMBDA.Sucursal (sucu_cod_postal)
)

CREATE TABLE [AMBDA].[RegistroPago](
	[regi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[regi_fecha_cobro] [datetime] ,
	[regi_empresa] [nvarchar](50),
	[regi_cliente] [numeric](18, 0),
	[regi_importe] [numeric](18, 2),
	[regi_usuario] [numeric](18, 0),
	[regi_sucursal] [numeric](18, 0),
	[regi_medio_pago] [numeric](18, 0),
	PRIMARY KEY (regi_id),
	FOREIGN KEY (regi_empresa) REFERENCES AMBDA.Empresa (empr_cuit),
	FOREIGN KEY (regi_cliente) REFERENCES AMBDA.Cliente (clie_dni),
	FOREIGN KEY (regi_usuario) REFERENCES AMBDA.Usuario (usua_id),
	FOREIGN KEY (regi_sucursal) REFERENCES AMBDA.Sucursal (sucu_cod_postal),
	FOREIGN KEY (regi_medio_pago) REFERENCES AMBDA.MedioDePago (medi_id)
)

CREATE TABLE [AMBDA].[FacturaxPago](
	[fact_nro] [numeric](18, 0),
	[regi_id] [numeric](18, 0),
	PRIMARY KEY (fact_nro, regi_id),
	FOREIGN KEY (fact_nro) REFERENCES AMBDA.Factura (fact_nro),
	FOREIGN KEY (regi_id) REFERENCES AMBDA.RegistroPago (regi_id)
)

-------Fin creacion de tablas
----TODO agregar los unique

---------------------------------------
----------Migración e índices----------
---------------------------------------
--Agregando roles.
INSERT INTO AMBDA.Rol (rol_nombre)
	VALUES ('Administrador'), ('Cobrador')

--Agregando funcionalidades.
INSERT INTO AMBDA.Funcionalidad(func_descripcion)
	VALUES	('ABM Roles'),
			('ABM Clientes'),
			('ABM Empresas'),
			('ABM Sucursales'),
			('ABM Facturas'),
			('Login y Seguridad'),
			('Registro de Usuario'),
			('Registro de Pago de Facturas'),
			('Rendición de facturas cobradas'),
			('Listado estadístico')


--Agregando funcionalidades por cada rol.
INSERT INTO AMBDA.RolxFunc(
	rol_id, func_id)
SELECT
	rol_id, func_id
FROM AMBDA.Rol, AMBDA.Funcionalidad
WHERE	(rol_nombre = 'Cobrador' AND
			func_descripcion IN ('Login y Seguridad', 'Registro de Usuario','Registro de Pago de Facturas')) OR
		(rol_nombre = 'Administrador' AND
			func_descripcion LIKE '%')

--Migrando clientes.
INSERT INTO AMBDA.cliente(
	clie_dni, clie_nombre, clie_apellido, clie_direccion, clie_mail,
	clie_cod_postal, clie_fecha_nacimiento, clie_telefono)
SELECT DISTINCT
	[Cliente-Dni], [Cliente-Nombre], [Cliente-Apellido], Cliente_Direccion, Cliente_Mail,
	Cliente_Codigo_Postal, [Cliente-Fecha_Nac], '1111111111'
FROM gd_esquema.Maestra
WHERE [Cliente-Dni] IS NOT NULL

--Migrando rubros.
SET IDENTITY_INSERT AMBDA.Rubro ON;

INSERT INTO AMBDA.Rubro(
	rubr_id, rubr_descripcion)
SELECT DISTINCT
	Empresa_Rubro, Rubro_Descripcion
FROM gd_esquema.Maestra
WHERE Empresa_Rubro IS NOT NULL

SET IDENTITY_INSERT AMBDA.Rubro OFF;

--Migrando empresas.
INSERT INTO AMBDA.Empresa(
	empr_cuit, empr_nombre, empr_direccion, empr_rubro)
SELECT DISTINCT
	Empresa_Cuit, Empresa_Nombre, Empresa_Direccion, (SELECT rubr_id FROM AMBDA.Rubro r WHERE Empresa_Rubro = r.rubr_id)
	FROM gd_esquema.Maestra
WHERE Empresa_Cuit IS NOT NULL

--Migrando facturas.
SET IDENTITY_INSERT AMBDA.Factura ON;

INSERT INTO AMBDA.Factura(
	fact_nro, fact_fecha, fact_total, fact_fecha_venc)
SELECT DISTINCT
	Nro_Factura, Factura_Fecha,
	Factura_Total, Factura_Fecha_Vencimiento
FROM gd_esquema.Maestra
WHERE Nro_Factura IS NOT NULL

SET IDENTITY_INSERT AMBDA.Factura OFF;

--Migrando renglones.
INSERT INTO AMBDA.Renglon(
	reng_monto, reng_cantidad)
SELECT
	ItemFactura_Monto, ItemFactura_Cantidad
FROM gd_esquema.Maestra
WHERE ItemFactura_Monto IS NOT NULL

-- Faltan ahora los usuarios y los index.

