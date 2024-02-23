using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations.FATCA
{
    public partial class FATCAReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.Sql($@"
                -- [ART_FATCA_ALERTS]  
                CREATE VIEW ART_DB.ART_FATCA_ALERTS AS
                 select 
                c.case_id,
                c.CREATE_DATE,
                d.cust_no Customer_ID,
                (case when d.customer_name_ar is null then d.customer_name_en else d.customer_name_ar end) Customer_Name,
                Party_Branch.branch_name,
                OCCS_ID Incident_ID,
                VAL_DESC Type,
                OCCS_DESC Description
                from 
                Dgecm.dgcmgmt.OCCURRENCE_LIVE a left join Dgecm.DGCMGMT.ref_table_val b
                on a.occs_type_cd = b.val_cd and b.ref_table_name = 'RT_OCCS_TYPE'
                left join dgecm.dgcmgmt.case_live c 
                on a.case_rk = c.case_rk
                left join RemoteServer100.agpdb.dbo.personal_info d on d.cust_no = SUBSTRing(c.CASE_ID, CHARINDEX('-', c.CASE_ID) + 1, len(c.CASE_ID)) COLLATE Arabic_100_CI_AI --and d.change_current_ind='Y'
                left join FCF71.FCFCORE.FSC_PARTY_DIM on FCF71.FCFCORE.FSC_PARTY_DIM.party_key = d.Cust_Key 
                LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch ON FSC_PARTY_DIM.STREET_STATE_CODE = Party_Branch.BRANCH_NUMBER 
                AND party_branch.change_current_ind = 'Y'
                where c.case_type_cd = 'FATCA_INDV' 
                union all
                select 
                c.case_id,
                c.CREATE_DATE,
                d.cust_no Customer_ID,
                COMMERCIAL_NAME Customer_Name,
                Party_Branch.branch_name,
                OCCS_ID Incident_ID,
                VAL_DESC Type,
                OCCS_DESC Description
                from 
                Dgecm.dgcmgmt.OCCURRENCE_LIVE a left join Dgecm.DGCMGMT.ref_table_val b
                on a.occs_type_cd = b.val_cd and b.ref_table_name = 'RT_OCCS_TYPE'
                left join Dgecm.dgcmgmt.case_live c 
                on a.case_rk = c.case_rk
                left join RemoteServer100.agpdb.dbo.entity_info d on d.cust_no = SUBSTRing(c.CASE_ID, CHARINDEX('-', c.CASE_ID) + 1, len(c.CASE_ID)) COLLATE Arabic_100_CI_AI --and d.change_current_ind='Y'
                left join FCF71.FCFCORE.FSC_PARTY_DIM on FCF71.FCFCORE.FSC_PARTY_DIM.party_key = d.ENTITY_KEY 
                LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch ON FSC_PARTY_DIM.STREET_STATE_CODE = Party_Branch.BRANCH_NUMBER 
                AND party_branch.change_current_ind = 'Y'
                where c.case_type_cd = 'FATCA_ENTITY' 
                order by create_date desc offset 0 rows;

            ");

            migrationBuilder.Sql($@"
-- [ART_FATCA_CACES]  
 CREATE VIEW ART_DB.ART_FATCA_CACES AS
 select 
a.case_id,
a.CREATE_DATE,
d.cust_no Customer_ID,
(case when d.customer_name_ar is null then d.customer_name_en else d.customer_name_ar end) Customer_Name,
Party_Branch.branch_name,
b.val_desc case_status,
bb.val_desc case_type
from 
dgecm.dgcmgmt.case_live a
left join dgecm.DGCMGMT.ref_table_val b
on a.case_stat_cd = b.val_cd and b.ref_table_name = 'RT_CASE_STATUS'
left join dgecm.DGCMGMT.ref_table_val bb
on a.case_type_cd = bb.val_cd and bb.ref_table_name = 'RT_CASE_TYPE'
left join RemoteServer100.agpdb.dbo.personal_info d on d.cust_no = SUBSTRing(a.CASE_ID, CHARINDEX('-', a.CASE_ID) + 1, len(a.CASE_ID)) COLLATE Arabic_100_CI_AI --and d.change_current_ind='Y'
left join FCF71.FCFCORE.FSC_PARTY_DIM on FCF71.FCFCORE.FSC_PARTY_DIM.party_key = d.Cust_Key 
LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch ON FSC_PARTY_DIM.STREET_STATE_CODE = Party_Branch.BRANCH_NUMBER 
AND party_branch.change_current_ind = 'Y'
where a.case_type_cd = 'FATCA_INDV'

union all

select 
a.case_id,
a.CREATE_DATE,
d.cust_no Customer_ID,
COMMERCIAL_NAME Customer_Name,
Party_Branch.branch_name,
b.val_desc case_status,
bb.val_desc case_type
from 
dgecm.dgcmgmt.case_live a
left join dgecm.DGCMGMT.ref_table_val b
on a.case_stat_cd = b.val_cd and b.ref_table_name = 'RT_CASE_STATUS'
left join dgecm.DGCMGMT.ref_table_val bb
on a.case_type_cd = bb.val_cd and bb.ref_table_name = 'RT_CASE_TYPE'
left join RemoteServer100.agpdb.dbo.entity_info d on d.cust_no = SUBSTRing(a.CASE_ID, CHARINDEX('-', a.CASE_ID) + 1, len(a.CASE_ID)) COLLATE Arabic_100_CI_AI -- and d.change_current_ind='Y'
left join FCF71.FCFCORE.FSC_PARTY_DIM on FCF71.FCFCORE.FSC_PARTY_DIM.party_key = d.Cust_Key 
LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch ON FSC_PARTY_DIM.STREET_STATE_CODE = Party_Branch.BRANCH_NUMBER 
AND party_branch.change_current_ind = 'Y'
where a.case_type_cd = 'FATCA_ENTITY';
            ");
            migrationBuilder.Sql($@"
-- [ART_FATCA_CUSTOMERS]  
create view art_db.ART_FATCA_CUSTOMERS as 
 select 
a.case_id,
b.val_desc case_status,
a.CREATE_DATE,
d.cust_key,
d.cust_no Customer_ID,
(case when d.customer_name_ar is null then d.customer_name_en else d.customer_name_ar end) Customer_Name,
Party_Branch.branch_name,
d.CUST_CLS_FLAG,
Nat.val_desc Main_Nationality,
(case when SIGN_W8 is null then 'N' else SIGN_W8 end) SIGN_W8, 
(case when SIGN_W9 is null then 'N' else SIGN_W9 end) SIGN_W9, 
(case when W9_SIGN_DATE is null then cast('01-JAN-99' as DATETIME)else W9_SIGN_DATE end) W9_SIGN_DATE, 
(case when W8_SIGN_DATE is null then cast('01-JAN-99' as DATETIME)else W8_SIGN_DATE end) W8_SIGN_DATE
from 
dgecm.dgcmgmt.case_live a
left join dgecm.DGCMGMT.ref_table_val b
on a.case_stat_cd = b.val_cd and b.ref_table_name = 'RT_CASE_STATUS'
left join dgecm.DGCMGMT.ref_table_val bb
on a.case_type_cd = bb.val_cd and bb.ref_table_name = 'RT_CASE_TYPE'
left join RemoteServer100.agpdb.dbo.personal_info d on d.cust_no = SUBSTRing(a.CASE_ID, CHARINDEX('-',a.CASE_ID) + 1, len(a.CASE_ID)) COLLATE Arabic_100_CI_AI --and d.change_current_ind='Y'
left join FCF71.FCFCORE.FSC_PARTY_DIM on FCF71.FCFCORE.FSC_PARTY_DIM.party_key = d.cust_key 
LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch ON FSC_PARTY_DIM.STREET_STATE_CODE = Party_Branch.BRANCH_NUMBER 
AND party_branch.change_current_ind = 'Y'
left join dgecm.DGCMGMT.ref_table_val Nat
on rtrim(ltrim(d.main_nat)) = Nat.val_cd  COLLATE Arabic_100_CI_AI and Nat.ref_table_name = 'X_RT_NATIONALITY_CD1'
left join RemoteServer100.agpdb.dbo.fatca_info e on d.cust_key =e.cust_key --and e.change_current_ind='Y'
where a.case_type_cd = 'FATCA_INDV'

union all

select 
a.case_id,
b.val_desc case_status,
a.CREATE_DATE,
d.entity_key cust_key,
d.cust_no Customer_ID,
COMMERCIAL_NAME Customer_Name,
Party_Branch.branch_name,
d.CUST_CLS_FLAG,
Nat.val_desc Main_Nationality,
(case when SIGN_W8_BEN_E is null then 'N' else SIGN_W8_BEN_E end) SIGN_W8, 
(case when SIGN_W9 is null then 'N' else SIGN_W9 end) SIGN_W9, 
(case when W9_SIGN_DATE is null then cast('01-JAN-99' as DATETIME)else W9_SIGN_DATE end) W9_SIGN_DATE, 
(case when W8_SIGN_DATE is null then cast('01-JAN-99' as DATETIME)else W8_SIGN_DATE end) W8_SIGN_DATE
 from 
dgecm.dgcmgmt.case_live a
left join dgecm.DGCMGMT.ref_table_val b
on a.case_stat_cd = b.val_cd and b.ref_table_name = 'RT_CASE_STATUS'
left join dgecm.DGCMGMT.ref_table_val bb
on a.case_type_cd = bb.val_cd and bb.ref_table_name = 'RT_CASE_TYPE'
left join RemoteServer100.agpdb.dbo.entity_info d on d.cust_no = SUBSTRing(a.CASE_ID, CHARINDEX('-', a.CASE_ID) + 1, len(a.CASE_ID)) COLLATE Arabic_100_CI_AI --and d.change_current_ind='Y'
left join FCF71.FCFCORE.FSC_PARTY_DIM on FCF71.FCFCORE.FSC_PARTY_DIM.party_key = d.ENTITY_KEY 
LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch ON FSC_PARTY_DIM.STREET_STATE_CODE = Party_Branch.BRANCH_NUMBER 
AND party_branch.change_current_ind = 'Y'
left join dgecm.DGCMGMT.ref_table_val Nat
on rtrim(ltrim(d.main_nat)) = Nat.val_cd COLLATE Arabic_100_CI_AI and Nat.ref_table_name = 'X_RT_NATIONALITY_CD1'
where a.case_type_cd = 'FATCA_ENTITY';

            ");
            migrationBuilder.Sql($@"

            ");
            migrationBuilder.Sql($@"

-- [ART_FATCA_DORMANT_ACCOUNTS_SUMMARY]  
CREATE VIEW art_db.DORMANT_ACCOUNTS_SUMMARY as
SELECT SUM(DORMANT_AMOUNT/RATE_TO_USD) AS AMOUNT_IN_USD, SUM(ACCOUNTS_COUNT) NUMBER_OF_ACCOUNTS FROM 
(SELECT SUM(ACCT_BALANCE) AS DORMANT_AMOUNT , CURR_CD, COUNT(1) AS ACCOUNTS_COUNT FROM RemoteServer100.agpdb.dbo.ACCT_INFO ACCOUN
WHERE DORMANT_ACCT = 'Y' AND CHANGE_CURRENT_IND = 'Y'
GROUP BY CURR_CD) A
, (SELECT DISTINCT CURR_CD, RATE_TO_USD FROM  RemoteServer100.agpdb.dbo.IRS_RATES) B
WHERE A.CURR_CD = B.CURR_CD
;
            ");
            migrationBuilder.Sql($@"

-- [ART_FATCA_IRS_REPORT]  
--drop view [ART_DB].[ART_FATCA_IRS_REPORT] 
 create  view [ART_DB].[ART_FATCA_IRS_REPORT] as 
 SELECT 
'0000000' AS ACCOUNTNUMBER,
'' AS ACCOUNTCLOSED,
'' AS COUNTRYCODE,
'000-00-0000' as TIN,
'' AS MIDDLENAME,
'' AS FIRSTNAME,
'' AS LASTNAME,
'' AS COUNTRYCODEADD,
'This record contains pools information' AS ADDRESSFREE_I,
'' AS ADDRESSFREE_E,
--TO_DATE('31-DEC-2021','DD-MON-YY') AS BIRTHDATE,
'' AS BIRTHDATE,
'' AS NATIONALITY,
cast(ROUND(0, 2) as float) AS ACCOUNTBALANCE,
'' as ACCOUNTHOLDERTYPE,
'' as ACCOUNTTYPE,
'' as OWNER_FIRST_NAME,
'' as OWNER_LAST_NAME,
'' as OWNER_TIN,
'' AS OWNER_RES_COUNTRY_CODE,
''  AS OWNER_ADDRESS,
cast(ROUND(0, 2) as float) AS PAYMENTAMNT_501,
cast(ROUND(0, 2) as float) AS PAYMENTAMNT_502,
cast(ROUND(0, 2) as float) AS PAYMENTAMNT_503,
cast(ROUND(0, 2) as float) AS PAYMENTAMNT_504,
'' AS ACCOUNTCOUNT_FATCA201,
'' AS POOLBALANCE_FATCA201,
'' AS ACCOUNTCOUNT_FATCA202,
'' AS POOLBALANCE_FATCA202,
number_of_accounts AS ACCOUNTCOUNT_FATCA203,
cast(ROUND(Amount_in_USD, 2) as float) AS POOLBALANCE_FATCA203,
'' AS ACCOUNTCOUNT_FATCA204,
'' AS POOLBALANCE_FATCA204,
'' AS ACCOUNTCOUNT_FATCA205,
'' AS POOLBALANCE_FATCA205,
'' AS ACCOUNTCOUNT_FATCA206,
'' AS POOLBALANCE_FATCA206,
'' as SIGN_W8,
'' as SIGN_W9
FROM art_db.ART_FATCA_DORMANT_ACCOUNTS_SUMMARY

UNION ALL

  SELECT 
CUSTOMER_INFO.CUST_NO AS ACCOUNTNUMBER,
ACCOUNT.CLOSED AS ACCOUNTCLOSED,
adrs.RES_COUNTRY AS COUNTRYCODE,
CASE xyz.TIN_NO WHEN NULL THEN '000-00-0000' ELSE xyz.TIN_NO END AS TIN,
CUSTOMER_INFO.MIDDLE_NAME AS MIDDLENAME,
CUSTOMER_INFO.FIRST_NAME AS FIRSTNAME,
CUSTOMER_INFO.LAST_NAME AS LASTNAME,
adrs.CURRENT_ADRS_COUNTRY AS COUNTRYCODEADD,
adrs.current_adrs AS ADDRESSFREE_I,
adrs.CURRENT_ADRS AS ADDRESSFREE_E,
--CUSTOMER_INFO.BIRTH_DATE AS BIRTHDATE,
'' AS BIRTHDATE,
CUSTOMER_INFO.MAIN_NAT AS NATIONALITY,
cast(ROUND(ACCOUNT.Customer_Balance, 2) as float) AS ACCOUNTBALANCE,
CASE a.CASE_TYPE_CD WHEN 'FATCA_ENTITY' THEN 'FATCA101' WHEN 'FATCA_INDV' THEN ''  ELSE '' END AS AccountHolderType,
CASE a.CASE_TYPE_CD WHEN 'FATCA_INDV' THEN '1' ELSE '2' END AS ACCOUNTTYPE,
'' as OWNER_FIRST_NAME,
'' as OWNER_LAST_NAME,
'' as OWNER_TIN,
''  AS OWNER_RES_COUNTRY_CODE,
'' AS OWNER_ADDRESS,
cast(ROUND(ACCOUNT.Customer_Dividend, 2) as float) AS PAYMENTAMNT_501,
cast(ROUND(ACCOUNT.Customer_Interest, 2) as float) AS PAYMENTAMNT_502,
cast(ROUND(ACCOUNT.Customer_Cross, 2) as float) AS PAYMENTAMNT_503,
cast(ROUND(ACCOUNT.Customer_Other_Pymnt, 2) as float) AS PAYMENTAMNT_504,
'' AS ACCOUNTCOUNT_FATCA201,
'' AS POOLBALANCE_FATCA201,
'' AS ACCOUNTCOUNT_FATCA202,
'' AS POOLBALANCE_FATCA202,
cast(ROUND(0, 2) as float) AS ACCOUNTCOUNT_FATCA203,
cast(ROUND(0, 2) as float) AS POOLBALANCE_FATCA203,
'' AS ACCOUNTCOUNT_FATCA204,
'' AS POOLBALANCE_FATCA204,
'' AS ACCOUNTCOUNT_FATCA205,
'' AS POOLBALANCE_FATCA205,
'' AS ACCOUNTCOUNT_FATCA206,
'' AS POOLBALANCE_FATCA206,
xyz.SIGN_W8,
xyz.SIGN_W9
from
dgecm.DGCMGMT.Case_Live a 
left join RemoteServer100.agpdb.dbo.Personal_Info CUSTOMER_INFO on substring(a.case_id,7, len(a.case_id)) = CUSTOMER_INFO.Cust_No COLLATE Arabic_100_CI_AI --and CUSTOMER_INFO.change_current_ind='Y'
left join RemoteServer100.agpdb.dbo.Address_Info adrs on CUSTOMER_INFO.cust_key = adrs.cust_key --and adrs.change_current_ind='Y'
LEFT JOIN art_db.CUSTOMER_ACCOUNTS_SUMMARY ACCOUNT ON ACCOUNT.CUST_NO=CUSTOMER_INFO.CUST_NO
left join RemoteServer100.agpdb.dbo.FATCA_INFO xyz on CUSTOMER_INFO.cust_key = xyz.cust_key --and xyz.change_current_ind='Y'
where 
--case_stat_cd = 'C_W9' and
--Case_Rk in (select max(case_rk) from dgcmgmt.Case_Live group by Col2)
customer_info.main_nat='US'  and 
CUSTOMER_INFO.CREATE_DATE < '01-jan-2022'

            ");

            migrationBuilder.Sql($@"
-- [ART_ST_FATCA_ALERTS_PER_BRANCH]  
      CREATE PROCEDURE [ART_DB].[ART_ST_FATCA_ALERTS_PER_BRANCH]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;
							select COALESCE(a.branch_name, 'Unknown') BRANCH_NAME,cast(count(a.INCIDENT_ID) as decimal)NUMBER_OF_ALERTS
							from art_db.art_fatca_alerts a 
							where  CAST(a.create_date AS date) >= @V_START_DATE AND CAST(a.create_date AS date) <= @V_END_DATE
							group by a.branch_name;              
                            END ;

            ");
            migrationBuilder.Sql($@"
-- [ART_ST_FATCA_ALERTS_PER_TYPE]  
      CREATE PROCEDURE [ART_DB].[ART_ST_FATCA_ALERTS_PER_TYPE]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;
							select COALESCE(a.type, 'Unknown') BRANCH_NAME,cast(count(a.INCIDENT_ID) as decimal)NUMBER_OF_ALERTS
							from art_db.art_fatca_alerts a 
							where  CAST(a.create_date AS date) >= @V_START_DATE AND CAST(a.create_date AS date) <= @V_END_DATE
							group by a.type;              
                            END ;

            ");
            migrationBuilder.Sql($@"
-- [ART_ST_FATCA_CASES_PER_BRANCH]  
      CREATE PROCEDURE [ART_DB].[ART_ST_FATCA_CASES_PER_BRANCH]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;
							select COALESCE(a.branch_name, 'Unknown') BRANCH_NAME,cast(count(1) as decimal)NUMBER_OF_CASES
							from art_db.art_fatca_caces a 
							where  CAST(a.create_date AS date) >= @V_START_DATE AND CAST(a.create_date AS date) <= @V_END_DATE
							group by a.branch_name;              
                            END ;

            ");
            migrationBuilder.Sql($@"
-- [ART_ST_FATCA_CASES_PER_STATUS]  
      CREATE PROCEDURE [ART_DB].[ART_ST_FATCA_CASES_PER_STATUS]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;
							select COALESCE(a.case_status, 'Unknown') BRANCH_NAME,cast(count(1) as decimal)NUMBER_OF_CASES
							from art_db.art_fatca_caces a 
							where  CAST(a.create_date AS date) >= @V_START_DATE AND CAST(a.create_date AS date) <= @V_END_DATE
							group by a.case_status;              
                            END ;

            ");
            migrationBuilder.Sql($@"
-- [ART_ST_FATCA_CASES_PER_TYPE]  
      CREATE PROCEDURE [ART_DB].[ART_ST_FATCA_CASES_PER_TYPE]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;
							select COALESCE(a.case_type, 'Unknown') BRANCH_NAME,cast(count(1) as decimal)NUMBER_OF_CASES
							from art_db.art_fatca_caces a 
							where  CAST(a.create_date AS date) >= @V_START_DATE AND CAST(a.create_date AS date) <= @V_END_DATE
							group by a.case_type;              
                            END ;

            ");
            migrationBuilder.Sql($@"
-- [ART_ST_FATCA_CUSTS_PER_NATION]  
      CREATE PROCEDURE [ART_DB].[ART_ST_FATCA_CUSTS_PER_NATION]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;
							select COALESCE(a.main_nationality, 'Unknown') BRANCH_NAME,cast(count(1) as decimal) NUMBER_OF_CUSTPOMERS
							from art_db.art_fatca_customers a 
							where  CAST(a.create_date AS date) >= @V_START_DATE AND CAST(a.create_date AS date) <= @V_END_DATE
							group by a.main_nationality;              
                            END ;

            ");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
