create database EventManagementSystem
 
 
create table users
(
UserId int primary key identity(1,1),
Fullname nvarchar(50) not null,
Username nvarchar(50) not null unique,
password nvarchar(50) not null,
Role nvarchar(10) not null
)

insert into users values
('Admin User', 'admin', 'admin123', 'Admin')
select * from users

------------------------------------------------------

create table Tableevent
(
    eventid int primary key identity,
    eventname nvarchar(100)null,
    eventdate datetime null,
)

select * from Tableevent

-------------------------------------------------------

create table Tablevenue
(
    venueid int primary key identity,
    venue nvarchar(100)null,
    events1 nvarchar(100)null
)

select * from Tablevenue

--------------------------------------------------------

create table Tableservice
(
    serviceid int primary key identity,
    servicename nvarchar(100),
    servicecharge decimal(18, 2)null
)

select * from Tableservice

---------------------------------------------------------
 
create table Tablebookvenue
(
    id int primary key identity,
    name nvarchar(100)null,
    mobilenumber varchar(10)null,
	event1 nvarchar(200)null,
	venue nvarchar(100)null,
	eventdate datetime null,
	requirements varchar(200) null
)

select * from Tablebookvenue

---------------------------------------------------------

create table Admins
(
AdminId int identity(1,1) primary key,
UserName VARCHAR (30),
Password nvarchar(100)
)
insert into admins Values('siva@gmail.com','siva@123')

select * from Admins

---------------------------------------------------------

select * from Admins
select * from Tableevent
select * from Tablevenue
select * from Tableservice
select * from Tablebookvenue






 
