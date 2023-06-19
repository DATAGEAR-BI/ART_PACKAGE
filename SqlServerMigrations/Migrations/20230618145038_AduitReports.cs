using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class AduitReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // VIEWS
            /*                VIEW ART_GROUPS_AUDIT_VIEW  */
            migrationBuilder.Sql($@"
                            USE [ART_DB]
                            GO
                            SET ANSI_NULLS ON
                            GO
                            SET QUOTED_IDENTIFIER ON
                            GO
                            CREATE OR ALTER view [ART_DB].[ART_GROUPS_AUDIT_VIEW] as 
                            with ST1 AS
(SELECT g.*,g2.name sub_group_name ,r.name role_name ,u.name member_user
  FROM [DGUSERMANAGMENT].[DGMGMT_AUDIT].[group_dg_aud] g
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[user_group_dg_aud] ug
  on g.id = ug.group_id and g.rev = ug.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[user_dg_aud] u 
  on u.id = ug.user_id and ug.rev = u.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[sub_group_aud] sg
  on g.id = sg.group_id and g.rev = sg.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[group_dg_aud] g2
  on g2.id = sg.sub_group_id and g2.rev = sg.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[group_role_dg_aud] gr
  on g.id = gr.group_id and g.rev = gr.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[role_dg_aud] r
  on r.id = gr.role_id and r.rev = gr.rev
  --where g.id = 1093
  --order by g.last_updated_date desc
  )

  select 
  ST4.name group_name, 
  (CASE WHEN ST4.revtype = 0 THEN 'Add' when ST4.revtype = 1 then 'Update' when ST4.revtype = 2 then 'Delete' end) action,
  ST4.description, ST4.display_name, ST4.created_by, cast(ST4.created_date as datetime) created_date,
  ST4.last_updated_by, cast(ST4.last_updated_date as datetime) last_updated_date, ST4.sub_group_names, ST4.role_names, ST4.member_users
  from
  (select distinct ST2.id, ST2.rev, ST2.revtype, ST2.name, ST2.description, ST2.display_name, ST2.created_by, ST2.created_date,
  ST2.last_updated_by, ST2.last_updated_date,
  SUBSTRING(
        (
            SELECT ','+ST3.sub_group_name  AS [text()]
            FROM 
			(SELECT DISTINCT ST1.sub_group_name
			FROM ST1 
            WHERE ST1.rev = ST2.rev) ST3
            FOR XML PATH (''), TYPE
         ).value('text()[1]','nvarchar(max)'), 2, 1000) [sub_group_names],
		 SUBSTRING(
        (
            SELECT ','+ST3.role_name  AS [text()]
            FROM  
            (SELECT DISTINCT ST1.role_name
			FROM ST1 
            WHERE ST1.REV = ST2.REV) ST3
            FOR XML PATH (''), TYPE
        ).value('text()[1]','nvarchar(max)'), 2, 1000) [role_names],
		SUBSTRING(
        (
            SELECT ','+ST3.member_user  AS [text()]
            FROM  
            (SELECT DISTINCT ST1.member_user
			FROM ST1 
            WHERE ST1.REV = ST2.REV) ST3
            FOR XML PATH (''), TYPE
        ).value('text()[1]','nvarchar(max)'), 2, 1000) [member_users]
  from ST1 as ST2) ST4
  order by ST4.id, ST4.last_updated_date desc
  offset 0 rows;
 


GO");
            /*                VIEW ART_ROLES_AUDIT_VIEW   */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/****** Script for SelectTopNRows command from SSMS  ******/
CREATE OR ALTER view [ART_DB].[ART_ROLES_AUDIT_VIEW] as 
with ST1 AS
(SELECT r.*,g.name group_name,u.name member_user
  FROM [DGUSERMANAGMENT].[DGMGMT_AUDIT].[role_dg_aud] r
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[user_role_dg_aud] ur
  on r.id = ur.role_id and r.rev = ur.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[user_dg_aud] u 
  on u.id = ur.user_id and ur.rev = u.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[group_role_dg_aud] gr
  on r.id = gr.role_id and r.rev = gr.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[group_dg_aud] g
  on g.id = gr.group_id and g.rev = gr.rev
  --where r.id = 316
  --order by r.last_updated_date desc
  )

  select 
  ST4.name role_name, 
  (CASE WHEN ST4.revtype = 0 THEN 'Add' when ST4.revtype = 1 then 'Update' when ST4.revtype = 2 then 'Delete' end) action,
  ST4.description, ST4.display_name, ST4.created_by, cast(ST4.created_date as datetime) created_date,
  ST4.last_updated_by, cast(ST4.last_updated_date as datetime) last_updated_date, ST4.group_names, ST4.member_users
  from
  (select distinct ST2.id, ST2.rev, ST2.revtype, ST2.name, ST2.description, ST2.display_name, ST2.created_by, ST2.created_date,
  ST2.last_updated_by, ST2.last_updated_date,
  SUBSTRING(
        (
            SELECT ','+ST3.group_name  AS [text()]
            FROM 
			(SELECT DISTINCT ST1.group_name
			FROM ST1 
            WHERE ST1.rev = ST2.rev) ST3
            FOR XML PATH (''), TYPE
         ).value('text()[1]','nvarchar(max)'), 2, 1000) [group_names],
		SUBSTRING(
        (
            SELECT ','+ST3.member_user  AS [text()]
            FROM  
            (SELECT DISTINCT ST1.member_user
			FROM ST1 
            WHERE ST1.REV = ST2.REV) ST3
            FOR XML PATH (''), TYPE
        ).value('text()[1]','nvarchar(max)'), 2, 1000) [member_users]
  from ST1 as ST2) ST4
  order by ST4.id, ST4.last_updated_date desc
  offset 0 rows;
 


GO");
            /*                VIEW  ART_USERS_AUDIT_VIEW  */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER view [ART_DB].[ART_USERS_AUDIT_VIEW] as 
WITH ST1 AS 
(SELECT  u.id , u.rev, u.revtype, u.name , u.address, U.description, U.display_name, u.email, u.phone, u.status,
U.created_by, u.created_date, U.last_updated_by,  u.last_updated_date, U.last_login_date, U.last_failed_login, u.enable,
g.name group_name, r.name role_name, ad.authentication_domain domain_account
  FROM [DGUSERMANAGMENT].[DGMGMT_AUDIT].[user_dg_aud] u 
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[user_group_dg_aud] ug
  on u.id = ug.user_id and u.rev = ug.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[group_dg_aud] g
  on g.id = ug.group_id and g.REV = ug.REV 
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[user_role_dg_aud] ur
  on u.id = ur.user_id and u.rev = ur.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[role_dg_aud] r
  on r.id = ur.role_id and r.rev = ur.rev
  left join [DGUSERMANAGMENT].[DGMGMT_AUDIT].[account_aud] ad 
  on u.id = ad.user_id and u.REV = ad.REV
  --where u.id = 1050
  --order by u.last_updated_date desc
  ) 

  select 
  ST4.name user_name, 
  (CASE WHEN ST4.revtype = 0 THEN 'Add' when ST4.revtype = 1 then 'Update' when ST4.revtype = 2 then 'Delete' end) action,
  ST4.address, ST4.description, ST4.display_name, ST4.email, ST4.phone, ST4.status,
   ST4.created_by, cast(ST4.created_date as datetime) created_date, ST4.last_updated_by,  cast(ST4.last_updated_date as datetime) last_updated_date, 
   cast(ST4.last_login_date as datetime) last_login_date, cast(ST4.last_failed_login as datetime) last_failed_login, ST4.enable,
   ST4.group_names, ST4.role_names, ST4.domain_accounts
  from
  (select distinct
   ST2.id , ST2.rev, ST2.revtype, ST2.name , ST2.address, ST2.description, ST2.display_name, ST2.email, ST2.phone, ST2.status,
   ST2.created_by, ST2.created_date, ST2.last_updated_by,  ST2.last_updated_date, ST2.last_login_date, ST2.last_failed_login, ST2.enable,
   SUBSTRING(
        (
            SELECT ','+ST3.group_name  AS [text()]
            FROM 
			(SELECT DISTINCT ST1.group_name
			FROM ST1 
            WHERE ST1.rev = ST2.rev) ST3
            FOR XML PATH (''), TYPE
         ).value('text()[1]','nvarchar(max)'), 2, 1000) [group_names],
    SUBSTRING(
        (
            SELECT ','+ST3.role_name  AS [text()]
            FROM  
            (SELECT DISTINCT ST1.role_name
			FROM ST1 
            WHERE ST1.REV = ST2.REV) ST3
            FOR XML PATH (''), TYPE
        ).value('text()[1]','nvarchar(max)'), 2, 1000) [role_names],
	SUBSTRING(
        (
            SELECT ','+ST3.domain_account  AS [text()]
            FROM  
            (SELECT DISTINCT ST1.domain_account
			FROM ST1 
            WHERE ST1.REV = ST2.REV) ST3
            FOR XML PATH (''), TYPE
        ).value('text()[1]','nvarchar(max)'), 2, 1000) [domain_accounts]
  from ST1 as ST2) ST4
  order by ST4.id, ST4.last_updated_date desc
  offset 0 rows;
 
  
GO");
            /*                VIEW  LAST_LOGIN_PER_DAY_VIEW */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE OR ALTER view [ART_DB].[LAST_LOGIN_PER_DAY_VIEW]  AS 
  select ""USER_NAME"",
      ""APP_NAME"",
      [DEVICE_NAME],
      [DEVICE_TYPE], 
	  [IP],
      [LOCATION],
	  LOGINDATETIME  from 
  (select ""USER_NAME"",
      ""APP_NAME"",
      [DEVICE_NAME],
      [DEVICE_TYPE], 
	  [IP],
      [LOCATION],
	  create_date LOGINDATETIME ,
	  row_number() over (PARTITION by user_name, cast(create_date as date) order by create_date desc) rn
  from [DGUSERMANAGMENT].[DGMGMT].[logged_user] ) as  aa
  where aa.rn = 1
  ;
GO");
            /*                VIEW  LIST_GROUPS_ROLES_SUMMARY*/
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE OR ALTER view [ART_DB].[LIST_GROUPS_ROLES_SUMMARY] AS
select distinct g.name GROUP_NAME , 
(Case when r.name is null then 'No Role' else r.name end) AS  ROLE_NAME
FROM [DGUSERMANAGMENT].[DGMGMT].[group_dg] g
left join [DGUSERMANAGMENT].[DGMGMT].[group_role_dg] gr
on gr.group_id = g.id
left join [DGUSERMANAGMENT].[DGMGMT].[role_dg] r
on r.id = gr.role_id;
GO");
            /*                VIEW  LIST_GROUPS_SUB_GROUPS_SUMMARY*/
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER view [ART_DB].[LIST_GROUPS_SUB_GROUPS_SUMMARY] AS
select  g.name GROUP_NAME , 
g2.name SUB_GROUP_NAME
FROM [DGUSERMANAGMENT].[DGMGMT].[group_dg] g
left join [DGUSERMANAGMENT].[DGMGMT].[sub_group] sg
on sg.group_id = g.id
left join [DGUSERMANAGMENT].[DGMGMT].[group_dg] g2
on sg.sub_group_id = g2.id;
GO");
            /*                 VIEW LIST_OF_DELTED_USERS       */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER view [ART_DB].[LIST_OF_DELTED_USERS] as
select ua.name USER_NAME
      ,[address]
      ,[description]
      ,[display_name]
      ,[email]
      ,[phone]
      ,[user_type]
      ,[created_by]
      ,cast([created_date] as datetime) created_date
      ,[last_login_date]
      ,[last_failed_login]
	  from [DGUSERMANAGMENT].[DGMGMT_AUDIT].[user_dg_aud] ua where revtype = 0
and ua.id not in(
select u.id  from [DGUSERMANAGMENT].[DGMGMT].[user_dg] u)
GO");
            /*                 VIEW LIST_OF_GROUPS            */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER view [ART_DB].[LIST_OF_GROUPS] as
select g.name group_name, g.description, g.group_type, g.display_name, g.created_by, cast(g.created_date as datetime) created_date,
  g.last_updated_by, cast(g.last_updated_date as datetime) last_updated_date
  FROM [DGUSERMANAGMENT].[DGMGMT].[group_dg] g;
GO");
            /*                 VIEW LIST_OF_ROLES            */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER view [ART_DB].[LIST_OF_ROLES] as
select 
name role_name, 
description, display_name,
role_type,
cast(created_date as datetime) created_date, 
created_by , last_updated_by, cast(last_updated_date as datetime) last_updated_date
FROM [DGUSERMANAGMENT].[DGMGMT].[role_dg];
GO");
            /*                 VIEW LIST_OF_USERS            */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER view [ART_DB].[LIST_OF_USERS] as 
select u.name user_name, u.address, u.description, u.display_name, u.email, u.phone, u.user_type,
   u.created_by, cast(u.created_date as datetime) created_date, u.last_updated_by, cast(u.last_updated_date as datetime) last_updated_date, 
   cast(u.last_login_date as datetime) last_login_date, cast(u.last_failed_login as datetime) last_failed_login,
   u.counter_lock, u.active, u.enable
   FROM [DGUSERMANAGMENT].[DGMGMT].[user_dg] u ;
GO");
            /*                 VIEW LIST_OF_USERS_AND_GROUPS_ROLES */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER VIEW [ART_DB].[LIST_OF_USERS_AND_GROUPS_ROLES] as
select distinct u.name USER_NAME, u.display_name DISPLAY_NAME, u.email EMAIL, g.name MEMBER_OF_GROUP , r.name ROLE_OF_GROUP
FROM [DGUSERMANAGMENT].[DGMGMT].[user_dg] u
left join [DGUSERMANAGMENT].[DGMGMT].[user_group_dg] ug
on u.id = ug.user_id
left join [DGUSERMANAGMENT].[DGMGMT].[group_dg] g
on g.id = ug.group_id
left join [DGUSERMANAGMENT].[DGMGMT].[group_role_dg] gr
on gr.group_id = g.id
left join [DGUSERMANAGMENT].[DGMGMT].[role_dg] r
on r.id = gr.role_id;
GO");
            /*                 VIEW LIST_OF_USERS_GROUPS         */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [ART_DB].[LIST_OF_USERS_GROUPS] as
select distinct u.name USER_NAME, u.display_name DISPLAY_NAME, u.email EMAIL, g.name MEMBER_OF_GROUP
FROM [DGUSERMANAGMENT].[DGMGMT].[user_dg] u
left join [DGUSERMANAGMENT].[DGMGMT].[user_group_dg] ug
on u.id = ug.user_id
left join [DGUSERMANAGMENT].[DGMGMT].[group_dg] g
on g.id = ug.group_id;
GO");
            /*                 VIEW LIST_OF_USERS_ROLES          */
            migrationBuilder.Sql($@"
USE [ART_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER VIEW [ART_DB].[LIST_OF_USERS_ROLES] as
select distinct  u.name USER_NAME, u.display_name DISPLAY_NAME, u.email EMAIL, r.name USER_ROLE
FROM [DGUSERMANAGMENT].[DGMGMT].[user_dg] u
left join [DGUSERMANAGMENT].[DGMGMT].[user_role_dg] ur
on u.id = ur.user_id
left join [DGUSERMANAGMENT].[DGMGMT].[role_dg] r
on r.id = ur.role_id;
GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[ART_GROUPS_AUDIT_VIEW]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[ART_ROLES_AUDIT_VIEW]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[ART_USERS_AUDIT_VIEW]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LAST_LOGIN_PER_DAY_VIEW]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LIST_GROUPS_ROLES_SUMMARY]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LIST_GROUPS_SUB_GROUPS_SUMMARY]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LIST_OF_DELTED_USERS]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LIST_OF_GROUPS]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LIST_OF_ROLES]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LIST_OF_USERS]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LIST_OF_USERS_AND_GROUPS_ROLES]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LIST_OF_USERS_GROUPS]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[LIST_OF_USERS_ROLES]");
        }
    }
}
