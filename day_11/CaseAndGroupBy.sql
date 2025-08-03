--case

sp_help agent
go

select * from agent

-- usage example for case
--write a query to ensure,if maritalstatus is 0 then 'unmarried' if maritalstatus is 1 then married

select AgentId,firstname,lastname,city,maritalstatus,
case maritalstatus
     when 0 then 'unmarried'
	 when 1 then 'married'
end maritalstatus
from agent

select * from policy

select * ,
case PayMentModelID
	when 1 then 'yearly'
	when 2 then 'halfyearly'
end paymentmodelid
from policy

--group by

select dept,sum(basic) from emp group by dept

select gender,count(*) from agent group by gender

select dept,avg(basic) from emp group by dept

select dept,sum(basic) 'Total',avg(basic) 'Average',max(basic) 'Maximum',min(basic) 'Minimum',count(*) 'Total Records' from emp
group by dept

-- having clause

select dept, sum(basic) 'Total',avg(basic) 'Average',max(basic) 'Max Basic', min(basic) 'Min Basic', count(*) 'Total Records' from emp 
group by Dept having count(*) > 1;

select dept, sum(basic) from Emp group by dept 
having sum(basic) > 50000

select dept, sum(basic) from Emp group by dept 
having sum(basic) < 50000