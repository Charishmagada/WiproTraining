--------------------------joins
---inner join
use wiprojuly

select * from employee
select * from leavehistory

select employee.empno,name,dept,basic,
leavehistory.leaveid,leavestartdate,leaveenddate
from employee inner join leavehistory
on employee.empno=leavehistory.empno

-- we can also give alias name
select e.empno,name,dept,basic,
lh.leaveid,leavestartdate,leaveenddate
from employee e inner join leavehistory lh
on e.empno=lh.empno

select * from agent
select * from agentpolicy
select * from policy

select a.agentid,firstname,lastname,city,state,
p.policyid,appnumber,modalpremium,annualpremium,paymentmodeid
from agent a inner join agentpolicy ap on
a.agentid=ap.agentid
inner join policy p on p.policyid=ap.policyid

--left outer join
select e.empno,name,dept,basic,
lh.leaveid,leavestartdate,leaveenddate
from employee e left join leavehistory lh
on e.empno=lh.empno

select a.agentid,firstname,lastname,city,state,
p.policyid,appnumber,modalpremium,annualpremium,paymentmodeid
from agent a left join agentpolicy ap on
a.agentid=ap.agentid
left join policy p on p.policyid=ap.policyid

--right outer join
select e.empno,name,dept,basic,
lh.leaveid,leavestartdate,leaveenddate
from employee e right join leavehistory lh
on e.empno=lh.empno

select a.agentid,firstname,lastname,city,state,
p.policyid,appnumber,modalpremium,annualpremium,paymentmodeid
from agent a right join agentpolicy ap
on a.agentid=ap.agentid
right join policy p on p.policyid=ap.policyid

--full outer join
select e.empno,name,dept,basic,
lh.leaveid,leavestartdate,leaveenddate
from employee e full join leavehistory lh
on e.empno=lh.empno

select a.agentid,firstname,lastname,city,state,
p.policyid,appnumber,modalpremium,annualpremium,paymentmodeid
from agent a full join agentpolicy ap
on a.agentid=ap.agentid
full join policy p on p.policyid=ap.policyid

--cross join
select * from employee cross join leavehistory

select * from agent cross join agentpolicy

select * from agent cross join policy