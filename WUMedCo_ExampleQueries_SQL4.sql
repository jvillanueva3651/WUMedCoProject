USE WUMedCo
GO

SELECT
CONCAT(p.FirstName, ' ', p.LastName) as 'Patient Name',
mr.VisitDate,
DATEDIFF(month, mr.VisitDate, GETDATE()) as 'Time Since Checked'
FROM MedicalRecord mr
LEFT JOIN Patient p on mr.PatientID = p.PatientID
WHERE DATEDIFF(month, mr.VisitDate, GETDATE()) >= 6;
GO
--checks for patients who havnt been seen in over six months

SELECT COUNT(*) FROM Employee
WHERE PayRate >= 50;
SELECT * FROM Employee;
GO
--Sees how many employees are making over $100,000 or $50 per hour

SELECT
CONCAT(p.FirstName, ' ', p.LastName) as Patient,
CONCAT(e.FirstName, ' ', e.LastName) as Physician,
r.RoomID as Room,
a.Purpose as Purpose,
CAST(a.DateTime AS DATE) AS [Date]
FROM Appointment a
LEFT JOIN Patient p ON a.PatientID = p.PatientID
LEFT JOIN Employee e ON a.PhysicianID = e.EmployeeID
LEFT JOIN Room r ON a.RoomID = r.RoomID
WHERE CAST(a.DateTime AS DATE) = CAST(GETDATE() AS DATE);
GO
--sees the list of appointments that day

SELECT
CONCAT(p.FirstName, ' ', p.LastName),
ec.PhoneNumber,
CONCAT(ec.FirstName, ' ', ec.LastName)
FROM Patient p
LEFT JOIN EmergencyContact ec ON p.EmergencyContactID = ec.EmergencyContactID
WHERE p.PatientID in (SELECT PatientID FROM MedicalRecord where Diagnosis = 'Death');
GO
--In case a patient passes away you get there emergency contacts phone number

DROP VIEW IF EXISTS ReceptionistView;
GO

CREATE VIEW ReceptionistView AS
SELECT
    CONCAT(p.FirstName, ' ', p.LastName) AS name,
    p.DateOfBirth AS DOB,
    p.Sex,
    p.PhoneNumber,
    p.Email,
    i.TerminationDate,
    i.ProviderName,
    a.DateTime AS AppointmentTime
FROM Patient p
LEFT JOIN Insurance i ON p.InsuranceID = i.InsuranceID
LEFT JOIN Appointment a ON a.PatientID = p.PatientID;
GO

SELECT * FROM ReceptionistView;
GO

CREATE OR ALTER VIEW vw_StaffDirectory AS
SELECT
  e.EmployeeID,
  e.FirstName + ' ' + e.LastName AS EmployeeName,
  e.Position,
  d.DepartmentName,
  b.Name AS AssignedBuilding,
  ed.FirstName + ' ' + ed.LastName AS BuildingDirector
FROM EMPLOYEE e
INNER JOIN DEPARTMENT d ON e.DepartmentID = d.DepartmentID
INNER JOIN BUILDING b ON e.BuildingID = b.BuildingID
LEFT JOIN EMPLOYEE ed ON b.DirectorID = ed.EmployeeID;
GO
-- Show it
SELECT *
FROM vw_StaffDirectory;
GO

CREATE OR ALTER VIEW vw_OverdueMaintenance AS
SELECT
  e.EquipmentID,
  e.Type,
  e.LastMaintenanceDate,
  r.RoomID,
  b.Name AS BuildingName,
  DATEDIFF(MONTH, e.LastMaintenanceDate, GETDATE()) AS MonthsSinceMaintenance
FROM EQUIPMENT e
INNER JOIN ROOM r ON e.RoomID = r.RoomID
INNER JOIN BUILDING b ON r.BuildingID = b.BuildingID
WHERE e.LastMaintenanceDate < DATEADD(YEAR, -1, GETDATE());
GO
-- Show the results
SELECT *
FROM vw_OverdueMaintenance;
GO

-- List rooms with no equipment assigned
SELECT RoomID, RoomType
FROM ROOM
WHERE RoomID NOT IN (SELECT RoomID FROM EQUIPMENT);
GO

-- Find patients without insurance
SELECT FirstName, LastName
FROM PATIENT
WHERE InsuranceID NOT IN (SELECT InsuranceID FROM INSURANCE);
GO

-- Count patients per department (via appointments)
SELECT d.DepartmentName, COUNT(DISTINCT a.PatientID) AS PatientCount
FROM APPOINTMENT a
INNER JOIN EMPLOYEE e ON a.PhysicianID = e.EmployeeID
INNER JOIN DEPARTMENT d ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentName;
GO

-- Average equipment cost per room type
SELECT r.RoomType, AVG(e.Cost) AS AvgCost
FROM EQUIPMENT e
INNER JOIN ROOM r ON e.RoomID = r.RoomID
GROUP BY r.RoomType;
GO

-- Get all appointments with patient, doctor, and room details
SELECT
  a.DateTime,
  p.FirstName + ' ' + p.LastName AS PatientName,
  e.FirstName + ' ' + e.LastName AS DoctorName,
  r.RoomType AS RoomType
FROM APPOINTMENT a
INNER JOIN PATIENT p ON a.PatientID = p.PatientID
INNER JOIN EMPLOYEE e ON a.PhysicianID = e.EmployeeID
INNER JOIN ROOM r ON a.RoomID = r.RoomID;
GO

-- List equipment in the "West Wing" building
SELECT e.Type, e.Brand, r.RoomID
FROM EQUIPMENT e
INNER JOIN ROOM r ON e.RoomID = r.RoomID
INNER JOIN BUILDING b ON r.BuildingID = b.BuildingID
WHERE b.Name = 'Emergency Center';
GO

-- Show equipment needing maintenance (last maintenance older than 1 year)
SELECT EquipmentID, Type, LastMaintenanceDate
FROM EQUIPMENT
WHERE LastMaintenanceDate < DATEADD(YEAR, -1, GETDATE());
GO

-- Find the directors of each building,
-- As well as that building's function
SELECT
	EmployeeID,
	FirstName,
	LastName,
	AssignedFunction
FROM EMPLOYEE e JOIN BUILDING b
ON e.EmployeeID = b.DirectorID
ORDER BY EmployeeID;
GO

-- Nice and Simple
SELECT
	EmployeeID,
	Position,
	FirstName,
	LastName
FROM EMPLOYEE
ORDER BY Position;
GO