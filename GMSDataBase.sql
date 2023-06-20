CREATE DATABASE GMSDataBase
DROP DATABASE GMSDataBase
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
INSERT INTO GymDetails VALUES('anhtk20013@gmail.com', 'lnxcgprgtpslfqgw', 'GYM APPLICATION')

SELECT * FROM Accounts 
SELECT * FROM EquipmentTable 
SELECT * FROM StaffTable 
SELECT * FROM MemberTable 
SELECT * FROM GymDetails