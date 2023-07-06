using Data.Data;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class NCBAReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Views
            //ART_SYSTEM_PERFORMANCE
            migrationBuilder.Sql($@"
                 CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_SYSTEM_PERFORMANCE"" as
                                        select 
                                        a.CASE_ID, 
                                        t.VAL_DESC Case_Type,
                                        c.VAL_DESC CASE_STATUS, 
                                        a.CASE_DESC, 
                                        H.VAL_DESC AS PRIORITY, 
                                        a.CREATE_DATE, 
                                        a.UPDATE_USER_ID,
                                        (CASE WHEN a.transaction_type IS NULL OR a.transaction_type = 'null' THEN 'Unknown' else a.transaction_type end )transaction_type,
                                        a.transaction_amount,
                                        CASE a.transaction_direction WHEN 'I' THEN 'InComing' WHEN 'O' THEN 'OutGoing' WHEN NULL THEN 'Unknown' WHEN 'null' THEN 'Unknown' ELSE a.transaction_direction END AS transaction_direction, 
                                        a.transaction_currency ,
                                        a.swift_reference,
                                        (case when a.Col1 is null then a.Cust_Full_Name else a.Col1 end)CLIENT_NAME,
                                        a.Col2 IDENTITY_NUM,
                                        g.LOCK_USER_ID AS Locked_By, 
                                        M.CREATE_DTTM ECM_LAST_STATUS_DATE,
                                        a.hits_count,
                                        trunc(((cast(M.CREATE_DTTM as date) - cast(a.create_date as date))*24*60*60),1) AS DURATIONS_In_Seconds,
                                        trunc((cast(M.CREATE_DTTM as date) - cast(a.create_date as date))*24*60,1) AS DURATIONS_In_minutes,
                                        trunc((cast(M.CREATE_DTTM as date) - cast(a.create_date as date))*24 ,1) as DURATIONS_In_hours,
                                        trunc((cast(M.CREATE_DTTM as date) - cast(a.create_date as date)),1) AS DURATIONS_In_days
                                        from
                                        dgcmgmt.CASE_LIVE a  
                                        LEFT JOIN
                                        dgcmgmt.REF_TABLE_VAL t ON lower(t.VAL_CD) = lower(a.CASE_TYPE_CD) AND t.REF_TABLE_NAME = 'RT_CASE_TYPE'
                                        LEFT JOIN
                                        dgcmgmt.REF_TABLE_VAL c ON c.VAL_CD = a.CASE_STAT_CD AND c.REF_TABLE_NAME = 'RT_CASE_STATUS' LEFT JOIN
                                        dgcmgmt.ECM_ENTITY_LOCK g ON a.case_rk = g.ENTITY_RK AND g.ENTITY_NAME = 'CASE' LEFT JOIN
                                        dgcmgmt.REF_TABLE_VAL H ON H.VAL_CD = a.PRIORITY_CD AND H.REF_TABLE_NAME = 'X_RT_PRIORITY' 
                                        LEFT JOIN
                                        (
                                        SELECT        
                                        m.BUSINESS_OBJECT_RK,m.EVENT_DESC,max(m.create_date)CREATE_DTTM
                                        FROM
                                        dgcmgmt.ECM_EVENT M
                                        WHERE       
                                        m.BUSINESS_OBJECT_NAME = 'CASE' and m.event_desc not in ('Unlock Case','LOCK CASE')
                                        GROUP BY BUSINESS_OBJECT_RK,EVENT_DESC) M 
                                        ON a.CASE_RK = M.BUSINESS_OBJECT_RK AND a.CASE_STAT_CD = M.EVENT_DESC;
                            ");
            //ART_ALERTED_ENTITY
            migrationBuilder.Sql($@"
            CREATE OR REPLACE FORCE EDITIONABLE VIEW  ""ART"".""ART_ALERTED_ENTITY"" as
                            select 
                            Base.case_id,base.create_date,
                            CAST(replace(SUBSTR(d.udf_val,INSTR(d.udf_val,'FIRST NAME:',1)+15,INSTR(udf_val,'LAST NAME:',1)-INSTR(udf_val,'FIRST NAME:',1)-15),' ','')
                            || ' ' ||
                            replace(SUBSTR(d.udf_val,INSTR(d.udf_val,'LAST NAME:',1)+15,INSTR(udf_val,'MIDDLE NAME:',1)-INSTR(udf_val,'LAST NAME:',1)-15),' ','') AS VARCHAR2(100)) Name,
                            CAST(replace(SUBSTR(d.udf_val,INSTR(d.udf_val,'PEP IND:',1)+15,INSTR(udf_val,'CREATE DATE:',1)-INSTR(udf_val,'PEP IND:',1)-15),' ','') AS VARCHAR2(100)) PEP_IND
                            from
                            dgcmgmt.case_live Base left join dgcmgmt.case_udf_lgchr_val d
                            on Base.case_rk=d.case_rk and base.valid_from_date = d.valid_from_date and d.udf_name='X_REMARKS';
                            ");
            #endregion
            #region Procdure
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
                    (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end) case_status,count(a.case_rk)Total_Number_of_Cases
                    from dgcmgmt.case_live a 
                    LEFT JOIN
                    dgcmgmt.REF_TABLE_VAL b ON b.val_cd = a.CASE_STAT_CD AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
                    where 
                    to_char(a.create_date,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                    AND to_char(a.create_date,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                    GROUP BY
                    (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end)
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
                    (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end) CASE_TYPE,count(a.case_rk)Total_Number_of_Cases
                    from dgcmgmt.case_live a 
                    LEFT JOIN
                    dgcmgmt.REF_TABLE_VAL b ON lower(b.VAL_CD) = lower(a.CASE_TYPE_CD) AND b.REF_TABLE_NAME = 'RT_CASE_TYPE'
                    where
                    to_char(a.create_date,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                    AND to_char(a.create_date,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                    GROUP BY
                    (case when b.VAL_DESC is null then 'Unknown' else b.VAL_DESC end)
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

                            select  Month_|| '-'  || Year_  as Month,Number_Of_Cases from
                            (select 
                            EXTRACT(YEAR FROM a.create_date) Year_,
                            EXTRACT(Month FROM a.create_date) Month_,
                            TO_CHAR(a.create_date, 'MON') Month__,
                            count(a.case_id) Number_Of_Cases
                            from  dgcmgmt.case_live a
                            where
                            to_char(a.create_date,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(a.create_date,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            group by 
                            EXTRACT(YEAR FROM a.create_date),
                            EXTRACT(Month FROM a.create_date) ,
                            TO_CHAR(a.create_date, 'MON')
                            order by EXTRACT(YEAR FROM a.create_date) desc,EXTRACT(Month FROM a.create_date)  desc 
                            );
                            END ART_ST_SYSTEM_PERF_PER_DATE;
");
            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
