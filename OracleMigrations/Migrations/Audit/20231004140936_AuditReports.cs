using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.Audit
{
    public partial class AuditReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LAST_LOGIN_PER_DAY_VIEW
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LAST_LOGIN_PER_DAY_VIEW"" (""USER_NAME"", ""APP_NAME"", ""DEVICE_NAME"", ""DEVICE_TYPE"", ""IP"", ""LOCATION"", ""LOGINDATETIME"") AS 
  select ""USER_NAME"",
      ""APP_NAME"",
      DEVICE_NAME,
      DEVICE_TYPE, 
	  IP,
      LOCATION,
	  LOGINDATETIME  from 
  (select ""USER_NAME"",
      ""APP_NAME"",
      DEVICE_NAME,
      DEVICE_TYPE, 
	  IP,
      LOCATION,
	  create_date LOGINDATETIME ,
	  row_number() over (PARTITION by user_name, cast(create_date as date) order by create_date desc) rn
  from DGMGMT.logged_user ) 
  where rn = 1
;");
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LIST_GROUPS_SUB_GROUPS_SUMMARY
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LIST_GROUPS_SUB_GROUPS_SUMMARY"" (""GROUP_NAME"", ""SUB_GROUP_NAME"") AS 
  select  g.name GROUP_NAME , 
g2.name SUB_GROUP_NAME
FROM DGMGMT.group_dg g
left join DGMGMT.sub_group sg
on sg.group_id = g.id
left join DGMGMT.group_dg g2
on sg.sub_group_id = g2.id
;");
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LIST_GROUPS_ROLES_SUMMARY
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LIST_GROUPS_ROLES_SUMMARY"" (""GROUP_NAME"", ""ROLE_NAME"") AS 
  select distinct g.name GROUP_NAME , 
(Case when r.name is null then 'No Role' else r.name end) AS  ROLE_NAME
FROM DGMGMT.group_dg g
left join DGMGMT.group_role_dg gr
on gr.group_id = g.id
left join DGMGMT.role_dg r
on r.id = gr.role_id
;");
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LIST_OF_DELTED_USERS
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LIST_OF_DELTED_USERS"" (""USER_NAME"", ""ADDRESS"", ""DESCRIPTION"", ""DISPLAY_NAME"", ""EMAIL"", ""PHONE"", ""USER_TYPE"", ""CREATED_BY"", ""CREATED_DATE"", ""LAST_LOGIN_DATE"", ""LAST_FAILED_LOGIN"") AS 
  select ua.name USER_NAME
      ,address
      ,description
      ,display_name
      ,email
      ,phone
      ,user_type
      ,created_by
      ,created_date
      ,last_login_date
      ,last_failed_login
	  from DGMGMT_AUDIT.user_dg_aud ua where revtype = 0
and ua.id not in(
select u.id  from DGMGMT.user_dg u)
;");
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LIST_OF_GROUPS
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LIST_OF_GROUPS"" (""GROUP_NAME"", ""DESCRIPTION"", ""GROUP_TYPE"", ""DISPLAY_NAME"", ""CREATED_BY"", ""CREATED_DATE"", ""LAST_UPDATED_BY"", ""LAST_UPDATED_DATE"") AS 
  select g.name group_name, g.description, g.group_type, g.display_name, g.created_by, g.created_date,
  g.last_updated_by, g.last_updated_date
  FROM DGMGMT.group_dg g
;");
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LIST_OF_ROLES
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LIST_OF_ROLES"" (""ROLE_NAME"", ""DESCRIPTION"", ""DISPLAY_NAME"", ""ROLE_TYPE"", ""CREATED_DATE"", ""CREATED_BY"", ""LAST_UPDATED_BY"", ""LAST_UPDATED_DATE"") AS 
  select 
name role_name, 
description, display_name,
role_type, created_date, created_by, last_updated_by, last_updated_date
FROM DGMGMT.role_dg
;");
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LIST_OF_USERS
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LIST_OF_USERS"" (""USER_NAME"", ""ADDRESS"", ""DESCRIPTION"", ""DISPLAY_NAME"", ""EMAIL"", ""PHONE"", ""USER_TYPE"", ""CREATED_BY"", ""CREATED_DATE"", ""LAST_UPDATED_BY"", ""LAST_UPDATED_DATE"", ""LAST_LOGIN_DATE"", ""LAST_FAILED_LOGIN"", ""COUNTER_LOCK"", ""ACTIVE"", ""ENABLE"") AS 
  select u.name user_name, u.address, u.description, u.display_name, u.email, u.phone, u.user_type,
   u.created_by, u.created_date, u.last_updated_by,  u.last_updated_date, u.last_login_date, u.last_failed_login,
   u.counter_lock, u.active, u.enable
   FROM DGMGMT.user_dg u
;");
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LIST_OF_USERS_AND_GROUPS_ROLES
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LIST_OF_USERS_AND_GROUPS_ROLES"" (""USER_NAME"", ""DISPLAY_NAME"", ""EMAIL"", ""MEMBER_OF_GROUP"", ""ROLE_OF_GROUP"") AS 
  select distinct u.name USER_NAME, u.display_name DISPLAY_NAME, u.email EMAIL, g.name MEMBER_OF_GROUP , r.name ROLE_OF_GROUP
FROM DGMGMT.user_dg u
left join DGMGMT.user_group_dg ug
on u.id = ug.user_id
left join DGMGMT.group_dg g
on g.id = ug.group_id
left join DGMGMT.group_role_dg gr
on gr.group_id = g.id
left join DGMGMT.role_dg r
on r.id = gr.role_id
;");
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LIST_OF_USERS_GROUPS
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LIST_OF_USERS_GROUPS"" (""USER_NAME"", ""DISPLAY_NAME"", ""EMAIL"", ""MEMBER_OF_GROUP"") AS 
  select distinct u.name USER_NAME, u.display_name DISPLAY_NAME, u.email EMAIL, g.name MEMBER_OF_GROUP
FROM DGMGMT.user_dg u
left join DGMGMT.user_group_dg ug
on u.id = ug.user_id
left join DGMGMT.group_dg g
on g.id = ug.group_id
;");
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View LIST_OF_USERS_ROLES
--------------------------------------------------------

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""LIST_OF_USERS_ROLES"" (""USER_NAME"", ""DISPLAY_NAME"", ""EMAIL"", ""USER_ROLE"") AS 
  select distinct  u.name USER_NAME, u.display_name DISPLAY_NAME, u.email EMAIL, r.name USER_ROLE
FROM DGMGMT.user_dg u
left join DGMGMT.user_role_dg ur
on u.id = ur.user_id
left join DGMGMT.role_dg r
on r.id = ur.role_id
;");
            migrationBuilder.Sql($@"-----------------------------------------------------------

CREATE view ""ART"".""ART_USERS_AUDIT_VIEW"" as 
WITH ST1 AS (
  SELECT u.id, u.rev, u.revtype, u.name, u.address, u.description, u.display_name, u.email, u.phone, u.status,
         u.created_by, u.created_date, u.last_updated_by, u.last_updated_date, u.last_login_date, u.last_failed_login, u.enable,
          g.name AS group_name,r.name AS role_name, ad.authentication_domain AS domain_account
  FROM dgmgmt_audit.user_dg_aud u
  LEFT JOIN dgmgmt_audit.user_role_dg_aud ur ON u.id = ur.user_id AND u.rev = ur.rev
  LEFT JOIN dgmgmt_audit.role_dg_aud r ON r.id = ur.role_id AND r.rev = ur.rev
  LEFT JOIN dgmgmt_audit.user_group_dg_aud ug ON u.id = ug.user_id AND u.rev = ug.rev
  LEFT JOIN dgmgmt_audit.group_dg_aud g ON g.id = ug.group_id AND g.rev = ug.rev
  LEFT JOIN dgmgmt_audit.account_aud ad ON u.id = ad.user_id AND u.REV = ad.REV
 -- WHERE u.id = 786
),
ST4 AS (
  SELECT id, rev, revtype, name, address, description, display_name, email, phone, status,
         created_by, created_date, last_updated_by, last_updated_date, last_login_date, last_failed_login, enable,
         LISTAGG(group_name, ', ') WITHIN GROUP (ORDER BY group_name) AS group_names,
         LISTAGG(role_name, ', ') WITHIN GROUP (ORDER BY role_name) AS role_names,
         LISTAGG(domain_account, ', ') WITHIN GROUP (ORDER BY domain_account) AS domain_accounts
  FROM ST1
  GROUP BY id, rev, revtype, name, address, description, display_name, email, phone, status,
         created_by, created_date, last_updated_by, last_updated_date, last_login_date, last_failed_login, enable
)
SELECT name AS user_name,
       CASE revtype
         WHEN 0 THEN 'Add'
         WHEN 1 THEN 'Update'
         WHEN 2 THEN 'Delete'
       END AS action,
       address, description, display_name, email, phone, status,
       created_by, TO_TIMESTAMP(created_date, 'YYYY-MM-DD HH24:MI:SS') AS created_date,
       last_updated_by, TO_TIMESTAMP(last_updated_date, 'YYYY-MM-DD HH24:MI:SS') AS last_updated_date,
       TO_TIMESTAMP(last_login_date, 'YYYY-MM-DD HH24:MI:SS') AS last_login_date,
       TO_TIMESTAMP(last_failed_login, 'YYYY-MM-DD HH24:MI:SS') AS last_failed_login,
       enable, group_names, role_names, domain_accounts
  FROM ST4
  ORDER BY id, last_updated_date DESC
 ;");
            migrationBuilder.Sql($@" CREATE view ""ART"".""ART_GROUPS_AUDIT_VIEW"" as 
WITH ST1 AS (
  SELECT g.id, g.rev, g.revtype, g.name, g.description, g.display_name, g.created_by, g.created_date,
  g.last_updated_by, g.last_updated_date, g2.name sub_group_name ,r.name role_name ,u.name member_user
  FROM DGMGMT_AUDIT.group_dg_aud g
  left join DGMGMT_AUDIT.user_group_dg_aud ug
  on g.id = ug.group_id and g.rev = ug.rev
  left join DGMGMT_AUDIT.user_dg_aud u 
  on u.id = ug.user_id and ug.rev = u.rev
  left join DGMGMT_AUDIT.sub_group_aud sg
  on g.id = sg.group_id and g.rev = sg.rev
  left join DGMGMT_AUDIT.group_dg_aud g2
  on g2.id = sg.sub_group_id and g2.rev = sg.rev
  left join DGMGMT_AUDIT.group_role_dg_aud gr
  on g.id = gr.group_id and g.rev = gr.rev
  left join DGMGMT_AUDIT.role_dg_aud r
  on r.id = gr.role_id and r.rev = gr.rev
),
ST4 AS (
  SELECT id, rev, revtype, name, description, display_name, 
         created_by, created_date, last_updated_by, last_updated_date,
         LISTAGG(sub_group_name, ', ') WITHIN GROUP (ORDER BY sub_group_name) AS sub_group_names,
         LISTAGG(role_name, ', ') WITHIN GROUP (ORDER BY role_name) AS role_names,
         LISTAGG(member_user, ', ') WITHIN GROUP (ORDER BY member_user) AS member_users
  FROM ST1
  GROUP BY id, rev, revtype, name, description, display_name, created_by, created_date,
  last_updated_by, last_updated_date
)
SELECT name AS group_name,
       CASE revtype
         WHEN 0 THEN 'Add'
         WHEN 1 THEN 'Update'
         WHEN 2 THEN 'Delete'
       END AS action,
        description, display_name, 
       created_by, TO_TIMESTAMP(created_date, 'YYYY-MM-DD HH24:MI:SS') AS created_date,
       last_updated_by, TO_TIMESTAMP(last_updated_date, 'YYYY-MM-DD HH24:MI:SS') AS last_updated_date,
       sub_group_names, role_names, member_users
  FROM ST4
  ORDER BY id, last_updated_date DESC
 ;");
            migrationBuilder.Sql($@"CREATE view ""ART"".""ART_ROLES_AUDIT_VIEW"" as 
WITH ST1 AS (
  SELECT r.id, r.rev, r.revtype, r.name, r.description, r.display_name, r.created_by, r.created_date,
  r.last_updated_by, r.last_updated_date, g.name group_name,u.name member_user
 FROM DGMGMT_AUDIT.role_dg_aud r
  left join DGMGMT_AUDIT.user_role_dg_aud ur
  on r.id = ur.role_id and r.rev = ur.rev
  left join DGMGMT_AUDIT.user_dg_aud u 
  on u.id = ur.user_id and ur.rev = u.rev
  left join DGMGMT_AUDIT.group_role_dg_aud gr
  on r.id = gr.role_id and r.rev = gr.rev
  left join DGMGMT_AUDIT.group_dg_aud g
  on g.id = gr.group_id and g.rev = gr.rev
),
ST4 AS (
  SELECT id, rev, revtype, name, description, display_name, 
         created_by, created_date, last_updated_by, last_updated_date,
         LISTAGG(group_name, ', ') WITHIN GROUP (ORDER BY group_name) AS group_names,
         LISTAGG(member_user, ', ') WITHIN GROUP (ORDER BY member_user) AS member_users
  FROM ST1
  GROUP BY id, rev, revtype, name, description, display_name, created_by, created_date,
  last_updated_by, last_updated_date
)
SELECT name AS role_name,
       CASE revtype
         WHEN 0 THEN 'Add'
         WHEN 1 THEN 'Update'
         WHEN 2 THEN 'Delete'
       END AS action,
        description, display_name, 
       created_by, TO_TIMESTAMP(created_date, 'YYYY-MM-DD HH24:MI:SS') AS created_date,
       last_updated_by, TO_TIMESTAMP(last_updated_date, 'YYYY-MM-DD HH24:MI:SS') AS last_updated_date,
       group_names, member_users
  FROM ST4
  ORDER BY id, last_updated_date DESC
 ;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
