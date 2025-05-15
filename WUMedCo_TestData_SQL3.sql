USE WUMedCo;
GO

BEGIN TRY
BEGIN TRANSACTION;

INSERT INTO PolicyType (TypeName, Cost, Copay, CoverageDetails)
VALUES
('Basic Coverage', 100.00, 20.00, 'Routine checkups and basic procedures'),
('Premium Plan', 250.00, 10.00, 'Full coverage including specialists'),
('Family Plan', 400.00, 15.00, 'Family coverage with dental'),
('Senior Care', 150.00, 25.00, 'For patients over 65'),
('Student Health', 75.00, 30.00, 'University student plan');


INSERT INTO Insurance (ProviderName, EffectiveDate, TerminationDate, PolicyTypeID)
VALUES
('HealthPlus', '2020-01-01', NULL, 1),
('CareFirst', '2021-05-15', '2025-05-15', 2),
('Family Wellness', '2019-03-10', NULL, 3),
('Golden Years', '2022-02-20', NULL, 4),
('Campus Care', '2022-08-01', '2026-08-01', 5);

-- 20 addresses: 10 for patients, 10 for buildings
INSERT INTO Address (StreetAddress, City, State, ZipCode) 
VALUES
-- Patient Addresses (1-10)
('123 Maple St', 'Springfield', 'IL', '62704'),
('456 Oak Ave', 'Madison', 'WI', '53558-1234'),
('789 Pine Rd', 'Columbus', 'OH', '43215'),
('321 Elm Ln', 'Austin', 'TX', '73301'),
('654 Birch Ct', 'Denver', 'CO', '80202'),
('987 Cedar Way', 'Phoenix', 'AZ', '85001'),
('135 Spruce Dr', 'Atlanta', 'GA', '30301'),
('246 Willow Pl', 'Raleigh', 'NC', '27601-5678'),
('369 Aspen Cir', 'Boston', 'MA', '02108'),
('579 Redwood Blvd', 'Seattle', 'WA', '98101'),

-- Building Addresses (11-20)
('100 Medical Plaza', 'Springfield', 'IL', '62704'),
('200 Healthcare Way', 'Madison', 'WI', '53558'),
('300 Hospital Circle', 'Columbus', 'OH', '43215'),
('400 Clinic Road', 'Austin', 'TX', '73301'),
('500 Wellness Lane', 'Denver', 'CO', '80202'),
('600 Surgery Center', 'Phoenix', 'AZ', '85001'),
('700 Emergency Way', 'Atlanta', 'GA', '30301'),
('800 Research Blvd', 'Raleigh', 'NC', '27601'),
('900 Innovation Drive', 'Boston', 'MA', '02108'),
('1000 Technology Park', 'Seattle', 'WA', '98101');


INSERT INTO EmergencyContact (FirstName, LastName, PhoneNumber)
VALUES
('Sarah', 'Johnson', '5551234567'),
('Michael', 'Smith', '5552345678'),
('Emily', 'Davis', '5553456789'),
('David', 'Wilson', '5554567890'),
('Jessica', 'Brown', '5555678901'),
('Daniel', 'Miller', '5556789012'),
('Olivia', 'Taylor', '5557890123'),
('James', 'Anderson', '5558901234'),
('Sophia', 'Thomas', '5559012345'),
('Benjamin', 'Jackson', '5550123456');


INSERT INTO Patient (FirstName, LastName, DateOfBirth, Sex, SSN, PhoneNumber, Email, AddressID, EmergencyContactID, InsuranceID)
VALUES
('John', 'Doe', '1985-03-15', 'Male', '123456789', '5551112233', 'john.doe@email.com', 1, 1, 1),
('Jane', 'Smith', '1990-07-22', 'Female', '987654321', '5552223344', 'jane.smith@email.com', 2, 2, 2),
('Robert', 'Johnson', '1978-11-05', 'Male', NULL, '5553334455', 'robertj@email.com', 3, 3, 3),
('Mary', 'Williams', '2000-02-14', 'Female', '456123789', '5554445566', 'mary.w@email.com', 4, 4, 4),
('William', 'Brown', '1995-09-30', 'Male', '789321654', '5555556677', 'william.b@email.com', 5, 5, 5),
('Linda', 'Davis', '1982-04-18', 'Female', NULL, '5556667788', 'linda.d@email.com', 6, 6, NULL),
('Richard', 'Miller', '1970-12-25', 'Male', '321654987', '5557778899', 'richardm@email.com', 7, 7, NULL),
('Patricia', 'Wilson', '1998-06-09', 'Female', NULL, '5558889900', 'patriciaw@email.com', 8, 8, NULL),
('Charles', 'Moore', '1989-08-12', 'Male', '654987321', '5559990011', 'charlesm@email.com', 9, 9, NULL),
('Karen', 'Taylor', '1975-01-07', 'Female', NULL, '5550001122', 'karent@email.com', 10, 10, NULL);


INSERT INTO Department (DepartmentName)
VALUES
('Cardiology'),
('Oncology'),
('Pediatrics'),
('Neurology'),
('Orthopedics'),
('Emergency Medicine'),
('Radiology'),
('General Surgery'),
('Internal Medicine'),
('Physical Therapy');


INSERT INTO Building (Name, DateOpened, AssignedFunction, AddressID)
VALUES
('Main Hospital', '1990-01-01', 'General Medical Care', 11),
('Heart Center', '2005-05-15', 'Cardiology Services', 12),
('Children''s Pavilion', '2010-03-10', 'Pediatric Care', 13),
('Neuro Science Wing', '2015-02-20', 'Neurological Services', 14),
('Ortho Center', '2018-08-01', 'Orthopedic Surgery', 15),
('Emergency Trauma', '2000-07-04', 'Emergency Services', 16),
('Imaging Center', '2012-09-15', 'Radiology Department', 17),
('Surgical Tower', '2020-04-01', 'Surgical Operations', 18),
('Research Facility', '2019-11-01', 'Medical Research', 19),
('Rehabilitation Center', '2017-06-01', 'Physical Therapy', 20);



-- Insert 30 Employee Addresses (AddressID 21-50)
INSERT INTO Address (StreetAddress, City, State, ZipCode)
VALUES
('789 Oak St', 'Springfield', 'IL', '62704'),
('101 Pine Ave', 'Madison', 'WI', '53558'),
('234 Maple Dr', 'Columbus', 'OH', '43215'),
('567 Cedar Ln', 'Austin', 'TX', '73301'),
('890 Birch Rd', 'Denver', 'CO', '80202'),
('123 Spruce Way', 'Phoenix', 'AZ', '85001'),
('456 Elm Cir', 'Atlanta', 'GA', '30301'),
('789 Willow Ct', 'Raleigh', 'NC', '27601'),
('012 Aspen Blvd', 'Boston', 'MA', '02108'),
('345 Redwood Pl', 'Seattle', 'WA', '98101'),
('111 Magnolia Ln', 'Springfield', 'IL', '62704'),
('222 Sycamore Rd', 'Madison', 'WI', '53558'),
('333 Dogwood Dr', 'Columbus', 'OH', '43215'),
('444 Redbud Cir', 'Austin', 'TX', '73301'),
('555 Juniper Way', 'Denver', 'CO', '80202'),
('666 Hickory St', 'Phoenix', 'AZ', '85001'),
('777 Poplar Ave', 'Atlanta', 'GA', '30301'),
('888 Sequoia Ct', 'Raleigh', 'NC', '27601'),
('999 Cypress Blvd', 'Boston', 'MA', '02108'),
('1010 Spruce Pl', 'Seattle', 'WA', '98101'),
('1212 Oakwood Dr', 'Chicago', 'IL', '60601'),
('1313 Pinecrest Rd', 'Milwaukee', 'WI', '53202'),
('1414 Maplewood Cir', 'Cleveland', 'OH', '44101'),
('1515 Cedar Heights', 'Houston', 'TX', '77001'),
('1616 Birchwood Way', 'Boulder', 'CO', '80301'),
('1717 Walnut St', 'Tucson', 'AZ', '85701'),
('1818 Chestnut Ave', 'Savannah', 'GA', '31401'),
('1919 Pecan Ct', 'Charlotte', 'NC', '28201'),
('2020 Red Maple Blvd', 'Cambridge', 'MA', '02138'),
('2121 Silver Birch Ln', 'Tacoma', 'WA', '98401');


INSERT INTO Employee (FirstName, LastName, DateOfBirth, SSN, Position, PayRate, 
                      StartDate, EndDate, OfficeNumber, Extension, 
                      AddressID, DepartmentID, BuildingID)
VALUES
('Emily', 'Johnson', '1980-05-15', '111223333', 'Cardiologist', 150.00, 
 '2015-01-01', NULL, 'A101', '1234', 21, 1, 2),

('Michael', 'Chen', '1975-08-20', '222334444', 'Oncologist', 145.00, 
 '2016-03-15', NULL, 'B202', '2345', 22, 2, 1),

('Sarah', 'Wilson', '1988-02-14', '333445555', 'Pediatrician', 130.00, 
 '2018-06-01', NULL, 'C303', '3456', 23, 3, 3),

('David', 'Martinez', '1972-11-30', '444556666', 'Neurologist', 155.00, 
 '2014-09-01', '2023-12-31', 'D404', '4567', 24, 4, 4),

('Olivia', 'Brown', '1990-07-04', '555667777', 'Orthopedic Surgeon', 160.00, 
 '2019-04-01', NULL, 'E505', '5678', 25, 5, 5),

('James', 'Davis', '1985-09-22', '666778888', 'ER Physician', 135.00, 
 '2017-08-15', NULL, 'F606', '6789', 26, 6, 6),

('Sophia', 'Garcia', '1983-04-18', '777889999', 'Radiologist', 140.00, 
 '2016-11-01', NULL, 'G707', '7890', 27, 7, 7),

('Daniel', 'Lee', '1978-12-25', '888990000', 'General Surgeon', 165.00, 
 '2013-05-01', NULL, 'H808', '8901', 28, 8, 8),

('Emma', 'Taylor', '1992-03-08', '999001111', 'Internist', 125.00, 
 '2020-02-01', NULL, 'I909', '9012', 29, 9, 1),

('Liam', 'Anderson', '1986-06-12', '000112222', 'Physical Therapist', 110.00, 
 '2018-07-15', NULL, 'J1010', '0123', 30, 10, 10),
 ('Grace', 'Roberts', '1982-09-14', '112233344', 'Cardiac Nurse', 85.00, 
 '2019-03-01', NULL, 'A102', '1235', 31, 1, 2),

('Ethan', 'Harris', '1978-12-03', '223344455', 'Radiation Oncologist', 160.00, 
 '2015-07-01', NULL, 'B203', '2346', 32, 2, 1),

('Mia', 'Clark', '1991-04-25', '334455566', 'Pediatric Nurse', 80.00, 
 '2020-08-15', NULL, 'C304', '3457', 33, 3, 3),

('Noah', 'Lewis', '1985-06-18', '445566677', 'Neurosurgeon', 185.00, 
 '2017-02-01', NULL, 'D405', '4568', 34, 4, 4),

('Ava', 'Walker', '1988-11-30', '556677788', 'Orthopedic Technician', 75.00, 
 '2021-01-01', NULL, 'E506', '5679', 35, 5, 5),

('Lucas', 'Hall', '1993-02-14', '667788899', 'ER Nurse', 78.00, 
 '2022-05-01', NULL, 'F607', '6780', 36, 6, 6),

('Isabella', 'Young', '1980-07-22', '778899900', 'MRI Technologist', 92.00, 
 '2018-09-15', NULL, 'G708', '7891', 37, 7, 7),

('Mason', 'King', '1975-03-08', '889900011', 'Surgical Nurse', 88.00, 
 '2016-11-01', '2024-01-01', 'H809', '8902', 38, 8, 8),

('Charlotte', 'Green', '1987-08-19', '990011122', 'Physician Assistant', 95.00, 
 '2019-06-01', NULL, 'I910', '9013', 39, 9, 1),

('Alexander', 'Adams', '1994-05-05', '001122233', 'Physical Therapist', 105.00, 
 '2021-07-01', NULL, 'J1011', '0124', 40, 10, 10),

('Amelia', 'Wright', '1983-01-12', '113355779', 'Medical Researcher', 120.00, 
 '2020-04-01', NULL, 'K111', '1357', 41, 9, 9),

('Benjamin', 'Scott', '1979-10-31', '224466880', 'Clinical Director', 150.00, 
 '2018-03-01', NULL, 'L212', '2468', 42, 2, 1),

('Chloe', 'Perez', '1990-07-04', '335577991', 'Laboratory Manager', 110.00, 
 '2019-09-01', NULL, 'M313', '3579', 43, 7, 7),

('Daniel', 'Evans', '1986-12-25', '446688002', 'IT Specialist', 95.00, 
 '2022-02-01', NULL, 'N414', '4680', 44, 8, 8),

('Evelyn', 'Collins', '1995-03-18', '557799113', 'Medical Coder', 65.00, 
 '2023-01-01', NULL, 'O515', '5791', 45, 6, 6),

('Gabriel', 'Stewart', '1981-04-09', '668800224', 'Pharmacy Manager', 130.00, 
 '2017-08-01', NULL, 'P616', '6802', 46, 1, 2),

('Harper', 'Morris', '1989-09-21', '779911335', 'Respiratory Therapist', 100.00, 
 '2020-10-01', NULL, 'Q717', '7913', 47, 5, 5),

('Jackson', 'Nguyen', '1992-06-15', '880022446', 'Pathologist', 170.00, 
 '2019-11-01', NULL, 'R818', '8024', 48, 4, 4),

('Luna', 'Rivera', '1984-08-07', '991133557', 'Dietitian', 85.00, 
 '2018-05-01', NULL, 'S919', '9135', 49, 3, 3),

('Oliver', 'Gomez', '1977-05-29', '002244668', 'Chief Administrator', 200.00, 
 '2015-01-01', NULL, 'T1020', '0246', 50, 10, 10);

 -- Update Department Heads
 UPDATE Department SET HeadOfDepartmentID = 
    CASE DepartmentID
        WHEN 1 THEN 1  
        WHEN 2 THEN 2  
        WHEN 3 THEN 3  
        WHEN 4 THEN 4 
        WHEN 5 THEN 5  
        WHEN 6 THEN 6  
        WHEN 7 THEN 7  
        WHEN 8 THEN 8  
        WHEN 9 THEN 9 
        WHEN 10 THEN 10 
    END;

-- Update Building Directors
UPDATE Building SET DirectorID = 
    CASE BuildingID
        WHEN 1 THEN 22  
        WHEN 2 THEN 1   
        WHEN 3 THEN 19  
        WHEN 4 THEN 24  
        WHEN 5 THEN 17  
        WHEN 6 THEN 6   
        WHEN 7 THEN 7   
        WHEN 8 THEN 28  
        WHEN 9 THEN 11  
        WHEN 10 THEN 10 
    END;

INSERT INTO Room (RoomType, Capacity, BuildingID)
VALUES
('Emergency Operating Room', 1, 1),
('ICU Suite', 2, 1),
('General Ward', 4, 1),
('Consultation Room', 6, 1),
('Isolation Room', 1, 1),
('Cardiac Cath Lab', 1, 2),
('Echo Testing Room', 2, 2),
('Cardiac Recovery', 4, 2),
('Stress Test Lab', 2, 2),
('Pediatric Play Therapy', 8, 3),
('Neonatal ICU', 2, 3),
('Child Exam Room', 1, 3),
('Neurology OR', 1, 4),
('EEG Monitoring', 2, 4),
('Neuro Recovery', 4, 4),
('Orthopedic OR', 1, 5),
('Cast Room', 2, 5),
('Physical Therapy Gym', 10, 5),
('Trauma Bay 1', 1, 6),
('Trauma Bay 2', 1, 6),
('Emergency Triage', 6, 6),
('CT Scan Room', 1, 6),
('MRI Suite', 1, 7),
('X-Ray Room', 1, 7),
('Ultrasound Room', 1, 7),
('Main OR 1', 1, 8),
('Post-Anesthesia Care', 4, 8),
('Biochemistry Lab', 6, 9),
('Imaging Research Lab', 4, 9),
('Aquatic Therapy Pool', 8, 10),
('Oncology Infusion', 4, 2),
('Pediatric ICU', 2, 3),
('Neuro Stepdown Unit', 4, 4),
('Ortho Consult Room', 4, 5),
('Emergency Pediatrics', 2, 6);


INSERT INTO Equipment (Brand, Model, SerialNumber, Type, Cost, AcquisitionDate, Status, LastMaintenanceDate, RoomID)
VALUES
('GE Healthcare', 'Optima MR360', 'GE-MRI-001', 'MRI Machine', 1500000.00, '2020-03-15', 'Operational', '2023-01-20', 25),
('Siemens', 'Multix Fusion', 'SI-XRAY-002', 'X-Ray Machine', 250000.00, '2018-06-01', 'Maintenance', '2022-11-15', 26),
('Philips', 'EPIQ Elite', 'PH-ULTR-003', 'Ultrasound System', 120000.00, '2021-09-10', 'Operational', '2023-03-01', 27),
('Stryker', 'LIFEPAK 20', 'ST-DEFIB-004', 'Defibrillator', 15000.00, '2022-01-15', 'Operational', NULL, 6),
('Hill-Rom', 'Progressa', 'HR-BED-005', 'Patient Bed', 8000.00, '2020-11-30', 'Operational', '2023-02-10', 3),
('Medtronic', 'NIM Eclipse', 'MD-NEURO-006', 'Nerve Monitor', 65000.00, '2019-05-20', 'Operational', '2022-12-05', 13),
('Draeger', 'Apollo Anesthesia', 'DR-ANES-007', 'Anesthesia Machine', 85000.00, '2015-08-12', 'Retired', '2020-06-30', 8),
('Baxter', 'Sigma Spectrum', 'BAX-IV-008', 'Infusion Pump', 12000.00, '2022-05-01', 'Operational', NULL, 2),
('Maquet', 'FLOW-i', 'MAQ-VENT-009', 'Ventilator', 45000.00, '2021-07-15', 'Maintenance', '2023-01-10', 1),
('Olympus', 'EVIS EXERA III', 'OL-ENDO-010', 'Endoscopy System', 95000.00, '2019-02-28', 'Operational', '2023-02-15', 18),
('Beckman Coulter', 'Allegra X-15R', 'BC-CENT-011', 'Centrifuge', 7500.00, '2020-04-10', 'Operational', '2022-10-01', 29),
('Mortara', 'ELI 350', 'MO-ECG-012', 'ECG Machine', 8500.00, '2022-08-20', 'Operational', NULL, 4),
('3M', 'Steri-Vac GS', '3M-STER-013', 'Sterilizer', 22000.00, '2010-12-05', 'Retired', '2018-07-15', 28),
('Karl Storz', 'IMAGE1 S', 'KS-SCOP-014', 'Surgical Camera', 35000.00, '2021-11-01', 'Operational', '2023-03-20', 15),
('Zimmer Biomet', 'CastVac', 'ZB-CAST-015', 'Cast Saw', 9500.00, '2022-02-15', 'Maintenance', '2023-02-28', 18),
('Mindray', 'BeneVision N22', 'MR-MON-016', 'Patient Monitor', 9500.00, '2023-01-10', 'Operational', NULL, 5),
('Fujifilm', 'FDR Cross', 'FJ-DR-017', 'Digital Radiography', 180000.00, '2017-04-01', 'Operational', '2023-01-05', 26),
('Haemonetics', 'Cell Saver 5+', 'HA-CELL-018', 'Blood Recovery', 55000.00, '2016-09-15', 'Retired', '2021-12-01', 8),
('Stryker', 'System 7', 'ST-OR-019', 'Surgical Power Tools', 28000.00, '2022-06-01', 'Operational', '2023-03-15', 15),
('Smiths Medical', 'CADD-Solis', 'SM-PUMP-020', 'Pain Management Pump', 13500.00, '2021-04-01', 'Maintenance', '2023-03-01', 9);


INSERT INTO Appointment (DateTime, Purpose, PatientID, PhysicianID, RoomID)
VALUES
('2026-04-05 09:00:00', 'Cardiac Consultation', 1, 1, 6),
('2026-04-05 10:30:00', 'Oncology Follow-Up', 2, 2, 7),
('2026-04-06 11:15:00', 'Pediatric Checkup', 3, 3, 11),
('2026-04-06 14:00:00', 'Neurological Evaluation', 4, 14, 13),
('2026-04-07 08:45:00', 'Orthopedic Surgery Consult', 5, 5, 15),
('2026-04-07 13:30:00', 'Emergency Follow-Up', 6, 6, 19),
('2026-04-10 10:00:00', 'MRI Scan Review', 7, 7, 25),
('2026-04-10 15:20:00', 'Pre-Surgical Consultation', 8, 8, 28),
('2026-04-11 09:30:00', 'Radiation Therapy Planning', 2, 12, 7),
('2026-04-11 11:00:00', 'Pathology Results Review', 9, 28, 8),
('2026-04-12 08:00:00', 'Post-Op Checkup', 10, 5, 15),
('2026-04-12 14:45:00', 'Chronic Pain Management', 4, 14, 13),
('2026-04-13 10:15:00', 'Vaccination Update', 3, 3, 11),
('2026-04-13 16:00:00', 'Cardiac Stress Test', 1, 1, 8),
('2026-04-14 07:30:00', 'Early Morning Consult', 5, 5, 15),
('2026-04-14 12:00:00', 'Lunchtime Follow-Up', 6, 6, 19),
('2026-04-17 09:45:00', 'Neurology Imaging Review', 7, 14, 25),
('2026-04-17 15:10:00', 'Surgical Pre-Op Clearance', 8, 8, 28),
('2026-04-18 08:30:00', 'Oncology Treatment Plan', 2, 2, 7),
('2026-04-18 13:15:00', 'Physical Therapy Assessment', 10, 5, 17);


INSERT INTO MedicalRecord (Diagnosis, Prescription, MedicalProcedure, Notes, VisitDate, PatientID, PhysicianID)
VALUES
('Essential hypertension', 'Lisinopril 10mg daily', NULL, 'BP 140/90 at visit', '2023-03-01', 1, 1),
(NULL, 'Amiodarone 200mg', 'Cardiac ablation', 'Arrhythmia treatment', '2023-03-15', 1, 1),
('Stage II breast cancer', NULL, 'Chemotherapy session', 'First cycle completed', '2023-02-20', 2, 2),
(NULL, NULL, 'Radiation therapy', '15th session of 25', '2023-03-10', 2, 2),
('Acute otitis media', 'Amoxicillin 500mg TID', NULL, 'Right ear infection', '2023-03-05', 3, 3),
('Migraine with aura', 'Sumatriptan 50mg PRN', NULL, 'Patient reported 6 episodes/month', '2023-02-28', 4, 14),
(NULL, 'Ibuprofen 600mg TID', 'Knee arthroscopy', 'Meniscus repair', '2023-03-12', 5, 5),
('Ankle sprain', NULL, 'X-ray and immobilization', 'No fracture detected', '2023-03-20', 6, 6),
('Pulmonary embolism', NULL, 'CT angiography', 'Confirmed diagnosis', '2023-03-18', 7, 7),
(NULL, 'Cephalexin 500mg QID', 'Appendectomy', 'Post-op checkup', '2023-03-22', 8, 8),
('Type 2 diabetes', 'Metformin 1000mg daily', NULL, 'HbA1c 7.2%', '2023-03-14', 9, 9),
(NULL, NULL, 'Therapeutic exercise program', 'Post-stroke rehab', '2023-03-25', 10, 10),
('GERD', 'Pantoprazole 40mg daily', NULL, 'Heartburn management', '2023-03-17', 4, 14),
(NULL, 'Warfarin 5mg daily', 'INR monitoring', 'Atrial fibrillation', '2023-03-19', 1, 1),
('Contact dermatitis', 'Triamcinolone cream 0.1%', NULL, 'Allergic reaction', '2023-03-21', 3, 3),
(NULL, NULL, 'Colonoscopy', 'Routine screening', '2023-03-23', 5, 5),
('Hyperlipidemia', 'Atorvastatin 20mg nightly', NULL, 'LDL 160 mg/dL', '2023-03-24', 9, 9),
('UTI', 'Ciprofloxacin 500mg BID', NULL, 'Urinalysis positive', '2023-03-26', 6, 6),
(NULL, 'Insulin glargine 20 units', 'Diabetic education', 'New diabetes diagnosis', '2023-03-27', 10, 10),
('Osteoarthritis', 'Meloxicam 15mg daily', 'Cortisone injection', 'Knee joint', '2023-03-28', 5, 5),
('Anxiety disorder', 'Sertraline 50mg daily', NULL, 'GAD-7 score 15', '2023-03-29', 4, 14);


COMMIT TRANSACTION;
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION;
    THROW;
END CATCH