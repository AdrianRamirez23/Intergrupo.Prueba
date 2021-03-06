USE [Intergrupo]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 13/03/2021 10:17:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [varchar](50) NOT NULL,
	[ApellidoEmpleado] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[DocIdent] [varchar](13) NOT NULL,
	[Cargo] [varchar](25) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC,
	[Email] ASC,
	[DocIdent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 13/03/2021 10:17:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](100) NOT NULL,
	[Contrasena] [varchar](2000) NOT NULL,
	[TipoUsuario] [varchar](10) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([idEmpleado], [NombreEmpleado], [ApellidoEmpleado], [Email], [DocIdent], [Cargo], [Estado]) VALUES (3, N'Adrian Esteban', N'Ramirez Jimenez', N'adrian.ramirez23@hotmail.com', N'1036598444', N'Desarrollador Software', 1)
INSERT [dbo].[Empleados] ([idEmpleado], [NombreEmpleado], [ApellidoEmpleado], [Email], [DocIdent], [Cargo], [Estado]) VALUES (4, N'Natalia A', N'Higuita Ortega', N'nataliahiguita28@hotmail.com', N'1128433392', N'Contadora UDEA', 1)
INSERT [dbo].[Empleados] ([idEmpleado], [NombreEmpleado], [ApellidoEmpleado], [Email], [DocIdent], [Cargo], [Estado]) VALUES (5, N'Santiago', N'Ramirez Jimenez', N'Usuario@usuario.com', N'112244336655', N'Aux Sistemas', 1)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [usuario], [Contrasena], [TipoUsuario], [Estado]) VALUES (5, N'adrian.ramirez23@hotmail.com', N'TgBpAGMAbwBsAGEAcwAxACoA', N'Admin', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Empleados]    Script Date: 13/03/2021 10:17:20 a. m. ******/
ALTER TABLE [dbo].[Empleados] ADD  CONSTRAINT [IX_Empleados] UNIQUE NONCLUSTERED 
(
	[DocIdent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Empleados_1]    Script Date: 13/03/2021 10:17:20 a. m. ******/
ALTER TABLE [dbo].[Empleados] ADD  CONSTRAINT [IX_Empleados_1] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios]    Script Date: 13/03/2021 10:17:20 a. m. ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [IX_Usuarios] UNIQUE NONCLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios_1]    Script Date: 13/03/2021 10:17:20 a. m. ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [IX_Usuarios_1] UNIQUE NONCLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Empleados] FOREIGN KEY([usuario])
REFERENCES [dbo].[Empleados] ([Email])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Empleados]
GO
/****** Object:  StoredProcedure [dbo].[Empleados_CRUD]    Script Date: 13/03/2021 10:17:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Empleados_CRUD](
	@opc int,
	@idEmpleado int,
	@NombreEmpleado varchar(50),
	@ApellidoEmpleado varchar(50),
	@Email varchar(100),
	@DocIdent varchar(13),
	@Cargo varchar(25),
	@Estado bit	
	)
AS

IF @opc=1 BEGIN

    SELECT * FROM Empleados

END

IF @opc=2 BEGIN

    SELECT * FROM Empleados WHERE DocIdent=@DocIdent

END

IF @opc=3 BEGIN

    UPDATE Empleados
	SET NombreEmpleado=@NombreEmpleado, ApellidoEmpleado=@ApellidoEmpleado, Email=@Email, 
	Cargo=@Cargo, Estado=@Estado
	WHERE DocIdent=@DocIdent

END

IF @opc=4 BEGIN
   
   DELETE  Usuarios where Usuario=(select email from Empleados where DocIdent=@DocIdent)

   DELETE Empleados where DocIdent=@DocIdent



END

IF @opc=5 BEGIN

   INSERT INTO Empleados
   SELECT @NombreEmpleado, @ApellidoEmpleado, @Email, @DocIdent, @Cargo, @Estado

END
GO
/****** Object:  StoredProcedure [dbo].[Usuarios_CRUD]    Script Date: 13/03/2021 10:17:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Usuarios_CRUD](
	@opc int,
	@idUsuario int,
	@Usuario varchar(50),
	@Contraseña varchar(2000),
	@TipoUsuario varchar(100),
	@Estado bit	
	)
AS

IF @opc=1 BEGIN

    SELECT * FROM Usuarios

END

IF @opc=2 BEGIN

    SELECT * FROM Usuarios WHERE usuario=@Usuario

END

IF @opc=3 BEGIN

    UPDATE Usuarios
	SET Contrasena=@Contraseña, TipoUsuario=@TipoUsuario, Estado=@Estado
	WHERE usuario=@Usuario

END

IF @opc=4 BEGIN

   DELETE  Usuarios WHERE usuario=@Usuario

END

IF @opc=5 BEGIN

   INSERT INTO Usuarios
   SELECT @Usuario, @Contraseña, @TipoUsuario, @Estado

END

IF @OPC=6 BEGIN

   SELECT 0, Email, '', '', CONVERT(bit, 0) FROM Empleados where Email=@Usuario

END
GO
