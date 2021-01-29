Use SporSalonuYSDB
Go
--Sepette girilen �r�n�n miktar� 1 den d���k olamaz
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
	Print 'De�er 1 den b�y�k'
	End
Go

--Sepetteki �r�n ba��na toplam fiyat �r�n�n miktar�ndan d���k olamaz
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