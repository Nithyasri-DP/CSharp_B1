use demo;

--NORMALIZING TO 3NF
--1) Client Table
	CREATE TABLE Client (
    ClientNo VARCHAR(10) PRIMARY KEY,
    cName VARCHAR(50) NOT NULL);

--2) Owner Table
	CREATE TABLE Owners (
    OwnerNo VARCHAR(10) PRIMARY KEY,
    oName VARCHAR(50) NOT NULL);

--3) Property Table
	CREATE TABLE Property (
    PropertyNo VARCHAR(10) PRIMARY KEY,
    pAddress VARCHAR(100) NOT NULL,
    OwnerNo VARCHAR(10) FOREIGN KEY REFERENCES Owners(OwnerNo));

--4) Rental Table
	CREATE TABLE Rental (
    RentalID INT IDENTITY(1,1) PRIMARY KEY,
    ClientNo VARCHAR(10) FOREIGN KEY REFERENCES Client(ClientNo),
    PropertyNo VARCHAR(10) FOREIGN KEY REFERENCES Property(PropertyNo),
    RentStart DATE,
    RentFinish DATE,
    Rent DECIMAL(10,2));

--1) Insert values to Client table
	INSERT INTO Client (ClientNo, cName) VALUES
	('CR76', 'John Kay'),
	('CR56', 'Aline Stewart');

--2) Insert values to Owner table
	INSERT INTO Owners (OwnerNo, oName) VALUES
	('C040', 'Tina Murphy'),
	('C093', 'Tony Shaw');

--3) Insert values to Property table
	INSERT INTO Property (PropertyNo, pAddress, OwnerNo) VALUES
	('PG4', '6 Lawrence St, Glasgow', 'C040'),
	('PG16', '5 Novar Dr, Glasgow', 'C093'),
	('PG36', '2 Manor Rd, Glasgow', 'C093');

--4) Insert values Rental table
	INSERT INTO Rental (ClientNo, PropertyNo, RentStart, RentFinish, Rent) VALUES
	('CR76', 'PG4', '2000-07-01', '2001-08-31', 350),
	('CR76', 'PG16', '2002-09-01', '2002-09-01', 450),
	('CR56', 'PG4', '1999-09-01', '2000-06-10', 350),
	('CR56', 'PG36', '2000-10-10', '2001-12-01', 370),
	('CR56', 'PG16', '2002-11-01', '2003-08-01', 450);

--Displaying Table
	SELECT * FROM Client;
	SELECT * FROM Owners;
	SELECT * FROM Property;
	SELECT * FROM Rental;

