using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations.ArtGoAml
{
    public partial class ArtDgAmlReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            #region Views
            migrationBuilder.Sql($@"
            
                            CREATE OR ALTER view [ART_DB].[ART_DGAML_TRIAGE_VIEW] AS
                            select ASO.Alarmed_Obj_Name ALERTED_ENTITY_NAME
                            , ASO.Alarmed_Obj_No ALERTED_ENTITY_NUMBER ,
                            ASO.Branch BRANCH_NAME, 
                            ASO.Risk_Score_Cd RISK_SCORE ,
                            ASO.Suspect_Queue QUEUE_CODE, 
                            ASO.Owner_UID OWNER_USERID, 
                            ALERTED_ENTITY_LEVEL.LKP_Val_Desc ALERTED_ENTITY_LEVEL,
                            ASO.Agg_Amt AGGREGATE_AMT ,
                            ASO.Age_Old_Alarm AGE_OLDEST_ALERT ,
                            ASO.Alarms_Count ALERTS_CNT_SUM
                            from DGAML.AC.AC_Suspected_Object ASO
                            left join DGAML.AC.AC_LKP_Table ALERTED_ENTITY_LEVEL ON ALERTED_ENTITY_LEVEL.LKP_Val_Cd = ASO.Alarmed_Obj_level_Cd 
                            AND ALERTED_ENTITY_LEVEL.LKP_Val_Cd='PTY' AND ALERTED_ENTITY_LEVEL.LKP_Lang_Desc = 'en' 
                            where ASO.Prod_Type = 'AML'
                            and ASO.Alarmed_Obj_level_Cd = 'PTY'
                            and ASO.Alarms_Count > 0 ;
                            GO

            ");

            migrationBuilder.Sql($@"


                                    CREATE OR ALTER view [ART_DB].[ART_DGAML_ALERT_DETAIL_VIEW] AS
                                    select 
                                    aa.alarm_id, 
                                    aa.Alarmed_Obj_No ALERTED_ENTITY_NUMBER, 
                                    aa.alarmed_obj_name ALERTED_ENTITY_NAME, 
                                    aa.alarm_desc ALERT_DESCRIPTION, 
                                    aa.Actual_Value_Txt ACTUAL_VALUES_TEXT, 
                                    ba.Acct_Prim_Branch_Name BRANCH_NAME,
                                    aa.Routine_Id SCENARIO_ID, 
                                    aa.Routine_Name SCENARIO_NAME, 
                                    aa.Ml_Risk_Score MONEY_LAUNDERING_RISK_SCORE,
                                    alarm_cat.LKP_Val_Desc alert_category,
                                    alarm_subcat.LKP_Val_Desc alert_subcategory,
                                    alarm_status.LKP_Val_Desc alert_status,
                                    aa.Create_Date, 
                                    aa.Run_Date, 
                                    --ASO.Owner_UID, 
                                    c.Political_Exp_Prsn_Ind POLITICALLY_EXPOSED_PERSON_IND,
                                    aa.Emp_Ind, 
                                    AEV.Create_User_Id Closed_USER_ID,
                                    users.UserName close_user_Name,
                                    NULL close_date,
                                    '' close_reason,
                                    (datediff(day,aa.CREATE_DATE,getdate())) Investigation_Days
                                    from 
                                    DGAML.ac.ac_alarm aa
                                    --left join ac.AC_Suspected_Object ASO on aa.alarmed_obj_name = ASO.Alarmed_Obj_No
                                    left join
                                    DGAML.DGAMLCORE.Customer c on aa.Alarmed_Obj_No = c.Cust_No and c.Chg_Current_Ind ='Y'
                                    left join 
                                    (select 
                                    a.*,b.Acct_Open_Date,b.Acct_Prim_Branch_Name,row_number() over (PARTITION by a.cust_no order by b.Acct_Open_Date asc) Rank
                                    from DGAML.DGAMLCORE.Customer_X_Account a left join DGAML.DGAMLCORE.Account b on a.Acct_No= b.Acct_No
                                    where a.Role_Key=1 and a.Chg_Current_Ind='Y') ba on c.cust_no = ba.Cust_No and ba.RANK = 1
                                    left join
                                    (select distinct aae.Alarm_Id, aae.Create_User_Id, aae.Create_Date, aae.Event_Desc, row_number() over (PARTITION by aae.Alarm_Id order by aae.CREATE_DATE desc) Rank
                                    from  DGAML.ac.ac_alarm_event aae
                                    WHERE aae.Event_Type_Cd ='CLS') AEV on aa.alarm_id = AEV.alarm_id and AEV.Rank=1
                                    left join [DG_AML_ADMIN].[DG_AML_ADMIN].[User] users on AEV.Create_User_Id = users.id
                                      left join DGAML.AC.AC_LKP_Table alarm_cat on lower(aa.Alarm_Categ_Cd)=lower(alarm_cat.LKP_Val_Cd) and alarm_cat.LKP_Lang_Desc='en' 
                                      and alarm_cat.LKP_Name = 'ALARM_CATEGORY'
                                      left join DGAML.AC.AC_LKP_Table alarm_subcat on lower(aa.Alarm_Subcateg_Cd)=lower(alarm_subcat.LKP_Val_Cd) and alarm_subcat.LKP_Lang_Desc='en' 
                                      and alarm_subcat.LKP_Name = 'ALARM_SUBCATEGORY'
                                       left join DGAML.AC.AC_LKP_Table alarm_status on lower(aa.Alarm_Status_Cd)=lower(alarm_status.LKP_Val_Cd) and alarm_status.LKP_Lang_Desc='en' 
                                      and alarm_status.LKP_Name = 'ALARM_STATUS'
                                    where aa.Prod_Type = 'AML' and aa.Alarm_Status_Cd = 'ACT'

                                    UNION 

                                    select 
                                    aa.alarm_id, 
                                    aa.Alarmed_Obj_No ALERTED_ENTITY_NUMBER, 
                                    aa.alarmed_obj_name ALERTED_ENTITY_NAME, 
                                    aa.alarm_desc ALERT_DESCRIPTION, 
                                    aa.Actual_Value_Txt ACTUAL_VALUES_TEXT, 
                                    ba.Acct_Prim_Branch_Name BRANCH_NAME,
                                    aa.Routine_Id SCENARIO_ID, 
                                    aa.Routine_Name SCENARIO_NAME, 
                                    aa.Ml_Risk_Score MONEY_LAUNDERING_RISK_SCORE,
                                    alarm_cat.LKP_Val_Desc alert_category,
                                    alarm_subcat.LKP_Val_Desc alert_subcategory,
                                    alarm_status.LKP_Val_Desc alert_status,
                                    aa.Create_Date, 
                                    aa.Run_Date, 
                                    --ASO.Owner_UID, 
                                    c.Political_Exp_Prsn_Ind POLITICALLY_EXPOSED_PERSON_IND,
                                    aa.Emp_Ind, 
                                    AEV.Create_User_Id Closed_USER_ID,
                                    users.UserName close_user_Name,
                                    AEV.Create_Date close_date,
                                    AEV.Event_Desc close_reason,
                                    (datediff(day,aa.Run_Date,isnull(AEV.CREATE_DATE,getdate()))) Investigation_Days
                                    from 
                                    DGAML.ac.ac_alarm aa
                                    --left join ac.AC_Suspected_Object ASO on aa.alarmed_obj_name = ASO.Alarmed_Obj_No
                                    left join
                                    DGAML.DGAMLCORE.Customer c on aa.Alarmed_Obj_No = c.Cust_No and c.Chg_Current_Ind ='Y'
                                    left join 
                                    (select 
                                    a.*,b.Acct_Open_Date,b.Acct_Prim_Branch_Name,row_number() over (PARTITION by a.cust_no order by b.Acct_Open_Date asc) Rank
                                    from DGAML.DGAMLCORE.Customer_X_Account a left join DGAML.DGAMLCORE.Account b on a.Acct_No= b.Acct_No
                                    where a.Role_Key=1 and a.Chg_Current_Ind='Y') ba on c.cust_no = ba.Cust_No and ba.RANK = 1
                                    left join
                                    (select distinct aae.Alarm_Id, aae.Create_User_Id, aae.Create_Date, aae.Event_Desc, row_number() over (PARTITION by aae.Alarm_Id order by aae.CREATE_DATE desc) Rank
                                    from  DGAML.ac.ac_alarm_event aae
                                    WHERE aae.Event_Type_Cd ='CLS') AEV on aa.alarm_id = AEV.alarm_id and AEV.Rank=1
                                    left join [DG_AML_ADMIN].[DG_AML_ADMIN].[User] users on AEV.Create_User_Id = users.id
                                      left join DGAML.AC.AC_LKP_Table alarm_cat on lower(aa.Alarm_Categ_Cd)=lower(alarm_cat.LKP_Val_Cd) and alarm_cat.LKP_Lang_Desc='en' 
                                      and alarm_cat.LKP_Name = 'ALARM_CATEGORY'
                                      left join DGAML.AC.AC_LKP_Table alarm_subcat on lower(aa.Alarm_Subcateg_Cd)=lower(alarm_subcat.LKP_Val_Cd) and alarm_subcat.LKP_Lang_Desc='en' 
                                      and alarm_subcat.LKP_Name = 'ALARM_SUBCATEGORY'
                                       left join DGAML.AC.AC_LKP_Table alarm_status on lower(aa.Alarm_Status_Cd)=lower(alarm_status.LKP_Val_Cd) and alarm_status.LKP_Lang_Desc='en' 
                                      and alarm_status.LKP_Name = 'ALARM_STATUS'
                                    where aa.Prod_Type = 'AML' and aa.Alarm_Status_Cd <> 'ACT'
                                    ;


                                    GO



");

            migrationBuilder.Sql($@"  CREATE OR ALTER view [ART_DB].[ART_DGAML_CASE_DETAIL_VIEW] AS
                                          SELECT 
                                        [CASE].CASE_ID,
                                        [CASE].Cust_Full_Name ENTITY_NAME,
                                        entity_number.Udf_Val ENTITY_NUMBER,
                                        ba.Acct_Prim_Branch_Name BRANCH_NAME,
                                        [CASE_PRIORITY].Val_Desc CASE_PRIORITY,
                                        [CASE].Case_Stat_Cd CASE_STATUS_CODE,
                                        CASE_STATUS.Val_Desc CASE_STATUS,
                                        [CASE].Case_Ctgry_Cd CASE_CATEGORY_CODE,
                                        CASE_CATEGORY.Val_Desc CASE_CATEGORY,
                                        [CASE].Case_Sub_Ctgry_Cd CASE_SUB_CATEGORY_CODE,
                                        --""CASE_SUBCATEGORY"".LOV_TYPE_DESC ""CASE_SUB_CATEGORY"",
                                        entity_level.Udf_Val ENTITY_LEVEL,
                                        [CASE].CREATE_USER_ID CREATED_BY, 
                                        --[CASE].OWNER_USER_LONG_ID ""OWNER"",
                                        [CASE].CREATE_DATE
                                        --'' Closed_Date

                                        FROM DGECM.DGCmgmt.Case_Live [CASE] LEFT JOIN
                                        DGECM.DGCmgmt.Ref_Table_Val CASE_STATUS ON CASE_STATUS.Val_Cd = [CASE].Case_Stat_Cd
                                        AND CASE_STATUS.Ref_Table_Name ='FCF_CASE_STATUS' --AND CASE_STATUS.LOV_LANGUAGE_DESC ='en'
                                        left join
                                        DGECM.DGCmgmt.Ref_Table_Val CASE_CATEGORY ON CASE_CATEGORY.Val_Cd = [CASE].Case_Ctgry_Cd
                                        AND CASE_CATEGORY.Ref_Table_Name ='RT_CASE_CATEGORY' --AND CASE_STATUS.LOV_LANGUAGE_DESC ='en'
                                        left join
                                        DGECM.DGCmgmt.Ref_Table_Val CASE_PRIORITY ON CASE_PRIORITY.Val_Cd = [CASE].Priority_Cd
                                        AND CASE_PRIORITY.Ref_Table_Name ='X_RT_PRIORITY' --AND CASE_STATUS.LOV_LANGUAGE_DESC ='en'
                                        LEFT JOIN DGECM.DGCmgmt.Case_Udf_Char_Val entity_level on [CASE].Case_Rk = entity_level.Case_Rk
                                        and entity_level.Udf_Name='AML_ALARMED_OBJ_LEVEL_CD' and entity_level.Udf_Table_Name = 'DGAML_OBJECT_CASE' 
                                        LEFT JOIN DGECM.DGCmgmt.Case_Udf_Char_Val entity_number on [CASE].Case_Rk = entity_number.Case_Rk
                                        and entity_number.Udf_Name='AML_ALARMED_OBJ_NO' and entity_number.Udf_Table_Name = 'DGAML_OBJECT_CASE' 
                                        left join DGAML.DGAMLCORE.Customer c on c.Cust_No = entity_number.Udf_Val COLLATE Arabic_100_CI_AI
                                        left join 
                                        (select 
                                        a.*,b.Acct_Open_Date,b.Acct_Prim_Branch_Name,row_number() over (PARTITION by a.cust_no order by b.Acct_Open_Date asc) Rank
                                        from DGAML.DGAMLCORE.Customer_X_Account a left join DGAML.DGAMLCORE.Account b on a.Acct_No= b.Acct_No
                                        where a.Role_Key=1 and a.Chg_Current_Ind='Y') ba on c.cust_no = ba.Cust_No and ba.RANK = 1
                                        WHERE
                                        [CASE].Case_Type_Cd='DGAML'
                                        --AND CASE_STATUS.Val_Desc ='Open'
                                        --AND ENTITY_LEVEL.LOV_TYPE_DESC <> 'Account'
                                        ;
                                        GO");

            migrationBuilder.Sql($@"

                    CREATE OR ALTER VIEW [ART_DB].[ART_DGAML_CUSTOMER_DETAIL_VIEW]  AS
                     SELECT        
                    c.Cust_Name customer_name,
                    c.Cust_No customer_number,
                    c.Cust_Type_Desc customer_type,
                    c.Cust_Ident_Id customer_identification_id,
                    c.Cust_Ident_Type_Desc customer_identification_type, 
                    c.Cust_Birth_Date customer_date_of_birth,
                    c.Risk_Class RISK_CLASSIFICATION,
                    c.Cust_Tax_Id Customer_Tax_ID,
                    c.Do_Bus_As_Name DOING_BUSINESS_AS_NAME,
                    c.State_Name Governorate_name,
                    c.Addr_1 street_address_1,
                    c.City_Name City_name,
                    c.Cust_Status_Desc Customer_status,
                    c.Post_Cd STREET_POSTAL_CODE,
                    c.Cntry_Cd STREET_COUNTRY_CODE,
                    c.Cntry_name STREET_COUNTRY_NAME,
                    c.Mail_Addr_1 MAILING_ADDRESS_1,
                    c.Mail_City_Name MAILING_CITY_NAME,
                    c.Mail_Post_Cd MAILING_POSTAL_CODE,
                    c.Mail_Cntry_Name MAILING_COUNTRY_NAME,
                    c.Resid_Cntry_Name RESIDENCE_COUNTRY_NAME,
                    c.Citizen_Cntry_Name CITIZENSHIP_COUNTRY_NAME,
                    c.Emp_Ind Is_EMPLOYEE,
                    c.Emp_No EMPLOYEE_NUMBER,
                    c.Empr_Name EMPLOYER_NAME,
                    c.Empr_Tel_No EMPLOYER_PHONE_NUMBER,
                    c.Email_Addr EMAIL_ADDRESS,
                    c.Occup_Desc occupation_desc,
                    c.Inds_Desc industry_desc, 
                    c.Tel_No_1 PHONE_NUMBER_1, 
                    c.Tel_No_2 PHONE_NUMBER_2, 
                    c.Tel_No_3 PHONE_NUMBER_3, 
                    c.Annual_Income_Amt ANNUAL_INCOME_AMOUNT,
                    c.Net_Worth_Amt NET_WORTH_AMOUNT,
                    c.MARITAL_STATUS_DESC,
                    c.Cust_Since_Date CUSTOMER_SINCE_DATE, 
                    c.Lst_Risk_Assmnt_Date LAST_RISK_ASSESSMENT_DATE,    
                    c.non_profit_org_ind,
                    c.Political_Exp_Prsn_Ind politically_exposed_person_ind,
                    --Risk.ACTIVE_FLG,
                    ba.Acct_Prim_Branch_Name BRANCH_NAME 
                    FROM            
                    DGAML.DGAMLCORE.Customer c 
                    left join 
                    (select 
                    a.*,b.Acct_Open_Date,b.Acct_Prim_Branch_Name,row_number() over (PARTITION by a.cust_no order by b.Acct_Open_Date asc) Rank
                    from DGAML.DGAMLCORE.Customer_X_Account a left join DGAML.DGAMLCORE.Account b on a.Acct_No= b.Acct_No
                    where a.Role_Key=1 and a.Chg_Current_Ind='Y') ba on c.cust_no = ba.Cust_No and ba.RANK = 1
                    WHERE (c.Cust_Key > - 1 and c.Chg_Current_Ind = 'Y');
                    GO



");
            #endregion

            #region Procs
            migrationBuilder.Sql($@"CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_DGAML_ALERT_PER_OWNER]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

select (case when a.OWNER_QUEUE is null then 'UNKNOWN' else a.OWNER_QUEUE end) AS OWNER_QUEUE,
CAST(count(distinct Alarm_Id) AS DECIMAL(10, 0)) AS ALERTS_CNT_SUM 
from (
select AC_Object_Queue.Owner_UID OWNER_QUEUE, Alarm_Id
from DGAML.ac.ac_alarm aa
left join DGAML.AC.AC_Object_Queue on aa.Alarmed_Obj_No = AC_Object_Queue.Alarmed_Obj_No 
and aa.Prod_Type = 'AML' and aa.Alarm_Status_Cd = 'ACT'
where CAST(create_date AS date) >= @V_START_DATE AND CAST(create_date AS date) <= @V_END_DATE
union

select AC_Object_Queue.Queue_CD OWNER_QUEUE ,Alarm_Id
from DGAML.ac.ac_alarm aa
left join DGAML.AC.AC_Object_Queue on aa.Alarmed_Obj_No = AC_Object_Queue.Alarmed_Obj_No
and aa.Prod_Type = 'AML' and aa.Alarm_Status_Cd = 'ACT'
where CAST(create_date AS date) >= @V_START_DATE AND CAST(create_date AS date) <= @V_END_DATE
    ) a
    GROUP BY
        (case when a.OWNER_QUEUE is null then 'UNKNOWN' else a.OWNER_QUEUE end);
END ;
GO");

            migrationBuilder.Sql($@"CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_DGAML_ALERTS_PER_STATUS]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

select  alarm_status.LKP_Val_Desc ALERT_STATUS,
CAST(count(aa.Alarm_Id) AS DECIMAL(10, 0)) ALERTS_COUNT
 from 
DGAML.ac.ac_alarm aa
  left join DGAML.AC.AC_LKP_Table alarm_status on lower(aa.Alarm_Status_Cd)=lower(alarm_status.LKP_Val_Cd) and alarm_status.LKP_Lang_Desc='en' 
  and alarm_status.LKP_Name = 'ALARM_STATUS'
where aa.Prod_Type = 'AML'
and  CAST(aa.create_date AS date) >= @V_START_DATE AND CAST(aa.create_date AS date) <= @V_END_DATE
group by alarm_status.LKP_Val_Desc;
END ;
GO");

            migrationBuilder.Sql($@"CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_DGAML_CUSTOMER_PER_BRANCH]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

SELECT   ba.Acct_Prim_Branch_Name BRANCH_NAME,  
CAST(count(c.Cust_Key) AS DECIMAL(10, 0))NUMBER_OF_CUSTOMERS
FROM            
DGAML.DGAMLCORE.Customer c 
left join 
(select 
a.*,b.Acct_Open_Date,b.Acct_Prim_Branch_Name,row_number() over (PARTITION by a.cust_no order by b.Acct_Open_Date asc) Rank
from DGAML.DGAMLCORE.Customer_X_Account a left join DGAML.DGAMLCORE.Account b on a.Acct_No= b.Acct_No
where a.Role_Key=1 and a.Chg_Current_Ind='Y') ba on c.cust_no = ba.Cust_No and ba.RANK = 1
WHERE (c.Cust_Key > - 1 and c.Chg_Current_Ind = 'Y')
and CAST(c.Cust_Since_Date AS date) >= @V_START_DATE AND CAST(c.Cust_Since_Date AS date) <= @V_END_DATE
group by ba.Acct_Prim_Branch_Name;
END ;
GO");

            migrationBuilder.Sql($@"CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_DGAML_CUSTOMER_PER_TYPE]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

SELECT 
(case when Cust_Type_Desc is null then 'UNKNOWN'
when Cust_Type_Desc =' 'then 'UNKNOWN'
else Cust_Type_Desc
end
)CUSTOMER_TYPE,
CAST(count(*) AS DECIMAL(10, 0))NUMBER_OF_CUSTOMERS
FROM            
DGAML.DGAMLCORE.Customer c 
WHERE (c.Cust_Key > - 1 and c.Chg_Current_Ind = 'Y')
and CAST(c.Cust_Since_Date AS date) >= @V_START_DATE AND CAST(c.Cust_Since_Date AS date) <= @V_END_DATE
group by Cust_Type_Desc;
END;
GO");

            migrationBuilder.Sql($@"CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_DGAML_CASES_PER_CATEGORY]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

select 
""CASE_CATEGORY"".Val_Desc CASE_CATEGORY ,CAST(count(1) AS DECIMAL(10, 0))NUMBER_OF_CASES
FROM DGECM.DGCmgmt.Case_Live ""CASE""
left join
DGECM.DGCmgmt.Ref_Table_Val CASE_CATEGORY ON CASE_CATEGORY.Val_Cd = ""CASE"".Case_Ctgry_Cd
AND CASE_CATEGORY.Ref_Table_Name ='RT_CASE_CATEGORY'
WHERE CAST(create_date AS date) >= @V_START_DATE AND CAST(create_date AS date) <= @V_END_DATE
AND ""CASE"".Case_Type_Cd='DGAML'
GROUP BY --CASE_CATEGORY
""CASE_CATEGORY"".Val_Desc
;
END;
GO");

            migrationBuilder.Sql($@"  CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_DGAML_CASES_PER_PRIORITY]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

select 
""CASE_PRIORITY"".Val_Desc CASE_PRIORITY ,CAST(count(1) AS DECIMAL(10, 0))NUMBER_OF_CASES
FROM DGECM.DGCmgmt.Case_Live ""CASE""
left join
DGECM.DGCmgmt.Ref_Table_Val CASE_PRIORITY ON CASE_PRIORITY.Val_Cd = ""CASE"".Priority_Cd
AND CASE_PRIORITY.Ref_Table_Name ='X_RT_PRIORITY'
WHERE CAST(create_date AS date) >= @V_START_DATE AND CAST(create_date AS date) <= @V_END_DATE
AND ""CASE"".Case_Type_Cd='DGAML'
GROUP BY 
""CASE_PRIORITY"".Val_Desc
;
END;
GO");

            migrationBuilder.Sql($@"  CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_DGAML_CASES_PER_STATUS]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

select 
""CASE_STATUS"".Val_Desc CASE_STATUS ,CAST(count(1) AS DECIMAL(10, 0))NUMBER_OF_CASES 
FROM DGECM.DGCmgmt.Case_Live ""CASE""
left join
DGECM.DGCmgmt.Ref_Table_Val CASE_STATUS ON CASE_STATUS.Val_Cd = ""CASE"".Case_Stat_Cd
AND CASE_STATUS.Ref_Table_Name ='FCF_CASE_STATUS'
WHERE CAST(create_date AS date) >= @V_START_DATE AND CAST(create_date AS date) <= @V_END_DATE
AND ""CASE"".Case_Type_Cd='DGAML'
GROUP BY --CASE_CATEGORY
""CASE_STATUS"".Val_Desc
;
END;
GO");
            #endregion

            #region Views
            //ART_SCENARIO_ADMIN_VIEW
            migrationBuilder.Sql($@"
            create view [ART_DB].[ART_SCENARIO_ADMIN_VIEW] as (
                            select 
                            a.Routine_Name SCENARIO_NAME,a.Routine_Short_Desc SCENARIO_SHORT_DESC,a.Routine_Desc SCENARIO_DESC,b.LKP_Val_Desc SCENARIO_STATUS
                            ,C.LKP_Val_Desc SCENARIO_CATEGORY,D.LKP_Val_Desc PRODUCT_TYPE,A.Risk_Fact_Ind RISK_FACT,CREATE_DATE,A.END_DATE,A.CREATE_USER_ID,
                            E.LKP_Val_Desc SCENARIO_TYPE,F.LKP_Val_Desc SCENARIO_FREQUENCY,A.Routine_Msg_Txt SCENARIO_MESSAGE,G.LKP_Val_Desc OBJECT_LEVEL
                            ,H.LKP_Val_Desc ALARM_TYPE,I.LKP_Val_Desc ALARM_CATEGORY,J.LKP_Val_Desc ALARM_SUBCATEGORY,a.corresponding_view_NM DEPENDED_DATA
                            ,PARA.PARM_NAME,PARA.PARM_VALUE,PARA.PARM_DESC,PARA.PARM_TYPE_DESC,PARA.PARAM_CONDITION,scor.PARM_NAME SCOR_PARM_NAME,scor.DEPEND_ATTRIBUTE SCOR_DEPEND_ATTRIBUTE
                            from
                            DGAML.ac.AC_Routine a left join DGAML.ac.AC_LKP_Table b on a.Routine_Status_Cd = b.LKP_Val_Cd and b.LKP_Name='SCENARIO_STATUS' and b.LKP_Lang_Desc='en'
                            left join DGAML.ac.AC_LKP_Table C on a.Routine_Categ_Cd = C.LKP_Val_Cd and C.LKP_Name='SCENARIO_CATEGORY' and C.LKP_Lang_Desc='en'
                            left join DGAML.ac.AC_LKP_Table D on a.Prod_Type_Cd = D.LKP_Val_Cd and D.LKP_Name='PRODUCT_TYPE' and D.LKP_Lang_Desc='en'
                            left join DGAML.ac.AC_LKP_Table E on a.Routine_Type_Cd = E.LKP_Val_Cd and E.LKP_Name='SCENARIO_TYPE' and E.LKP_Lang_Desc='en'
                            left join DGAML.ac.AC_LKP_Table F on a.Routine_Run_Freq_Cd = F.LKP_Val_Cd and F.LKP_Name='SCENARIO_FREQUENCY' and F.LKP_Lang_Desc='en'
                            left join DGAML.ac.AC_LKP_Table G on a.Obj_Level_Cd = G.LKP_Val_Cd and G.LKP_Name='OBJECT_LEVEL' and G.LKP_Lang_Desc='en'
                            left join DGAML.ac.AC_LKP_Table H on a.Alarm_Type_Cd = H.LKP_Val_Cd and H.LKP_Name='ALARM_TYPE' and H.LKP_Lang_Desc='en'
                            left join DGAML.ac.AC_LKP_Table I on a.Alarm_Categ_Cd = I.LKP_Val_Cd and I.LKP_Name='ALARM_CATEGORY' and I.LKP_Lang_Desc='en'
                            left join DGAML.ac.AC_LKP_Table J on a.Alarm_Subcateg_Cd = J.LKP_Val_Cd and J.LKP_Name='ALARM_SUBCATEGORY' and J.LKP_Lang_Desc='en'
                            LEFT JOIN DGAML.AC.AC_Routine_Parameter PARA ON A.Routine_Id = PARA.Routine_Id
                            left join DGAML.ac.AC_Scoring_Rules scor on a.Routine_Id = scor.Routine_Id
                            )
                            ;");
            //ART_SCENARIO_HISTORY_VIEW
            migrationBuilder.Sql($@"
            CREATE VIEW [ART_DB].[ART_SCENARIO_HISTORY_VIEW] AS
                        SELECT * FROM
                        (SELECT 
                        r.Routine_Name
                        ,r.Routine_Short_Desc
                        ,Event_Desc
                        ,e.Create_Date
                        ,e.Create_User_Id
                        FROM [DGAML].[AC].[AC_Scenario_Event] e
                        left join [DGAML].[AC].[AC_Routine] r 
                        on r.root_key = e.Scenario_Root_Key and r.Routine_Id = e.Scenario_Root_Key
                        order by Scenario_Root_Key , e.Create_Date asc OFFSET 0 ROWS) A;");
            //ART_SUSPECT_DETAIL_VIEW
            migrationBuilder.Sql($@"
            create view  [ART_DB].[ART_SUSPECT_DETAIL_VIEW] as 
                            select 
                            a.Alarmed_Obj_No SUSPECT_NUMBER,
                            a.Alarmed_Obj_Name SUSPECT_NAME,
                            ba.Acct_Prim_Branch_Name BRANCH_NAME,
                            a.Risk_Score_Cd PROFILE_RISK,
                            a.Alarms_Count NUMBER_OF_ALARMS,
                            a.Age_Old_Alarm AGE_OF_OLDEST_ALERT,
                            a.Owner_UID OWNER_USER_ID,
                            c.Cust_Birth_Date,
                            c.Political_Exp_Prsn_Ind,
                            c.Risk_Class risk_classification,
                            c.Citizen_Cntry_Name,
                            c.Cust_Ident_Id,
                            c.Cust_Ident_Type_Desc,
                            c.Cust_Ident_Exp_Date,
                            c.Cust_Ident_Iss_Date,
                            c.Empr_Name,
                            c.Occup_Desc,
                            c.Tel_No_1,
                            c.Cust_Since_Date
                            from DGAML.ac.AC_Suspected_Object a
                            LEFT JOIN DGAML.DGAMLCORE.Customer C ON a.Alarmed_Obj_No = c.Cust_No and c.Chg_Current_Ind ='Y'
                            left join 
                            (select 
                            a.*,b.Acct_Open_Date,b.Acct_Prim_Branch_Name,row_number() over (PARTITION by a.cust_no order by b.Acct_Open_Date asc) Rank
                            from DGAML.DGAMLCORE.Customer_X_Account a left join DGAML.DGAMLCORE.Account b on a.Acct_No= b.Acct_No
                            where a.Role_Key=1 and a.Chg_Current_Ind='Y') ba on c.cust_no = ba.Cust_No and ba.RANK = 1;");
            //ART_EXTERNAL_CUSTOMER_DETAIL_VIEW
            migrationBuilder.Sql($@"
            create view [ART_DB].[ART_EXTERNAL_CUSTOMER_DETAIL_VIEW] as
                        SELECT        
                        e.Ext_Full_Name customer_name,
                        e.Ext_Cust_No customer_number,
                        e.Ext_Cust_Type_Desc customer_type,
                        e.Ident_Id customer_identification_id,
                        e.Ident_Type_Desc customer_identification_type, 
                        e.Ext_Birth_Date customer_date_of_birth,
                        e.Cust_Tax_Id Customer_Tax_ID,
                        e.State_Name Governorate_name,
                        e.Addr_1 street_address_1,
                        e.City_Name City_name,
                        e.Post_Cd STREET_POSTAL_CODE,
                        e.Cntry_Cd STREET_COUNTRY_CODE,
                        e.Cntry_name STREET_COUNTRY_NAME,
                        e.Resid_Cntry_Name RESIDENCE_COUNTRY_NAME,
                        e.Citizen_Cntry_Name CITIZENSHIP_COUNTRY_NAME,
                        e.Tel_No_1 PHONE_NUMBER_1, 
                        e.Tel_No_2 PHONE_NUMBER_2, 
                        --e.Cust_Since_Date CUSTOMER_SINCE_DATE, 
                        e.Branch_Name BRANCH_NAME,
                        e.Create_Date CREATE_DATE
                        FROM            
                        DGAML.DGAMLCORE.External_Customer e
                        WHERE (e.Ext_Cust_Acct_Key > - 1);");
            #endregion
            #region Procs
            //ART_ST_EXTERNAL_CUSTOMER_PER_BRANCH
            migrationBuilder.Sql($@"
            CREATE PROCEDURE [ART_DB].[ART_ST_EXTERNAL_CUSTOMER_PER_BRANCH]
                                (
                                @V_START_DATE date , @V_END_DATE date
                                ) AS 
                                BEGIN
                                SET NOCOUNT ON;

                                SELECT 
                                (case when Branch_Name is null then 'UNKNOWN'
                                when Branch_Name =' 'then 'UNKNOWN'
                                else Branch_Name
                                end
                                )BRANCH_NAME, CAST(count(*) AS decimal) NUMBER_OF_CUSTOMERS
                                FROM            
                                DGAML.DGAMLCORE.External_Customer c 
                                WHERE (c.Ext_Cust_Acct_Key > - 1)
                                and CAST(c.Create_Date AS date) >= @V_START_DATE AND CAST(c.Create_Date AS date) <= @V_END_DATE
                                group by BRANCH_NAME;
                                END;
                                GO");
            //ART_ST_EXTERNAL_CUSTOMER_PER_TYPE
            migrationBuilder.Sql($@"
            CREATE PROCEDURE [ART_DB].[ART_ST_EXTERNAL_CUSTOMER_PER_TYPE]
                                (
                                @V_START_DATE date , @V_END_DATE date
                                ) AS 
                                BEGIN
                                SET NOCOUNT ON;

                                SELECT 
                                (case when Ext_Cust_Type_Desc is null then 'UNKNOWN'
                                when Ext_Cust_Type_Desc =' 'then 'UNKNOWN'
                                else Ext_Cust_Type_Desc
                                end
                                )customer_type, cast(count(*) as decimal)  NUMBER_OF_CUSTOMERS
                                FROM            
                                DGAML.DGAMLCORE.External_Customer c 
                                WHERE (c.Ext_Cust_Acct_Key > - 1)
                                and CAST(c.Create_Date AS date) >= @V_START_DATE AND CAST(c.Create_Date AS date) <= @V_END_DATE
                                group by Ext_Cust_Type_Desc;
                                END;
                                GO");
            #endregion

            #region Procs
            //ART_ST_ALERTS_PER_BRANCH
            migrationBuilder.Sql($@"
            CREATE PROCEDURE [ART_DB].[ART_ST_ALERTS_PER_BRANCH]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                            select COALESCE(ba.Acct_Prim_Branch_Name, 'Unknown') BRANCH_NAME,
                            cast(count(aa.Alarm_Id) as decimal) Alerts_Count  from 
                            DGAML.ac.ac_alarm aa
                              left join
                            DGAML.DGAMLCORE.Customer c on aa.Alarmed_Obj_No = c.Cust_No and c.Chg_Current_Ind ='Y'
                            left join 
                            (select 
                            a.*,b.Acct_Open_Date,b.Acct_Prim_Branch_Name,row_number() over (PARTITION by a.cust_no order by b.Acct_Open_Date asc) Rank
                            from DGAML.DGAMLCORE.Customer_X_Account a left join DGAML.DGAMLCORE.Account b on a.Acct_No= b.Acct_No
                            where a.Role_Key=1 and a.Chg_Current_Ind='Y') ba on c.cust_no = ba.Cust_No and ba.RANK = 1
                            where aa.Prod_Type = 'AML' 
                             --and aa.Alarm_Status_Cd = 'ACT'
                            and  CAST(aa.create_date AS date) >= @V_START_DATE AND CAST(aa.create_date AS date) <= @V_END_DATE
                            group by ba.Acct_Prim_Branch_Name;
                            END ;");
            //ART_ST_ALERTS_PER_SCENARIO
            migrationBuilder.Sql($@"
             CREATE PROCEDURE [ART_DB].[ART_ST_ALERTS_PER_SCENARIO]
                        (
                        @V_START_DATE date , @V_END_DATE date
                        ) AS 
                        BEGIN
                        SET NOCOUNT ON;

                        select COALESCE(aa.Routine_Name, 'Unknown') SCENARIO_NAME,
                        cast(count(aa.Alarm_Id) as decimal) Alerts_Count  from 
                        DGAML.ac.ac_alarm aa
                        where aa.Prod_Type = 'AML' 
                         --and aa.Alarm_Status_Cd = 'ACT'
                        and  CAST(aa.create_date AS date) >= @V_START_DATE AND CAST(aa.create_date AS date) <= @V_END_DATE
                        group by aa.Routine_Name;
                        END ;
            ");
            #endregion


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
