
-- =============================================
-- Author:		Andrew Jones
-- Create date: 20-08-12
-- Description:	Data_Cleanup
-- =============================================
CREATE PROCEDURE `Data_Cleanup` (IN vCustomerID	CHAR(38))
BEGIN 
			SET foreign_key_checks = 0;
			
			DELETE FROM BookDemoVehicle WHERE AppointmentID IN(SELECT AppointmentID FROM Appointment WHERE CustomerID IN(SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			-- ----PartExchange Section---------------------------
			
			DELETE FROM  DealPartExchange WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));						
			DELETE FROM  PartExchangeOption WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN(SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  PartExchangePhoto WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  PXAdditionalInformation WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  PXVehicleConditionCost WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  PXVehicleCondition WHERE PartExchangeVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  PXPatch WHERE PXVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  PXValuation WHERE PXVehicleID IN(SELECT PartExchangeVehicleID FROM PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  CapCarOptions WHERE CapCarDetailsID IN(SELECT CapCarDetailsID FROM CapCarDetails WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  CapCarDetails WHERE CustomerID  IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  PXVehicleHistory WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			
			-- ----Enquiry Vehicle Section------------------------
				
			DELETE FROM  EnquiryVehicleOption WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  LostSale WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  Note WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  EnquiryVehicleFeature WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  EnquiryHistory WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  BudgetDetail WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  EnquiryOption WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  EnquiryVehicleAdditionalinfo WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
					
			-- ------DealBuilder Section-------------------------------	
				
			DELETE FROM DealEnquiryExtra WHERE DealEnquiryVehicleID IN (SELECT DealEnquiryVehicleID FROM DealEnquiryVehicle WHERE DealBuilderID 
							IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID))));
			DELETE FROM DealEnquiryVehicle WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID)));
			DELETE FROM DealContractHire WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID)));
			DELETE FROM DealDocumentationFee WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID)));
			DELETE FROM DealPCP WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID)));
			DELETE FROM DealMotability WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID)));
			DELETE FROM DealMileageComparisonSheet WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID)));
			DELETE FROM PartExchangeValuation WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID)));
			DELETE FROM DealHirePurchaseDetail WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID)));
			DELETE FROM DealEnquiryVehicle WHERE DealBuilderID IN(SELECT DealBuilderID FROM DealBuilder WHERE EnquiryVehicleID 
							IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID)));
			DELETE FROM  DealBuilder WHERE EnquiryVehicleID IN(SELECT EnquiryVehicleID FROM EnquiryVehicle WHERE CustomerID 
							IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID))	;
							
							
			DELETE FROM  Address WHERE AddressID IN(SELECT AddressID FROM Customer WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  Contact WHERE ContactID IN(SELECT CONTACTID FROM Customer WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			DELETE FROM  CustomerDPA WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  CustomerBankDetails WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  CustomerExtras WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  CustomerEmploymentDetails WHERE CustomerID  IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  AdditionalInfo WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  ReceptionLog WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  PersonalNote WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  DepositDetails WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  EnquiryVehicle WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  PartExchangeVehicle WHERE  CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  Appointment WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  Lead  WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID);
			DELETE FROM  CustomerTransferLog WHERE CustomerID=vCustomerID;
			DELETE FROM  Customer  WHERE CustomerID=vCustomerID;
			
			DELETE FROM  PXServiceHistory WHERE PXServiceHistoryID IN (SELECT PXServiceHistoryID FROM  PartExchangeVehicle WHERE CustomerID IN (SELECT CustomerID FROM Customer  WHERE CustomerID=vCustomerID));
			SET foreign_key_checks = 1;
END




