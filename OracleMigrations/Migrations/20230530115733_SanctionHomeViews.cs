﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class SanctionHomeViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    dgcmgmt.case_live A 

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

                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_HOME_CASES_STATUS"" (""CASE_STATUS"", ""NUMBER_OF_CASES"") AS 
                     select 
                    (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end) case_status,count(a.case_rk)Total_Number_of_Cases
                    from dgcmgmt.case_live a 
                    LEFT JOIN
                    dgcmgmt.REF_TABLE_VAL b ON b.val_cd = a.CASE_STAT_CD AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
                    GROUP BY
                    (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end)
                    ;");
            migrationBuilder.Sql($@"

                    --------------------------------------------------------
                    --  DDL for View ART_HOME_CASES_TYPES
                    --------------------------------------------------------

                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_HOME_CASES_TYPES"" (""CASE_TYPE"", ""NUMBER_OF_CASES"") AS 
                      select 
                    (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end) CASE_TYPE,count(a.case_rk)Total_Number_of_Cases
                    from dgcmgmt.case_live a 
                    LEFT JOIN
                    dgcmgmt.REF_TABLE_VAL b ON lower(b.VAL_CD) = lower(a.CASE_TYPE_CD) AND b.REF_TABLE_NAME = 'RT_CASE_TYPE'
                    GROUP BY
                    (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end)
                    ;



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