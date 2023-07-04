using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class AMLHomeViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"

--------------------------------------------------------
--  DDL for View ART_HOME_ALERTS_PER_DATE
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_HOME_ALERTS_PER_DATE"" (""YEAR"", ""MONTH"", ""DAY"", ""NUMBER_OF_ALERTS"") AS 
  select Year_ Year,Month__ Month,Day_ Day,Number_Of_ALerts from
                                    (select 
                                    EXTRACT(YEAR FROM a.create_date) Year_,
                                    EXTRACT(Month FROM a.create_date) Month_,
                                    to_Char(a.create_date,'Month') Month__,
                                    EXTRACT(Day FROM a.create_date) Day_,
                                    count(a.alert_id) Number_Of_ALerts
                                    from  fcfkc.FSK_ALERT@FCFKCLINK a
                                    group by 
                                    EXTRACT(YEAR FROM a.create_date),
                                    EXTRACT(Month FROM a.create_date) ,
                                    to_Char(a.create_date,'Month'),
                                    EXTRACT(Day FROM a.create_date)
                                    order by
                                    EXTRACT(YEAR FROM a.create_date) desc,EXTRACT(Month FROM a.create_date)  desc,EXTRACT(Day FROM a.create_date) desc
                                    )
;");
            migrationBuilder.Sql($@"
--------------------------------------------------------
--  DDL for View ART_HOME_ALERTS_PER_STATUS
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_HOME_ALERTS_PER_STATUS"" (""ALERT_STATUS"", ""ALERTS_COUNT"") AS 
  select  (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end) ALERT_STATUS,
                                    count(FSK_ALERT.alert_id) Alerts_Count
                                    FROM fcfkc.FSK_ALERT@FCFKCLINK FSK_ALERT 
                                    LEFT JOIN 
                                    fcfkc.FSK_LOV@FCFKCLINK ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                                    and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                                    group by (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end)
;");
            migrationBuilder.Sql($@"
--------------------------------------------------------
--  DDL for View ART_HOME_NUMBER_OF_ACCOUNTS
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_HOME_NUMBER_OF_ACCOUNTS"" (""NUMBER_OF_ACCOUNTS"") AS 
  select  count(*) Number_Of_Accounts
                                    FROM fcfcore.FSC_ACCOUNT_DIM@FCFCORELINK a
                                    where a.change_current_ind = 'Y'
;");
            migrationBuilder.Sql($@"
--------------------------------------------------------
--  DDL for View ART_HOME_NUMBER_OF_CUSTOMERS
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_HOME_NUMBER_OF_CUSTOMERS"" (""NUMBER_OF_CUSTOMERS"") AS 
  select  count(*) Number_Of_Customers
                                    FROM fcfcore.FSC_PARTY_DIM@FCFCORELINK a
                                    where a.change_current_ind = 'Y'
;");
            migrationBuilder.Sql($@"
--------------------------------------------------------
--  DDL for View ART_NUMBER_OF_HIGH_RISK_CUSTS
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_NUMBER_OF_HIGH_RISK_CUSTS"" (""NUMBER_OF_HIGH_RISK_CUSTOMERS"") AS 
  select  count(*) Number_Of_High_Risk_Customers
                                    FROM fcfcore.FSC_PARTY_DIM@FCFCORELINK a
                                    where a.change_current_ind = 'Y'
                                    and a.risk_classification = '3'
;");
            migrationBuilder.Sql($@"
--------------------------------------------------------
--  DDL for View ART_NUMBER_OF_PEP_CUSTOMERS
--------------------------------------------------------

   CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_NUMBER_OF_PEP_CUSTOMERS"" (""NUMBER_OF_PEP_CUSTOMERS"") AS 
  (select  count(*) Number_Of_PEP_Customers
                                    FROM fcfcore.FSC_PARTY_DIM@FCFCORELINK a
                                    where a.change_current_ind = 'Y'
                                    and a.politically_exposed_person_ind = 'Y');

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql($@"DROP VIEW {"ART_NUMBER_OF_PEP_CUSTOMERS".ToUpper()};");
            migrationBuilder.Sql($@"DROP VIEW {"ART_NUMBER_OF_High_Risk_CUSTS".ToUpper()};");
            migrationBuilder.Sql($@"DROP VIEW {"ART_HOME_NUMBER_OF_CUSTOMERS".ToUpper()};");
            migrationBuilder.Sql($@"DROP VIEW {"ART_HOME_Number_Of_Accounts".ToUpper()};");
            migrationBuilder.Sql($@"DROP VIEW {"ART_HOME_ALERTS_PER_STATUS".ToUpper()};");
            migrationBuilder.Sql($@"DROP VIEW {"ART_HOME_ALERTS_PER_DATE".ToUpper()};");
        }
    }
}
