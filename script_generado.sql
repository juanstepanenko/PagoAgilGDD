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

IF OBJECT_ID('[AMBDA].[Empresa]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Empresa]

IF OBJECT_ID('[AMBDA].[Rubro]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Rubro]

IF OBJECT_ID('[AMBDA].[Cliente]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Cliente]

IF OBJECT_ID('[AMBDA].[RegistroPago]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[RegistroPago]

IF OBJECT_ID('[AMBDA].[MedioDePago]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[MedioDePago]

IF OBJECT_ID('[AMBDA].[Rol]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Rol]

IF OBJECT_ID('[AMBDA].[Sucursal]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Sucursal]

IF OBJECT_ID('[AMBDA].[Funcionalidad]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Funcionalidad]

IF OBJECT_ID('[AMBDA].[Usuario]', 'U') IS NOT NULL
DROP TABLE [AMBDA].[Usuario]

-- FIN ELIMINACION DE TABLAS --

-- ELIMINACION DE PROCESOS, FUNCIONES, VISTAS Y TRIGGERS NECESARIOS
-- Si existe, lo elimina

-------------------------------------------
-----Creación de tablas y foreign keys-----
-------------------------------------------

CREATE TABLE [AMBDA].[Cliente](
	[clie_dni] [numeric](18, 0) NOT NULL,
	[clie_mail] [nvarchar](255) NULL,
	[clie_nombre] [nvarchar](255) NULL,
	[clie_apellido] [nvarchar](255) NULL,
	[clie_direccion] [nvarchar](255) NULL,
	[clie_cod_postal] [nvarchar](255) NULL,
	[clie_fecha_nacimiento] [datetime] NULL,
	[clie_telefono] [numeric](18, 0) NULL,
	[clie_habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[clie_dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Devolucion](
	[devo_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[devo_motivo] [nvarchar](255) NULL,
	[devo_fecha] [datetime] NULL,
	[devo_factura] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Devolucion] PRIMARY KEY CLUSTERED 
(
	[devo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Empresa](
	[empr_cuit] [nvarchar](50) NOT NULL,
	[empr_nombre] [nvarchar](255) NULL,
	[empr_direccion] [nvarchar](255) NULL,
	[empr_rubro] [numeric](18, 0) NOT NULL,
	[empr_habilitada] [bit] NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[empr_cuit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Factura](
	[fact_nro] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[fact_fecha] [datetime] NULL,
	[fact_total] [numeric](18, 2) NULL,
	[fact_fecha_venc] [datetime] NULL,
	[fact_cliente] [numeric](18, 0) NOT NULL,
	[fact_empresa] [nvarchar](50) NOT NULL,
	[fact_cobrada] [bit] NULL,
	[fact_rendida] [bit] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[fact_nro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[FacturaxPago](
	[fact_nro] [numeric](18, 0) NOT NULL,
	[regi_id] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_FacturaxPago] PRIMARY KEY CLUSTERED 
(
	[fact_nro] ASC,
	[regi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Funcionalidad](
	[func_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[func_descripcion] [nvarchar](255) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[func_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[MedioDePago](
	[medi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[medi_descripcion] [nvarchar](255) NULL,
 CONSTRAINT [PK_MedioDePago] PRIMARY KEY CLUSTERED 
(
	[medi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[RegistroPago](
	[regi_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[regi_factura] [numeric](18, 0) NOT NULL,
	[regi_fecha_cobro] [datetime] NULL,
	[regi_empresa] [numeric](18, 0) NOT NULL,
	[regi_cliente] [numeric](18, 0) NOT NULL,
	[regi_importe] [numeric](18, 2) NULL,
	[regi_usuario] [numeric](18, 0) NOT NULL,
	[regi_sucursal] [numeric](18, 0) NOT NULL,
	[regi_medio_pago] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_RegistroPago] PRIMARY KEY CLUSTERED 
(
	[regi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Rendicion](
	[rend_nro] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[rend_fecha] [datetime] NULL,
	[rend_cant_facturas] [numeric](18, 0) NULL,
	[rend_factura] [numeric](18, 0) NOT NULL,
	[rend_importe_total] [numeric](18, 2) NULL,
	[rend_porcentaje] [numeric](18, 0) NOT NULL,
	[rend_empresa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[rend_nro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Renglon](
	[reng_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[reng_monto] [numeric](18, 2) NULL,
	[reng_cantidad] [numeric](18, 0) NULL,
	[reng_factura] [numeric](18, 0) NOT NULL,
	[reng_item] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Renglon] PRIMARY KEY CLUSTERED 
(
	[reng_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Rol](
	[rol_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[rol_nombre] [nvarchar](255) NULL,
	[rol_habilitado] [bit] NOT NULL,
	[rol_funcionalidad] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[RolxFunc](
	[func_id] [numeric](18, 0) NOT NULL,
	[rol_id] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_RolxFunc] PRIMARY KEY CLUSTERED 
(
	[func_id] ASC,
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[RolxUsuario](
	[usua_id] [numeric](18, 0) NOT NULL,
	[rol_id] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_RolxUsuario] PRIMARY KEY CLUSTERED 
(
	[usua_id] ASC,
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Rubro](
	[rubr_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[rubr_descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[rubr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Sucursal](
	[sucu_cod_postal] [numeric](18, 0) NOT NULL,
	[sucu_nombre] [nvarchar](255) NULL,
	[sucu_direccion] [nvarchar](255) NULL,
	[sucu_habilitada] [bit] NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[sucu_cod_postal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[SucursalxUsuario](
	[usua_id] [numeric](18, 0) NOT NULL,
	[sucu_cod_postal] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_SucursalxUsuario] PRIMARY KEY CLUSTERED 
(
	[usua_id] ASC,
	[sucu_cod_postal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AMBDA].[Usuario](
	[usua_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[usua_username] [nvarchar](255) NULL,
	[usua_password] [nvarchar](255) NULL,
	[usua_habilitado] [bit] NOT NULL,
	[usua_intentos_fallidos] [int] NOT NULL,
	[usua_rol] [numeric](18, 0) NOT NULL,
	[usua_sucursal] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usua_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [AMBDA].[Cliente] ADD  CONSTRAINT [DF_Cliente_clie_habilitado]  DEFAULT ((1)) FOR [clie_habilitado]
GO
ALTER TABLE [AMBDA].[Empresa] ADD  CONSTRAINT [DF_Empresa_empr_habilitada]  DEFAULT ((1)) FOR [empr_habilitada]
GO
ALTER TABLE [AMBDA].[Factura] ADD  CONSTRAINT [DF_Factura_fact_cobrada]  DEFAULT ((0)) FOR [fact_cobrada]
GO
ALTER TABLE [AMBDA].[Factura] ADD  CONSTRAINT [DF_Factura_fact_rendida]  DEFAULT ((0)) FOR [fact_rendida]
GO
ALTER TABLE [AMBDA].[RegistroPago] ADD  CONSTRAINT [DF_RegistroPago_regi_importe]  DEFAULT ((0)) FOR [regi_importe]
GO
ALTER TABLE [AMBDA].[Rol] ADD  CONSTRAINT [DF_Rol_rol_habilitado]  DEFAULT ((1)) FOR [rol_habilitado]
GO
ALTER TABLE [AMBDA].[Sucursal] ADD  CONSTRAINT [DF_Sucursal_sucu_habilitada]  DEFAULT ((1)) FOR [sucu_habilitada]
GO
ALTER TABLE [AMBDA].[Usuario] ADD  CONSTRAINT [DF_Usuario_usua_habilitado]  DEFAULT ((1)) FOR [usua_habilitado]
GO
ALTER TABLE [AMBDA].[Usuario] ADD  CONSTRAINT [DF_Usuario_usua_intentos_fallidos]  DEFAULT ((0)) FOR [usua_intentos_fallidos]
GO
ALTER TABLE [AMBDA].[Devolucion]  WITH CHECK ADD  CONSTRAINT [FK_Devolucion_Factura] FOREIGN KEY([devo_factura])
REFERENCES [AMBDA].[Factura] ([fact_nro])
GO
ALTER TABLE [AMBDA].[Devolucion] CHECK CONSTRAINT [FK_Devolucion_Factura]
GO
ALTER TABLE [AMBDA].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Rubro] FOREIGN KEY([empr_rubro])
REFERENCES [AMBDA].[Rubro] ([rubr_id])
GO
ALTER TABLE [AMBDA].[Empresa] CHECK CONSTRAINT [FK_Empresa_Rubro]
GO
ALTER TABLE [AMBDA].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([fact_cliente])
REFERENCES [AMBDA].[Cliente] ([clie_dni])
GO
ALTER TABLE [AMBDA].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [AMBDA].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Empresa] FOREIGN KEY([fact_empresa])
REFERENCES [AMBDA].[Empresa] ([empr_cuit])
GO
ALTER TABLE [AMBDA].[Factura] CHECK CONSTRAINT [FK_Factura_Empresa]
GO
ALTER TABLE [AMBDA].[FacturaxPago]  WITH CHECK ADD  CONSTRAINT [FK_FacturaxPago_Factura] FOREIGN KEY([fact_nro])
REFERENCES [AMBDA].[Factura] ([fact_nro])
GO
ALTER TABLE [AMBDA].[FacturaxPago] CHECK CONSTRAINT [FK_FacturaxPago_Factura]
GO
ALTER TABLE [AMBDA].[FacturaxPago]  WITH CHECK ADD  CONSTRAINT [FK_FacturaxPago_RegistroPago] FOREIGN KEY([regi_id])
REFERENCES [AMBDA].[RegistroPago] ([regi_id])
GO
ALTER TABLE [AMBDA].[FacturaxPago] CHECK CONSTRAINT [FK_FacturaxPago_RegistroPago]
GO
ALTER TABLE [AMBDA].[RegistroPago]  WITH CHECK ADD  CONSTRAINT [FK_RegistroPago_MedioDePago] FOREIGN KEY([regi_medio_pago])
REFERENCES [AMBDA].[MedioDePago] ([medi_id])
GO
ALTER TABLE [AMBDA].[RegistroPago] CHECK CONSTRAINT [FK_RegistroPago_MedioDePago]
GO
ALTER TABLE [AMBDA].[RegistroPago]  WITH CHECK ADD  CONSTRAINT [FK_RegistroPago_Sucursal] FOREIGN KEY([regi_sucursal])
REFERENCES [AMBDA].[Sucursal] ([sucu_cod_postal])
GO
ALTER TABLE [AMBDA].[RegistroPago] CHECK CONSTRAINT [FK_RegistroPago_Sucursal]
GO
ALTER TABLE [AMBDA].[RegistroPago]  WITH CHECK ADD  CONSTRAINT [FK_RegistroPago_Usuario] FOREIGN KEY([regi_usuario])
REFERENCES [AMBDA].[Usuario] ([usua_id])
GO
ALTER TABLE [AMBDA].[RegistroPago] CHECK CONSTRAINT [FK_RegistroPago_Usuario]
GO
ALTER TABLE [AMBDA].[Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_Rendicion_Empresa] FOREIGN KEY([rend_empresa])
REFERENCES [AMBDA].[Empresa] ([empr_cuit])
GO
ALTER TABLE [AMBDA].[Rendicion] CHECK CONSTRAINT [FK_Rendicion_Empresa]
GO
ALTER TABLE [AMBDA].[Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_Rendicion_Factura] FOREIGN KEY([rend_factura])
REFERENCES [AMBDA].[Factura] ([fact_nro])
GO
ALTER TABLE [AMBDA].[Rendicion] CHECK CONSTRAINT [FK_Rendicion_Factura]
GO
ALTER TABLE [AMBDA].[Renglon]  WITH CHECK ADD  CONSTRAINT [FK_Renglon_Factura] FOREIGN KEY([reng_factura])
REFERENCES [AMBDA].[Factura] ([fact_nro])
GO
ALTER TABLE [AMBDA].[Renglon] CHECK CONSTRAINT [FK_Renglon_Factura]
GO
ALTER TABLE [AMBDA].[RolxFunc]  WITH CHECK ADD  CONSTRAINT [FK_RolxFunc_Funcionalidad] FOREIGN KEY([func_id])
REFERENCES [AMBDA].[Funcionalidad] ([func_id])
GO
ALTER TABLE [AMBDA].[RolxFunc] CHECK CONSTRAINT [FK_RolxFunc_Funcionalidad]
GO
ALTER TABLE [AMBDA].[RolxFunc]  WITH CHECK ADD  CONSTRAINT [FK_RolxFunc_Rol] FOREIGN KEY([rol_id])
REFERENCES [AMBDA].[Rol] ([rol_id])
GO
ALTER TABLE [AMBDA].[RolxFunc] CHECK CONSTRAINT [FK_RolxFunc_Rol]
GO
ALTER TABLE [AMBDA].[RolxUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolxUsuario_Rol] FOREIGN KEY([rol_id])
REFERENCES [AMBDA].[Rol] ([rol_id])
GO
ALTER TABLE [AMBDA].[RolxUsuario] CHECK CONSTRAINT [FK_RolxUsuario_Rol]
GO
ALTER TABLE [AMBDA].[RolxUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolxUsuario_Usuario] FOREIGN KEY([usua_id])
REFERENCES [AMBDA].[Usuario] ([usua_id])
GO
ALTER TABLE [AMBDA].[RolxUsuario] CHECK CONSTRAINT [FK_RolxUsuario_Usuario]
GO
ALTER TABLE [AMBDA].[SucursalxUsuario]  WITH CHECK ADD  CONSTRAINT [FK_SucursalxUsuario_Sucursal] FOREIGN KEY([sucu_cod_postal])
REFERENCES [AMBDA].[Sucursal] ([sucu_cod_postal])
GO
ALTER TABLE [AMBDA].[SucursalxUsuario] CHECK CONSTRAINT [FK_SucursalxUsuario_Sucursal]
GO
ALTER TABLE [AMBDA].[SucursalxUsuario]  WITH CHECK ADD  CONSTRAINT [FK_SucursalxUsuario_Usuario] FOREIGN KEY([usua_id])
REFERENCES [AMBDA].[Usuario] ([usua_id])
GO
ALTER TABLE [AMBDA].[SucursalxUsuario] CHECK CONSTRAINT [FK_SucursalxUsuario_Usuario]
GO


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
	clie_cod_postal, clie_fecha_nacimiento)
SELECT DISTINCT
	[Cliente-Dni], [Cliente-Nombre], [Cliente-Apellido], Cliente_Direccion, Cliente_Mail,
	Cliente_Codigo_Postal, [Cliente-Fecha_Nac]
FROM gd_esquema.Maestra
WHERE [Cliente-Dni] IS NOT NULL


--Migrando empresas.
INSERT INTO AMBDA.Empresa(
	empr_cuit, empr_nombre, empr_direccion, empr_rubro)
SELECT DISTINCT
	Empresa_Cuit, Empresa_Nombre, Empresa_Direccion, Empresa_Rubro 
	FROM gd_esquema.Maestra
WHERE Empresa_Cuit IS NOT NULL


--Migrando rubros.
INSERT INTO AMBDA.Rubro(
	rubr_id, rubr_descripcion)
SELECT DISTINCT
	Empresa_Rubro, Rubro_Descripcion
FROM gd_esquema.Maestra
WHERE Empresa_Rubro IS NOT NULL

--Migrando facturas.   /*********************Chequear esto*************************** ahre on of ja já/
SET IDENTITY_INSERT AMBDA.Factura ON;

INSERT INTO AMBDA.Factura(
	fact_nro, fact_fecha, fact_total, fact_fecha_venc, fact_cliente, fact_empresa)
SELECT DISTINCT
	Nro_Factura, Factura_Fecha,
	Factura_Total, Factura_Fecha_Vencimiento, [Cliente-Dni], Empresa_Cuit
FROM gd_esquema.Maestra
WHERE Nro_Factura IS NOT NULL

SET IDENTITY_INSERT SALUDOS.FACTURAS OFF;


--Migrando renglones.
INSERT INTO AMBDA.Renglon(
	reng_monto, reng_cantidad, reng_factura)
SELECT
	ItemFactura_Monto, ItemFactura_Cantidad, Nro_Factura
FROM gd_esquema.Maestra
WHERE ItemFactura_Monto IS NOT NULL

-- Faltan ahora los usuarios y los index.
-- Preguntar mañana tema Cliente con guion medio.