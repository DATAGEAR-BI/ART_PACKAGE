using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class AlertSummaryReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
