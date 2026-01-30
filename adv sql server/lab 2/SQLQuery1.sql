--//1
--select Dnum , Dname , Fname , SSN from Departments inner join Employee on MGRSSN = SSN


--//2
--select Dname , Pname from Departments inner join Project on Departments.Dnum = Project.Dnum


--//3
--select Dependent.* , Employee.Fname as Manger_Name from Dependent inner join Employee on ESSN = SSN

--//4
--select Dependent.Dependent_name, Dependent.Sex from dependent inner join employee on dependent.essn = employee.ssn where dependent.sex = 'F' and employee.sex = 'F'
--union
--select Dependent.Dependent_name, Dependent.Sex from dependent inner join employee on dependent.essn = employee.ssn where dependent.sex = 'M' and employee.sex = 'M';

--//5
--select Pnumber, Pname , Plocation from Project where City in ('Alex' , 'Cairo')

--//6
--select * from Project where Pname like 'a%'

--//7
--select * from Employee where Dno = 30 and Salary between 1000 and 2000 


--//8
--select Fname from Employee inner join Works_for on SSN= ESSN inner join Project on Pno = Pnumber where Pname = 'AL Rabwah' and Dno = 10 and Hours >= 10  


--//9
--select Fname + ' ' + Lname as Full_Name from Employee where Superssn = (select SSN from Employee where Fname = 'Kamel') 


--//10
--select Pname ,SUM(Hours) as Total_Hours from Project join Works_for on Project.Pnumber = Works_for.Pno group by Pname


--//11
--select Fname , Pname from Employee join Works_for on SSN = ESSn join Project on Pno = Pnumber order by Pname asc


--//12
--select d.* , e.SSN from Departments d inner join employee e on d.Dnum = e.dno where e.ssn = (select min(ssn) from employee)


--//13
--select Dname , max(Salary) as Maximum_Salary , min(Salary) as Minimum_Salary , avg(salary) as Average_Salary  from Departments join Employee on Dno = Dnum group by Dname


--//14
--select Employee.SSN , Lname from Employee where SSN not in (select Dependent.ESSN from Dependent) and SSN in (select Departments.MGRSSN from Departments)


--//15
--select Departments.Dname , COUNT(Employee.SSN) as Number_Of_Employee from Departments join Employee on Dno = Dnum group by Dname having AVG(Salary) < (select avg(Salary) from Employee)

--//16
--select Lname , Fname , Pname	from Employee join Works_for on SSN = ESSn join Project on Works_for.Pno = Project.Pnumber order by Pname , Lname , Fname


--//17
--select Pnumber, Project.Dnum , Lname , Employee.Address , Employee.Bdate  from Project join Departments on Project.Dnum = Departments.Dnum join Employee on Departments.MGRSSN = Employee.SSN where Project.City ='Cairo'

