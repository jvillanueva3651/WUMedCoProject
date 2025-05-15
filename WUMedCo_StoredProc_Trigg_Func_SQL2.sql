USE WUMedCo
GO

CREATE FUNCTION dbo.GetAge
(
    @DOB DATE
)
RETURNS INT
AS
BEGIN
    DECLARE @Age INT

    SET @Age = DATEDIFF(YEAR, @DOB, GETDATE())
    IF (MONTH(GETDATE()) < MONTH(@DOB))
        OR (MONTH(GETDATE()) = MONTH(@DOB) AND DAY(GETDATE()) < DAY(@DOB))
    BEGIN
        SET @Age = @Age - 1
    END

    RETURN @Age
END
GO

CREATE OR ALTER PROCEDURE sp_GetPatientLastVisitDate
    @PatientID INT,
    @LastVisitDate DATE OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Find the most recent visit date for the specified patient
    SELECT TOP 1 @LastVisitDate = CAST(VisitDate AS DATE)
    FROM MedicalRecord
    WHERE PatientID = @PatientID
    ORDER BY VisitDate DESC;

    -- If no records found, set to NULL
    IF @LastVisitDate IS NULL
    BEGIN
        SET @LastVisitDate = NULL;
    END
END
GO

-- Example Usage
DECLARE @LastVisitDate DATE;

EXEC sp_GetPatientLastVisitDate @PatientID = 15, @LastVisitDate =  @LastVisitDate OUTPUT;

SELECT @LastVisitDate as LastVisit;
GO

CREATE OR ALTER PROCEDURE sp_PromoteToDirector
    @EmployeeID INT,
    @BuildingID INT
AS
BEGIN
    UPDATE BUILDING
    SET DirectorID = @EmployeeID
    WHERE BuildingID = @BuildingID
END
GO

CREATE OR ALTER FUNCTION fn_GetAppointmentCount (@PatientID INT)
RETURNS INT
AS
BEGIN
    DECLARE @Count INT
    SELECT @Count = COUNT(*) FROM MEDICALRECORD WHERE PatientID = @PatientID
    RETURN @Count
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateEmployeePayRate
    @EmployeeID INT,
    @NewPayRate DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validate employee exists
    IF NOT EXISTS (SELECT 1 FROM EMPLOYEE WHERE EmployeeID = @EmployeeID)
    BEGIN
        RAISERROR('Employee ID %d does not exist.', 16, 1, @EmployeeID);
        RETURN;
    END

    -- Update pay rate
    UPDATE EMPLOYEE
    SET PayRate = @NewPayRate
    WHERE EmployeeID = @EmployeeID;

    PRINT 'Pay rate updated successfully.';
END
GO

CREATE OR ALTER FUNCTION fn_GetEquipmentAge
(
    @AcquisitionDate DATE
)
RETURNS INT
AS
BEGIN
    DECLARE @Age INT

    SET @Age = DATEDIFF(YEAR, @AcquisitionDate, GETDATE())

    -- Adjust if acquisition month/day hasn't occurred yet this year
    IF (MONTH(GETDATE()) < MONTH(@AcquisitionDate)) OR
       (MONTH(GETDATE()) = MONTH(@AcquisitionDate) AND DAY(GETDATE()) < DAY(@AcquisitionDate))
    BEGIN
        SET @Age = @Age - 1
    END

    RETURN @Age
END
GO

-- Procedure to fix the MedicalRecord/Appointment paradox
CREATE OR ALTER PROCEDURE DropCheckConstraintByColumn
    @TableName SYSNAME,
    @ColumnName SYSNAME
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ConstraintName SYSNAME;
    DECLARE @SQL NVARCHAR(MAX);

    -- Find the name of the CHECK constraint that references the given column
    SELECT TOP 1 @ConstraintName = cc.name
    FROM sys.check_constraints cc
    INNER JOIN sys.tables t ON cc.parent_object_id = t.object_id
    INNER JOIN sys.columns col ON col.object_id = t.object_id
    WHERE t.name = @TableName
      AND cc.definition LIKE '%' + @ColumnName + '%';

    IF @ConstraintName IS NOT NULL
    BEGIN
        SET @SQL = 'ALTER TABLE [' + @TableName + '] DROP CONSTRAINT [' + @ConstraintName + '];';
        EXEC sp_executesql @SQL;
        PRINT 'Constraint [' + @ConstraintName + '] dropped from table [' + @TableName + '].';
    END
    ELSE
    BEGIN
        PRINT 'No CHECK constraint found on column [' + @ColumnName + '] in table [' + @TableName + '].';
    END
END;
GO
-- Call the procedure
EXEC DropCheckConstraintByColumn @TableName = 'MedicalRecord', @ColumnName = 'VisitDate';
GO