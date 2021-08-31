-- Table Access insert new user
declare @user nvarchar(255) = N'KOLBASA-VS\s_weight'  -- KOLBASA-VS\andreev_ia
declare @level bit = 1
if not exists (select 1 from [db_scales].[ACCESS] where [USER]=@user) begin
	insert into [db_scales].[ACCESS] ([USER],[LEVEL]) values (@user,@level)
end else begin
	update [db_scales].[ACCESS] set [LEVEL]=@level where [USER]=@user
end
select * from [db_scales].[ACCESS] where [USER]=@user