CREATE TABLE Customers(
id int Primary KEY,
Name VARCHAR(10) not null);

CREATE TABLE Orders(
id int PRIMARY Key,
CustomerId int not null,
FOREIGN KEY(CustomerId) REFERENCES Customers(id));

insert into Customers (id, name) VALUES
(1,'Maxim'),
(2,'Pavel'),
(3,'Ivan'),
(4,'Leoind');

insert into orders (id, customerid) VALUES
(1,2),
(2,4);

select customers.name from customers LEFT join orders on customers.id = orders.customerid where customerid is null;
