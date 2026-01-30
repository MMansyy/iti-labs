use sd


sp_Addtype loc , 'nchar(2)';

create table department
(
	deptNo int primary,
	deptName varchar(20),
	location loc
)

create rule r1 as @x in ('NY' ,'DS' , 'KW');

sp_bindrule r1 , 'department.location'

create default def1 as 'NY';

sp_bindefault def1,'department.location'


select * from department



create table employee 
(
	empNo int primary key identity(1,1),
	empFname varchar(20) not null ,
	empLname varchar(20) not null ,
	salary int unique ,
	deptNum int ,
	constraint c1 foreign key(deptNum) references department(deptNo)
)

create rule r2 as @x >= 6000;

sp_bindrule r2 , 'employee.salary'

-- لان مفيش موظف بالرقم ده
INSERT INTO Works_On (EmpNo, projNum, Job, Enter_Date)
VALUES (11111, 1, 'Analyst', '2025-12-15');

--نفس الفكره
UPDATE Works_On
SET EmpNo = 11111
WHERE EmpNo = 10102;

-- نفس الفكره
UPDATE Employee
SET empNo = 22222
WHERE empNo = 10102;

-- نفس اللكلام بردو
DELETE FROM Employee
WHERE empNo = 10102;


ALTER TABLE Employee
ADD TelephoneNumber VARCHAR(15) NULL;


ALTER TABLE Employee
DROP COLUMN TelephoneNumber;



CREATE SCHEMA Company;



CREATE SCHEMA HumanResource;


ALTER SCHEMA Company TRANSFER dbo.Department;

ALTER SCHEMA Company TRANSFER dbo.Project;

ALTER SCHEMA HumanResource TRANSFER dbo.Employee;



SELECT 
   *
FROM 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE 
    TABLE_NAME = 'Employee';


CREATE SYNONYM Emp FOR [HumanResource].[Employee];

-- مش هيشتغ احنا مش في الdbo دلوقتي
Select * from Employee
-- هيشتغل تمام
Select * from [HumanResource].[Employee]

-- هيشتغل
Select * from Emp

-- مش هيشتغل مفيش حاجه اسمها emp
Select * from [HumanResource].Emp


UPDATE P SET P.Budget = P.Budget * 1.1 FROM [Company].[Project] AS P JOIN Works_On AS W
ON P.projNum = W.projNum WHERE W.EmpNo = 10102 AND W.Job = 'Manager';


UPDATE D
SET D.DeptName = 'Sales'
FROM [Company].[Department] AS D
INNER JOIN [HumanResource].[Employee] AS E
    ON D.DeptNo = E.DeptNum
WHERE E.empFname = 'James';


UPDATE W
SET W.Enter_Date = '2007-12-12'
FROM Works_On AS W
INNER JOIN [HumanResource].[Employee] AS E
    ON W.EmpNo = E.empNo
INNER JOIN [Company].[Department] AS D
    ON E.DeptNum = D.DeptNo
WHERE W.projNum = 1  
  AND D.DeptName = 'Sales';

DELETE W
FROM Works_On AS W
INNER JOIN [HumanResource].[Employee] AS E
    ON W.EmpNo = E.empNo
INNER JOIN [Company].[Department] AS D
    ON E.DeptNum = D.DeptNo
WHERE D.Location = 'KW';


