﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace BlazorCore.Utils
{
    public static class SqlQueries
    {
        public static string GetAccess => @"
-- Table Access diagram summary
select
	 [UID]
	,[CREATE_DT]
	,[CHANGE_DT]
	,[USER]
	,[LEVEL]
from [db_scales].[ACCESS]
order by [USER] desc
        ".TrimStart('\r', ' ', '\n').TrimEnd('\r', ' ', '\n');
        
        public static string GetAccessUser(string userName) => @$"
select
	 [UID]
	,[CREATE_DT]
	,[CHANGE_DT]
	,[USER]
	,[LEVEL]
from [db_scales].[ACCESS]
where [USER]=N'{userName}'
        ".TrimStart('\r', ' ', '\n').TrimEnd('\r', ' ', '\n');
        
        public static string GetLogTypes => @"
-- Table LOG_TYPES
select 
	 [UID]
	,[NUMBER]
	,[ICON]
from [db_scales].[LOG_TYPES]
order by [NUMBER]
            ".TrimStart('\r', ' ', '\n').TrimEnd('\r', ' ', '\n');
        
        public static string GetLogs => @"
-- Table LOGS diagram summary
select 
	 [l].[UID]
	,[l].[CREATE_DT]
	,[s].[Description] [SCALE]
	,[h].[Name] [HOST]
	,[a].[NAME] [APP]
	,[l].[VERSION]
	,[l].[FILE]
	,[l].[LINE]
	,[l].[MEMBER]
	,[lt].[ICON]
	,[l].[MESSAGE]
from [db_scales].[LOGS] [l]
left join [db_scales].[Hosts] [h] on [h].[ID]=[l].[HOST_ID]
left join [db_scales].[Scales] [s] on [s].[HostId]=[h].[ID]
left join [db_scales].[APPS] [a] on [a].[UID]=[l].[APP_UID]
left join [db_scales].[LOG_TYPES] [lt] on [lt].[UID]=[l].[LOG_TYPE_UID]
order by [l].[CREATE_DT] desc
            ".TrimStart('\r', ' ', '\n').TrimEnd('\r', ' ', '\n');
        
        public static string GetWeithingFacts => @"
-- Table WeithingFact diagram summary
select
	 cast([wf].[WeithingDate] as date) [WeithingDate]
	,count(*) [Count]
	,[s].[Description] [Scale]
	,[h].[Name] [Host]
	,[p].[Name] [Printer]
from [db_scales].[WeithingFact] [wf]
left join [db_scales].[Scales] [s] on [wf].[ScaleId] = [s].[Id]
left join [db_scales].[Hosts] [h] on [s].[HostId] = [h].[Id]
left join [db_scales].[ZebraPrinter] [p] on [s].[ZebraPrinterId] = [p].[Id]
group by cast([WeithingDate] as date), [s].[Description], [h].[Name], [p].[Name]
order by [WeithingDate] desc
            ".TrimStart('\r', ' ', '\n').TrimEnd('\r', ' ', '\n');

        public static string GetBusyHosts => @"
-- Get busy hosts
select [h].[Id]
      ,[h].[CreateDate]
      ,[h].[ModifiedDate]
      ,[h].[Name]
      ,[s].[Description]
      ,[h].[IP]
      ,[h].[MAC]
      ,[h].[IdRRef]
      ,[h].[Marked]
      ,[h].[SettingsFile]
from [db_scales].[Hosts] [h]
left join [db_scales].[Scales] [s] on [h].[Id] = [s].[HostId]
where [h].[Id] in (select [HostId] from [db_scales].[Scales] where [Scales].[HostId] is not null and [s].[Marked] = 0) and [h].[Marked] = 0
order by [h].[Name]
            ".TrimStart('\r', ' ', '\n').TrimEnd('\r', ' ', '\n');

        public static string GetFreeHosts => @"
-- Get free hosts
select [h].[Id]
      ,[h].[CreateDate]
      ,[h].[ModifiedDate]
      ,[h].[Name]
      ,[h].[IP]
      ,[h].[MAC]
      ,[h].[IdRRef]
      ,[h].[Marked]
      ,[h].[SettingsFile]
from [db_scales].[Hosts] [h]
where [h].[Id] not in (select [HostId] from [db_scales].[Scales] [s] where [s].[HostId] is not null and [s].[Marked] = 0) and [h].[Marked] = 0
order by [h].[Name]
            ".TrimStart('\r', ' ', '\n').TrimEnd('\r', ' ', '\n');
    }
}