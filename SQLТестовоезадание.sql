-- -- Создание таблицы Products
-- CREATE TABLE Products (
--     ID SERIAL PRIMARY KEY,
--     Name VARCHAR(255),
--     Cost DECIMAL,
--     Volume DECIMAL
-- );

-- -- Создание таблицы Managers
-- CREATE TABLE Managers (
--     ID SERIAL PRIMARY KEY,
--     Fio VARCHAR(255),
--     Salary DECIMAL,
--     Age INTEGER,
--     Phone VARCHAR(20)
-- );

-- -- Создание таблицы Sells
-- CREATE TABLE Sells (
--     ID SERIAL PRIMARY KEY,
--     ID_Manag INTEGER,
--     ID_Prod INTEGER,
--     Count INTEGER,
--     Sum DECIMAL,
--     Date DATE,
--     FOREIGN KEY (ID_Manag) REFERENCES Managers (ID),
--     FOREIGN KEY (ID_Prod) REFERENCES Products (ID)
-- );

-- -- TASK 1
-- SELECT *
-- FROM Managers
-- WHERE Phone IS NOT NULL;

-- -- TASK 2
-- SELECT COUNT(*)
-- FROM Sells
-- WHERE Date = '2021-06-20';

-- TASK 3
-- SELECT AVG(Sum)
-- FROM Sells
-- WHERE ID_Prod = (SELECT ID FROM Products WHERE Name = 'Фанера');

-- -- TASK 4
-- SELECT m.Fio, SUM(s.Sum) as TotalSales
-- FROM Managers m
-- JOIN Sells s ON m.ID = s.ID_Manag
-- JOIN Products p ON s.ID_Prod = p.ID
-- WHERE p.Name = 'ОСБ'
-- GROUP BY m.Fio;

-- -- TASK 5
-- SELECT m.Fio, p.Name AS Product
-- FROM Managers m
-- JOIN Sells s ON m.ID = s.ID_Manag
-- JOIN Products p ON s.ID_Prod = p.ID
-- WHERE s.Date = '2021-08-22';

-- -- TASK 6
-- SELECT *
-- FROM Products
-- WHERE Name LIKE '%Фанера%' AND Cost >= 1750;

-- -- TASK 7
-- SELECT DATE_TRUNC('month', s.Date) AS Sale_Month, p.Name AS Product_Name, SUM(s.Count) AS Total_Sold
-- FROM Sells s
-- JOIN Products p ON s.ID_Prod = p.ID
-- GROUP BY DATE_TRUNC('month', s.Date), p.Name
-- ORDER BY Sale_Month, p.Name;

-- -- TASK 8
-- SELECT Name, COUNT(*) as Repetitions
-- FROM Products
-- GROUP BY Name
-- HAVING COUNT(*) > 1;



