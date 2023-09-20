using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations.SasAml
{
    public partial class SasAmlQueries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //create AML Views
            migrationBuilder.Sql($@"
                USE [ART_DB]
               
                GO
                
                /****** Object:  View [ART_DB].[ART_HOME_ALERTS_PER_STATUS]    Script Date: 5/22/2023 10:11:01 AM ******/
                SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                CREATE VIEW [ART_DB].[ART_HOME_ALERTS_PER_STATUS] as
                select  (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end) ALERT_STATUS,
                count(FSK_ALERT.alert_id) Alerts_Count,
				YEAR(FSK_ALERT.create_date) Year
                FROM fcf71.fcfkc.FSK_ALERT FSK_ALERT 
                LEFT JOIN 
                fcf71.fcfkc.FSK_LOV ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                group by (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end),YEAR(FSK_ALERT.create_date);

                GO


                -------------------------------------------------------------------------------


                USE [ART_DB]
                GO
                

                /****** Object:  View [ART_DB].[ART_HOME_ALERTS_PER_DATE]    Script Date: 5/22/2023 10:22:37 AM ******/
                SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                CREATE VIEW [ART_DB].[ART_HOME_ALERTS_PER_DATE] as
                select Year_ Year,Month__ Month,Day_ Day,Number_Of_ALerts from
                (select 
                YEAR(a.create_date) Year_,
                Month(a.create_date) Month_,
                FORMAT(a.create_date,'MMM') Month__,
                Day(a.create_date) Day_,
                count(a.alert_id) Number_Of_ALerts
                from  fcf71.fcfkc.FSK_ALERT a
                group by 
                YEAR(a.create_date),
                Month(a.create_date),
                FORMAT(a.create_date,'MMM') ,
                Day(a.create_date)
                order by YEAR(a.create_date) desc,
                Month(a.create_date) desc,
                Day(a.create_date)  desc offset 0 rows) aaa;
                GO


                ---------------------------------------------------------------------------

                USE [ART_DB]
                GO

                /****** Object:  View [ART_DB].[ART_HOME_NUMBER_OF_CUSTOMERS]    Script Date: 5/22/2023 11:12:40 AM ******/
                SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                CREATE VIEW [ART_DB].[ART_HOME_NUMBER_OF_CUSTOMERS] AS
                select  count(*) Number_Of_Customers
                FROM fcf71.fcfcore.FSC_PARTY_DIM a
                where a.change_current_ind = 'Y';
                GO


                ---------------------------------------------------------------------------

                USE [ART_DB]
                GO

                /****** Object:  View [ART_DB].[ART_HOME_NUMBER_OF_PEP_CUSTOMERS]    Script Date: 5/22/2023 11:21:05 AM ******/
                SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                CREATE VIEW [ART_DB].[ART_HOME_NUMBER_OF_PEP_CUSTOMERS] AS
                select  count(*) Number_Of_PEP_Customers
                FROM fcf71.fcfcore.FSC_PARTY_DIM a
                where a.change_current_ind = 'Y'
                and a.politically_exposed_person_ind = 'Y';
                GO


                ----------------------------------------------------------------------

                USE [ART_DB]
                GO

                /****** Object:  View [ART_DB].[ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS]    Script Date: 5/22/2023 11:20:09 AM ******/
                SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                CREATE VIEW [ART_DB].[ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS] AS
                select  count(*) Number_Of_High_Risk_Customers
                FROM fcf71.fcfcore.FSC_PARTY_DIM a
                where a.change_current_ind = 'Y'
                and a.risk_classification = '3';
                GO


                ---------------------------------------------------------------------------

                USE [ART_DB]
                GO

                /****** Object:  View [ART_DB].[ART_HOME_Number_Of_Accounts]    Script Date: 5/22/2023 11:22:35 AM ******/
                SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                CREATE VIEW [ART_DB].[ART_HOME_Number_Of_Accounts] AS
                select  count(*) Number_Of_Accounts
                FROM fcf71.fcfcore.FSC_ACCOUNT_DIM a
                where a.change_current_ind = 'Y';
                GO
            ");

            //views
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  View [FCF71.FCFKC].[ART_AML_TRIAGE_VIEW]    Script Date: 6/11/2023 3:29:24 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO

                            CREATE VIEW [ART_DB].[ART_AML_TRIAGE_VIEW] AS
                              SELECT
                                    FSK_ALERTED_ENTITY.ALERTED_ENTITY_NAME ALERTED_ENTITY_NAME,
		                            FSK_ALERTED_ENTITY.ALERTED_ENTITY_NUMBER ALERTED_ENTITY_NUMBER,
                                    branch_number.BRANCH_NUMBER BRANCH_NUMBER,
                                    (Case when Party_Branch.BRANCH_NAME is null then 'Unknown' else Party_Branch.BRANCH_NAME end) BRANCH_NAME,
                                    RISK_SCORE.LOV_TYPE_DESC RISK_SCORE,
                                    EQ.OWNER_USERID OWNER_USERID,
                                    ALERTED_ENTITY_LEVEL.LOV_TYPE_DESC ALERTED_ENTITY_LEVEL,
                                    FSK_ALERTED_ENTITY.AGGREGATE_AMT AGGREGATE_AMT,
                                    FSK_ALERTED_ENTITY.AGE_OLDEST_ALERT AGE_OLDEST_ALERT,
                                    FSK_ALERTED_ENTITY.ALERTS_CNT ALERTS_CNT
                                FROM
                                    FCF71.FCFKC.FSK_ALERTED_ENTITY FSK_ALERTED_ENTITY 
                                LEFT JOIN
                                    FCF71.FCFKC.FSK_LOV ALERTED_ENTITY_LEVEL 
                                        ON ALERTED_ENTITY_LEVEL.LOV_TYPE_CODE = FSK_ALERTED_ENTITY.ALERTED_ENTITY_LEVEL_CODE AND ALERTED_ENTITY_LEVEL.LOV_TYPE_NAME='RT_ENTITY_LEVEL' AND ALERTED_ENTITY_LEVEL.LOV_LANGUAGE_DESC = 'en'
                                LEFT JOIN
                                    FCF71.FCFKC.FSK_LOV RISK_SCORE
                                        ON RISK_SCORE.LOV_TYPE_CODE = FSK_ALERTED_ENTITY.RISK_SCORE_CODE  AND RISK_SCORE.LOV_TYPE_NAME = 'RT_RISK_CLASSIFICATION' AND RISK_SCORE.LOV_LANGUAGE_DESC = 'en' 
                               LEFT JOIN FCF71.FCFKC.FSK_ENTITY_QUEUE EQ ON FSK_ALERTED_ENTITY.ALERTED_ENTITY_NUMBER = EQ.ALERTED_ENTITY_NUMBER
                               LEFT JOIN
                               FCF71.FCFCORE.FSC_PARTY_DIM PARTY on FSK_ALERTED_ENTITY.alerted_entity_number = Party.party_number AND PARTY.CHANGE_CURRENT_IND ='Y'
                               left join 
									(select 
									a.*,b.account_open_date,b.account_primary_branch_name branch_name,row_number() over (PARTITION by a.party_number order by b.account_open_date asc) Rank
									from [FCF71].[FCFCORE].[FSC_PARTY_ACCOUNT_BRIDGE] a left join [FCF71].[FCFCORE].FSC_ACCOUNT_DIM b on a.account_key= b.account_key
									where a.Role_Key=1 and a.change_current_ind='Y')
							   Party_Branch on party.party_number = Party_Branch.party_number and Party_Branch.RANK = 1
							   LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM branch_number on branch_number.branch_name = Party_Branch.branch_name and Party_Branch.CHANGE_CURRENT_IND ='Y'
							   --LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch on PARTY.STREET_STATE_CODE = Party_Branch.branch_number and Party_Branch.CHANGE_CURRENT_IND ='Y'
                                WHERE
                                    FSK_ALERTED_ENTITY.ALERTS_CNT > 0 
		                            ;

                            GO
                            ");
            migrationBuilder.Sql($@"---------------------------------------------------------------------------------------------------

                           USE [ART_DB]
                            GO

                            /****** Object:  View [FCF71.FCFKC].[ART_AML_ALERT_DETAIL_VIEW]    Script Date: 6/11/2023 3:27:21 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO

                            CREATE VIEW [ART_DB].[ART_AML_ALERT_DETAIL_VIEW] AS 
                              SELECT 
                            ALERTED_ENTITY_NUMBER,
                            ALERTED_ENTITY_NAME,
                            BRANCH_NAME,
                            BRANCH_NUMBER,
                            PARTY_TYPE_DESC,
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
                            RUN_DATE,
                            CLOSE_DATE,
                            OWNER_USERID,
                            REPORT_CLOSE_RSN,
                            POLITICALLY_EXPOSED_PERSON_IND,
                            EMPLOYEE_IND,
                            INVESTIGATION_DAYS
                            FROM
                            (
                            SELECT
                                 FSK_ALERT.ALERT_ID,
		                             FSK_ALERT.ALERTED_ENTITY_NUMBER,
                                 FSK_ALERT.ALERTED_ENTITY_NAME,
                                 upper(PARTDM.PARTY_TYPE_DESC) Party_Type_Desc,
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
                                 (case when EQ.OWNER_USERID is null then 'UNKNOWN' else EQ.OWNER_USERID end ) OWNER_USERID,
	                             isnull(PARTDM.POLITICALLY_EXPOSED_PERSON_IND,'N') POLITICALLY_EXPOSED_PERSON_IND,
                                 NULL CLOSE_DATE,
                                 '' REPORT_CLOSE_RSN,
	                             PARTDM.EMPLOYEE_IND,
                                 (Case when Party_Branch.BRANCH_NAME is null then 'UNKNOWN' else Party_Branch.BRANCH_NAME end) branch_name,
	                             branch_number.BRANCH_NUMBER,
                                 (datediff(DAY,FSK_ALERT.CREATE_DATE,getdate())) Investigation_Days
                                FROM
                                    FCF71.FCFKC.FSK_ALERT FSK_ALERT 
                                    inner join FCF71.FCFKC.FSK_ALERTED_ENTITY AE on FSK_ALERT.ALERTED_ENTITY_NUMBER = AE.ALERTED_ENTITY_NUMBER
                             LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                                    and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                                 left join 
                                    FCF71.FCFKC.FSK_LOV ALERT_SUB_CAT ON FSK_ALERT.ALERT_SUBCATEGORY_CD = ALERT_SUB_CAT.Lov_Type_Code
                                    and ALERT_SUB_CAT.LOV_TYPE_NAME='RT_CASE_SUBCATEGORY' AND ALERT_SUB_CAT.Lov_Language_Desc='en'
                                    left join FCF71.FCFCORE.FSC_PARTY_DIM PARTDM on FSK_ALERT.ALERTED_ENTITY_NUMBER = PARTDM.PARTY_NUMBER and PARTDM.CHANGE_CURRENT_IND ='Y'
                                    LEFT JOIN FCF71.FCFKC.FSK_ENTITY_QUEUE EQ ON AE.ALERTED_ENTITY_NUMBER = EQ.ALERTED_ENTITY_NUMBER
                            left join 
									(select 
									a.*,b.account_open_date,b.account_primary_branch_name branch_name,row_number() over (PARTITION by a.party_number order by b.account_open_date asc) Rank
									from [FCF71].[FCFCORE].[FSC_PARTY_ACCOUNT_BRIDGE] a left join [FCF71].[FCFCORE].FSC_ACCOUNT_DIM b on a.account_key= b.account_key
									where a.Role_Key=1 and a.change_current_ind='Y')
							        Party_Branch on PARTDM.party_number = Party_Branch.party_number and Party_Branch.RANK = 1
							        LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM branch_number on branch_number.branch_name = Party_Branch.branch_name and Party_Branch.CHANGE_CURRENT_IND ='Y'
							--left join
                            --FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch on PARTDM.STREET_STATE_CODE = Party_Branch.branch_number and Party_Branch.CHANGE_CURRENT_IND ='Y'
                                    left join FCF71.FCFKC.FSK_ALERT_CASE AC on FSK_ALERT.ALERT_ID = AC.ALERT_ID


		                            where FSK_ALERT.ALERT_STATUS_CODE='ACT'
        
                                    union all
        
                                   SELECT 
                                    FSK_ALERT.ALERT_ID,
		                                FSK_ALERT.ALERTED_ENTITY_NUMBER,
                                    FSK_ALERT.ALERTED_ENTITY_NAME,
                                    upper(PARTDM.PARTY_TYPE_DESC) Party_Type_Desc,
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
                                    isnull(PARTDM.POLITICALLY_EXPOSED_PERSON_IND,'N') POLITICALLY_EXPOSED_PERSON_IND,
                                    ALERT_EVE.CREATE_DATE CLOSE_DATE,
                                    CLOS_RN.LOV_TYPE_DESC REPORT_CLOSE_RSN,
		                            PARTDM.EMPLOYEE_IND,
                                 (Case when Party_Branch.BRANCH_NAME is null then 'UNKNOWN' else Party_Branch.BRANCH_NAME end) branch_name,
	 	                             branch_number.BRANCH_NUMBER,
                                 (datediff(day,FSK_ALERT.Run_Date,ALERT_EVE.CREATE_DATE)) Investigation_Days
                                FROM
                                    FCF71.FCFKC.FSK_ALERT FSK_ALERT 
                                    inner join 
                                    (select distinct a.ALERT_ID,a.CREATE_USER_ID,a.EVENT_DESCRIPTION,Event_Desc.LOV_TYPE_DESC,row_number() over (PARTITION by A.alert_id order by A.CREATE_DATE desc) Rank
                                    from FCF71.FCFKC.FSK_ALERT_EVENT a 
                                    LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV Event_Desc ON a.EVENT_TYPE_CODE = Event_Desc.Lov_Type_Code
                                    and Event_Desc.LOV_TYPE_NAME='RT_CLOSE_REASON' AND Event_Desc.Lov_Language_Desc='en'
                                    where
                                    a.EVENT_TYPE_CODE in ('ADD','CLS','CBC','CLC','CLR','CLS','SUE','SUP','CLP','CLA')
                                    ) AEV on FSK_ALERT.ALERT_ID = AEV.ALERT_ID and AEV.Rank=1
                             LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                                    and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
       
                                 left join 
                                    FCF71.FCFKC.FSK_LOV ALERT_SUB_CAT ON FSK_ALERT.ALERT_SUBCATEGORY_CD = ALERT_SUB_CAT.Lov_Type_Code
                                    and ALERT_SUB_CAT.LOV_TYPE_NAME='RT_CASE_SUBCATEGORY' AND ALERT_SUB_CAT.Lov_Language_Desc='en'
                                    left join FCF71.FCFCORE.FSC_PARTY_DIM PARTDM on FSK_ALERT.ALERTED_ENTITY_NUMBER = PARTDM.PARTY_NUMBER and PARTDM.CHANGE_CURRENT_IND ='Y'
                                    LEFT JOIN 
                                    (SELECT A.ALERT_ID,EVENT_DESCRIPTION,A.CREATE_DATE,row_number() over (PARTITION by A.alert_id order by A.CREATE_DATE desc) Rank FROM FCF71.FCFKC.FSK_ALERT_EVENT A 
                                    WHERE A.EVENT_TYPE_CODE in ('CLS','CLP','CLPA')
                                    ) ALERT_EVE
                                    ON FSK_ALERT.ALERT_ID = ALERT_EVE.ALERT_ID and ALERT_EVE.Rank=1
                                    LEFT JOIN
                                    FCF71.FCFKC.FSK_LOV CLOS_RN ON ALERT_EVE.EVENT_DESCRIPTION = CLOS_RN.Lov_Type_Code
                                    and CLOS_RN.LOV_TYPE_NAME='RT_CLOSE_REASON' AND CLOS_RN.Lov_Language_Desc='en'
                                   left join 
									(select 
									a.*,b.account_open_date,b.account_primary_branch_name branch_name,row_number() over (PARTITION by a.party_number order by b.account_open_date asc) Rank
									from [fcf71].[FCFCORE].[FSC_PARTY_ACCOUNT_BRIDGE] a left join [fcf71].[FCFCORE].FSC_ACCOUNT_DIM b on a.account_key= b.account_key
									where a.Role_Key=1 and a.change_current_ind='Y')
							        Party_Branch on PARTDM.party_number = Party_Branch.party_number and Party_Branch.RANK = 1
								    LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM branch_number on branch_number.branch_name = Party_Branch.branch_name and Party_Branch.CHANGE_CURRENT_IND ='Y'
								   --left join
                            --FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch on PARTDM.STREET_STATE_CODE = Party_Branch.branch_number and Party_Branch.CHANGE_CURRENT_IND ='Y'
                             left join FCF71.FCFKC.FSK_ALERT_CASE AC on FSK_ALERT.ALERT_ID = AC.ALERT_ID
                                    where  
                                     FSK_ALERT.ALERT_STATUS_CODE <> 'ACT' 
                                     )a
		 
		                             ;

                            GO


                            -----------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  View [FCF71.FCFCORE].[ART_AML_CUSTOMERS_DETAILS_VIEW]    Script Date: 6/11/2023 3:18:06 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO






                            CREATE VIEW [ART_DB].[ART_AML_CUSTOMERS_DETAILS_VIEW]  AS 
                              SELECT        
                            FCF71.FCFCORE.FSC_PARTY_DIM.party_name customer_name,
                            FCF71.FCFCORE.FSC_PARTY_DIM.party_number customer_number,
                            FCF71.FCFCORE.FSC_PARTY_DIM.party_type_desc customer_type,
                            FCF71.FCFCORE.FSC_PARTY_DIM.party_identification_id customer_identification_id,
                            FCF71.FCFCORE.FSC_PARTY_DIM.party_identification_type_desc customer_identification_type, 
                            FCF71.FCFCORE.FSC_PARTY_DIM.party_date_of_birth customer_date_of_birth, 
                            (case when Risk.lov_type_desc is null then 'Unknown' else Risk.lov_type_desc end ) AS RISK_CLASSIFICATION,
                            FCF71.FCFCORE.FSC_PARTY_DIM.PARTY_TAX_ID Customer_Tax_ID,
                            FCF71.FCFCORE.FSC_PARTY_DIM.DOING_BUSINESS_AS_NAME,
                            FCF71.FCFCORE.FSC_PARTY_DIM.street_state_name Governorate_name,
                            FCF71.FCFCORE.FSC_PARTY_DIM.street_address_1,
                            FCF71.FCFCORE.FSC_PARTY_DIM.street_city_name City_name,
                            FCF71.FCFCORE.FSC_PARTY_DIM.party_status_desc Customer_status,
                            FCF71.FCFCORE.FSC_PARTY_DIM.STREET_POSTAL_CODE,
                            FCF71.FCFCORE.FSC_PARTY_DIM.STREET_COUNTRY_CODE,
                            FCF71.FCFCORE.FSC_PARTY_DIM.STREET_COUNTRY_NAME,
                            FCF71.FCFCORE.FSC_PARTY_DIM.MAILING_ADDRESS_1,
                            FCF71.FCFCORE.FSC_PARTY_DIM.MAILING_CITY_NAME,
                            FCF71.FCFCORE.FSC_PARTY_DIM.MAILING_POSTAL_CODE,
                            FCF71.FCFCORE.FSC_PARTY_DIM.MAILING_COUNTRY_NAME,
                            FCF71.FCFCORE.FSC_PARTY_DIM.RESIDENCE_COUNTRY_NAME,
                            FCF71.FCFCORE.FSC_PARTY_DIM.CITIZENSHIP_COUNTRY_NAME,
                            FCF71.FCFCORE.FSC_PARTY_DIM.EMPLOYEE_IND AS Is_EMPLOYEE,
                            FCF71.FCFCORE.FSC_PARTY_DIM.EMPLOYEE_NUMBER,
                            FCF71.FCFCORE.FSC_PARTY_DIM.EMPLOYER_NAME,
                            FCF71.FCFCORE.FSC_PARTY_DIM.EMPLOYER_PHONE_NUMBER,
                            FCF71.FCFCORE.FSC_PARTY_DIM.EMAIL_ADDRESS,
                            FCF71.FCFCORE.FSC_PARTY_DIM.occupation_desc,
                            FCF71.FCFCORE.FSC_PARTY_DIM.industry_desc, 
                            FCF71.FCFCORE.FSC_PARTY_DIM.PHONE_NUMBER_1, 
                            FCF71.FCFCORE.FSC_PARTY_DIM.PHONE_NUMBER_2, 
                            FCF71.FCFCORE.FSC_PARTY_DIM.PHONE_NUMBER_3, 
                            FCF71.FCFCORE.FSC_PARTY_DIM.ANNUAL_INCOME_AMOUNT,
                            FCF71.FCFCORE.FSC_PARTY_DIM.NET_WORTH_AMOUNT,
                            FCF71.FCFCORE.FSC_PARTY_DIM.MARITAL_STATUS_DESC,
                            FCF71.FCFCORE.FSC_PARTY_DIM.CUSTOMER_SINCE_DATE, 
                            FCF71.FCFCORE.FSC_PARTY_DIM.LAST_RISK_ASSESSMENT_DATE,    
                            FCF71.FCFCORE.FSC_PARTY_DIM.non_profit_org_ind,
                            FCF71.FCFCORE.FSC_PARTY_DIM.politically_exposed_person_ind,
                            Risk.ACTIVE_FLG,
                            (Case when Party_Branch.BRANCH_NAME is null then 'Unknown' else Party_Branch.BRANCH_NAME end) BRANCH_NAME,
                            branch_number.BRANCH_NUMBER

                            FROM            
                            FCF71.FCFCORE.FSC_PARTY_DIM LEFT OUTER JOIN
                            FCF71.FCFKC.FSK_LOV Risk ON FCF71.FCFCORE.FSC_PARTY_DIM.risk_classification = Risk.lov_type_code AND Risk.lov_language_desc = 'en'
                            AND Risk.lov_type_name = 'RT_RISK_CLASSIFICATION'  
                           left join 
									(select 
									a.*,b.account_open_date,b.account_primary_branch_name branch_name,row_number() over (PARTITION by a.party_number order by b.account_open_date asc) Rank
									from [FCF71].[FCFCORE].[FSC_PARTY_ACCOUNT_BRIDGE] a left join [FCF71].[FCFCORE].FSC_ACCOUNT_DIM b on a.account_key= b.account_key
									where a.Role_Key=1 and a.change_current_ind='Y')
							   Party_Branch on FSC_PARTY_DIM.party_number = Party_Branch.party_number and Party_Branch.RANK = 1
							   LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM branch_number on branch_number.branch_name = Party_Branch.branch_name and Party_Branch.CHANGE_CURRENT_IND ='Y'
							   
						    --LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM BRAN ON FSC_PARTY_DIM.STREET_STATE_CODE = BRAN.BRANCH_Number and bran.change_current_ind='Y'
                            WHERE (FCF71.FCFCORE.FSC_PARTY_DIM.party_key > - 1 and FSC_PARTY_DIM.change_current_ind = 'y'
                            );

                            GO


                            ---------------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  View [FCF71.FCFKC].[ART_AML_CASE_DETAILS_VIEW]    Script Date: 6/11/2023 3:28:54 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO

                            CREATE VIEW [ART_DB].[ART_AML_CASE_DETAILS_VIEW] AS 
                               SELECT 
                            ""CASE"".CASE_ID,
                            FSK_CASE_ENTITY.ENTITY_NAME,
                            FSK_CASE_ENTITY.ENTITY_NUMBER,
                            PARTY_BRANCH.BRANCH_NAME,
                            branch_number.BRANCH_NUMBER,
                            ""CASE_PRIORITY"".LOV_TYPE_DESC ""CASE_PRIORITY"",
                            ""CASE_STATUS"".LOV_TYPE_DESC ""CASE_STATUS"",
                            ""CASE_CATEGORY"".LOV_TYPE_DESC ""CASE_CATEGORY"",
                            ""CASE_SUBCATEGORY"".LOV_TYPE_DESC ""CASE_SUB_CATEGORY"",
                            ""ENTITY_LEVEL"".LOV_TYPE_DESC ""ENTITY_LEVEL"",
                            ""CASE"".CREATE_USER_ID ""CREATED_BY"", 
                            ""CASE"".OWNER_USER_LONG_ID ""OWNER"",
                            ""CASE"".CREATE_DATE,
                            '' Closed_Date

                            FROM FCF71.FCFKC.FSK_CASE ""CASE"" LEFT JOIN
                            FCF71.FCFKC.FSK_LOV ""CASE_STATUS"" ON ""CASE_STATUS"".LOV_TYPE_CODE = ""CASE"".CASE_STATUS_CODE
                            AND ""CASE_STATUS"".LOV_TYPE_NAME ='FCF_CASE_STATUS' AND ""CASE_STATUS"".LOV_LANGUAGE_DESC ='en'
                            LEFT JOIN FCF71.FCFKC.FSK_LOV ""CASE_CATEGORY"" ON ""CASE_CATEGORY"".LOV_TYPE_CODE = ""CASE"".CASE_CATEGORY_CODE
                            AND ""CASE_CATEGORY"".LOV_TYPE_NAME ='RT_CASE_CATEGORY' AND ""CASE_CATEGORY"".LOV_LANGUAGE_DESC ='en'
                            LEFT JOIN FCF71.FCFKC.FSK_LOV ""CASE_SUBCATEGORY"" ON ""CASE_SUBCATEGORY"".LOV_TYPE_CODE = ""CASE"".CASE_SUB_CATEGORY_CODE
                            AND ""CASE_SUBCATEGORY"".LOV_TYPE_NAME ='RT_CASE_SUBCATEGORY' AND ""CASE_SUBCATEGORY"".LOV_LANGUAGE_DESC ='en'
                            LEFT JOIN FCF71.FCFKC.FSK_LOV ""CASE_PRIORITY"" ON ""CASE_PRIORITY"".LOV_TYPE_CODE = ""CASE"".CASE_PRIORITY_CODE
                            AND ""CASE_PRIORITY"".LOV_TYPE_NAME ='X_RT_PRIORITY' AND ""CASE_PRIORITY"".LOV_LANGUAGE_DESC ='en'
                            LEFT JOIN FCF71.FCFKC.FSK_CASE_ENTITY ON FSK_CASE_ENTITY.CASE_ID = ""CASE"".CASE_ID
                            LEFT JOIN FCF71.FCFKC.FSK_LOV ""ENTITY_LEVEL"" ON FSK_CASE_ENTITY.ENTITY_LEVEL_CODE = ENTITY_LEVEL.LOV_TYPE_CODE
                            AND ENTITY_LEVEL.LOV_TYPE_NAME ='RT_CASE_ENTITY_LEVEL' AND ENTITY_LEVEL.LOV_LANGUAGE_DESC ='en'
                            left JOIN FCF71.FCFCORE.FSC_PARTY_DIM PARTY ON FSK_CASE_ENTITY.ENTITY_NUMBER = party.PARTY_NUMBER and party.CHANGE_CURRENT_IND ='Y'
                            left join 
									(select 
									a.*,b.account_open_date,b.account_primary_branch_name branch_name,row_number() over (PARTITION by a.party_number order by b.account_open_date asc) Rank
									from [FCF71].[FCFCORE].[FSC_PARTY_ACCOUNT_BRIDGE] a left join [FCF71].[FCFCORE].FSC_ACCOUNT_DIM b on a.account_key= b.account_key
									where a.Role_Key=1 and a.change_current_ind='Y')
							   Party_Branch on party.party_number = Party_Branch.party_number and Party_Branch.RANK = 1
							   LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM branch_number on branch_number.branch_name = Party_Branch.branch_name and Party_Branch.CHANGE_CURRENT_IND ='Y'
							  
							--LEFT JOIN
                           -- FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch on PARTY.STREET_STATE_CODE = Party_Branch.branch_number and Party_Branch.CHANGE_CURRENT_IND ='Y'
                            WHERE
                            CASE_STATUS.LOV_TYPE_DESC ='Open'
                            AND entity_level_code ='PTY'

                            union all

                            SELECT 
                            ""CASE"".CASE_ID,
                            FSK_CASE_ENTITY.ENTITY_NAME,
                            FSK_CASE_ENTITY.ENTITY_NUMBER,
                            PARTY_BRANCH.BRANCH_NAME,
                            branch_number.BRANCH_NUMBER,
                            ""CASE_PRIORITY"".LOV_TYPE_DESC ""CASE_PRIORITY"",
                            ""CASE_STATUS"".LOV_TYPE_DESC ""CASE_STATUS"",
                            ""CASE_CATEGORY"".LOV_TYPE_DESC ""CASE_CATEGORY"",
                            ""CASE_SUBCATEGORY"".LOV_TYPE_DESC ""CASE_SUB_CATEGORY"",
                            ""ENTITY_LEVEL"".LOV_TYPE_DESC ""ENTITY_LEVEL"",
                            ""CASE"".CREATE_USER_ID ""CREATED_BY"", 
                            ""CASE"".OWNER_USER_LONG_ID ""OWNER"",
                            ""CASE"".CREATE_DATE,
                            ""case"".LSTUPDATE_DATE Close_Date

                            FROM FCF71.FCFKC.FSK_CASE ""CASE"" LEFT JOIN
                            FCF71.FCFKC.FSK_LOV ""CASE_STATUS"" ON ""CASE_STATUS"".LOV_TYPE_CODE = ""CASE"".CASE_STATUS_CODE
                            AND ""CASE_STATUS"".LOV_TYPE_NAME ='FCF_CASE_STATUS' AND ""CASE_STATUS"".LOV_LANGUAGE_DESC ='en'
                            LEFT JOIN FCF71.FCFKC.FSK_LOV ""CASE_CATEGORY"" ON CASE_CATEGORY.LOV_TYPE_CODE = ""CASE"".CASE_CATEGORY_CODE
                            AND ""CASE_CATEGORY"".LOV_TYPE_NAME ='RT_CASE_CATEGORY' AND ""CASE_CATEGORY"".LOV_LANGUAGE_DESC ='en'
                            LEFT JOIN FCF71.FCFKC.FSK_LOV ""CASE_SUBCATEGORY"" ON ""CASE_SUBCATEGORY"".LOV_TYPE_CODE = ""CASE"".CASE_SUB_CATEGORY_CODE
                            AND ""CASE_SUBCATEGORY"".LOV_TYPE_NAME ='RT_CASE_SUBCATEGORY' AND ""CASE_SUBCATEGORY"".LOV_LANGUAGE_DESC ='en'
                            LEFT JOIN FCF71.FCFKC.FSK_LOV ""CASE_PRIORITY"" ON ""CASE_PRIORITY"".LOV_TYPE_CODE = ""CASE"".CASE_PRIORITY_CODE
                            AND ""CASE_PRIORITY"".LOV_TYPE_NAME ='X_RT_PRIORITY' AND ""CASE_PRIORITY"".LOV_LANGUAGE_DESC ='en'
                            LEFT JOIN FCF71.FCFKC.FSK_CASE_ENTITY ON FSK_CASE_ENTITY.CASE_ID = ""CASE"".CASE_ID
                            LEFT JOIN FCF71.FCFKC.FSK_LOV ""ENTITY_LEVEL"" ON FSK_CASE_ENTITY.ENTITY_LEVEL_CODE = ""ENTITY_LEVEL"".LOV_TYPE_CODE
                            AND ""ENTITY_LEVEL"".LOV_TYPE_NAME ='RT_CASE_ENTITY_LEVEL' AND ""ENTITY_LEVEL"".LOV_LANGUAGE_DESC ='en'
                            left JOIN FCF71.FCFCORE.FSC_PARTY_DIM PARTY ON FSK_CASE_ENTITY.ENTITY_NUMBER = party.PARTY_NUMBER and party.CHANGE_CURRENT_IND ='Y'
                            left join 
									(select 
									a.*,b.account_open_date,b.account_primary_branch_name branch_name,row_number() over (PARTITION by a.party_number order by b.account_open_date asc) Rank
									from [FCF71].[FCFCORE].[FSC_PARTY_ACCOUNT_BRIDGE] a left join [FCF71].[FCFCORE].FSC_ACCOUNT_DIM b on a.account_key= b.account_key
									where a.Role_Key=1 and a.change_current_ind='Y')
							   Party_Branch on party.party_number = Party_Branch.party_number and Party_Branch.RANK = 1
							   LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM branch_number on branch_number.branch_name = Party_Branch.branch_name and Party_Branch.CHANGE_CURRENT_IND ='Y'
							  
							--LEFT JOIN
                            --FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch on PARTY.STREET_STATE_CODE = Party_Branch.branch_number and Party_Branch.CHANGE_CURRENT_IND ='Y'
                            WHERE
                            ""CASE_STATUS"".LOV_TYPE_DESC <>'Open'
                            AND entity_level_code ='PTY'
                            GO

                            -----------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  View [FCF71.FCFCORE].[ART_AML_HIGH_RISK_CUST_VIEW]    Script Date: 6/11/2023 3:18:36 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO

                            CREATE VIEW [ART_DB].[ART_AML_HIGH_RISK_CUST_VIEW] AS 
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
                                    FSC_PARTY_DIM.POLITICALLY_EXPOSED_PERSON_IND AS POLITICALLY_EXPOSED_PERSON_IND,
		                            RISK_CLASS.LOV_TYPE_DESC RISK_CLASSIFICATION,
                                    PARTY_BRANCH.BRANCH_NAME,
		                            branch_number.BRANCH_NUMBER
                                FROM
                                    FCF71.FCFCORE.FSC_PARTY_DIM FSC_PARTY_DIM 
									left join 
									(select 
									a.*,b.account_open_date,b.account_primary_branch_name branch_name,row_number() over (PARTITION by a.party_number order by b.account_open_date asc) Rank
									from [FCF71].[FCFCORE].[FSC_PARTY_ACCOUNT_BRIDGE] a left join [FCF71].[FCFCORE].FSC_ACCOUNT_DIM b on a.account_key= b.account_key
									where a.Role_Key=1 and a.change_current_ind='Y')
							        Party_Branch on FSC_PARTY_DIM.party_number = Party_Branch.party_number and Party_Branch.RANK = 1
							        LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM branch_number on branch_number.branch_name = Party_Branch.branch_name and Party_Branch.CHANGE_CURRENT_IND ='Y'
							  
                                    --LEFT JOIN
                                    --FCF71.FCFCORE.FSC_BRANCH_DIM PARTY_BRANCH ON FSC_PARTY_DIM.STREET_STATE_CODE = PARTY_BRANCH.branch_number and PARTY_BRANCH.change_current_ind='Y'
                                     LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV RISK_CLASS on FSC_PARTY_DIM.RISK_CLASSIFICATION = RISK_CLASS.LOV_TYPE_CODE and RISK_CLASS.LOV_TYPE_NAME ='RT_RISK_CLASSIFICATION' and RISK_CLASS.LOV_LANGUAGE_DESC='en'
                                    WHERE
                                    FSC_PARTY_DIM.RISK_CLASSIFICATION > 1
		                            and FSC_PARTY_DIM.party_key > - 1 and FSC_PARTY_DIM.change_current_ind = 'y'

                            GO



                            ----------------------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  View [FCF71.FCFCORE].[ART_AML_RISK_ASSESSMENT_VIEW]    Script Date: 6/11/2023 3:20:07 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO

                            CREATE VIEW [ART_DB].[ART_AML_RISK_ASSESSMENT_VIEW] AS
                            SELECT
                                    RISK_STATUS.LOV_TYPE_DESC RISK_STATUS,
                                    RISK_CLASS.LOV_TYPE_DESC RISK_CLASS,
                                    PROPOSED_RISK_CLASS.LOV_TYPE_DESC PROPOSED_RISK_CLASS,        
                                    PARTY_BRANCH.BRANCH_NAME  AS BRANCH_NAME,
		                            branch_number.BRANCH_NUMBER BRANCH_NUMBER,
                                    FSK_RISK_ASSESSMENT.RISK_ASSESSMENT_ID  AS RISK_ASSESSMENT_ID,
                                    FSK_RISK_ASSESSMENT.PARTY_NUMBER  AS PARTY_NUMBER,
                                    FSK_RISK_ASSESSMENT.PARTY_NAME AS PARTY_NAME,
                                    FSK_RISK_ASSESSMENT.RISK_ASSESSMENT_DURATION  AS RISK_ASSESSMENT_DURATION,
                                    FSK_RISK_ASSESSMENT.CREATE_DATE AS CREATE_DATE,
                                    FSK_RISK_ASSESSMENT.CREATE_USER_ID AS CREATE_USER_ID,
                                    FSK_RISK_ASSESSMENT.VERSION_NUMBER  AS VERSION_NUMBER,
                                    FSK_RISK_ASSESSMENT.ASSESSMENT_TYPE_CD AS ASSESSMENT_TYPE_CD,
                                    FSK_RISK_ASSESSMENT.ASSESSMENT_CATEGORY_CD AS ASSESSMENT_CATEGORY_CD,
                                    FSK_RISK_ASSESSMENT.ASSESSMENT_SUBCATEGORY_CD AS ASSESSMENT_SUBCATEGORY_CD,
                                    FSK_RISK_ASSESSMENT.OWNER_USER_LONG_ID AS OWNER_USER_LONG_ID
                                FROM
                                    FCF71.FCFKC.FSK_RISK_ASSESSMENT FSK_RISK_ASSESSMENT 
                                LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV RISK_STATUS on FSK_RISK_ASSESSMENT.RISK_ASSESSMENT_STATUS_CODE = RISK_STATUS.LOV_TYPE_CODE and RISK_STATUS.LOV_TYPE_NAME ='RT_ASMT_STATUS' and RISK_STATUS.LOV_LANGUAGE_DESC='en'
                                LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV RISK_CLASS on FSK_RISK_ASSESSMENT.RISK_CLASSIFICATION = RISK_CLASS.LOV_TYPE_CODE and RISK_CLASS.LOV_TYPE_NAME ='RT_RISK_CLASSIFICATION' and RISK_CLASS.LOV_LANGUAGE_DESC='en'
                                LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV PROPOSED_RISK_CLASS on FSK_RISK_ASSESSMENT.PROPOSED_RISK_CLASSIFICATION = PROPOSED_RISK_CLASS.LOV_TYPE_CODE and PROPOSED_RISK_CLASS.LOV_TYPE_NAME ='RT_RISK_CLASSIFICATION' and PROPOSED_RISK_CLASS.LOV_LANGUAGE_DESC='en'
                                LEFT JOIN
                                    FCF71.FCFCORE.FSC_PARTY_DIM PARTY ON FSK_RISK_ASSESSMENT.PARTY_NUMBER = PARTY.PARTY_NUMBER
                                     left join 
									(select 
									a.*,b.account_open_date,b.account_primary_branch_name branch_name,row_number() over (PARTITION by a.party_number order by b.account_open_date asc) Rank
									from [FCF71].[FCFCORE].[FSC_PARTY_ACCOUNT_BRIDGE] a left join [FCF71].[FCFCORE].FSC_ACCOUNT_DIM b on a.account_key= b.account_key
									where a.Role_Key=1 and a.change_current_ind='Y')
							        Party_Branch on party.party_number = Party_Branch.party_number and Party_Branch.RANK = 1
							        LEFT JOIN FCF71.FCFCORE.FSC_BRANCH_DIM branch_number on branch_number.branch_name = Party_Branch.branch_name and Party_Branch.CHANGE_CURRENT_IND ='Y'
							   
									 --LEFT JOIN
                                    --FCF71.FCFCORE.FSC_BRANCH_DIM PARTY_BRANCH ON PARTY.STREET_STATE_CODE = PARTY_BRANCH.branch_number and PARTY_BRANCH.change_current_ind='Y'
                                    WHERE PARTY.CHANGE_CURRENT_IND='Y' and PARTY.party_key > - 1

                            GO






                            ------------------------------------------------------------------------------------------------
                            ");

            //procs
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFKC].[ART_ST_ALERT_PER_OWNER]    Script Date: 6/11/2023 3:40:16 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO



                              CREATE PROCEDURE [ART_DB].[ART_ST_ALERT_PER_OWNER]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                           select (case when a.OWNER_USERID is null then 'UNKNOWN' else a.OWNER_USERID end) AS OWNER_USERID,
                             CAST(count(distinct alert_id) AS DECIMAL(10, 0)) ALERTS_CNT_SUM 
                            from (
                            select  FSK_ENTITY_QUEUE.OWNER_USERID OWNER_USERID, alert_id
                            from FCF71.FCFKC.FSK_ALERT
                            left join FCF71.FCFKC.FSK_ENTITY_QUEUE on FSK_ALERT.ALERTED_ENTITY_NUMBER = FSK_ENTITY_QUEUE.ALERTED_ENTITY_NUMBER 
                            and FSK_ALERT.ALERT_STATUS_CODE='ACT'
                            where CAST(FSK_ALERT.create_date AS date) >= @V_START_DATE AND CAST(FSK_ALERT.create_date AS date) <= @V_END_DATE

                            union

                            select FSK_ENTITY_QUEUE.queue_code OWNER_USERID ,alert_id
                            from FCF71.FCFKC.FSK_ALERT
                            left join FCF71.FCFKC.FSK_ENTITY_QUEUE on FSK_ALERT.ALERTED_ENTITY_NUMBER = FSK_ENTITY_QUEUE.ALERTED_ENTITY_NUMBER 
                            and FSK_ALERT.ALERT_STATUS_CODE='ACT'
                            where CAST(FSK_ALERT.create_date AS date) >= @V_START_DATE AND CAST(FSK_ALERT.create_date AS date) <= @V_END_DATE
	                            ) a
	                            GROUP BY
                                    (case when a.OWNER_USERID is null then 'UNKNOWN' else a.OWNER_USERID end);
                            END ;
                            GO

                            -------------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFKC].[ART_ST_AML_ALERTS_PER_STATUS]    Script Date: 6/11/2023 3:41:11 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO

                              CREATE PROCEDURE [ART_DB].[ART_ST_AML_ALERTS_PER_STATUS]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;
                            select ALERT_STATUS.LOV_TYPE_DESC ALERT_STATUS,
                             CAST(count(FSK_ALERT.alert_id) AS DECIMAL(10, 0)) ALERTS_COUNT
                             FROM
                                    FCF71.FCFKC.FSK_ALERT FSK_ALERT 
		                            LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                                    and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                            where   CAST(FSK_ALERT.create_date AS date) >= @V_START_DATE AND CAST(FSK_ALERT.create_date AS date) <= @V_END_DATE
                            group by ALERT_STATUS.LOV_TYPE_DESC 
                            ;
                        END ;
                            GO

                            ----------------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFKC].[ART_ST_CASES_PER_CATEGORY]    Script Date: 6/11/2023 3:41:41 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO



                              CREATE PROCEDURE [ART_DB].[ART_ST_CASES_PER_CATEGORY]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                            select 
                            CASE_CATEGORY.lov_type_desc CASE_CATEGORY , CAST(count(1) AS DECIMAL(10, 0)) NUMBER_OF_CASES
                            FROM FCF71.FCFKC.FSK_CASE FSK_CASE 
                            LEFT JOIN FCF71.FCFKC.FSK_LOV CASE_CATEGORY ON CASE_CATEGORY.LOV_TYPE_CODE = FSK_CASE.CASE_CATEGORY_CODE
                            AND CASE_CATEGORY.LOV_TYPE_NAME ='RT_CASE_CATEGORY' AND CASE_CATEGORY.LOV_LANGUAGE_DESC ='en'
                            where CAST(create_date AS date) >= @V_START_DATE AND CAST(create_date AS date) <= @V_END_DATE
                            GROUP BY --CASE_CATEGORY
                            CASE_CATEGORY.lov_type_desc
                            ;
                            END ;
                            GO

                            ----------------------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFKC].[ART_ST_CASES_PER_PRIORITY]    Script Date: 6/11/2023 3:42:11 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO



                              CREATE PROCEDURE [ART_DB].[ART_ST_CASES_PER_PRIORITY]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                            select 
                            CASE_PRIORITY.lov_type_desc CASE_PRIORITY , CAST(count(1) AS DECIMAL(10, 0)) NUMBER_OF_CASES
                            FROM FCF71.FCFKC.FSK_CASE  
                            LEFT JOIN FCF71.FCFKC.FSK_LOV CASE_PRIORITY ON CASE_PRIORITY.LOV_TYPE_CODE = FSK_CASE.CASE_PRIORITY_CODE
                            AND CASE_PRIORITY.LOV_TYPE_NAME ='X_RT_PRIORITY' AND CASE_PRIORITY.LOV_LANGUAGE_DESC ='en'
                            where CAST(create_date AS date) >= @V_START_DATE AND CAST(create_date AS date) <= @V_END_DATE
                            GROUP BY CASE_PRIORITY.lov_type_desc
                            ;
                               END ;
                            GO

                            ------------------------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFKC].[ART_ST_CASES_PER_STATUS]    Script Date: 6/11/2023 3:42:40 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO



                              CREATE  PROCEDURE [ART_DB].[ART_ST_CASES_PER_STATUS]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                            select  
                            case_status.lov_type_desc CASE_STATUS ,
                             CAST(COUNT(*) AS DECIMAL(10, 0)) NUMBER_OF_CASES
                            FROM FCF71.FCFKC.FSK_CASE FSK_CASE 
                            LEFT JOIN FCF71.FCFKC.FSK_LOV CASE_STATUS 
                            ON CASE_STATUS.LOV_TYPE_CODE = FSK_CASE.CASE_STATUS_CODE 
                            AND CASE_STATUS.LOV_TYPE_NAME ='FCF_CASE_STATUS' 
                            AND CASE_STATUS.LOV_LANGUAGE_DESC ='en'
                            where CAST(create_date AS date) >= @V_START_DATE AND CAST(create_date AS date) <= @V_END_DATE
                            GROUP BY 
                            case_status.lov_type_desc
                            ;
                            END ;
                            GO

                            ---------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"


                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFKC].[ART_ST_CASES_PER_SUBCAT]    Script Date: 6/11/2023 3:43:11 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO



                              CREATE PROCEDURE [ART_DB].[ART_ST_CASES_PER_SUBCAT]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                             select CASE_SUBCATEGORY.lov_type_desc CASE_SUBCATEGORY , CAST(count(1) AS DECIMAL(10, 0)) NUMBER_OF_CASES
                            FROM FCF71.FCFKC.FSK_CASE  
                            LEFT JOIN FCF71.FCFKC.FSK_LOV CASE_SUBCATEGORY ON CASE_SUBCATEGORY.LOV_TYPE_CODE = FSK_CASE.CASE_SUB_CATEGORY_CODE
                            AND CASE_SUBCATEGORY.LOV_TYPE_NAME ='RT_CASE_SUBCATEGORY' AND CASE_SUBCATEGORY.LOV_LANGUAGE_DESC ='en'
                            where CAST(create_date AS date) >= @V_START_DATE AND CAST(create_date AS date) <= @V_END_DATE
                            GROUP BY
                            CASE_SUBCATEGORY.lov_type_desc
                            ;
                             END ;
                            GO

                            ----------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFCORE].[ART_ST_CUST_PER_BRANCH]    Script Date: 6/11/2023 3:39:08 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO




                              CREATE PROCEDURE [ART_DB].[ART_ST_CUST_PER_BRANCH]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                            SELECT        
                            (Case when Party_Branch.BRANCH_NAME is null then 'Unknown' else Party_Branch.BRANCH_NAME end) BRANCH_NAME
							, CAST(count(FCF71.FCFCORE.fsc_party_dim.party_key)AS DECIMAL(10, 0)) NUMBER_OF_CUSTOMERS
                            FROM            
                            FCF71.FCFCORE.FSC_PARTY_DIM 
                            left join 
									(select 
									a.*,b.account_open_date,b.account_primary_branch_name branch_name,row_number() over (PARTITION by a.party_number order by b.account_open_date asc) Rank
									from [FCF71].[FCFCORE].[FSC_PARTY_ACCOUNT_BRIDGE] a left join [FCF71].[FCFCORE].FSC_ACCOUNT_DIM b on a.account_key= b.account_key
									where a.Role_Key=1 and a.change_current_ind='Y')
							   Party_Branch on FSC_PARTY_DIM.party_number = Party_Branch.party_number and Party_Branch.RANK = 1
							  
							--LEFT JOIN
                            --FCF71.FCFCORE.FSC_BRANCH_DIM Party_Branch ON FSC_PARTY_DIM.STREET_STATE_CODE = Party_Branch.BRANCH_NUMBER 
                            AND party_branch.change_current_ind = 'Y'
                            WHERE (FCF71.FCFCORE.FSC_PARTY_DIM.party_key > - 1 and FCF71.FCFCORE.fsc_party_dim.change_current_ind='Y')
                            and CAST(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE AS date) >= @V_START_DATE AND CAST(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE AS date) <= @V_END_DATE
                            group by Party_Branch.branch_name;
                            END ;
                            GO


                            -----------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFCORE].[ART_ST_CUST_PER_RISK]    Script Date: 6/11/2023 3:39:08 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO




                              CREATE PROCEDURE [ART_DB].[ART_ST_CUST_PER_RISK]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                            SELECT        
                            (case when Risk.lov_type_desc is null then 'UNKNOWN' else Risk.lov_type_desc end) RISK_CLASSIFICATION,
                            CAST(count(FCF71.FCFCORE.fsc_party_dim.party_key)AS DECIMAL(10, 0)) NUMBER_OF_CUSTOMERS
                            FROM            
                            FCF71.FCFCORE.FSC_PARTY_DIM 
                            LEFT OUTER JOIN
                            FCF71.FCFKC.FSK_LOV Risk ON FCF71.FCFCORE.FSC_PARTY_DIM.risk_classification = Risk.lov_type_code AND Risk.lov_language_desc = 'en'
                            AND Risk.lov_type_name = 'RT_RISK_CLASSIFICATION'  
                            WHERE (FCF71.FCFCORE.FSC_PARTY_DIM.party_key > - 1 and FCF71.FCFCORE.fsc_party_dim.change_current_ind='Y')
                            and CAST(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE AS date) >= @V_START_DATE AND CAST(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE AS date) <= @V_END_DATE
                            group by (case when Risk.lov_type_desc is null then 'UNKNOWN' else Risk.lov_type_desc end);
                            END;
                            GO

                            -----------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFCORE].[ART_ST_CUST_PER_TYPE]    Script Date: 6/11/2023 3:39:42 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO

                              CREATE PROCEDURE [ART_DB].[ART_ST_CUST_PER_TYPE]
                            (
                            @V_START_DATE date , 
                            @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                             SELECT        
                            (case when FCF71.FCFCORE.FSC_PARTY_DIM.party_type_desc = 'organization' then 'ORGANIZATION' 
                            when FCF71.FCFCORE.FSC_PARTY_DIM.party_type_desc is null then 'UNKNOWN'
                            when FCF71.FCFCORE.FSC_PARTY_DIM.party_type_desc =' 'then 'UNKNOWN'
                            else FCF71.FCFCORE.FSC_PARTY_DIM.party_type_desc
                            end
                            ) CUSTOMER_TYPE,
                            CAST(count(FCF71.FCFCORE.fsc_party_dim.party_key) AS DECIMAL(10, 0)) NUMBER_OF_CUSTOMERS
                            FROM            
                            FCF71.FCFCORE.FSC_PARTY_DIM 
                            WHERE (FCF71.FCFCORE.FSC_PARTY_DIM.party_key > - 1 and FCF71.FCFCORE.fsc_party_dim.change_current_ind='Y')
                            and CAST(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE AS date) >= @V_START_DATE AND CAST(FSC_PARTY_DIM.CUSTOMER_SINCE_DATE AS date) <= @V_END_DATE
                            group by (case when FCF71.FCFCORE.FSC_PARTY_DIM.party_type_desc = 'organization' then 'ORGANIZATION' 
                            when FCF71.FCFCORE.FSC_PARTY_DIM.party_type_desc is null then 'UNKNOWN'
                            when FCF71.FCFCORE.FSC_PARTY_DIM.party_type_desc =' 'then 'UNKNOWN'
                            else FCF71.FCFCORE.FSC_PARTY_DIM.party_type_desc
                            end
                            );
                            END;
                            GO

                            --------------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFCORE].[ART_ST_AML_PROP_RISK_CLASS]    Script Date: 6/11/2023 3:38:12 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO



                              CREATE  PROCEDURE [ART_DB].[ART_ST_AML_PROP_RISK_CLASS]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

 
                             select 
                             (case when PROPOSED_RISK_CLASS.lov_type_desc is null then 'UNKNOWN' else PROPOSED_RISK_CLASS.lov_type_desc end) AS PROPOSED_RISK_CLASS,
                             CAST(count(PARTY.party_key) AS DECIMAL(10, 0)) NUMBER_OF_CUSTOMERS
                             FROM
                                    FCF71.FCFKC.FSK_RISK_ASSESSMENT FSK_RISK_ASSESSMENT 
                                LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV PROPOSED_RISK_CLASS on FSK_RISK_ASSESSMENT.PROPOSED_RISK_CLASSIFICATION = PROPOSED_RISK_CLASS.LOV_TYPE_CODE and PROPOSED_RISK_CLASS.LOV_TYPE_NAME ='RT_RISK_CLASSIFICATION' and PROPOSED_RISK_CLASS.LOV_LANGUAGE_DESC='en'
                                LEFT JOIN
                                    FCF71.FCFCORE.FSC_PARTY_DIM PARTY ON FSK_RISK_ASSESSMENT.PARTY_NUMBER = PARTY.PARTY_NUMBER
                                    LEFT JOIN 
                                FCF71.FCFKC.FSK_LOV RISK_STATUS on FSK_RISK_ASSESSMENT.RISK_ASSESSMENT_STATUS_CODE = RISK_STATUS.LOV_TYPE_CODE and RISK_STATUS.LOV_TYPE_NAME ='RT_ASMT_STATUS' and RISK_STATUS.LOV_LANGUAGE_DESC='en'
									WHERE PARTY.CHANGE_CURRENT_IND='Y' and PARTY.party_key > - 1
		                            and CAST(FSK_RISK_ASSESSMENT.CREATE_DATE AS date) >= @V_START_DATE AND CAST(FSK_RISK_ASSESSMENT.CREATE_DATE AS date) <= @V_END_DATE
		                            group by  (case when PROPOSED_RISK_CLASS.lov_type_desc is null then 'UNKNOWN' else PROPOSED_RISK_CLASS.lov_type_desc end);
		                            END ;
                            GO


                            ----------------------------------------------------------------------------------------------------
                            ");
            migrationBuilder.Sql($@"
                           USE [ART_DB]
                            GO

                            /****** Object:  StoredProcedure [FCF71.FCFCORE].[ART_ST_AML_RISK_CLASS]    Script Date: 6/11/2023 3:38:41 PM ******/
                            SET ANSI_NULLS ON
                            GO

                            SET QUOTED_IDENTIFIER ON
                            GO



                              CREATE  PROCEDURE [ART_DB].[ART_ST_AML_RISK_CLASS]
                            (
                            @V_START_DATE date , @V_END_DATE date
                            ) AS 
                            BEGIN
                            SET NOCOUNT ON;

                             select 
                             (case when RISK_CLASS.lov_type_desc is null then 'UNKNOWN' else RISK_CLASS.lov_type_desc end) AS RISK_CLASSIFICATION, 
							 CAST(count(PARTY.party_key) AS DECIMAL(10, 0)) NUMBER_OF_CUSTOMERS
                             FROM
                                    FCF71.FCFKC.FSK_RISK_ASSESSMENT FSK_RISK_ASSESSMENT 
                                LEFT JOIN 
                                    FCF71.FCFKC.FSK_LOV RISK_CLASS on FSK_RISK_ASSESSMENT.RISK_CLASSIFICATION = RISK_CLASS.LOV_TYPE_CODE and RISK_CLASS.LOV_TYPE_NAME ='RT_RISK_CLASSIFICATION' and RISK_CLASS.LOV_LANGUAGE_DESC='en'
                                LEFT JOIN
                                    FCF71.FCFCORE.FSC_PARTY_DIM PARTY ON FSK_RISK_ASSESSMENT.PARTY_NUMBER = PARTY.PARTY_NUMBER
                                    LEFT JOIN 
                                FCF71.FCFKC.FSK_LOV RISK_STATUS on FSK_RISK_ASSESSMENT.RISK_ASSESSMENT_STATUS_CODE = RISK_STATUS.LOV_TYPE_CODE and RISK_STATUS.LOV_TYPE_NAME ='RT_ASMT_STATUS' and RISK_STATUS.LOV_LANGUAGE_DESC='en'
									WHERE PARTY.CHANGE_CURRENT_IND='Y' and PARTY.party_key > - 1
		                            and CAST(FSK_RISK_ASSESSMENT.CREATE_DATE AS date) >= @V_START_DATE AND CAST(FSK_RISK_ASSESSMENT.CREATE_DATE AS date) <= @V_END_DATE
		                            group by  (case when RISK_CLASS.lov_type_desc is null then 'UNKNOWN' else RISK_CLASS.lov_type_desc end);
		                            END ;
                            GO
                            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                DROP VIEW [ART_DB].[ART_HOME_Number_Of_Accounts]
                                DROP VIEW [ART_DB].[ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS]
                                DROP VIEW [ART_DB].[ART_HOME_NUMBER_OF_PEP_CUSTOMERS] 
                                DROP VIEW [ART_DB].[ART_HOME_NUMBER_OF_CUSTOMERS]
                                DROP VIEW [ART_DB].[ART_HOME_ALERTS_PER_DATE]
                                DROP VIEW [ART_DB].[ART_HOME_ALERTS_PER_STATUS]
                                ");


            migrationBuilder.Sql($"DROP VIEW [ART_DB].[ART_AML_TRIAGE_VIEW]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[ART_AML_ALERT_DETAIL_VIEW]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[ART_AML_CUSTOMERS_DETAILS_VIEW]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[ART_AML_CASE_DETAILS_VIEW]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[ART_AML_HIGH_RISK_CUST_VIEW]");
            migrationBuilder.Sql($"DROP VIEW [ART_DB].[ART_AML_RISK_ASSESSMENT_VIEW]");


            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_ALERT_PER_OWNER]");
            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_AML_ALERTS_PER_STATUS]");

            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_CASES_PER_CATEGORY]");
            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_CASES_PER_PRIORITY]");
            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_CASES_PER_STATUS]");
            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_CASES_PER_SUBCAT]");

            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_CUST_PER_BRANCH]");
            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_CUST_PER_RISK]");
            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_CUST_PER_TYPE]");

            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_AML_PROP_RISK_CLASS]");
            migrationBuilder.Sql($"DROP PROCEDURE [ART_DB].[ART_ST_AML_RISK_CLASS]");
        }
    }
}
