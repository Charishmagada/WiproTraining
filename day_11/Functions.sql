--number functions

select abs(-12)
select power(2,3) -- 8
select sqrt(49)
select CEILING(12.00001)--13(returns greatest integer value)
select floor(12.999999)--12(return smallest integer value)
select ceiling(12.99999)--13
select floor(12.0000001)--12

--string functions

select charindex('l','hello') --first occurence of given character
select nam ,charindex('a',nam) from emp

select reverse('charishma')
select nam,reverse(nam) from emp

select len('charishma gada')

select nam,len(nam) from emp

select left('charishma',5)

select right('charishma',5)

select nam,upper(nam) from emp

select nam,lower(nam) from emp

select substring('welcome to sql',5,8) --first number start from that particular index,second number indicates number of characters needed from that index.

select replace('dotnet training','dotnet','java') --replaces dotnet with java


--date functions
--get date()-used to display todays date

select getdate()

select convert(varchar,GETDATE(),1) --mm-dd-yy
select convert(varchar,GETDATE(),2) --yy-mm-dd
select convert(varchar,GETDATE(),101) 

/* | Style   | Format (Output) | Description              |
| ------- | --------------- | ------------------------ |
| **1**   | `mm/dd/yy`      | U.S. short date          |
| **2**   | `yy.mm.dd`      | ANSI standard            |
| **3**   | `dd/mm/yy`      | British/French style     |
| **10**  | `mm-dd-yy`      | USA with hyphen          |
| **101** | `mm/dd/yyyy`    | U.S. full year           |
| **103** | `dd/mm/yyyy`    | British/French full year |
| **105** | `dd-mm-yyyy`    | Italian                  |
| **110** | `mm-dd-yyyy`    | USA alternate            |
| **111** | `yyyy/mm/dd`    | Japan ISO-style          |*/


-- DatePart() : used to display the specific portion of the given date 

select datepart(dd,getdate())
select datepart(mm,getdate())
select datepart(yy,getdate())
select datepart(hh,getdate()) --hour
select datepart(mi,getdate()) --minute
select datepart(ss,getdate()) --second
select datepart(ms,getdate()) --millisecond
select datepart(dw,getdate()) --day of the week.sun-0,mon-1,...sat-6
select datepart(qq,getdate()) --quarter of the year(1-4) aug-3


-- DateName() :Displays date part in english words 

select datename(dw,getdate())
select datename(mm, getdate())
select datename(yy,getdate())

select convert(varchar,DATEPART(dd,getdate())) + '/' + 
convert(varchar,datepart(mm,getdate())) + '/' + 
convert(varchar,DATEPART(yy,getdate()))

--dateadd() :used to add no. of days or months or year to the particular date

select dateadd(dd,3,getdate())
select dateadd(mm,3,getdate())
select dateadd(yy,3,getdate())

--datediff() : used to Display difference between Two Dates 

select DATEDIFF(dd,'03/08/2024',getdate())
select DATEDIFF(yy,'03/08/2024',getdate())

--aggregate functions

select sum(basic) from emp
select avg(basic) from emp
select max(basic) from emp
select min(basic) from emp
select count(basic) from emp











