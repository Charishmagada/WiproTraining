drop database wiprojuly --if we run multiple times we can avoid error like databse already created

create database wiprojuly

use wiprojuly
if exists(select * from sysobjects where name='leavehistory')
drop table leavehistory

if exists(select * from sysobjects where name='Employee') 
Drop Table Employee



create table employee(
		empno int constraint pk_employee_empno primary key,
		name varchar(30) not null,
		gender varchar(10)
		constraint chk_emp_gender check(gender in('male','female')),
		dept varchar(20)
		constraint chk_emp_dept check(dept in('dotnet','java','python')),
		desgn varchar(20) not null,
		basic numeric(9,2) 
		constraint chk_emp_basic check(basic between 10000 and 90000)
)

insert into employee(empno,name,gender,dept,desgn,basic)
values(1,'siri','female','java','manager',88000),
(2,'padma','female','dotnet','manager',89000),
(3,'Uday','MALE','Python','Expert',68833),
(4,'Datta','MALE','Dotnet','Manager',88322),
(5,'Mahi','FEMALE','Python','Expert',88223)

select * from employee

create table leavehistory(
		leaveid int identity(1,1) constraint pk_leave_history_leaveid primary key,
		-- leaveid int identity(1,1) indicates auto increment start with one and increment by one
		empno int constraint fk_emp_empno foreign key(empno) references employee(empno),
		leavestartdate date,
		leaveenddate date,
		noofdays int,
		lossofpay numeric(9,2)
)

insert into leavehistory(empno,leavestartdate,leaveenddate)
values(3,'08/02/2025','08/05/2025'),
      (4,'09/03/2025','09/22/2025')

select * from leavehistory