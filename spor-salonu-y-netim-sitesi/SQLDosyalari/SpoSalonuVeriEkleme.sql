
exec SP_AddCategories 'Supplementler','Bu kategoride sporcular için özel destekleyiciler mevcuttur.'
go
exec SP_AddCategories 'T-Shirtler(Erkek)','Bu kategoride erkek sporcular için t-shirtler mevcuttur.'
go
exec SP_AddCategories 'T-Shirler(Kadýn)','Bu kategoride kadýn sporcular için t-shirtler mevcuttur'
go
exec SP_AddDealers 'Bagcilar StormGYM','Necip fazýl caddesi no 41'
go
exec SP_AddEquiepment 1,'Dumbell','Bir veya birden fazla kas grubunu çalýþtýrmak 
için kullanýlan aðýrlýk ekipmaný'
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
exec SP_AddManager 2,'Hasan','Gezeroðlu','05423213022'
go
exec SP_AddSponsor 1,'Nike'
go
exec SP_AddSponsor 1,'Puma'
go
exec SP_AddTrainers 1,1,'Berkin','Rençberoðlu','berkinrencberoglu@yandex.com'
go
exec SP_AddTrainers 1,1,'Fatma','Yalçýn','fatmayalcin@outlook.com'
go
exec SP_AddExercises 2,'Mekik','Karýn kaslarýný aktif olarak çalýþtýran direnç egzersizi'
go
exec SP_AddExercises 1,'Squat','Birden fazla kasý çalýþtýran direnç egzersizi'
go
exec SP_AddExercises 1,'Þýnav','Göðüs,karýn ve kol bölgesini aðýrlýklý olarak çalýþtýran direnç antremaný'
go
