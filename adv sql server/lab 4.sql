use ITI

--1 
create view gt50
as
	select CONCAT_WS(' ', s.St_Fname , s.St_Lname) as Full_Name , c.Crs_Name , sc.Grade from Student s join Stud_Course sc on sc.St_Id = s.St_Id
	join Course c on c.Crs_Id = sc.Crs_Id where sc.Grade > 50;


select * from gt50


--2
create view mgrTop 
as	
with e
	select i.Ins_Name , t.Top_Name from Instructor i 
	join Ins_Course ic on i.Ins_Id = ic.Ins_Id
	join Course c on c.Crs_Id = ic.Crs_Id
	join Topic t on t.Top_Id = c.Top_Id 
	join Department d on d.Dept_Manager = i.Ins_Id 


select * from mgrTop


create view depName 
as 
	select i.Ins_Name , d.Dept_Name from Instructor i join Department d on d.Dept_Id = i.Dept_Id
	where d.Dept_Name in ('SD' , 'JAVA')


select * from depName 


create view v1
as
	select * from Student where Student.St_Address in ('Alex' , 'Cairo') 
with check option


select * from v1

UPDATE v1
SET st_address = 'tanta'
WHERE st_address = 'alex';



use Company_SD

create view comsd 
as
	select COUNT(e.SSN) as Number , p.Pname from Employee e 
	join Works_for w on e.SSN = w.ESSn join Project p on p.Pnumber = w.Pno group by p.Pname


select * from comsd


-- works fine
create nonclustered index i1 on Department(Manager_hiredate)

-- didnt work as there is already duplicated keys so it wont work
create unique index i7   
on student(st_age)



-- create first table
create table UsersTransactions (
    UserID int primary key,
    TransactionAmount decimal(10,2)
);

-- create second table
create table NewTransactions (
    UserID int primary key,
    TransactionAmount decimal(10,2)
);

-- insert sample data
insert into UsersTransactions values
(1, 500.00),
(2, 1200.50),
(3, 300.00);

insert into NewTransactions values
(2, 1500.00),
(3, 300.00),
(4, 800.00);

-- merge statement
merge into UsersTransactions as t
using NewTransactions as s
on t.UserID = s.UserID
when matched then
    update
    set t.TransactionAmount = s.TransactionAmount
when not matched then
    insert (UserID, TransactionAmount)
    values (s.UserID, s.TransactionAmount);

select * from UsersTransactions

drop table UsersTransactions , NewTransactions


use sd

--CREATE SYNONYM Emp FOR [HumanResource].[Employee];
CREATE SYNONYM proj FOR [Company].[project];
CREATE SYNONYM dep FOR [Company].[department];



create view v_clerk
as
	select emp.empNo , proj.projNum from emp
	join works_on on Emp.empNo = works_on.empNo
	join proj on proj.projNum = works_on.projNum
	where works_on.job = 'Clerk'

select * from v_clerk



create view v_without_budget
as
select *
from proj
where budget is null;

select * from v_without_budget

create view v_count
as
select 
    proj.projName,
    count(works_on.job) as job_count
from proj
join works_on on proj.projNum = works_on.projNum
group by proj.projName;


select * from v_count


create view v_project_p2
as
select empNo
from v_clerk
where projNum = 2;


select * from v_project_p2


alter view v_without_budget
as
select *
from proj
where projNum in (1, 2);


drop view v_clerk;
drop view v_count;


create view v_emp_d2
as
select 
    empNo,
    empLname
from emp
where deptNum = 2;


select * from v_emp_d2


select empLname
from v_emp_d2
where empLname like '%J%';




create view v_dept
as
select 
    deptNo,
    deptName
from dep;


select * from v_dept


insert into v_dept (deptNo, deptName) values (4, 'Development');

create view v_2006_check
as
select
    empNo,
    projNum,
	enter_date
from works_on
where enter_date between '2006-01-01' and '2006-12-31'



select * from v_2006_check










