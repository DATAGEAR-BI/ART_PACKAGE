using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.FTI
{
    public partial class OutStaReportQueries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"

                        create or replace NONEDITIONABLE PROCEDURE       ""ART"".""ART_ST_TI_ODC_OUTSTA_REPORT"" 
                                                    (
                                                      DATA_CUR OUT SYS_REFCURSOR 
                                                    , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                                    , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                                                    ) AS 
                                                    BEGIN
                                                    OPEN DATA_CUR FOR 



                        SELECT EXEMPL30.SHORTN13,MASTER.MASTER_REF , PARTYDTLS.ADDRESS1 ,COLLMASTER.ISSUE_DATE,
                        COLLDRAFT.TENOR_DATE,
                        CASE COLLDRAFT.DRAFT_TYP
                        WHEN 'P' THEN 'PAYMENT'
                        WHEN 'A' THEN 'ACCEPTANCE'
                        ELSE 'ACCEPTANCE POUR AVAL'
                        END AS DRAFT_TYPE ,
                        case --outstanding amount formated
                        when to_number(c8pf.c8ced) = 0 then 
                        trim((to_char(COLLDRAFT.O_S_AMT ,'999999999999999')))
                        when to_number(c8pf.c8ced) = 2 then 
                        trim((to_char(COLLDRAFT.O_S_AMT/power(10,c8pf.c8ced) ,'999999999999999.99')))
                        when  to_number(c8pf.c8ced) = 3 then 
                        trim((to_char(COLLDRAFT.O_S_AMT/power(10,c8pf.c8ced) ,'999999999999999.999'))) end as Outstanding_amount,
                        COLLDRAFT.O_S_CCY,
                        case --master amount formated
                        when to_number(c8pf.c8ced) = 0 then 
                        trim((to_char(master.amount ,'999999999999999')))
                        when to_number(c8pf.c8ced) = 2 then 
                        trim((to_char(master.amount/power(10,c8pf.c8ced) ,'999999999999999.99')))
                        when  to_number(c8pf.c8ced) = 3 then 
                        trim((to_char(master.amount/power(10,c8pf.c8ced) ,'999999999999999.999'))) end as Master_amount
                        ,MASTER.CCY,
                        case --draft amount formated
                        when to_number(c8pf.c8ced) = 0 then 
                        trim((to_char(COLLDRAFT.PAY_AMT ,'999999999999999')))
                        when to_number(c8pf.c8ced) = 2 then 
                        trim((to_char(COLLDRAFT.PAY_AMT/power(10,c8pf.c8ced) ,'999999999999999.99')))
                        when  to_number(c8pf.c8ced) = 3 then 
                        trim((to_char(COLLDRAFT.PAY_AMT/power(10,c8pf.c8ced) ,'999999999999999.999'))) end AS DRAFT_AMT,
                        CASE COLLDRAFT.STATUS
                        WHEN 'P' THEN 'PAID'
                        WHEN 'WP' THEN 'Await pay'
                        WHEN 'RT' THEN 'RETURNED'
                        WHEN 'WA' THEN 'Await accept'
                        WHEN 'WV' THEN 'Await acc+aval'
                        WHEN 'NA' THEN 'Non accept'
                        WHEN 'NP' THEN 'Non pay'
                        ELSE 'Finance offer'
                        END AS DRAFT_STATUS,
                        (SELECT ADDRESS1 FROM PARTYDTLS@TIZONE2_LINK WHERE PARTYDTLS.KEY97 = COLLMASTER.DRAWEE_PTY) AS DRAWEE,
                        (SELECT COUNTRY FROM PARTYDTLS@TIZONE2_LINK WHERE PARTYDTLS.KEY97 = COLLMASTER.DRAWEE_PTY) AS DRAWEE_COUNTRY,
                        (SELECT ADDRESS1 FROM PARTYDTLS@TIZONE2_LINK WHERE PARTYDTLS.KEY97 = MASTER.NPCP_PTY) AS COLLECTING_BANK,
                        (SELECT COUNTRY FROM PARTYDTLS@TIZONE2_LINK WHERE PARTYDTLS.KEY97 = MASTER.NPCP_PTY) AS COLBANK_COUNTRY,
                        COLLMASTER.GOODS_DESC,COLLMASTER.GOODSCODE
                        FROM MASTER@TIZONE2_LINK JOIN exempl30@TIZONE2_LINK ON MASTER.EXEMPLAR = EXEMPL30.KEY97
                        JOIN COLLMASTER@TIZONE2_LINK ON COLLMASTER.KEY97 = MASTER.KEY97
                        JOIN PARTYDTLS@TIZONE2_LINK ON COLLMASTER.DRAWER_PTY = PARTYDTLS.KEY97
                        JOIN TIDATAITEM@TIZONE2_LINK ON TIDATAITEM.MASTER_KEY = MASTER.KEY97
                        JOIN COLLDRAFT@TIZONE2_LINK ON COLLDRAFT.KEY97 = TIDATAITEM.KEY97
                        LEFT JOIN C8PF@TIZONE2_LINK ON C8PF.C8CCY = MASTER.CCY
                        WHERE MASTER.EXEMPLAR= 175 AND master.refno_mbe <> 'MBWW' and master.status = 'LIV' and master.amt_o_s > 0
                        AND to_char(COLLMASTER.ISSUE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
                        AND to_char(COLLMASTER.ISSUE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
                        ORDER BY MASTER.MASTER_REF DESC;
                       END ART_ST_TI_ODC_OUTSTA_REPORT;
            ");
            migrationBuilder.Sql($@"create or replace NONEDITIONABLE PROCEDURE       ""ART"".""ART_TI_ODC_OUTSTA_SUMM_COUNTRY_REPORT"" 
(
DATA_CUR OUT SYS_REFCURSOR 
, V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
, V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
) AS 
BEGIN
OPEN DATA_CUR FOR

select count(master_ref) count ,c7pf.c7cnm
from master@TIZONE2_LINK join partydtls@TIZONE2_LINK on PARTYDTLS.KEY97 = MASTER.NPCP_PTY
join c7pf@TIZONE2_LINK on partydtls.country = c7pf.c7cna
WHERE MASTER.EXEMPLAR= 175 AND master.refno_mbe <> 'MBWW' and master.status = 'LIV' and master.amt_o_s > 0
group by c7pf.c7cnm;

END ART_TI_ODC_OUTSTA_SUMM_COUNTRY_REPORT;");
            migrationBuilder.Sql($@"create or replace NONEDITIONABLE PROCEDURE       ""ART"".""ART_TI_ODC_OUTSTA_SUMM_DRAFT_STATUS_REPORT"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 
select count(master.master_ref)No_drafts,
CASE COLLDRAFT.STATUS
WHEN 'P' THEN 'PAID'
WHEN 'WP' THEN 'Await pay'
WHEN 'RT' THEN 'RETURNED'
WHEN 'WA' THEN 'Await accept'
WHEN 'WV' THEN 'Await acc+aval'
WHEN 'NA' THEN 'Non accept'
WHEN 'NP' THEN 'Non pay'
ELSE 'Finance offer'
END AS DRAFT_STATUS
from master@TIZONE2_LINK join collmaster@TIZONE2_LINK on master.key97 = collmaster.key97
JOIN TIDATAITEM@TIZONE2_LINK ON TIDATAITEM.MASTER_KEY = MASTER.KEY97
JOIN COLLDRAFT@TIZONE2_LINK ON COLLDRAFT.KEY97 = TIDATAITEM.KEY97
where 
to_char(COLLMASTER.ISSUE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
AND to_char(COLLMASTER.ISSUE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
group by COLLDRAFT.STATUS;

END ART_TI_ODC_OUTSTA_SUMM_DRAFT_STATUS_REPORT;");
            migrationBuilder.Sql($@"create or replace NONEDITIONABLE PROCEDURE       ""ART"".""ART_TI_ODC_OUTSTA_SUMM_DRAFT_TYPE_REPORT"" 
                            (
                              DATA_CUR OUT SYS_REFCURSOR 
                            , V_START_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            , V_END_DATE IN VARCHAR2 DEFAULT to_date(SYSDATE,'dd-MON-yy')
                            ) AS 
                            BEGIN
                            OPEN DATA_CUR FOR 
select count(master.master_ref)No_drafts,
CASE COLLDRAFT.DRAFT_TYP
WHEN 'P' THEN 'PAYMENT'
WHEN 'A' THEN 'ACCEPTANCE'
ELSE 'ACCEPTANCE POUR AVAL'
END AS DRAFT_TYPE
from master@TIZONE2_LINK join collmaster@TIZONE2_LINK on master.key97 = collmaster.key97
JOIN TIDATAITEM@TIZONE2_LINK ON TIDATAITEM.MASTER_KEY = MASTER.KEY97
JOIN COLLDRAFT@TIZONE2_LINK ON COLLDRAFT.KEY97 = TIDATAITEM.KEY97
where 
to_char(COLLMASTER.ISSUE_DATE,'dd-MON-yy') >=  to_date(V_START_DATE,'yyyy-MM-dd')
AND to_char(COLLMASTER.ISSUE_DATE,'dd-MON-yy') <=   to_date(V_END_DATE,'yyyy-MM-dd')
group by COLLDRAFT.DRAFT_TYP;
END ART_TI_ODC_OUTSTA_SUMM_DRAFT_TYPE_REPORT;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
