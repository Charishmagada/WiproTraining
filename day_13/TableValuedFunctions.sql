--table valued functions
--example1
select * from employee
go

create function EmpTabEx() returns @EmpTable table
(
empno int,name varchar(20),basic numeric(9,2)
)
as
begin
	insert into @EmpTable
		select empno,name,basic from employee
		return
end
go

select * from dbo.EmpTabEx()
--example2
select * from leavehistory
go

Create Function FnEmpLeaveHistory() RETURNS @EmpLeave TABLE
(
	Empno INT, Name varchar(30), Basic numeric(9,2), leaveId INT,
		LeaveStartDate Date, LeaveEndDate Date, Lop INT
)
as
begin
	insert into @EmpLeave
	select E.Empno, Name, Basic, LeaveId, LeaveStartDate, LeaveEndDate, LossOfPay
	from Employee E INNER JOIN LeaveHistory LH ON E.Empno = LH.EmpNo
	return
end
go

select * from dbo.FnEmpLeaveHistory()
	