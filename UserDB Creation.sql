-- Create a new database called 'UserDB'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'UserDB
    '
)
CREATE DATABASE UserDB
GO

-- Create a new table called '[Organization]' in schema '[dbo]'
-- Drop the table if it already exists
-- IF OBJECT_ID('[dbo].[Organization]', 'U') IS NOT NULL
-- DROP TABLE [dbo].[Organization]
-- GO
-- Create the table in the specified schema
-- CREATE TABLE [dbo].[Organization]
-- (
   

-- );
-- GO

-- Create a new table called '[OrganizationCredentials]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[OrganizationCredentials]', 'U') IS NOT NULL
DROP TABLE [dbo].[OrganizationCredentials]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[OrganizationCredentials]
(
    [Id] STRING NOT NULL PRIMARY KEY, -- Primary Key column
    [credentials] LIST,
   
);
GO

-- Create a new table called '[Attribute]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Attribute]', 'U') IS NOT NULL
DROP TABLE [dbo].[Attribute]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Attribute]
(
    [name] STRING, -- Primary Key column
    [value] STRING, 
   
);
GO

-- Create a new table called '[UserData]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[UserData]', 'U') IS NOT NULL
DROP TABLE [dbo].[UserData]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[UserData]
(
    [Id] STRING, -- Primary Key column
    [attributes] LIST,
    [credentials] LIST, 
    [hash] STRING,
    [profile_version] INT, 
);
GO