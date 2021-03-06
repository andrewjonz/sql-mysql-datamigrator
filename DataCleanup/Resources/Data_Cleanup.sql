USE [Emax]
GO
/****** Object:  StoredProcedure [dbo].[Data_Cleanup]    Script Date: 12/06/2012 12:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Andrew Jones
-- Create date: 20-08-12
-- Description:	Data_Cleanup
-- =============================================
ALTER PROCEDURE  [dbo].[Data_Cleanup]
		 
		 @CustomerID		AS	UNIQUEIDENTIFIER
AS        
BEGIN 

SET NOCOUNT ON;        
     BEGIN TRY
        BEGIN TRANSACTION;
			IF EXISTS(SELECT CustomerID FROM Customer WHERE CustomerID = @CustomerID)
			DELETE FROM BookDemoVehicle WHERE AppointmentID IN(SELECT AppointmentID FROM Appointment WHERE CustomerID IN(SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			------PartExchange Section---------------------------
			
			DELETE FROM  DealPartExchange WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))						
			DELETE FROM  PartExchangeOption WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN(SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  PartExchangePhoto WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  PXAdditionalInformation WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  PXVehicleConditionCost WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  PXVehicleCondition WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  PXPatch WHERE PXVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  PXValuation WHERE PXVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  CapCarOptions WHERE CapCarDetailsID IN(SELECT CapCarDetailsID FROM CapCarDetails WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  CapCarDetails WHERE CustomerID  IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  PXVehicleHistory WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			
			------Enquiry Vehicle Section------------------------
				
			DELETE FROM  EnquiryVehicleOption WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  LostSale WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))					
			DELETE FROM  Note WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))	
			DELETE FROM  EnquiryVehicleFeature WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))		
			DELETE FROM  EnquiryHistory WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  BudgetDetail WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  EnquiryOption WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  EnquiryVehicleAdditionalinfo WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
					
			--------DealBuilder Section-------------------------------	
				
			DELETE FROM DealEnquiryExtra WHERE DealEnquiryVehicleID IN (SELECT DealEnquiryVehicleID FROM DealEnquiryVehicle WHERE DealBuilderID 
							IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))))
			DELETE FROM DealEnquiryVehicle WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)))					
			DELETE FROM DealContractHire WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)))					
			DELETE FROM DealDocumentationFee WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)))
			DELETE FROM DealPCP WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)))	
			DELETE FROM DealMotability WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)))	
			DELETE FROM DealMileageComparisonSheet WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)))
			DELETE FROM PartExchangeValuation WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)))
			DELETE FROM DealHirePurchaseDetail WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)))
			DELETE FROM DealEnquiryVehicle WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)))
			DELETE FROM  DealBuilder WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID 
							IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))	
							
							
			DELETE FROM  Address WHERE AddressID IN(SELECT AddressID FROM Customer WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))
			DELETE FROM  Contact WHERE ContactID IN(SELECT CONTACTID FROM Customer WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))				
			DELETE FROM  CustomerDPA WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)	
			DELETE FROM  CustomerBankDetails WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  CustomerExtras WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  CustomerEmploymentDetails WHERE CustomerID  IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  AdditionalInfo WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  ReceptionLog WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)				
			DELETE FROM  PersonalNote WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)				
			DELETE FROM  DepositDetails WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  EnquiryVehicle WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  PartExchangeVehicle WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  Appointment WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)				
			DELETE FROM  Lead  WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID)
			DELETE FROM  CustomerTransferLog WHERE CustomerID=@CustomerID	
			DELETE FROM  Customer  WHERE CustomerID=@CustomerID				
			
			DELETE FROM  PXServiceHistory WHERE PXServiceHistoryID IN (SELECT PXServiceHistoryID FROM  PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=@CustomerID))		
		COMMIT TRANSACTION;			
    END TRY
    BEGIN CATCH
		DECLARE @UserComment AS VARCHAR(100)             
		SET @UserComment='An error occured while Updating customer';                            
		PRINT 'Failure in ' + ERROR_PROCEDURE()
		ROLLBACK TRANSACTION;        
	END CATCH              
END

