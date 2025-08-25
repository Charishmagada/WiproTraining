create database carrental
go

use carrental
go

Create Table Vehicle
(
   vehicleID INT Primary Key IDENTITY(1,1),
   make varchar(30),
   model varchar(30),
   year int, 
   dailyRate numeric(9,2),
   status varchar(30) default 'AVAILABLE',
   passengerCapacity INT,
   engineCapacity varchar(30)
)
Go

insert into Vehicle values('Tata','Zxi',2022,1900,'AVAILABLE',4,'330cc'),
('Hyundai', 'i20', 2023, 2200, 'AVAILABLE', 5, '1200cc'),
('Maruti', 'Swift', 2021, 1800, 'AVAILABLE', 5, '1197cc'),
('Honda', 'City', 2022, 2500, 'AVAILABLE', 5, '1498cc'),
('Mahindra', 'XUV500', 2023, 3500, 'AVAILABLE', 7, '2179cc'),
('Kia', 'Seltos', 2023, 3000, 'AVAILABLE', 5, '1493cc'),
('Toyota', 'Innova', 2021, 4000, 'AVAILABLE', 7, '2393cc'),
('Ford', 'EcoSport', 2020, 2800, 'AVAILABLE', 5, '1497cc');
GO

CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);
go

INSERT INTO Users (Username, Password)
VALUES ('Siri', 'Siri123'),  
('Riya','Riya37');
go