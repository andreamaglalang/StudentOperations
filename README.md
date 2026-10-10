
# StudentOperations

**ELECT3 – Activity Four: Building a Hangfire Console Application with C#**

## Project Overview

StudentOperations is a C# console application that uses Hangfire, Entity Framework Core, and Microsoft SQL Server to manage student registration and enrollment requests through background job processing.


## Technologies Used

- C# / .NET 9
- Visual Studio 2022
- Microsoft SQL Server
- SQL Server Management Studio (SSMS)
- Entity Framework Core
- Hangfire

## Project Structure

The solution consists of four projects:

- **StudentOperations.Domain** – Contains the domain models.
- **StudentOperations.Application** – Contains application service interfaces.
- **StudentOperations.Infrastructure** – Contains database operations, EF Core migrations, services, and Hangfire jobs.
- **StudentOperations.Console** – Contains the console menu and application configuration.

## Features

1. **Student Registration** – Registers students and stores their information in SQL Server.
2. **Enrollment Requests** – Creates and manages student enrollment requests.
3. **Immediate Jobs** – Processes enrollment requests through Hangfire background jobs.
4. **Delayed Jobs** – Schedules enrollment processing after a one-minute delay.
5. **Recurring Jobs** – Automatically processes pending enrollment requests every minute.
6. **Continuation Jobs** – Executes a confirmation job after successful enrollment processing.
7. **Batch Processing** – Processes multiple pending enrollment requests.
8. **Automatic Retries** – Retries jobs when a temporary processing failure occurs.
9. **Processing History** – Stores and displays enrollment processing records.
10. **Data Persistence** – Preserves database records after restarting the application.

## Installation and Setup

### Requirements

- Visual Studio 2022
- .NET 9 SDK
- Microsoft SQL Server
- SQL Server Management Studio (SSMS)

### Step 1 – Download the Project

1. Download or clone this GitHub repository.
2. Extract the ZIP file if downloaded.
3. Open `StudentOperations.sln` in Visual Studio.

### Step 2 – Configure SQL Server

1. Open SQL Server Management Studio (SSMS).
2. Connect to your SQL Server instance using Windows Authentication.
3. Open `StudentOperations.Console/appsettings.json`.
4. Replace `LAPTOP-MHRETQLO` in both connection strings with your own SQL Server instance name.
5. Save the file.

The application uses two databases:

- `StudentOperationsDb` – Stores student records, enrollment requests, and processing history.
- `StudentOperationsHangfireDb` – Stores Hangfire background job information.

### Step 3 – Set Up the Database

1. In Visual Studio, go to **Tools → NuGet Package Manager → Package Manager Console**.
2. Run the following command:

```powershell
Update-Database -Project StudentOperations.Infrastructure -StartupProject StudentOperations.Console -Context StudentOperationsDbContext
```

3. Wait for the database migration to complete.
4. Ensure `StudentOperationsHangfireDb` exists and the SQL Server account has permission to initialize its Hangfire tables.

### Step 4 – Run the Application

1. Right-click `StudentOperations.Console` in Solution Explorer.
2. Select **Set as Startup Project**.
3. Press `Ctrl + F5` to run the application.
4. Wait for the STUDENT OPERATIONS menu to appear.

If Visual Studio reports missing packages, right-click the solution and select **Restore NuGet Packages**.

## Console Menu

The application provides the following options:

```text
STUDENT OPERATIONS

1. Register student
2. Create enrollment request
3. Immediate job
4. Delayed job
5. Continuation job
6. Batch job
7. Show processing history
0. Exit
```

## Testing the Application

1. Register a student using option `1`.
2. Create an enrollment request using option `2`.
3. Test immediate, delayed, continuation, and batch jobs using options `3` to `6`.
4. Observe automatic recurring enrollment processing.
5. Enable temporary failure simulation when creating an enrollment request to demonstrate automatic retries.
6. Select option `7` to view processing history.
7. Restart the application and verify that existing records remain available.

## Database Verification

Use SQL Server Management Studio to verify the stored records.

### Student Records

```sql
USE StudentOperationsDb;
SELECT * FROM dbo.Students;
```

### Enrollment Requests

```sql
USE StudentOperationsDb;
SELECT * FROM dbo.EnrollmentRequests;
```

### Processing History

```sql
USE StudentOperationsDb;
SELECT * FROM dbo.ProcessingLogs;
```

### Hangfire Job History

```sql
USE StudentOperationsHangfireDb;
SELECT Id, StateName, CreatedAt
FROM HangFire.Job
ORDER BY Id DESC;
```

## Submitted By

**Name:** Andrea P. Maglalang  
**Course/Year/Section:** BSCpE 4-A  
**Subject:** ELECT3  
**Activity:** Activity Four – Building a Hangfire Console Application with C#  
**Date:** October 10, 2026
