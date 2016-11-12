-- Self Join
-- -----------

-- ********************************************************************************************************************************************************
--                                              Tables
--                                              ------

mysql> DESC product;
+-----------------+-------------+------+-----+---------+-------+
| Field           | Type        | Null | Key | Default | Extra |
+-----------------+-------------+------+-----+---------+-------+
| product_cd      | varchar(10) | NO   | PRI | NULL    |       |
| name            | varchar(50) | NO   |     | NULL    |       |
| product_type_cd | varchar(10) | NO   | MUL | NULL    |       |
| date_offered    | date        | YES  |     | NULL    |       |
| date_retired    | date        | YES  |     | NULL    |       |
+-----------------+-------------+------+-----+---------+-------+
5 rows in set (0.23 sec)

 mysql> DESC customer;
+--------------+------------------+------+-----+---------+----------------+
| Field        | Type             | Null | Key | Default | Extra          |
+--------------+------------------+------+-----+---------+----------------+
| cust_id      | int(10) unsigned | NO   | PRI | NULL    | auto_increment |
| fed_id       | varchar(12)      | NO   |     | NULL    |                |
| cust_type_cd | enum('I','B')    | NO   |     | NULL    |                |
| address      | varchar(30)      | YES  |     | NULL    |                |
| city         | varchar(20)      | YES  |     | NULL    |                |
| state        | varchar(20)      | YES  |     | NULL    |                |
| postal_code  | varchar(10)      | YES  |     | NULL    |                |
+--------------+------------------+------+-----+---------+----------------+
7 rows in set (0.04 sec)

mysql> DESC employee;
+--------------------+----------------------+------+-----+---------+
| Field              | Type                 | Null | Key | Default |
+--------------------+----------------------+------+-----+---------+
| emp_id             | smallint(5) unsigned | NO   | PRI | NULL    |
| fname              | varchar(20)          | NO   |     | NULL    |
| lname              | varchar(20)          | NO   |     | NULL    |
| start_date         | date                 | NO   |     | NULL    |
| end_date           | date                 | YES  |     | NULL    |
| superior_emp_id    | smallint(5) unsigned | YES  | MUL | NULL    |
| dept_id            | smallint(5) unsigned | YES  | MUL | NULL    |
| title              | varchar(20)          | YES  |     | NULL    |
| assigned_branch_id | smallint(5) unsigned | YES  | MUL | NULL    |
+--------------------+----------------------+------+-----+---------+
9 rows in set (0.11 sec)

 mysql> DESC department;
+---------+----------------------+------+-----+---------+
| Field   | Type                 | Null | Key | Default |
+---------+----------------------+------+-----+---------+
| dept_id | smallint(5) unsigned | No   | PRI | NULL    |
| name    | varchar(20)          | No   |     | NULL    |
+---------+----------------------+------+-----+---------+
2 rows in set (0.03 sec)



-- ********************************************************************************************************************************************************
--                                              Existing information in the table i.e. No of Rows
--                                              -------------------------------------------------
-- There are only 18 employees and 3 different departments




-- ********************************************************************************************************************************************************
--                                              Cross Join or Cartesian Product 
--                                              -------------------------------
-- 18 * 3 = 54
-- the result of joining multiple tables without specifying any join conditions.
SELECT pt.name, p.product_cd, p.name
FROM product p CROSS JOIN product_type pt;


-- ********************************************************************************************************************************************************
--                                              Equi-Join/Inner-Join
--                                              --------------------

-- Problem Definition: 
-- Retrieve the first and last names of each employee along with the name of the department to which each employee is assigned.

-- Soln:
SELECT emp.fname, emp.lname, dept.name 
FROM   employee emp , department dept
WHERE  emp.dept_id = dept.dept_id;

                -- OR

SELECT emp.fname, emp.lname, dept.name 
FROM   employee emp JOIN department dept 
                ON emp.dept_id = emp.dept_id;

                -- OR

SELECT emp.fname, emp.lname, dept.name 
FROM   employee emp INNER JOIN department dept 
                ON emp.dept_id = emp.dept_id;

-- Join variation with nested query 
-- Problem Definition: find all accounts opened by experienced tellers currently assigned to the Woburn branch
SELECT acct.account_id, acct.cust_id, acct.open_date, acct.product_cd
FROM account acct INNER JOIN (SELECT emp_id, assigned_branch_id
                             FROM employee
                             WHERE start_date < '2007-01-01'
                                   AND (title = 'Teller' OR title = 'Head Teller')) emp
                       ON acct.open_emp_id = emp.emp_id
                  INNER JOIN (SELECT branch_id
                             FROM branch
                             WHERE name = 'Woburn Branch') branch
                       ON emp.assigned_branch_id = branch.branch_id;

-- ********************************************************************************************************************************************************
--                                              Self-Join
--                                              ---------
-- Problem : Display name of employees and there superior. 
-- Problem Definition: Display employee first and last name with superiors first and last name.

-- Soln:

-- Employee table includes a self-referencing foreign key, 
-- which means that it includes a column (superior_emp_id) that points to the primary key within the same table. 
-- Visualize there are two table .
-- (1) employee table with employee information with superior_emp_id as foreign key which points the information in superior table.
-- (2) superior table with superior information with emp_id as primary key. 

-- ----------------------------     --------------------
-- |  Employee Table          |     | Superior Table    |   
-- ----------------------------     --------------------
-- | Emp_ID | Superior_Emp_ID |     | Emp_ID            |
-- ----------------------------     ---------------------


SELECT emp.fname, emp.lname, superior.fname, superior.lname
FROM   employee emp JOIN employee superior
                ON emp.superior_emp_id = superior.emp_id;


-- ********************************************************************************************************************************************************
--                                      Non equi-join 
--                                      -------------

-- You may also find a need for a self-non-equi-join, meaning that a table is joined to itself using a non-equi-join. 
-- For example, let’s say that the operations manager has decided to have a chess tournament for all bank tellers. 
-- You have been asked to create a list of all the pairings. 
-- You might try joining the employee table to itself for all tellers (title = 'Teller') and return all rows where the emp_ids don’t match (since a person can’t play chess against himself):

SELECT emp1.fname, emp1.lname, "VS" vs, emp2.fname, emp2.lname  
FROM   employee emp1 JOIN employee emp2
                ON emp1.emp_id != emp2.emp_id
WHERE  emp1.title = emp2.title = "Teller";

SELECT emp1.fname, emp1.lname, "VS" vs, emp2.fname, emp2.lname  
FROM   employee emp1 JOIN employee emp2
                ON emp1.title != emp2.title
WHERE  emp1.title = "Teller"
       AND emp1.emp_id != emp2.emp_id;


-- Natural Joins
--  lets the database server determine what the join conditions need to be
 -- For example, the account table includes a column named cust_id, which is the foreign key to the customer table,whose primary key is also named cust_id. Thus, you can write a query that uses natural join to join the two tables:

SELECT a.account_id, a.cust_id, c.cust_type_cd, c.fed_id
FROM account a NATURAL JOIN customer c;


-- SET
------

SELECT 'IND' type_cd, cust_id, lname name
FROM individual
UNION ALL
SELECT 'BUS' type_cd, cust_id, name
FROM business;