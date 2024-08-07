CREATE TABLE dbo.Brands (
    BrandID INT PRIMARY KEY IDENTITY(1,1),
    BrandName NVARCHAR(50) NOT NULL
);

CREATE TABLE dbo.Colors (
    ColorID INT PRIMARY KEY IDENTITY(1,1),
    ColorName NVARCHAR(50) NOT NULL
);

CREATE TABLE dbo.Cars (
    ID INT PRIMARY KEY IDENTITY(1,1),
    BrandID INT FOREIGN KEY REFERENCES dbo.Brands(BrandID),
    ColorID INT FOREIGN KEY REFERENCES dbo.Colors(ColorID),
    CarDescription NVARCHAR(50) NOT NULL,
    ModelYear  INT NOT NULL,
    DailyPrice decimal NOT NULL
);