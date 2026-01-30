--1
declare c1 cursor
for select salary from Employee
for update
declare @sal int
open c1
fetch c1 into @sal
while @@FETCH_STATUS=0
	begin
		if @sal < 3000
		update Employee set salary = salary * 1.2  
		where current of c1;
		else if @sal>=3000
			update Employee
				set Salary=@sal*1.10
			where current of c1;
	fetch c1 into @sal
	end
close c1;
deallocate c1;


--2
declare c2 cursor
for select d.Dept_Name , i.Ins_Name from Department d join Instructor i on d.Dept_Manager = i.Ins_Id
for read only
declare @iName varchar(20) , @dName varchar(20)
open c2 
fetch c2 into @iName , @dName
while @@FETCH_STATUS=0
	begin
		select @iName as Ins_Name , @dName as Dept_Name 
		fetch c2 into @iName , @dName
	end	
close c2
deallocate c2



--3
declare c3 cursor
for select distinct st_fname from Student where st_fname is not null
for read only
declare @name varchar(20),@all_names varchar(300)=''
open c3
fetch c3 into @name
while @@FETCH_STATUS=0
	begin
		set @all_names=concat(@all_names,',',@name)
		fetch c3 into @name
	end
select @all_names
close c3
deallocate c3


go
--4
create proc GetMonthName2 @dt date
as
begin
    SELECT DATENAME(MONTH, @dt) AS Month_Name;
end

go

create proc inrange2
    @x int,
    @y int
as
begin
    declare @i int = @x + 1;

    declare @t table (
        between_them int
    );

    while @i < @y
    begin
        insert into @t values (@i);
        set @i = @i + 1;
    end

    select * from @t;
end


exec inrange2 9,40



go

create proc namess2
    @id int
as
begin
    select 
        concat_ws(' ', s.st_fname, s.st_lname) as fullname,
        d.dept_name as departmentname
    from student s
    join department d
        on s.dept_id = d.dept_id
    where s.st_id = @id;
end

exec namess2 5;


go

create proc namenull2
    @id int
as
begin
    declare @fname varchar(50),
            @lname varchar(50),
            @msg varchar(100);

    select 
        @fname = s.st_fname,
        @lname = s.st_lname
    from student s
    where s.st_id = @id;

    if @fname is null and @lname is null
        set @msg = 'first name & last name are null';
    else if @fname is null
        set @msg = 'first name is null';
    else if @lname is null
        set @msg = 'last name is null';
    else
        set @msg = 'first name & last name are not null';

    select @msg as result_message;
end

exec namenull2 5;

go

create proc managerinfo2
    @id int
as
begin
    select 
        d.dept_name,
        s.ins_name,
        d.manager_hiredate
    from department d
    join instructor s
        on d.dept_manager = s.ins_id
    where d.dept_manager = @id;
end

exec managerinfo2 5;


go

create proc studentnames2
    @type varchar(20)
as
begin
    if @type = 'first name'
    begin
        select isnull(st_fname, 'null') as studentname
        from student;
    end
    else if @type = 'last name'
    begin
        select isnull(st_lname, 'null') as studentname
        from student;
    end
    else if @type = 'full name'
    begin
        select isnull(concat(st_fname, ' ', st_lname), 'null') as studentname
        from student;
    end
end

exec studentnames2 'first name';
exec studentnames2 'last name';
exec studentnames2 'full name';


--5
create sequence seq_test
    start with 1
    increment by 1
    minvalue 1
    maxvalue 10
    no cycle;



create table test_seq(
    id int default (next value for seq_test),
    name varchar(50)
);


insert into test_seq(name) values ('ahmed');
insert into test_seq(name) values ('mohamed');
insert into test_seq(name) values ('sara');

select * from test_seq;


--6

create database AdvSnap
on
(
 name='AdventureWorks2012_Data',  
 filename='D:\db\snap1.ss'
)
as snapshot of AdventureWorks2012


select * from AdvSnap.Sales.Store


