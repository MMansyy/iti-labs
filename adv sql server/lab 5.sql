
--1
create proc getNum 
as 
	select COUNT(s.St_Id) as Student_Number , d.Dept_Name from Student s join Department d on s.Dept_Id = d.Dept_Id group by d.Dept_Name


exec getNum



--2
use sd

create proc checkEmp 
as
	declare @num int
	select  @num=count(emp.empNo) from emp join works_on w on emp.empNo = w.empNo join proj on proj.projNum = w.projNum where proj.projNum = 1
	if (@num <= 3)
		begin
		select 'The number of employees in the project p1 is 3 or more'
		end
	else 
		begin
		select 'The following employees work for the project p1'

		select CONCAT_WS(' ',emp.empFname , Emp.empLname ) as Full_Name 
		from emp join works_on w on emp.empNo = w.empNo join proj on proj.projNum = w.projNum where proj.projNum = 1
		end


exec checkEmp

--3
create proc updateEmp @oldId int, @newId int , @pnum int
as
	begin 
		begin try 
			update
			works_on set empNo = @newId 
			output inserted.*
			where empNo = @oldId and projNum = @pnum

		end try
		begin catch
			select 'error' , ERROR_MESSAGE() , ERROR_LINE()
		end catch
	end

exec updateEmp 9031 , 2581 , 1


--4
CREATE TABLE Project_Audit
(
    ProjectNo     INT,
    UserName      VARCHAR(50),
    ModifiedDate  DATE,
    Budget_Old    INT,
    Budget_New    INT
);

go

create trigger t1 
on [Company].[project]
after update
as
	begin 
		if (UPDATE(budget))
		begin
			declare @old int, @new int, @id int
			select @old=deleted.budget from deleted
			select @new=inserted.budget ,@id=inserted.projNum from inserted 
			insert into Project_Audit values (@id , SUSER_NAME(), GETDATE(),@old , @new)
		end
	end

select * from Project_Audit
		


go
--5
create trigger t2 
on [Company].[department]
instead of insert 
as
	begin
	select 'you cant insert'
	end

insert into [Company].[department] values (5 , 'Mansy' , 'NY')


go
--6
create trigger t3
on [HumanResource].[employee]
instead of insert 
as
	begin
	if MONTH(GETDATE()) = 3
		begin
			select 'Insertion is not allowed in March';
		end
		 else
		begin
			insert into [HumanResource].[employee]
			select * from inserted;
		end
	end	




use ITI
--7
CREATE TABLE Student_Audit
(
    ServerUserName VARCHAR(50),
    AuditDate      DATETIME,
    Note           VARCHAR(200)
);

go

alter trigger t4
on student
after insert
as
begin
	declare @id int;
	select @id=i.St_Id from inserted i
    insert into Student_Audit 
	select 
        suser_name(),
        getdate(),
        concat(suser_name(), ' insert new row with key=', i.st_id, ' in table student')
    from inserted i
	end;

--8
create trigger t5
on student
instead of delete
as
begin
    insert into student_audit (serverusername, auditdate, note)
    select 
        suser_name(),
        getdate(),
        concat('try to delete row with key=', d.st_id)
    from deleted d;
end;
