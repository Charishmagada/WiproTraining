use sqlpractice
Go

--to display list of tables availbale in database(sqlpractice)
select * from INFORMATION_SCHEMA.TABLES
go

--to display info abot emp table
sp_help emp
go

sp_help agent
go

--to display all records in particular table
select * from emp

--some basic queries
select empno,nam,basic from emp

select nam,basic from emp where basic>50000

select  * from emp where dept='dotnet'

select * from emp where nam='ashish'

--between and(workers for numbers and date only)
select * from emp where basic between 50000 and 90000

select * from emp where basic not between 50000 and 90000

-- in clause-used to check multiple values for particular column

select * from emp where dept in('java','dotnet')

select * from emp where dept not in('java','dotnet')

--like operator
--name starting with s
select *from emp where nam like 's%'

--name ending with a
select * from emp where nam like '%a'
select * from emp where RTRIM(nam) like '%a'

--name contains a anywhere start,end,middle
select * from emp where nam like '%h%'

--distinct eliminates duplicates at the tome of display
select dept from emp
select distinct dept from emp

--order by by default ascending order
select * from emp order by nam
select * from emp order by nam desc

select * from emp order by basic
select * from emp order by basic desc

--in order by we can have multiple values too,if first one is same in 2 cases it checks wrt 2nd one
select *  from emp order by dept,nam
select * from emp order by dept,nam desc -- here dept is ascending order only nam in descending order
select * from emp order by dept desc,nam desc --both dept and nam descending
