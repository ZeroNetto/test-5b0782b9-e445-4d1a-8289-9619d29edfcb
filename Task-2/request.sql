create table products (
	id int primary key,
	name text
);

insert into products
values
	(1, 'Product one'),
	(2, 'Product two'),
	(3, 'Product three');

create table categories (
	id int primary key,
	name text
);

insert into categories
values
	(1, 'Category one'),
	(2, 'Category two'),
	(3, 'Category three');

create table productCategories (
  productId int,
  categoryId int,
	foreign key (productId) references products(id),
	foreign key (categoryId) references categories(id),
	primary key (productId, categoryId)
);

insert into productCategories
values
	(1, 1),
	(1, 2),
	(2, 3);

select p.name as productName, c.name as categoryName
from products p
left join productCategories pc
	on p.id = pc.productId
left join categories c
	on pc.categoryId = c.id;