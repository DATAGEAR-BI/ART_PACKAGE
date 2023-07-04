using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class AMLReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //views
            migrationBuilder.Sql(@"
                                         CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_AML_TRIAGE_VIEW"" AS 
                                     SELECT 
                                            FSK_ALERTED_ENTITY.ALERTED_ENTITY_NUMBER ,
                                            FSK_ALERTED_ENTITY.ALERTED_ENTITY_NAME,
                                            BRANCH.BRANCH_NUMBER,
                                            (Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
                                            RISK_SCORE.LOV_TYPE_DESC risk_Score,
                                            EQ.OWNER_USERID OWNER_USERID,
                                            ALERTED_ENTITY_LEVEL.LOV_TYPE_DESC alerted_entity_level,
                                            FSK_ALERTED_ENTITY.AGGREGATE_AMT aggregate_amt,
                                            FSK_ALERTED_ENTITY.AGE_OLDEST_ALERT age_oldest_alert,
                                            FSK_ALERTED_ENTITY.ALERTS_CNT
                                        FROM
                                            fcfkc.FSK_ALERTED_ENTITY@FCFKCLINK FSK_ALERTED_ENTITY 
                                            left join FCFCORE.FSC_PARTY_DIM@FCFCORELINK PARTDM on FSK_ALERTED_ENTITY.ALERTED_ENTITY_NUMBER = PARTDM.PARTY_NUMBER and PARTDM.CHANGE_CURRENT_IND ='Y'
                                            LEFT JOIN 
                                            FCFCORE.FSC_BRANCH_DIM@FCFCORELINK BRANCH on trim(PARTDM.STREET_STATE_CODE) = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y' 
                                            LEFT JOIN
                                            FCFKC.FSK_LOV@FCFKCLINK ALERTED_ENTITY_LEVEL 
                                            ON ALERTED_ENTITY_LEVEL.LOV_TYPE_CODE = FSK_ALERTED_ENTITY.ALERTED_ENTITY_LEVEL_CODE 
                                            AND ALERTED_ENTITY_LEVEL.LOV_TYPE_NAME='RT_ENTITY_LEVEL' AND ALERTED_ENTITY_LEVEL.LOV_LANGUAGE_DESC = 'en'
                                            LEFT JOIN
                                            FCFKC.FSK_LOV@FCFKCLINK RISK_SCORE
                                            ON RISK_SCORE.LOV_TYPE_CODE = FSK_ALERTED_ENTITY.RISK_SCORE_CODE  AND RISK_SCORE.LOV_TYPE_NAME = 'RT_RISK_CLASSIFICATION' AND RISK_SCORE.LOV_LANGUAGE_DESC = 'en' 
                                            LEFT JOIN fcfkc.FSK_ENTITY_QUEUE@FCFKCLINK EQ ON FSK_ALERTED_ENTITY.ALERTED_ENTITY_NUMBER = EQ.ALERTED_ENTITY_NUMBER
                                        WHERE
                                            FSK_ALERTED_ENTITY.ALERTS_CNT > 0");

            migrationBuilder.Sql(@"--------------------------------------------------------
                                    --  DDL for View ART_AML_ALERT_DETAIL_VIEW
                                    --------------------------------------------------------

                                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_AML_ALERT_DETAIL_VIEW"" AS 
                                    SELECT 
                                    ALERTED_ENTITY_NUMBER,
                                    ALERTED_ENTITY_NAME,
                                    Party_Type_Desc,
                                    BRANCH_NAME,
                                    BRANCH_NUMBER,
                                    ALERT_ID,
                                    ALERT_DESCRIPTION,
                                    ACTUAL_VALUES_TEXT,
                                    ALERT_STATUS,
                                    ALERT_SUB_CAT,
                                    ALERT_TYPE_CD,
                                    SCENARIO_NAME,
                                    SCENARIO_ID,
                                    MONEY_LAUNDERING_RISK_SCORE,
                                    CREATE_DATE,
                                    Run_Date,
                                    CLOSE_DATE,
                                    OWNER_USERID,
                                    REPORT_CLOSE_RSN,
                                    POLITICALLY_EXPOSED_PERSON_IND,
                                    EMPLOYEE_IND,
                                    Investigation_Days
                                    FROM
                                    (
                                    SELECT
                                         FSK_ALERT.ALERT_ID,
		                                     FSK_ALERT.ALERTED_ENTITY_NUMBER,
                                         FSK_ALERT.ALERTED_ENTITY_NAME,
                                         upper(PARTDM.PARTY_TYPE_DESC) Party_Type_Desc,
                                         (Case when BRANCH.BRANCH_NAME is null then 'UNKNOWN' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
                                         BRANCH.BRANCH_NUMBER,
                                         FSK_ALERT.ALERT_DESCRIPTION,
		                                     FSK_ALERT.ACTUAL_VALUES_TEXT,
                                         ALERT_STATUS.LOV_TYPE_DESC ALERT_STATUS,
                                         ALERT_SUB_CAT.LOV_TYPE_DESC ALERT_SUB_CAT,
		                                     FSK_ALERT.ALERT_TYPE_CD,
		                                     FSK_ALERT.SCENARIO_NAME,
                                         FSK_ALERT.SCENARIO_ID,
		                                     FSK_ALERT.MONEY_LAUNDERING_RISK_SCORE,
		                                     FSK_ALERT.CREATE_DATE,
                                         FSK_ALERT.Run_Date,
                                         (case when EQ.OWNER_USERID is null then 'UNKNOWN' else EQ.OWNER_USERID end )  OWNER_USERID,
                                         NVL(PARTDM.POLITICALLY_EXPOSED_PERSON_IND,'N') POLITICALLY_EXPOSED_PERSON_IND,
                                         TO_DATE('') CLOSE_DATE,
                                         '' REPORT_CLOSE_RSN,
                                         PARTDM.EMPLOYEE_IND,
                                         trunc((sysdate - FSK_ALERT.CREATE_DATE)) Investigation_Days
                                        FROM
                                            FCFKC.FSK_ALERT@FCFKCLINK FSK_ALERT 
                                            left join FCFKC.FSK_ALERTED_ENTITY@FCFKCLINK AE on FSK_ALERT.ALERTED_ENTITY_NUMBER = AE.ALERTED_ENTITY_NUMBER
                                            left join FCFKC.FSK_ENTITY_QUEUE@FCFKCLINK EQ on AE.ALERTED_ENTITY_NUMBER = EQ.ALERTED_ENTITY_NUMBER
                                         LEFT JOIN 
                                            FCFKC.FSK_LOV@FCFKCLINK ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                                            and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                                         left join 
                                            FCFKC.FSK_LOV@FCFKCLINK ALERT_SUB_CAT ON FSK_ALERT.ALERT_SUBCATEGORY_CD = ALERT_SUB_CAT.Lov_Type_Code
                                            and ALERT_SUB_CAT.LOV_TYPE_NAME='RT_CASE_SUBCATEGORY' AND ALERT_SUB_CAT.Lov_Language_Desc='en'
                                            left join FCFCORE.FSC_PARTY_DIM@FCFCORELINK PARTDM on FSK_ALERT.ALERTED_ENTITY_NUMBER = PARTDM.PARTY_NUMBER and PARTDM.CHANGE_CURRENT_IND ='Y'
                                            LEFT JOIN 
                                            FCFCORE.FSC_BRANCH_DIM@FCFCORELINK BRANCH on trim(PARTDM.STREET_STATE_CODE) = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
  
                                            where FSK_ALERT.ALERT_STATUS_CODE='ACT'
        
                                            union all
        
                                           SELECT 
                                            FSK_ALERT.ALERT_ID,
		                                        FSK_ALERT.ALERTED_ENTITY_NUMBER,
                                            FSK_ALERT.ALERTED_ENTITY_NAME,
                                            upper(PARTDM.PARTY_TYPE_DESC) Party_Type_Desc,
		                                        (Case when BRANCH.BRANCH_NAME is null then 'UNKNOWN' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
		                                        BRANCH.BRANCH_NUMBER,
		                                        FSK_ALERT.ALERT_DESCRIPTION,
                                            FSK_ALERT.ACTUAL_VALUES_TEXT,
		                                        ALERT_STATUS.LOV_TYPE_DESC ALERT_STATUS,
                                            ALERT_SUB_CAT.LOV_TYPE_DESC ALERT_SUB_CAT,
		                                        FSK_ALERT.ALERT_TYPE_CD,
		                                        FSK_ALERT.SCENARIO_NAME,
                                            FSK_ALERT.SCENARIO_ID,
		                                        FSK_ALERT.MONEY_LAUNDERING_RISK_SCORE,
		                                        FSK_ALERT.CREATE_DATE,
                                            FSK_ALERT.Run_Date,
                                            (case when AEV.CREATE_USER_ID is null then 'UNKNOWN' else AEV.CREATE_USER_ID end ) OWNER_USERID,
                                            NVL(PARTDM.POLITICALLY_EXPOSED_PERSON_IND,'N') POLITICALLY_EXPOSED_PERSON_IND,
                                            ALERT_EVE.CREATE_DATE CLOSE_DATE,
                                            CLOS_RN.LOV_TYPE_DESC REPORT_CLOSE_RSN,
                                            PARTDM.EMPLOYEE_IND,
                                         trunc((ALERT_EVE.CREATE_DATE - FSK_ALERT.Run_Date)) Investigation_Days
                                        FROM
                                            FCFKC.FSK_ALERT@FCFKCLINK FSK_ALERT 
                                            left join 
                                            (select distinct a.ALERT_ID,a.CREATE_USER_ID,a.EVENT_DESCRIPTION,Event_Desc.LOV_TYPE_DESC,row_number() over (PARTITION by A.alert_id order by A.CREATE_DATE desc) Rank
                                            from FCFKC.FSK_ALERT_EVENT@FCFKCLINK a 
                                            LEFT JOIN 
                                            FCFKC.FSK_LOV@FCFKCLINK Event_Desc ON a.EVENT_DESCRIPTION  = Event_Desc.Lov_Type_Code
                                            and Event_Desc.LOV_TYPE_NAME='RT_CLOSE_REASON' AND Event_Desc.Lov_Language_Desc='en'
                                            where
                                            a.EVENT_TYPE_CODE in ('ADD','CLS','CBC','CLC','CLR','CLS','SUE','SUP','CLP','CLA')
                                            ) AEV on FSK_ALERT.ALERT_ID = AEV.ALERT_ID and AEV.Rank=1
                                        LEFT JOIN 
                                            FCFKC.FSK_LOV@FCFKCLINK ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                                            and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                                         left join 
                                            FCFKC.FSK_LOV@FCFKCLINK ALERT_SUB_CAT ON FSK_ALERT.ALERT_SUBCATEGORY_CD = ALERT_SUB_CAT.Lov_Type_Code
                                            and ALERT_SUB_CAT.LOV_TYPE_NAME='RT_CASE_SUBCATEGORY' AND ALERT_SUB_CAT.Lov_Language_Desc='en'
                                            left join FCFCORE.FSC_PARTY_DIM@FCFCORELINK PARTDM on FSK_ALERT.ALERTED_ENTITY_NUMBER = PARTDM.PARTY_NUMBER and PARTDM.CHANGE_CURRENT_IND ='Y'
                                            LEFT JOIN 
                                            FCFCORE.FSC_BRANCH_DIM@FCFCORELINK BRANCH on trim(PARTDM.STREET_STATE_CODE) = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
                                            LEFT JOIN 
                                            (SELECT A.ALERT_ID,EVENT_DESCRIPTION,A.CREATE_DATE,row_number() over (PARTITION by A.alert_id order by A.CREATE_DATE desc) Rank FROM FCFKC.FSK_ALERT_EVENT@FCFKCLINK A 
                                            WHERE A.EVENT_TYPE_CODE in ('CLS','CLP','CLPA')
                                            ) ALERT_EVE
                                            ON FSK_ALERT.ALERT_ID = ALERT_EVE.ALERT_ID and ALERT_EVE.Rank=1
                                            LEFT JOIN
                                            FCFKC.FSK_LOV@FCFKCLINK CLOS_RN ON ALERT_EVE.EVENT_DESCRIPTION = CLOS_RN.Lov_Type_Code
                                            and CLOS_RN.LOV_TYPE_NAME='RT_CLOSE_REASON' AND CLOS_RN.Lov_Language_Desc='en'
                                            where  
                                             FSK_ALERT.ALERT_STATUS_CODE <> 'ACT' 
                                             )	");

            migrationBuilder.Sql(@" --------------------------------------------------------
                                    --  DDL for View ART_AML_CUSTOMERS_DETAILS_VIEW
                                    --------------------------------------------------------

                                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_AML_CUSTOMERS_DETAILS_VIEW"" AS 
                                      SELECT        
                                    FCFCORE.FSC_PARTY_DIM.party_name customer_name,
                                    FCFCORE.FSC_PARTY_DIM.party_number customer_number,
                                    UPPER(FCFCORE.FSC_PARTY_DIM.party_type_desc) customer_type,
                                    FCFCORE.FSC_PARTY_DIM.party_identification_id customer_identification_id,
                                    FCFCORE.FSC_PARTY_DIM.party_identification_type_desc customer_identification_type, 
                                    FCFCORE.FSC_PARTY_DIM.party_date_of_birth customer_date_of_birth, 
                                    (case when Risk.lov_type_desc is null then 'Unknown' else Risk.lov_type_desc end )AS RISK_CLASSIFICATION,
                                    FCFCORE.FSC_PARTY_DIM.PARTY_TAX_ID Customer_Tax_ID,
                                    FCFCORE.FSC_PARTY_DIM.DOING_BUSINESS_AS_NAME,
                                    FCFCORE.FSC_PARTY_DIM.street_state_name Governorate_name,
                                    FCFCORE.FSC_PARTY_DIM.street_address_1,
                                    FCFCORE.FSC_PARTY_DIM.street_city_name City_name,
                                    FCFCORE.FSC_PARTY_DIM.party_status_desc Customer_status,
                                    FCFCORE.FSC_PARTY_DIM.STREET_POSTAL_CODE,
                                    FCFCORE.FSC_PARTY_DIM.STREET_COUNTRY_CODE,
                                    FCFCORE.FSC_PARTY_DIM.STREET_COUNTRY_NAME,
                                    FCFCORE.FSC_PARTY_DIM.MAILING_ADDRESS_1,
                                    FCFCORE.FSC_PARTY_DIM.MAILING_CITY_NAME,
                                    FCFCORE.FSC_PARTY_DIM.MAILING_POSTAL_CODE,
                                    FCFCORE.FSC_PARTY_DIM.MAILING_COUNTRY_NAME,
                                    FCFCORE.FSC_PARTY_DIM.RESIDENCE_COUNTRY_NAME,
                                    (case when FCFCORE.FSC_PARTY_DIM.CITIZENSHIP_COUNTRY_NAME is null then 'Unknown' else CITIZENSHIP_COUNTRY_NAME end) CITIZENSHIP_COUNTRY_NAME,
                                    FCFCORE.FSC_PARTY_DIM.EMPLOYEE_IND AS Is_EMPLOYEE,
                                    FCFCORE.FSC_PARTY_DIM.EMPLOYEE_NUMBER,
                                    FCFCORE.FSC_PARTY_DIM.EMPLOYER_NAME,
                                    FCFCORE.FSC_PARTY_DIM.EMPLOYER_PHONE_NUMBER,
                                    FCFCORE.FSC_PARTY_DIM.EMAIL_ADDRESS,
                                    FCFCORE.FSC_PARTY_DIM.occupation_desc,
                                    FCFCORE.FSC_PARTY_DIM.industry_desc, 
                                    FCFCORE.FSC_PARTY_DIM.PHONE_NUMBER_1, 
                                    FCFCORE.FSC_PARTY_DIM.PHONE_NUMBER_2, 
                                    FCFCORE.FSC_PARTY_DIM.PHONE_NUMBER_3, 
                                    FCFCORE.FSC_PARTY_DIM.ANNUAL_INCOME_AMOUNT,
                                    FCFCORE.FSC_PARTY_DIM.NET_WORTH_AMOUNT,
                                    FCFCORE.FSC_PARTY_DIM.MARITAL_STATUS_DESC,
                                    FCFCORE.FSC_PARTY_DIM.CUSTOMER_SINCE_DATE, 
                                    FCFCORE.FSC_PARTY_DIM.LAST_RISK_ASSESSMENT_DATE,    
                                    FCFCORE.FSC_PARTY_DIM.non_profit_org_ind,
                                    FCFCORE.FSC_PARTY_DIM.politically_exposed_person_ind,
                                    Risk.ACTIVE_FLG,
                                    (Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
                                    BRANCH.BRANCH_NUMBER  BRANCH_NUMBER
                                    FROM            
                                    FCFCORE.FSC_PARTY_DIM@FCFCORELINK LEFT OUTER JOIN
                                    FCFKC.FSK_LOV@FCFKCLINK Risk ON TO_CHAR(FCFCORE.FSC_PARTY_DIM.risk_classification) = Risk.lov_type_code AND Risk.lov_language_desc = 'en'
                                    AND Risk.lov_type_name = 'RT_RISK_CLASSIFICATION' 
                                    LEFT JOIN
                                    FCFCORE.FSC_BRANCH_DIM@FCFCORELINK BRANCH on trim(FSC_PARTY_DIM.STREET_STATE_CODE) = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
                                    WHERE (FCFCORE.FSC_PARTY_DIM.party_key > - 1 and FCFCORE.FSC_PARTY_DIM.CHANGE_CURRENT_IND='Y')
");
            migrationBuilder.Sql(@"--------------------------------------------------------
                                    --  DDL for View ART_AML_CASE_DETAILS_VIEW
                                    --------------------------------------------------------

                                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_AML_CASE_DETAILS_VIEW"" AS 
                                      SELECT 
                                    CASE.CASE_ID,
                                    FSK_CASE_ENTITY.ENTITY_NAME,
                                    FSK_CASE_ENTITY.ENTITY_NUMBER,
                                    BRANCH.BRANCH_NAME,
                                    BRANCH.BRANCH_NUMBER,
                                    CASE_PRIORITY.LOV_TYPE_DESC ""CASE_PRIORITY"",
                                    CASE_STATUS.LOV_TYPE_DESC ""CASE_STATUS"",
                                    CASE_CATEGORY.LOV_TYPE_DESC ""CASE_CATEGORY"",
                                    CASE_SUBCATEGORY.LOV_TYPE_DESC ""CASE_SUB_CATEGORY"",
                                    ENTITY_LEVEL.LOV_TYPE_DESC ""ENTITY_LEVEL"",
                                    CASE.CREATE_USER_ID ""CREATED_BY"", 
                                    CASE.OWNER_USER_LONG_ID ""OWNER"",
                                    case.CREATE_DATE,
                                    to_date('') Closed_Date

                                    FROM FCFKC.FSK_CASE@FCFKCLINK CASE LEFT JOIN
                                    FCFKC.FSK_LOV@FCFKCLINK CASE_STATUS ON CASE_STATUS.LOV_TYPE_CODE = CASE.CASE_STATUS_CODE
                                    AND CASE_STATUS.LOV_TYPE_NAME ='FCF_CASE_STATUS' AND CASE_STATUS.LOV_LANGUAGE_DESC ='en'
                                    LEFT JOIN FCFKC.FSK_LOV@FCFKCLINK CASE_CATEGORY ON CASE_CATEGORY.LOV_TYPE_CODE = CASE.CASE_CATEGORY_CODE
                                    AND CASE_CATEGORY.LOV_TYPE_NAME ='RT_CASE_CATEGORY' AND CASE_CATEGORY.LOV_LANGUAGE_DESC ='en'
                                    LEFT JOIN FCFKC.FSK_LOV@FCFKCLINK CASE_SUBCATEGORY ON CASE_SUBCATEGORY.LOV_TYPE_CODE = CASE.CASE_SUB_CATEGORY_CODE
                                    AND CASE_SUBCATEGORY.LOV_TYPE_NAME ='RT_CASE_SUBCATEGORY' AND CASE_SUBCATEGORY.LOV_LANGUAGE_DESC ='en'
                                    LEFT JOIN FCFKC.FSK_LOV@FCFKCLINK CASE_PRIORITY ON CASE_PRIORITY.LOV_TYPE_CODE = CASE.CASE_PRIORITY_CODE
                                    AND CASE_PRIORITY.LOV_TYPE_NAME ='X_RT_PRIORITY' AND CASE_PRIORITY.LOV_LANGUAGE_DESC ='en'
                                    LEFT JOIN FCFKC.FSK_CASE_ENTITY@FCFKCLINK ON FSK_CASE_ENTITY.CASE_ID = CASE.CASE_ID
                                    LEFT JOIN FCFKC.FSK_LOV@FCFKCLINK ENTITY_LEVEL ON FSK_CASE_ENTITY.ENTITY_LEVEL_CODE = ENTITY_LEVEL.LOV_TYPE_CODE
                                    AND ENTITY_LEVEL.LOV_TYPE_NAME ='RT_ENTITY_LEVEL' AND ENTITY_LEVEL.LOV_LANGUAGE_DESC ='en'
                                    left JOIN fcfcore.FSC_PARTY_DIM@FCFCORELINK PARTY ON FSK_CASE_ENTITY.ENTITY_NUMBER = party.PARTY_NUMBER and party.CHANGE_CURRENT_IND ='Y' 
                                    LEFT JOIN 
                                    fcfcore.FSC_BRANCH_DIM@FCFCORELINK BRANCH on trim(PARTY.STREET_STATE_CODE) = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'

                                    WHERE
                                    CASE_STATUS.LOV_TYPE_DESC ='Open'
                                    and entity_level_code ='PTY'
 
                                    union all
 
                                    SELECT 
                                    CASE.CASE_ID,
                                    FSK_CASE_ENTITY.ENTITY_NAME,
                                    FSK_CASE_ENTITY.ENTITY_NUMBER,
                                    BRANCH.BRANCH_NAME,
                                    BRANCH.BRANCH_NUMBER,
                                    CASE_PRIORITY.LOV_TYPE_DESC ""CASE_PRIORITY"",
                                    CASE_STATUS.LOV_TYPE_DESC ""CASE_STATUS"",
                                    CASE_CATEGORY.LOV_TYPE_DESC ""CASE_CATEGORY"",
                                    CASE_SUBCATEGORY.LOV_TYPE_DESC ""CASE_SUB_CATEGORY"",
                                    ENTITY_LEVEL.LOV_TYPE_DESC ""ENTITY_LEVEL"",
                                    CASE.CREATE_USER_ID ""CREATED_BY"", 
                                    CASE.OWNER_USER_LONG_ID ""OWNER"",
                                    case.CREATE_DATE,
                                    case.LSTUPDATE_DATE Close_Date

                                    FROM fcfkc.FSK_CASE@FCFKCLINK CASE LEFT JOIN
                                    fcfkc.FSK_LOV@FCFKCLINK CASE_STATUS ON CASE_STATUS.LOV_TYPE_CODE = CASE.CASE_STATUS_CODE
                                    AND CASE_STATUS.LOV_TYPE_NAME ='FCF_CASE_STATUS' AND CASE_STATUS.LOV_LANGUAGE_DESC ='en'
                                    LEFT JOIN fcfkc.FSK_LOV@FCFKCLINK CASE_CATEGORY ON CASE_CATEGORY.LOV_TYPE_CODE = CASE.CASE_CATEGORY_CODE
                                    AND CASE_CATEGORY.LOV_TYPE_NAME ='RT_CASE_CATEGORY' AND CASE_CATEGORY.LOV_LANGUAGE_DESC ='en'
                                    LEFT JOIN fcfkc.FSK_LOV@FCFKCLINK CASE_SUBCATEGORY ON CASE_SUBCATEGORY.LOV_TYPE_CODE = CASE.CASE_SUB_CATEGORY_CODE
                                    AND CASE_SUBCATEGORY.LOV_TYPE_NAME ='RT_CASE_SUBCATEGORY' AND CASE_SUBCATEGORY.LOV_LANGUAGE_DESC ='en'
                                    LEFT JOIN fcfkc.FSK_LOV@FCFKCLINK CASE_PRIORITY ON CASE_PRIORITY.LOV_TYPE_CODE = CASE.CASE_PRIORITY_CODE
                                    AND CASE_PRIORITY.LOV_TYPE_NAME ='X_RT_PRIORITY' AND CASE_PRIORITY.LOV_LANGUAGE_DESC ='en'
                                    LEFT JOIN fcfkc.FSK_CASE_ENTITY@FCFKCLINK ON FSK_CASE_ENTITY.CASE_ID = CASE.CASE_ID
                                    LEFT JOIN fcfkc.FSK_LOV@FCFKCLINK ENTITY_LEVEL ON FSK_CASE_ENTITY.ENTITY_LEVEL_CODE = ENTITY_LEVEL.LOV_TYPE_CODE
                                    AND ENTITY_LEVEL.LOV_TYPE_NAME ='RT_ENTITY_LEVEL' AND ENTITY_LEVEL.LOV_LANGUAGE_DESC ='en'
                                    left JOIN fcfcore.FSC_PARTY_DIM@FCFCORELINK PARTY ON FSK_CASE_ENTITY.ENTITY_NUMBER = party.PARTY_NUMBER and party.CHANGE_CURRENT_IND ='Y' 
                                    LEFT JOIN 
                                    fcfcore.FSC_BRANCH_DIM@FCFCORELINK BRANCH on trim(PARTY.STREET_STATE_CODE) = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
                                    WHERE
                                    CASE_STATUS.LOV_TYPE_DESC <>'Open'
                                    and entity_level_code ='PTY'");

            migrationBuilder.Sql(@"--------------------------------------------------------
                                    --  DDL for View ART_AML_HIGH_RISK_CUST_VIEW
                                    --------------------------------------------------------

                                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_AML_HIGH_RISK_CUST_VIEW"" AS 
                                      SELECT
                                            FSC_PARTY_DIM.PARTY_NUMBER AS PARTY_NUMBER,
                                            FSC_PARTY_DIM.PARTY_TYPE_DESC AS PARTY_TYPE_DESC,
                                            FSC_PARTY_DIM.PARTY_TAX_ID AS PARTY_TAX_ID,
                                            FSC_PARTY_DIM.PARTY_IDENTIFICATION_ID AS PARTY_IDENTIFICATION_ID,
                                            FSC_PARTY_DIM.PARTY_IDENTIFICATION_TYPE_DESC AS PARTY_IDENTIFICATION_TYPE_DESC,
                                            FSC_PARTY_DIM.PARTY_DATE_OF_BIRTH AS PARTY_DATE_OF_BIRTH,
                                            FSC_PARTY_DIM.PARTY_NAME AS PARTY_NAME,
                                            FSC_PARTY_DIM.STREET_ADDRESS_1 AS STREET_ADDRESS_1,
                                            FSC_PARTY_DIM.STREET_CITY_NAME AS STREET_CITY_NAME,
                                            FSC_PARTY_DIM.MAILING_ADDRESS_1 AS MAILING_ADDRESS_1,
                                            FSC_PARTY_DIM.MAILING_CITY_NAME AS MAILING_CITY_NAME,
                                            FSC_PARTY_DIM.RESIDENCE_COUNTRY_NAME AS RESIDENCE_COUNTRY_NAME,
                                            FSC_PARTY_DIM.CITIZENSHIP_COUNTRY_NAME AS CITIZENSHIP_COUNTRY_NAME,
                                            FSC_PARTY_DIM.PHONE_NUMBER_1 AS PHONE_NUMBER_1,
                                            NVL(FSC_PARTY_DIM.POLITICALLY_EXPOSED_PERSON_IND,'N') AS POLITICALLY_EXPOSED_PERSON_IND,
                                            Risk.lov_type_desc AS RISK_CLASSIFICATION,
                                            BRANCH.BRANCH_NAME,
                                            BRANCH.BRANCH_NUMBER
                                        FROM
                                            FCFCORE.FSC_PARTY_DIM@FCFCORELINK FSC_PARTY_DIM 
                                        LEFT JOIN 
                                            FCFCORE.FSC_BRANCH_DIM@FCFCORELINK BRANCH on trim(FSC_PARTY_DIM.STREET_STATE_CODE) = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
                                            LEFT OUTER JOIN
                                            FCFKC.FSK_LOV@FCFKCLINK RISK ON TO_CHAR(FCFCORE.FSC_PARTY_DIM.RISK_CLASSIFICATION) = RISK.LOV_TYPE_CODE AND RISK.LOV_LANGUAGE_DESC = 'en'
                                            AND RISK.LOV_TYPE_NAME = 'RT_RISK_CLASSIFICATION' 
                                            WHERE
                                            FSC_PARTY_DIM.RISK_CLASSIFICATION > 1 and FSC_PARTY_DIM.change_current_ind ='Y'
	");
            migrationBuilder.Sql(@"--------------------------------------------------------
                                    --  DDL for View ART_RISK_ASSESSMENT_VIEW
                                    --------------------------------------------------------

                                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_RISK_ASSESSMENT_VIEW"" AS
                                     SELECT
                                            RISK_STATUS.LOV_TYPE_DESC RISK_STATUS,
                                            RISK_CLASS.LOV_TYPE_DESC RISK_CLASS,
                                            PROPOSED_RISK_CLASS.LOV_TYPE_DESC PROPOSED_RISK_CLASS,        
                                            PARTY_BRANCH.BRANCH_NAME  AS BRANCH_NAME,
		                                    PARTY_BRANCH.BRANCH_NUMBER BRANCH_NUMBER,
                                            FSK_RISK_ASSESSMENT.RISK_ASSESSMENT_ID  AS RISK_ASSESSMENT_ID,
                                            FSK_RISK_ASSESSMENT.PARTY_NUMBER  AS PARTY_NUMBER,
                                            FSK_RISK_ASSESSMENT.PARTY_NAME AS PARTY_NAME,
                                            FSK_RISK_ASSESSMENT.RISK_ASSESSMENT_DURATION  AS RISK_ASSESSMENT_DURATION,
                                            FSK_RISK_ASSESSMENT.CREATE_DATE AS CREATE_DATE,
                                            FSK_RISK_ASSESSMENT.CREATE_USER_ID CREATE_USER_ID,
                                            FSK_RISK_ASSESSMENT.VERSION_NUMBER  AS VERSION_NUMBER,
                                            FSK_RISK_ASSESSMENT.ASSESSMENT_TYPE_CD AS ASSESSMENT_TYPE_CD,
                                            FSK_RISK_ASSESSMENT.ASSESSMENT_CATEGORY_CD AS ASSESSMENT_CATEGORY_CD,
                                            FSK_RISK_ASSESSMENT.ASSESSMENT_SUBCATEGORY_CD AS ASSESSMENT_SUBCATEGORY_CD,
                                            FSK_RISK_ASSESSMENT.OWNER_USER_LONG_ID AS OWNER_USER_LONG_ID
                                        FROM
                                            FCFKC.FSK_RISK_ASSESSMENT@FCFKCLINK FSK_RISK_ASSESSMENT 
                                        LEFT JOIN 
                                            FCFKC.FSK_LOV@FCFKCLINK RISK_STATUS on FSK_RISK_ASSESSMENT.RISK_ASSESSMENT_STATUS_CODE = RISK_STATUS.LOV_TYPE_CODE and RISK_STATUS.LOV_TYPE_NAME ='RT_ASMT_STATUS' and RISK_STATUS.LOV_LANGUAGE_DESC='en'
                                        LEFT JOIN 
                                            FCFKC.FSK_LOV@FCFKCLINK RISK_CLASS on FSK_RISK_ASSESSMENT.RISK_CLASSIFICATION = RISK_CLASS.LOV_TYPE_CODE and RISK_CLASS.LOV_TYPE_NAME ='RT_RISK_CLASSIFICATION' and RISK_CLASS.LOV_LANGUAGE_DESC='en'
                                        LEFT JOIN 
                                            FCFKC.FSK_LOV@FCFKCLINK PROPOSED_RISK_CLASS on FSK_RISK_ASSESSMENT.PROPOSED_RISK_CLASSIFICATION = PROPOSED_RISK_CLASS.LOV_TYPE_CODE and PROPOSED_RISK_CLASS.LOV_TYPE_NAME ='RT_RISK_CLASSIFICATION' and PROPOSED_RISK_CLASS.LOV_LANGUAGE_DESC='en'
                                        LEFT JOIN
                                            FCFCORE.FSC_PARTY_DIM@FCFCORELINK PARTY ON FSK_RISK_ASSESSMENT.PARTY_NUMBER = PARTY.PARTY_NUMBER
                                             LEFT JOIN
                                            FCFCORE.FSC_BRANCH_DIM@FCFCORELINK Party_Branch ON PARTY.STREET_STATE_CODE = Party_Branch.BRANCH_NUMBER AND party_branch.change_current_ind = 'Y'
                                            WHERE PARTY.CHANGE_CURRENT_IND='Y'
                                        ");
            //procs
            migrationBuilder.Sql($@"

                            --------------------------------------------------------
                            --  DDL for Procedure ART_ST_ALERT_PER_OWNER
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_ALERT_PER_OWNER"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            select (case when FSK_ENTITY_QUEUE.OWNER_USERID is null then 'UNKNOWN' else FSK_ENTITY_QUEUE.OWNER_USERID end)  AS OWNER_USERID,
                                    count(distinct alert_id) AS ALERTS_CNT_SUM 
                            from fcfkc.FSK_ALERT
                            left join fcfkc.FSK_ENTITY_QUEUE on FSK_ALERT.ALERTED_ENTITY_NUMBER = FSK_ENTITY_QUEUE.ALERTED_ENTITY_NUMBER 
                            and FSK_ALERT.ALERT_STATUS_CODE='ACT'
                            and to_char(FSK_ALERT.CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(FSK_ALERT.CREATE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            GROUP BY
                                    (case when FSK_ENTITY_QUEUE.OWNER_USERID is null then 'UNKNOWN' else FSK_ENTITY_QUEUE.OWNER_USERID end);
                            END ART_ST_ALERT_PER_OWNER;;");




            migrationBuilder.Sql(@" --------------------------------------------------------
                            --  DDL for Procedure ART_ST_ALERTS_PER_STATUS
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_ALERTS_PER_STATUS"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            select ALERT_STATUS.LOV_TYPE_DESC ALERT_STATUS,
                            count(FSK_ALERT.alert_id) ALERTS_COUNT
                             FROM
                                    fcfkc.FSK_ALERT FSK_ALERT 
		                            LEFT JOIN 
                                    FCFKC.FSK_LOV ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                                    and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                            where   to_char(CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(CREATE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            group by ALERT_STATUS.LOV_TYPE_DESC 
                            ;
                            END ART_ST_ALERTS_PER_STATUS;;");




            migrationBuilder.Sql(@"--------------------------------------------------------
                            --  DDL for Procedure ART_ST_CASES_PER_CATEGORY
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_CASES_PER_CATEGORY"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            select CASE_CATEGORY.lov_type_desc CASE_CATEGORY ,count(1)NUMBER_OF_CASES
                            FROM FCFKC.FSK_CASE CASE 
                            LEFT JOIN FCFKC.FSK_LOV CASE_CATEGORY ON CASE_CATEGORY.LOV_TYPE_CODE = CASE.CASE_CATEGORY_CODE
                            AND CASE_CATEGORY.LOV_TYPE_NAME ='RT_CASE_CATEGORY' AND CASE_CATEGORY.LOV_LANGUAGE_DESC ='en'
                            Where
                            to_char(CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(CREATE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            GROUP BY
                            CASE_CATEGORY.lov_type_desc
                            ;
                            END ART_ST_CASES_PER_CATEGORY;;");



            migrationBuilder.Sql(@"--------------------------------------------------------
                            --  DDL for Procedure ART_ST_CASES_PER_PRIORITY
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_CASES_PER_PRIORITY"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            select CASE_PRIORITY.lov_type_desc CASE_PRIORITY ,count(1)NUMBER_OF_CASES
                            FROM FCFKC.FSK_CASE CASE 
                            LEFT JOIN FCFKC.FSK_LOV CASE_PRIORITY ON CASE_PRIORITY.LOV_TYPE_CODE = CASE.CASE_PRIORITY_CODE
                            AND CASE_PRIORITY.LOV_TYPE_NAME ='X_RT_PRIORITY' AND CASE_PRIORITY.LOV_LANGUAGE_DESC ='en'
                            Where
                            to_char(CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(CREATE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            GROUP BY
                            CASE_PRIORITY.lov_type_desc
                            ;
                            END ART_ST_CASES_PER_PRIORITY;;
                            ");


            migrationBuilder.Sql(@"--------------------------------------------------------
                            --  DDL for Procedure ART_ST_CASES_PER_STATUS
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_CASES_PER_STATUS"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            SELECT 
                            case_status.lov_type_desc CASE_STATUS ,
                            COUNT(1)NUMBER_OF_CASES
                            FROM FCFKC.FSK_CASE CASE 
                            LEFT JOIN FCFKC.FSK_LOV CASE_STATUS 
                            ON CASE_STATUS.LOV_TYPE_CODE = CASE.CASE_STATUS_CODE 
                            AND CASE_STATUS.LOV_TYPE_NAME ='FCF_CASE_STATUS' 
                            AND CASE_STATUS.LOV_LANGUAGE_DESC ='en' 
                            Where
                            to_char(CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(CREATE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            GROUP BY
                            case_status.lov_type_desc
                            ;
                            END ART_ST_CASES_PER_STATUS;;

                            ");


            migrationBuilder.Sql(@"--------------------------------------------------------
                            --  DDL for Procedure ART_ST_CASES_PER_SUBCAT
                            --------------------------------------------------------
                            

                             CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_CASES_PER_SUBCAT"" 
                                (
                                  DATA_CUR OUT SYS_REFCURSOR 
                                , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                ) AS 
                                BEGIN
                                OPEN DATA_CUR FOR 

                                select CASE_SUBCATEGORY.lov_type_desc CASE_SUBCATEGORY ,count(1)NUMBER_OF_CASES
                                FROM FCFKC.FSK_CASE CASE 
                                LEFT JOIN FCFKC.FSK_LOV CASE_SUBCATEGORY ON CASE_SUBCATEGORY.LOV_TYPE_CODE = CASE.CASE_SUB_CATEGORY_CODE
                                AND CASE_SUBCATEGORY.LOV_TYPE_NAME ='RT_CASE_SUBCATEGORY' AND CASE_SUBCATEGORY.LOV_LANGUAGE_DESC ='en'
                                Where
                                to_char(CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                                AND to_char(CREATE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                                GROUP BY
                                CASE_SUBCATEGORY.lov_type_desc
                                ;
                                END ART_ST_CASES_PER_SUBCAT;;

                            ");

            migrationBuilder.Sql(@"--------------------------------------------------------
                            --  DDL for Procedure ART_ST_CUST_PER_BRANCH
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_CUST_PER_BRANCH"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            SELECT        
                            Party_Branch.branch_name BRANCH_NAME,count(fcfcore.fsc_party_dim.party_key)NUMBER_OF_CUSTOMERS
                            FROM            
                            FCFCORE.FSC_PARTY_DIM 
                            LEFT JOIN
                            FCFCORE.FSC_BRANCH_DIM Party_Branch ON FSC_PARTY_DIM.STREET_STATE_CODE = Party_Branch.BRANCH_NUMBER 
                            AND party_branch.change_current_ind = 'Y'
                            WHERE (FCFCORE.FSC_PARTY_DIM.party_key > - 1 and fcfcore.fsc_party_dim.change_current_ind='Y')
                            and to_char(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            group by Party_Branch.branch_name;
                            END ART_ST_CUST_PER_BRANCH;;
                            ");
            migrationBuilder.Sql(@"--------------------------------------------------------
                            --  DDL for Procedure ART_ST_CUST_PER_RISK
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_CUST_PER_RISK"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            SELECT        
                            (case when Risk.lov_type_desc is null then 'UNKNOWN' else Risk.lov_type_desc end) RISK_CLASSIFICATION,
                            count(fcfcore.fsc_party_dim.party_key)NUMBER_OF_CUSTOMERS
                            FROM            
                            FCFCORE.FSC_PARTY_DIM 
                            LEFT OUTER JOIN
                            FCFKC.FSK_LOV Risk ON TO_CHAR(FCFCORE.FSC_PARTY_DIM.risk_classification) = Risk.lov_type_code AND Risk.lov_language_desc = 'en'
                            AND Risk.lov_type_name = 'RT_RISK_CLASSIFICATION' 
                            WHERE (FCFCORE.FSC_PARTY_DIM.party_key > - 1 and fcfcore.fsc_party_dim.change_current_ind='Y')
                            and to_char(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            group by (case when Risk.lov_type_desc is null then 'UNKNOWN' else Risk.lov_type_desc end);
                            END ART_ST_CUST_PER_RISK;;
");

            migrationBuilder.Sql(@"--------------------------------------------------------
                            --  DDL for Procedure ART_ST_CUST_PER_TYPE
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_CUST_PER_TYPE"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            SELECT        
                            (case when FCFCORE.FSC_PARTY_DIM.party_type_desc = 'organization' then 'ORGANIZATION' 
                            when FCFCORE.FSC_PARTY_DIM.party_type_desc is null then 'UNKNOWN'
                            when FCFCORE.FSC_PARTY_DIM.party_type_desc =' 'then 'UNKNOWN'
                            else FCFCORE.FSC_PARTY_DIM.party_type_desc
                            end
                            ) CUSTOMER_TYPE,
                            count(fcfcore.fsc_party_dim.party_key)NUMBER_OF_CUSTOMERS
                            FROM            
                            FCFCORE.FSC_PARTY_DIM 
                            WHERE (FCFCORE.FSC_PARTY_DIM.party_key > - 1 and fcfcore.fsc_party_dim.change_current_ind='Y')
                            and to_char(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            group by (case when FCFCORE.FSC_PARTY_DIM.party_type_desc = 'organization' then 'ORGANIZATION' 
                            when FCFCORE.FSC_PARTY_DIM.party_type_desc is null then 'UNKNOWN'
                            when FCFCORE.FSC_PARTY_DIM.party_type_desc =' 'then 'UNKNOWN'
                            else FCFCORE.FSC_PARTY_DIM.party_type_desc
                            end
                            )
                            ;
                            END ART_ST_CUST_PER_TYPE;;

                            ");


            migrationBuilder.Sql(@"--------------------------------------------------------
                            --  DDL for Procedure ART_ST_AML_PROP_RISK_CLASS
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_AML_PROP_RISK_CLASS"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            SELECT
                                    PROPOSED_RISK_CLASS.LOV_TYPE_DESC PROPOSED_RISK_CLASS,        
                                   count(PARTY.party_key) NUMBER_OF_CUSTOMERS
                                FROM
                                    FCFKC.FSK_RISK_ASSESSMENT FSK_RISK_ASSESSMENT 
                                LEFT JOIN 
                                    FCFKC.FSK_LOV PROPOSED_RISK_CLASS on FSK_RISK_ASSESSMENT.PROPOSED_RISK_CLASSIFICATION = PROPOSED_RISK_CLASS.LOV_TYPE_CODE and PROPOSED_RISK_CLASS.LOV_TYPE_NAME ='RT_RISK_CLASSIFICATION' and PROPOSED_RISK_CLASS.LOV_LANGUAGE_DESC='en'
                                LEFT JOIN
                                    FCFCORE.FSC_PARTY_DIM PARTY ON FSK_RISK_ASSESSMENT.PARTY_NUMBER = PARTY.PARTY_NUMBER
                                    WHERE PARTY.CHANGE_CURRENT_IND='Y'
                            and to_char(FSK_RISK_ASSESSMENT.CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(FSK_RISK_ASSESSMENT.CREATE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            group by PROPOSED_RISK_CLASS.LOV_TYPE_DESC;

                            END ART_ST_AML_PROP_RISK_CLASS;;

                            ");
            migrationBuilder.Sql(@"--------------------------------------------------------
                            --  DDL for Procedure ART_ST_AML_RISK_CLASS
                            --------------------------------------------------------
                            

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_AML_RISK_CLASS"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            SELECT        
                            (case when Risk.lov_type_desc is null then 'UNKNOWN' else Risk.lov_type_desc end) AS RISK_CLASSIFICATION,
                            count(FCFCORE.FSC_PARTY_DIM.PARTY_KEY) NUMBER_OF_CUSTOMERS
                            FROM            
                            FCFCORE.FSC_PARTY_DIM 
                            LEFT OUTER JOIN
                            FCFKC.FSK_LOV Risk ON TO_CHAR(FCFCORE.FSC_PARTY_DIM.risk_classification) = Risk.lov_type_code AND Risk.lov_language_desc = 'en'
                            AND Risk.lov_type_name = 'RT_RISK_CLASSIFICATION' 
                            LEFT JOIN
                                    FCFKC.FSK_RISK_ASSESSMENT FSK_RISK_ASSESSMENT ON FSK_RISK_ASSESSMENT.PARTY_NUMBER = FCFCORE.FSC_PARTY_DIM.PARTY_NUMBER
                            WHERE (FCFCORE.FSC_PARTY_DIM.party_key > - 1 and fcfcore.fsc_party_dim.change_current_ind='Y')
                            and to_char(FSK_RISK_ASSESSMENT.CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(FSK_RISK_ASSESSMENT.CREATE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            group by (case when Risk.lov_type_desc is null then 'UNKNOWN' else Risk.lov_type_desc end);
                            END ART_ST_AML_RISK_CLASS;;
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_ALERT_PER_OWNER""");
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_ALERTS_PER_STATUS""");
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_CASES_PER_CATEGORY""");
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_CASES_PER_PRIORITY""");
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_CASES_PER_STATUS""");
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_CASES_PER_SUBCAT""");
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_CUST_PER_BRANCH""");
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_CUST_PER_RISK""");
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_CUST_PER_TYPE""");
            migrationBuilder.Sql($@"DROP PROCEDURE ""ART"".""ART_ST_AML_RISK_CLASS""");

        }
    }
}
