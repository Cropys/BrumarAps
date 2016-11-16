
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/10/2014 15:55:55
-- Generated from EDMX file: F:\TestPlan_Brumar\brumarOwnWebsite\withWebApi\BrumarAps\BrumarAps\BrumarDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [brumardk];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LanguageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LanguageSet];
GO
IF OBJECT_ID(N'[dbo].[ContactFormSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactFormSet];
GO
IF OBJECT_ID(N'[dbo].[LoggerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoggerSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LanguageSet'
CREATE TABLE [dbo].[LanguageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Danish] nvarchar(max)  NOT NULL,
    [English] nvarchar(max)  NOT NULL,
    [Icelandic] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ContactFormSet'
CREATE TABLE [dbo].[ContactFormSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LoggerSet'
CREATE TABLE [dbo].[LoggerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Timestamp] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'LanguageSet'
ALTER TABLE [dbo].[LanguageSet]
ADD CONSTRAINT [PK_LanguageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactFormSet'
ALTER TABLE [dbo].[ContactFormSet]
ADD CONSTRAINT [PK_ContactFormSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LoggerSet'
ALTER TABLE [dbo].[LoggerSet]
ADD CONSTRAINT [PK_LoggerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------