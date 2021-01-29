Use SporSalonuYSDB
Go
--Sepette girilen ürünün miktarý 1 den düþük olamaz
Create Trigger TRG_CheckBasketQuantity
On Basket
After Update
As
Begin
	Declare @id Int
	Set @id = (select BasketID from inserted)
	if(exists(select Quantity from inserted where inserted.Quantity < 1))
	Update Basket
	Set Quantity = 1 where BasketID = @id
	Else
	Print 'Deðer 1 den büyük'
	End
Go

--Sepetteki ürün baþýna toplam fiyat ürünün miktarýndan düþük olamaz
Create Trigger TRG_CheckSubTotalPrice
On Basket
After Update
As
Begin
Declare @id int
Set @id = (select BasketID from inserted)
if(exists(select SubTotalPrice from inserted where inserted.SubTotalPrice < inserted.Price))
Update Basket
Set SubTotalPrice = Price where BasketID = @id
End
Go