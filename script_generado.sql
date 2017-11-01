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

IF OBJECT_ID('[AMBDA].[Renglon]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Renglon]

IF OBJECT_ID('[AMBDA].[Devolucion]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Devolucion]

IF OBJECT_ID('[AMBDA].[Factura]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Factura]

IF OBJECT_ID('[AMBDA].[Rendicion]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Rendicion]

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

IF OBJECT_ID('[AMBDA].[Direccion]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Direccion]

-- FIN ELIMINACION DE TABLAS --

-- ELIMINACION DE PROCESOS, FUNCIONES, VISTAS Y TRIGGERS NECESARIOS
-- Si existe, lo elimina

IF OBJECT_ID('AMBDA.crear_cliente', 'P') IS NOT NULL
DROP PROCEDURE AMBDA.crear_cliente

IF OBJECT_ID('AMBDA.crear_direccion', 'P') IS NOT NULL
DROP PROCEDURE AMBDA.crear_direccion

IF OBJECT_ID('AMBDA.crear_empresa', 'P') IS NOT NULL
DROP PROCEDURE AMBDA.crear_empresa

IF OBJECT_ID('AMBDA.crear_pago', 'P') IS NOT NULL
DROP PROCEDURE AMBDA.crear_pago

IF OBJECT_ID('AMBDA.login', 'P') IS NOT NULL
DROP PROCEDURE AMBDA.login

IF OBJECT_ID('AMBDA.crear_factura', 'P') IS NOT NULL
DROP PROCEDURE AMBDA.crear_factura

IF OBJECT_ID('AMBDA.crear_item', 'P') IS NOT NULL
DROP PROCEDURE AMBDA.crear_item

IF OBJECT_ID('AMBDA.crear_devolucion', 'P') IS NOT NULL
DROP PROCEDURE AMBDA.crear_devolucion

IF OBJECT_ID('AMBDA.pagar_factura', 'P') IS NOT NULL
DROP PROCEDURE AMBDA.pagar_factura

IF OBJECT_ID ('AMBDA.listados') IS NOT NULL
DROP PROCEDURE AMBDA.listados

IF OBJECT_ID ('AMBDA.porcentaje_facturas_empresas_por_mes') IS NOT NULL
DROP PROCEDURE AMBDA.porcentaje_facturas_empresas_por_mes

IF OBJECT_ID ('AMBDA.empresas_mayor_monto_facturado') IS NOT NULL
DROP PROCEDURE AMBDA.empresas_mayor_monto_facturado

IF OBJECT_ID ('AMBDA.clientes_mas_pagos') IS NOT NULL
DROP PROCEDURE AMBDA.clientes_mas_pagos

IF OBJECT_ID ('AMBDA.clientes_cumplidores') IS NOT NULL
DROP PROCEDURE AMBDA.clientes_cumplidores


-------------------------------------------
-----Creación de tablas y foreign keys-----
-------------------------------------------

CREATE TABLE [AMBDA].[Direccion](
	[direc_id] numeric(18,0) IDENTITY(1,1),
	[direc_calleNro] nvarchar(100),
	[direc_piso] numeric(18,0),
	[direc_depto] nvarchar(5),
	[direc_cod_postal] nvarchar(50),
	[direc_localidad] nvarchar(50),
	PRIMARY KEY(direc_id)
)

CREATE TABLE [AMBDA].[Cliente](
	[clie_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[clie_dni] [numeric](18, 0),
	[clie_mail] [nvarchar](255), -- hay uno duplicado en la maestra
	[clie_nombre] [nvarchar](255),
	[clie_apellido] [nvarchar](255),
	[clie_direc_id] numeric(18,0),
	[clie_fecha_nacimiento] [datetime],
	[clie_telefono] [numeric](18, 0),
	[clie_habilitado] [bit] NOT NULL DEFAULT 1,
	FOREIGN KEY ([clie_direc_id]) REFERENCES AMBDA.Direccion (direc_id),
	PRIMARY KEY (clie_id)
)

CREATE TABLE [AMBDA].[Rubro](
	[rubr_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[rubr_descripcion] [nvarchar](50),
	PRIMARY KEY (rubr_id)
)

CREATE TABLE [AMBDA].[Empresa](
	[empr_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[empr_cuit] [nvarchar](50),
	[empr_nombre] [nvarchar](255),
	[empr_direc_id] [numeric](18, 0),
	[empr_rubro] [numeric](18, 0),
	[empr_habilitada] [bit] NOT NULL DEFAULT 1,
	PRIMARY KEY (empr_id),
	FOREIGN KEY (empr_rubro) REFERENCES AMBDA.Rubro (rubr_id)
 )

 CREATE TABLE [AMBDA].[Rendicion](
	[rend_nro] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[rend_fecha] [datetime],
	[rend_cant_facturas] [numeric](18, 0),
	[rend_importe_total] [numeric](18, 2),
	[rend_porcentaje] [numeric](18, 0),
	[rend_empresa] [numeric](18, 0)
	PRIMARY KEY (rend_nro),
	FOREIGN KEY (rend_empresa) REFERENCES AMBDA.Empresa (empr_id)
 )

 CREATE TABLE [AMBDA].[Factura](
	[fact_id] [numeric](18, 0) IDENTITY(1,1),
	[fact_nro] [numeric](18, 0),
	[fact_fecha] [datetime],
	[fact_total] [numeric](18, 2),
	[fact_fecha_venc] [datetime],
	[fact_cliente] [numeric](18, 0),
	[fact_empresa] [numeric](18, 0),
	[fact_cobrada] [bit] NOT NULL DEFAULT 0,
	[fact_rendicion] [numeric](18, 0) DEFAULT NULL,
	PRIMARY KEY (fact_id),
	--FOREIGN KEY (fact_rendicion) REFERENCES AMBDA.Rendicion (rend_nro), --lo agrega desp en la migracion
	FOREIGN KEY (fact_cliente) REFERENCES AMBDA.Cliente (clie_id),
	FOREIGN KEY (fact_empresa) REFERENCES AMBDA.Empresa (empr_id)
 )

CREATE TABLE [AMBDA].[Devolucion](
	[devo_id] [numeric](18, 0) IDENTITY(1,1),
	[devo_motivo] [nvarchar](255),
	[devo_fecha] [datetime],
	[devo_factura] [numeric](18, 0),
	PRIMARY KEY (devo_id),
	FOREIGN KEY (devo_factura) REFERENCES AMBDA.Factura (fact_id)
 )

 CREATE TABLE [AMBDA].[Renglon](
	[reng_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[reng_monto] [numeric](18, 2),
	[reng_cantidad] [numeric](18, 0),
	[reng_factura] [numeric](18, 0),
	PRIMARY KEY (reng_id),
	FOREIGN KEY (reng_factura) REFERENCES AMBDA.Factura (fact_id)
 )

 CREATE TABLE [AMBDA].[MedioDePago](
	[medi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[medi_descripcion] [nvarchar](255),
 PRIMARY KEY (medi_id)
)

CREATE TABLE [AMBDA].[Sucursal](
	[sucu_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[sucu_nombre] [nvarchar](255),
	[sucu_direc_id] [numeric](18, 0),
	[sucu_habilitada] [bit] NOT NULL DEFAULT 1,
 PRIMARY KEY ([sucu_id])
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
	[sucu_id] [numeric](18, 0),
	PRIMARY KEY (usua_id, sucu_id),
	FOREIGN KEY (usua_id) REFERENCES AMBDA.Usuario (usua_id),
	FOREIGN KEY (sucu_id) REFERENCES AMBDA.Sucursal (sucu_id)
)

CREATE TABLE [AMBDA].[RegistroPago](
	[regi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[regi_fecha_cobro] [datetime],
	[regi_cliente] [numeric](18, 0),
	[regi_importe] numeric(18, 2),
	[regi_usuario] [numeric](18, 0),
	[regi_sucursal] [numeric](18, 0),
	[regi_medio_pago] [numeric](18, 0),
	[regi_devuelto] bit DEFAULT 0
	PRIMARY KEY (regi_id),
	FOREIGN KEY (regi_cliente) REFERENCES AMBDA.Cliente (clie_id),
	FOREIGN KEY (regi_usuario) REFERENCES AMBDA.Usuario (usua_id),
	FOREIGN KEY (regi_sucursal) REFERENCES AMBDA.Sucursal (sucu_id),
	FOREIGN KEY (regi_medio_pago) REFERENCES AMBDA.MedioDePago (medi_id)
)

CREATE TABLE [AMBDA].[FacturaxPago](
	[fact_id] [numeric](18, 0),
	[regi_id] [numeric](18, 0),
	PRIMARY KEY (fact_id, regi_id),
	FOREIGN KEY (fact_id) REFERENCES AMBDA.Factura (fact_id),
	FOREIGN KEY (regi_id) REFERENCES AMBDA.RegistroPago (regi_id)
)

GO

-------Fin creacion de tablas

--------------------------------------
--------------Funciones---------------
--------------------------------------


-------------------------------------
----------Store Procedures-----------
-------------------------------------


CREATE PROCEDURE AMBDA.crear_cliente
	@dni numeric(18,0),
	@mail nvarchar(255),
	@nombre nvarchar(255),
	@apellido nvarchar(255),
	@direccion_id numeric(18,0),
	@fecha_nacimiento datetime,
	@telefono numeric(18,0),
	@habilitado bit,
	@id numeric(18,0) OUTPUT
AS
BEGIN
	INSERT INTO AMBDA.Cliente 
		(clie_dni, clie_mail, clie_nombre, clie_apellido, clie_direc_id, 
		clie_fecha_nacimiento, clie_telefono) 
	VALUES 
		(@dni, @mail, @nombre, @apellido, @direccion_id, @fecha_nacimiento, @telefono);
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE AMBDA.crear_direccion
	@calleNro nvarchar(100),
	@piso numeric(18,0),
	@depto nvarchar(5),
	@cod_postal nvarchar(50),
	@localidad nvarchar(50),
	@id numeric(18,0) OUTPUT
AS
BEGIN
	INSERT INTO AMBDA.Direccion 
		(direc_calleNro, direc_piso, direc_depto, direc_cod_postal, direc_localidad)
	VALUES
		(@calleNro, @piso, @depto, @cod_postal, @localidad);
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE AMBDA.crear_empresa
	@cuit nvarchar(50),
	@nombre nvarchar(255),
	@rubro numeric(18,0),
	@direccion_id numeric(18,0),
	@habilitada bit,
	@id numeric(18,0) OUTPUT
	
AS
BEGIN
	INSERT INTO AMBDA.Empresa 
		(empr_cuit, empr_nombre, empr_rubro, empr_direc_id) 
	VALUES 
		(@cuit, @nombre, @rubro, @direccion_id)
	SET @id = SCOPE_IDENTITY();	
END
GO

CREATE PROCEDURE AMBDA.crear_pago
	@cliente numeric(18,0),
	@fecha_cobro datetime,
	@importe numeric(18,2),
	@usuario numeric(18,0),
	@sucursal numeric(18,0),
	@medio_pago numeric(18,0)
	
AS
BEGIN
	INSERT INTO AMBDA.RegistroPago
		(regi_cliente, regi_fecha_cobro, regi_medio_pago, regi_sucursal, regi_usuario, regi_importe) 
	VALUES 
		(@cliente, @fecha_cobro, @medio_pago, @sucursal, @usuario, @importe)	
END
GO

CREATE PROCEDURE AMBDA.crear_factura
	@nroFactura numeric(18,0),
	@fechaAlta datetime,
	@fechaVencimiento datetime,
	@total numeric(18,2),
	@cliente numeric(18,0),
	@empresa nvarchar(255),
	@id numeric(18,0) OUTPUT
AS
BEGIN
	INSERT INTO AMBDA.Factura
		(fact_nro, fact_fecha, fact_total, fact_fecha_venc, fact_cliente, fact_empresa)
	VALUES
		(@nroFactura, @fechaAlta, @total, @fechaVencimiento, (select clie_id from AMBDA.Cliente where clie_dni = @cliente), (select empr_id from AMBDA.Empresa where empr_nombre = @empresa))
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE AMBDA.crear_item
	@monto numeric(18,2),
	@cantidad numeric(18,0),
	@id_factura numeric(18,0),
	@id numeric(18,0) OUTPUT
AS
BEGIN
	INSERT INTO AMBDA.Renglon
		(reng_monto, reng_cantidad, reng_factura)
	VALUES
		(@monto, @cantidad, @id_factura)
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE AMBDA.crear_devolucion
	@motivo nvarchar(255),
	@fecha_devo datetime,
	@factura numeric(18,0),
	@id numeric(18,0) OUTPUT
AS
BEGIN
	INSERT INTO AMBDA.Devolucion
		(devo_motivo, devo_fecha, devo_factura)
	VALUES
		(@motivo, @fecha_devo, @factura)
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE AMBDA.login
(@usuario nvarchar(255), @password_ingresada nvarchar(255))
AS
BEGIN
	DECLARE @password nvarchar(255),
			@password_hasheada nvarchar(255),
			@intentos tinyint,
			@existe_usuario int,
			@usuario_habilitado bit

	SELECT @existe_usuario = COUNT(*)
	FROM AMBDA.USUARIO
	WHERE USUA_USERNAME = @usuario


	IF @existe_usuario = 0
		BEGIN
			RAISERROR('El usuario no existe o los datos ingresados son incorrectos.', 16, 1)
			RETURN
		END


	SELECT @usuario_habilitado = USUA_HABILITADO
	FROM AMBDA.USUARIO
	WHERE USUA_USERNAME = @usuario

	IF @usuario_habilitado = 0
		BEGIN
			RAISERROR('El usuario ha sido inhabilitado. Por favor, contáctese con un administrador', 16, 1)
			RETURN
		END


	SELECT @password = USUA_PASSWORD
	FROM AMBDA.USUARIO
	WHERE USUA_USERNAME = @usuario

	SELECT @password_hasheada = HASHBYTES('SHA2_256',@password_ingresada)

	IF @password <> @password_hasheada
		BEGIN
			RAISERROR('Contraseña incorrecta.', 16, 1)

			UPDATE AMBDA.USUARIO
			SET USUA_INTENTOS_FALLIDOS = USUA_INTENTOS_FALLIDOS + 1
			WHERE USUA_USERNAME =  @usuario

			SELECT @intentos = USUA_INTENTOS_FALLIDOS
			FROM AMBDA.USUARIO
			WHERE USUA_USERNAME = @usuario

			IF @intentos >= 3
			BEGIN
				RAISERROR('Ha ingresado la contraseña 3 veces de forma incorrecta. El usuario ha sido inhabilitado', 16, 1)

				UPDATE AMBDA.USUARIO
				SET USUA_HABILITADO = 0
				WHERE USUA_USERNAME = @usuario

				RETURN
			END
		
		END
	ELSE
		BEGIN
			UPDATE AMBDA.USUARIO
			SET USUA_INTENTOS_FALLIDOS = 0
			WHERE USUA_USERNAME = @usuario
			RETURN
		END
END
GO

CREATE PROCEDURE AMBDA.pagar_factura
	@cliente numeric(18,0),
	@fecha datetime,
	@importe numeric(18,2),
	@usuario numeric(18,0),
	@sucursal numeric(18,0),
	@medio numeric(18,0),
	@factura numeric(18,0)

AS
BEGIN
DECLARE @idpago numeric(18,0),
		@idfactura numeric(18,0)

	Select @idpago = regi_id 
	From AMBDA.RegistroPago 
	where regi_fecha_cobro = CONVERT(DateTime, @fecha) AND 
	regi_importe = @importe AND 
	regi_cliente = @cliente AND 
	regi_medio_pago = @medio AND
	 regi_sucursal = @sucursal AND 
	 regi_usuario = @usuario

	Select @idfactura = fact_id 
	From AMBDA.Factura 
	where fact_nro = @factura

	INSERT INTO AMBDA.FacturaxPago(fact_id, regi_id) 
		VALUES (@idfactura, @idpago)

	UPDATE AMBDA.Factura 
	SET fact_cobrada = 1 
	WHERE fact_id = @idfactura

END
GO
/*
CREATE PROCEDURE AMBDA.porcentaje_facturas_empresas_por_mes (@anio int, @nro_trim int)
AS BEGIN
SELECT TOP 5 empr_nombre, empr_rubro, empr_cuit, 
isnull((((select count(*) from AMBDA.Factura where fact_empresa = empr_id 
and fact_pago IS NOT NULL 
and YEAR(fact_fecha) = @anio
and (MONTH(fact_fecha) = (@nro_trim * 3) OR MONTH(fact_fecha) = (@nro_trim * 3) -1 OR MONTH(fact_fecha) = (@nro_trim * 3) -2)) * 100 /
NULLIF((select count(*) from POSTRESQL.Factura where fact_empresa = empr_id 
and YEAR(fact_fecha) = @anio
and (MONTH(fact_fecha) = (@nro_trim * 3) OR MONTH(fact_fecha) = (@nro_trim * 3) -1 OR MONTH(fact_fecha) = (@nro_trim * 3) -2)), 0))),0) as "Porcentaje de facturas cobradas"
FROM AMBDA.Empresa
group by empr_id, empr_nombre, empr_rubro, empr_cuit
ORDER BY 4 DESC;
END
GO

CREATE PROCEDURE AMBDA.empresas_mayor_monto_facturado (@anio int, @nro_trim int)
AS BEGIN
SELECT TOP 5 empr_nombre, empr_rubro, empr_cuit, SUM(rend_total) as "Monto total rendido"
FROM AMBDA.Empresa join AMBDA.Rendicion ON rend_empresa = empr_id
where YEAR(rend_fecha) = @anio
and (MONTH(rend_fecha) = (@nro_trim * 3) OR MONTH(rend_fecha) = (@nro_trim * 3) -1 OR MONTH(rend_fecha) = (@nro_trim * 3) -2)
GROUP BY empr_id, empr_nombre, empr_rubro, empr_cuit
ORDER BY 4 DESC;
END
GO


CREATE PROCEDURE AMBDA.clientes_mas_pagos (@anio int, @nro_trim int)
AS BEGIN
SELECT TOP 5 clie_nombre, clie_apellido, clie_dni, clie_mail, 
(SELECT COUNT(*) FROM AMBDA.Pago WHERE pago_cliente = clie_id and YEAR(pago_fecha) = @anio
and (MONTH(pago_fecha) = (@nro_trim * 3) OR MONTH(pago_fecha) = (@nro_trim * 3) -1 OR MONTH(pago_fecha) = (@nro_trim * 3) -2))
as "Cantidad de Pagos" 
FROM AMBDA.Cliente
GROUP BY clie_nombre, clie_apellido, clie_dni, clie_mail, clie_id
ORDER BY 5 DESC;
END
GO


CREATE PROCEDURE AMBDA.clientes_cumplidores (@anio int, @nro_trim int)
AS BEGIN
SELECT TOP 5 clie_nombre, clie_apellido, clie_dni, clie_mail, 
isnull((((select count(*) from AMBDA.Factura where fact_cliente = clie_id 
and fact_pago IS NOT NULL 
and YEAR(fact_fecha) = @anio
and (MONTH(fact_fecha) = (@nro_trim * 3) OR MONTH(fact_fecha) = (@nro_trim * 3) -1 OR MONTH(fact_fecha) = (@nro_trim * 3) -2)) * 100 /
NULLIF((select count(*) from POSTRESQL.Factura where fact_cliente = clie_id
and YEAR(fact_fecha) = @anio
and (MONTH(fact_fecha) = (@nro_trim * 3) OR MONTH(fact_fecha) = (@nro_trim * 3) -1 OR MONTH(fact_fecha) = (@nro_trim * 3) -2)), 0))),0) as "Porcentaje de facturas pagadas"
FROM AMBDA.Cliente
group by clie_nombre, clie_apellido, clie_dni, clie_mail, clie_id
ORDER BY 5 DESC;
END
GO


CREATE PROCEDURE AMBDA.listados (@anio int, @nro_trim int, @tipoListado int)
AS BEGIN

if @tipoListado = 0
    exec AMBDA.porcentaje_facturas_empresas_por_mes @anio, @nro_trim
if @tipoListado = 1
    exec AMBDA.empresas_mayor_monto_facturado @anio, @nro_trim
if @tipoListado = 2
    exec AMBDA.clientes_mas_pagos @anio, @nro_trim
if @tipoListado = 3
    exec AMBDA.clientes_cumplidores @anio, @nro_trim

END
GO
*/
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
			('Registro de Pago de Facturas'),
			('Devolucion de Pago de Facturas'),
			('Rendición de facturas cobradas'),
			('Listado estadístico')


--Agregando Funcionalidades por cada Rol.
INSERT INTO AMBDA.RolxFunc(
	rol_id, func_id)
SELECT
	rol_id, func_id
	FROM AMBDA.Rol, AMBDA.Funcionalidad
	WHERE (rol_nombre = 'Cobrador' AND
			func_descripcion IN ('Registro de Usuario','Registro de Pago de Facturas', 'Devolucion de Pago de Facturas')) OR
		(rol_nombre = 'Administrador' AND
			func_descripcion LIKE '%' AND
            func_descripcion NOT LIKE 'Devolucion de Pago de Facturas')

--Migrando Direcciones.
INSERT INTO AMBDA.Direccion(
	direc_calleNro, direc_cod_postal)
SELECT DISTINCT
	Cliente_Direccion, Cliente_Codigo_Postal
	FROM gd_esquema.Maestra
	WHERE Cliente_Direccion IS NOT NULL

INSERT INTO AMBDA.Direccion(
	direc_calleNro)
SELECT DISTINCT
	Empresa_Direccion
	FROM gd_esquema.Maestra
	WHERE Empresa_Direccion IS NOT NULL

INSERT INTO AMBDA.Direccion(
	direc_calleNro, direc_cod_postal)
SELECT DISTINCT
	Sucursal_Dirección, Sucursal_Codigo_Postal
	FROM gd_esquema.Maestra
	WHERE Empresa_Direccion IS NOT NULL

--Migrando Sucursales.
INSERT INTO AMBDA.Sucursal(
	sucu_direc_id, sucu_nombre)
SELECT DISTINCT
	(SELECT direc_id FROM AMBDA.Direccion WHERE direc_calleNro = Sucursal_Dirección), Sucursal_Nombre
	FROM gd_esquema.Maestra
	WHERE [Sucursal_Codigo_Postal] IS NOT NULL

--Migrando Clientes.
INSERT INTO AMBDA.Cliente(
	clie_dni, clie_nombre, clie_apellido, clie_mail, clie_fecha_nacimiento, clie_direc_id)
SELECT DISTINCT
	[Cliente-Dni], [Cliente-Nombre], [Cliente-Apellido], Cliente_Mail, [Cliente-Fecha_Nac], 
	(SELECT direc_id FROM AMBDA.Direccion WHERE direc_calleNro = Cliente_Direccion)
	FROM gd_esquema.Maestra
	WHERE [Cliente-Dni] IS NOT NULL


--Migrando Rubros.
SET IDENTITY_INSERT AMBDA.Rubro ON;

INSERT INTO AMBDA.Rubro(
	rubr_id, rubr_descripcion)
SELECT DISTINCT
	Empresa_Rubro, Rubro_Descripcion
	FROM gd_esquema.Maestra
	WHERE Empresa_Rubro IS NOT NULL

SET IDENTITY_INSERT AMBDA.Rubro OFF;

--Migrando Empresas.
INSERT INTO AMBDA.Empresa(
	empr_cuit, empr_nombre, empr_direc_id, empr_rubro)
SELECT DISTINCT
	Empresa_Cuit, Empresa_Nombre, (SELECT direc_id FROM AMBDA.Direccion WHERE direc_calleNro = Empresa_Direccion),
	(SELECT rubr_id FROM AMBDA.Rubro r WHERE Empresa_Rubro = r.rubr_id)
	FROM gd_esquema.Maestra
	WHERE Empresa_Cuit IS NOT NULL

--Migrando Rendiciones.
SET IDENTITY_INSERT AMBDA.Rendicion ON;

INSERT INTO AMBDA.Rendicion(
	rend_nro, rend_fecha, rend_porcentaje, rend_empresa)
SELECT 
	DISTINCT Rendicion_Nro, Rendicion_Fecha,
	(ItemRendicion_Importe * 100) / Total,
	(SELECT empr_id FROM AMBDA.Empresa c WHERE c.empr_cuit = Empresa_Cuit)
	FROM gd_esquema.Maestra
	WHERE Rendicion_Nro IS NOT NULL

SET IDENTITY_INSERT AMBDA.Rendicion OFF;
GO

--Migrando Facturas.
INSERT INTO AMBDA.Factura(fact_nro, fact_fecha, fact_total, fact_fecha_venc, fact_cliente, fact_empresa)
SELECT DISTINCT
	Nro_Factura, Factura_Fecha,
	Factura_Total, Factura_Fecha_Vencimiento, (SELECT clie_id FROM AMBDA.Cliente c WHERE c.clie_dni = [Cliente-Dni]),
	 (SELECT empr_id FROM AMBDA.Empresa c WHERE c.empr_cuit = Empresa_Cuit)
	FROM gd_esquema.Maestra
	WHERE Nro_Factura IS NOT NULL
GO

ALTER TABLE AMBDA.Factura
	ADD CONSTRAINT FK_RENDICION_NRO
	FOREIGN KEY (fact_rendicion)
	REFERENCES AMBDA.Rendicion(rend_nro)

--Setear Facturas ya rendidas.
UPDATE AMBDA.Factura 
SET fact_rendicion = (select distinct Rendicion_Nro 
				FROM gd_esquema.Maestra 
			WHERE Nro_Factura = fact_nro and Rendicion_Nro is not null)

--Setear Importe Total de Rendicion
UPDATE AMBDA.Rendicion
SET rend_importe_total = (SELECT sum(fact_total) 
						FROM AMBDA.Factura 
						WHERE fact_rendicion = rend_nro)

--Setear Cantidad de Facturas en cada Rendicion
UPDATE AMBDA.Rendicion
SET rend_cant_facturas = (SELECT count(fact_nro)
						FROM AMBDA.Factura 
						WHERE fact_rendicion = rend_nro)
GO
--Migrando Renglones.
INSERT INTO AMBDA.Renglon(
	reng_monto, reng_cantidad, reng_factura)
SELECT
	ItemFactura_Monto, ItemFactura_Cantidad, (SELECT fact_id FROM AMBDA.Factura c WHERE Nro_Factura = c.fact_nro)
	FROM gd_esquema.Maestra
	WHERE ItemFactura_Monto IS NOT NULL

--Creacion de medios de pago
INSERT INTO AMBDA.MedioDePago(medi_descripcion) 
	VALUES ('Efectivo'), ('TarjetaCredito'), ('TarjetaDebito')

--Migrando pagos.
--Supongo que el primer usuario es el admin y todos los demás cobradores asi que los pagos los hizo el usuario con id 2
--Todos los pagos migrados se hicieron en efectivo
SET IDENTITY_INSERT AMBDA.RegistroPago ON;

--con el usuario creado iria asi:
--INSERT INTO AMBDA.RegistroPago(
--regi_id, regi_fecha_cobro, regi_empresa, regi_cliente, regi_importe, regi_usuario, regi_sucursal, regi_medio_pago)
--SELECT DISTINCT Pago_nro, Pago_Fecha, Empresa_Cuit, [Cliente-Dni], Total, 2, 
			--(select sucu_cod_postal from AMBDA.SucursalxUsuario where usua_id = 2), 
			--(select medi_id from AMBDA.MedioDePago where medi_descripcion = 'Efectivo')
INSERT INTO AMBDA.RegistroPago(
regi_id, regi_fecha_cobro, regi_cliente, regi_importe, regi_medio_pago, regi_sucursal)
SELECT DISTINCT 
	Pago_nro, Pago_Fecha,
	(SELECT clie_id FROM AMBDA.Cliente c WHERE c.clie_dni = [Cliente-Dni]), 
	Total, 
	(SELECT medi_id FROM AMBDA.MedioDePago WHERE medi_descripcion = 'Efectivo'),
	(SELECT sucu_id FROM AMBDA.Sucursal s WHERE s.sucu_nombre = Sucursal_Nombre)
	FROM gd_esquema.Maestra
	WHERE Pago_nro IS NOT NULL

SET IDENTITY_INSERT AMBDA.RegistroPago OFF;
GO

--Migrando facturas por pago
INSERT INTO AMBDA.FacturaxPago(fact_id, regi_id)
SELECT (select fact_id from AMBDA.Factura where fact_nro = Nro_Factura), Pago_nro
	FROM gd_esquema.Maestra
	WHERE Pago_nro IS NOT NULL
	group by Nro_Factura, Pago_nro

UPDATE AMBDA.Factura
SET fact_cobrada = 1
WHERE fact_id = (select fp.fact_id from AMBDA.FacturaxPago fp where fact_nro = (select f.fact_nro from AMBDA.Factura f where f.fact_id = fp.fact_id))

GO

--Creacion Usuario Administrador Default
--Tabla Usuario y UsuarioxRol
INSERT INTO AMBDA.Usuario(usua_username, usua_password)
VALUES
	('admin', HASHBYTES('SHA2_256', CONVERT(nvarchar(255), 'w23e'))) 

INSERT INTO AMBDA.RolxUsuario(usua_id, rol_id)
VALUES
	((SELECT usua_id FROM AMBDA.Usuario WHERE usua_username = 'admin'), 
	(SELECT rol_id FROM AMBDA.Rol WHERE rol_nombre = 'Administrador')) 


--Creacion Usuario Cobrador
INSERT INTO AMBDA.Usuario(usua_username, usua_password)
VALUES
	('cobrador1', HASHBYTES('SHA2_256', CONVERT(nvarchar(255), 'cobrador1'))) 

INSERT INTO AMBDA.RolxUsuario(usua_id, rol_id)
VALUES
	((SELECT usua_id FROM AMBDA.Usuario WHERE usua_username = 'cobrador1'), 
	(SELECT rol_id FROM AMBDA.Rol WHERE rol_nombre = 'Cobrador')) 

--Creacion Direccion Para Usar
INSERT INTO AMBDA.Direccion(direc_calleNro, direc_cod_postal, direc_localidad)
VALUES
	('Llavallol 3000', '1419', 'CABA')

--Creacion Segunda Sucursal Para Usar
INSERT INTO AMBDA.Sucursal(sucu_direc_id, sucu_nombre)
VALUES
	((SELECT direc_id FROM AMBDA.Direccion WHERE direc_cod_postal = '1419'), 'Sucursal N°2001')

--Usuario Cobrador con mas de una Sucursal
INSERT INTO AMBDA.SucursalxUsuario(usua_id, sucu_id)
VALUES
	((SELECT usua_id FROM AMBDA.Usuario WHERE usua_username = 'cobrador1'), 
	(SELECT sucu_id FROM AMBDA.Sucursal WHERE sucu_nombre = 'Sucursal N°2001'))

INSERT INTO AMBDA.SucursalxUsuario(usua_id,sucu_id)
VALUES
	((SELECT usua_id FROM AMBDA.Usuario WHERE usua_username = 'cobrador1'), 
	(SELECT sucu_id FROM AMBDA.Sucursal WHERE sucu_nombre = 'Sucursal N°2000'))


GO


