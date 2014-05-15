USE [master]
    GO
    IF EXISTS(SELECT * FROM sys.databases WHERE NAME = 'SofiaCarRental_v2.2')
    BEGIN
    DROP DATABASE [SofiaCarRental_v2.2]
    END
    GO
    USE [master]
    GO
    CREATE DATABASE [SofiaCarRental_v2.2]
    GO
    IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
    BEGIN
    EXEC [SofiaCarRental_v2.2].[dbo].[sp_fulltext_database] @ACTION = 'enable'
    END
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET ANSI_NULL_DEFAULT OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET ANSI_NULLS OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET ANSI_PADDING OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET ANSI_WARNINGS OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET ARITHABORT OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET AUTO_CLOSE ON
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET AUTO_CREATE_STATISTICS ON
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET AUTO_SHRINK OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET AUTO_UPDATE_STATISTICS ON
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET CURSOR_CLOSE_ON_COMMIT OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET CURSOR_DEFAULT  GLOBAL
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET CONCAT_NULL_YIELDS_NULL OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET NUMERIC_ROUNDABORT OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET QUOTED_IDENTIFIER OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET RECURSIVE_TRIGGERS OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET  ENABLE_BROKER
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET DATE_CORRELATION_OPTIMIZATION OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET TRUSTWORTHY OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET ALLOW_SNAPSHOT_ISOLATION OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET PARAMETERIZATION SIMPLE
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET READ_COMMITTED_SNAPSHOT OFF
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET  READ_WRITE
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET RECOVERY SIMPLE
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET  MULTI_USER
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET PAGE_VERIFY CHECKSUM
    GO
    ALTER DATABASE [SofiaCarRental_v2.2] SET DB_CHAINING OFF
    GO
    USE [SofiaCarRental_v2.2]
    GO
    /****** Object:  Table [dbo].[Employees]    Script Date: 02/08/2012 12:50:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    SET ANSI_PADDING ON
    GO
    CREATE TABLE [dbo].[Employees](
    [EmployeeID] [INT] IDENTITY(1,1) NOT NULL,
    [EmployeeNumber] [NCHAR](5) NULL,
    [FirstName] [varchar](32) NULL,
    [LastName] [varchar](32) NOT NULL,
    [FullName]  AS (([LastName]+', ')+[FirstName]),
    [Title] [varchar](80) NULL,
    [HourlySalary] [smallmoney] NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED
    (
    [EmployeeID] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET ANSI_PADDING OFF
    GO
    SET IDENTITY_INSERT [dbo].[Employees] ON
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (1, N'88798', N'James', N'Robinson', N'janitor', 2.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (2, N'78965', N'John', N'Martinez', N'sales man', 7.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (3, N'14856', N'Robert', N'Garcia', N'sales man', 7.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (4, N'65823', N'Michael', N'Thompson', N'sales man', 7.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (5, N'13526', N'William', N'Martin', N'sales man', 7.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (6, N'25558', N'David', N'Harris', N'sales man', 7.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (7, N'69856', N'Richard', N'White', N'sales man', 7.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (8, N'14785', N'Charles', N'Jackson', N'manager', 9.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (9, N'13689', N'Joseph', N'Thomas', N'driver', 5.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (10, N'10585', N'Thomas', N'Anderson', N'driver', 5.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (11, N'45896', N'Christopher', N'Taylor', N'driver', 5.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (12, N'36985', N'Daniel', N'Moore', N'supervisor', 11.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (13, N'18745', N'Paul', N'Wilson', N'dealer', 12.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (14, N'12563', N'Mark', N'Miller', N'dealer', 12.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (15, N'85963', N'Donald', N'Davis', N'janitor', 2.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (16, N'15368', N'George', N'Brown', N'janitor', 2.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (17, N'69853', N'Kenneth', N'Jones', N'QA', 15.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (18, N'25478', N'Steven', N'Williams', N'chairman', 55.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (19, N'15789', N'Edward', N'Johnson', N'driver', 5.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (20, N'87596', N'Brian', N'Smith', N'driver', 5.0000)
    INSERT [dbo].[Employees] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [Title], [HourlySalary]) VALUES (21, N'12126', N'Internet', N'Internet', N'Internet', 5.0000)
    SET IDENTITY_INSERT [dbo].[Employees] OFF
    /****** Object:  Table [dbo].[Customers]    Script Date: 02/08/2012 12:50:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    SET ANSI_PADDING ON
    GO
    CREATE TABLE [dbo].[Customers](
    [CustomerID] [INT] IDENTITY(1,1) NOT NULL,
    [DrvLicNumber] [varchar](50) NULL,
    [FullName] [varchar](80) NULL,
    [Address] [varchar](100) NOT NULL,
    [Country] [varchar](100) NOT NULL,
    [City] [varchar](50) NULL,
    [State] [varchar](50) NULL,
    [ZIPCode] [varchar](20) NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
    (
    [CustomerID] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET ANSI_PADDING OFF
    GO
    SET IDENTITY_INSERT [dbo].[Customers] ON
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (1, N'240-573-885', N'John Wattson', N'4024 Locktar Drive', N'USA', N'Silver Spring', N'MD', N'20904')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (2, N'264-72-6663', N'Charles Calhoun', N'10630 Leila Rd #D4', N'USA', N'Alexandria', N'VA', N'22231')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (3, N'802-46-4006', N'Jeannine Pons', N'802 Mimosa Road NW', N'USA', N'Washington', N'DC', N'20006')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (4, N'264-72-6663', N'Charles Calhoun', N'10630 Leila Rd #D4', N'USA', N'Alexandria', N'VA', N'22231')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (5, N'386-32-3456', N'Jarmein Defoe', N'Historic Road 66', N'USA', N'Tuskegee', N'TS', N'34612')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (6, N'568-17-9875', N'James White', N'Minnehaha AND Hiawatha Avenue', N'USA', N'Trussville', N'TR', N'22114')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (7, N'288-14-5423', N'William King', N'889 Lake D4', N'USA', N'Southside', N'ST', N'20897')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (8, N'978-27-1145', N'Jeff Lewis', N'4451 Willow', N'USA', N'Smiths', N'SM', N'20999')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (9, N'879-13-7798', N'Ronald Young', N'4412 Mill', N'USA', N'Prichard', N'PR', N'22665')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (10, N'147-22-6663', N'Kevin Allen', N'19676 Lakeview', N'USA', N'Guntersville', N'GR', N'22566')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (11, N'725-12-3498', N'Joseph Harris', N'55878 Broadway', N'USA', N'Fort Payne', N'FP', N'22967')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (12, N'778-13-6871', N'Michael Smith', N'17896 Sycamore', N'USA', N'Craig-Tyler', N'CT', N'22643')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (13, N'123-56-3567', N'Thomas Wilson', N'57878 Hillcrest', N'USA', N'Attalla', N'AT', N'22123')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (14, N'546-61-1878', N'Anthony Moore', N'77485 Madison', N'USA', N'Birmingham', N'BR', N'22309')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (15, N'745-66-9863', N'George Martinez', N'68598 Taylor', N'USA', N'Chehalis', N'CH', N'22576')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (16, N'124-33-3568', N'Jason Baker', N'77748 Woodland', N'USA', N'Everett', N'EV', N'22138')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (17, N'665-38-8745', N'Mark Hernandez', N'11478 Dogwood', N'USA', N'Lake Stevens', N'LS', N'22265')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (18, N'453-32-8777', N'John Brown', N'88798 Spruce', N'USA', N'Spokane', N'SP', N'22731')
    INSERT [dbo].[Customers] ([CustomerID], [DrvLicNumber], [FullName], [Address], [Country], [City], [State], [ZIPCode]) VALUES (19, N'489-89-1744', N'Whyne Rooney', N'74256 Franklin', N'USA', N'Washougal', N'WS', N'22311')
    SET IDENTITY_INSERT [dbo].[Customers] OFF
    /****** Object:  Table [dbo].[Categories]    Script Date: 02/08/2012 12:50:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    SET ANSI_PADDING ON
    GO
    CREATE TABLE [dbo].[Categories](
    [CategoryID] [INT] IDENTITY(1,1) NOT NULL,
    [CategoryName] [varchar](50) NOT NULL,
    [ImageFileName] [varchar](256) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED
    (
    [CategoryID] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET ANSI_PADDING OFF
    GO
    SET IDENTITY_INSERT [dbo].[Categories] ON
    INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [ImageFileName]) VALUES (1, N'Hatchback', N'hatchback.png')
    INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [ImageFileName]) VALUES (2, N'Saloon', N'saloon.png')
    INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [ImageFileName]) VALUES (3, N'People Carrier', N'peoplecarrier.png')
    INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [ImageFileName]) VALUES (4, N'SUV', N'suv.png')
    INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [ImageFileName]) VALUES (5, N'Limousine', N'limousine.png')
    SET IDENTITY_INSERT [dbo].[Categories] OFF
    /****** Object:  Table [dbo].[RentalRates]    Script Date: 02/08/2012 12:50:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[RentalRates](
    [RentalRateID] [INT] IDENTITY(1,1) NOT NULL,
    [CategoryID] [INT] NULL,
    [Daily] [smallmoney] NULL,
    [Weekly] [smallmoney] NULL,
    [Monthly] [smallmoney] NULL,
    CONSTRAINT [PK_RentalRates] PRIMARY KEY CLUSTERED
    (
    [RentalRateID] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET IDENTITY_INSERT [dbo].[RentalRates] ON
    INSERT [dbo].[RentalRates] ([RentalRateID], [CategoryID], [Daily], [Weekly], [Monthly]) VALUES (1, 2, 2.0000, 12.0000, 44.0000)
    INSERT [dbo].[RentalRates] ([RentalRateID], [CategoryID], [Daily], [Weekly], [Monthly]) VALUES (2, 1, 1.0000, 6.0000, 22.0000)
    INSERT [dbo].[RentalRates] ([RentalRateID], [CategoryID], [Daily], [Weekly], [Monthly]) VALUES (3, 4, 5.0000, 3.0000, 11.0000)
    INSERT [dbo].[RentalRates] ([RentalRateID], [CategoryID], [Daily], [Weekly], [Monthly]) VALUES (4, 3, 1.0000, 9.0000, 33.0000)
    INSERT [dbo].[RentalRates] ([RentalRateID], [CategoryID], [Daily], [Weekly], [Monthly]) VALUES (5, 5, 5.0000, 12.0000, 36.0000)
    SET IDENTITY_INSERT [dbo].[RentalRates] OFF
    /****** Object:  Table [dbo].[Cars]    Script Date: 02/08/2012 12:50:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    SET ANSI_PADDING ON
    GO
    CREATE TABLE [dbo].[Cars](
    [CarID] [INT] IDENTITY(1,1) NOT NULL,
    [TagNumber] [varchar](20) NOT NULL,
    [Make] [varchar](50) NULL,
    [Model] [varchar](50) NOT NULL,
    [CarYear] [SMALLINT] NULL,
    [CategoryID] [INT] NULL,
    [Mp3Player] [BIT] NULL,
    [DVDPlayer] [BIT] NULL,
    [AirConditioner] [BIT] NULL,
    [ABS] [BIT] NULL,
    [ASR] [BIT] NULL,
    [Navigation] [BIT] NULL,
    [Available] [BIT] NULL,
    [Latitude] [FLOAT] NULL,
    [Longitude] [FLOAT] NULL,
    [ImageFileName] [varchar](256) NULL,
    [Rating] [DECIMAL](9, 2) NULL,
    [NumberOfRatings] [INT] NULL,
    CONSTRAINT [IX_Cars_TagNumber] UNIQUE ([TagNumber]),
    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED
    (
    [CarID] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET ANSI_PADDING OFF
    GO
    SET IDENTITY_INSERT [dbo].[Cars] ON
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (1, N'TE 3445 IK', N'Opel', N'Corsa', 2004, 1, 1, 0, 1, 1, 0, 0, 1, 42.697872, 23.321583, N'opel_corsa_2004.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (2, N'TE 2312 IK', N'Honda', N'Civic', 1993, 1, 1, 0, 0, 1, 0, 0, 1, 48.139126, 11.580186, N'honda_civic_2006.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (3, N'TE 6645 IK', N'Hyundai', N'I30', 2008, 1, 0, 0, 0, 0, 0, 0, 1, 48.873974, 2.324701, N'hyundai_i30_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (4, N'TE 3455 IK', N'Audi', N'A3', 2003, 1, 1, 1, 1, 1, 0, 0, 0, 48.873974, 2.324701, N'audi_a3_2003.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (5, N'TE 3789 IK', N'Mercedez', N'Aclass', 2007, 1, 1, 0, 1, 1, 0, 0, 1, 48.201763, 16.379904, N'mercedesbenz_aclass.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (6, N'TE 3445 IM', N'Mercedez', N'Bclass', 2007, 1, 1, 0, 1, 1, 0, 0, 1, 43.210134, 27.920162, N'mercedesbenz_bclass_lorinzer.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (7, N'TE 8934 IK', N'Alfaromeo', N'147', 2006, 1, 1, 1, 1, 0, 1, 1, 1, 48.201763, 16.379904, N'alfaromeo_147_2006.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (8, N'TE 5484 IK', N'Volvo', N'c30', 2009, 1, 1, 0, 1, 1, 0, 0, 1, 48.201763, 16.379904, N'volvo_c30_2009.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (9, N'TE 9876 IK', N'Lancia', N'Ypsilon', 2006, 1, 1, 0, 1, 1, 0, 0, 1, 48.873974, 2.324701, N'lancia_ypsilon_2006.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (10, N'TE 1254 IK', N'Honda', N'CR-Z', 2010, 1, 1, 0, 0, 1, 0, 0, 1, 49.177862, -0.379726, N'honda_cr-z_2010.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (11, N'TE 5317 IK', N'Renault', N'Laguna', 2008, 1, 1, 0, 1, 1, 0, 0, 1, 43.210134, 27.920162, N'renault_laguna_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (12, N'TE 4567 IK', N'VW', N'Golf', 2008, 1, 1, 1, 1, 1, 1, 1, 1, 42.697872, 23.321583, N'vw_golf_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (13, N'TE 7856 IK', N'Volvo', N'S60', 2010, 2, 1, 0, 1, 1, 0, 0, 1, 48.139126, 11.580186, N'volvo_s60_2010.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (14, N'TE 3454 IK', N'Audi', N'A4', 2002, 2, 1, 0, 1, 1, 1, 1, 0, 48.873974, 2.324701, N'audi_a4_2002.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (15, N'TE 5434 IK', N'BMW', N'535d', 2006, 2, 1, 1, 1, 1, 1, 1, 1, 48.873974, 2.324701, N'bmw_535d_2005.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (16, N'TE 7656 IK', N'BMW', N'320d', 2006, 2, 1, 1, 0, 0, 1, 1, 1, 48.201763, 16.379904, N'bmw_320d_2006.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (17, N'TE 1221 IK', N'VW', N'Passat', 2005, 2, 0, 0, 0, 0, 0, 0, 1, 43.210134, 27.920162, N'vw_passat_2005.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (18, N'TE 2232 IK', N'Peugeot', N'407', 2006, 2, 1, 0, 1, 1, 0, 0, 1, 48.201763, 16.379904, N'peugeot_407_2006.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (20, N'TE 3498 IK', N'Honda', N'Accord', 2008, 2, 1, 0, 0, 1, 0, 0, 1, 48.873974, 2.324701, N'honda_accord_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (21, N'TE 9009 IK', N'Alfaromeo', N'159', 2008, 2, 0, 0, 0, 1, 1, 1, 1, 49.177862, -0.379726, N'alfaromeo_159_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (22, N'TE 4132 IK', N'Toyota', N'Corolla', 2007, 3, 1, 0, 1, 1, 0, 0, 1, 43.210134, 27.920162, N'toyota_corolla_spacio_2007.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (23, N'TE 9383 IK', N'Audi', N'Q7', 2007, 4, 1, 0, 1, 1, 0, 0, 1, 42.697872, 23.321583, N'audi_Q7_2007.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (24, N'TE 2010 IK', N'Hyundai', N'Santafe', 2007, 4, 1, 0, 1, 1, 0, 0, 1, 48.139126, 11.580186, N'hyundai_santafe_2007.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (25, N'TE 1992 IK', N'Nissan', N'Qashqai', 2007, 4, 1, 0, 1, 1, 0, 0, 1, 48.873974, 2.324701, N'nissan_qashqai_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (26, N'TE 6677 IK', N'Toyota', N'Landcruiser', 2005, 4, 1, 0, 1, 1, 0, 0, 1, 48.873974, 2.324701, N'toyota_landcruiser100_2005.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (27, N'TE 6987 IK', N'Volvo', N'xc90', 2006, 4, 1, 0, 1, 1, 0, 0, 1, 48.201763, 16.379904, N'volvo_xc90_2006.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (28, N'TE 1766 IK', N'VW', N'Touareg', 2010, 4, 1, 0, 1, 1, 0, 0, 1, 43.210134, 27.920162, N'vw_touareg_2010.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (29, N'TE 9880 IK', N'VW', N'Touran', 2010, 3, 1, 0, 1, 1, 0, 0, 1, 48.201763, 16.379904, N'vw_touran_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (31, N'TE 0001 IK', N'Nissan', N'Almera', 2001, 2, 1, 0, 1, 1, 0, 0, 1, 48.873974, 2.324701, N'nissan_almera_2001.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (32, N'TE 1000 IK', N'BMW', N'x3', 2007, 4, 1, 1, 1, 1, 1, 1, 1, 49.177862, -0.379726, N'bmw_x3_2007.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (33, N'TE 6666 IK', N'Lincoln', N'TownCar', 2006, 5, 1, 1, 1, 1, 1, 1, 1, 43.210134, 27.920162, N'lincoln_towncar_2006.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (36, N'TE 5656 IK', N'Lincoln', N'TownCar', 2010, 5, 1, 0, 0, 1, 0, 0, 1, 48.873974, 2.324701, N'lincoln_2011towncar_2010.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (37, N'TE 8778 IK', N'Mitsubishi', N'Lancer', 2008, 2, 1, 0, 0, 1, 0, 0, 1, 48.873974, 2.324701, N'mitsubishi_lancer_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (38, N'TE 5555 IK', N'Opel', N'Vectra', 2008, 2, 1, 0, 1, 1, 0, 0, 1, 48.201763, 16.379904, N'opel_vectra_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (39, N'TE 8989 IK', N'Toyota', N'Avensis', 2008, 2, 1, 0, 1, 1, 0, 0, 1, 43.210134, 27.920162, N'toyota_avensis_2008.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (40, N'TE 0000 IK', N'Chrysler', N'300', 2006, 5, 1, 0, 1, 1, 0, 0, 1, 48.201763, 16.379904, N'chrysler_300_2006.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (41, N'TE 0290 IK', N'Mercedez', N'S600', 2009, 5, 1, 0, 1, 1, 0, 0, 1, 48.201763, 16.379904, N'mercedesbenz_S600_pullman_guard.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (42, N'TE 4554 IK', N'VW', N'Phaeton', 2005, 5, 1, 0, 1, 1, 0, 0, 1, 48.873974, 2.324701, N'vw_phaeton_2005.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (43, N'TE 4288 IK', N'Citroen', N'Evasion', 1998, 3, 1, 0, 1, 1, 0, 0, 1, 49.177862, -0.379726, N'citroen_evasion_1998.jpg', NULL, 0)
    INSERT [dbo].[Cars] ([CarID], [TagNumber], [Make], [Model], [CarYear], [CategoryID], [Mp3Player], [DVDPlayer], [AirConditioner], [ABS], [ASR], [Navigation], [Available], [Latitude], [Longitude], [ImageFileName], [Rating], [NumberOfRatings]) VALUES (44, N'TE 7227 IK', N'Ford', N'Galaxy', 1998, 3, 1, 0, 1, 1, 0, 0, 1, 43.210134, 27.920162, N'ford_galaxy_2008.jpg', NULL, 0)
    SET IDENTITY_INSERT [dbo].[Cars] OFF
    /****** Object:  Table [dbo].[RentalOrders]    Script Date: 02/08/2012 12:50:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    SET ANSI_PADDING ON
    GO
    CREATE TABLE [dbo].[RentalOrders](
    [RentalOrderID] [INT] IDENTITY(1,1) NOT NULL,
    [DateProcessed] [datetime] NULL,
    [EmployeeID] [INT] NOT NULL,
    [CustomerID] [INT] NOT NULL,
    [CarID] [INT] NOT NULL,
    [TankLevel] [varchar](40) NULL,
    [MileageStart] [INT] NULL,
    [MileageEnd] [INT] NULL,
    [RentStartDate] [datetime] NOT NULL,
    [RentEndDate] [datetime] NOT NULL,
    [Days]  AS (CONVERT([INT],[RentEndDate]-[RentStartDate],(0))),
    [RateApplied] [money] NULL,
    [OrderTotal]  AS (CONVERT([money],[RateApplied]*CONVERT([INT],[RentEndDate]-[RentStartDate],(0)),(0))),
    [OrderStatus] [varchar](50) NULL,
    CONSTRAINT [PK_RentalOrder] PRIMARY KEY CLUSTERED
    (
    [RentalOrderID] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET ANSI_PADDING OFF
    GO
    SET IDENTITY_INSERT [dbo].[RentalOrders] ON
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (1, CAST(0x000095E400000000 AS DateTime), 1, 1, 1, N'FULL', 100000, 102000, CAST(0x000095E500000000 AS DateTime), CAST(0x000095EA00000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (2, CAST(0x00009B7200000000 AS DateTime), 2, 2, 2, N'FULL', 3500, 3700, CAST(0x0000973300000000 AS DateTime), CAST(0x00009B7F00000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (3, CAST(0x000095B100000000 AS DateTime), 3, 3, 3, N'FULL', 310000, 310200, CAST(0x000095E500000000 AS DateTime), CAST(0x000095EA00000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (4, CAST(0x0000944800000000 AS DateTime), 4, 4, 4, N'FULL', 250000, 250000, CAST(0x0000951A00000000 AS DateTime), CAST(0x0000952200000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (5, CAST(0x0000989500000000 AS DateTime), 5, 5, 5, N'FULL', 250000, 260000, CAST(0x000097D500000000 AS DateTime), CAST(0x000097DB00000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (6, CAST(0x00009A6200000000 AS DateTime), 5, 5, 5, N'FULL', 100000, 100012, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (7, CAST(0x00009B5200000000 AS DateTime), 5, 5, 5, N'FULL', 1000, 1050, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (8, CAST(0x00009B3300000000 AS DateTime), 6, 6, 6, N'FULL', 1000, 1070, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (9, CAST(0x00009B1500000000 AS DateTime), 7, 7, 7, N'FULL', 1000, 1560, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (10, CAST(0x00009AF600000000 AS DateTime), 8, 8, 8, N'FULL', 1000, 1300, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (11, CAST(0x00009AD700000000 AS DateTime), 9, 9, 9, N'FULL', 1000, 1287, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (12, CAST(0x00009AB900000000 AS DateTime), 10, 10, 10, N'FULL', 1000, 1388, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (13, CAST(0x00009A9800000000 AS DateTime), 11, 11, 11, N'FULL', 1000, 1458, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (14, CAST(0x00009A8300000000 AS DateTime), 12, 12, 12, N'FULL', 1000, 1658, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (15, CAST(0x00009A5F00000000 AS DateTime), 13, 13, 13, N'FULL', 1000, 1458, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (16, CAST(0x00009A4D00000000 AS DateTime), 14, 14, 14, N'FULL', 1000, 1689, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    INSERT [dbo].[RentalOrders] ([RentalOrderID], [DateProcessed], [EmployeeID], [CustomerID], [CarID], [TankLevel], [MileageStart], [MileageEnd], [RentStartDate], [RentEndDate], [RateApplied], [OrderStatus]) VALUES (17, CAST(0x00009A2100000000 AS DateTime), 15, 15, 15, N'FULL', 1000, 1333, CAST(0x000095E500000000 AS DateTime), CAST(0x000095E800000000 AS DateTime), 1.0000, N'completed')
    SET IDENTITY_INSERT [dbo].[RentalOrders] OFF
    /****** Object:  Default [DF__Categorie__Image__0425A276]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[Categories] ADD  DEFAULT (NULL) FOR [ImageFileName]
    GO
    /****** Object:  Default [DF__Cars__Latitude__7D78A4E7]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[Cars] ADD  DEFAULT (NULL) FOR [Latitude]
    GO
    /****** Object:  Default [DF__Cars__Longitude__7E6CC920]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[Cars] ADD  DEFAULT (NULL) FOR [Longitude]
    GO
    /****** Object:  Default [DF__Cars__ImageFileN__7F60ED59]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[Cars] ADD  DEFAULT (NULL) FOR [ImageFileName]
    GO
    /****** Object:  Default [DF__Cars__Rating__00551192]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[Cars] ADD  DEFAULT (NULL) FOR [Rating]
    GO
    /****** Object:  Default [DF__Cars__NumberOfRa__014935CB]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[Cars] ADD  DEFAULT ((0)) FOR [NumberOfRatings]
    GO
    /****** Object:  ForeignKey [FK_RentalRateCategory]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[RentalRates]  WITH CHECK ADD  CONSTRAINT [FK_RentalRateCategory] FOREIGN KEY([CategoryID])
    REFERENCES [dbo].[Categories] ([CategoryID])
    GO
    ALTER TABLE [dbo].[RentalRates] CHECK CONSTRAINT [FK_RentalRateCategory]
    GO
    /****** Object:  ForeignKey [FK_Categories]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Categories] FOREIGN KEY([CategoryID])
    REFERENCES [dbo].[Categories] ([CategoryID])
    GO
    ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Categories]
    GO
    /****** Object:  ForeignKey [FK_Cars]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[RentalOrders]  WITH CHECK ADD  CONSTRAINT [FK_Cars] FOREIGN KEY([CarID])
    REFERENCES [dbo].[Cars] ([CarID])
    GO
    ALTER TABLE [dbo].[RentalOrders] CHECK CONSTRAINT [FK_Cars]
    GO
    /****** Object:  ForeignKey [FK_Customers]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[RentalOrders]  WITH CHECK ADD  CONSTRAINT [FK_Customers] FOREIGN KEY([CustomerID])
    REFERENCES [dbo].[Customers] ([CustomerID])
    GO
    ALTER TABLE [dbo].[RentalOrders] CHECK CONSTRAINT [FK_Customers]
    GO
    /****** Object:  ForeignKey [FK_Employees]    Script Date: 02/08/2012 12:50:54 ******/
    ALTER TABLE [dbo].[RentalOrders]  WITH CHECK ADD  CONSTRAINT [FK_Employees] FOREIGN KEY([EmployeeID])
    REFERENCES [dbo].[Employees] ([EmployeeID])
    GO
    ALTER TABLE [dbo].[RentalOrders] CHECK CONSTRAINT [FK_Employees]
    GO
    /****** Object:  StoredProcedure [dbo].[GetProfitFromCar]    Script Date: 1/18/2013 15:56:14 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE PROCEDURE [dbo].[GetProfitFromCar]
    @CarID INT
    AS
    BEGIN
    SET NOCOUNT ON;
    SELECT SUM(OrderTotal) AS Profit FROM dbo.RentalOrders
    WHERE CarID = @CarID
    END
    GO
    /****** Object:  StoredProcedure [dbo].[GetRentalOrdersForCar]    Script Date: 1/18/2013 16:01:38 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE PROCEDURE [dbo].[GetRentalOrdersForCar]
    @CarID INT
    AS
    BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.RentalOrders
    WHERE CarID = @CarID
    END
    GO