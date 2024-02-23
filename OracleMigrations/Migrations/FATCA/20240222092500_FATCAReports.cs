using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.FATCA
{
    public partial class FATCAReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                CREATE DATABASE LINK DGCMGMT
                CONNECT TO DGCMGMT IDENTIFIED BY DGCMGMT
                USING '192.168.1.96:1521/aml71';

                CREATE DATABASE LINK fagpdb
                CONNECT TO fagpdb IDENTIFIED BY fagpdb1
                USING '192.168.1.96:1521/aml71';
            ");

            migrationBuilder.Sql($@"
                --------------------------------------------------------
                --  DDL for View ART_FATCA_CUSTOMERS
                --------------------------------------------------------
                CREATE
                OR
                replace FORCE editionable VIEW ""ART"".""ART_FATCA_CUSTOMERS"" (""CASE_ID"", ""CASE_STATUS"", ""CREATE_DATE"", ""CUST_KEY"", ""CUSTOMER_ID"", ""CUSTOMER_NAME"", ""BRANCH_NAME"", ""CUST_CLS_FLAG"", ""MAIN_NATIONALITY"", ""SIGN_W8"", ""SIGN_W9"", ""W9_SIGN_DATE"", ""W8_SIGN_DATE"") AS
                SELECT    a.case_id,
                          b.val_desc case_status,
                          a.create_date,
                          d.cust_key,
                          d.cust_no customer_id, (
                          CASE
                                    WHEN d.customer_name_ar IS NULL THEN d.customer_name_en
                                    ELSE d.customer_name_ar
                          END) customer_name,
                          branch.branch_name,
                          d.cust_cls_flag,
                          nat.val_desc main_nationality, (
                          CASE
                                    WHEN sign_w8 IS NULL THEN 'N'
                                    ELSE sign_w8
                          END) sign_w8, (
                          CASE
                                    WHEN sign_w9 IS NULL THEN 'N'
                                    ELSE sign_w9
                          END) sign_w9,
                          trunc(
                          CASE
                                    WHEN w9_sign_date IS NULL THEN to_date('01-JAN-99', 'DD-MON-YY')
                                    ELSE w9_sign_date
                          END) w9_sign_date,
                          trunc(
                          CASE
                                    WHEN w8_sign_date IS NULL THEN to_date('01-JAN-99', 'DD-MON-YY')
                                    ELSE w8_sign_date
                          END) w8_sign_date
                FROM      case_live@dgcmgmt a
                left join ref_table_val@dgcmgmt b
                ON        a.case_stat_cd = b.val_cd
                AND       b.ref_table_name = 'RT_CASE_STATUS'
                left join ref_table_val@dgcmgmt bb
                ON        a.case_type_cd = bb.val_cd
                AND       bb.ref_table_name = 'RT_CASE_TYPE'
                left join personal_info@fagpdb d
                ON        d.cust_no = substr(a.case_id, instr(a.case_id, '-') + 1)
                AND       d.change_current_ind='Y'
                left join fcfcore.fsc_branch_dim branch
                ON        d.branch_cd = branch.branch_number
                AND       branch.branch_type_desc = 'BRANCH'
                AND       branch.change_current_ind = 'Y'
                left join ref_table_val@dgcmgmt nat
                ON        trim(d.main_nat) = nat.val_cd
                AND       nat.ref_table_name = 'X_RT_NATIONALITY_CD1'
                left join fatca_info e
                ON        d.cust_key =e.cust_key
                AND       e.change_current_ind='Y'
                WHERE     a.case_type_cd = 'FATCA_INDV'
                UNION ALL
                SELECT    a.case_id,
                          b.val_desc case_status,
                          a.create_date,
                          d.entity_key    cust_key,
                          d.cust_no       customer_id,
                          commercial_name customer_name,
                          branch.branch_name,
                          d.cust_cls_flag,
                          nat.val_desc main_nationality, (
                          CASE
                                    WHEN sign_w8_ben_e IS NULL THEN 'N'
                                    ELSE sign_w8_ben_e
                          END) sign_w8, (
                          CASE
                                    WHEN sign_w9 IS NULL THEN 'N'
                                    ELSE sign_w9
                          END) sign_w9,
                          trunc(
                          CASE
                                    WHEN w9_sign_date IS NULL THEN to_date('01-JAN-99', 'DD-MON-YY')
                                    ELSE w9_sign_date
                          END) w9_sign_date,
                          trunc(
                          CASE
                                    WHEN w8_sign_date IS NULL THEN to_date('01-JAN-99', 'DD-MON-YY')
                                    ELSE w8_sign_date
                          END) w8_sign_date
                FROM      case_live@dgcmgmt a
                left join ref_table_val@dgcmgmt b
                ON        a.case_stat_cd = b.val_cd
                AND       b.ref_table_name = 'RT_CASE_STATUS'
                left join ref_table_val@dgcmgmt bb
                ON        a.case_type_cd = bb.val_cd
                AND       bb.ref_table_name = 'RT_CASE_TYPE'
                left join entity_info@fagpdb d
                ON        d.cust_no = substr(a.case_id, instr(a.case_id, '-') + 1)
                AND       d.change_current_ind='Y'
                left join fcfcore.fsc_branch_dim branch
                ON        d.branch_cd = branch.branch_number
                AND       branch.branch_type_desc = 'BRANCH'
                AND       branch.change_current_ind = 'Y'
                left join ref_table_val@dgcmgmt nat
                ON        trim(d.main_nat) = nat.val_cd
                AND       nat.ref_table_name = 'X_RT_NATIONALITY_CD1'
                WHERE     a.case_type_cd = 'FATCA_ENTITY' ;
            ");
            migrationBuilder.Sql($@"
                
                --------------------------------------------------------
                --  DDL for View ART_FATCA_CACES
                --------------------------------------------------------
                CREATE
                OR
                replace FORCE editionable VIEW ""ART"".""ART_FATCA_CACES"" (""CASE_ID"", ""CREATE_DATE"", ""CUSTOMER_ID"", ""CUSTOMER_NAME"", ""BRANCH_NAME"", ""CASE_STATUS"", ""CASE_TYPE"") AS
                SELECT    a.case_id,
                          a.create_date,
                          d.cust_no customer_id, (
                          CASE
                                    WHEN d.customer_name_ar IS NULL THEN d.customer_name_en
                                    ELSE d.customer_name_ar
                          END) customer_name,
                          branch.branch_name,
                          b.val_desc  case_status,
                          bb.val_desc case_type
                FROM      case_live@dgcmgmt a
                left join ref_table_val@dgcmgmt b
                ON        a.case_stat_cd = b.val_cd
                AND       b.ref_table_name = 'RT_CASE_STATUS'
                left join ref_table_val@dgcmgmt bb
                ON        a.case_type_cd = bb.val_cd
                AND       bb.ref_table_name = 'RT_CASE_TYPE'
                left join personal_info@fagpdb d
                ON        d.cust_no = substr(a.case_id, instr(a.case_id, '-') + 1)
                AND       d.change_current_ind='Y'
                left join fcfcore.fsc_branch_dim branch
                ON        d.branch_cd = branch.branch_number
                AND       branch.branch_type_desc = 'BRANCH'
                AND       branch.change_current_ind = 'Y'
                WHERE     a.case_type_cd = 'FATCA_INDV'
                UNION ALL
                SELECT    a.case_id,
                          a.create_date,
                          d.cust_no       customer_id,
                          commercial_name customer_name,
                          branch.branch_name,
                          b.val_desc  case_status,
                          bb.val_desc case_type
                FROM      case_live@dgcmgmt a
                left join ref_table_val@dgcmgmt b
                ON        a.case_stat_cd = b.val_cd
                AND       b.ref_table_name = 'RT_CASE_STATUS'
                left join ref_table_val@dgcmgmt bb
                ON        a.case_type_cd = bb.val_cd
                AND       bb.ref_table_name = 'RT_CASE_TYPE'
                left join entity_info@fagpdb d
                ON        d.cust_no = substr(a.case_id, instr(a.case_id, '-') + 1)
                AND       d.change_current_ind='Y'
                left join fcfcore.fsc_branch_dim branch
                ON        d.branch_cd = branch.branch_number
                AND       branch.branch_type_desc = 'BRANCH'
                AND       branch.change_current_ind = 'Y'
                WHERE     a.case_type_cd = 'FATCA_ENTITY' ;
            ");
            migrationBuilder.Sql($@"
                
                --------------------------------------------------------
                --  DDL for View ART_FATCA_ALERTS
                --------------------------------------------------------

                  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_FATCA_ALERTS"" (""CASE_ID"", ""CREATE_DATE"", ""CUSTOMER_ID"", ""CUSTOMER_NAME"", ""BRANCH_NAME"", ""INCIDENT_ID"", ""TYPE"", ""DESCRIPTION"") AS 
                  select 
                c.case_id,
                c.CREATE_DATE,
                d.cust_no Customer_ID,
                (case when d.customer_name_ar is null then d.customer_name_en else d.customer_name_ar end) Customer_Name,
                branch.branch_name,
                OCCS_ID Incident_ID,
                VAL_DESC Type,
                OCCS_DESC Description
                from 
                OCCURRENCE_LIVE@dgcmgmt a left join ref_table_val@DGCMGMT b
                on a.occs_type_cd = b.val_cd and b.ref_table_name = 'RT_OCCS_TYPE'
                left join case_live@dgcmgmt c 
                on a.case_rk = c.case_rk
                left join personal_info@fagpdb d on d.cust_no = SUBSTR(c.CASE_ID, INSTR(c.CASE_ID, '-') + 1) and d.change_current_ind='Y'
                left join fcfcore.fsc_branch_dim branch on d.branch_cd = branch.branch_number 
                and branch.BRANCH_TYPE_DESC = 'BRANCH' and branch.change_current_ind = 'Y'
                where c.case_type_cd = 'FATCA_INDV' 
                union all
                select 
                c.case_id,
                c.CREATE_DATE,
                d.cust_no Customer_ID,
                COMMERCIAL_NAME Customer_Name,
                branch.branch_name,
                OCCS_ID Incident_ID,
                VAL_DESC Type,
                OCCS_DESC Description
                from 
                OCCURRENCE_LIVE@dgcmgmt a left join ref_table_val@DGCMGMT b
                on a.occs_type_cd = b.val_cd and b.ref_table_name = 'RT_OCCS_TYPE'
                left join case_live@dgcmgmt c 
                on a.case_rk = c.case_rk
                left join entity_info@fagpdb d on d.cust_no = SUBSTR(c.CASE_ID, INSTR(c.CASE_ID, '-') + 1) and d.change_current_ind='Y'
                left join fcfcore.fsc_branch_dim branch on d.branch_cd = branch.branch_number 
                and branch.BRANCH_TYPE_DESC = 'BRANCH' and branch.change_current_ind = 'Y'
                where c.case_type_cd = 'FATCA_ENTITY' 
                order by create_date desc
                ;


                
            ");
            migrationBuilder.Sql($@"
                
                  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_FATCA_DORMANT_ACCOUNTS_SUMMARY"" (""AMOUNT_IN_USD"", ""NUMBER_OF_ACCOUNTS"") AS 
                  (
                SELECT SUM(DORMANT_AMOUNT/RATE_TO_USD) AS AMOUNT_IN_USD, SUM(ACCOUNTS_COUNT) NUMBER_OF_ACCOUNTS FROM 
                (SELECT SUM(ACCT_BALANCE) AS DORMANT_AMOUNT , CURR_CD, COUNT(1) AS ACCOUNTS_COUNT FROM ACCT_INFO@FAGPDB ACCOUN
                WHERE DORMANT_ACCT = 'Y' AND CHANGE_CURRENT_IND = 'Y'
                GROUP BY CURR_CD) A
                , (SELECT DISTINCT CURR_CD, RATE_TO_USD FROM  IRS_RATES@FAGPDB) B
                WHERE A.CURR_CD = B.CURR_CD
                );
            ");
            migrationBuilder.Sql($@"
                --------------------------------------------------------
                --  DDL for View IRS_REPORT
                --------------------------------------------------------
                CREATE
                OR
                replace FORCE editionable VIEW ""ART"".""ART_FATCA_IRS_REPORT"" (""ACCOUNTNUMBER"", ""ACCOUNTCLOSED"", ""COUNTRYCODE"", ""TIN"", ""MIDDLENAME"", ""FIRSTNAME"", ""LASTNAME"", ""COUNTRYCODEADD"", ""ADDRESSFREE_I"", ""ADDRESSFREE_E"", ""BIRTHDATE"", ""NATIONALITY"", ""ACCOUNTBALANCE"", ""ACCOUNTHOLDERTYPE"", ""ACCOUNTTYPE"", ""OWNER_FIRST_NAME"", ""OWNER_LAST_NAME"", ""OWNER_TIN"", ""OWNER_RES_COUNTRY_CODE"", ""OWNER_ADDRESS"", ""PAYMENTAMNT_501"", ""PAYMENTAMNT_502"", ""PAYMENTAMNT_503"", ""PAYMENTAMNT_504"", ""ACCOUNTCOUNT_FATCA201"", ""POOLBALANCE_FATCA201"", ""ACCOUNTCOUNT_FATCA202"", ""POOLBALANCE_FATCA202"", ""ACCOUNTCOUNT_FATCA203"", ""POOLBALANCE_FATCA203"", ""ACCOUNTCOUNT_FATCA204"", ""POOLBALANCE_FATCA204"", ""ACCOUNTCOUNT_FATCA205"", ""POOLBALANCE_FATCA205"", ""ACCOUNTCOUNT_FATCA206"", ""POOLBALANCE_FATCA206"", ""SIGN_W8"", ""SIGN_W9"") AS
                (
                       SELECT '0000000'                                AS accountnumber,
                              ''                                       AS accountclosed,
                              ''                                       AS countrycode,
                              '000-00-0000'                            AS tin,
                              ''                                       AS middlename,
                              ''                                       AS firstname,
                              ''                                       AS lastname,
                              ''                                       AS countrycodeadd,
                              'This record contains pools information' AS addressfree_i,
                              ''                                       AS addressfree_e,
                              --TO_DATE('31-DEC-2021','DD-MON-YY') AS BIRTHDATE,
                              ''                                     AS birthdate,
                              ''                                     AS nationality,
                              cast(round(0, 2) AS FLOAT)             AS accountbalance,
                              ''                                     AS accountholdertype,
                              ''                                     AS accounttype,
                              ''                                     AS owner_first_name,
                              ''                                     AS owner_last_name,
                              ''                                     AS owner_tin,
                              ''                                     AS owner_res_country_code,
                              ''                                     AS owner_address,
                              cast(round(0, 2) AS FLOAT)             AS paymentamnt_501,
                              cast(round(0, 2) AS FLOAT)             AS paymentamnt_502,
                              cast(round(0, 2) AS FLOAT)             AS paymentamnt_503,
                              cast(round(0, 2) AS FLOAT)             AS paymentamnt_504,
                              ''                                     AS accountcount_fatca201,
                              ''                                     AS poolbalance_fatca201,
                              ''                                     AS accountcount_fatca202,
                              ''                                     AS poolbalance_fatca202,
                              number_of_accounts                     AS accountcount_fatca203,
                              cast(round(amount_in_usd, 2) AS FLOAT) AS poolbalance_fatca203,
                              ''                                     AS accountcount_fatca204,
                              ''                                     AS poolbalance_fatca204,
                              ''                                     AS accountcount_fatca205,
                              ''                                     AS poolbalance_fatca205,
                              ''                                     AS accountcount_fatca206,
                              ''                                     AS poolbalance_fatca206,
                              ''                                     AS sign_w8,
                              ''                                     AS sign_w9
                       FROM   art.art_fatca_dormant_accounts_summary
                       UNION ALL
                       SELECT    customer_info.cust_no AS accountnumber,
                                 account.closed        AS accountclosed,
                                 adrs.res_country      AS countrycode,
                                 CASE xyz.tin_no
                                           WHEN NULL THEN '000-00-0000'
                                           ELSE xyz.tin_no
                                 END                       AS tin,
                                 customer_info.middle_name AS middlename,
                                 customer_info.first_name  AS firstname,
                                 customer_info.last_name   AS lastname,
                                 adrs.current_adrs_country AS countrycodeadd,
                                 adrs.current_adrs         AS addressfree_i,
                                 adrs.current_adrs         AS addressfree_e,
                                 --CUSTOMER_INFO.BIRTH_DATE AS BIRTHDATE,
                                 ''                                                AS birthdate,
                                 customer_info.main_nat                            AS nationality,
                                 cast(round(account.customer_balance, 2) AS FLOAT) AS accountbalance,
                                 CASE a.case_type_cd
                                           WHEN 'FATCA_ENTITY' THEN 'FATCA101'
                                           WHEN 'FATCA_INDV' THEN ''
                                           ELSE ''
                                 END AS accountholdertype,
                                 CASE a.case_type_cd
                                           WHEN 'FATCA_INDV' THEN '1'
                                           ELSE '2'
                                 END                                                   AS accounttype,
                                 ''                                                    AS owner_first_name,
                                 ''                                                    AS owner_last_name,
                                 ''                                                    AS owner_tin,
                                 ''                                                    AS owner_res_country_code,
                                 ''                                                    AS owner_address,
                                 cast(round(account.customer_dividend, 2) AS FLOAT)    AS paymentamnt_501,
                                 cast(round(account.customer_interest, 2) AS FLOAT)    AS paymentamnt_502,
                                 cast(round(account.customer_cross, 2) AS FLOAT)       AS paymentamnt_503,
                                 cast(round(account.customer_other_pymnt, 2) AS FLOAT) AS paymentamnt_504,
                                 ''                                                    AS accountcount_fatca201,
                                 ''                                                    AS poolbalance_fatca201,
                                 ''                                                    AS accountcount_fatca202,
                                 ''                                                    AS poolbalance_fatca202,
                                 cast(round(0, 2) AS FLOAT)                            AS accountcount_fatca203,
                                 cast(round(0, 2) AS FLOAT)                            AS poolbalance_fatca203,
                                 ''                                                    AS accountcount_fatca204,
                                 ''                                                    AS poolbalance_fatca204,
                                 ''                                                    AS accountcount_fatca205,
                                 ''                                                    AS poolbalance_fatca205,
                                 ''                                                    AS accountcount_fatca206,
                                 ''                                                    AS poolbalance_fatca206,
                                 xyz.sign_w8,
                                 xyz.sign_w9
                       FROM      case_live@dgcmgmt a
                       left join personal_info@fagpdb customer_info
                       ON        substr(a.case_id,7, length(a.case_id)) = customer_info.cust_no
                       AND       customer_info.change_current_ind='Y'
                       left join address_info@fagpdb adrs
                       ON        customer_info.cust_key = adrs.cust_key
                       AND       adrs.change_current_ind='Y'
                       left join customer_accounts_summary@fagpdb account
                       ON        account.cust_no=customer_info.cust_no
                       left join fatca_info@fagpdb xyz
                       ON        customer_info.cust_key = xyz.cust_key
                       AND       xyz.change_current_ind='Y'
                       WHERE
                                 --case_stat_cd = 'C_W9' and
                                 --Case_Rk in (select max(case_rk) from case_live@dgcmgmt group by Col2)
                                 customer_info.main_nat='US'
                       AND       trunc(customer_info.create_date) < '01-jan-2022' ) ;
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
