
exec SP_AddCategories 'Supplementler','Bu kategoride sporcular i�in �zel destekleyiciler mevcuttur.'
go
exec SP_AddCategories 'T-Shirtler(Erkek)','Bu kategoride erkek sporcular i�in t-shirtler mevcuttur.'
go
exec SP_AddCategories 'T-Shirler(Kad�n)','Bu kategoride kad�n sporcular i�in t-shirtler mevcuttur'
go
exec SP_AddDealers 'Bagcilar StormGYM','Necip faz�l caddesi no 41'
go
exec SP_AddEquiepment 1,'Dumbell','Bir veya birden fazla kas grubunu �al��t�rmak 
i�in kullan�lan a��rl�k ekipman�'
go
exec SP_AddRoles 'User'
go 
exec SP_AddRoles 'Admin'
go 
exec SP_AddUsers 'Yonetici1','sifre1',2,'metehanyolcu0q@outlook.com'
go
exec SP_AddUsers 'Yonetici2','sifre2',2,'hasangezeroglu@yandex.com'
go
exec SP_AddManager 1,'Metehan','Yolcu','05425624606'
go
exec SP_AddManager 2,'Hasan','Gezero�lu','05423213022'
go
exec SP_AddSponsor 1,'Nike'
go
exec SP_AddSponsor 1,'Puma'
go
exec SP_AddTrainers 1,1,'Berkin','Ren�bero�lu','berkinrencberoglu@yandex.com'
go
exec SP_AddTrainers 1,1,'Fatma','Yal��n','fatmayalcin@outlook.com'
go
exec SP_AddExercises 2,'Mekik','Kar�n kaslar�n� aktif olarak �al��t�ran diren� egzersizi'
go
exec SP_AddExercises 1,'Squat','Birden fazla kas� �al��t�ran diren� egzersizi'
go
exec SP_AddExercises 1,'��nav','G���s,kar�n ve kol b�lgesini a��rl�kl� olarak �al��t�ran diren� antreman�'
go
