using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class SanctionHomeViews : Migration
    {
        private readonly bool IsAppliable;
        public SanctionHomeViews()
        {
            var m = MigrationsModules.GetModules();
            IsAppliable = m.Contains("ECM");
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (!IsAppliable)
                return;
            migrationBuilder.Sql($@"
                    --------------------------------------------------------
                    --  DDL for View ART_HOME_CASES_DATE
                    --------------------------------------------------------

                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_HOME_CASES_DATE"" (""YEAR"", ""MONTH"", ""DAY"", ""NUMBER_OF_CASES"") AS 
                      select Year_ Year,Month__ Month,Day_ Day,Number_Of_Cases from
                    (
                    select
                    EXTRACT(YEAR FROM a.create_date) Year_,
                    EXTRACT(Month FROM a.create_date) Month_,
                    to_Char(a.create_date,'Month') Month__,
                    EXTRACT(Day FROM a.create_date) Day_,
                    count(a.case_rk) Number_Of_Cases
                    from
                    dgcmgmt.case_live@DGCMGMTLINK A 

                    --where
                    --A.CASE_STAT_CD IN ('MSC','SMT','ST','HIT','SC','NOHIT','SP','POSTPOND','SO','SN')
                    group by 
                    EXTRACT(YEAR FROM a.create_date),
                    EXTRACT(Month FROM a.create_date) ,
                    to_Char(a.create_date,'Month'),
                    EXTRACT(Day FROM a.create_date)
                    order by  EXTRACT(YEAR FROM a.create_date) desc,EXTRACT(Month FROM a.create_date)  desc,EXTRACT(Day FROM a.create_date) desc
                    )
                    ;");
            migrationBuilder.Sql($@"
                    --------------------------------------------------------
                    --  DDL for View ART_HOME_CASES_STATUS
                    --------------------------------------------------------

                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_HOME_CASES_STATUS"" (""YEAR"", ""CASE_STATUS"", ""NUMBER_OF_CASES"") AS 
                    select 
                        EXTRACT(YEAR FROM a.create_date) Year,
                        (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end) case_status,count(a.case_rk)Total_Number_of_Cases
                        from dgcmgmt.case_live@DGCMGMTLINK a 
                        LEFT JOIN
                        dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK b ON b.val_cd = a.CASE_STAT_CD AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
                        --where a.Case_Type_Cd in ('WEB','BULK','DELTA','WHITELIST','ACH','SWIFT')
                        GROUP BY
                        EXTRACT(YEAR FROM a.create_date),
                        (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end)
                        order by  EXTRACT(YEAR FROM a.create_date) desc
                        ;
                    ");
            migrationBuilder.Sql($@"

                   
           CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_HOME_CASES_TYPES"" (""YEAR"", ""CASE_TYPE"", ""NUMBER_OF_CASES"") AS 
                    select 
                        EXTRACT(YEAR FROM a.create_date) Year,
                        (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end) CASE_TYPE,count(a.case_rk)Total_Number_of_Cases
                        from dgcmgmt.case_live@DGCMGMTLINK a 
                        LEFT JOIN
                        dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK b ON lower(b.VAL_CD) = lower(a.CASE_TYPE_CD) AND b.REF_TABLE_NAME = 'RT_CASE_TYPE'
                        GROUP BY
                        EXTRACT(YEAR FROM a.create_date),
                        (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end)
                        order by  EXTRACT(YEAR FROM a.create_date)desc                



");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                                DROP VIEW ""ART"".""ART_HOME_CASES_DATE"";");
            migrationBuilder.Sql($@"
                                DROP VIEW ""ART"".""ART_HOME_CASES_TYPES"";");
            migrationBuilder.Sql($@"
                                DROP VIEW ""ART"".""ART_HOME_CASES_STATUS"";");
        }
    }
}
