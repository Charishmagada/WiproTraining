SELECT TOP (1000) [leaveid]
      ,[empno]
      ,[leavestartdate]
      ,[leaveenddate]
      ,[noofdays]
      ,[lossofpay]
  FROM [wiprojuly].[dbo].[leavehistory]

--update
  update leavehistory set noofdays=datediff(dd,leavestartdate,leaveenddate)
  
  select * from leavehistory
--alter
  create table employeedummy
  (
		eno int,
		name int,
		basic int
	)

--  set eno to pk
alter table employeedummy alter column  eno int not null
alter table employeedummy add primary key(eno)

--change name field to varchar(30)
alter table employeedummy alter column name varchar(30)

--change base field to numeric(9,2)
alter table employeedummy alter column basic numeric(9,2)

sp_help employeedummy

--to add new column
alter table employeedummy add  gender varchar(10)
alter table employeedummy drop column gender 

