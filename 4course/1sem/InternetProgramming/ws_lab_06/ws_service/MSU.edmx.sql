
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/21/2019 18:03:17
-- Generated from EDMX file: D:\LAST\web-services-master\web-services-master\ws_lab_06\ws_service\MSU.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[Хранилище WSModelContainer].[FK_notes_students]', 'F') IS NOT NULL
    ALTER TABLE [Хранилище WSModelContainer].[notes] DROP CONSTRAINT [FK_notes_students];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[students];
GO
IF OBJECT_ID(N'[Хранилище WSModelContainer].[notes]', 'U') IS NOT NULL
    DROP TABLE [Хранилище WSModelContainer].[notes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'students'
CREATE TABLE [dbo].[students] (
    [id] int  NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'notes'
CREATE TABLE [dbo].[notes] (
    [id] int  NOT NULL,
    [subject] nvarchar(50)  NOT NULL,
    [notes] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'students'
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [PK_students]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [subject], [notes] in table 'notes'
ALTER TABLE [dbo].[notes]
ADD CONSTRAINT [PK_notes]
    PRIMARY KEY CLUSTERED ([id], [subject], [notes] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id] in table 'notes'
ALTER TABLE [dbo].[notes]
ADD CONSTRAINT [FK_notes_students]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[students]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------