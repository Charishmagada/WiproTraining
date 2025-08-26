-- Create Database
CREATE DATABASE ems;
GO

USE ems;
GO

-- 1) Departments Table
CREATE TABLE Departments (
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName VARCHAR(50) NOT NULL
);
GO

-- 2) Employees Table
CREATE TABLE Employee (
    EmpId INT NOT NULL PRIMARY KEY,
    EmployName VARCHAR(30) NULL,
    DateOfBirth DATETIME NULL,
    Email VARCHAR(50) NULL,
    Mobile VARCHAR(15) NULL,
    DepartmentId INT NULL,
    MgrId INT NULL,
    LeaveAvail INT NULL,
    CONSTRAINT FK_Employee_Department FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId),
    CONSTRAINT FK_Employee_Manager FOREIGN KEY (MgrId) REFERENCES Employee(EmpId)
);


-- 3) Users Table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('HR','Manager','Employee')),
    EmpId INT NULL,
    CONSTRAINT FK_User_Employee FOREIGN KEY (EmpId) REFERENCES Employee(EmpId)
);
GO

-- 4) LeaveHistory Table
CREATE TABLE LeaveHistory (
    LeaveId INT IDENTITY(1,1) PRIMARY KEY,
    EmpId INT NULL,
    LeaveStartDate DATETIME NULL,
    LeaveEndDate DATETIME NULL,
    NoOfDays INT NULL,
    LeaveStatus VARCHAR(30) NOT NULL DEFAULT 'PENDING',
    LeaveReason VARCHAR(100) NULL,
    ManagerComments VARCHAR(100) NULL,
    CONSTRAINT FK_LeaveHistory_Employee FOREIGN KEY (EmpId) REFERENCES Employee(EmpId)
);
GO

-- Insert Departments
INSERT INTO Departments (DepartmentName) VALUES ('HR'), ('IT'), ('Finance');

-- Insert Employees
INSERT INTO Employee (EmpId, EmployName, MgrId, LeaveAvail, DateOfBirth, Email, Mobile, DepartmentId)
VALUES
(1000, 'Tapaswi', NULL, 20, '2002-12-12', 'tapaswi@gmail.com', '992445552', 1),
(2000, 'Arya', 1000, 22, '2002-05-12', 'arya@gmail.com', '99293444', 2),
(3000, 'Aslesha', 1000, 28, '2001-11-11', 'aslesha@gmail.com', '9922445', 2),
(4000, 'Rustyn', 2000, 18, '2002-11-12', 'rustyn@gmail.com', '99234544', 3),
(5000, 'Nakshitra', 2000, 15, '2003-08-22', 'nakshitra@gmail.com', '99335566', 3);

-- Insert Users (PasswordHash here is just text for demo)
INSERT INTO Users (Username, PasswordHash, Role, EmpId)
VALUES
('hruser', 'hashedpwd1', 'HR', 1000),
('manager1', 'hashedpwd2', 'Manager', 2000),
('emp1', 'hashedpwd3', 'Employee', 3000),
('emp2', 'hashedpwd4', 'Employee', 4000),
('emp3', 'hashedpwd5', 'Employee', 5000);

-- Insert Leave Requests
INSERT INTO LeaveHistory (EmpId, LeaveStartDate, LeaveEndDate, NoOfDays, LeaveReason)
VALUES
(2000, '2025-10-10', '2025-10-11', 2, 'Going Home'),
(2000, '2025-11-11', '2025-11-14', 4, 'Marriage'),
(3000, '2025-12-12', '2025-12-14', 3, 'Convocation'),
(4000, '2025-09-15', '2025-09-16', 2, 'Medical Leave'),
(5000, '2025-10-20', '2025-10-21', 2, 'Family Function');

select * from Departments
go

select * from Employee
go

select * from LeaveHistory
go

select * from Users
go

