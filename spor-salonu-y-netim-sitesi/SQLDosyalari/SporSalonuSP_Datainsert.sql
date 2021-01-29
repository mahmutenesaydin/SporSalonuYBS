--Veri tabanina veri ekleme query'si

--Sepet tablosuna veri girisi icin yazilan stored precedure
Create Proc SP_AddBasket
	@ProductID int,
	@MembersID int,
	@Quantity int,
	@Price money,
	@SubTotalPrice decimal
As
Begin
	Insert Into Basket Values(@ProductID,@MembersID,@Quantity,@Price,@SubTotalPrice)
End
Go

--Kategori tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddCategories

	@CategoryName varchar(100),
	@Description varchar(max)
	As
Begin
	Insert Into Categories Values(@CategoryName,@Description)
End
Go

--Bayi tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddDealers
@DealerName varchar(100),
@Address varchar(max)
As
Begin
Insert into Dealers values(@DealerName,@Address)
End
Go

--Ekipman tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddEquiepment
@DealerID int,
@EquipmentN varchar(100),
@Description varchar(max)
As
Begin
Insert into Equipment values(@DealerID,@EquipmentN,@Description)
End
Go

--Antreman tablosuna veri girisi icin yazilan stored procedure
Create proc SP_AddExercises
@TrainerID int,
@ExerciseName varchar(100),
@Description varchar(max)
As
Begin
Insert into Exercises values(@TrainerID,@ExerciseName,@Description)
End
Go

--Yonetici tablosuna veri girisi icin yazilan stored procedure
Create proc SP_AddManager
@UserID int,
@FirstName varchar(100),
@LastName varchar(100),
@Phone varchar(13)
As
Begin
Insert into Manager values(@UserID,@FirstName,@LastName,@Phone)
End
Go

--Uyeler(Musteri) tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddMembers
@UserID int,
@FirstName varchar(50),
@LastName  varchar(50),
@Phone varchar(16)
As
Begin
Insert into Members values(@UserID,@FirstName,@LastName,@Phone)
End
Go

--Siparis Detay(OrderDetails) tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddOrderDetails
@ProductID int,
@MembersID int,
@Quantity int
As
Begin
Insert into OrderDetails values(@ProductID,@MembersID,@Quantity)
End
Go

--Siparis(Orders) tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddOrders
@MembersID int,
@ShippedDate date,
@ShippedAdress varchar(max),
@Shippedname varchar(100),
@ShippedCity varchar(50),
@ShippedTown varchar(50),
@CartFName varchar(50),
@CartLName varchar(50),
@CartNumber varchar(17),
@CartLastDate varchar(6)
As
Begin
Insert into Orders values(@MembersID,@ShippedDate
,@ShippedAdress,@Shippedname,@ShippedCity,@ShippedTown,
@CartFName,@CartLName,@CartNumber,@CartLastDate)
End
Go

--Product(Ürünler) tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddProducts
@CategoryID int,
@DealerID int,
@ProductName varchar(100),
@Price money,
@ImageURL varchar(max)
As
Begin
Insert into Products values(@CategoryID,@DealerID,
@ProductName,@Price,@ImageURL)
End
Go

--Roles(Roller) tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddRoles
@Role varchar(50)
As
Begin
Insert into Roles values(@Role)
End
Go

--Sponsors(Sponsorlar) tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddSponsor
@DealerID int,
@SponsorName varchar(100)
As
Begin
Insert into Sponsors values(@DealerID,@SponsorName)
End
Go

--Trainers(Antrenorler) tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddTrainers
@RoleID int,
@DealerID int,
@FirstName varchar(50),
@LastName varchar(50),
@Email varchar(100)
As
Begin
Insert into Trainers values(@RoleID,@DealerID,@FirstName,@LastName,@Email)
End
Go

--Users(Kullanicilar) tablosuna veri girisi icin yazilan stored procedure
Create Proc SP_AddUsers
@UserName varchar(50),
@Password varchar(50),
@RoleID int,
@EMail varchar(100)
As
Begin
Insert into Users values(@UserName,@Password,@RoleID,@EMail)
End
Go















