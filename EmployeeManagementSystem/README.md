# Employee Management System (EMS)

## Project Overview
Employee Management System (EMS) is a full-stack application designed to streamline HR operations. It allows HR teams to manage employees, assign roles, handle leave requests, and generate workforce reports. Managers can view team details and approve or reject leave requests, while employees can manage their profile, apply for leave, and track the status of their requests.

---

## Problem Statement
HR departments often face challenges in efficiently managing employee data, tracking leaves, and generating insightful reports. Manual processes lead to errors, inefficiencies, and delays in decision-making.  

Goal: To build a robust EMS that improves efficiency, reduces errors, and enables quick decision-making.

---

## Key Features
- Role-Based Access Control (RBAC): HR, Manager, Employee  
- JWT Authentication and Authorization  
- RESTful API with ASP.NET Core backend  
- React frontend with role-specific dashboards  
- Employee, Leave, Department, and User management  
- Reporting capabilities for HR  

---

## Tech Stack
- Backend: ASP.NET Core Web API, Entity Framework Core, SQL Server  
- Frontend: React.js, Axios, React Router  
- Database: Microsoft SQL Server  
- Authentication: JWT (JSON Web Tokens)  
- Tools: Swagger for API Testing, Git for Version Control  

---

## Project Structure
- Backend  
  - .NET Core Web API project with Controllers, Models, Services  
- Frontend  
  - React.js app with components for each role and protected routes  

---

## Installation Guide

### Backend Setup
1. Clone the repository  
   ```
   git clone <repository-url>
   cd backend
   ```
2. Update appsettings.json with your SQL Server connection string and JWT settings  
3. Run the database migrations or execute the provided SQL script  
4. Start the backend  
   ```
   dotnet run
   ```

### Frontend Setup
1. Navigate to the frontend folder  
   ```
   cd frontend
   ```
2. Install dependencies  
   ```
   npm install
   ```
3. Start the React development server  
   ```
   npm start
   ```

---

## Role-Based Access
- HR: Manage employees, assign roles, track and approve leave requests, generate reports  
- Manager: Approve or reject leave requests of team members, view department employees  
- Employee: Apply for leave, view leave history, view profile  

---

## Authentication
- POST `/api/Auth/login` - Authenticates user and returns JWT token  

---

## API Endpoints

### Employees
- GET /api/Employees - Get all employees  
- GET /api/Employees/{id} - Get employee by ID  
- POST /api/Employees - Add new employee  
- PUT /api/Employees/{id} - Update employee  
- DELETE /api/Employees/{id} - Delete employee  

Examples:  
https://localhost:7008/api/Employees  
https://localhost:7008/api/Employees/10  

---

### Leave Histories
- GET /api/LeaveHistories - Get all leave records  
- GET /api/LeaveHistories/{id} - Get leave record by Leave ID  
- GET /api/LeaveHistories/employee/{empId} - Get leave history by Employee ID  
- POST /api/LeaveHistories/apply - Apply for leave  
- PUT /api/LeaveHistories/{id} - Update leave status  
- DELETE /api/LeaveHistories/{id} - Delete leave record  

Examples:  
https://localhost:7008/api/LeaveHistories  
https://localhost:7008/api/LeaveHistories/employee/2000  
https://localhost:7008/api/LeaveHistories/1  

---

### Users
- GET /api/Users - Get all users  
- GET /api/Users/{id} - Get user by ID  
- POST /api/Users - Add user  
- PUT /api/Users/{id} - Update user  
- DELETE /api/Users/{id} - Delete user  

Examples:  
https://localhost:7008/api/Users  
https://localhost:7008/api/Users/1  

---

### Departments
- GET /api/Departments - Get all departments  
- GET /api/Departments/{id} - Get department by ID  
- POST /api/Departments - Add department  
- PUT /api/Departments/{id} - Update department  
- DELETE /api/Departments/{id} - Delete department  

Examples:  
https://localhost:7008/api/Departments  
https://localhost:7008/api/Departments/1  

---

## How to Run
- Ensure SQL Server is running and the database is created using provided scripts  
- Start backend API using  
  ```
  dotnet run
  ```
- Start frontend React app using  
  ```
  npm start
  ```

---

## Screenshots
- github link:
https://github.com/Charishmagada/WiproTraining/tree/main/EmployeeManagementSystem/screenshots

## Demo
- Video Demo: https://drive.google.com/file/d/11VUELnaMTjcTrVoLBiscPm0G2jWJ3tnl/view?usp=drive_link

## Project Link
- https://github.com/Charishmagada/WiproTraining/tree/main/EmployeeManagementSystem

---

## License
This project is developed for educational and organizational purposes.  
