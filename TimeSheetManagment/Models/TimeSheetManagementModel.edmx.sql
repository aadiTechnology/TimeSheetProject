
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/03/2020 19:09:29
-- Generated from EDMX file: D:\Projects\Time sheet\TimeSheetManagment\TimeSheetManagment\Models\TimeSheetManagementModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TimeSheet];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClientDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientDetails];
GO
IF OBJECT_ID(N'[dbo].[Company_Master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company_Master];
GO
IF OBJECT_ID(N'[dbo].[EmployeeDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeDetails];
GO
IF OBJECT_ID(N'[dbo].[Module_Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Module_Details];
GO
IF OBJECT_ID(N'[dbo].[Project_Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project_Details];
GO
IF OBJECT_ID(N'[dbo].[TaskDeatils]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskDeatils];
GO
IF OBJECT_ID(N'[dbo].[TimeSheetsDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeSheetsDetails];
GO
IF OBJECT_ID(N'[dbo].[Activity_Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activity_Type];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClientDetails'
CREATE TABLE [dbo].[ClientDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientName] nvarchar(200)  NULL,
    [CompanyId] int  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'Company_Master'
CREATE TABLE [dbo].[Company_Master] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(200)  NULL
);
GO

-- Creating table 'EmployeeDetails'
CREATE TABLE [dbo].[EmployeeDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpName] nvarchar(200)  NULL,
    [Designation] nvarchar(200)  NULL
);
GO

-- Creating table 'Module_Details'
CREATE TABLE [dbo].[Module_Details] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Modules] nvarchar(100)  NULL,
    [ProjectId] int  NULL
);
GO

-- Creating table 'Project_Details'
CREATE TABLE [dbo].[Project_Details] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(200)  NULL,
    [ClientId] int  NULL
);
GO

-- Creating table 'TaskDeatils'
CREATE TABLE [dbo].[TaskDeatils] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TaskName] nvarchar(200)  NULL,
    [Description] nvarchar(max)  NULL,
    [PlannedStartDate] datetime  NULL,
    [PlannedEndDate] datetime  NULL,
    [PlannedEfforts] int  NULL,
    [ModuleId] int  NULL
);
GO

-- Creating table 'TimeSheetsDetails'
CREATE TABLE [dbo].[TimeSheetsDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpId] int  NULL,
    [TaskId] int  NULL,
    [ActualStartDate] datetime  NULL,
    [ActualEndDate] datetime  NULL,
    [Efforts] int  NULL,
    [ProductiveHrs] int  NULL,
    [ActivityComment] nvarchar(500)  NULL,
    [ActId] nchar(10)  NULL
);
GO

-- Creating table 'Activity_Type'
CREATE TABLE [dbo].[Activity_Type] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Activity] nvarchar(200)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClientDetails'
ALTER TABLE [dbo].[ClientDetails]
ADD CONSTRAINT [PK_ClientDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Company_Master'
ALTER TABLE [dbo].[Company_Master]
ADD CONSTRAINT [PK_Company_Master]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeDetails'
ALTER TABLE [dbo].[EmployeeDetails]
ADD CONSTRAINT [PK_EmployeeDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Module_Details'
ALTER TABLE [dbo].[Module_Details]
ADD CONSTRAINT [PK_Module_Details]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Project_Details'
ALTER TABLE [dbo].[Project_Details]
ADD CONSTRAINT [PK_Project_Details]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaskDeatils'
ALTER TABLE [dbo].[TaskDeatils]
ADD CONSTRAINT [PK_TaskDeatils]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TimeSheetsDetails'
ALTER TABLE [dbo].[TimeSheetsDetails]
ADD CONSTRAINT [PK_TimeSheetsDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Activity_Type'
ALTER TABLE [dbo].[Activity_Type]
ADD CONSTRAINT [PK_Activity_Type]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------