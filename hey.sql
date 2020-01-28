CREATE TABLE Categories(
idCategory int primary key not null,
idPost int not null,
FOREIGN KEY(idPost) 
REFERENCES Posts(idPost) ON DELETE CASCADE
)

CREATE TABLE NamedCategories(
idCategory int primary key not null,
nameCategory varchar(50) not null,
)
