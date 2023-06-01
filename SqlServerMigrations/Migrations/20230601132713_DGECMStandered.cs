using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class DGECMStandered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //ART_SYSTEM_PERFORMANCE => View
            migrationBuilder.Sql($@"
                                        SET ANSI_NULLS ON
                                        GO

                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                        CREATE VIEW [ART_DB].[ART_SYSTEM_PERFORMANCE] (""CASE_ID"", ""CASE_RK"", ""VALID_FROM_DATE"", ""CASE_TYPE"", ""CASE_STATUS"", ""CASE_DESC"", ""PRIORITY"", ""CREATE_USER_ID"", ""INVESTR_USER_ID"", ""CREATE_DATE"", ""UPDATE_USER_ID"", ""TRANSACTION_TYPE"", ""TRANSACTION_AMOUNT"", ""TRANSACTION_DIRECTION"", ""TRANSACTION_CURRENCY"", ""SWIFT_REFERENCE"", ""CLIENT_NAME"", ""IDENTITY_NUM"", ""LOCKED_BY"", ""ECM_LAST_STATUS_DATE"", ""HITS_COUNT"", ""DURATIONS_IN_SECONDS"", ""DURATIONS_IN_MINUTES"", ""DURATIONS_IN_HOURS"", ""DURATIONS_IN_DAYS"") AS 
                                        select 
                                        a.CASE_ID, 
                                        a.CASE_RK, 
                                        a.VALID_FROM_DATE, 
                                        T.Val_Desc Case_Type,
                                        c.VAL_DESC CASE_STATUS, 
                                        a.CASE_DESC, 
                                        H.VAL_DESC AS PRIORITY,
                                        a.CREATE_USER_ID, 
                                        a.primary_owner investr_user_id,
                                        a.CREATE_DATE, 
                                        a.UPDATE_USER_ID,
                                        (CASE WHEN a.transaction_type IS NULL OR a.transaction_type = 'null' THEN 'Unknown' else a.transaction_type end )transaction_type,
                                        a.transaction_amount,
                                        CASE a.transaction_direction WHEN 'I' THEN 'Input' WHEN 'O' THEN 'Output' WHEN NULL THEN 'Unknown' WHEN 'null' THEN 'Unknown' ELSE a.transaction_direction END AS transaction_direction, 
                                        a.transaction_currency ,
                                        a.swift_reference,
                                        (case when a.Col1 is null then a.Cust_Full_Name else a.Col1 end)CLIENT_NAME,
                                        a.Col2 IDENTITY_NUM,
                                        g.LOCK_USER_ID AS Locked_By, 
                                        M.CREATE_DTTM ECM_LAST_STATUS_DATE,
                                        a.hits_count,
                                        DATEDIFF(SECOND, a.create_date, M.CREATE_DTTM ) AS DURATIONS_In_Seconds,
                                        DATEDIFF(MINUTE, a.create_date, M.CREATE_DTTM ) AS DURATIONS_In_minutes,
                                        DATEDIFF(HOUR, a.create_date, M.CREATE_DTTM ) as DURATIONS_In_hours,
                                        DATEDIFF(DAY, a.create_date, M.CREATE_DTTM ) AS DURATIONS_In_days
                                        from
                                        [DGECM].dgcmgmt.CASE_LIVE a  LEFT JOIN
                                        [DGECM].dgcmgmt.REF_TABLE_VAL c ON c.VAL_CD = a.CASE_STAT_CD AND c.REF_TABLE_NAME = 'RT_CASE_STATUS' LEFT JOIN
                                        [DGECM].dgcmgmt.ECM_ENTITY_LOCK g ON a.case_rk = g.ENTITY_RK AND g.ENTITY_NAME = 'CASE' LEFT JOIN
                                        [DGECM].dgcmgmt.REF_TABLE_VAL H ON H.VAL_CD = a.PRIORITY_CD AND H.REF_TABLE_NAME = 'X_RT_PRIORITY' 
                                        LEFT JOIN
                                        [DGECM].dgcmgmt.REF_TABLE_VAL T ON lower(T.VAL_CD) = lower(a.Case_Type_Cd) AND T.REF_TABLE_NAME = 'RT_CASE_TYPE' 
                                        LEFT JOIN
                                        (
                                        SELECT        
                                        m.BUSINESS_OBJECT_RK,max(m.create_date)CREATE_DTTM
                                        FROM
                                        [DGECM].dgcmgmt.ECM_EVENT M
                                        WHERE       
                                        m.BUSINESS_OBJECT_NAME = 'CASE' and m.event_desc not in ('Unlock Case','LOCK CASE')
                                        GROUP BY BUSINESS_OBJECT_RK) M 
                                        ON a.CASE_RK = M.BUSINESS_OBJECT_RK
                                        ;
                                        GO


");
            //ART_USER_PERFORMANCE => View
            migrationBuilder.Sql($@"SET ANSI_NULLS ON
                                            GO

                                            SET QUOTED_IDENTIFIER ON
                                            GO

                                                CREATE VIEW [ART_DB].[ART_USER_PERFORMANCE] (""CASE_RK"", ""CASE_ID"", ""VALID_FROM_DATE"", ""CASE_TYPE_CD"", ""CASE_STATUS"", ""PRIORITY"", ""CASE_DESC"", ""LOCKED_BY"", ""CREATE_USER_ID"", ""CREATE_DATE"", ""UPDATE_USER_ID"", ""ASSSIGNED_TIME"", ""ACTION_USER"", ""ACTION"", ""RELEASED_DATE"", ""DURATIONS_IN_SECONDS"", ""DURATIONS_IN_MINUTES"", ""DURATIONS_IN_HOURS"", ""DURATIONS_IN_DAYS"") AS 
                                                select 
                                                    a.CASE_RK,
                                                    a.CASE_ID,
                                                    a.VALID_FROM_DATE ,
                                                    a.CASE_TYPE_CD,
                                                    c.VAL_DESC CASE_STATUS,
                                                    h.VAL_DESC PRIORITY,
                                                    a.CASE_DESC,
                                                    g.LOCK_USER_ID LOCKED_BY,
                                                    a.CREATE_USER_ID,
                                                    a.CREATE_DATE ,
                                                    a.UPDATE_USER_ID,
                                                    bb.CREATE_DTTM ASSSIGNED_TIME,
                                                    I.CREATE_USER_ID ACTION_USER ,
                                                    (case when I.EVENT_DESC='Case workflow terminated and restarted' then
                                                    SUBSTRING(I.EVENT_DESC, CHARINDEX(':', I.EVENT_DESC) + 6, LEN(I.EVENT_DESC)) else
                                                    SUBSTRING(I.EVENT_DESC, CHARINDEX(':', I.EVENT_DESC) + 2, LEN(I.EVENT_DESC)) end )ACTION,
                                                    I.CREATE_DATE AS RELEASED_DATE,
                                                    DATEDIFF(SECOND, bb.CREATE_DTTM, I.CREATE_DATE ) AS DURATIONS_In_Seconds,
                                                    DATEDIFF(MINUTE, bb.CREATE_DTTM, I.CREATE_DATE ) AS DURATIONS_In_minutes,
                                                    DATEDIFF(HOUR, bb.CREATE_DTTM, I.CREATE_DATE) as DURATIONS_In_hours,
                                                    DATEDIFF(DAY, bb.CREATE_DTTM, I.CREATE_DATE ) AS DURATIONS_In_days
        
                                            from 
                                            [DGECM].dgcmgmt.case_live a 
                                            LEFT JOIN [DGECM].dgcmgmt.REF_TABLE_VAL c
                                            ON c.VAL_CD = a.CASE_STAT_CD AND c.REF_TABLE_NAME = 'RT_CASE_STATUS'

                                            LEFT JOIN [DGECM].dgcmgmt.ECM_ENTITY_LOCK g
                                            ON a.case_rk = g.ENTITY_RK AND g.ENTITY_NAME ='CASE'

                                            LEFT JOIN [DGECM].dgcmgmt.REF_TABLE_VAL H
                                            ON H.VAL_CD = a.PRIORITY_CD AND H.REF_TABLE_NAME = 'X_RT_PRIORITY'

                                            left JOIN [DGECM].dgcmgmt.ECM_EVENT I
                                            on I.BUSINESS_OBJECT_RK=a.CASE_RK   AND I.EVENT_TYPE_CD in('ACTVCWF','UPDCWF')

                                            left join (
                                            SELECT CREATE_USER_ID, CREATE_DATE CREATE_DTTM, BUSINESS_OBJECT_RK
                                            from (
                                            select ECM_EVENT.*, rank() OVER (PARTITION BY CREATE_USER_ID,BUSINESS_OBJECT_RK ORDER BY CREATE_DATE ASC) As RK
                                            from [DGECM].dgcmgmt.ECM_EVENT
                                            where BUSINESS_OBJECT_NAME='CASE'
                                            )a
                                            where RK=1
                                            ) bb
                                            ON a.CASE_RK=bb.BUSINESS_OBJECT_RK and I.CREATE_USER_ID=bb.CREATE_USER_ID
                                            WHERE 
                                            a.case_stat_cd in ('SC','ST') 
                                            --and trunc(a.create_date) >='01-OCT-21'
                                            --and
                                            --CASE_TYPE_CD not in ('FATCA_INDV','FATCA_ENTITY')
                                            and I.CREATE_USER_ID is not null
                                            and (case when I.EVENT_DESC='Case workflow terminated and restarted' then
                                                    SUBSTRING(I.EVENT_DESC, CHARINDEX(':', I.EVENT_DESC) + 6, LEN(I.EVENT_DESC)) else
                                                    SUBSTRING(I.EVENT_DESC, CHARINDEX(':', I.EVENT_DESC) + 2, LEN(I.EVENT_DESC))  end) is not null
                                            ;
                                            GO
                                            ");
            //ART_ST_SYSTEM_PERF_PER_DIRECTION => Stored P
            migrationBuilder.Sql($@"SET ANSI_NULLS ON
                                        GO
                                        SET QUOTED_IDENTIFIER ON
                                        GO
                                          CREATE PROCEDURE [ART_DB].[ART_ST_SYSTEM_PERF_PER_DIRECTION] 
                                        (
                                        @V_START_DATE date , @V_END_DATE date
                                        ) AS 
                                        BEGIN
                                        SET NOCOUNT ON;
                                        select  
                                        (CASE UPPER(A.TRANSACTION_DIRECTION) 
                                        WHEN 'I' THEN 'Input' 
                                        WHEN 'O' THEN 'Output' 
                                        WHEN Null THEN 'Unknown' 
                                        WHEN 'NULL' THEN 'Unknown' 
                                        ELSE A.TRANSACTION_DIRECTION END) AS TRANSACTION_DIRECTION
                                        ,count(a.case_rk)Total_Number_of_Cases 
                                        from [DGECM].dgcmgmt.case_live a 
                                        --LEFT JOIN
                                        --[DGECM].dgcmgmt.REF_TABLE_VAL b ON b.val_cd = a.CASE_STAT_CD AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
                                        WHERE 
                                        --a.case_stat_cd in ('SC','ST') and 
                                        a.case_type_cd = 'RTP'
                                        and
                                        CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE
                                        GROUP BY
                                        (CASE UPPER(A.TRANSACTION_DIRECTION) 
                                        WHEN 'I' THEN 'Input' 
                                        WHEN 'O' THEN 'Output' 
                                        WHEN Null THEN 'Unknown' 
                                        WHEN 'NULL' THEN 'Unknown' 
                                        ELSE A.TRANSACTION_DIRECTION END)
                                        ;
                                        END;
                                        GO
");
            //ART_ST_SYSTEM_PERF_PER_STATUS => Stored P
            migrationBuilder.Sql($@"SET ANSI_NULLS ON
                                        GO

                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                          CREATE PROCEDURE [ART_DB].[ART_ST_SYSTEM_PERF_PER_STATUS] 
                                        (
                                        @V_START_DATE date , @V_END_DATE date
                                        ) AS 
                                        BEGIN
                                        SET NOCOUNT ON;

                                        select 
                                        b.val_desc case_status,count(a.case_rk)Total_Number_of_Cases
                                        from [DGECM].dgcmgmt.case_live a 
                                        LEFT JOIN
                                        [DGECM].dgcmgmt.REF_TABLE_VAL b ON b.val_cd = a.CASE_STAT_CD AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
                                        where 
                                        CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE
                                        GROUP BY
                                        b.val_desc
                                        ;
                                        END;

                                        GO
");
            //ART_ST_SYSTEM_PERF_PER_TYPE => Stored P
            migrationBuilder.Sql($@"SET ANSI_NULLS ON
                                        GO

                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                          CREATE PROCEDURE [ART_DB].[ART_ST_SYSTEM_PERF_PER_TYPE] 
                                        (
                                        @V_START_DATE date , @V_END_DATE date
                                        ) AS 
                                        BEGIN
                                        SET NOCOUNT ON;

                                        select 
                                        b.VAL_DESC CASE_TYPE,count(a.case_rk)Total_Number_of_Cases
                                        from [DGECM].dgcmgmt.case_live a 
                                        LEFT JOIN
                                        [DGECM].dgcmgmt.REF_TABLE_VAL b ON lower(b.VAL_CD) = lower(a.CASE_TYPE_CD) AND b.REF_TABLE_NAME = 'RT_CASE_TYPE'
                                        where
                                        CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE
                                        GROUP BY
                                        b.VAL_DESC
                                        ;
                                        END;

                                        GO
");
            //ART_ST_USER_PERFORMANCE_PER_ACTION => Stored P
            migrationBuilder.Sql($@"SET ANSI_NULLS ON
                                            GO

                                            SET QUOTED_IDENTIFIER ON
                                            GO

                                              CREATE PROCEDURE [ART_DB].[ART_ST_USER_PERFORMANCE_PER_ACTION] 
                                            (
                                            @V_START_DATE date , @V_END_DATE date
                                            ) AS 
                                            BEGIN
                                            SET NOCOUNT ON;

                                            select 
                                            (case when A.action is null then 'Manually Closed' else  A.action end) action,
                                            count(distinct a.case_rk)Total_Number_Of_Cases,
                                            sum(a.durations_in_seconds) durations_in_seconds,
                                            floor(sum(a.durations_in_seconds)/count(a.case_rk)) AVG_durations_in_seconds,
                                            sum(a.durations_in_minutes) durations_in_minutes,
                                            floor(sum(a.durations_in_minutes)/count(a.case_rk)) AVG_durations_in_minutes,
                                            sum(a.durations_in_hours) durations_in_hours,
                                            floor(sum(a.durations_in_hours)/count(a.case_rk)) AVG_durations_in_hours,
                                            sum(a.durations_in_days) durations_in_days,
                                            floor(sum(a.durations_in_days)/count(a.case_rk)) AVG_durations_in_days 
                                            from [DGECM].dgcmgmt.art_user_performance a 
                                            WHERE
                                            CAST(a.CREATE_DATE AS date) >= @V_START_DATE AND CAST(a.CREATE_DATE AS date) <= @V_END_DATE
                                            group by  action
                                            ;
                                            END;

                                            GO

");
            //ART_ST_USER_PERFORMANCE_PER_ACTION_USER => Stored P
            migrationBuilder.Sql($@"
                                        SET ANSI_NULLS ON
                                        GO

                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                          CREATE PROCEDURE [ART_DB].[ART_ST_USER_PERFORMANCE_PER_ACTION_USER] 
                                        (
                                        @V_START_DATE date , @V_END_DATE date
                                        ) AS 
                                        BEGIN
                                        SET NOCOUNT ON;

                                        select 
                                        a.action_user,
                                        count(distinct a.case_rk)Total_Number_Of_Cases,
                                        sum(a.durations_in_seconds) durations_in_seconds,
                                        floor(sum(a.durations_in_seconds)/count(a.case_rk)) AVG_durations_in_seconds,
                                        sum(a.durations_in_minutes) durations_in_minutes,
                                        floor(sum(a.durations_in_minutes)/count(a.case_rk)) AVG_durations_in_minutes,
                                        sum(a.durations_in_hours) durations_in_hours,
                                        floor(sum(a.durations_in_hours)/count(a.case_rk)) AVG_durations_in_hours,
                                        sum(a.durations_in_days) durations_in_days,
                                        floor(sum(a.durations_in_days)/count(a.case_rk)) AVG_durations_in_days 
                                        from [DGECM].dgcmgmt.art_user_performance a 
                                        WHERE
                                        CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE

                                        group by  a.action_user
                                        ;
                                        END;

                                        GO
");
            //ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION => Stored P
            migrationBuilder.Sql($@"
                                        SET ANSI_NULLS ON
                                            GO
                                            SET QUOTED_IDENTIFIER ON
                                            GO
                                            CREATE PROCEDURE [ART_DB].[ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION] 
                                            (
                                            @V_START_DATE date , @V_END_DATE date
                                            ) AS 
                                            BEGIN
                                            SET NOCOUNT ON;
                                            select 
                                            a.action_user,
                                            (case when A.action is null then 'Manually Closed' else  A.action end) action,
                                            count(distinct a.case_rk)Total_Number_Of_Cases,
                                            sum(a.durations_in_seconds) durations_in_seconds,
                                            floor(sum(a.durations_in_seconds)/count(a.case_rk)) AVG_durations_in_seconds,
                                            sum(a.durations_in_minutes) durations_in_minutes,
                                            floor(sum(a.durations_in_minutes)/count(a.case_rk)) AVG_durations_in_minutes,
                                            sum(a.durations_in_hours) durations_in_hours,
                                            floor(sum(a.durations_in_hours)/count(a.case_rk)) AVG_durations_in_hours,
                                            sum(a.durations_in_days) durations_in_days,
                                            floor(sum(a.durations_in_days)/count(a.case_rk)) AVG_durations_in_days 
                                            from [DGECM].dgcmgmt.art_user_performance a 
                                            WHERE
                                            CAST(A.CREATE_DATE AS date) >= @V_START_DATE AND CAST(A.CREATE_DATE AS date) <= @V_END_DATE
                                            group by  a.action_user,
                                            (case when A.action is null then 'Manually Closed' else  A.action end)
                                            ;
                                            END;
                                            GO
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
