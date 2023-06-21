using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class SanctionHomeViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //create ECM Views
            migrationBuilder.Sql($@"
                                        
                                        USE [ART_DB]
                                        GO
                                        
                                        /****** Object:  View [ART_DB].[ART_HOME_CASES_DATE]    Script Date: 5/21/2023 4:03:07 PM ******/
                                        SET ANSI_NULLS ON
                                        GO
                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                         CREATE OR ALTER VIEW [ART_DB].[ART_HOME_CASES_DATE] (""YEAR"", ""MONTH"", ""DAY"", ""NUMBER_OF_CASES"") AS 
                                          select Year_ Year,Month__ Month,Day_ Day,Number_Of_Cases from
                                        (
                                        select
                                        YEAR(a.create_date) Year_,
                                        Month(a.create_date) Month_,
                                        FORMAT(a.create_date,'MMM') Month__,
                                        Day(a.create_date) Day_,
                                        count(a.case_rk) Number_Of_Cases
                                        from
                                        dgecm.dgcmgmt.case_live A
                                        where Case_Type_Cd in ('WEB','BULK','DELTA','WHITELIST','ACH','SWIFT')
                                        group by 
                                        YEAR(a.create_date),
                                        Month(a.create_date),
                                        FORMAT(a.create_date,'MMM') ,
                                        Day(a.create_date)
                                        order by YEAR(a.create_date) desc,
                                        Month(a.create_date) desc,
                                        Day(a.create_date)  desc offset 0 rows) aaa
                                        ;
                                        GO
                                        -------------------------------------------------------------------------------------------------



                                        USE [ART_DB]
                                        GO

                                        /****** Object:  View [ART_DB].[ART_HOME_CASES_STATUS]    Script Date: 5/21/2023 4:03:37 PM ******/
                                        SET ANSI_NULLS ON
                                        GO

                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                        CREATE OR ALTER VIEW [ART_DB].[ART_HOME_CASES_STATUS] (""Year"",""CASE_STATUS"", ""NUMBER_OF_CASES"") AS
                                    select Year_ Year,CASE_status,NUMBER_OF_CASES from
                                    (
                                    select
                                    YEAR(a.create_date) Year_,
                                    b.Val_Desc CASE_status,
                                    count(a.case_rk) NUMBER_OF_CASES
                                    from
                                    dgecm.dgcmgmt.case_live A  LEFT JOIN 

									dgecm.DGCMGMT.REF_TABLE_VAL b ON lower(b.VAL_CD) = lower(a.CASE_STAT_CD) AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
									where Case_Type_Cd in ('WEB','BULK','DELTA','WHITELIST','ACH','SWIFT')
                                    group by 
                                    YEAR(a.create_date),b.Val_Desc
                                    order by YEAR(a.create_date) desc offset 0 rows) aaa;
                                    GO
                                        ---------------------------------------------------------------------------------------------------


                                        USE [ART_DB]
                                        GO

                                        /****** Object:  View [ART_DB].[ART_HOME_CASES_TYPES]    Script Date: 5/21/2023 4:04:26 PM ******/
                                        SET ANSI_NULLS ON
                                        GO

                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                           CREATE OR ALTER VIEW [ART_DB].[ART_HOME_CASES_TYPES] (""Year"",""CASE_TYPE"", ""NUMBER_OF_CASES"") AS 
                                         select Year_ Year,CASE_TYPE,NUMBER_OF_CASES from
                                        (
                                        select
                                        YEAR(a.create_date) Year_,
                                        CASE_TYPE.Val_Desc CASE_TYPE,
                                        count(a.case_rk) NUMBER_OF_CASES
                                        from
                                        dgecm.dgcmgmt.case_live A  LEFT JOIN dgecm.dgcmgmt.REF_TABLE_VAL CASE_TYPE 
                                        ON CASE_TYPE.VAL_CD = a.CASE_TYPE_CD
                                        AND CASE_TYPE.REF_TABLE_NAME='RT_CASE_TYPE'
										where Case_Type_Cd in ('WEB','BULK','DELTA','WHITELIST','ACH','SWIFT')
                                        group by 
                                        YEAR(a.create_date),CASE_TYPE.Val_Desc
                                        order by YEAR(a.create_date) desc offset 0 rows) aaa;
                                        GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //remove ECM Views
            migrationBuilder.Sql($@"
                                        DROP VIEW [ART_DB].[ART_HOME_CASES_DATE]
                                        DROP VIEW [ART_DB].[ART_HOME_CASES_STATUS]
                                        DROP VIEW [ART_DB].[ART_HOME_CASES_TYPES]
                                        ");
        }
    }
}
