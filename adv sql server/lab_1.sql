use ITI;

--1
select count(*) from Student where St_Age is not null


--2
select distinct ins_name from Instructor


--3
--select s.St_Id , ISNULL( s.St_Fname , 'blank' )+' ' + ISNULL(s.St_Lname , ' ') as Full_Name , ISNULL(d.Dept_Name,'no dept') as Department_Name from Student s join Department d on s.Dept_Id = d.Dept_Id


--4
--select i.Ins_Name , d.Dept_Name  from Instructor i left join Department d on i.Dept_Id = d.Dept_Id


--5
--select CONCAT(s.St_Fname,' ',s.St_Fname) as Full_Name , c.Crs_Name as Course_Name from Student s join Stud_Course sc on s.St_Id = sc.St_Id join Course c on c.Crs_Id = sc.Crs_Id 


--6
--select t.Top_Name ,COUNT(*) as Number from Course c join Topic t on c.Top_Id = t.Top_Id group by t.Top_Name


--7
--select MAX(i.Salary) , MIN(i.Salary) from Instructor i


--8
--select * from Instructor where Salary < (select avg(Salary) from Instructor)


--9
--select d.Dept_Name from Department d where d.Dept_Id = (select i.Dept_Id from Instructor i where i.Salary = (select min(Salary) from Instructor))  


--10
--select top(2) Salary from Instructor order by Salary desc 


--11
--select Ins_Name, coalesce(Salary, 'bonus') as Salary from Instructor;


--12
--select avg(Salary) from Instructor


--13
--select std.St_Fname as Student_Name , sup.* from Student std join Student sup on std.St_super = sup.St_Id 


--14
--select * from (select * , DENSE_RANK() over(partition by dept_id order by Salary desc) as rd from Instructor where Salary is not null) as t where rd <= 2


--15
--select top(1)* from Student order by NEWID()



use AdventureWorks2012;

--1
--select SalesOrderID, ShipDate  from Sales.SalesOrderHeader where ShipDate between '2005-07-28' and '2014-07-29'


--2
--select p.ProductID , p.Name from Production.Product p where p.StandardCost < 110 


--3
--select p.ProductID ,p.Name from Production.Product p where p.Weight is null


--4
--select p.ProductID ,p.Name , p.Color from Production.Product p where p.Color in ('Red' , 'Silver' , 'Black') order by Color


--5
--select p.ProductID ,p.Name from Production.Product p where p.Name like 'b%'


--6
--UPDATE Production.ProductDescription
--SET Description = 'Chromoly steel_High of defects'
--WHERE ProductDescriptionID = 3

-- لو من غير [] هيدور للي عنده حرف واحد بس علي الاقل

--select * from Production.ProductDescription p where p.Description like '%[_]%'  


--7
--select sum(s.TotalDue) as Total from Sales.SalesOrderHeader s where s.OrderDate between '7/1/2001' and '7/31/2014'

--8
--select distinct HireDate from HumanResources.Employee


--9
--select avg(ListPrice) as average from (select distinct ListPrice from Production.Product ) as temp


--10
--select concat('The ', Name, ' is only! ', ListPrice) as ProductInfo from Production.Product where ListPrice between 100 and 120 order by ListPrice;


--11
--select rowguid, Name, SalesPersonID, Demographics into store_Archive from Sales.Store;

--drop table store_Archive;

--select rowguid, Name, SalesPersonID, Demographics into store_Archive from Sales.Store where 1+1=4;


--12
SELECT CONVERT(VARCHAR, GETDATE(), 101) AS TodayDate
UNION
SELECT CONVERT(VARCHAR, GETDATE(), 103)
UNION
SELECT CONVERT(VARCHAR, GETDATE(), 105)
UNION
SELECT CONVERT(VARCHAR, GETDATE(), 110);







