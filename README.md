# WUMedCoProject

## Project Overview

WUMedCoProject is a comprehensive Windows Forms application built with .NET 8, designed to manage various aspects of a medical administrative environment. The solution covers multiple operational areas such as patient management, appointments, departmental administration, employee management, and building and room facilities.

## Key Components

- **Patient Management**
  - **frmPatient.cs**: Displays and manages patient information.
  - **frmPatientCRUD.cs**: Offers create, read, update, and delete (CRUD) operations for patient records.

- **Appointment Scheduling**
  - **frmAppointment.cs**: Manages appointment scheduling and related details.
  - **frmAppointmentsCRUD.cs**: Offers create, read, update, and delete (CRUD) operations for appointment records

- **Department and Administration**
  - **frmDepartment.cs**: Handles department-related functionalities.
  - **frmDepartmentsCRUD.cs**: Offers create, read, and update (CRUD) operations for department records.
  - **frmAdminHome.cs**: Serves as the main administrative dashboard.
  - **frmAdminLogin.cs**: Manages the administration login process.
  - **frmNewAdmin.cs**: Provides functionality for registering or adding new administrators.

- **Employee Management**
  - **frmEmployee.cs**: Manages employee information and interactions.
  - **frmEmployeeCRUD.cs**: Provides CRUD operations for employee records.

- **Equipment Management**
  - **frmEquipment.cs**: Manages equipment information and status.
  - **frmEquipmentCRUD.cs**: Provides CRUD operations for equipment records.

- **Building and Room Facilities**
  - **frmBuilding.cs**: Displays and manages building information.
  - **frmBuildingsCRUD.cs**: Implements CRUD operations for building-related records.
  - **frmAddRoom.cs**: Handles the addition of room details within buildings.
  - **frmRooms.cs**: Handles viewing and editing rooms from buildings.

- **Medical Records (NOT YET IMPLEMENTED)**
  - **frmMedicalRecordsCRUD.cs**: Manages patient medical records and information (NOT IMPLEMENTED DUE TO TIME). 

## Database Setup

Before configuring your application, you need to set up the database:
 
1. **Execute the SQL Scripts in SQL Server Management Studio (Or compatible DBMS):**
   - The project includes several SQL files to set up the database.
   - Run the SQL scripts in order:
     1. **WUMedCo_DBCreation_SQL1.sql**: This script creates the initial database structure.
     2. **WUMedCo_StoredProc_Trigg_Func_SQL2.sql**: This script adds stored procedures, functions, and triggers.
     3. **WUMedCo_TestData_SQL3,sql**: This script populates the database with test data.
   - **WUMedCo_ExampleQueries_SQL4.sql** is optional, as it only shows data manipulation in SSMS.
   
2. **Using Your SQL Tool:**
   - Open your preferred SQL tool (for example, SQL Server Management Studio).
   - Connect to your SQL Server instance.
   - Open each SQL file (SQL1 to SQL3, optionally SQL4) and execute them in the specified order.


## Configuration Setup

To get the project running locally, you must set up your configuration by doing the following:

1. **Rename Configuration File:**
   - Locate the `App.config.template` file in the project directory.
   - Copy and rename this file to `App.config`.

2. **Update the Connection String:**
   - Open the new `App.config` file.
   - Locate the `<connectionStrings>` section in the file.
   - Replace the file path in the `Data Source` or `AttachDbFilename` property with the correct path where your database file is located on your device. See template file for example.
     
3. **Verify Local Database Path:**
   - Ensure that the specified path points to the actual location of your database file and that you have the necessary permissions to access it.

4. **Rebuild the Project:**
   - Save changes to `App.config`.
   - Rebuild the project to ensure that the configuration settings are applied correctly.

## Initial set up
- **Run the Application:**
  - Open the solution in Visual Studio.
  - Set the startup project to `WUMedCoProject`.
  - Build and run the application.

- **On program start:**
  - The application will prompt for an admin login.
  - Use the credentials of an existing admin user to log in.
  - If you are a new user, you can create a new admin account using the "New Admin?" link. 

- **Navigation:**
  - After logging in, you will be directed to the admin home page.
  - From there, you can navigate to different modules using the menu options.

## Summary

This solution is modular in design, addressing critical operational areas within a medical facility. Using the latest .NET 8 framework, each module is structured for scalability, ease of maintenance, and improved performance. The application ensures that all necessary administrative, clinical, and facility management tasks are supported through dedicated, well-organized forms and modules.
