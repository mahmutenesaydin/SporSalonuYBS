Create database SporSalonuYSDB
go
Use SporSalonuYSDB
Go
Create table Roles
(
RoleID int primary key identity,
Role varchar(40)
)
Go
Create table Users
(
UserID int primary key identity,
Username varchar(50) not null,
Password varchar(50) not null,
EMail varchar(100) not null unique,
RoleID int not null,
Foreign Key(RoleID)
References Roles(RoleID)
)
Go
Create table Members
(
MembersID int primary key identity,
UserID int not null,
Firstname varchar(40) not null,
LastName varchar(40) not null,
Phone varchar(15) unique not null,
Foreign Key(UserID)
References Users(UserID)
)
Go
Create table Manager
(
ManagerID int primary key identity,
UserID int not null,
FirstName varchar(40) not null,
LastName varchar(40) not null,
Phone varchar(15) unique not null,
Foreign Key(UserID)
References Users(UserID)
)
Go
Create table Categories
(
CategoryID int primary key identity,
CategoryName varchar(40) not null,
Decription varchar(max)
)
Go
Create table Dealers
(
DealerID int primary key identity,
DealerName varchar(40) not null,
Adress varchar(max) not null
)
Go

Create table Products
(
ProductID int primary key identity,
CategoryID int not null,
DealerID int not null,
ProductName varchar(40) not null,
Description varchar(1000) not null,
Price decimal not null,
ImageUrl varchar(500),
Foreign Key(CategoryID)
References Categories(CategoryID),
Foreign Key(DealerID)
References Dealers(DealerID)
)
Go

Create table Equipment
(
EquipmentID int primary key identity,
DealerID int not null,
EquipmentName varchar(50) not null,
Description varchar(500),
Foreign Key(DealerID)
References Dealers(DealerID)
)
Go
Create table Sponsors
(
SponsorID int primary key identity,
DealerID int not null,
SponsorName varchar(100) not null,
ImageUrl varchar(1000),
Foreign Key(DealerID)
References Dealers(DealerID)
)
Go
Create table Trainers
(
TrainerID int primary key identity,
RoleID int not null,
DealerID int not null,
FirstName varchar(40) not null,
LastName varchar(40) not null,
EMail varchar(100) unique not null,
Foreign Key(RoleID)
References Roles(RoleID),
Foreign Key(DealerID)
References Dealers(DealerID)
)
Go
Create table Exercises
(
ExercisesID int primary key identity,
TrainerID int not null,
ExerciseName varchar(40) not null,
Description varchar(1000) not null,
Foreign Key(TrainerID)
References Trainers(TrainerID)
)
Go
Create table Basket
(
BasketID int primary key identity,
ProductID int not null,
MembersID int not null,
Quantity int not null,
Price decimal not null,
SubTotalPrice decimal not null,
Foreign Key(ProductID)
References Products(ProductID),
Foreign Key(MembersID)
References Members(MembersID)
)
Go
Create table OrderDetails
(
OrderDetailsID int primary key identity,
ProductID int not null,
MembersID int not null,
Quantity int not null,
Foreign Key(ProductID)
References Products(ProductID),
Foreign Key(MembersID)
References Members(MembersID)
)
Go
Create table Orders
(
OrderID int primary key identity,
MembersID int,
ShippedDate date,
ShippedAdress varchar(max),
ShippedFirstName varchar(100),
ShippedLastName varchar(100),
ShippedPhone varchar(20),
ShippedCity varchar(50),
ShippedTown varchar(50),

Foreign Key(MembersID)
References Members(MembersID)
)
Go
