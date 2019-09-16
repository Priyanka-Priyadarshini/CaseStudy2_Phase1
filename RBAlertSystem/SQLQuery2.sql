USE [HospitalDb]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[AvailableBed]
		@BedNo = NULL

SELECT	@return_value as 'Return Value'

GO
