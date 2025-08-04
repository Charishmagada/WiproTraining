----sub queries

select * from employee

-- max salary
select name,basic from employee where basic=(select max(basic) from employee) 

--2nd max salary
select max(basic) from employee where basic<(select max(basic) from employee)

select name from employee where basic=(select max(basic) from employee where basic<(select max(basic) from employee))

select * from agent

select PolicyId, AppNumber, ModalPremium, AnnualPremium,
ROW_NUMBER() OVER(Order By AnnualPremium desc) 'Rno' from Policy

select PolicyId, AppNumber, ModalPremium, AnnualPremium,
RANK() OVER(Order By AnnualPremium desc) 'Rno' from Policy

select PolicyId, AppNumber, ModalPremium, AnnualPremium,
DENSE_RANK() OVER(Order By AnnualPremium desc) 'Rno' from Policy

select * from policy
select max(annualpremium) from policy

select policyid from policy where AnnualPremium=(select max(annualpremium) from policy)
--2nd max annualpremium
select max(annualpremium) from policy where AnnualPremium<(select max(annualpremium) from policy)

--------multi row subquery(all and any)

--diplay matching records from employee and leavehistory
select * from employee where empno=any(select empno from leavehistory)

--display matchrecordingd from agent and agentpolicy table
select * from agent where agentid=any(select agentid from agentpolicy)

--policy and agentpolicy
select * from policy where policyid=any(select agentid from agentpolicy)

--display employee who haven't taken leave(i.e, records in employee but not in leave history)
select * from employee where empno <> all(select empno from leavehistory)

--idle agents(ie exists in agent but not in agent policy)
select * from agent where agentid<> all(select agentid from agentpolicy)

--idlepolicy
select * from policy where policyid <>all(select policyid from agentpolicy)



