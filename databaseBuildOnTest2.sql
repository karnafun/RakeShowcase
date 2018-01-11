
/*
drop table TagsInArticle
drop table Articles
drop table authors


*/




create table Articles (
id int identity,
authorId int,
title nvarchar(50) not null,
[text] nvarchar(max) not null
)

create table Authors(
id int identity not null,
[name] nvarchar(60)
)


create table TagsInArticle (
tag nvarchar(30) not null,
articleId int
)


--primary keys

alter table Articles
add constraint Articles_PK
primary key (id)
go

alter table Authors
add constraint Authors_PK
primary key (id)
go

alter table TagsInArticle
add constraint TagsInArticle_PK 
primary key (tag)
go

--foriegn keys

alter table Articles 
add constraint Articles_Author_FK
foreign key (authorId) references Authors(id)
go


alter table TagsInArticle 
add constraint TagsInArticle_Article_FK
foreign key (articleId) references Articles(id)
