using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.ArtGoAml
{
    public partial class ArtGoAmlReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //GOAML_INDICATORS
            migrationBuilder.Sql(@"CREATE TABLE GOAML_INDICATORS 
                        (
                          GOAML_INDICATORS_CODE VARCHAR2(5 BYTE) NOT NULL 
                        , GOAML_INDICATORS_DESCRIPTION VARCHAR2(150 BYTE) NOT NULL 
                        )");
            #region Views
            //ART_GOAML_REPORTS_DETAILS
            migrationBuilder.Sql(@" CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_GOAML_REPORTS_DETAILS"" (""ID"", ""REPORTCODE"", ""REPORTSTATUSCODE"", ""SUBMISSIONDATE"", ""REPORTUSERLOCKID"", ""REPORTCREATEDDATE"", ""PRIORITY"", ""REPORTCREATEDBY"", ""ENTITYREFERENCE"", ""FIUREFNUMBER"", ""RENTITYBRANCH"", ""REASON"", ""REPORTINGPERSONTYPE"", ""CURRENCYCODELOCAL"", ""ACTION"", ""VERSION"", ""ISVALID"", ""LOCATION"", ""RENTITYID"", ""REPORTCLOSEDDATE"", ""REPORTRISKSIGNIFICANCE"", ""REPORTXML"", ""SUBMISSIONCODE"", ""LAST_UPDATED_DATE"") AS 
                                  SELECT
                                    id,
                                    reportcode,
                                    reportstatuscode,
                                    TO_TIMESTAMP(submissiondate,'YYYY-MM-DD""T""HH24:MI:SS""Z""') submissiondate,
                                    reportuserlockid,    
                                    TO_TIMESTAMP(reportcreateddate,'YYYY-MM-DD""T""HH24:MI:SS""Z""') reportcreateddate,
                                    priority,
                                    reportcreatedby,
                                    entityreference,
                                    fiurefnumber,
                                    (case when rentitybranch is null then 'UNKNOWN' else rentitybranch end)rentitybranch,
                                    reason,
                                    reportingpersontype,
                                    currencycodelocal,
                                    action,
                                    version,
                                    isvalid,
                                    location,
                                    rentityid,
                                    TO_TIMESTAMP(reportcloseddate,'YYYY-MM-DD""T""HH24:MI:SS""Z""') reportcloseddate,
                                    reportrisksignificance,
                                    reportxml,
                                    submissioncode,
                                    last_updated_date
                                FROM
                                    target.report 
                                    left join (select history.report_id,max(history.last_updated_date)  last_updated_date
                                    from target.history history
                                    GROUP BY history.report_id) history
                                    on report.id=history.report_id
                                ");
            //ART_GOAML_REPORTS_SUSBECT_PARTIES
            migrationBuilder.Sql(@" CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_GOAML_REPORTS_SUSBECT_PARTIES"" (""ID"", ""REPORTCODE"", ""REPORTSTATUSCODE"", ""ENTITYREFERENCE"", ""FIUREFNUMBER"", ""TRANSACTIONNUMBER"", ""SUBMISSIONDATE"", ""REPORTCREATEDDATE"", ""REPORTCLOSEDDATE"", ""PARTYNUMBER"", ""ACCOUNT"", ""PARTY_ID"", ""PARTY_NAME"", ""BRANCH"", ""ACTIVITY"") AS 
                                        SELECT   distinct
                                        R.ID 
                                        ,R.REPORTCODE
                                        ,R.REPORTSTATUSCODE
                                        ,R.ENTITYREFERENCE
                                        ,R.FIUREFNUMBER
                                        ,'' transactionnumber
                                        ,TO_TIMESTAMP(R.SUBMISSIONDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') SUBMISSIONDATE
                                        ,TO_TIMESTAMP(R.REPORTCREATEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCREATEDDATE
                                        ,TO_TIMESTAMP(R.REPORTCLOSEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCLOSEDDATE
                                        ,TP.PARTYNUMBER
                                        ,'' ACCOUNT
                                        ,TP.SSN PARTY_ID
                                        ,TP.FIRSTNAME PARTY_NAME
                                        ,'' BRANCH
                                        ,'Person' Activity


                                        FROM TARGET.REPORT  R
                                        INNER JOIN TARGET.ACTIVITY ACT ON R.ID=ACT.REPORT_ID
                                        INNER JOIN TARGET.REPORTPARTYTYPE RPT ON RPT.ACTIVITY_ID=ACT.ID
                                        INNER JOIN TARGET.TPERSON TP ON RPT.ID=TP.REPORTPARTYTYPE_ID
                                        LEFT JOIN SOURCE.PERSONACCOUNTBRIDGE PAB ON TP.PARTYNUMBER=PAB.PARTY_NUMBER AND PAB.CHANGE_CURRENT_IND='Y'
                                        LEFT JOIN SOURCE.SACCOUNT SA ON PAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'

                                        UNION 

                                         SELECT   
                                        R.ID
                                        ,R.REPORTCODE
                                        ,R.REPORTSTATUSCODE
                                        ,R.ENTITYREFERENCE
                                        ,R.FIUREFNUMBER
                                        ,'' transactionnumber
                                        ,TO_TIMESTAMP(R.SUBMISSIONDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') SUBMISSIONDATE
                                        ,TO_TIMESTAMP(R.REPORTCREATEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCREATEDDATE
                                        ,TO_TIMESTAMP(R.REPORTCLOSEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCLOSEDDATE
                                        ,SP.PARTYNUMBER
                                        ,TA.ACCOUNT
                                        ,SP.SSN PARTY_ID
                                        ,SP.FIRSTNAME PARTY_NAME
                                        ,TA.BRANCH
                                        ,'Account' Activity

                                        FROM TARGET.REPORT  R
                                        INNER JOIN TARGET.ACTIVITY ACT ON R.ID=ACT.REPORT_ID
                                        INNER JOIN TARGET.REPORTPARTYTYPE RPT ON RPT.ACTIVITY_ID=ACT.ID
                                        INNER JOIN TARGET.TACCOUNT TA ON RPT.ID=TA.REPORTPARTYTYPE_ID
                                        LEFT JOIN SOURCE.PERSONACCOUNTBRIDGE PAB ON TA.ACCOUNT =PAB.ACCOUNTNUMBER AND PAB.CHANGE_CURRENT_IND='Y'
                                        LEFT JOIN SOURCE.SPERSON SP ON PAB.PARTY_NUMBER =SP.PARTYNUMBER AND SP.CHANGE_CURRENT_IND='Y'

                                        UNION

                                        SELECT  distinct
                                        R.ID
                                        ,R.REPORTCODE
                                        ,R.REPORTSTATUSCODE
                                        ,R.ENTITYREFERENCE
                                        ,R.FIUREFNUMBER
                                        ,'' transactionnumber
                                        ,TO_TIMESTAMP(R.SUBMISSIONDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') SUBMISSIONDATE
                                        ,TO_TIMESTAMP(R.REPORTCREATEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCREATEDDATE
                                        ,TO_TIMESTAMP(R.REPORTCLOSEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCLOSEDDATE
                                        ,TE.ENTITYNUMBER
                                        ,'' ACCOUNT
                                        ,TE.INCORPORATIONNUMBER PARTY_ID
                                        ,TE.NAME PARTY_NAME
                                        ,SA.BRANCH
                                        ,'Entity' Activity

                                        FROM TARGET.REPORT  R
                                        INNER JOIN TARGET.ACTIVITY ACT ON R.ID=ACT.REPORT_ID
                                        INNER JOIN TARGET.REPORTPARTYTYPE RPT ON RPT.ACTIVITY_ID=ACT.ID
                                        INNER JOIN TARGET.TENTITY TE ON RPT.ID=TE.REPORTPARTYTYPE_ID
                                        LEFT JOIN SOURCE.ENTITYACCOUNTBRIDGE EAB ON TE.ENTITYNUMBER=EAB.ENTITY_NUMBER AND EAB.CHANGE_CURRENT_IND='Y'
                                        LEFT JOIN SOURCE.SACCOUNT SA ON EAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'


                                        union
                                        SELECT   
                                        R.ID 
                                        ,R.REPORTCODE
                                        ,R.REPORTSTATUSCODE
                                        ,R.ENTITYREFERENCE
                                        ,R.FIUREFNUMBER
                                        ,tr.transactionnumber
                                        ,TO_TIMESTAMP(R.SUBMISSIONDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') SUBMISSIONDATE
                                        ,TO_TIMESTAMP(R.REPORTCREATEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCREATEDDATE
                                        ,TO_TIMESTAMP(R.REPORTCLOSEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCLOSEDDATE
                                        ,TP.PARTYNUMBER
                                        ,SA.ACCOUNT
                                        ,TP.SSN party_id
                                        ,TP.FIRSTNAME||TP.MIDDLENAME||TP.LASTNAME PARTY_NAME
                                        ,SA.BRANCH
                                        ,'From Person' Activity
                                        FROM target.report r
                                        inner join target.transaction tr on r.id = tr.report_id
                                        inner join target.TFrom tfrom1 on tr.id in(tfrom1.transaction_id, tfrom1.transactionMyClient_id)
                                        inner join target.TPerson TP on tfrom1.t_person_id=TP.id
                                        LEFT JOIN SOURCE.PERSONACCOUNTBRIDGE PAB ON TP.PARTYNUMBER=PAB.PARTY_NUMBER AND PAB.CHANGE_CURRENT_IND='Y'
                                        LEFT JOIN SOURCE.SACCOUNT SA ON PAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'


                                        union 
                                         SELECT   
                                        R.ID
                                        ,R.REPORTCODE
                                        ,R.REPORTSTATUSCODE
                                        ,R.ENTITYREFERENCE
                                        ,R.FIUREFNUMBER
                                        ,tr.transactionnumber
                                        ,TO_TIMESTAMP(R.SUBMISSIONDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') SUBMISSIONDATE
                                        ,TO_TIMESTAMP(R.REPORTCREATEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCREATEDDATE
                                        ,TO_TIMESTAMP(R.REPORTCLOSEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCLOSEDDATE
                                        ,SP.PARTYNUMBER
                                        ,TA.ACCOUNT
                                        ,SP.SSN PARTY_ID
                                        ,SP.FIRSTNAME||SP.MIDDLENAME||SP.LASTNAME PARTY_NAME
                                        ,TA.BRANCH
                                        ,'From Account' Activity

                                        FROM target.report r
                                        inner join target.transaction tr on r.id = tr.report_id
                                        inner join target.TFrom tfrom1 on tr.id in(tfrom1.transaction_id, tfrom1.transactionMyClient_id)
                                        inner join target.TAccount tA on tfrom1.t_account_id = tA.id
                                        LEFT JOIN SOURCE.PERSONACCOUNTBRIDGE PAB ON TA.ACCOUNT =PAB.ACCOUNTNUMBER AND PAB.CHANGE_CURRENT_IND='Y'
                                        LEFT JOIN SOURCE.SPERSON SP ON PAB.PARTY_NUMBER =SP.PARTYNUMBER AND SP.CHANGE_CURRENT_IND='Y'

                                        union 

                                        SELECT   
                                        R.ID
                                        ,R.REPORTCODE
                                        ,R.REPORTSTATUSCODE
                                        ,R.ENTITYREFERENCE
                                        ,R.FIUREFNUMBER
                                        ,tr.transactionnumber
                                        ,TO_TIMESTAMP(R.SUBMISSIONDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') SUBMISSIONDATE
                                        ,TO_TIMESTAMP(R.REPORTCREATEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCREATEDDATE
                                        ,TO_TIMESTAMP(R.REPORTCLOSEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCLOSEDDATE
                                        ,TE.ENTITYNUMBER
                                        ,SA.ACCOUNT
                                        ,TE.INCORPORATIONNUMBER PARTY_ID
                                        ,TE.NAME PARTY_NAME
                                        ,SA.BRANCH
                                        ,'From Entity' Activity

                                        FROM target.report r
                                        inner join target.transaction tr on r.id = tr.report_id
                                        inner join target.TFrom tfrom1 on tr.id in(tfrom1.transaction_id, tfrom1.transactionMyClient_id)
                                        inner join TARGET.tentity TE on tfrom1.t_account_id = TE.id
                                        LEFT JOIN SOURCE.ENTITYACCOUNTBRIDGE EAB ON TE.ENTITYNUMBER=EAB.ENTITY_NUMBER AND EAB.CHANGE_CURRENT_IND='Y'
                                        LEFT JOIN SOURCE.SACCOUNT SA ON EAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'
                                        union 

                                        SELECT   distinct
                                        R.ID 
                                        ,R.REPORTCODE
                                        ,R.REPORTSTATUSCODE
                                        ,R.ENTITYREFERENCE
                                        ,R.FIUREFNUMBER
                                        ,tr.transactionnumber
                                        ,TO_TIMESTAMP(R.SUBMISSIONDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') SUBMISSIONDATE
                                        ,TO_TIMESTAMP(R.REPORTCREATEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCREATEDDATE
                                        ,TO_TIMESTAMP(R.REPORTCLOSEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCLOSEDDATE
                                        ,TP.PARTYNUMBER
                                        ,'' ACCOUNT
                                        ,TP.SSN party_id
                                        ,TP.FIRSTNAME||TP.MIDDLENAME||TP.LASTNAME PARTY_NAME
                                        ,SA.BRANCH
                                        ,'To Person' Activity
                                        FROM target.report r
                                        inner join target.transaction tr on r.id = tr.report_id
                                        inner join target.TTO TTO1 on tr.id in(TTO1.transaction_id, TTO1.transactionMyClient_id)
                                        inner join target.TPerson TP on TTO1.t_person_id=TP.id
                                        LEFT JOIN SOURCE.PERSONACCOUNTBRIDGE PAB ON TP.PARTYNUMBER=PAB.PARTY_NUMBER AND PAB.CHANGE_CURRENT_IND='Y'
                                        LEFT JOIN SOURCE.SACCOUNT SA ON PAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'

                                        union
                                         SELECT   distinct
                                        R.ID
                                        ,R.REPORTCODE
                                        ,R.REPORTSTATUSCODE
                                        ,R.ENTITYREFERENCE
                                        ,R.FIUREFNUMBER
                                        ,tr.transactionnumber
                                        ,TO_TIMESTAMP(R.SUBMISSIONDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') SUBMISSIONDATE
                                        ,TO_TIMESTAMP(R.REPORTCREATEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCREATEDDATE
                                        ,TO_TIMESTAMP(R.REPORTCLOSEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCLOSEDDATE
                                        ,SP.PARTYNUMBER
                                        ,TA.ACCOUNT
                                        ,SP.SSN PARTY_ID
                                        ,SP.FIRSTNAME||SP.MIDDLENAME||SP.LASTNAME PARTY_NAME
                                        ,TA.BRANCH
                                        ,'To Account' Activity

                                        FROM target.report r
                                        inner join target.transaction tr on r.id = tr.report_id
                                        inner join target.TTO TTO1 on tr.id in(TTO1.transaction_id, TTO1.transactionMyClient_id)
                                        inner join target.TAccount tA on TTO1.t_account_id = tA.id
                                        LEFT JOIN SOURCE.PERSONACCOUNTBRIDGE PAB ON TA.ACCOUNT =PAB.ACCOUNTNUMBER AND PAB.CHANGE_CURRENT_IND='Y'
                                        LEFT JOIN SOURCE.SPERSON SP ON PAB.PARTY_NUMBER =SP.PARTYNUMBER AND SP.CHANGE_CURRENT_IND='Y'

                                        union 

                                        SELECT   distinct
                                        R.ID
                                        ,R.REPORTCODE
                                        ,R.REPORTSTATUSCODE
                                        ,R.ENTITYREFERENCE
                                        ,R.FIUREFNUMBER
                                        ,tr.transactionnumber
                                        ,TO_TIMESTAMP(R.SUBMISSIONDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') SUBMISSIONDATE
                                        ,TO_TIMESTAMP(R.REPORTCREATEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCREATEDDATE
                                        ,TO_TIMESTAMP(R.REPORTCLOSEDDATE,'YYYY-MM-DD""T""HH24:MI:SS""Z""') REPORTCLOSEDDATE
                                        ,TE.ENTITYNUMBER
                                        ,'' ACCOUNT
                                        ,TE.INCORPORATIONNUMBER PARTY_ID
                                        ,TE.NAME PARTY_NAME
                                        ,SA.BRANCH
                                        ,'To Entity' Activity

                                        FROM target.report r
                                        inner join target.transaction tr on r.id = tr.report_id
                                        inner join target.TTO TTO1 on tr.id in(TTO1.transaction_id, TTO1.transactionMyClient_id)
                                        inner join TARGET.tentity TE on TTO1.t_entity_id = TE.id-- TTO1.t_account_id = TE.id
                                        LEFT JOIN SOURCE.ENTITYACCOUNTBRIDGE EAB ON TE.ENTITYNUMBER=EAB.ENTITY_NUMBER AND EAB.CHANGE_CURRENT_IND='Y'
                                        LEFT JOIN SOURCE.SACCOUNT SA ON EAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'

");
            //ART_GOAML_REPORTS_INDICATORS
            migrationBuilder.Sql(@" CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_GOAML_REPORTS_INDICATORS"" (""REPORT_ID"", ""INDICATOR"", ""DESCRIPTION"") AS 
                              select type.REPORT_ID,type.INDICATOR,des.goaml_indicators_description
                              from 
                              target.REPORTINDICATORTYPE type
                            LEFT JOIN goaml_indicators des on type.indicator=des.GOAML_INDICATORS_CODE");
            #endregion
            #region Prod
            //ART_ST_GOAML_REPORTS_PER_CREATOR
            migrationBuilder.Sql(@"

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_GOAML_REPORTS_PER_CREATOR"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            select 
                            reportcreatedby Created_By,
                            count(id) number_of_reports 
                            FROM
                            target.report
                            where to_char(to_date(reportcreateddate, 'YYYY-MM-DD""T""HH24:MI:SS'), 'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(to_date(reportcreateddate, 'YYYY-MM-DD""T""HH24:MI:SS'), 'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            group by reportcreatedby;
                            END ART_ST_GOAML_REPORTS_PER_CREATOR;");
            //ART_ST_GOAML_REPORTS_PER_INDICATOR
            migrationBuilder.Sql(@"

                          CREATE OR REPLACE EDITIONABLE PROCEDURE ""ART"".""ART_ST_GOAML_REPORTS_PER_INDICATOR"" 
                        (
                          DATA_CUR OUT SYS_REFCURSOR 
                        , V_REPORT_ID IN VARCHAR2 DEFAULT NULL
                        , V_INDICATOR IN VARCHAR2 DEFAULT NULL
                        ) AS 
                        BEGIN
                        OPEN DATA_CUR FOR 

                        select 
                        type.INDICATOR,
                        count(REPORT_ID)number_of_reports 
                        from 
                        target.REPORTINDICATORTYPE type
                        WHERE
                         (V_REPORT_ID IS NULL OR REPORT_ID = V_REPORT_ID)
                        AND (V_INDICATOR IS NULL OR INDICATOR
                        in (select regexp_substr(V_INDICATOR, '[^,]+', 1, level) from dual 
                        connect by regexp_substr(V_INDICATOR, '[^,]+', 1, level) is not null))
                        GROUP BY type.INDICATOR
                        ;
                        END ART_ST_GOAML_REPORTS_PER_INDICATOR;");
            //ART_ST_GOAML_REPORTS_PER_STATUS
            migrationBuilder.Sql(@"

                              CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_GOAML_REPORTS_PER_STATUS"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 

                            select 
                            REPORTSTATUSCODE Report_Status,
                            count(id) number_of_reports 
                            FROM
                            target.report
                            where to_char(to_date(reportcreateddate, 'YYYY-MM-DD""T""HH24:MI:SS'), 'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                            AND to_char(to_date(reportcreateddate, 'YYYY-MM-DD""T""HH24:MI:SS'), 'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                            group by REPORTSTATUSCODE;
                            END ART_ST_GOAML_REPORTS_PER_STATUS;");
            //ART_ST_GOAML_REPORTS_PER_TYPE
            migrationBuilder.Sql(@"

                          CREATE OR REPLACE NONEDITIONABLE PROCEDURE ""ART"".""ART_ST_GOAML_REPORTS_PER_TYPE"" 
                        (
                          DATA_CUR OUT SYS_REFCURSOR 
                        , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                        , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                        ) AS 
                        BEGIN
                        OPEN DATA_CUR FOR 

                        select 
                        REPORTCODE Report_Type,
                        count(id) number_of_reports 
                        FROM
                        target.report
                        where to_char(to_date(reportcreateddate, 'YYYY-MM-DD""T""HH24:MI:SS'), 'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                        AND to_char(to_date(reportcreateddate, 'YYYY-MM-DD""T""HH24:MI:SS'), 'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                        group by REPORTCODE;
                        END ART_ST_GOAML_REPORTS_PER_TYPE;");

            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
