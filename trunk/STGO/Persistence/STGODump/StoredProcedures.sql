
USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_SALA_SAVE_OR_UPDATE]    Script Date: 10/28/2012 15:15:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SALA_SAVE_OR_UPDATE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_SALA_SAVE_OR_UPDATE]
GO

USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_SALA_SAVE_OR_UPDATE]    Script Date: 10/28/2012 15:15:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[SP_SALA_SAVE_OR_UPDATE]
    @id						bigint OUTPUT,
    @frecuencia             int,
    @horaCierre				DateTime,
    @horaInicio				DateTime,
    @nombre					varchar(100),
    @permiteMultiplo		tinyint,
    @empresaId				BIGINT
AS
DECLARE @rows int;
SET @rows = 0;
BEGIN TRANSACTION UPSERTSALA; 
if(@id is not null and @id <> 0) 
begin
	SET @rows = (SELECT COUNT(*) FROM Sala WHERE id = @id);
end
IF (@rows = 0)
BEGIN
	INSERT INTO Sala (nombre, frecuencia, permiteMultiplo, horaInicio, horaFin, empresaId)
	VALUES (@nombre, @frecuencia, @permiteMultiplo, @horaInicio, @horaCierre, @empresaId);
	SET @id = (SELECT MAX(id) FROM Sala); 
end

IF (@rows = 1)
BEGIN
	UPDATE Sala SET nombre = @nombre,
					frecuencia = @frecuencia,
					permiteMultiplo = @permiteMultiplo, 
					horaInicio = @horaInicio,
					horaFin = @horaCierre
			WHERE id = @id;
end
COMMIT TRANSACTION UPSERTSALA; 	

GO


USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[aspnet_Profile_DeleteProfiles]    Script Date: 10/28/2012 15:15:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_SALA_DELETE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_SALA_DELETE]
GO

USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_SALA_DELETE]    Script Date: 10/28/2012 15:15:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[SP_SALA_DELETE]
    @id						bigint    
AS
BEGIN TRANSACTION DELETESALA; 
	UPDATE Sala SET fechaHoraBaja = GETDATE()
			WHERE id = @id;
COMMIT TRANSACTION DELETESALA; 	
GO


USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_EMPRESA_SAVE_OR_UPDATE]    Script Date: 10/28/2012 15:15:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_EMPRESA_SAVE_OR_UPDATE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_EMPRESA_SAVE_OR_UPDATE]
GO

USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_SALA_SAVE_OR_UPDATE]    Script Date: 10/28/2012 15:15:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[SP_EMPRESA_SAVE_OR_UPDATE]
    @id						bigint OUTPUT,
    @razonSocial             varchar(100),
    @cuit				varchar(13),
    @telefono				varchar(20),
    @maximoSalas					smallint,
    @activa		tinyint,
    @userId				uniqueidentifier
AS
DECLARE @rows int;
DECLARE @maximoSalasDefault int;

SET @rows = 0;

BEGIN TRANSACTION UPSERTEMPRESA; 
if(@id is not null and @id <> 0) 
begin
	SET @rows = (SELECT COUNT(*) FROM Sala WHERE id = @id);
end

IF (@rows = 0)
BEGIN
	SET @maximoSalasDefault = (SELECT CAST(valor AS int) FROM Parametro where clave = 'MAX_SALAS_DEFAULT');
	INSERT INTO Empresa(activa, cuit, maximoSalas, razonSocial, telefono, userId)
	VALUES (0, @cuit, @maximoSalasDefault, @razonSocial, @telefono, @userId);
	SET @id = (SELECT MAX(id) FROM Sala); 
end

IF (@rows = 1)
BEGIN
	UPDATE Empresa SET activa = @activa,
					cuit = @cuit,
					maximoSalas = @maximoSalas, 
					razonSocial = @razonSocial,
					telefono = @telefono
			WHERE id = @id;
end

COMMIT TRANSACTION UPSERTEMPRESA; 	
GO

USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_EMPRESA_DELETE]    Script Date: 10/28/2012 15:15:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_EMPRESA_DELETE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_EMPRESA_DELETE]
GO

USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_EMPRESA_DELETE]    Script Date: 10/28/2012 15:15:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[SP_EMPRESA_DELETE]
    @id						bigint    
AS
BEGIN TRANSACTION DELETEEMPRESA; 
	UPDATE Empresa SET fechaHoraBaja = GETDATE()
			WHERE id = @id;
COMMIT TRANSACTION DELETEEMPRESA; 	
GO





/****** Object:  StoredProcedure [dbo].[SP_EMPRESA_SAVE_OR_UPDATE]    Script Date: 10/28/2012 15:15:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_REGISTRACION_CREAR_PENDIENTE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_REGISTRACION_CREAR_PENDIENTE]
GO

USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_REGISTRACION_CREAR_PENDIENTE]    Script Date: 10/28/2012 15:15:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[SP_REGISTRACION_CREAR_PENDIENTE]
    @userId					uniqueidentifier,
    @telefono				varchar(100),
    @cuit					varchar(13),
    @razonSocial			varchar(20)
AS
DECLARE @rows int;
DECLARE @maximoSalasDefault int;
DECLARE @userName varchar(256);
SET @rows = 0;

BEGIN TRANSACTION REGISTRACION_PENDIENTE_CREAR; 


	SET @userName = (SELECT U.UserName FROM aspnet_Users U WHERE U.UserId = @userId);
	
	INSERT INTO Registracion (cuit, email, fechaHoraRegistro, razonSocial, pendiente, telefono, userId)
	VALUES (@cuit, @userName, GETDATE(), @razonSocial, 1, @telefono, @userId);

COMMIT TRANSACTION REGISTRACION_PENDIENTE_CREAR; 	
GO

USE [STGO]
GO



/****** Object:  StoredProcedure [dbo].[SP_ACTIVAR_CUENTA]    Script Date: 10/28/2012 15:15:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ACTIVAR_CUENTA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ACTIVAR_CUENTA]
GO

USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_ACTIVAR_CUENTA]    Script Date: 10/28/2012 15:15:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[SP_ACTIVAR_CUENTA]
    @key					uniqueidentifier
AS

DECLARE @userId uniqueidentifier;
DECLARE @telefono varchar(20);
DECLARE @cuit varchar(13);
DECLARE @razonSocial varchar(100);
DECLARE @mail varchar(256);
DECLARE @maximoSalas smallint;

BEGIN TRANSACTION ACTIVAR_CUENTA; 
	
	SELECT @userId = U.UserId,@cuit = R.cuit, @mail = R.email,@razonSocial = R.razonSocial,@telefono = R.telefono FROM aspnet_Users U INNER JOIN Registracion R ON (R.userId = U.UserId) WHERE R.link = @key;
	UPDATE Registracion SET pendiente = 0 WHERE link = @key;
	SET @maximoSalas = (SELECT CAST(valor AS int) FROM Parametro where clave = 'MAX_SALAS_DEFAULT');
	INSERT INTO Empresa(cuit, activa, razonSocial, telefono, userId, maximoSalas)
	VALUES (@cuit, 1, @razonSocial, @telefono, @userId, @maximoSalas);

COMMIT TRANSACTION ACTIVAR_CUENTA; 	
GO

USE [STGO]
GO

USE [STGO]
GO

/****** Object:  StoredProcedure [dbo].[SP_TURNO_RESERVAR]    Script Date: 11/11/2012 21:03:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[SP_TURNO_RESERVAR]
    @salaId						bigint,
    @nombreReservador             varchar(100),   
    @horaInicio				DateTime,
    @horaFin				DateTime,
    @descripcion					varchar(200)
AS
DECLARE @rows int;
SET @rows = 0;
BEGIN TRANSACTION RESERVA_TURNO; 
if(@salaId is not null and @salaId <> 0) 
begin
	SET @rows = (SELECT COUNT(*) FROM Turno T 
				WHERE T.salaId = @salaId 
				AND @horaInicio BETWEEN T.fechaHoraInicio AND T.fechaHoraFin
				OR @horaFin BETWEEN T.fechaHoraFin AND T.fechaHoraInicio);
end
IF (@rows = 0)
BEGIN
	INSERT INTO TURNO (reservador, fechaHoraInicio, fechaHoraFin, descripcion, salaId)
	VALUES (@nombreReservador, @horaInicio, @horaFin, @descripcion, @salaId);	 
end
COMMIT TRANSACTION RESERVA_TURNO;
IF (@rows = 1)
	RAISERROR("TURNO OCUPADO.",16,1)
 	

GO