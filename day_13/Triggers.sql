--triggers
create table student
(
	sno int constraint pk_student_sno primary key,
	name varchar(30),
	sub1 int,sub2 int,sub3 int,
	total int,avg float,InsertedOn datetime,
	InsertedBy varchar(1000)
)
go
create trigger trgStudentInsert on student for insert
as
begin
	declare @sno int
	select @sno=sno from inserted 
/*the above 2 stmts(i.e,all sno related at end inserted by where condn too) is used for the concept of magic tables.
without this evry record insertion time will be same.to avoid this we use magic tables.*/
	update student set total=sub1+sub2+sub3,avg=(sub1+sub2+sub3)/3,
	InsertedOn=getdate(),InsertedBy = SYSTEM_USER WHERE SNo = @sno;
end
go

truncate table student

Insert INTO Student(Sno,Name,Sub1,Sub2,sub3) Values(1,'Venkata',87,74,91) 
GO

Insert into Student(Sno,Name,Sub1,SUb2,Sub3) values(2,'Rajesh',87,82,91) 
GO

Insert into Student(sno,name,sub1,sub2,sub3) values(3,'Uday',88,77,82) 
GO

select * from student;