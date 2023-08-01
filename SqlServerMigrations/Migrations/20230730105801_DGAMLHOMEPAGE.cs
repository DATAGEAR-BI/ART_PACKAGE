using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class DGAMLHOMEPAGE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Views
            //ART_HOME_DGAML_ALERTS_PER_DATE
            migrationBuilder.Sql($@"
            CREATE OR ALTER   VIEW [ART_DB].[ART_HOME_DGAML_ALERTS_PER_DATE] as
                select Year_ Year,Month__ Month,Day_ Day,Number_Of_ALerts from
                (select 
                YEAR(a.create_date) Year_,
                Month(a.create_date) Month_,
                FORMAT(a.create_date,'MMM') Month__,
                Day(a.create_date) Day_,
                count(a.Alarm_Id) Number_Of_ALerts
                from  DGAML.ac.ac_alarm a
				where a.Prod_Type = 'AML'
                group by 
                YEAR(a.create_date),
                Month(a.create_date),
                FORMAT(a.create_date,'MMM') ,
                Day(a.create_date)
                order by YEAR(a.create_date) desc,
                Month(a.create_date) desc,
                Day(a.create_date)  desc offset 0 rows) aaa;");
            //ART_HOME_DGAML_ALERTS_PER_STATUS
            migrationBuilder.Sql($@"
            CREATE OR ALTER  VIEW [ART_DB].[ART_HOME_DGAML_ALERTS_PER_STATUS] as
                select Year_ Year,ALERT_STATUS,ALERTS_COUNT from
                (
                select  
				YEAR(aa.create_date) Year_,
				(case when alarm_status.LKP_Val_Desc is null then 'Unknown' else alarm_status.LKP_Val_Desc end) ALERT_STATUS,
                count(aa.Alarm_Id) ALERTS_COUNT
                FROM DGAML.ac.ac_alarm aa 
                left join DGAML.AC.AC_LKP_Table alarm_status on lower(aa.Alarm_Status_Cd)=lower(alarm_status.LKP_Val_Cd) and alarm_status.LKP_Lang_Desc='en' 
                and alarm_status.LKP_Name = 'ALARM_STATUS'
				where aa.Prod_Type = 'AML'
                group by 
				YEAR(aa.create_date),
				(case when alarm_status.LKP_Val_Desc is null then 'Unknown' else alarm_status.LKP_Val_Desc end)
				order by YEAR(aa.create_date) desc offset 0 rows) aaa;");
            //ART_HOME_DGAML_NUMBER_OF_ACCOUNTS
            migrationBuilder.Sql($@"
            CREATE OR ALTER  VIEW [ART_DB].[ART_HOME_DGAML_NUMBER_OF_ACCOUNTS] AS               
              select  count(*) NUMBER_OF_ACCOUNTS
                FROM [DGAML].[DGAMLCORE].[Account] a
                where a.Chg_Current_Ind = 'Y';");
            //ART_HOME_DGAML_NUMBER_OF_CUSTOMERS
            migrationBuilder.Sql($@"
            CREATE OR ALTER   VIEW [ART_DB].[ART_HOME_DGAML_NUMBER_OF_CUSTOMERS] AS               
                 select  count(*) NUMBER_OF_CUSTOMERS
                FROM DGAML.DGAMLCORE.Customer c 
                where c.Chg_Current_Ind = 'Y'
				and c.Cust_Key > - 1;");
            //ART_HOME_DGAML_NUMBER_OF_HIGH_RISK_CUSTOMERS
            migrationBuilder.Sql($@"
            CREATE OR ALTER   VIEW [ART_DB].[ART_HOME_DGAML_NUMBER_OF_HIGH_RISK_CUSTOMERS] AS               
                 select  count(*) NUMBER_OF_HIGH_RISK_CUSTOMERS
                FROM DGAML.DGAMLCORE.Customer c 
                where c.Chg_Current_Ind = 'Y'
				and c.Cust_Key > - 1
				and c.Risk_Class = '3';");
            //ART_HOME_DGAML_NUMBER_OF_PEP_CUSTOMERS
            migrationBuilder.Sql($@"
             CREATE OR ALTER  VIEW [ART_DB].[ART_HOME_DGAML_NUMBER_OF_PEP_CUSTOMERS] AS               
                select  count(*) NUMBER_OF_PEP_CUSTOMERS
                FROM DGAML.DGAMLCORE.Customer c 
                where c.Chg_Current_Ind = 'Y'
				and c.Cust_Key > - 1
				and c.Political_Exp_Prsn_Ind = 'Y';");
            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
