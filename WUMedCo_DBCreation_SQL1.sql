USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'WUMedCo')
BEGIN
	Alter Database WUMedCo SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE WUMedCo;
END
GO

CREATE DATABASE WUMedCo;
GO

USE WUMedCo;
GO

BEGIN TRY

BEGIN TRANSACTION;

CREATE TABLE Address (
	AddressID INT PRIMARY KEY IDENTITY(1,1),
	StreetAddress NVARCHAR(100) NOT NULL,
	ApartmentSuiteNum VARCHAR(25) NULL,
	City NVARCHAR(50) NOT NULL,
	State CHAR(2) NOT NULL CHECK (State LIKE '[A-Z][A-Z]'), -- To enforce state codes
	ZipCode VARCHAR(10) NOT NULL CHECK ( -- I'm doing this to validate both forms of zip codes
		ZipCode LIKE '[0-9][0-9][0-9][0-9][0-9]'
		OR ZipCode LIKE '[0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'
	)
);

CREATE TABLE EmergencyContact (
	EmergencyContactID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(80) NOT NULL,
	LastName NVARCHAR(80) NOT NULL,
	PhoneNumber VARCHAR(10) NOT NULL CHECK (
		PhoneNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
	)
);

CREATE TABLE PolicyType (
	PolicyTypeID INT PRIMARY KEY IDENTITY(1,1),
	TypeName NVARCHAR(80) NOT NULL,
	Cost DECIMAL(8,2) NOT NULL,
	Copay DECIMAL(8,2) NOT NULL,
	CoverageDetails NVARCHAR(250) NULL
);

CREATE TABLE Insurance (
	InsuranceID INT PRIMARY KEY IDENTITY(1,1),
	ProviderName NVARCHAR(80) NOT NULL,
	EffectiveDate DATE NOT NULL,
	TerminationDate DATE NULL, -- Policies could be indefinite or an end date not set
	PolicyTypeID INT NOT NULL,
	CONSTRAINT FK_PolicyType_Insurance FOREIGN KEY (PolicyTypeID) 
		REFERENCES PolicyType(PolicyTypeID)
		ON DELETE NO ACTION -- For now, I don't want data to risk being deleted
		ON UPDATE NO ACTION,
	CONSTRAINT CHK_Insurance_Dates CHECK ( -- Gotta validate that end date is AFTER start date
    		TerminationDate IS NULL 
    		OR TerminationDate > EffectiveDate
	)
);

CREATE TABLE Patient (
	PatientID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(80) NOT NULL,
	LastName NVARCHAR(80) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Sex NVARCHAR(6) NOT NULL CHECK (Sex IN ('Male', 'Female')),
	SSN CHAR(9) NULL CHECK (SSN LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'), -- Null bc patient might not be a citizen or resident
	PhoneNumber VARCHAR(10) NOT NULL CHECK (
		PhoneNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
	),
	Email NVARCHAR(254) NULL CHECK (Email LIKE '%@%'),
	AddressID INT NOT NULL,
	EmergencyContactID INT NOT NULL,
	InsuranceID INT NULL, -- Might not have insurance
	CONSTRAINT FK_Patient_Address FOREIGN KEY (AddressID)
		REFERENCES Address(AddressID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Patient_EmerContact FOREIGN KEY (EmergencyContactID)
		REFERENCES EmergencyContact(EmergencyContactID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Patient_Insurance FOREIGN KEY (InsuranceID)
		REFERENCES Insurance(InsuranceID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	-- CONSTRAINT UQ_Patient_SSN UNIQUE (SSN) This ends up breaking if you put more than one NULL SSN. Leave it commented out
);

CREATE TABLE Department (
	DepartmentID INT PRIMARY KEY IDENTITY(1,1),
	DepartmentName NVARCHAR(100) NOT NULL,
	HeadOfDepartmentID INT NULL
);

CREATE TABLE Building (
	BuildingID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	DateOpened DATE NOT NULL,
	AssignedFunction NVARCHAR(100) NOT NULL,
	AddressID INT NOT NULL,
	DirectorID INT NULL,
	CONSTRAINT FK_Building_Address FOREIGN KEY (AddressID)
		REFERENCES Address(AddressID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);

CREATE TABLE Employee (
	EmployeeID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(80) NOT NULL,
	LastName NVARCHAR(80) NOT NULL,
	DateOfBirth DATE NOT NULL,
	SSN CHAR(9) NOT NULL CHECK (SSN LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	Position VARCHAR(50) NOT NULL,
	PayRate DECIMAL(10,2) NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NULL,
	OfficeNumber VARCHAR(25) NOT NULL,
	Extension VARCHAR(10) NOT NULL,
	AddressID INT NOT NULL,
	DepartmentID INT NOT NULL,
	BuildingID INT NOT NULL,
	CONSTRAINT FK_Employee_Address FOREIGN KEY (AddressID)
		REFERENCES Address(AddressID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Employee_Department FOREIGN KEY (DepartmentID)
        	REFERENCES Department(DepartmentID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Employee_Building FOREIGN KEY (BuildingID)
        	REFERENCES Building(BuildingID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT UQ_Employee_SSN UNIQUE (SSN),
	CONSTRAINT CHK_Employee_EndDate CHECK (EndDate IS NULL OR EndDate > StartDate)
);

ALTER TABLE Department
ADD CONSTRAINT FK_Department_Head FOREIGN KEY (HeadOfDepartmentID)
	REFERENCES Employee(EmployeeID)
	ON DELETE SET NULL;

ALTER TABLE Building
ADD CONSTRAINT FK_Building_Director FOREIGN KEY (DirectorID)
	REFERENCES Employee(EmployeeID)
	ON DELETE SET NULL;

CREATE TABLE Room (
	RoomID INT PRIMARY KEY IDENTITY(1,1),
	RoomType NVARCHAR(100) NOT NULL,
	Capacity INT NOT NULL CHECK (Capacity > 0),
	BuildingID INT NOT NULL,
	CONSTRAINT FK_Room_Building FOREIGN KEY (BuildingID)
		REFERENCES Building(BuildingID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);

CREATE TABLE Equipment (
	EquipmentID INT PRIMARY KEY IDENTITY(1,1),
	Brand NVARCHAR(80) NOT NULL,
	Model NVARCHAR(80) NOT NULL,
	SerialNumber NVARCHAR(80) NOT NULL,
	Type NVARCHAR(80) NOT NULL,
	Cost DECIMAL(10,2) NOT NULL,
	AcquisitionDate DATE NOT NULL,
	Status NVARCHAR(250) NOT NULL,
	LastMaintenanceDate DATE NULL,
	RoomID INT NOT NULL,
	CONSTRAINT FK_Equipment_Room FOREIGN KEY (RoomID)
		REFERENCES Room(RoomID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT UQ_Equipment_SerialNumber UNIQUE (SerialNumber)
);

CREATE TABLE Appointment (
	AppointmentID INT PRIMARY KEY IDENTITY(1,1),
	DateTime DATETIME2(0) NOT NULL CHECK (DateTime >= GETDATE()),
	Purpose NVARCHAR(250) NOT NULL,
	PatientID INT NOT NULL,
	PhysicianID INT NOT NULL,
	-- BuildingID INT NOT NULL, Get rid of this, kinda pointless since Room is already here
	RoomID INT NOT NULL,
	CONSTRAINT FK_Appointment_Patient FOREIGN KEY (PatientID)
		REFERENCES Patient(PatientID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_Appointment_Physician FOREIGN KEY (PhysicianID)
		REFERENCES Employee(EmployeeID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	-- CONSTRAINT FK_Appointment_Building FOREIGN KEY (BuildingID)
		-- REFERENCES Building(BuildingID)
		-- ON DELETE NO ACTION
		-- ON UPDATE NO ACTION,
	CONSTRAINT FK_Appointment_Room FOREIGN KEY (RoomID)
		REFERENCES Room(RoomID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
);

CREATE TABLE MedicalRecord (
	RecordID INT PRIMARY KEY IDENTITY(1,1),
	Diagnosis NVARCHAR(250) NULL,
	Prescription NVARCHAR(250) NULL,
	MedicalProcedure NVARCHAR(250) NULL, -- Procedure is a reserved keyword!!!
	Notes NVARCHAR(MAX) NULL,
	VisitDate DATE NOT NULL CHECK (VisitDate <= GETDATE()),
	PatientID INT NOT NULL,
	PhysicianID INT NOT NULL,
	-- AppointmentID INT NOT NULL, Get rid of this and the matching FK, otherwise MedRec and Appts conflict each other
	CONSTRAINT FK_MedRecord_Patient FOREIGN KEY (PatientID)
		REFERENCES Patient(PatientID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT FK_MedRecord_Physician FOREIGN KEY (PhysicianID)
		REFERENCES Employee(EmployeeID)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	--CONSTRAINT FK_MedicalRecord_Appointment FOREIGN KEY (AppointmentID)
	--	REFERENCES Appointment(AppointmentID),
	CONSTRAINT CHK_Diag_Presc_Proc CHECK (Diagnosis IS NOT NULL OR Prescription IS NOT NULL OR MedicalProcedure IS NOT NULL)
);

-- I need this for the C# application, DO NOT ENTER DATA INTO IT!!
CREATE TABLE AdminLogin (
	AdminID INT PRIMARY KEY IDENTITY(1,1),
	Username NVARCHAR(80) NOT NULL UNIQUE,
	Password NVARCHAR(80) NOT NULL,
	CreatedDate DATETIME2 DEFAULT GETDATE(),
	LastLogin DATETIME2 NULL
);

COMMIT TRANSACTION;

END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
END CATCH