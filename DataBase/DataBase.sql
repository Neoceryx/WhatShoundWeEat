
CREATE DATABASE WSWET

USE WSWET

create table Users(

Id int identity(1,1) primary key,
PersonalName varchar(100) not null,
Surnames varchar(500) not null,
Gender char(1) not null CHECK(Gender IN ('M', 'F', 'O')),
UserName varchar(50) not null,
Email varchar(500) not null,
Password varchar(500) not null,
ProfilePicture varchar(500),
IsActive bit not null,
RegisterDate datetime DEFAULT GETDATE()

)

create table Groups(

Id int identity(1,1) primary key,
GroupName varchar(100) not null,
Users_Id int not null,
IsAdmin bit not null,
IsActive bit not null,
CreatedDate datetime default GETDATE(),

-- Foreign Key
FOREIGN KEY(Users_Id) REFERENCES Users(Id)
)

create table GroupMembers(

Id int identity(1,1) primary key,
Groups_Id int not null,
Users_Id int not null,
RegisterDate datetime default GETDATE(),

-- Foreign Keys
FOREIGN KEY(Groups_Id) REFERENCES Groups(Id),
FOREIGN KEY(Users_Id) REFERENCES Users(Id)
)

create table StatusRequest(

Id int identity(1,1) primary key,
StatusName varchar(50) not null,

)

create table AdmissionRequests(

Id int identity(1,1) primary key,
Groups_Id int not null,
Users_Id int not null,
StatusRequest_Id int not null,

-- Foreign Keys
FOREIGN KEY(Groups_Id) REFERENCES Groups(Id),
FOREIGN KEY(Users_Id) REFERENCES Users(Id),
FOREIGN KEY(StatusRequest_Id) REFERENCES StatusRequest(Id)

)

create table VotingList(

Id int identity(1,1) primary key,
Groups_Id int not null,
ListName varchar(250) not null,
ScheduledDate datetime,
IsActive bit not null,
CreatedDate dateTime DEFAULT GETDATE(),

-- FOREIGN KEYS
FOREIGN KEY(Groups_Id) REFERENCES Groups(Id)

)

create table VotingListItems(

Id int identity(1,1) primary key,
VotingList_Id int not null,
ItenName varchar(200) not null,
Users_Id int not null,

-- Foregin Keys
FOREIGN KEY (VotingList_Id) REFERENCES VotingList(Id),
FOREIGN KEY(Users_Id) REFERENCES Users(Id)

)

create table Votes(

Id int identity(1,1) primary key,
VotingListItems_Id int not null,
Users_Id int not null,

-- FOREIGN KEY
FOREIGN KEY(VotingListItems_Id) REFERENCES VotingListItems(Id),
FOREIGN KEY(Users_Id) REFERENCES Users(Id)

)
