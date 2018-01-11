/*
--Drop Tables
drop table Raketest
drop table TestResults
drop table TestExpectedResults
drop table TestParameters
*/


create table RakeTest(
id int identity not null,
[text] nvarchar(max) not null,
resultsId int not null,
paramsId int not null,
expectedId int
)
go
create table TestResults(
testId int not null,
phrase nvarchar(50) not null
)
go
create table TestExpectedResults(
testId int not null,
phrase nvarchar(50) not null
)
go
create table TestParameters(
testId int not null,
minCharLength int not null,
maxWordsLength int not null,
minWordsFreq int not null
)
go
--primary keys

alter table RakeTest
add constraint RakeTest_id_pk
primary key (id)
go


alter table TestResults
add constraint TestResults_testId_Phrase_PK
primary key (testId,phrase)
go

alter table TestExpectedResults
add constraint TestExpectedResults_testId_Phrase_PK
primary key (testId,phrase)
go

alter table TestParameters
add constraint TestParameters_testId_PK
primary key (testId)
go

--foreign keys

alter table TestResults
add constraint TestResults_resultsId_FK
foreign key (testId) references RakeTest (id) 
go

alter table TestExpectedResults
add constraint TestExpectedResults_testId_FK
foreign key (testId) references RakeTest (id) 
go

alter table TestParameters
add constraint TestParameters_testId_FK
foreign key (testId) references RakeTest (id) 
go


