using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.Ecm
{
    public partial class EcmReports : Migration
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


            #region Views
            //ART_SYSTEM_PERFORMANCE
            migrationBuilder.Sql($@" CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_SYSTEM_PERFORMANCE"" (""CASE_ID"", ""CASE_RK"", ""VALID_FROM_DATE"", ""CASE_TYPE"", ""CASE_STATUS"", ""CASE_DESC"", ""PRIORITY"", ""CREATE_USER_ID"", ""INVESTR_USER_ID"", ""CREATE_DATE"", ""UPDATE_USER_ID"", ""TRANSACTION_TYPE"", ""TRANSACTION_AMOUNT"", ""TRANSACTION_DIRECTION"", ""TRANSACTION_CURRENCY"", ""SWIFT_REFERENCE"", ""CLIENT_NAME"", ""IDENTITY_NUM"", ""LOCKED_BY"", ""ECM_LAST_STATUS_DATE"", ""HITS_COUNT"", ""DURATIONS_IN_SECONDS"", ""DURATIONS_IN_MINUTES"", ""DURATIONS_IN_HOURS"", ""DURATIONS_IN_DAYS"") AS 
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
                                            --X_SWFM.UDF_VAL AS  SWIFT_MESSAGE,
                                            trunc(((cast(M.CREATE_DTTM as date) - cast(a.create_date as date))*24*60*60),1) AS DURATIONS_In_Seconds,
                                            trunc((cast(M.CREATE_DTTM as date) - cast(a.create_date as date))*24*60,1) AS DURATIONS_In_minutes,
                                            trunc((cast(M.CREATE_DTTM as date) - cast(a.create_date as date))*24 ,1) as DURATIONS_In_hours,
                                            trunc((cast(M.CREATE_DTTM as date) - cast(a.create_date as date)),1) AS DURATIONS_In_days

                                            from
                                            dgcmgmt.CASE_LIVE@DGCMGMTLINK a  LEFT JOIN
                                            dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK c ON c.VAL_CD = a.CASE_STAT_CD AND c.REF_TABLE_NAME = 'RT_CASE_STATUS' LEFT JOIN
                                            dgcmgmt.ECM_ENTITY_LOCK@DGCMGMTLINK g ON a.case_rk = g.ENTITY_RK AND g.ENTITY_NAME = 'CASE' LEFT JOIN
                                            dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK H ON H.VAL_CD = a.PRIORITY_CD AND H.REF_TABLE_NAME = 'X_RT_PRIORITY' 
                                            LEFT JOIN
                                            dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK T ON lower(T.VAL_CD) = lower(a.Case_Type_Cd) AND T.REF_TABLE_NAME = 'RT_CASE_TYPE' 
                                            LEFT JOIN
                                            (
                                            SELECT        
                                            m.BUSINESS_OBJECT_RK,max(m.create_date)CREATE_DTTM
                                            FROM
                                            dgcmgmt.ECM_EVENT@DGCMGMTLINK M
                                            WHERE       
                                            m.BUSINESS_OBJECT_NAME = 'CASE' and m.event_desc not in ('Unlock Case','LOCK CASE')
                                            GROUP BY BUSINESS_OBJECT_RK) M 
                                            ON a.CASE_RK = M.BUSINESS_OBJECT_RK 
                                            --left join 
                                            --dgcmgmt.case_udf_lgchr_val X_SWFM ON a.case_rk = X_SWFM.case_rk AND a.valid_from_date = x_swfm.valid_from_date AND X_SWFM.UDF_TABLE_NAME = 'CASE' AND x_swfm.udf_name ='X_SWFM'
                                            --where
                                            --a.case_stat_cd IN ('SC', 'ST')
                                            --and
                                            --trunc(a.create_date) >='01-OCT-21' 
                                            --and 
                                            --CASE_TYPE_CD not in ('FATCA_INDV','FATCA_ENTITY')
                                            ");

            //ART_SYSTEM_PERFORMANCE_NCBA
            migrationBuilder.Sql($@"  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_SYSTEM_PERFORMANCE_NCBA"" (""CASE_ID"", ""CASE_TTPE"", ""CASE_STATUS"", ""CASE_DESC"", ""PRIORITY"", ""CREATE_DATE"", ""UPDATE_USER_ID"", ""TRANSACTION_TYPE"", ""TRANSACTION_AMOUNT"", ""TRANSACTION_DIRECTION"", ""TRANSACTION_CURRENCY"", ""SWIFT_REFERENCE"", ""CLIENT_NAME"", ""IDENTITY_NUM"", ""LOCKED_BY"", ""ECM_LAST_STATUS_DATE"", ""HITS_COUNT"", ""DURATIONS_IN_SECONDS"", ""DURATIONS_IN_MINUTES"", ""DURATIONS_IN_HOURS"", ""DURATIONS_IN_DAYS"") AS 
  select 
a.CASE_ID, 
t.VAL_DESC CASE_TTPE,
c.VAL_DESC CASE_STATUS, 
a.CASE_DESC, 
H.VAL_DESC AS PRIORITY, 
a.CREATE_DATE, 
a.UPDATE_USER_ID,
(CASE WHEN a.transaction_type IS NULL OR a.transaction_type = 'null' THEN 'Unknown' else a.transaction_type end )TRANSACTION_TYPE,
a.TRANSACTION_AMOUNT,
CASE a.transaction_direction WHEN 'I' THEN 'Input' WHEN 'O' THEN 'Output' WHEN NULL THEN 'Unknown' WHEN 'null' THEN 'Unknown' ELSE a.transaction_direction END AS TRANSACTION_DIRECTION, 
a.transaction_currency TRANSACTION_CURRENCY ,
a.swift_reference SWIFT_REFERENCE,
(case when a.Col1 is null then a.Cust_Full_Name else a.Col1 end)CLIENT_NAME,
a.Col2 IDENTITY_NUM,
g.LOCK_USER_ID AS LOCKED_BY, 
M.CREATE_DTTM ECM_LAST_STATUS_DATE,
TO_NUMBER(a.hits_count) HITS_COUNT,
trunc(((cast(M.CREATE_DTTM as date) - cast(a.create_date as date))*24*60*60),1) AS DURATIONS_IN_SECONDS,
trunc((cast(M.CREATE_DTTM as date) - cast(a.create_date as date))*24*60,1) AS DURATIONS_IN_MINUTES,
trunc((cast(M.CREATE_DTTM as date) - cast(a.create_date as date))*24 ,1) as DURATIONS_IN_HOURS,
trunc((cast(M.CREATE_DTTM as date) - cast(a.create_date as date)),1) AS DURATIONS_IN_DAYS
from
dgcmgmt.CASE_LIVE@DGCMGMTLINK a  
LEFT JOIN
dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK t ON lower(t.VAL_CD) = lower(a.CASE_TYPE_CD) AND t.REF_TABLE_NAME = 'RT_CASE_TYPE'
LEFT JOIN
dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK c ON c.VAL_CD = a.CASE_STAT_CD AND c.REF_TABLE_NAME = 'RT_CASE_STATUS' LEFT JOIN
dgcmgmt.ECM_ENTITY_LOCK@DGCMGMTLINK g ON a.case_rk = g.ENTITY_RK AND g.ENTITY_NAME = 'CASE' LEFT JOIN
dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK H ON H.VAL_CD = a.PRIORITY_CD AND H.REF_TABLE_NAME = 'X_RT_PRIORITY' 
LEFT JOIN
(
SELECT        
m.BUSINESS_OBJECT_RK,m.EVENT_DESC,max(m.create_date)CREATE_DTTM
FROM
dgcmgmt.ECM_EVENT@DGCMGMTLINK M
WHERE       
m.BUSINESS_OBJECT_NAME = 'CASE' and m.event_desc not in ('Unlock Case','LOCK CASE')
GROUP BY BUSINESS_OBJECT_RK,EVENT_DESC) M 
ON a.CASE_RK = M.BUSINESS_OBJECT_RK AND a.CASE_STAT_CD = M.EVENT_DESC");

            //ART_USER_PERFORMANCE
            migrationBuilder.Sql(@$"CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_USER_PERFORMANCE"" (""CASE_RK"", ""CASE_ID"", ""VALID_FROM_DATE"", ""CASE_TYPE_CD"", ""CASE_STATUS"", ""PRIORITY"", ""CASE_DESC"", ""LOCKED_BY"", ""CREATE_USER_ID"", ""CREATE_DATE"", ""UPDATE_USER_ID"", ""ASSSIGNED_TIME"", ""ACTION_USER"", ""ACTION"", ""RELEASED_DATE"", ""DURATIONS_IN_SECONDS"", ""DURATIONS_IN_MINUTES"", ""DURATIONS_IN_HOURS"", ""DURATIONS_IN_DAYS"") AS 
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
                                                SUBSTR(I.EVENT_DESC, INSTR(I.EVENT_DESC, ':') + 6) else
                                                SUBSTR(I.EVENT_DESC, INSTR(I.EVENT_DESC, ':') + 2) end )ACTION,
                                                I.CREATE_DATE AS RELEASED_DATE,
                                                trunc(((cast(I.CREATE_DATE as date) - cast(bb.CREATE_DTTM as date))*24*60*60),1) AS DURATIONS_In_Seconds,
                                                trunc((cast(I.CREATE_DATE as date) - cast(bb.CREATE_DTTM as date))*24*60,1) AS DURATIONS_In_minutes,
                                                trunc((cast(I.CREATE_DATE as date) - cast(bb.CREATE_DTTM as date))*24 ,1) as DURATIONS_In_hours,
                                                trunc((cast(I.CREATE_DATE as date) - cast(bb.CREATE_DTTM as date)),1) AS DURATIONS_In_days
        
                                        from 
                                        case_live@DGCMGMTLINK a 
                                        LEFT JOIN dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK c
                                        ON c.VAL_CD = a.CASE_STAT_CD AND c.REF_TABLE_NAME = 'RT_CASE_STATUS'

                                        LEFT JOIN dgcmgmt.ECM_ENTITY_LOCK@DGCMGMTLINK g
                                        ON a.case_rk = g.ENTITY_RK AND g.ENTITY_NAME ='CASE'

                                        LEFT JOIN dgcmgmt.REF_TABLE_VAL@DGCMGMTLINK H
                                        ON H.VAL_CD = a.PRIORITY_CD AND H.REF_TABLE_NAME = 'X_RT_PRIORITY'

                                        left JOIN dgcmgmt.ECM_EVENT@DGCMGMTLINK I
                                        on I.BUSINESS_OBJECT_RK=a.CASE_RK   AND I.EVENT_TYPE_CD in('ACTVCWF','UPDCWF')

                                        left join (
                                        SELECT CREATE_USER_ID, CREATE_DATE CREATE_DTTM, BUSINESS_OBJECT_RK
                                        from (
                                        select ECM_EVENT.*, rank() OVER (PARTITION BY CREATE_USER_ID,BUSINESS_OBJECT_RK ORDER BY CREATE_DATE ASC) As RK
                                        from dgcmgmt.ECM_EVENT@DGCMGMTLINK
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
                                                SUBSTR(I.EVENT_DESC, INSTR(I.EVENT_DESC, ':') + 6) else
                                                SUBSTR(I.EVENT_DESC, INSTR(I.EVENT_DESC, ':') + 2) end) is not null
                                        ");


            //ِAlerted Entities
            migrationBuilder.Sql($@"CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_ALERTED_ENTITY"" 
as select * from ""DGCMGMT"".""ART_ALERTED_ENTITY""@DGCMGMTLINK
");
            #endregion


            #region Procs

            //ART_ST_SYSTEM_PERF_PER_DIRECTION
            migrationBuilder.Sql($@"

                                      CREATE OR REPLACE EDITIONABLE PROCEDURE ""ART"".""ART_ST_SYSTEM_PERF_PER_DIRECTION"" 
                                    (
                                      DATA_CUR OUT SYS_REFCURSOR 
                                    , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                    , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                    ) AS 
                                    BEGIN
                                    OPEN DATA_CUR FOR 

                                    select  
                                    (CASE UPPER(A.TRANSACTION_DIRECTION) 
                                    WHEN 'I' THEN 'Input' 
                                    WHEN 'O' THEN 'Output' 
                                    WHEN Null THEN 'Unknown' 
                                    ELSE A.TRANSACTION_DIRECTION END) AS TRANSACTION_DIRECTION
                                    ,count(a.case_rk)Total_Number_of_Cases 
                                    from DGCMGMT.case_live@DGCMGMTLINK a 
                                    --LEFT JOIN
                                    --DGCMGMT.REF_TABLE_VAL b ON b.val_cd = a.CASE_STAT_CD AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
                                    WHERE 
                                    --a.case_stat_cd in ('SC','ST') and 
                                    a.case_type_cd = 'SWIFT'
                                    and
                                    to_char(a.create_date,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                                    AND to_char(a.create_date,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                                    GROUP BY
                                    (CASE UPPER(A.TRANSACTION_DIRECTION) 
                                    WHEN 'I' THEN 'Input' 
                                    WHEN 'O' THEN 'Output' 
                                    WHEN Null THEN 'Unknown' 
                                    ELSE A.TRANSACTION_DIRECTION END)
                                    ;
                                    END ART_ST_SYSTEM_PERF_PER_DIRECTION;");
            //ART_ST_SYSTEM_PERF_PER_STATUS
            migrationBuilder.Sql($@"
                                      CREATE OR REPLACE EDITIONABLE PROCEDURE ""ART"".""ART_ST_SYSTEM_PERF_PER_STATUS"" 
                                    (
                                      DATA_CUR OUT SYS_REFCURSOR 
                                    , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                    , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                    ) AS 
                                    BEGIN
                                    OPEN DATA_CUR FOR 

                                    select 
                                    b.val_desc case_status,count(a.case_rk)Total_Number_of_Cases
                                    from case_live@DGCMGMTLINK a 
                                    LEFT JOIN
                                    REF_TABLE_VAL@DGCMGMTLINK b ON b.val_cd = a.CASE_STAT_CD AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
                                    where 
                                    to_char(a.create_date,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                                    AND to_char(a.create_date,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                                    GROUP BY
                                    b.val_desc
                                    ;
                                    END ART_ST_SYSTEM_PERF_PER_STATUS;");
            //ART_ST_SYSTEM_PERF_PER_TYPE
            migrationBuilder.Sql($@"

                                          CREATE OR REPLACE EDITIONABLE PROCEDURE ""ART"".""ART_ST_SYSTEM_PERF_PER_TYPE"" 
                                        (
                                          DATA_CUR OUT SYS_REFCURSOR 
                                        , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                        , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                        ) AS 
                                        BEGIN
                                        OPEN DATA_CUR FOR 

                                        select 
                                        b.VAL_DESC CASE_TYPE,count(a.case_rk)Total_Number_of_Cases
                                        from case_live@DGCMGMTLINK a 
                                        LEFT JOIN
                                        REF_TABLE_VAL@DGCMGMTLINK b ON lower(b.VAL_CD) = lower(a.CASE_TYPE_CD) AND b.REF_TABLE_NAME = 'RT_CASE_TYPE'
                                        where
                                        --CASE_TYPE_CD not in ('FATCA_INDV','FATCA_ENTITY')
                                        --and
                                        to_char(a.create_date,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                                        AND to_char(a.create_date,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                                        GROUP BY
                                        b.VAL_DESC
                                        ;
                                        END ART_ST_SYSTEM_PERF_PER_TYPE;");
            //ART_ST_SYSTEM_PERF_PER_DATE
            migrationBuilder.Sql($@"
  CREATE OR REPLACE EDITIONABLE PROCEDURE ""ART"".""ART_ST_SYSTEM_PERF_PER_DATE"" 
(
  DATA_CUR OUT SYS_REFCURSOR 
, V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
, V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
) AS 
BEGIN
OPEN DATA_CUR FOR 

select  15 as DAY , Month__ as MONTH ,Year_  as YEAR ,NUMBER_OF_CASES from
(select 
EXTRACT(YEAR FROM a.create_date) Year_,
EXTRACT(Month FROM a.create_date) Month_,
TO_CHAR(a.create_date, 'MON') Month__,
count(a.case_id) Number_Of_Cases
from  dgcmgmt.case_live@DGCMGMTLINK a
where
to_char(a.create_date,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
AND to_char(a.create_date,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
group by 
EXTRACT(YEAR FROM a.create_date),
EXTRACT(Month FROM a.create_date) ,
TO_CHAR(a.create_date, 'MON')
order by EXTRACT(YEAR FROM a.create_date) desc,EXTRACT(Month FROM a.create_date)  desc 
);
END ART_ST_SYSTEM_PERF_PER_DATE;");


            //ART_ST_USER_PERFORMANCE_PER_ACTION
            migrationBuilder.Sql(@$"

                                          CREATE OR REPLACE EDITIONABLE PROCEDURE ""ART"".""ART_ST_USER_PERFORMANCE_PER_ACTION"" 
                                        (
                                          DATA_CUR OUT SYS_REFCURSOR 
                                        , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                        , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                        --, V_CASE_ID IN VARCHAR2 DEFAULT NULL
                                        --, V_CASE_TYPE IN VARCHAR2 DEFAULT NULL
                                        --, V_CASE_STATUS IN VARCHAR2 DEFAULT NULL
                                        --, V_PREV_STATUS_USER IN VARCHAR2 DEFAULT NULL
                                        --, V_CREATE_USER IN VARCHAR2 DEFAULT NULL
                                        --, V_PREV_STATUS IN VARCHAR2 DEFAULT NULL
                                        ) AS 
                                        BEGIN
                                        OPEN DATA_CUR FOR 

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
                                        from art_user_performance a 
                                        WHERE

                                        to_char(a.CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                                        AND to_char(a.CREATE_DATE,'dd-MON-yy') <= to_date(V_END_DATE,'yyyy-MM-dd')
                                        --AND (V_CASE_ID IS NULL OR CASE_ID = V_CASE_ID)
                                        --AND (V_CASE_TYPE IS NULL OR CASE_TYPE
                                        --in (select regexp_substr(V_CASE_TYPE, '[^,]+', 1, level) from dual 
                                        --connect by regexp_substr(V_CASE_TYPE, '[^,]+', 1, level) is not null))
                                        --AND (V_CASE_STATUS IS NULL OR CASE_STATUS
                                        --in (select regexp_substr(V_CASE_STATUS, '[^,]+', 1, level) from dual 
                                        --connect by regexp_substr(V_CASE_STATUS, '[^,]+', 1, level) is not null))
                                        --AND (V_PREV_STATUS_USER IS NULL OR PREV_STATUS_USER
                                        --in (select regexp_substr(V_PREV_STATUS_USER, '[^,]+', 1, level) from dual 
                                        --connect by regexp_substr(V_PREV_STATUS_USER, '[^,]+', 1, level) is not null))
                                        --AND (V_CREATE_USER IS NULL OR CREATE_USER
                                        --in (select regexp_substr(V_CREATE_USER, '[^,]+', 1, level) from dual 
                                        --connect by regexp_substr(V_CREATE_USER, '[^,]+', 1, level) is not null))
                                        --AND (V_PREV_STATUS IS NULL OR trim(PREV_STATUS)
                                        --in (select trim(regexp_substr(V_PREV_STATUS, '[^,]+', 1, level)) from dual 
                                        --connect by trim(regexp_substr(V_PREV_STATUS, '[^,]+', 1, level)) is not null))
                                        group by  action
                                        ;
                                        END ART_ST_USER_PERFORMANCE_PER_ACTION;");
            //ART_ST_USER_PERFORMANCE_PER_ACTION_USER
            migrationBuilder.Sql($@"

                                      CREATE OR REPLACE EDITIONABLE PROCEDURE ""ART"".""ART_ST_USER_PERFORMANCE_PER_ACTION_USER"" 
                                    (
                                      DATA_CUR OUT SYS_REFCURSOR 
                                    , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                    , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                    --, V_CASE_ID IN VARCHAR2 DEFAULT NULL
                                    --, V_CASE_TYPE IN VARCHAR2 DEFAULT NULL
                                    --, V_CASE_STATUS IN VARCHAR2 DEFAULT NULL
                                    --, V_PREV_STATUS_USER IN VARCHAR2 DEFAULT NULL
                                    --, V_CREATE_USER IN VARCHAR2 DEFAULT NULL
                                    --, V_PREV_STATUS IN VARCHAR2 DEFAULT NULL
                                    ) AS 
                                    BEGIN
                                    OPEN DATA_CUR FOR 

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
                                    from art_user_performance a 
                                    WHERE

                                    to_char(a.CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                                    AND to_char(a.CREATE_DATE,'dd-MON-yy') <= to_date(V_END_DATE,'yyyy-MM-dd')
                                    --AND (V_CASE_ID IS NULL OR CASE_ID = V_CASE_ID)
                                    --AND (V_CASE_TYPE IS NULL OR CASE_TYPE
                                    --in (select regexp_substr(V_CASE_TYPE, '[^,]+', 1, level) from dual 
                                    --connect by regexp_substr(V_CASE_TYPE, '[^,]+', 1, level) is not null))
                                    --AND (V_CASE_STATUS IS NULL OR CASE_STATUS
                                    --in (select regexp_substr(V_CASE_STATUS, '[^,]+', 1, level) from dual 
                                    --connect by regexp_substr(V_CASE_STATUS, '[^,]+', 1, level) is not null))
                                    --AND (V_PREV_STATUS_USER IS NULL OR PREV_STATUS_USER
                                    --in (select regexp_substr(V_PREV_STATUS_USER, '[^,]+', 1, level) from dual 
                                    --connect by regexp_substr(V_PREV_STATUS_USER, '[^,]+', 1, level) is not null))
                                    --AND (V_CREATE_USER IS NULL OR CREATE_USER
                                    --in (select regexp_substr(V_CREATE_USER, '[^,]+', 1, level) from dual 
                                    --connect by regexp_substr(V_CREATE_USER, '[^,]+', 1, level) is not null))
                                    --AND (V_PREV_STATUS IS NULL OR trim(PREV_STATUS)
                                    --in (select trim(regexp_substr(V_PREV_STATUS, '[^,]+', 1, level)) from dual 
                                    --connect by trim(regexp_substr(V_PREV_STATUS, '[^,]+', 1, level)) is not null))
                                    group by  a.action_user
                                    ;
                                    END ART_ST_USER_PERFORMANCE_PER_ACTION_USER;");
            //ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION
            migrationBuilder.Sql($@"

                                      CREATE OR REPLACE EDITIONABLE PROCEDURE ""ART"".""ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION"" 
                                    (
                                      DATA_CUR OUT SYS_REFCURSOR 
                                    , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                    , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                    --, V_CASE_ID IN VARCHAR2 DEFAULT NULL
                                    --, V_CASE_TYPE IN VARCHAR2 DEFAULT NULL
                                    --, V_CASE_STATUS IN VARCHAR2 DEFAULT NULL
                                    --, V_PREV_STATUS_USER IN VARCHAR2 DEFAULT NULL
                                    --, V_CREATE_USER IN VARCHAR2 DEFAULT NULL
                                    --, V_PREV_STATUS IN VARCHAR2 DEFAULT NULL
                                    ) AS 
                                    BEGIN
                                    OPEN DATA_CUR FOR 

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
                                    from art_user_performance a 
                                    WHERE

                                    to_char(a.CREATE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                                    AND to_char(a.CREATE_DATE,'dd-MON-yy') <= to_date(V_END_DATE,'yyyy-MM-dd')
                                    --AND (V_CASE_ID IS NULL OR CASE_ID = V_CASE_ID)
                                    --AND (V_CASE_TYPE IS NULL OR CASE_TYPE
                                    --in (select regexp_substr(V_CASE_TYPE, '[^,]+', 1, level) from dual 
                                    --connect by regexp_substr(V_CASE_TYPE, '[^,]+', 1, level) is not null))
                                    --AND (V_CASE_STATUS IS NULL OR CASE_STATUS
                                    --in (select regexp_substr(V_CASE_STATUS, '[^,]+', 1, level) from dual 
                                    --connect by regexp_substr(V_CASE_STATUS, '[^,]+', 1, level) is not null))
                                    --AND (V_PREV_STATUS_USER IS NULL OR PREV_STATUS_USER
                                    --in (select regexp_substr(V_PREV_STATUS_USER, '[^,]+', 1, level) from dual 
                                    --connect by regexp_substr(V_PREV_STATUS_USER, '[^,]+', 1, level) is not null))
                                    --AND (V_CREATE_USER IS NULL OR CREATE_USER
                                    --in (select regexp_substr(V_CREATE_USER, '[^,]+', 1, level) from dual 
                                    --connect by regexp_substr(V_CREATE_USER, '[^,]+', 1, level) is not null))
                                    --AND (V_PREV_STATUS IS NULL OR trim(PREV_STATUS)
                                    --in (select trim(regexp_substr(V_PREV_STATUS, '[^,]+', 1, level)) from dual 
                                    --connect by trim(regexp_substr(V_PREV_STATUS, '[^,]+', 1, level)) is not null))
                                    group by  a.action_user,
                                    (case when A.action is null then 'Manually Closed' else  A.action end)
                                    ;
                                    END ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION;
                                    ");
            #endregion

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
