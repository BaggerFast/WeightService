-- ������� WorkShop
use [ScalesDB]
declare @id int = 0
declare @delete bit = 0
set nocount on
------------------------------------------------------------------------------------------------------------------------
if (@delete = 1) begin
	print N'[-] �������� ��������'
	delete from [db_scales].[WorkShop] where [Id] = @id
end
------------------------------------------------------------------------------------------------------------------------
select * 
from [db_scales].[WorkShop]
order by [Id]
set nocount off