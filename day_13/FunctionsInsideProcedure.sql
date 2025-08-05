--we can use functions inside a stored procedure but not vice-versa
--Examples
create proc prcShowPaySlip
@empno INT
AS
BEGIN
	declare
		@name varchar(30),
		@basic numeric(9,2),
		@tax numeric(9,2),
		@takehome numeric(9,2)
	BEGIN
	if exists(select * from Employee where empno = @empno)
	BEGIN
		select @name=name, @basic = Basic, @tax = dbo.Fncommission(basic),
			@takehome = Basic - dbo.Fncommission(basic)
			from Employee WHERE Empno =@empno
		Print 'Hi Mr/Miss/Mrs ' +@name
		Print 'Your Salary is ' +convert(varchar,@basic) 
		Print 'Your Tax to be Paid ' +convert(varchar,@tax) 
		Print 'Your Takehome is ' +convert(varchar,@takehome)
	END
	ELSE
	BEGIN
		Print 'Employee Record Not Found'
	END
	END
END
GO

EXEC prcShowPaySlip 10
GO


create proc prcPolicyInfo
@policyId INT
AS
BEGIN
	Declare
		@appNumber varchar(30),
		@annualPremium numeric(9,2),
		@paymode varchar(30) 
	BEGIN
		if exists(select * from Policy WHERE PolicyId = @policyId)
		BEGIN
		select	@appNumber = AppNumber, @annualPremium = AnnualPremium, 
			@paymode = dbo.fnPaymode(paymentModeId)
			from Policy WHERE PolicyId = @policyId
		Print 'Application Number ' +@appNumber 
		Print 'AnnualPremium ' +convert(varchar,@annualpremium)
		Print 'Paymode ' +@paymode
		END
		ELSE
		BEGIN
			Print 'Policy Id Not Found...'
		END
	END
END

Exec prcPolicyInfo 2
GO
