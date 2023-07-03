Create database QLSV;
use QLSV;

create table sv(
code char(4) primary key,
fullName nvarchar(30),
sex nvarchar(3),
birthDay date,
addres nvarchar(30),
phone char(10),
score_A1 float,
score_A2 float,
score_A3 float);

insert into sv values('SV01', N'Phạm Tuấn Anh', N'Nam', '2002-05-19', N'Yên Bái', '0869014150', 8, 9, 8.8);
insert into sv values('SV04', N'Phạm Kiều Anh', N'Nữ', '2002-06-19', N'Hà Nội', '0123456789', 10, 10, 9);
select *from sv;