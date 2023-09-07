using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations.Ecm
{
    public partial class EcmModuleQueries : Migration
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
                                          select Year_ Year,Month__ Month,Day_ Day,NUMBER_OF_CASES from
                                        (
                                        select
                                        YEAR(a.create_date) Year_,
                                        Month(a.create_date) Month_,
                                        FORMAT(a.create_date,'MMM') Month__,
                                        Day(a.create_date) Day_,
                                        CAST(count(a.case_rk)  AS DECIMAL(10, 0)) NUMBER_OF_CASES
                                        from
                                        dgecm.dgcmgmt.case_live A
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
                                        group by 
                                        YEAR(a.create_date),CASE_TYPE.Val_Desc
                                        order by YEAR(a.create_date) desc offset 0 rows) aaa;
                                        GO");
            //            //ART_SYSTEM_PERFORMANCE => View
            //            migrationBuilder.Sql($@"
            //                                        SET ANSI_NULLS ON
            //                                        GO

            //                                        SET QUOTED_IDENTIFIER ON
            //                                        GO

            //                                        CREATE OR ALTER VIEW [ART_DB].[ART_SYSTEM_PERFORMANCE] (""CASE_ID"", ""CASE_RK"", ""VALID_FROM_DATE"", ""CASE_TYPE"", ""CASE_STATUS"", ""CASE_DESC"", ""PRIORITY"", ""CREATE_USER_ID"", ""INVESTR_USER_ID"", ""CREATE_DATE"", ""UPDATE_USER_ID"", ""TRANSACTION_TYPE"", ""TRANSACTION_AMOUNT"", ""TRANSACTION_DIRECTION"", ""TRANSACTION_CURRENCY"", ""SWIFT_REFERENCE"", ""CLIENT_NAME"", ""IDENTITY_NUM"", ""LOCKED_BY"", ""ECM_LAST_STATUS_DATE"", ""HITS_COUNT"", ""DURATIONS_IN_SECONDS"", ""DURATIONS_IN_MINUTES"", ""DURATIONS_IN_HOURS"", ""DURATIONS_IN_DAYS"") AS 
            //                                        select 
            //                                        a.CASE_ID, 
            //                                        a.CASE_RK, 
            //                                        a.VALID_FROM_DATE, 
            //                                        T.Val_Desc Case_Type,
            //                                        c.VAL_DESC CASE_STATUS, 
            //                                        a.CASE_DESC, 
            //                                        H.VAL_DESC AS PRIORITY,
            //                                        a.CREATE_USER_ID, 
            //                                        a.primary_owner investr_user_id,
            //                                        a.CREATE_DATE, 
            //                                        a.UPDATE_USER_ID,
            //                                        (CASE WHEN a.transaction_type IS NULL OR a.transaction_type = 'null' THEN 'Unknown' else a.transaction_type end )transaction_type,
            //                                        a.transaction_amount,
            //                                          (CASE 
            //										when a.transaction_direction is null then 'Unknown' 
            //										when a.transaction_direction ='null' then 'Unknown' 
            //										when a.transaction_direction = 'I' THEN 'InComing'
            //										when a.transaction_direction = 'O' THEN 'OutGoing'
            //										else a.transaction_direction end )transaction_direction, 
            //                                        a.transaction_currency ,
            //                                        a.swift_reference,
            //                                        (case when a.Col1 is null then a.Cust_Full_Name else a.Col1 end)CLIENT_NAME,
            //                                        a.Col2 IDENTITY_NUM,
            //                                        g.LOCK_USER_ID AS Locked_By, 
            //                                        M.CREATE_DTTM ECM_LAST_STATUS_DATE,
            //                                        a.hits_count,
            //                                        DATEDIFF(SECOND, a.create_date, M.CREATE_DTTM ) AS DURATIONS_In_Seconds,
            //                                        DATEDIFF(MINUTE, a.create_date, M.CREATE_DTTM ) AS DURATIONS_In_minutes,
            //                                        DATEDIFF(HOUR, a.create_date, M.CREATE_DTTM ) as DURATIONS_In_hours,
            //                                        DATEDIFF(DAY, a.create_date, M.CREATE_DTTM ) AS DURATIONS_In_days
            //                                        from
            //                                        [DGECM].dgcmgmt.CASE_LIVE a  LEFT JOIN
            //                                        [DGECM].dgcmgmt.REF_TABLE_VAL c ON c.VAL_CD = a.CASE_STAT_CD AND c.REF_TABLE_NAME = 'RT_CASE_STATUS' LEFT JOIN
            //                                        [DGECM].dgcmgmt.ECM_ENTITY_LOCK g ON a.case_rk = g.ENTITY_RK AND g.ENTITY_NAME = 'CASE' LEFT JOIN
            //                                        [DGECM].dgcmgmt.REF_TABLE_VAL H ON H.VAL_CD = a.PRIORITY_CD AND H.REF_TABLE_NAME = 'X_RT_PRIORITY' 
            //                                        LEFT JOIN
            //                                        [DGECM].dgcmgmt.REF_TABLE_VAL T ON lower(T.VAL_CD) = lower(a.Case_Type_Cd) AND T.REF_TABLE_NAME = 'RT_CASE_TYPE' 
            //                                        LEFT JOIN
            //                                        (
            //                                        SELECT        
            //                                        m.BUSINESS_OBJECT_RK,max(m.create_date)CREATE_DTTM
            //                                        FROM
            //                                        [DGECM].dgcmgmt.ECM_EVENT M
            //                                        WHERE       
            //                                        m.BUSINESS_OBJECT_NAME = 'CASE' and m.event_desc not in ('Unlock Case','LOCK CASE')
            //                                        GROUP BY BUSINESS_OBJECT_RK) M 
            //                                        ON a.CASE_RK = M.BUSINESS_OBJECT_RK
            //                                        ;
            //                                        GO


            //");
            //            //ART_USER_PERFORMANCE => View
            //            migrationBuilder.Sql($@"
            //                                  /****** Object:  View [ART_DB].[ART_USER_PERFORMANCE]    Script Date: 04/06/2023 11:20:12 ******/
            //                                  SET ANSI_NULLS ON
            //                                  GO

            //                                  SET QUOTED_IDENTIFIER ON
            //                                  GO

            //                                  CREATE OR ALTER VIEW [ART_DB].[ART_USER_PERFORMANCE] (""CASE_RK"", ""CASE_ID"", ""VALID_FROM_DATE"", ""CASE_TYPE_CD"", ""CASE_STATUS"", ""PRIORITY"", ""CASE_DESC"", ""LOCKED_BY"", ""CREATE_USER_ID"", ""CREATE_DATE"", ""UPDATE_USER_ID"", ""ASSSIGNED_TIME"", ""ACTION_USER"", ""ACTION"", ""RELEASED_DATE"", ""DURATIONS_IN_SECONDS"", ""DURATIONS_IN_MINUTES"", ""DURATIONS_IN_HOURS"", ""DURATIONS_IN_DAYS"") AS 
            //                                                select 
            //                                                    a.CASE_RK,
            //                                                    a.CASE_ID,
            //                                                    a.VALID_FROM_DATE ,
            //                                                    T.VAL_DESC CASE_TYPE_CD,
            //                                                    c.VAL_DESC CASE_STATUS,
            //                                                    h.VAL_DESC PRIORITY,
            //                                                    a.CASE_DESC,
            //                                                    g.LOCK_USER_ID LOCKED_BY,
            //                                                    a.CREATE_USER_ID,
            //                                                    a.CREATE_DATE ,
            //                                                    a.UPDATE_USER_ID,
            //                                                    bb.CREATE_DTTM ASSSIGNED_TIME,
            //                                                    I.CREATE_USER_ID ACTION_USER ,
            //                                                    (case when I.EVENT_DESC='Case workflow terminated and restarted' then
            //                                                    SUBSTRING(I.EVENT_DESC, CHARINDEX(':', I.EVENT_DESC) + 6, LEN(I.EVENT_DESC)) else
            //                                                    SUBSTRING(I.EVENT_DESC, CHARINDEX(':', I.EVENT_DESC) + 2, LEN(I.EVENT_DESC)) end )ACTION,
            //                                                    I.CREATE_DATE AS RELEASED_DATE,
            //                                                    DATEDIFF(SECOND, bb.CREATE_DTTM, I.CREATE_DATE ) AS DURATIONS_In_Seconds,
            //                                                    DATEDIFF(MINUTE, bb.CREATE_DTTM, I.CREATE_DATE ) AS DURATIONS_In_minutes,
            //                                                    DATEDIFF(HOUR, bb.CREATE_DTTM, I.CREATE_DATE) as DURATIONS_In_hours,
            //                                                    DATEDIFF(DAY, bb.CREATE_DTTM, I.CREATE_DATE ) AS DURATIONS_In_days

            //                                            from 
            //                                            [DGECM].dgcmgmt.case_live a 
            //                                            LEFT JOIN [DGECM].dgcmgmt.REF_TABLE_VAL c
            //                                            ON c.VAL_CD = a.CASE_STAT_CD AND c.REF_TABLE_NAME = 'RT_CASE_STATUS'

            //                                            LEFT JOIN [DGECM].dgcmgmt.ECM_ENTITY_LOCK g
            //                                            ON a.case_rk = g.ENTITY_RK AND g.ENTITY_NAME ='CASE'

            //                                            LEFT JOIN [DGECM].dgcmgmt.REF_TABLE_VAL H
            //                                            ON H.VAL_CD = a.PRIORITY_CD AND H.REF_TABLE_NAME = 'X_RT_PRIORITY'
            //											LEFT JOIN
            //                                            [DGECM].dgcmgmt.REF_TABLE_VAL T ON lower(T.VAL_CD) = lower(a.Case_Type_Cd) AND T.REF_TABLE_NAME = 'RT_CASE_TYPE' 

            //                                            left JOIN [DGECM].dgcmgmt.ECM_EVENT I
            //                                            on I.BUSINESS_OBJECT_RK=a.CASE_RK   AND I.EVENT_TYPE_CD in('ACTVCWF','UPDCWF')

            //                                            left join (
            //                                            SELECT CREATE_USER_ID, CREATE_DATE CREATE_DTTM, BUSINESS_OBJECT_RK
            //                                            from (
            //                                            select ECM_EVENT.*, rank() OVER (PARTITION BY CREATE_USER_ID,BUSINESS_OBJECT_RK ORDER BY CREATE_DATE ASC) As RK
            //                                            from [DGECM].dgcmgmt.ECM_EVENT
            //                                            where BUSINESS_OBJECT_NAME='CASE'
            //                                            )a
            //                                            where RK=1
            //                                            ) bb
            //                                            ON a.CASE_RK=bb.BUSINESS_OBJECT_RK and I.CREATE_USER_ID=bb.CREATE_USER_ID
            //                                            WHERE 
            //											 a.case_stat_cd in ('SC','ST') 
            //                                            --and trunc(a.create_date) >='01-OCT-21'
            //                                            --and
            //                                            --CASE_TYPE_CD not in ('FATCA_INDV','FATCA_ENTITY')
            //                                            and I.CREATE_USER_ID is not null
            //                                            and (case when I.EVENT_DESC='Case workflow terminated and restarted' then
            //                                                    SUBSTRING(I.EVENT_DESC, CHARINDEX(':', I.EVENT_DESC) + 6, LEN(I.EVENT_DESC)) else
            //                                                    SUBSTRING(I.EVENT_DESC, CHARINDEX(':', I.EVENT_DESC) + 2, LEN(I.EVENT_DESC))  end) is not null
            //                                            and I.Event_Desc not in

            //                                            (
            //                                            'Case workflow started and status is Accept',
            //                                            'Case workflow started and status is REJECT',
            //                                            'Case Workflow Finished with status Accept',
            //                                            'Case Workflow Finished with status Reject',
            //                                            'Case workflow terminated and restarted',
            //                                            'Case Workflow Finished with status : SC',
            //                                            'Case Workflow Finished with status : ST',
            //                                            'Case workflow started and status is : MSC',
            //                                            'Case workflow started and status is : MST',
            //                                            'Case workflow started and status is : SM',
            //                                            'Case workflow updated with status : CSC',
            //                                            'Case workflow updated with status : CSR',
            //                                            'Case workflow updated with status : CST',
            //                                            'Case workflow updated with status : MSC',
            //                                            'Case workflow updated with status : MST',
            //                                            'Case workflow updated with status : SM'
            //                                            )
            //                                            ;
            //                                        GO



            //                                            ");
            //            //ART_ST_SYSTEM_PERF_PER_DIRECTION => Stored P
            //            migrationBuilder.Sql($@"SET ANSI_NULLS ON
            //                                        GO
            //                                        SET QUOTED_IDENTIFIER ON
            //                                        GO
            //                                          CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_SYSTEM_PERF_PER_DIRECTION] 
            //                                        (
            //                                        @V_START_DATE date , @V_END_DATE date
            //                                        ) AS 
            //                                        BEGIN
            //                                        SET NOCOUNT ON;
            //                                        select  
            //                                        (CASE UPPER(A.TRANSACTION_DIRECTION) 
            //                                        WHEN 'I' THEN 'InComing' 
            //                                        WHEN 'O' THEN 'OutGoing' 
            //                                        WHEN Null THEN 'Unknown' 
            //                                        WHEN 'NULL' THEN 'Unknown' 
            //                                        ELSE A.TRANSACTION_DIRECTION END) AS TRANSACTION_DIRECTION
            //                                        , CAST(count(a.case_rk) AS DECIMAL(10, 0)) TOTAL_NUMBER_OF_CASES 
            //                                        from [DGECM].dgcmgmt.case_live a 
            //                                        --LEFT JOIN
            //                                        --[DGECM].dgcmgmt.REF_TABLE_VAL b ON b.val_cd = a.CASE_STAT_CD AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
            //                                        WHERE 
            //                                        --a.case_stat_cd in ('SC','ST') and 
            //                                        a.case_type_cd = 'SWIFT'
            //                                        and
            //                                        CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE
            //                                        GROUP BY
            //                                        (CASE UPPER(A.TRANSACTION_DIRECTION) 
            //                                        WHEN 'I' THEN 'InComing' 
            //                                        WHEN 'O' THEN 'OutGoing' 
            //                                        WHEN Null THEN 'Unknown' 
            //                                        WHEN 'NULL' THEN 'Unknown' 
            //                                        ELSE A.TRANSACTION_DIRECTION END)
            //                                        ;
            //                                        END;
            //                                        GO
            //");
            //            //ART_ST_SYSTEM_PERF_PER_STATUS => Stored P
            //            migrationBuilder.Sql($@"SET ANSI_NULLS ON
            //                                        GO

            //                                        SET QUOTED_IDENTIFIER ON
            //                                        GO

            //                                          CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_SYSTEM_PERF_PER_STATUS] 
            //                                        (
            //                                        @V_START_DATE date , @V_END_DATE date
            //                                        ) AS 
            //                                        BEGIN
            //                                        SET NOCOUNT ON;

            //                                        select 
            //                                        b.val_desc case_status, CAST(count(a.case_rk) AS DECIMAL(10, 0)) TOTAL_NUMBER_OF_CASES
            //                                        from [DGECM].dgcmgmt.case_live a 
            //                                        LEFT JOIN
            //                                        [DGECM].dgcmgmt.REF_TABLE_VAL b ON b.val_cd = a.CASE_STAT_CD AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
            //                                        where 

            //                                        CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE
            //                                        GROUP BY
            //                                        b.val_desc
            //                                        ;
            //                                        END;

            //                                        GO
            //");
            //            //ART_ST_SYSTEM_PERF_PER_TYPE => Stored P
            //            migrationBuilder.Sql($@"SET ANSI_NULLS ON
            //                                        GO

            //                                        SET QUOTED_IDENTIFIER ON
            //                                        GO

            //                                          CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_SYSTEM_PERF_PER_TYPE] 
            //                                        (
            //                                        @V_START_DATE date , @V_END_DATE date
            //                                        ) AS 
            //                                        BEGIN
            //                                        SET NOCOUNT ON;

            //                                        select 
            //                                        b.VAL_DESC CASE_TYPE, CAST(count(a.case_rk)AS DECIMAL(10, 0)) TOTAL_NUMBER_OF_CASES
            //                                        from [DGECM].dgcmgmt.case_live a 
            //                                        LEFT JOIN
            //                                        [DGECM].dgcmgmt.REF_TABLE_VAL b ON lower(b.VAL_CD) = lower(a.CASE_TYPE_CD) AND b.REF_TABLE_NAME = 'RT_CASE_TYPE'
            //                                        where

            //CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE
            //                                        GROUP BY
            //                                        b.VAL_DESC
            //                                        ;
            //                                        END;

            //                                        GO
            //");
            //            //ART_ST_USER_PERFORMANCE_PER_ACTION => Stored P
            //            migrationBuilder.Sql($@"SET ANSI_NULLS ON
            //                                            GO

            //                                            SET QUOTED_IDENTIFIER ON
            //                                            GO

            //                                              CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_USER_PERFORMANCE_PER_ACTION] 
            //                                            (
            //                                            @V_START_DATE date , @V_END_DATE date
            //                                            ) AS 
            //                                            BEGIN
            //                                            SET NOCOUNT ON;

            //                                            select 
            //                                            (case when A.action is null then 'Manually Closed' else  A.action end) action,
            //                                            count(distinct a.case_rk)Total_Number_Of_Cases,
            //                                            sum(a.durations_in_seconds) durations_in_seconds,
            //                                            floor(sum(a.durations_in_seconds)/count(a.case_rk)) AVG_durations_in_seconds,
            //                                            sum(a.durations_in_minutes) durations_in_minutes,
            //                                            floor(sum(a.durations_in_minutes)/count(a.case_rk)) AVG_durations_in_minutes,
            //                                            sum(a.durations_in_hours) durations_in_hours,
            //                                            floor(sum(a.durations_in_hours)/count(a.case_rk)) AVG_durations_in_hours,
            //                                            sum(a.durations_in_days) durations_in_days,
            //                                            floor(sum(a.durations_in_days)/count(a.case_rk)) AVG_durations_in_days 
            //                                            from [ART_DB].art_user_performance a 
            //                                            WHERE

            //                                            CAST(a.CREATE_DATE AS date) >= @V_START_DATE AND CAST(a.CREATE_DATE AS date) <= @V_END_DATE
            //                                            group by  action
            //                                            ;
            //                                            END;

            //                                            GO

            //");
            //            //ART_ST_USER_PERFORMANCE_PER_ACTION_USER => Stored P
            //            migrationBuilder.Sql($@"
            //                                        SET ANSI_NULLS ON
            //                                        GO

            //                                        SET QUOTED_IDENTIFIER ON
            //                                        GO

            //                                          CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_USER_PERFORMANCE_PER_ACTION_USER] 
            //                                        (
            //                                        @V_START_DATE date , @V_END_DATE date
            //                                        ) AS 
            //                                        BEGIN
            //                                        SET NOCOUNT ON;

            //                                        select 
            //                                        a.action_user,
            //                                        count(distinct a.case_rk)Total_Number_Of_Cases,
            //                                        sum(a.durations_in_seconds) durations_in_seconds,
            //                                        floor(sum(a.durations_in_seconds)/count(a.case_rk)) AVG_durations_in_seconds,
            //                                        sum(a.durations_in_minutes) durations_in_minutes,
            //                                        floor(sum(a.durations_in_minutes)/count(a.case_rk)) AVG_durations_in_minutes,
            //                                        sum(a.durations_in_hours) durations_in_hours,
            //                                        floor(sum(a.durations_in_hours)/count(a.case_rk)) AVG_durations_in_hours,
            //                                        sum(a.durations_in_days) durations_in_days,
            //                                        floor(sum(a.durations_in_days)/count(a.case_rk)) AVG_durations_in_days 
            //                                        from [ART_DB].art_user_performance a 
            //                                        WHERE
            //                                        CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE

            //                                        group by  a.action_user
            //                                        ;
            //                                        END;

            //                                        GO
            //");
            //            //ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION => Stored P
            //            migrationBuilder.Sql($@"
            //                                        SET ANSI_NULLS ON
            //                                            GO
            //                                            SET QUOTED_IDENTIFIER ON
            //                                            GO
            //                                            CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION] 
            //                                            (
            //                                            @V_START_DATE date , @V_END_DATE date
            //                                            ) AS 
            //                                            BEGIN
            //                                            SET NOCOUNT ON;
            //                                            select 
            //                                            a.action_user,
            //                                            (case when A.action is null then 'Manually Closed' else  A.action end) action,
            //                                            count(distinct a.case_rk)Total_Number_Of_Cases,
            //                                            sum(a.durations_in_seconds) durations_in_seconds,
            //                                            floor(sum(a.durations_in_seconds)/count(a.case_rk)) AVG_durations_in_seconds,
            //                                            sum(a.durations_in_minutes) durations_in_minutes,
            //                                            floor(sum(a.durations_in_minutes)/count(a.case_rk)) AVG_durations_in_minutes,
            //                                            sum(a.durations_in_hours) durations_in_hours,
            //                                            floor(sum(a.durations_in_hours)/count(a.case_rk)) AVG_durations_in_hours,
            //                                            sum(a.durations_in_days) durations_in_days,
            //                                            floor(sum(a.durations_in_days)/count(a.case_rk)) AVG_durations_in_days 
            //                                            from [ART_DB].art_user_performance a 
            //                                            WHERE
            //                                            CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE
            //                                            group by  a.action_user,
            //                                            (case when A.action is null then 'Manually Closed' else  A.action end)
            //                                            ;
            //                                            END;
            //                                            GO
            //");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //remove ECM Views
            migrationBuilder.Sql($@"
                                        DROP VIEW [ART_DB].[ART_HOME_CASES_DATE]
                                        DROP VIEW [ART_DB].[ART_HOME_CASES_STATUS]
                                        DROP VIEW [ART_DB].[ART_HOME_CASES_TYPES]
                                        ");
            migrationBuilder.Sql($@"DROP VIEW [ART_DB].[ART_SYSTEM_PERFORMANCE]");
            migrationBuilder.Sql($@"DROP VIEW [ART_DB].[ART_USER_PERFORMANCE]");
            migrationBuilder.Sql($@"DROP PROCEDURE [ART_DB].[ART_ST_SYSTEM_PERF_PER_DIRECTION]");
            migrationBuilder.Sql($@"DROP PROCEDURE [ART_DB].[ART_ST_SYSTEM_PERF_PER_STATUS]");
            migrationBuilder.Sql($@"DROP PROCEDURE [ART_DB].[ART_ST_SYSTEM_PERF_PER_TYPE]");
            migrationBuilder.Sql($@"DROP PROCEDURE [ART_DB].[ART_ST_USER_PERFORMANCE_PER_ACTION]");
            migrationBuilder.Sql($@"DROP PROCEDURE [ART_DB].[ART_ST_USER_PERFORMANCE_PER_ACTION_USER]");
            migrationBuilder.Sql($@"DROP PROCEDURE [ART_DB].[ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION]");


        }
    }
}
