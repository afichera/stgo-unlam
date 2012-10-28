
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
COMMIT TRANSACTION UPSERTSALA; 	
GO