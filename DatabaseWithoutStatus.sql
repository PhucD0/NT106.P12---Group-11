CREATE DATABASE RemoteDesktopDB1

USE RemoteDesktopDB1

CREATE TABLE ConnectionLogs (
    Id INT PRIMARY KEY IDENTITY,
    IPAddress NVARCHAR(50),
    AccessTime DATETIME
);

