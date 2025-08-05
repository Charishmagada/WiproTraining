create table DummyEx
(
   Eno INT,
   Name varchar(30),
   Sal Numeric(9,2)
)
GO
Insert into DummyEx(Eno,Name,Sal) 
		values(12,'Vomesh',82245),
			(7,'Uday',82111),
			(3,'Charishma',89144),
			(18,'Pallavi',81455),
			(15,'Nitin',88155) 
GO

select * from DummyEx 
GO

Create Clustered Index Idx_Empno ON DummyEx(Eno)
GO

-- Drop existing indexes (if they exist)
DROP INDEX IF EXISTS idx_agent ON AgentPolicy;
GO

DROP INDEX IF EXISTS idx_policy ON AgentPolicy;
GO

-- Recreate idx_policy on AgentID
CREATE NONCLUSTERED INDEX idx_policy 
ON AgentPolicy(AgentID);
GO

-- View table contents (optional)
SELECT * FROM AgentPolicy;
GO

-- Recreate idx_agent on PolicyID
CREATE NONCLUSTERED INDEX idx_agent 
ON AgentPolicy(PolicyID);
GO
