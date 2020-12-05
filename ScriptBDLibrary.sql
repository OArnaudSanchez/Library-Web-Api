Create database Library
use Library


Create table Author
(
	id int not null primary key identity(1,1),
	Name varchar(50) not null,
	LastName varchar(50) not null,
	BirthDate date not null,
	AuthorGender bit not null
)

Create table Gender
(
	id int not null primary key identity(1,1),
	NameGender varchar(50) not null unique
)


Create table Book
(
	id int not null primary key identity(1,1),
	Title varchar(100) not null,
	ReleaseDate date not null,
	Editorial varchar(100) not null default 'IBSN',
	Author int not null,
	Gender int not null,
	Constraint Fk_Author_Book foreign key(Author) references Author(id),
	Constraint FK_Gender_Book foreign key(Gender) references Gender(id)
)



Insert into Author values('Juan Emilio', 'Bosch Gaviño', '30-06-1909', 1)
Select * from Author

insert into Book (Title, ReleaseDate, Author, Gender) values('La Mañosa', '12-08-1936', 1,1)
Select * from Book


insert into Gender values('Novela')
Select * from Gender