CREATE DATABASE RemoteDesktopDB

USE RemoteDesktopDB

CREATE TABLE ConnectionLogs (
    Id INT PRIMARY KEY IDENTITY,
    IPAddress NVARCHAR(50),
    AccessTime DATETIME,
	[Status] NVARCHAR(50)
);

SELECT * FROM ConnectionLogs