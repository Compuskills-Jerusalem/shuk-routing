USE Northwind;

IF db_id('ShukRoutingDB') IS NOT NULL DROP DATABASE ShukRoutingDB;

CREATE DATABASE ShukRoutingDB;

USE ShukRoutingDB;

CREATE TABLE Commodities(
	Commodity_ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	CommodityName NVARCHAR(30) NOT NULL,

);

CREATE TABLE Stalls(
    Stall_ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	StallName NVARCHAR(50) NOT NULL,
	FirstCoord INT,
	SecondCoord INT,
	
);

CREATE TABLE CommoditiesStalls(
	Commodities_Stalls_ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	CommoditiesID INT NOT NULL FOREIGN KEY REFERENCES Commodities(Commodity_ID),
	StallsID INT NOT NULL FOREIGN KEY REFERENCES Stalls(Stall_ID),
	Price SMALLMONEY NOT NULL CHECK(Price > 0),
	Rating INT CHECK(Rating >= 1 AND Rating <= 5),
	TimeRegistered DateTime NOT NULL DEFAULT(SYSDATETIME()),
    Notes NVARCHAR(140)
);

INSERT INTO Commodities (CommodityName)
VALUES ('Grapes'), ('Bananas'), ('French Rolls');

INSERT INTO Stalls(StallName, FirstCoord, SecondCoord)
Values
	('Chaim''s Stall', 32, 40),
	('Roland''s Rolls', 50, 19),
	('Shabbos Treats', 12, 31);
	
INSERT INTO CommoditiesStalls (CommoditiesID, StallsID, Price)
VALUES
	(1, 3, 21.34),
	(3, 2, 12.12),
	(2, 1, 5.67);