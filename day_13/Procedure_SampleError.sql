create proc prcDivision
	@a int,
	@b int
as
begin
	begin try
		set @b=@a/0;
		print @b;
	end try
	begin catch
		print 'Error is :';
		print ERROR_MESSAGE();
	end catch
end
go

exec prcDivision 12,0

---
if exists(select * from sysobjects where name='prcEvenOdd')
drop proc prcEvenOdd
go

create proc prcEvenOdd
@n int
as
begin
	declare
		@res int
	begin try 
		set @res=@n%2;
		if(@res=0)
			print 'even number'
		else
		begin
			print 'error occured'
			print 'odd number'
		end
	end try
	 begin catch
		print Error_message()
		end catch
end
prcEvenOdd 2
prcEvenOdd 5
