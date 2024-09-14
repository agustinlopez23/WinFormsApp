# WinForms Project

This project is a Windows Forms application for managing employees and departments. The project is under improvement to consolidate concepts.

## Requirements
- Windows
- Visual Studio
- SQL Server Management Studio (SSMS)

## Installation Instructions

### 1. Create the Database

1. Open SQL Server Management Studio (SSMS).
2. Run the script `FORM_PRACTICE_DB_SCHEMA.sql` to create the database and the necessary tables.

### 2. Configure the Connection String

1. Open the `App.config` file in the project.
2. Configure the connection string with your SQL server details.
   
   ```xml
   <configuration>
     <connectionStrings>
       <add name="DefaultConnection" connectionString="Data Source=YOUR_SERVER;Initial Catalog=FORM_PRACTICE_DB;Integrated Security=True" providerName="System.Data.SqlClient" />
     </connectionStrings>
   </configuration>
### 3. Open the Project in Visual Studio

1. Open Visual Studio.
2. Load the WinForms project (`.sln`).
3. Build and run the application.

## Project Status

The project is under improvement to consolidate concepts. Ongoing adjustments and optimizations are being made.

## Contributions

Contributions are welcome. If you have suggestions or improvements, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.






