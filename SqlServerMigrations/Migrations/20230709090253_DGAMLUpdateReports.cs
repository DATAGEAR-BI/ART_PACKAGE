using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class DGAMLUpdateReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
