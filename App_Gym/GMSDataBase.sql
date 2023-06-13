CREATE DATABASE GMSDataBase

USE GMSDataBase
DROP TABLE Accounts
DROP TABLE GymDetails
DROP TABLE MemberTable
DROP TABLE StaffTable
DROP TABLE EquipmentTable

CREATE TABLE Accounts
(
			UserId INT PRIMARY KEY IDENTITY,
			UserType NVARCHAR(50),
			UserName NVARCHAR(50),
			UserEmailID NVARCHAR(50),
			UserPassword NVARCHAR(50)
)

CREATE TABLE GymDetails
(
			GymEmailID NVARCHAR(50) PRIMARY KEY,
			Password NVARCHAR(50),
			GymName NVARCHAR(50)
)

CREATE TABLE MemberTable
(
			memberid INT PRIMARY KEY IDENTITY,
			Membername NVARCHAR(50),
			fathername NVARCHAR(50),
			gender NVARCHAR(10),
			age INT,
			phoneNo NVARCHAR(50),
			Emailid NVARCHAR(50),
			Address NVARCHAR(150),
			joiningDate DATETIME,
			renewaldate DATETIME,
			membershiptype NVARCHAR(50),
			feepaid INT,
			timings NVARCHAR(50),
			photo IMAGE,
)

CREATE TABLE StaffTable
(
			staffid INT PRIMARY KEY IDENTITY,
			staffname NVARCHAR(50),
			fathername NVARCHAR(50),
			gender NVARCHAR(50),
			age INT,
			phoneNo NVARCHAR(50),
			Emailid NVARCHAR(50),
			Address NVARCHAR(150),
			joiningDate DATETIME,
			staffdesignation NVARCHAR(50),
			salary INT,
			shifttime NVARCHAR(50),
			IDtype NVARCHAR(50),
			IDProof NVARCHAR(50),
			photo IMAGE,
)

CREATE TABLE EquipmentTable
(
            EquipmentID INT PRIMARY KEY IDENTITY,
            EquipmentName NVARCHAR(100),
            EquipmentType NVARCHAR(100),
			EquipmentQuantity NVARCHAR(100),
			EquipmentWeight NVARCHAR(100),
			EquipmentCost NVARCHAR(100),
			PurchasedDate DATETIME
)

INSERT INTO Accounts VALUES ('Admin','20520132','20520132@gm.uit.edu.vn','anhtk123')
INSERT INTO Accounts VALUES ('User','maquyronglua','maquyronglua@gm.uit.edu.vn','anhtk123')

INSERT INTO GymDetails VALUES('anhtk20013@gmail.com', 'lnxcgprgtpslfqgw', 'GYM APPLICATION')

INSERT INTO MemberTable 
VALUES('Anh', 'La Trong', 'Male', 25, '0353241205', 
'20520132@gm.uit.edu.vn', '45/27 Nguyen Van Dau', '02/04/2020', 
'02/04/2021', 'Platinum - Yearly', 60000, 'Morning Hours','')

INSERT INTO StaffTable 
VALUES('Tien', 'Luong Ha', 'Female', 27, '0328797406', 
'luonghatien@gmail.com', '76/225 Truong Cong Dinh', '03/23/2021',
'PT', 300000, 'Evening Shift','Driving Licence', '092522029444403','')

INSERT INTO EquipmentTable VALUES ('Treadmill', 'Weights', '30', '60kg', '3000000', '02/07/2023')

SELECT * FROM Accounts 
SELECT * FROM EquipmentTable 
SELECT * FROM StaffTable 
SELECT * FROM MemberTable 
SELECT * FROM GymDetails
