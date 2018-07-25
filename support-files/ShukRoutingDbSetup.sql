CREATE TABLE dbo.Commodities
(
CommodityID INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
CommodityName NVARCHAR(30) NOT NULL
);

CREATE TABLE dbo.Stalls
(
StallID INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
StallName NVARCHAR(50) NOT NULL, FirstCoord INT, SecondCoord INT
);

DROP TABLE CommoditiesStalls

CREATE TABLE dbo.CommoditiesStalls
(
CommodityStallID INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
CommodityID INT FOREIGN KEY REFERENCES Commodities(CommodityID), 
StallID INT FOREIGN KEY REFERENCES Stalls(StallID), 
Price SMALLMONEY NOT NULL CHECK(Price > 0), 
Rating INT CHECK(Rating >= 1 AND Rating <= 5), 
TimeRegistered DateTime NOT NULL DEFAULT(SYSDATETIME()), 
Notes NVARCHAR(140)
);

INSERT INTO Commodities 
(CommodityName) 
VALUES
('Grapes'), 
('Bananas'), 
('French Rolls');

INSERT INTO Stalls
(StallName, FirstCoord, SecondCoord) 
Values 
('Chaim''s Stall', 32, 40), 
('Roland''s Rolls', 50, 19), 
('Shabbos Treats', 12, 31);

INSERT INTO  CommoditiesStalls
(CommodityID, StallID, Price) 
VALUES 
(2, 3, 21.34), 
(3, 2, 12.12), 
(4, 4, 5.67);