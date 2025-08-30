CREATE DATABASE PrepTest;
GO

USE PrepTest;
GO

-- Roles table
CREATE TABLE Roles (
    Id NVARCHAR(50) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Roles PRIMARY KEY (Id)
);
GO

-- Users table
CREATE TABLE Users (
    Id NVARCHAR(50) NOT NULL,
    UserName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(50) NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    CONSTRAINT PK_Users PRIMARY KEY (Id)
);
GO

-- UserRoles mapping table
CREATE TABLE UserRoles (
    UserId NVARCHAR(50) NOT NULL,
    RoleId NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_UserRoles PRIMARY KEY (UserId, RoleId),
    CONSTRAINT FK_UserRoles_Users_UserId FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT FK_UserRoles_Roles_RoleId FOREIGN KEY (RoleId) REFERENCES Roles(Id) ON DELETE CASCADE
);
GO

-- Indexes
CREATE UNIQUE INDEX IX_Roles_Name ON Roles (Name);
CREATE UNIQUE INDEX IX_Users_UserName ON Users (UserName);
GO

-- Insert Roles
INSERT INTO Roles (Id, Name) VALUES
('1', 'Admin'),
('2', 'User');
GO

-- Insert Users (passwords should be hashed in real scenario)

INSERT INTO Users (Id, UserName, Email, PasswordHash) VALUES
('100', 'admin', 'admin@example.com', 'Admin123'),
('101', 'user1', 'user1@example.com', 'User123');
GO

-- Assign Roles to Users
INSERT INTO UserRoles (UserId, RoleId) VALUES
('100', '1'), -- admin 
('101', '2'); -- user1 
GO

Select * from Users
go
