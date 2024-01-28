USE [DBTransacciones]
GO
/****** Object:  Table [dbo].[comercios]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comercios](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[nit] [varchar](20) NULL,
	[direccion] [varchar](250) NULL,
 CONSTRAINT [PK_comercio] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estado]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estado](
	[idEstado] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[idIntegrador] [int] NULL,
 CONSTRAINT [PK_estado] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mediosPago]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mediosPago](
	[idMedio] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[IdIntegrador] [int] NULL,
 CONSTRAINT [PK_mediosPago] PRIMARY KEY CLUSTERED 
(
	[idMedio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[esActivo] [bit] NULL,
	[fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transaciones]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transaciones](
	[codigo] [int] NOT NULL,
	[medio_pago] [int] NULL,
	[estado] [int] NULL,
	[total] [int] NULL,
	[fecha] [varchar](50) NULL,
	[concepto] [varchar](250) NULL,
	[identificacionUsuario] [varchar](20) NULL,
	[codigoComercio] [int] NULL,
 CONSTRAINT [PK_transaciones] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[identificacion] [varchar](20) NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[email] [varchar](200) NOT NULL,
	[idRol] [int] NULL,
	[clave] [varchar](50) NULL,
	[esActivo] [bit] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[estado] ON 
GO
INSERT [dbo].[estado] ([idEstado], [descripcion], [idIntegrador]) VALUES (1, N'Aprobada', 1)
GO
INSERT [dbo].[estado] ([idEstado], [descripcion], [idIntegrador]) VALUES (2, N'Rechazada', 1000)
GO
INSERT [dbo].[estado] ([idEstado], [descripcion], [idIntegrador]) VALUES (3, N'Pendiente', 999)
GO
INSERT [dbo].[estado] ([idEstado], [descripcion], [idIntegrador]) VALUES (4, N'Rechazada SR', 1001)
GO
INSERT [dbo].[estado] ([idEstado], [descripcion], [idIntegrador]) VALUES (5, N'Sin Asignar', 0)
GO
SET IDENTITY_INSERT [dbo].[estado] OFF
GO
SET IDENTITY_INSERT [dbo].[mediosPago] ON 
GO
INSERT [dbo].[mediosPago] ([idMedio], [descripcion], [IdIntegrador]) VALUES (1, N'Tarjeta de Credito', 32)
GO
INSERT [dbo].[mediosPago] ([idMedio], [descripcion], [IdIntegrador]) VALUES (2, N'PSE', 29)
GO
INSERT [dbo].[mediosPago] ([idMedio], [descripcion], [IdIntegrador]) VALUES (3, N'GANA', 41)
GO
INSERT [dbo].[mediosPago] ([idMedio], [descripcion], [IdIntegrador]) VALUES (4, N'Caja', 42)
GO
INSERT [dbo].[mediosPago] ([idMedio], [descripcion], [IdIntegrador]) VALUES (5, N'Sin Asignar', 0)
GO
SET IDENTITY_INSERT [dbo].[mediosPago] OFF
GO
SET IDENTITY_INSERT [dbo].[rol] ON 
GO
INSERT [dbo].[rol] ([idRol], [descripcion], [esActivo], [fechaRegistro]) VALUES (1, N'Administrador', 1, CAST(N'2024-01-25T12:03:53.370' AS DateTime))
GO
INSERT [dbo].[rol] ([idRol], [descripcion], [esActivo], [fechaRegistro]) VALUES (2, N'Comercio', 1, CAST(N'2024-01-25T12:03:53.370' AS DateTime))
GO
INSERT [dbo].[rol] ([idRol], [descripcion], [esActivo], [fechaRegistro]) VALUES (3, N'Pagador', 1, CAST(N'2024-01-25T12:03:53.370' AS DateTime))
GO
INSERT [dbo].[rol] ([idRol], [descripcion], [esActivo], [fechaRegistro]) VALUES (4, N'Sin Asignar', 1, CAST(N'2024-01-25T23:29:36.760' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[rol] OFF
GO
INSERT [dbo].[usuarios] ([identificacion], [nombre], [email], [idRol], [clave], [esActivo]) VALUES (N'1', N'admin', N'admin@example.com', 1, N'12345', 1)
GO
INSERT [dbo].[usuarios] ([identificacion], [nombre], [email], [idRol], [clave], [esActivo]) VALUES (N'2', N'pagador', N'pagador@example.com', 3, N'12345', 1)
GO
INSERT [dbo].[usuarios] ([identificacion], [nombre], [email], [idRol], [clave], [esActivo]) VALUES (N'3', N'comercio', N'comercio@exanmple.com', 2, N'12345', 1)
GO
INSERT [dbo].[usuarios] ([identificacion], [nombre], [email], [idRol], [clave], [esActivo]) VALUES (N'4', N'Sin Asignar', N'True', 4, N'12345', 1)
GO
ALTER TABLE [dbo].[rol] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[transaciones]  WITH NOCHECK ADD  CONSTRAINT [FK_transaciones_comercios] FOREIGN KEY([codigoComercio])
REFERENCES [dbo].[comercios] ([codigo])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[transaciones] NOCHECK CONSTRAINT [FK_transaciones_comercios]
GO
ALTER TABLE [dbo].[transaciones]  WITH CHECK ADD  CONSTRAINT [FK_transaciones_estado] FOREIGN KEY([estado])
REFERENCES [dbo].[estado] ([idEstado])
GO
ALTER TABLE [dbo].[transaciones] CHECK CONSTRAINT [FK_transaciones_estado]
GO
ALTER TABLE [dbo].[transaciones]  WITH NOCHECK ADD  CONSTRAINT [FK_transaciones_mediosPago] FOREIGN KEY([medio_pago])
REFERENCES [dbo].[mediosPago] ([idMedio])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[transaciones] NOCHECK CONSTRAINT [FK_transaciones_mediosPago]
GO
ALTER TABLE [dbo].[transaciones]  WITH CHECK ADD  CONSTRAINT [FK_transaciones_usuarios] FOREIGN KEY([identificacionUsuario])
REFERENCES [dbo].[usuarios] ([identificacion])
GO
ALTER TABLE [dbo].[transaciones] CHECK CONSTRAINT [FK_transaciones_usuarios]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[rol] ([idRol])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_rol]
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarComercios]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarComercios]
AS
BEGIN 
SELECT *
FROM comercios
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarComerciosId]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarComerciosId]
@codigo	int
AS
BEGIN 
SELECT *
FROM comercios
WHERE [codigo] = @codigo
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarTransacciones]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTransacciones]
AS
BEGIN 
SELECT *
FROM transaciones
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CrearComercio]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CrearComercio]
	   @nombre varchar(250),
	   @nit varchar(20),
	   @direccion varchar(250)
AS
BEGIN 
IF (@nombre IS NOT NULL AND @nombre != '')
BEGIN 
INSERT INTO [dbo].[comercios]
           ([nombre]
           ,[nit]
           ,[direccion])
     VALUES
           (@nombre
           ,@nit
           ,@direccion)

		   SELECT SCOPE_IDENTITY()
    END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CrearProducto]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CrearProducto]
	       @codigo int,
           @nombre varchar(100),
           @nit varchar(20),
		   @direccion varchar(100)
AS
BEGIN 
INSERT INTO [dbo].[comercios]
           (codigo
           ,nombre
           ,nit
           ,direccion)
     VALUES
           (@codigo
           ,@nombre
           ,@nit
           ,@direccion)

		   SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CrearTransaccion]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CrearTransaccion]
           @codigo int,
		   @medio_pago int,
		   @estado int,
		   @identificacionUsuario varchar(20),
		   @codigoComercio int,
           @concepto varchar(250),
           @fecha varchar(100),
           @total decimal(10,2)
AS
BEGIN 
   
INSERT INTO [dbo].[transaciones]
           (codigo ,
	   medio_pago ,
	   estado ,
	   total ,
	   fecha ,
	   concepto ,
	   identificacionUsuario,
	   codigoComercio)
     VALUES
           ( @codigo ,
	   @medio_pago ,
	   @estado ,
	   @total ,
	   @fecha ,
	   @concepto ,
	   @identificacionUsuario,
	   @codigoComercio)

		   SELECT SCOPE_IDENTITY()
     END 
GO
/****** Object:  StoredProcedure [dbo].[SP_CrearUsuario]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CrearUsuario]
       @identificacion varchar(20),
	   @nombre varchar(200),
	   @email varchar(200),
	   @IdRol int,
	   @clave varchar(40),
	   @esActivo bit
AS
BEGIN 
IF NOT EXISTS (SELECT * 
                  FROM [dbo].[usuarios]
                  WHERE identificacion = @identificacion) AND @identificacion is not null
   BEGIN
INSERT INTO [dbo].[usuarios]
           ([identificacion]
		   ,[nombre]
           ,[email]
           ,[idRol]
           ,[clave]
           ,[esActivo])
     VALUES
           (@identificacion
		   ,@nombre
           ,@email
           ,@IdRol
           ,@Clave
           ,@esActivo)

		   SELECT SCOPE_IDENTITY()
   END
   IF (@IdRol = 2)
   BEGIN
   INSERT INTO [dbo].[comercios]
           ([nombre]
           ,[nit])
     VALUES
           (@nombre
           ,@identificacion)
   END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EditarComercio]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EditarComercio]
           @codigo int,
           @nombre varchar(100),
           @nit varchar(20),
		   @direccion varchar(100)
AS
BEGIN 
UPDATE [dbo].[comercios]
   SET [nombre] = @Nombre
      ,[nit] = @nit
      ,[direccion] = @direccion
 WHERE [codigo] = @codigo
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EditarUsuario]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EditarUsuario]
	   @identificacion	varchar(20),
	   @nombre varchar(200),
	   @email varchar(200),
	   @IdRol int,
	   @clave varchar(40),
	   @esActivo bit
AS
BEGIN 
UPDATE [dbo].[usuarios]
   SET [nombre] = @nombre
      ,[email] = @email
      ,[idRol] = @IdRol
      ,[clave] = @Clave
      ,[esActivo] = @esActivo
 WHERE identificacion = @identificacion
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarComercio]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarComercio]
	   @codigo	int	 
AS
BEGIN 
DELETE
FROM comercios 
WHERE codigo = @codigo
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarUsuario]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarUsuario]
	   @identificacion	int	 
AS
BEGIN 
IF NOT EXISTS (SELECT * 
                  FROM [dbo].[comercios]
                  WHERE nit = @identificacion)
   BEGIN
   DELETE FROM comercios WHERE nit = @identificacion
   END
 END
DELETE
FROM usuarios 
WHERE [identificacion] = @identificacion


GO
/****** Object:  StoredProcedure [dbo].[SP_ListarMedioPago]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListarMedioPago] 
AS
BEGIN 
SELECT *
FROM [dbo].[mediosPago]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarRol]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListarRol] 
AS
BEGIN 
SELECT *
FROM [dbo].[Rol]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarUsuario]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListarUsuario] 
AS
BEGIN 
SELECT *
FROM usuarios 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerComercioId]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerComercioId]
	   @codigo	varchar(20)	 
AS
BEGIN 
SELECT *
FROM comercios 
WHERE [codigo] = @codigo
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerTransaccionComercioId]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerTransaccionComercioId]
	   @codigoComercio	int 
AS
BEGIN 
SELECT *
FROM transaciones 
WHERE [codigoComercio] = @codigoComercio
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerTransaccionId]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerTransaccionId]
	   @codigo	int 
AS
BEGIN 
SELECT *
FROM transaciones 
WHERE [codigo] = @codigo
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerTransaccionUsuarioId]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerTransaccionUsuarioId]
	   @identificacionUsuario	varchar(20) 
AS
BEGIN 
SELECT *
FROM transaciones 
WHERE [identificacionUsuario] = @identificacionUsuario
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerUsuario]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerUsuario]
	   @email	varchar(100),
	   @clave varchar(100)
	 
AS
BEGIN 
SELECT *
FROM usuarios 
WHERE [email] = @email AND [clave] = @clave
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerUsuarioId]    Script Date: 28/01/2024 1:19:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerUsuarioId]
	   @identificacion	varchar(20)	 
AS
BEGIN 
SELECT *
FROM usuarios 
WHERE [identificacion] = @identificacion
END

GO
