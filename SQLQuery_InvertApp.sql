create database InvertApp;
USE InvertApp;


Create table categories
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
);

create table products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    CategoryId INT NOT NULL , 
    Price FLOAT NOT NULL,
    Strock INT NOT NULL
    FOREIGN KEY (CategoryId) REFERENCES categories (Id)
);
