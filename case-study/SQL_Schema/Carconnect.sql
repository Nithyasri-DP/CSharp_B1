---DATABASE DESIGN
create database CarConnect;

use CarConnect;

---SQL Schema Creation
--1)CUSTOMER TABLE

CREATE TABLE Customer 
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50),
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15) UNIQUE,
    cAddress VARCHAR(255),
    Username VARCHAR(50) UNIQUE NOT NULL,
    cPassword VARCHAR(200) NOT NULL,
    RegistrationDate DATETIME DEFAULT GETDATE()
);

--2)VEHICLE TABLE

CREATE TABLE Vehicle 
(
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    Model VARCHAR(50) NOT NULL,
    Make VARCHAR(50) NOT NULL,
    VehicleYear INT NOT NULL,
    Color VARCHAR(20),
    RegistrationNumber VARCHAR(50) UNIQUE NOT NULL,
    VehicleAvailability BIT DEFAULT 1,
    DailyRate DECIMAL(10,2) CHECK (DailyRate > 0) NOT NULL
);

--3)RESERVATION TABLE

CREATE TABLE Reservation 
(
    ReservationID INT IDENTITY(1,1) PRIMARY KEY,
	CustomerID INT NOT NULL,
	VehicleID INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    TotalCost DECIMAL(10,2) CHECK (TotalCost >= 0),
    rStatus VARCHAR(20) CHECK (rStatus IN ('Pending', 'Confirmed', 'Completed')) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID)
);

--4)ADMIN TABLE

CREATE TABLE AdminTb
(
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50),
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15) UNIQUE,
    Username VARCHAR(50) UNIQUE NOT NULL,
    AdminPassword VARCHAR(200) NOT NULL,
    AdminRole VARCHAR(50) CHECK (AdminRole IN ('Super Admin', 'Fleet Manager')) NOT NULL,
    JoinDate DATETIME DEFAULT GETDATE()
);

