-- Verificar se o banco de dados existe antes de criar
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'dashboard')
BEGIN
    CREATE DATABASE dashboard;
END

USE dashboard;

DROP TABLE IF EXISTS items_sale;
DROP TABLE IF EXISTS sales;
DROP TABLE IF EXISTS customers;
DROP TABLE IF EXISTS users;

--Criação das tabelas
CREATE TABLE users(
	id INT PRIMARY KEY IDENTITY(1,1),
	full_name VARCHAR(150) NOT NULL,
	email VARCHAR(150) NOT NULL,
	password VARCHAR(150) NOT NULL
);

CREATE TABLE customers(
	id INT PRIMARY KEY IDENTITY(1,1),
    full_name VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL,
    telephone VARCHAR(16) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE,
	deleted BIT NOT NULL DEFAULT 0,
    deleted_at DATETIME NULL,
);

CREATE TABLE sales(
	id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT NOT NULL,
    customer_id INT NOT NULL,
    sale_date DATE NOT NULL,
    billing_date DATE NOT NULL,
    sale_total_value DECIMAL(20,2) NOT NULL,
	sale_total_items INT NOT NULL,
	FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (customer_id) REFERENCES customers(id)
);

CREATE TABLE items_sale(
	id INT PRIMARY KEY IDENTITY(1,1),
    sale_id INT NOT NULL,
    item_description VARCHAR(150) NOT NULL,
    quantity INT NOT NULL,
    unity_value DECIMAL(10,2) NOT NULL,
    total_value DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (sale_id) REFERENCES sales(id)
);

--Vizualizar tabelas por completo
SELECT * FROM customers;
SELECT * FROM sales;
SELECT * FROM items_sale;
SELECT * FROM users;



--Cadastro de um novo usuário
INSERT INTO users(full_name, email, password)
VALUES('Alberto Marinho', 'alberto8marinho@gmail.com','123456789');

--Cadastro de novo cliente, em /customers-form
IF EXISTS (SELECT 1 FROM customers WHERE cpf = '000.000.000-33' AND deleted = 0)
	BEGIN
		PRINT 'Usuário já cadastrado.';
	END
ELSE IF EXISTS (SELECT 1 FROM customers WHERE cpf = '000.000.000-33' AND deleted = 1)
	BEGIN
		UPDATE customers
		SET full_name = 'Jack Sparrow',
			email = 'jack@gmail.com',
			telephone = '(47)99612-7200',
			cpf = '000.000.000-22',
			deleted = 0,
			deleted_at = NULL
		WHERE ID = 1;
	END
ELSE 
	BEGIN
		INSERT INTO customers(full_name, email, telephone, cpf, deleted)
		VALUES('Claudia Nescau', 'clauNesc@gmail.com', '(47)99612-7200', '000.000.000-33', 0);
	END;




--Cadastro de nova venda e respectivos produtos, em /sales-form
BEGIN TRANSACTION;

INSERT INTO sales(user_id, customer_id, sale_date, billing_date, sale_total_value, sale_total_items)
VALUES(1, 1, '2023-12-12', '2023-12-13', 26.50, 12);

DECLARE @saleId INT;
SET @saleId = SCOPE_IDENTITY();

INSERT INTO items_sale(sale_id, item_description, quantity, unity_value, total_value) 
VALUES(@saleId, 'Batatinha', 3, 5.25, 10.50),
	(@saleId, 'Pão de Batata', 7, 5.50, 11),
	(@saleId, 'Batata Frita', 2, 2.50, 5);

COMMIT;

BEGIN TRANSACTION;

INSERT INTO sales(user_id, customer_id, sale_date, billing_date, sale_total_value, sale_total_items)
VALUES(1, 2, '2023-12-12', '2023-12-13', 600, 120);

DECLARE @saleId2 INT;
SET @saleId2 = SCOPE_IDENTITY();

INSERT INTO items_sale(sale_id, item_description, quantity, unity_value, total_value) 
VALUES(@saleId2, 'Batatinha premium', 30, 5.25, 165),
	(@saleId2, 'Pão de Batata premium', 70, 5.50, 385),
	(@saleId2, 'Batata Frita premium', 20, 2.50, 50);

COMMIT;

BEGIN TRANSACTION;

INSERT INTO sales(user_id, customer_id, sale_date, billing_date, sale_total_value, sale_total_items)
VALUES(1, 3, '2023-12-12', '2023-12-13', 47.25, 11);

DECLARE @saleId3 INT;
SET @saleId3 = SCOPE_IDENTITY();

INSERT INTO items_sale(sale_id, item_description, quantity, unity_value, total_value) 
VALUES(@saleId3, 'Batatinha da promo', 5, 5.25, 26.25),
	(@saleId3, 'Pão de Batata da promo', 2, 5.50, 11),
	(@saleId3, 'Batata Frita da promo', 4, 2.50, 10);

COMMIT;






--Listar clientes no input Select, em /sales-form
SELECT id, full_name
FROM customers
WHERE deleted = 0
ORDER BY full_name;

--Listar vendas cadastradas no sistema, em /sales
SELECT customers.full_name, sales.sale_date, sales.billing_date,
	SUM(quantity) AS total_quantity_items,
    SUM(total_value) AS total_quantity_value
FROM sales
INNER JOIN customers
	ON sales.customer_id = customers.id
INNER JOIN items_sale
	ON items_sale.sale_id = sales.id
GROUP BY items_sale.sale_id, customers.full_name, sales.sale_date, sales.billing_date;




--Atualizar dados de Customer, em /sales
UPDATE customers
SET full_name = 'Fulana de Tal',
    email = 'fulana@gmail.com',
    telephone = '(47)99612-7200',
    cpf = '111.111.111-11'
WHERE ID = 1;




-- Soft delete para a tabela customers
UPDATE customers
SET deleted = 1, deleted_at = GETDATE()
WHERE id = 1;

-- Delete para a tabela sales
DELETE FROM sales WHERE id = 1;





--Atividades:

--Retornar todos os pedidos onde o valor faturado for mais que um valor X (Escolher um valor):
SELECT users.full_name AS user_name, customers.full_name AS customer_name, sales.sale_date, sales.billing_date, sales.sale_total_value, sales.sale_total_items
FROM sales
	INNER JOIN users ON sales.user_id = users.id
	INNER JOIN customers ON sales.customer_id = customers.id
WHERE sale_total_value > 100;

--Retornar todos os pedidos onde há item/itens com a descrição X (Usar uma parcial do nome de algum item informado):
SELECT sales.id AS id_vendas_que_contenham_descricao
FROM sales
	INNER JOIN items_sale ON sales.id = items_sale.sale_id
WHERE items_sale.item_description LIKE '%premium%'
GROUP BY sales.id;

--Retornar o valor médio de todos os pedidos:
SELECT CONVERT(DEC(10,2), AVG(sale_total_value)) AS media_valor_todos_pedidos
FROM sales;

--Retornar o valor médio dos pedidos por cliente:
SELECT customers.full_name AS customer, CONVERT(DEC(10,2), AVG(sale_total_value)) AS media_valor_todos_pedidos
FROM sales
	INNER JOIN customers ON customers.id = sales.customer_id
GROUP BY customers.full_name;

--Criar alguns pedidos que contenham o mesmo item, então faça uma consulta que me retorne (item, quantidade total vendida, valor total vendido)
SELECT items_sale.item_description, SUM(items_sale.quantity) AS quantidade_total_vendida, SUM(items_sale.total_value) AS valor_total_vendido
FROM items_sale
GROUP BY items_sale.item_description;