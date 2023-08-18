using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class GOAMLREports : Migration
    {
        private readonly bool IsAppliable;
        public GOAMLREports()
        {
            var m = MigrationsModules.GetModules();
            IsAppliable = m.Contains("GOAML");
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (!IsAppliable)
                return;
            //function that used in upcoming Views or Procs
            migrationBuilder.Sql($@"CREATE OR ALTER FUNCTION ART_DB.SplitString_XML
                                        (
                                            @string nvarchar(MAX),
                                            @delimiter nvarchar(10)
                                        )
                                        RETURNS @result TABLE (value nvarchar(MAX))
                                        AS
                                        BEGIN
                                            DECLARE @xml xml
                                            SET @xml = N'<rootitem><item>' + REPLACE(@string, @delimiter, '</item><item>') + '</item></rootitem>'

                                            INSERT INTO @result
                                            SELECT T.c.value('.', 'nvarchar(MAX)') AS value
                                            FROM @xml.nodes('/rootitem/item') T(c)

                                            RETURN
                                        END;
                                        ");
            //Views
            migrationBuilder.Sql($@"CREATE OR ALTER view [ART_DB].[ART_GOAML_REPORTS_DETAILS] as
                                    SELECT
	                                    ID,
                                        REPORTCODE,
                                        REPORTSTATUSCODE,
	                                    CASE
                                            WHEN ISDATE(submissiondate) = 1 THEN CONVERT(datetime, submissiondate)
                                            WHEN ISDATE(SUBSTRING(submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(submissiondate, 1, 10))
                                            ELSE NULL
                                        END AS SUBMISSIONDATE,
                                        --cast (submissiondate as datetime) SUBMISSIONDATE,
                                        REPORTUSERLOCKID,    
                                        cast(reportcreateddate as datetime) REPORTCREATEDDATE,
                                        PRIORITY,
                                        REPORTCREATEDBY,
                                        ENTITYREFERENCE,
                                        FIUREFNUMBER,
                                        RENTITYBRANCH,
                                        REASON,
                                        REPORTINGPERSONTYPE,
                                        CURRENCYCODELOCAL,
                                        ACTION,
                                        VERSION,
                                        ISVALID,
                                        LOCATION,
                                        RENTITYID,
                                        CAST(reportcloseddate as datetime) REPORTCLOSEDDATE,
                                        REPORTRISKSIGNIFICANCE,
                                        REPORTXML,
                                        SUBMISSIONCODE,
                                        LAST_UPDATED_DATE
                                    FROM
                                        DGGOAML_NEW.target.report 
                                        left join (select history.report_id,max(history.last_updated_date)  last_updated_date
                                        from DGGOAML_NEW.target.history history
                                        GROUP BY history.report_id) history
                                        on report.id=history.report_id;");
            migrationBuilder.Sql(@$"CREATE OR ALTER VIEW [ART_DB].[ART_GOAML_REPORTS_INDICATORS]
                                        AS
                                        SELECT distinct 
                                        DGGOAML_NEW.target.ReportIndicatorType.Report_ID REPORT_ID, DGGOAML_NEW.target.ReportIndicatorType.indicator INDICATOR, 
                                        SUBSTRING(INDICATOR_DESC, CHARINDEX('/', INDICATOR_DESC) + 1, LEN(INDICATOR_DESC) - CHARINDEX('/', INDICATOR_DESC)) DESCRIPTION
                                         FROM            
                                        [DGGOAML_NEW].target.ReportIndicatorType 
                                        LEFT JOIN
                                        [DGGOAML_NEW].FCFCORE.GOAML_INDICATORS_DESC ON DGGOAML_NEW.target.ReportIndicatorType.indicator = DGGOAML_NEW.FCFCORE.GOAML_INDICATORS_DESC.INDICATOR;");
            migrationBuilder.Sql($@"create OR ALTER view [ART_DB].[ART_GOAML_REPORTS_SUSBECT_PARTIES] as 
SELECT DISTINCT
R.ID 
,R.REPORTCODE
,R.REPORTSTATUSCODE
,R.ENTITYREFERENCE
,R.FIUREFNUMBER
,'' TRANSACTIONNUMBER
,CASE
        WHEN ISDATE(R.submissiondate) = 1 THEN CONVERT(datetime, R.submissiondate)
        WHEN ISDATE(SUBSTRING(R.submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(R.submissiondate, 1, 10))
        ELSE NULL
    END AS SUBMISSIONDATE
,CAST(R.REPORTCREATEDDATE as datetime) REPORTCREATEDDATE
,CAST(R.REPORTCLOSEDDATE as datetime) REPORTCLOSEDDATE
,TP.PARTYNUMBER
,'' ACCOUNT
,TP.SSN PARTY_ID
,TP.FIRSTNAME PARTY_NAME
,'' BRANCH
,'Person' ACTIVITY


FROM [DGGOAML_NEW].TARGET.REPORT  R
INNER JOIN [DGGOAML_NEW].TARGET.ACTIVITY ACT ON R.ID=ACT.REPORT_ID
INNER JOIN [DGGOAML_NEW].TARGET.REPORTPARTYTYPE RPT ON RPT.ACTIVITY_ID=ACT.ID
INNER JOIN [DGGOAML_NEW].TARGET.TPERSON TP ON RPT.ID=TP.REPORTPARTYTYPE_ID
LEFT JOIN [DGGOAML_NEW].SOURCE.PERSONACCOUNTBRIDGE PAB ON TP.PARTYNUMBER=PAB.PARTY_NUMBER AND PAB.CHANGE_CURRENT_IND='Y'
LEFT JOIN [DGGOAML_NEW].SOURCE.SACCOUNT SA ON PAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'

UNION 

 SELECT   
R.ID
,R.REPORTCODE
,R.REPORTSTATUSCODE
,R.ENTITYREFERENCE
,R.FIUREFNUMBER
,'' TRANSACTIONNUMBER
,CASE
        WHEN ISDATE(R.submissiondate) = 1 THEN CONVERT(datetime, R.submissiondate)
        WHEN ISDATE(SUBSTRING(R.submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(R.submissiondate, 1, 10))
        ELSE NULL
    END AS submissiondate
,CAST(R.REPORTCREATEDDATE as datetime) REPORTCREATEDDATE
,CAST(R.REPORTCLOSEDDATE as datetime) REPORTCLOSEDDATE
,SP.PARTYNUMBER
,TA.ACCOUNT
,SP.SSN PARTY_ID
,SP.FIRSTNAME PARTY_NAME
,TA.BRANCH
,'Account' ACTIVITY

FROM [DGGOAML_NEW].TARGET.REPORT  R
INNER JOIN [DGGOAML_NEW].TARGET.ACTIVITY ACT ON R.ID=ACT.REPORT_ID
INNER JOIN [DGGOAML_NEW].TARGET.REPORTPARTYTYPE RPT ON RPT.ACTIVITY_ID=ACT.ID
INNER JOIN [DGGOAML_NEW].TARGET.TACCOUNT TA ON RPT.ID=TA.REPORTPARTYTYPE_ID
LEFT JOIN [DGGOAML_NEW].SOURCE.PERSONACCOUNTBRIDGE PAB ON TA.ACCOUNT =PAB.ACCOUNTNUMBER AND PAB.CHANGE_CURRENT_IND='Y'
LEFT JOIN [DGGOAML_NEW].SOURCE.SPERSON SP ON PAB.PARTY_NUMBER =SP.PARTYNUMBER AND SP.CHANGE_CURRENT_IND='Y'

UNION

SELECT distinct
R.ID
,R.REPORTCODE
,R.REPORTSTATUSCODE
,R.ENTITYREFERENCE
,R.FIUREFNUMBER
,'' TRANSACTIONNUMBER
,CASE
        WHEN ISDATE(R.submissiondate) = 1 THEN CONVERT(datetime, R.submissiondate)
        WHEN ISDATE(SUBSTRING(R.submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(R.submissiondate, 1, 10))
        ELSE NULL
    END AS submissiondate
,CAST(R.REPORTCREATEDDATE as datetime) REPORTCREATEDDATE
,CAST(R.REPORTCLOSEDDATE as datetime) REPORTCLOSEDDATE
,TE.ENTITYNUMBER
,'' ACCOUNT
,TE.INCORPORATIONNUMBER PARTY_ID
,TE.NAME PARTY_NAME
,SA.BRANCH
,'Entity' ACTIVITY

FROM [DGGOAML_NEW].TARGET.REPORT  R
INNER JOIN [DGGOAML_NEW].TARGET.ACTIVITY ACT ON R.ID=ACT.REPORT_ID
INNER JOIN [DGGOAML_NEW].TARGET.REPORTPARTYTYPE RPT ON RPT.ACTIVITY_ID=ACT.ID
INNER JOIN [DGGOAML_NEW].TARGET.TENTITY TE ON RPT.ID=TE.REPORTPARTYTYPE_ID
LEFT JOIN [DGGOAML_NEW].SOURCE.ENTITYACCOUNTBRIDGE EAB ON TE.ENTITYNUMBER=EAB.ENTITY_NUMBER AND EAB.CHANGE_CURRENT_IND='Y'
LEFT JOIN [DGGOAML_NEW].SOURCE.SACCOUNT SA ON EAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'


union
SELECT 
R.ID 
,R.REPORTCODE
,R.REPORTSTATUSCODE
,R.ENTITYREFERENCE
,R.FIUREFNUMBER
,TR.TRANSACTIONNUMBER
,CASE
        WHEN ISDATE(R.submissiondate) = 1 THEN CONVERT(datetime, R.submissiondate)
        WHEN ISDATE(SUBSTRING(R.submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(R.submissiondate, 1, 10))
        ELSE NULL
    END AS submissiondate
,CAST(R.REPORTCREATEDDATE as datetime) REPORTCREATEDDATE
,CAST(R.REPORTCLOSEDDATE as datetime) REPORTCLOSEDDATE
,TP.PARTYNUMBER
,SA.ACCOUNT
,TP.SSN PARTY_ID
,Concat(TP.FIRSTNAME,TP.MIDDLENAME,TP.LASTNAME) PARTY_NAME
,SA.BRANCH
,'From Person' ACTIVITY

FROM [DGGOAML_NEW].target.report r
inner join [DGGOAML_NEW].target.[transaction] tr on r.id = tr.report_id
inner join [DGGOAML_NEW].target.TFrom tfrom1 on tr.id in(tfrom1.transaction_id, tfrom1.transactionMyClient_id)
inner join [DGGOAML_NEW].target.TPerson TP on tfrom1.t_person_id=TP.id
LEFT JOIN [DGGOAML_NEW].SOURCE.PERSONACCOUNTBRIDGE PAB ON TP.PARTYNUMBER=PAB.PARTY_NUMBER AND PAB.CHANGE_CURRENT_IND='Y'
LEFT JOIN [DGGOAML_NEW].SOURCE.SACCOUNT SA ON PAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'


union
 SELECT  
R.ID
,R.REPORTCODE
,R.REPORTSTATUSCODE
,R.ENTITYREFERENCE
,R.FIUREFNUMBER
,TR.TRANSACTIONNUMBER
,CASE
        WHEN ISDATE(R.submissiondate) = 1 THEN CONVERT(datetime, R.submissiondate)
        WHEN ISDATE(SUBSTRING(R.submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(R.submissiondate, 1, 10))
        ELSE NULL
    END AS submissiondate
,CAST(R.REPORTCREATEDDATE as datetime) REPORTCREATEDDATE
,CAST(R.REPORTCLOSEDDATE as datetime) REPORTCLOSEDDATE,
SP.PARTYNUMBER,
TA.ACCOUNT
,SP.SSN PARTY_ID
,concat(SP.FIRSTNAME,SP.MIDDLENAME,SP.LASTNAME) PARTY_NAME
,TA.BRANCH
,'From Account' ACTIVITY

FROM [DGGOAML_NEW].target.report r
inner join [DGGOAML_NEW].target.[transaction] tr on r.id = tr.report_id
inner join [DGGOAML_NEW].target.TFrom tfrom1 on tr.id in(tfrom1.transaction_id, tfrom1.transactionMyClient_id)
inner join [DGGOAML_NEW].target.TAccount tA on tfrom1.t_account_id = tA.id
LEFT JOIN [DGGOAML_NEW].SOURCE.PERSONACCOUNTBRIDGE PAB ON TA.ACCOUNT =PAB.ACCOUNTNUMBER AND PAB.CHANGE_CURRENT_IND='Y'
LEFT JOIN [DGGOAML_NEW].SOURCE.SPERSON SP ON PAB.PARTY_NUMBER =SP.PARTYNUMBER AND SP.CHANGE_CURRENT_IND='Y'

union

SELECT  
R.ID
,R.REPORTCODE
,R.REPORTSTATUSCODE
,R.ENTITYREFERENCE
,R.FIUREFNUMBER
,TR.TRANSACTIONNUMBER
,CASE
        WHEN ISDATE(R.submissiondate) = 1 THEN CONVERT(datetime, R.submissiondate)
        WHEN ISDATE(SUBSTRING(R.submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(R.submissiondate, 1, 10))
        ELSE NULL
    END AS SUBMISSIONDATE
,CAST(R.REPORTCREATEDDATE as datetime) REPORTCREATEDDATE
,CAST(R.REPORTCLOSEDDATE as datetime) REPORTCLOSEDDATE
,TE.ENTITYNUMBER 
,SA.ACCOUNT
,TE.INCORPORATIONNUMBER PARTY_ID
,TE.NAME PARTY_NAME
,SA.BRANCH
,'From Entity' ACTIVITY


FROM [DGGOAML_NEW].target.report r
inner join [DGGOAML_NEW].target.[transaction] tr on r.id = tr.report_id
inner join [DGGOAML_NEW].target.TFrom tfrom1 on tr.id in(tfrom1.transaction_id, tfrom1.transactionMyClient_id)
inner join [DGGOAML_NEW].TARGET.tentity TE on tfrom1.t_account_id = TE.id
LEFT JOIN [DGGOAML_NEW].SOURCE.ENTITYACCOUNTBRIDGE EAB ON TE.ENTITYNUMBER=EAB.ENTITY_NUMBER AND EAB.CHANGE_CURRENT_IND='Y'
LEFT JOIN [DGGOAML_NEW].SOURCE.SACCOUNT SA ON EAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'

union

SELECT distinct
R.ID 
,R.REPORTCODE
,R.REPORTSTATUSCODE
,R.ENTITYREFERENCE
,R.FIUREFNUMBER
,TR.TRANSACTIONNUMBER
,CASE
        WHEN ISDATE(R.submissiondate) = 1 THEN CONVERT(datetime, R.submissiondate)
        WHEN ISDATE(SUBSTRING(R.submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(R.submissiondate, 1, 10))
        ELSE NULL
    END AS submissiondate
,CAST(R.REPORTCREATEDDATE as datetime) REPORTCREATEDDATE
,CAST(R.REPORTCLOSEDDATE as datetime) REPORTCLOSEDDATE,
TP.PARTYNUMBER
,'' ACCOUNT
,TP.SSN PARTY_ID
,concat(TP.FIRSTNAME,TP.MIDDLENAME,TP.LASTNAME) PARTY_NAME
,SA.BRANCH
,'To Person' ACTIVITY

FROM [DGGOAML_NEW].target.report r
inner join [DGGOAML_NEW].target.[transaction] tr on r.id = tr.report_id
inner join [DGGOAML_NEW].target.TTO TTO1 on tr.id in(TTO1.transaction_id, TTO1.transactionMyClient_id)
inner join [DGGOAML_NEW].target.TPerson TP on TTO1.t_person_id=TP.id
LEFT JOIN [DGGOAML_NEW].SOURCE.PERSONACCOUNTBRIDGE PAB ON TP.PARTYNUMBER=PAB.PARTY_NUMBER AND PAB.CHANGE_CURRENT_IND='Y'
LEFT JOIN [DGGOAML_NEW].SOURCE.SACCOUNT SA ON PAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'

union
 SELECT  DISTINCT 
R.ID
,R.REPORTCODE
,R.REPORTSTATUSCODE
,R.ENTITYREFERENCE
,R.FIUREFNUMBER
,TR.TRANSACTIONNUMBER
,CASE
        WHEN ISDATE(R.submissiondate) = 1 THEN CONVERT(datetime, R.submissiondate)
        WHEN ISDATE(SUBSTRING(R.submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(R.submissiondate, 1, 10))
        ELSE NULL
    END AS submissiondate
,CAST(R.REPORTCREATEDDATE as datetime) REPORTCREATEDDATE
,CAST(R.REPORTCLOSEDDATE as datetime) REPORTCLOSEDDATE,
SP.PARTYNUMBER
,TA.ACCOUNT
,SP.SSN PARTY_ID
,concat(SP.FIRSTNAME,SP.MIDDLENAME,SP.LASTNAME) PARTY_NAME
,TA.BRANCH
,'To Account' ACTIVITY

FROM [DGGOAML_NEW].target.report r
inner join [DGGOAML_NEW].target.[transaction] tr on r.id = tr.report_id
inner join [DGGOAML_NEW].target.TTO TTO1 on tr.id in(TTO1.transaction_id, TTO1.transactionMyClient_id)
inner join [DGGOAML_NEW].target.TAccount tA on TTO1.t_account_id = tA.id
LEFT JOIN [DGGOAML_NEW].SOURCE.PERSONACCOUNTBRIDGE PAB ON TA.ACCOUNT =PAB.ACCOUNTNUMBER AND PAB.CHANGE_CURRENT_IND='Y'
LEFT JOIN [DGGOAML_NEW].SOURCE.SPERSON SP ON PAB.PARTY_NUMBER =SP.PARTYNUMBER AND SP.CHANGE_CURRENT_IND='Y'

union

SELECT  DISTINCT 
R.ID
,R.REPORTCODE
,R.REPORTSTATUSCODE
,R.ENTITYREFERENCE
,R.FIUREFNUMBER
,TR.TRANSACTIONNUMBER
,CASE
        WHEN ISDATE(R.submissiondate) = 1 THEN CONVERT(datetime, R.submissiondate)
        WHEN ISDATE(SUBSTRING(R.submissiondate, 1, 10)) = 1 THEN CONVERT(datetime, SUBSTRING(R.submissiondate, 1, 10))
        ELSE NULL
    END AS submissiondate
,CAST(R.REPORTCREATEDDATE as datetime) REPORTCREATEDDATE
,CAST(R.REPORTCLOSEDDATE as datetime) REPORTCLOSEDDATE,
TE.ENTITYNUMBER PARTYNUMBER
,SA.ACCOUNT
,TE.INCORPORATIONNUMBER PARTY_ID
,TE.NAME PARTY_NAME
,SA.BRANCH
,'To Entity' ACTIVITY

FROM [DGGOAML_NEW].target.report r
inner join [DGGOAML_NEW].target.[transaction] tr on r.id = tr.report_id
inner join [DGGOAML_NEW].target.TTO TTO1 on tr.id in(TTO1.transaction_id, TTO1.transactionMyClient_id)
inner join [DGGOAML_NEW].TARGET.tentity TE on TTO1.t_account_id = TE.id
LEFT JOIN [DGGOAML_NEW].SOURCE.ENTITYACCOUNTBRIDGE EAB ON TE.ENTITYNUMBER=EAB.ENTITY_NUMBER AND EAB.CHANGE_CURRENT_IND='Y'
LEFT JOIN [DGGOAML_NEW].SOURCE.SACCOUNT SA ON EAB.ACCOUNTNUMBER =SA.ACCOUNT AND SA.CHANGE_CURRENT_IND='Y'");

            //Stored Procs 
            migrationBuilder.Sql($@"  CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_GOAML_REPORTS_PER_CREATOR]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

select 
reportcreatedby CREATED_BY,
 CAST(count(id) AS DECIMAL(10, 0)) NUMBER_OF_REPORTS 
FROM
[DGGOAML_NEW].target.report
Where CAST(reportcreateddate AS date) >= @V_START_DATE AND CAST(reportcreateddate AS date) <= @V_END_DATE
group by reportcreatedby;
END;");
            migrationBuilder.Sql($@"CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_GOAML_REPORTS_PER_INDICATOR]
                                        (
                                        @V_REPORT_ID nvarchar(max), @V_INDICATOR nvarchar(max)
                                        ) AS 
                                        BEGIN
                                        SET NOCOUNT ON;

                                        select 
                                        [DGGOAML_NEW].target.REPORTINDICATORTYPE.INDICATOR,
                                         CAST(count(REPORT_ID) AS DECIMAL(10, 0)) NUMBER_OF_REPORTS 
                                        FROM
                                        [DGGOAML_NEW].target.REPORTINDICATORTYPE
                                        Where (@V_REPORT_ID IS NULL OR REPORT_ID  = @V_REPORT_ID )
                                        and (@V_INDICATOR IS NULL OR [DGGOAML_NEW].target.REPORTINDICATORTYPE.INDICATOR  COLLATE Latin1_General_100_CI_AI_SC IN (select value from [ART_DB].SplitString_XML(@V_INDICATOR , ',')))
                                        group by [DGGOAML_NEW].target.REPORTINDICATORTYPE.INDICATOR;
                                        END;");
            migrationBuilder.Sql($@"CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_GOAML_REPORTS_PER_STATUS]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

select 
REPORTSTATUSCODE REPORT_STATUS,
 CAST(count(id) AS DECIMAL(10, 0)) NUMBER_OF_REPORTS 
FROM
[DGGOAML_NEW].target.report
Where CAST(reportcreateddate AS date) >= @V_START_DATE AND CAST(reportcreateddate AS date) <= @V_END_DATE
group by REPORTSTATUSCODE;
END;");
            migrationBuilder.Sql($@" CREATE OR ALTER PROCEDURE [ART_DB].[ART_ST_GOAML_REPORTS_PER_TYPE]
(
@V_START_DATE date , @V_END_DATE date
) AS 
BEGIN
SET NOCOUNT ON;

select 
REPORTCODE REPORT_TYPE,
 CAST(count(id) AS DECIMAL(10, 0)) NUMBER_OF_REPORTS 
FROM
[DGGOAML_NEW].target.report
Where CAST(reportcreateddate AS date) >= @V_START_DATE AND CAST(reportcreateddate AS date) <= @V_END_DATE
group by REPORTCODE;
END;");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
