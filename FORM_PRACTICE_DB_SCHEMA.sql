CREATE DATABASE [form_practice]
GO
USE [form_practice]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 12/09/2024 19:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[departamento] [nvarchar](250) NULL,
	[id_departamento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadoDepartamento]    Script Date: 12/09/2024 19:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadoDepartamento](
	[idDepartamento] [int] NULL,
	[idEmpleado] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 12/09/2024 19:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [nvarchar](250) NULL,
	[primer_apellido] [nvarchar](250) NULL,
	[segundo_apellido] [nvarchar](250) NULL,
	[correo] [nvarchar](250) NULL,
	[foto] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmpleadoDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDepartamento_Departamentos] FOREIGN KEY([idDepartamento])
REFERENCES [dbo].[Departamentos] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpleadoDepartamento] CHECK CONSTRAINT [FK_EmpleadoDepartamento_Departamentos]
GO
ALTER TABLE [dbo].[EmpleadoDepartamento]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDepartamento_Empleados] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleados] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpleadoDepartamento] CHECK CONSTRAINT [FK_EmpleadoDepartamento_Empleados]
GO
/****** Object:  StoredProcedure [dbo].[InsertarEmpleadoConDepartamento]    Script Date: 12/09/2024 19:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertarEmpleadoConDepartamento]
    @nombres NVARCHAR(250),
    @primer_apellido NVARCHAR(250),
    @segundo_apellido NVARCHAR(250),
    @correo NVARCHAR(250),
    @foto IMAGE,
    @ID_DEPARTAMENTO INT
AS
BEGIN
    -- Iniciar transacci?n
    BEGIN TRY
        BEGIN TRANSACTION

        -- Insertar en la tabla Empleados
        INSERT INTO [dbo].[Empleados] (nombres, primer_apellido, segundo_apellido, correo, foto)
        VALUES (@nombres, @primer_apellido, @segundo_apellido, @correo, @foto)

        -- Obtener el ID generado por la inserci?n
        DECLARE @idEmpleado INT = SCOPE_IDENTITY()

        -- Insertar en la tabla EmpleadoDepartamento con el ID del empleado insertado
		DECLARE @IDDEPARTAMENTO INT=(SELECT ID FROM DEPARTAMENTOS  WHERE id=@ID_DEPARTAMENTO)
        INSERT INTO [dbo].[EmpleadoDepartamento] (idDepartamento, idEmpleado)
        VALUES (@IDDEPARTAMENTO, @idEmpleado)

        -- Confirmar la transacci?n si todo sale bien
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        -- En caso de error, deshacer la transacci?n
        ROLLBACK TRANSACTION
        -- Manejar el error
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE()
        RAISERROR(@ErrorMessage, 16, 1)
    END CATCH
END

GO
