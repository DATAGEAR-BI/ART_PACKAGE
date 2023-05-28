using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class AMLHomeViews : Migration
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

                create view [ART_DB].[ART_HOME_ALERTS_PER_STATUS] as
                select  (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end) ALERT_STATUS,
                count(FSK_ALERT.alert_id) Alerts_Count
                FROM fcf71.fcfkc.FSK_ALERT FSK_ALERT 
                LEFT JOIN 
                fcf71.fcfkc.FSK_LOV ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                group by (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end);

                GO


                -------------------------------------------------------------------------------


                USE [ART_DB]
                GO
                

                /****** Object:  View [ART_DB].[ART_HOME_ALERTS_PER_DATE]    Script Date: 5/22/2023 10:22:37 AM ******/
                SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                create view [ART_DB].[ART_HOME_ALERTS_PER_DATE] as
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

                create view [ART_DB].[ART_HOME_NUMBER_OF_CUSTOMERS] AS
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

                create view [ART_DB].[ART_HOME_NUMBER_OF_PEP_CUSTOMERS] AS
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

                create view [ART_DB].[ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS] AS
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

                create view [ART_DB].[ART_HOME_Number_Of_Accounts] AS
                select  count(*) Number_Of_Accounts
                FROM fcf71.fcfcore.FSC_ACCOUNT_DIM a
                where a.change_current_ind = 'Y';
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
        }
    }
}
