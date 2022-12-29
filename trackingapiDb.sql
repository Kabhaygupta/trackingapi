create database trackingApi
use trackingApi

create table Issue(
Id int identity(1,1) not null,
Title varchar(max) not null,
Description varchar(max) not null,
Priority int not null,
IssueType int not null,
Created datetime not null,
Completed datetime,
primary key(Id),
)

select *from Issue
insert into Issue values('Asp.net Tutorial','This is the .net tutorial',1,2,GETDATE(),GETDATE());