--1
create function Name(@dt date)
returns varchar(30)
as
	begin
		declare @month varchar(30);
			select @month= DATENAME(MONTH , @dt);
			return @month;
	end




select dbo.Name('2005-1-20')

--2
create function inRange(@x int , @y int)
returns @t table (
		between_them int
)
as
begin
	declare @i int = @x+1
	while @i < @y
		begin 
			insert into @t values (@i)
			set @i = @i + 1
		end
	return
end


select * from inRange(9,40)




-- 3 Create inline function that takes Student No and returns Department Name with Student full name
create function namess(@id int) returns table as
		return ( select CONCAT_WS(' ', s.St_Fname , s.St_Lname) as FullName, 
		d.Dept_Name as DepartmentName from Student s join Department d
		on s.Dept_Id = d.Dept_Id where s.St_Id = @id )

select * from namess(5)


--4.	Create a scalar function that takes Student ID and returns a message to user 
--a.	If first name and Last name are null then display 'First name & last name are null'
--b.	If First name is null then display 'first name is null'
--c.	If Last name is null then display 'last name is null'
--d.	Else display 'First name & last name are not null'

create function nameNull(@id int) returns varchar(88) as
		begin
			declare @fname varchar(50), @lname varchar(50) , @msg varchar(100);
			select @fname = s.St_Fname , @lname = s.St_Lname from Student s where s.St_Id = @id

			if @fname is null and @lname is null 
				set @msg = 'First name & last name are null'
			else if @fname is null 
				set @msg = 'first name is null'
			else if @lname is null
				set @msg = 'last name is null'
			else 
				set @msg = 'First name & last name are not null'

			return @msg;
		end


select dbo.nameNull(5)


--5
create function ManagerInfo(@id int)
returns table
as
return
(
    select d.Dept_Name , s.Ins_Name , d.Manager_hiredate 
	from Department d join Instructor s on d.Dept_Manager = s.Ins_Id where d.Dept_Manager = @id
);


select * from dbo.ManagerInfo(5)


--6
create function studentnames(@type varchar(20))
returns @t table
(
    studentname varchar(200)
)
as
begin
    if @type = 'first name'
    begin
        insert into @t
        select isnull(st_fname, 'NULL')
        from student;
    end
    else if @type = 'last name'
    begin
        insert into @t
        select isnull(st_lname, 'NULL')
        from student;
    end
    else if @type = 'full name'
    begin
        insert into @t
        select isnull(concat(st_fname, ' ', st_lname), 'NULL')
        from student;
    end

    return;
end;


select * from StudentNames('first name')
select * from StudentNames('last name')
select * from StudentNames('full name')


--7
select St_Id as StudentNo, substring(St_Fname, 1, len(St_Fname) - 1) as FirstNameWithoutLastChar from Student;


--8
delete sc from Stud_Course sc join Student s on s.St_Id = sc.St_Id 
join Department d on s.Dept_Id = d.Dept_Id where d.Dept_Name = 'SD' 


--10
declare @i int = 3000;
while @i <= 5999
begin
    insert into Student (St_Id, St_Fname, St_Lname)
    values (@i, 'Jane', 'Smith');
    set @i = @i + 1;
end;

select * from Student


-- بنحول الداتا لشكل هرمي زي مين رئيس الشركه ومين الموظفين اللي تحتيه وهكذا
-- getroot() , GetDescendant() , OrgNode.ToString()
