using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing.Printing;
using System.IO;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class FTI_Reports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Views
            //ART_TI_ACPOSTINGS_ACC_REPORT
            migrationBuilder.Sql($@"
             CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_ACPOSTINGS_ACC_REPORT"" (""EVENT_REF"", ""MASTER_REF"", ""ACCT_NO"", ""SHORTNAME"", ""DR_CR_FLG"", ""POST_AMOUNT"", ""CCY"", ""POST_AMOUNT_EGP"", ""VALUEDATE"", ""CUS_MNM"", ""SPSK"", ""MAINBANKING"", ""ACCOUNT_TYPE"", ""BRANCH_NAME"") AS 
                              SELECT 
                            POSTEDPOSTINGS.EVENT_REF, 
                            POSTEDPOSTINGS.MASTER_REF, 
                            POSTEDPOSTINGS.ACCT_NO, 
                            TRIM(regexp_replace(regexp_replace(regexp_replace(ACCOUNT.SHORTNAME, chr(13),''), chr(10) , ''), chr(9) , '')) SHORTNAME, 
                            (case when POSTEDPOSTINGS.DR_CR_FLG='D' then 'Dr' else 'Cr' end)DR_CR_FLG, 
                            --C8PF.C8CED, 
                            --POSTEDPOSTINGS.POST_AMOUNT,
                            (POSTEDPOSTINGS.POST_AMOUNT/ power(10,c8pf.c8ced)) POST_AMOUNT,
                            POSTEDPOSTINGS.CCY, 
                            ((POSTEDPOSTINGS.POST_AMOUNT/ power(10,c8pf.c8ced))*SPOTRATE)AS POST_AMOUNT_EGP,
                            POSTEDPOSTINGS.VALUEDATE,--Date Filter 
                            TRIM(regexp_replace(regexp_replace(regexp_replace(ACCOUNT.CUS_MNM, chr(13),''), chr(10) , ''), chr(9) , '')) CUS_MNM, 
                            POSTEDPOSTINGS.SPSK, 
                            POSTEDPOSTINGS.MAINBANKING, 
                            (trim(C5PF.C5ATP)||' - '||C5PF.C5ATD) Account_Type,
                            CAPF.FULLNAME Branch_Name -- Filter For Branch Name 
                            FROM   
                            TIZONE2.POSTEDPOSTINGS@TIZONE2_LINK POSTEDPOSTINGS, 
                            TIZONE2.ACCOUNT@TIZONE2_LINK ACCOUNT, 
                            TIZONE2.C8PF@TIZONE2_LINK C8PF, 
                            TIZONE2.C5PF@TIZONE2_LINK C5PF,
                            TIZONE2.CAPF@TIZONE2_LINK CAPF,
                            TIZONE2.SPOTRATE@TIZONE2_LINK SPOTRATE

                            WHERE  
                            (POSTEDPOSTINGS.ACCT_KEY=ACCOUNT.ACCT_KEY) 
                            AND (ACCOUNT.CURRENCY=C8PF.C8CCY) 
                            AND (ACCOUNT.ACC_TYPE=C5PF.C5ATP)
                            AND (POSTEDPOSTINGS.branch = CAPF.CABRNM)
                            AND (POSTEDPOSTINGS.CCY = SPOTRATE.currency) AND SPOTRATE.branch = 'BMEG'
                            ORDER BY POSTEDPOSTINGS.ACCT_NO");
            //ART_TI_ACPOSTINGS_CUST_REPORT
            migrationBuilder.Sql($@"
               CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_ACPOSTINGS_CUST_REPORT"" (""EVENT_REF"", ""MASTER_REF"", ""ACCT_NO"", ""SHORTNAME"", ""DR_CR_FLG"", ""POST_AMOUNT"", ""CCY"", ""POST_AMOUNT_EGP"", ""VALUEDATE"", ""CUS_MNM"", ""SPSK"", ""MAINBANKING"", ""ACCOUNT_TYPE"", ""BRANCH_NAME"") AS 
                      SELECT 
                    POSTEDPOSTINGS.EVENT_REF, 
                    POSTEDPOSTINGS.MASTER_REF, 
                    POSTEDPOSTINGS.ACCT_NO, 
                    ACCOUNT.SHORTNAME, 
                    (case when POSTEDPOSTINGS.DR_CR_FLG='D' then 'Dr' else 'Cr' end)DR_CR_FLG, 
                    (POSTEDPOSTINGS.POST_AMOUNT/ power(10,c8pf.c8ced)) POST_AMOUNT,
                    POSTEDPOSTINGS.CCY, --Filter For Currency from c8pf.C8SCY
                    ((POSTEDPOSTINGS.POST_AMOUNT/ power(10,c8pf.c8ced))*SPOTRATE)AS POST_AMOUNT_EGP,
                    POSTEDPOSTINGS.VALUEDATE,--date filter 
                    ACCOUNT.CUS_MNM, --Filter For Customer Short Name
                    POSTEDPOSTINGS.SPSK, -- Filter for SPSK
                    POSTEDPOSTINGS.MAINBANKING, 
                    (trim(C5PF.C5ATP)||' - '||C5PF.C5ATD) Account_Type,-- Filter For Account Type from c5pf.C5ATP then use C5ATD in the report
                    CAPF.FULLNAME Branch_Name -- Filter For Branch Name 
                    FROM   

                    TIZONE2.POSTEDPOSTINGS@TIZONE2_LINK POSTEDPOSTINGS, 
                    TIZONE2.ACCOUNT@TIZONE2_LINK  ACCOUNT, 
                    TIZONE2.C8PF@TIZONE2_LINK  C8PF, 
                    TIZONE2.C5PF@TIZONE2_LINK  C5PF,
                    TIZONE2.CAPF@TIZONE2_LINK  ,
                    TIZONE2.SPOTRATE@TIZONE2_LINK 

                    WHERE  

                    (POSTEDPOSTINGS.ACCT_KEY=ACCOUNT.ACCT_KEY) 
                    AND (ACCOUNT.CURRENCY=C8PF.C8CCY) 
                    AND (ACCOUNT.ACC_TYPE=C5PF.C5ATP)
                    AND (POSTEDPOSTINGS.branch = CAPF.CABRNM)
                    AND (POSTEDPOSTINGS.CCY = SPOTRATE.currency AND SPOTRATE.branch = 'BMEG')
                    ORDER BY 
                    POSTEDPOSTINGS.ACCT_NO");
            //ART_TI_ACTIVITY_REPORT
            migrationBuilder.Sql($@"
             CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_ACTIVITY_REPORT"" (""PRODUCT"", ""BASE_STATUS"", ""TOUCHED"", ""AMOUNT"", ""CCY"", ""AMOUNT_EGP"", ""BRANCH_NAME"", ""MASTER_REF"", ""RELMSTRREF"", ""ADDRESS1"", ""SW_BANK"", ""SW_CTR"", ""SW_LOC"", ""SW_BRANCH"", ""CUS_MNM"", ""GFCUN"", ""ADDRESS12"", ""GFCUN12"", ""CUS_MNM12"", ""SW_BANK12"", ""SW_CTR12"", ""SW_LOC12"", ""SW_BRANCH12"", ""TEAM"", ""EVENT_REF"", ""CCY_CED"", ""RELMSTRREF12"", ""SOVALUE"", ""BHALF_BRN"", ""STARTED"", ""STARTED_FILTER"", ""SHORTNAME"", ""LANGUAGE"", ""EVENT_STATUS"", ""LSTMODUSER"", ""STEPDESCR"", ""START_DATE"", ""START_TIME"") AS 
                                  SELECT 
                                PROD.longna85 Product, -- Filter For Product
                                BASEEVENT.STATUS BASE_STATUS, 
                                BASEEVENT.TOUCHED, 
                                --BASEEVENT.AMOUNT, 
                                (BASEEVENT.AMOUNT/ power(10,c8pf.c8ced)) AMOUNT,
                                BASEEVENT.CCY, 
                                ((BASEEVENT.AMOUNT/ power(10,c8pf.c8ced))*SPOTRATE)AS AMOUNT_EGP,
                                CAPF.FULLNAME Branch_Name, -- Filter For Branch Name 
                                RPTMASTERS.MASTER_REF, 
                                RPTMASTERS.RELMSTRREF, 
                                PCP_PARTY.ADDRESS1, 
                                PCP_PARTY.SW_BANK, 
                                PCP_PARTY.SW_CTR, 
                                PCP_PARTY.SW_LOC, 
                                PCP_PARTY.SW_BRANCH, 
                                PCP_PARTY.CUS_MNM, 
                                PCP_PARTY.GFCUN, 
                                NPCP_PARTY.ADDRESS1 ADDRESS12 , 
                                NPCP_PARTY.GFCUN GFCUN12, 
                                NPCP_PARTY.CUS_MNM CUS_MNM12, 
                                NPCP_PARTY.SW_BANK SW_BANK12, 
                                NPCP_PARTY.SW_CTR SW_CTR12, 
                                NPCP_PARTY.SW_LOC SW_LOC12, 
                                NPCP_PARTY.SW_BRANCH SW_BRANCH12, 
                                --RPTMASTERS.WORKGROUP Team, -- Filter For Team
                                (trim(RPTMASTERS.WORKGROUP)||' '||trim(TEAM.DESCRI56)) Team,
                                (trim(BASEEVENT.REFNO_PFIX)||' '||trim(BASEEVENT.REFNO_SERL)) Event_Ref,
                                CCYDTLS.CCY_CED, 
                                ALLRLMSTRS.RELMSTRREF RELMSTRREF12, 
                                PRODSHORTNAME.SOVALUE, 
                                RPTMASTERS.BHALF_BRN, 
                                EVENTTSTAMPS.STARTED, 
                                (to_date(substr(EVENTTSTAMPS.STARTED, 1, instr(EVENTTSTAMPS.STARTED, '-', 1, 3)-1),'yyyy-mm-dd'))STARTED_Filter,--Filter for start & end dates
                                EVENTSHORTNAME.SHORTNAME, 
                                EVENTSHORTNAME.LANGUAGE, 
                                (case when EVENTSTEP.STATUS ='i' then 'In progress' 
                                when EVENTSTEP.STATUS ='c' then 'Completed'
                                when EVENTSTEP.STATUS ='a' then 'Aborted'
                                end) EVENT_STATUS, 
                                EVENTSTEP.LSTMODUSER, 
                                EVENTSTEPNAMES.STEPDESCR,
                                BASEEVENT.START_DATE,
                                BASEEVENT.START_TIME

                                FROM   
                                TIZONE2.RPTMASTERS@TIZONE2_LINK RPTMASTERS, 
                                TIZONE2.BASEEVENT@TIZONE2_LINK BASEEVENT, 
                                TIZONE2.EXEMPL30@TIZONE2_LINK PRODUCT, 
                                TIZONE2.ALLRLMSTRS@TIZONE2_LINK ALLRLMSTRS, 
                                TIZONE2.WORKGR44@TIZONE2_LINK TEAM, 
                                TIZONE2.CAPF@TIZONE2_LINK  CAPF, 
                                TIZONE2.RPTPARTIES@TIZONE2_LINK  PCP_PARTY, 
                                TIZONE2.RPTPARTIES@TIZONE2_LINK  NPCP_PARTY, 
                                TIZONE2.PRODSHORTNAME@TIZONE2_LINK  PRODSHORTNAME, 
                                TIZONE2.EVENTCCY@TIZONE2_LINK  EVENTCCY, 
                                TIZONE2.EVENTTSTAMPS@TIZONE2_LINK  EVENTTSTAMPS, 
                                TIZONE2.EVENTSHORTNAME@TIZONE2_LINK  EVENTSHORTNAME, 
                                TIZONE2.EVENTSTEP@TIZONE2_LINK  EVENTSTEP, 
                                TIZONE2.EVENTSTEPNAMES@TIZONE2_LINK  EVENTSTEPNAMES, 
                                TIZONE2.CCYDTLS@TIZONE2_LINK  CCYDTLS,
                                TIZONE2.EXEMPL30@TIZONE2_LINK  PROD,
                                TIZONE2.C8PF@TIZONE2_LINK  C8PF,
                                TIZONE2.SPOTRATE@TIZONE2_LINK 

                                WHERE  

                                (RPTMASTERS.KEY97=BASEEVENT.MASTER_KEY) 
                                AND (RPTMASTERS.EXEMPLAR=PRODUCT.KEY97) 
                                AND (RPTMASTERS.KEY97=ALLRLMSTRS.MASTERKEY (+)) 
                                AND (RPTMASTERS.WORKGROUP=TEAM.CODE79 (+)) 
                                AND (RPTMASTERS.BHALF_BRN=CAPF.CABRNM) 
                                AND (RPTMASTERS.PCP_PTY=PCP_PARTY.PARTYKEY) 
                                AND (RPTMASTERS.NPCP_PTY=NPCP_PARTY.PARTYKEY) 
                                AND (PRODUCT.CODE79=PRODSHORTNAME.PRODCODE) 
                                AND (BASEEVENT.KEY97=EVENTCCY.EVENTKEY) 
                                AND (BASEEVENT.KEY97=EVENTTSTAMPS.EVENTKEY) 
                                AND (BASEEVENT.KEY97=EVENTSHORTNAME.EVENTKEY) 
                                AND (BASEEVENT.KEY97=EVENTSTEP.EVENT_KEY) 
                                AND (EVENTSTEP.KEY97=EVENTSTEPNAMES.STEPKEY) 
                                AND ((EVENTCCY.CCY=CCYDTLS.CCY_CODE (+)) 
                                AND (EVENTCCY.SBB_BRN=CCYDTLS.MBE (+))) 
                                AND RPTMASTERS.EXEMPLAR = PROD.KEY97
                                AND  NOT (PRODSHORTNAME.SOVALUE LIKE 'Fin%' OR PRODSHORTNAME.SOVALUE LIKE 'Lic%' OR PRODSHORTNAME.SOVALUE LIKE 'Ship%')
                                AND (BASEEVENT.CCY=C8PF.C8CCY (+)) 
                                AND (BASEEVENT.CCY = SPOTRATE.currency AND SPOTRATE.branch = 'BMEG')
                                ORDER BY RPTMASTERS.BHALF_BRN, RPTMASTERS.WORKGROUP, RPTMASTERS.MASTER_REF, ALLRLMSTRS.RELMSTRREF, EVENTTSTAMPS.STARTED");
            //ART_TI_ADVANCE_PAYMENT_UTILIZATION_REPORT
            migrationBuilder.Sql($@"
                             CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_ADVANCE_PAYMENT_UTILIZATION_REPORT"" (""BRANCH"", ""ADV_REFERENCE"", ""PRINCIPAL_PARTY"", ""NON_PRINCIPAL_PARTY"", ""CREATION_DATE"", ""EXPIRY_DATE"", ""UTILIZATION_TRN"", ""ADV_AMOUNT"", ""ADV_CURRENCY"", ""UTILIZATION_AMOUNT"", ""UTILIZATION_CURRENCY"", ""OUTSTANDING_AMOUNT"") AS 
                                  SELECT ADVMASTER.BHALF_BRN BRANCH,ADVMASTER.MASTER_REF AS ""ADV_REFERENCE"" ,
                                PARTYDTLS.ADDRESS1 AS PRINCIPAL_PARTY,
                                NON_PRINCIPAL_PARTY.ADDRESS1 AS NON_PRINCIPAL_PARTY,
                                ADVMASTER.CTRCT_DATE CREATION_DATE ,ADVMASTER.EXPIRY_DAT EXPIRY_DATE,
                                TRIM(regexp_replace(regexp_replace(regexp_replace(LCDCMASTER.ORIG_REF, chr(13),''), chr(10) , ''), chr(9) , ''))  UTILIZATION_TRN , EXTMASTERADP.AP_M_AMT ADV_AMOUNT ,EXTMASTERADP.CCY ADV_CURRENCY,
                                EXTMASTERADP.UTLS_AMT UTILIZATION_AMOUNT ,EXTMASTERADP.CCY_4 UTILIZATION_CURRENCY ,
                                (EXTMASTERADP.AP_M_AMT - EXTMASTERADP.UTLS_AMT) OUTSTANDING_AMOUNT
                                FROM TIZONE2.MASTER@TIZONE2_LINK ADVMASTER
                                LEFT JOIN TIZONE2.EXTMASTERADP@TIZONE2_LINK ON ADVMASTER.MASTER_REF = EXTMASTERADP.AP_M_REF
                                LEFT JOIN TIZONE2.MASTER@TIZONE2_LINK LCDCMASTER ON EXTMASTERADP.FK_MASTER = LCDCMASTER.EXTFIELD
                                JOIN TIZONE2.PARTYDTLS@TIZONE2_LINK ON ADVMASTER.PCP_PTY = PARTYDTLS.KEY97
                                left JOIN TIZONE2.PARTYDTLS@TIZONE2_LINK NON_PRINCIPAL_PARTY on ADVMASTER.NPCP_PTY = NON_PRINCIPAL_PARTY.KEY97
                                WHERE ADVMASTER.STATUS = 'LIV' AND ADVMASTER.PRDCLASS = 'C' ");
            //ART_TI_Amortization_Report
            migrationBuilder.Sql($@"
            CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_TI_Amortization_Report"" (""BHALF_BRN"", ""FULLNAME"", ""WORKGROUP"", ""DESCRI56"", ""ADDRESS1"", ""GFCUN"", ""CUS_MNM"", ""SOVALUE"", ""MASTER_REF"", ""EVENT_REF"", ""RELMSTRREF"", ""OUTSTCCY"", ""OUTSTAMT"", ""OUTCCYCED"", ""CHARGE_AMT"", ""END_DAT"", ""START_DAT"", ""FIRSTSTART"", ""CTRCT_DATE"", ""EXPIRY_DAT"", ""ACC_PERIOD"", ""DAILY_ACC"", ""CHGPEXTRADAY"", ""ACCRUE_AMT"", ""CHARGE_CCY"", ""ACCRUE_CCY"", ""ID"", ""DESCR"", ""PERIODIC"", ""C8CED"", ""PERIOD_CHG"") AS 
                              SELECT 
                            ""RPTMASTERS"".""BHALF_BRN"",
                                   ""CAPF"".""FULLNAME"",
                                   ""RPTMASTERS"".""WORKGROUP"",
                                   ""TEAM"".""DESCRI56"",
                                   ""CHG_PARTY"".""ADDRESS1"",
                                   ""CHG_PARTY"".""GFCUN"",
                                   ""CHG_PARTY"".""CUS_MNM"",
                                   ""PRODLONGNAME"".""SOVALUE"",
                                   ""BSCHGSFORRPT"".""MASTER_REF"",
                                   BASEEVENT.REFNO_PFIX || BASEEVENT.REFNO_SERL AS EVENT_REF,
                                    TRIM(regexp_replace(regexp_replace(regexp_replace(""RPTMASTERS"".""RELMSTRREF"", chr(13),''), chr(10) , ''), chr(9) , '')) RELMSTRREF ,
                                   ""MSTROAMT"".""OUTSTCCY"",
                                   ""MSTROAMT"".""OUTSTAMT"",
                                   ""MSTROAMT"".""OUTCCYCED"",
                                   ""PERDCHGACCR"".""CHARGE_AMT"",
                                   ""PERDCHGACCR"".""END_DAT"",
                                   ""PERDCHGACCR"".""START_DAT"",
                                   ""PERDCHGACCR"".""FIRSTSTART"",
                                   RPTMASTERS.CTRCT_DATE,
                                   RPTMASTERS.EXPIRY_DAT,
                                   (""PERDCHGACCR"".""END_DAT"" - ""PERDCHGACCR"".""START_DAT"")AS ACC_PERIOD,
                                   CASE
                                       WHEN (""PERDCHGACCR"".""END_DAT"" - ""PERDCHGACCR"".""START_DAT"" <> 0)
                                            AND (""PERDCHGACCR"".""END_DAT"" >= CURRENT_DATE) THEN ROUND((""PERDCHGACCR"".""ACCRUE_AMT""/(""PERDCHGACCR"".""END_DAT"" - ""PERDCHGACCR"".""START_DAT""))/POWER(10, ""C8PF"".""C8CED""), 2)
                                   END AS DAILY_ACC,
                                   ""PERDCHGACCR"".""CHGPEXTRADAY"",
                                   ""PERDCHGACCR"".""ACCRUE_AMT"",
                                   ""PERDCHGACCR"".""CHARGE_CCY"",
                                   TRIM(regexp_replace(regexp_replace(regexp_replace(""PERDCHGACCR"".""ACCRUE_CCY"", chr(13),''), chr(10) , ''), chr(9) , '')) ACCRUE_CCY,
                                   ""RELTEMPLTE"".""ID"",
                                   ""RELTEMPLTE"".""DESCR"",
                                   ""TRANSCHED"".""PERIODIC"",
                                   ""C8PF"".""C8CED"",
                                   ""PERDCHGACCR"".""PERIOD_CHG""
                            FROM TIZONE2.RPTMASTERS@TIZONE2_LINK ""RPTMASTERS"",
                                 TIZONE2.CAPF@TIZONE2_LINK  ""CAPF"",
                                 TIZONE2.WORKGR44@TIZONE2_LINK  ""TEAM"",
                                 TIZONE2.BSCHGSFORRPT@TIZONE2_LINK  ""BSCHGSFORRPT"",
                                 TIZONE2.MSTROAMT@TIZONE2_LINK  ""MSTROAMT"",
                                 TIZONE2.EXEMPL30@TIZONE2_LINK  ""PRODUCT"",
                                 TIZONE2.RPTPARTIES@TIZONE2_LINK  ""CHG_PARTY"",
                                 TIZONE2.EVENTCHG@TIZONE2_LINK  ""EVENTCHG"",
                                 TIZONE2.RELTEMPLTE@TIZONE2_LINK  ""RELTEMPLTE"",
                                 TIZONE2.TRANSCHEDE@TIZONE2_LINK  ""TRANSCHED"",
                                 TIZONE2.PERDCHGACCR@TIZONE2_LINK  ""PERDCHGACCR"",
                                 TIZONE2.C8PF@TIZONE2_LINK  ""C8PF"",
                                 TIZONE2.PRODLONGNAME@TIZONE2_LINK  ""PRODLONGNAME"",
                                 TIZONE2.BASEEVENT@TIZONE2_LINK 
                            WHERE (""RPTMASTERS"".""BHALF_BRN""=""CAPF"".""CABRNM"")
                              AND (""RPTMASTERS"".""WORKGROUP""=""TEAM"".""CODE79"" (+))
                              AND (""RPTMASTERS"".""KEY97""=""BSCHGSFORRPT"".""MASTERKEY"")
                              AND (""RPTMASTERS"".""KEY97""=""MSTROAMT"".""MASTERKEY"")
                              AND (""BSCHGSFORRPT"".""EXEMPLAR""=""PRODUCT"".""KEY97"")
                              AND (""BSCHGSFORRPT"".""CHG_PTY""=""CHG_PARTY"".""PARTYKEY"")
                              AND (""BSCHGSFORRPT"".""CHGKEY""=""EVENTCHG"".""KEY97"")
                              AND (""BSCHGSFORRPT"".""TEMPLATEKEY""=""RELTEMPLTE"".""KEY97"")
                              AND (""EVENTCHG"".""TCHG_SCH""=""TRANSCHED"".""KEY97"" (+))
                              AND (""EVENTCHG"".""KEY97""=""PERDCHGACCR"".""PERIOD_CHG"" (+))
                              AND (""PERDCHGACCR"".""CHARGE_CCY""=""C8PF"".""C8CCY"")
                              AND (""RPTMASTERS"".""KEY97"" = ""BASEEVENT"".""MASTER_KEY"")
                              AND (""PRODUCT"".""CODE79""=""PRODLONGNAME"".""PRODCODE"" (+))
                              AND ""TRANSCHED"".""PERIODIC""=u'Y'
                              AND ""PERDCHGACCR"".""CHARGE_AMT"" IS NOT  NULL
                            ORDER BY ""RPTMASTERS"".""BHALF_BRN"",
                                     ""RPTMASTERS"".""WORKGROUP""");
            //ART_TI_CHARGES_BY_CUST_REPORT
            migrationBuilder.Sql($@"
            CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_CHARGES_BY_CUST_REPORT"" (""HVBAD1"", ""GFCUN"", ""LONGNAME"", ""MASTER_REF"", ""TOTOAL_PERIODIC_BILLED_CHG_DUE"", ""TOTOAL_BILLED_CHG_DUE"", ""TOTOAL_PAID_CHG_DUE"", ""TOTOAL_CLAIMED_CHG_DUE"", ""TOTOAL_OUTSTANDING_CHG_DUE"", ""TOTOAL_WAIVED_CHG_DUE"") AS 
                              SELECT 
                            CHGSBYPTY.HVBAD1, --Filter For Branch
                            CHGSBYPTY.GFCUN,
                            CHGSBYPTY.LONGNAME, -- Filter For Product
                            CHGSBYPTY.MASTER_REF, --Filter For Reference
                            COALESCE(SUM(CASE WHEN CHGSBYPTY.STATUS = 'G' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END), 0) TOTOAL_PERIODIC_BILLED_CHG_DUE,
                            COALESCE(SUM(CASE WHEN CHGSBYPTY.STATUS = 'D' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END), 0)TOTOAL_BILLED_CHG_DUE,
                            COALESCE(SUM(CASE WHEN CHGSBYPTY.STATUS = 'P' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END), 0) TOTOAL_PAID_CHG_DUE,
                            COALESCE(SUM(CASE WHEN CHGSBYPTY.STATUS = 'C' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END), 0) TOTOAL_CLAIMED_CHG_DUE,
                            COALESCE(SUM(CASE WHEN CHGSBYPTY.STATUS = 'O' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END), 0) TOTOAL_OUTSTANDING_CHG_DUE,
                            COALESCE(SUM(CASE WHEN CHGSBYPTY.STATUS = 'W' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END), 0)TOTOAL_WAIVED_CHG_DUE
                            --CHGSBYPTY.CHG_DUE, 
                            --(CHGSBYPTY.CHG_DUE/ power(10,c8pf.c8ced)) CHG_DUE,
                            --CHGSBYPTY.CHG_CCY, 
                            --((CHGSBYPTY.CHG_DUE/ power(10,c8pf.c8ced))*SPOTRATE.SPOTRATE)AS CHG_DUE_EGP,
                            --CHGSBYPTY.ACTION, 
                            --CHGSBYPTY.REDUCTION, 
                            --CHGSBYPTY.SCH_AMT, 
                            --(CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced)) SCH_AMT,
                            --CHGSBYPTY.SCH_CCY, 
                            --((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE)AS SCH_AMT_EGP,
                            --CHGSBYPTY.SCH_RATE, 
                            --CHGSBYPTY.CHG_CCY_SPT, 
                            --CHGSBYPTY.CHG_CCY_SEI, 
                            --CHGSBYPTY.BILL_STS, 
                            --RELTEMPLTE.DESCR, 
                            --CHGSBYPTY.BHALF_BRN


                            FROM   
                            TIZONE2.CHGSBYPTY@TIZONE2_LINK CHGSBYPTY, 
                            TIZONE2.RELTEMPLTE@TIZONE2_LINK  RELTEMPLTE,
                            TIZONE2.C8PF@TIZONE2_LINK  C8PF,
                            TIZONE2.SPOTRATE@TIZONE2_LINK  ,
                            TIZONE2.SPOTRATE@TIZONE2_LINK  SPOTRATE_SCH 
                            WHERE  
                            (CHGSBYPTY.TEMPLATEKEY=RELTEMPLTE.KEY97) 
                            AND 
                            (CHGSBYPTY.SCH_CCY=C8PF.C8CCY (+))
                            --AND CHGSBYPTY.BILL_STS<>'R'
                            AND (CHGSBYPTY.CHG_CCY = SPOTRATE.currency (+) AND SPOTRATE.branch = 'BMEG' )
                            AND (CHGSBYPTY.SCH_CCY = SPOTRATE_SCH.currency (+) AND SPOTRATE_SCH.branch = 'BMEG' )
                            GROUP BY
                            CHGSBYPTY.HVBAD1, 
                            CHGSBYPTY.GFCUN,
                            CHGSBYPTY.LONGNAME, 
                            CHGSBYPTY.MASTER_REF");
            //ART_TI_CHARGES_BY_MASTER_REPORT
            migrationBuilder.Sql($@"
              CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_CHARGES_BY_MASTER_REPORT"" (""HVBAD1"", ""LONGNAME"", ""MASTER_REF"", ""TOTOAL_PERIODIC_BILLED_CHG_DUE"", ""TOTOAL_BILLED_CHG_DUE"", ""TOTOAL_PAID_CHG_DUE"", ""TOTOAL_CLAIMED_CHG_DUE"", ""TOTOAL_OUTSTANDING_CHG_DUE"", ""TOTOAL_WAIVED_CHG_DUE"") AS 
                                  SELECT 
                                CHGSBYPTY.HVBAD1, --Filter For Branch
                                CHGSBYPTY.LONGNAME, -- Filter For Product
                                CHGSBYPTY.MASTER_REF, --Filter For Reference
                                SUM(CASE WHEN CHGSBYPTY.STATUS = 'G' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END) TOTOAL_PERIODIC_BILLED_CHG_DUE,
                                SUM(CASE WHEN CHGSBYPTY.STATUS = 'D' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END) TOTOAL_BILLED_CHG_DUE,
                                SUM(CASE WHEN CHGSBYPTY.STATUS = 'P' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END) TOTOAL_PAID_CHG_DUE,
                                SUM(CASE WHEN CHGSBYPTY.STATUS = 'C' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END) TOTOAL_CLAIMED_CHG_DUE,
                                SUM(CASE WHEN CHGSBYPTY.STATUS = 'O' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END) TOTOAL_OUTSTANDING_CHG_DUE,
                                SUM(CASE WHEN CHGSBYPTY.STATUS = 'W' THEN ((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE) END) TOTOAL_WAIVED_CHG_DUE
                                --CHGSBYPTY.CHG_DUE, 
                                --(CHGSBYPTY.CHG_DUE/ power(10,c8pf.c8ced)) CHG_DUE,
                                --CHGSBYPTY.CHG_CCY, 
                                --((CHGSBYPTY.CHG_DUE/ power(10,c8pf.c8ced))*SPOTRATE.SPOTRATE)AS CHG_DUE_EGP,
                                --CHGSBYPTY.ACTION, 
                                --CHGSBYPTY.REDUCTION, 
                                --CHGSBYPTY.SCH_AMT, 
                                --(CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced)) SCH_AMT,
                                --CHGSBYPTY.SCH_CCY, 
                                --((CHGSBYPTY.SCH_AMT/ power(10,c8pf.c8ced))*SPOTRATE_SCH.SPOTRATE)AS SCH_AMT_EGP,
                                --CHGSBYPTY.SCH_RATE, 
                                --CHGSBYPTY.CHG_CCY_SPT, 
                                --CHGSBYPTY.CHG_CCY_SEI, 
                                --CHGSBYPTY.BILL_STS, 
                                --RELTEMPLTE.DESCR, 
                                --CHGSBYPTY.BHALF_BRN


                                FROM   
                                TIZONE2.CHGSBYPTY@TIZONE2_LINK CHGSBYPTY, 
                                --TIZONE2.RELTEMPLTE RELTEMPLTE,
                                TIZONE2.C8PF@TIZONE2_LINK  C8PF,
                                TIZONE2.SPOTRATE@TIZONE2_LINK  ,
                                TIZONE2.SPOTRATE@TIZONE2_LINK  SPOTRATE_SCH 
                                WHERE  
                                --(CHGSBYPTY.TEMPLATEKEY=RELTEMPLTE.KEY97) 
                                --AND 
                                (CHGSBYPTY.SCH_CCY=C8PF.C8CCY (+))
                                AND CHGSBYPTY.BILL_STS<>'R'
                                AND (CHGSBYPTY.CHG_CCY = SPOTRATE.currency (+) AND SPOTRATE.branch = 'BMEG' )
                                AND (CHGSBYPTY.SCH_CCY = SPOTRATE_SCH.currency (+) AND SPOTRATE_SCH.branch = 'BMEG' )
                                GROUP BY
                                CHGSBYPTY.HVBAD1, 
                                CHGSBYPTY.LONGNAME, 
                                CHGSBYPTY.MASTER_REF
");
            //ART_TI_CHARGES_DETAILS_REPORT
            migrationBuilder.Sql($@"
            CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_CHARGES_DETAILS_REPORT"" (""MASTER_REF"", ""ADDRESS1"", ""GFCUN"", ""CUS_MNM"", ""SW_BANK"", ""SW_CTR"", ""SW_LOC"", ""SW_BRANCH"", ""EVENT_REF"", ""ACTION"", ""STATUS"", ""CHG_DUE"", ""CHG_CCY"", ""CHG_DUE_EGP"", ""REDUCTION"", ""SCH_AMT"", ""SCH_CCY"", ""SCH_AMT_EGP"", ""SCH_RATE"", ""CHGBAS_AMT"", ""CHGBAS_CCY"", ""CHGBAS_AMT_EGP"", ""TAX_AMT"", ""TAX_CCY"", ""TAX_FOR"", ""PARTIC_CHG"", ""DESCR"", ""REFNO_PFIX1"", ""REFNO_SERL1"", ""START_DATE"", ""START_TIME"", ""LONGNAME"", ""BHALF_BRN"", ""HVBAD1"", ""SCH_CCY_SPT"", ""SCH_CCY_SEI"") AS 
                                      SELECT 
                                    CHGSBYPTY.MASTER_REF, --fILTER FOR REFERENCE
                                    CHGSBYPTY.ADDRESS1, 
                                    CHGSBYPTY.GFCUN, 
                                    CHGSBYPTY.CUS_MNM, 
                                    CHGSBYPTY.SW_BANK, 
                                    CHGSBYPTY.SW_CTR, 
                                    CHGSBYPTY.SW_LOC, 
                                    CHGSBYPTY.SW_BRANCH, 
                                    (OWNINGEVENT.REFNO_PFIX||' '||OWNINGEVENT.REFNO_SERL) Event_Ref,
                                    (case
                                    when CHGSBYPTY.ACTION='W' then 'Waive'
                                    when CHGSBYPTY.ACTION='Y' then 'Defer'
                                    when CHGSBYPTY.ACTION='N' then 'Take'
                                    when CHGSBYPTY.ACTION='C' then 'Claim'
                                    when CHGSBYPTY.ACTION='A' then 'Await reimbursement'
                                    when CHGSBYPTY.ACTION='R' then 'Reimburse'
                                    when CHGSBYPTY.ACTION='B' then 'Bill/Invoice'
                                    when CHGSBYPTY.ACTION='E' then 'Await pay'
                                    when CHGSBYPTY.ACTION='Z' then 'Cancel'
                                    when CHGSBYPTY.ACTION='U' then 'Refund'
                                    when CHGSBYPTY.ACTION='V' then 'Refund periodic'
                                    when CHGSBYPTY.ACTION='M' then 'Partial pay'
                                    when CHGSBYPTY.ACTION='O' then 'Open'
                                    when CHGSBYPTY.ACTION='F' then 'Consolidated'
                                    when CHGSBYPTY.ACTION='S' then 'Split'
                                    when CHGSBYPTY.ACTION='K' then 'Waive and Cancel'
                                    when CHGSBYPTY.ACTION='H' then 'Update schedule'
                                    when CHGSBYPTY.ACTION='T' then 'Partial pay, bill/invoice other party'
                                    when CHGSBYPTY.ACTION='Q' then 'Take, bill/invoice other party'
                                    when CHGSBYPTY.ACTION='I' then 'Partial pay settlement, bill/invoice other party'
                                    end
                                    )ACTION, 
                                    (case
                                    when CHGSBYPTY.STATUS='X' then 'In preparation'
                                    when CHGSBYPTY.STATUS='O' then 'Outstanding'
                                    when CHGSBYPTY.STATUS='P' then 'Paid'
                                    when CHGSBYPTY.STATUS='A' then 'Superseded'
                                    when CHGSBYPTY.STATUS='W' then 'Waived'
                                    when CHGSBYPTY.STATUS='C' then 'Claimed'
                                    when CHGSBYPTY.STATUS='F' then 'Periodic'
                                    when CHGSBYPTY.STATUS='B' then 'Awaiting'
                                    when CHGSBYPTY.STATUS='R' then 'Reimbursement'
                                    when CHGSBYPTY.STATUS='D' then 'Billed'
                                    when CHGSBYPTY.STATUS='G' then 'Periodic billed'
                                    when CHGSBYPTY.STATUS='E' then 'Invoiced'
                                    when CHGSBYPTY.STATUS='H' then 'Periodic invoiced'
                                    when CHGSBYPTY.STATUS='Z' then 'Cancelled'
                                    when CHGSBYPTY.STATUS='U' then 'Refunded'
                                    when CHGSBYPTY.STATUS='V' then 'Refunded periodic'
                                    when CHGSBYPTY.STATUS='a' then 'Superseded (rate)'
                                    when CHGSBYPTY.STATUS='S' then 'Split'
                                    when CHGSBYPTY.STATUS='K' then 'Waived and Cancelled'
                                    end
                                    )STATUS, 
                                    --CHGSBYPTY.CHG_DUE,
                                    (CHGSBYPTY.CHG_DUE/ power(10,C8PF_CHG_DUE.c8ced)) CHG_DUE,
                                    CHGSBYPTY.CHG_CCY, 
                                    ((CHGSBYPTY.CHG_DUE/ power(10,C8PF_CHG_DUE.c8ced))*SPOTRATE_CHG_DUE.SPOTRATE)AS CHG_DUE_EGP,
                                    CHGSBYPTY.REDUCTION, 
                                    --CHGSBYPTY.SCH_AMT, 
                                    (CHGSBYPTY.SCH_AMT/ power(10,C8PF_SCH_AMT.c8ced)) SCH_AMT,
                                    CHGSBYPTY.SCH_CCY, 
                                    ((CHGSBYPTY.SCH_AMT/ power(10,C8PF_SCH_AMT.c8ced))*SPOTRATE_SCH_AMT.SPOTRATE)AS SCH_AMT_EGP,
                                    CHGSBYPTY.SCH_RATE, 
                                    --CHGSBYPTY.CHGBAS_AMT, 
                                    (CHGSBYPTY.CHGBAS_AMT/ power(10,C8PF_SCH_AMT.c8ced)) CHGBAS_AMT,
                                    CHGSBYPTY.CHGBAS_CCY, 
                                    ((CHGSBYPTY.CHGBAS_AMT/ power(10,C8PF_CHGBAS_AMT.c8ced))*SPOTRATE_CHGBAS_AMT.SPOTRATE)AS CHGBAS_AMT_EGP,
                                    CHGSBYPTY.TAX_AMT, 
                                    --(CHGSBYPTY.TAX_AMT/ power(10,C8PF_TAX_AMT.c8ced)) TAX_AMT,
                                    CHGSBYPTY.TAX_CCY, 
                                    --((CHGSBYPTY.TAX_AMT/ power(10,C8PF_TAX_AMT.c8ced))*SPOTRATE_TAX_AMT.SPOTRATE)AS TAX_AMT_EGP,
                                    CHGSBYPTY.TAX_FOR, 
                                    CHGSBYPTY.PARTIC_CHG, 
                                    RELTEMPLTE.DESCR, 
                                    ORIGEVENT.REFNO_PFIX REFNO_PFIX1, 
                                    ORIGEVENT.REFNO_SERL REFNO_SERL1, 
                                    ORIGEVENT.START_DATE, --FILTER FOR DATES
                                    ORIGEVENT.START_TIME, 
                                    CHGSBYPTY.LONGNAME, --FILTER FOR PRODUCT
                                    CHGSBYPTY.BHALF_BRN, 
                                    CHGSBYPTY.HVBAD1, --FILTER FOR BRANCH

                                    CHGSBYPTY.SCH_CCY_SPT, 
                                    CHGSBYPTY.SCH_CCY_SEI

                                    FROM   

                                    TIZONE2.BASEEVENT@TIZONE2_LINK OWNINGEVENT, 
                                    TIZONE2.BASEEVENT@TIZONE2_LINK ORIGEVENT, 
                                    TIZONE2.CHGSBYPTY@TIZONE2_LINK CHGSBYPTY, 
                                    TIZONE2.RELTEMPLTE@TIZONE2_LINK RELTEMPLTE,
                                    TIZONE2.C8PF@TIZONE2_LINK C8PF_CHG_DUE,
                                    TIZONE2.SPOTRATE@TIZONE2_LINK SPOTRATE_CHG_DUE,
                                    TIZONE2.C8PF@TIZONE2_LINK C8PF_SCH_AMT,
                                    TIZONE2.SPOTRATE@TIZONE2_LINK SPOTRATE_SCH_AMT,
                                    TIZONE2.C8PF@TIZONE2_LINK C8PF_CHGBAS_AMT,
                                    TIZONE2.SPOTRATE@TIZONE2_LINK SPOTRATE_CHGBAS_AMT--,
                                    --TIZONE2.C8PF C8PF_TAX_AMT,
                                    --SPOTRATE SPOTRATE_TAX_AMT
                                    WHERE  
                                    (ORIGEVENT.KEY97=CHGSBYPTY.ORIGEV) 
                                    AND (OWNINGEVENT.KEY97=CHGSBYPTY.OWNINGEV) 
                                    AND (CHGSBYPTY.TEMPLATEKEY=RELTEMPLTE.KEY97)
                                    AND (CHGSBYPTY.CHG_CCY=C8PF_CHG_DUE.C8CCY (+))
                                    AND (CHGSBYPTY.CHG_CCY = SPOTRATE_CHG_DUE.currency (+) AND SPOTRATE_CHG_DUE.branch = 'BMEG' )
                                    AND (CHGSBYPTY.SCH_CCY=C8PF_SCH_AMT.C8CCY (+))
                                    AND (CHGSBYPTY.SCH_CCY = SPOTRATE_SCH_AMT.currency (+) AND SPOTRATE_SCH_AMT.branch = 'BMEG' )
                                    AND (CHGSBYPTY.CHGBAS_CCY=C8PF_CHGBAS_AMT.C8CCY (+))
                                    AND (CHGSBYPTY.CHGBAS_CCY = SPOTRATE_CHGBAS_AMT.currency (+) AND SPOTRATE_CHGBAS_AMT.branch = 'BMEG' )
                                    --AND (CHGSBYPTY.TAX_CCY=C8PF_TAX_AMT.C8CCY (+))
                                    --AND (CHGSBYPTY.TAX_CCY = SPOTRATE_TAX_AMT.currency (+) AND SPOTRATE_TAX_AMT.branch = 'BMEG' )
                                    ORDER BY CHGSBYPTY.BHALF_BRN, CHGSBYPTY.LONGNAME, CHGSBYPTY.MASTER_REF");
            //ART_TI_DIARY_EXCEPTIONS_REPORT
            migrationBuilder.Sql($@"
            CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_DIARY_EXCEPTIONS_REPORT"" (""MASTER_REF"", ""PRODUCT"", ""ADDRESS1"", ""STATUS"", ""BRANCH_CODE"", ""BRANCH_NAME"", ""TEAM"", ""CTRCT_DATE"", ""OUTSTAMT"", ""OUTCCYCED"", ""OUTSTCCY"", ""OUTSTAMT_EGP"", ""RELMSTRREF"", ""AMOUNT"", ""CCY"", ""AMOUNT_EGP"", ""CREATED_AT"", ""NOTE_TEXT"", ""REFNO_PFIX"", ""REFNO_SERL"", ""EXPIRY_DAT"", ""CCY_CED"", ""SOVALUEDESC"", ""SOVALUECODE"", ""GFCUN"", ""CUS_MNM"", ""SW_BANK"", ""SW_CTR"", ""SW_LOC"", ""SW_BRANCH"", ""ACTIVE"") AS 
                                  SELECT 

                                RPTMASTERS.MASTER_REF,-- Filter For reference
                                EXEMPL30.longna85 Product, -- Filter For Product
                                PCP_PARTY.ADDRESS1,
                                RPTMASTERS.STATUS,
                                RPTMASTERS.BHALF_BRN Branch_Code, -- Filter For Branch Code 
                                CAPF.FULLNAME Branch_Name, -- Filter For Branch Name 
                                RPTMASTERS.WORKGROUP Team, -- Filter For Team
                                rptmasters.ctrct_date,--Filter for date
                                --MSTROAMT.OUTSTAMT, 
                                (MSTROAMT.OUTSTAMT/ power(10,c8pf.c8ced)) OUTSTAMT,
                                MSTROAMT.OUTCCYCED, 
                                MSTROAMT.OUTSTCCY,
                                ((MSTROAMT.OUTSTAMT/ power(10,c8pf.c8ced))*SPOTRATE.SPOTRATE)AS OUTSTAMT_EGP,
                                RPTMASTERS.RELMSTRREF,
                                --RPTMASTERS.AMOUNT, 
                                (RPTMASTERS.AMOUNT/ power(10,c8pf_RPTMAS.c8ced)) AMOUNT,
                                RPTMASTERS.CCY, 
                                ((RPTMASTERS.AMOUNT/ power(10,c8pf_RPTMAS.c8ced))*SPOTRATE_RPTMAS.SPOTRATE)AS AMOUNT_EGP,
                                NOTE.CREATED_AT,
                                TRIM(regexp_replace(regexp_replace(regexp_replace(NOTE.NOTE_TEXT, chr(13),''), chr(10) , ''), chr(9) , ''))  NOTE_TEXT, 
                                RPTMASTERS.REFNO_PFIX, 
                                RPTMASTERS.REFNO_SERL, 
                                RPTMASTERS.EXPIRY_DAT, 
                                CCYDTLS.CCY_CED, 
                                PRODLONGNAME.SOVALUE SOVALUEDESC, 
                                PRODSHORTNAME.SOVALUE SOVALUECODE, 
                                PCP_PARTY.GFCUN, 
                                PCP_PARTY.CUS_MNM, 
                                PCP_PARTY.SW_BANK, 
                                PCP_PARTY.SW_CTR, 
                                PCP_PARTY.SW_LOC, 
                                PCP_PARTY.SW_BRANCH, 
                                NOTE.ACTIVE
                                FROM   
                                TIZONE2.RPTMASTERS@TIZONE2_LINK RPTMASTERS,
                                TIZONE2.EXEMPL30@TIZONE2_LINK PRODUCT,
                                TIZONE2.CCYDTLS@TIZONE2_LINK CCYDTLS,
                                TIZONE2.CAPF@TIZONE2_LINK CAPF, 
                                TIZONE2.RPTPARTIES@TIZONE2_LINK PCP_PARTY, 
                                TIZONE2.NOTE@TIZONE2_LINK NOTE, 
                                TIZONE2.PRODLONGNAME@TIZONE2_LINK PRODLONGNAME, 
                                TIZONE2.PRODSHORTNAME@TIZONE2_LINK PRODSHORTNAME,
                                TIZONE2.EXEMPL30@TIZONE2_LINK,
                                TIZONE2.MSTROAMT@TIZONE2_LINK MSTROAMT,
                                TIZONE2.C8PF@TIZONE2_LINK C8PF,
                                TIZONE2.SPOTRATE@TIZONE2_LINK ,
                                TIZONE2.C8PF@TIZONE2_LINK C8PF_RPTMAS,
                                TIZONE2.SPOTRATE@TIZONE2_LINK SPOTRATE_RPTMAS

                                WHERE  
                                --RPTMASTERS.MASTER_REF='ELC/MBW/11/0011'
                                --AND
                                (RPTMASTERS.EXEMPLAR=PRODUCT.KEY97) 
                                AND ((RPTMASTERS.SBB_BRN=CCYDTLS.MBE) 
                                AND (RPTMASTERS.CCY=CCYDTLS.CCY_CODE)) 
                                AND (RPTMASTERS.BHALF_BRN=CAPF.CABRNM) 
                                AND (RPTMASTERS.PCP_PTY=PCP_PARTY.PARTYKEY) 
                                AND (RPTMASTERS.KEY97=NOTE.MASTER_KEY) 
                                AND (PRODUCT.CODE79=PRODLONGNAME.PRODCODE (+)) 
                                AND (PRODUCT.CODE79=PRODSHORTNAME.PRODCODE (+)) 
                                AND NOTE.ACTIVE='Y'
                                AND (RPTMASTERS.EXEMPLAR = EXEMPL30.KEY97)
                                AND (RPTMASTERS.KEY97=MSTROAMT.MASTERKEY)
                                AND (MSTROAMT.OUTSTCCY=C8PF.C8CCY (+))
                                AND (MSTROAMT.OUTSTCCY = SPOTRATE.currency (+) AND SPOTRATE.branch = 'BMEG' )
                                AND (RPTMASTERS.CCY=C8PF_RPTMAS.C8CCY (+))
                                AND (RPTMASTERS.CCY = SPOTRATE_RPTMAS.currency (+) AND SPOTRATE_RPTMAS.branch = 'BMEG' )
                                ORDER BY RPTMASTERS.BHALF_BRN");
            //ART_TI_ECM_TRANSACTIONS_REPORT
            migrationBuilder.Sql($@"  
                        CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_ECM_TRANSACTIONS_REPORT"" (""CASE_ID"", ""BEHALFOFBRANCH"", ""CREATE_DATE"", ""APPLICANTNAME"", ""PRODUCT"", ""PRODUCTTYPE"", ""EVENTNAME"", ""TRANSACTION_AMOUNT"", ""TRANSACTION_CURRENCY"", ""PRIMARY_OWNER"", ""CASE_STAT_CD"", ""UPDATE_USER_ID"") AS 
                                          select 
                                        Case_Id,
                                        behalfOfBranch,
                                        Create_Date,
                                        applicantName,
                                        prod.val_desc product,
                                        prodtype.val_desc productType,
                                        event.val_desc eventName,
                                        transaction_amount , 
                                        transaction_currency,
                                        primary_Owner,
                                        Case_Stat_Cd,
                                        a.update_user_id
                                        from
                                        dgcmgmt.case_live@DGDB_DGCMGMT a 
                                        left join dgcmgmt.ref_table_val@DGDB_DGCMGMT prod on a.product=prod.val_cd
                                        left join dgcmgmt.ref_table_val@DGDB_DGCMGMT prodtype on a.producttype=prodtype.val_cd
                                        left join dgcmgmt.ref_table_val@DGDB_DGCMGMT event on a.eventname=event.val_cd");
            //ART_TI_ECM_WORKFLOW_PROG_REPORT
            migrationBuilder.Sql($@"
                          CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_ECM_WORKFLOW_PROG_REPORT"" (""ECM_REFERENCE"", ""ECM_CASE_CREATION_DATE"", ""BRANCH_ID"", ""CUTOMER_NAME"", ""PRODUCT"", ""PRODUCT_TYPE"", ""ECM_EVENT"", ""TRANSACTION_AMOUNT"", ""TRANSACTION_CURRENCY"", ""PRIMARY_OWNER"", ""CASE_STAT_CD"", ""UPDATE_USER_ID"", ""ECM_REJECTION_TYPE"", ""ECM_REJECTION_REASON"", ""FTI_REFERENCE"", ""EVENT_NAME"", ""EVENT_STATUS"", ""EVENT_CREATION_DATE"", ""ASSIGNED_TO"", ""ASSIGNMENT_TYPE"", ""EVENT_STEPS"", ""STEP_STATUS"", ""LSTMODTIME"", ""LSTMODUSER"", ""WARNING_OVERRIDDEN"", ""REJECTION_REASON"", ""SLA_DEADLINE"", ""INPUT_STEP_TIME"", ""INPUT_SLA_STATUS"", ""INPUT_MAX_TIME"", ""EXTERNAL_REVIEW_STEP_TIME"", ""EXTERNAL_REVIEW_SLA_STATUS"", ""REVIEW_STEP_TIME"", ""REVIEW_SLA_STATUS"", ""AUTHORIZE_STEP_TIME"", ""AUTHORIZE_SLA_STATUS"", ""SLA_DASHBOARD_AMBER"", ""SLA_DASHBOARD_RED"", ""SLA_REMAINING_TIME"") AS 
                          select ""ECM_REFERENCE"",""ECM_CASE_CREATION_DATE"",""BRANCH_ID"",""CUTOMER_NAME"",""PRODUCT"",""PRODUCT_TYPE"",""ECM_EVENT"",""TRANSACTION_AMOUNT"",""TRANSACTION_CURRENCY"",""PRIMARY_OWNER"",""CASE_STAT_CD"",""UPDATE_USER_ID"",""ECM_REJECTION_TYPE"",""ECM_REJECTION_REASON"",""FTI_REFERENCE"",""EVENT_NAME"",""EVENT_STATUS"",""EVENT_CREATION_DATE"",""ASSIGNED_TO"",""ASSIGNMENT_TYPE"",""EVENT_STEPS"",""STEP_STATUS"",""LSTMODTIME"",""LSTMODUSER"",""WARNING_OVERRIDDEN"",""REJECTION_REASON"",""SLA_DEADLINE"",""INPUT_STEP_TIME"",""INPUT_SLA_STATUS"",""INPUT_MAX_TIME"",""EXTERNAL_REVIEW_STEP_TIME"",""EXTERNAL_REVIEW_SLA_STATUS"",""REVIEW_STEP_TIME"",""REVIEW_SLA_STATUS"",""AUTHORIZE_STEP_TIME"",""AUTHORIZE_SLA_STATUS"",""SLA_DASHBOARD_AMBER"",""SLA_DASHBOARD_RED"",""SLA_REMAINING_TIME"" from 
                        TIZONE2.ART_TI_ECM_WORKFLOW_PROG_REPORT@TIZONE2_LINK

                    ") ;
            //ART_TI_ECM_WORKFLOW_PROG_REPORT_OLD
            migrationBuilder.Sql($@"
                           CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_ECM_WORKFLOW_PROG_REPORT_OLD"" (""ECM_REFERENCE"", ""ECM_CASE_CREATION_DATE"", ""BRANCH_ID"", ""CUTOMER_NAME"", ""PRODUCT"", ""PRODUCT_TYPE"", ""ECM_EVENT"", ""TRANSACTION_AMOUNT"", ""TRANSACTION_CURRENCY"", ""PRIMARY_OWNER"", ""CASE_STAT_CD"", ""UPDATE_USER_ID"", ""COMMENTS"", ""ECM_REJECTION_TYPE"", ""ECM_REJECTION_REASON"", ""FTI_REFERENCE"", ""EVENT_NAME"", ""EVENT_STATUS"", ""EVENT_CREATION_DATE"", ""ASSIGNED_TO"", ""ASSIGNMENT_TYPE"", ""EVENT_STEPS"", ""STEP_STATUS"", ""LSTMODTIME"", ""LSTMODUSER"", ""WARNING_OVERRIDDEN"", ""REJECTION_REASON"", ""SLA_DEADLINE"", ""INPUT_STEP_TIME"", ""INPUT_SLA_STATUS"", ""INPUT_MAX_TIME"", ""EXTERNAL_REVIEW_STEP_TIME"", ""EXTERNAL_REVIEW_SLA_STATUS"", ""REVIEW_STEP_TIME"", ""REVIEW_SLA_STATUS"", ""AUTHORIZE_STEP_TIME"", ""AUTHORIZE_SLA_STATUS"", ""SLA_DASHBOARD_AMBER"", ""SLA_DASHBOARD_RED"", ""SLA_REMAINING_TIME"", ""NOTE"", ""NOTE_CREATION_TIME"") AS 
                              select ""ECM_REFERENCE"",""ECM_CASE_CREATION_DATE"",""BRANCH_ID"",""CUTOMER_NAME"",""PRODUCT"",""PRODUCT_TYPE"",""ECM_EVENT"",""TRANSACTION_AMOUNT"",""TRANSACTION_CURRENCY"",""PRIMARY_OWNER"",""CASE_STAT_CD"",""UPDATE_USER_ID"",""COMMENTS"",""ECM_REJECTION_TYPE"",""ECM_REJECTION_REASON"",""FTI_REFERENCE"",""EVENT_NAME"",""EVENT_STATUS"",""EVENT_CREATION_DATE"",""ASSIGNED_TO"",""ASSIGNMENT_TYPE"",""EVENT_STEPS"",""STEP_STATUS"",""LSTMODTIME"",""LSTMODUSER"",""WARNING_OVERRIDDEN"",""REJECTION_REASON"",""SLA_DEADLINE"",""INPUT_STEP_TIME"",""INPUT_SLA_STATUS"",""INPUT_MAX_TIME"",""EXTERNAL_REVIEW_STEP_TIME"",""EXTERNAL_REVIEW_SLA_STATUS"",""REVIEW_STEP_TIME"",""REVIEW_SLA_STATUS"",""AUTHORIZE_STEP_TIME"",""AUTHORIZE_SLA_STATUS"",""SLA_DASHBOARD_AMBER"",""SLA_DASHBOARD_RED"",""SLA_REMAINING_TIME"",""NOTE"",""NOTE_CREATION_TIME"" from 
                            TIZONE2.ART_TI_ECM_WORKFLOW_PROG_REPORT_OLD@TIZONE2_LINK
                    ");
            //ART_TI_FINAN_INTER_ACCRUALS
            migrationBuilder.Sql($@"
            CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_FINAN_INTER_ACCRUALS"" (""BRANCH_NAME"", ""MASTER_REF"", ""STARTDATE"", ""MATURITY"", ""PRODCUT"", ""AMT_O_S"", ""RECCCY"", ""AMT_O_S_EGP"", ""INTTYPEID"", ""CALCDTE"", ""EARLY_DATE"", ""RECAMT_PD"", ""RECCCY_PD"", ""RECAMT_PD_EGP"", ""ADDRESS1"", ""GFCUN"", ""CUS_MNM"", ""SW_BANK"", ""SW_CTR"", ""SW_LOC"", ""SW_BRANCH"", ""RECAMT"", ""DEAL_CCY"", ""INTP_AMT"", ""INTP_CCY"", ""INTP_AMT_EGP"", ""CYCLEEND"", ""PASTDUEDTE"", ""EXTRADAY"", ""RATE_TYPE"", ""PARTPN_REF"", ""PTNSHARE"", ""PRODTYPENAME"", ""IDB"", ""INTPERUNIT"", ""INTPERNUM"", ""INTPERDAY"", ""CCY_SPT"", ""CCY_SEI"", ""BHALF_BRN"", ""SOVALUE"", ""CCY_CED"", ""CALCDTE_PD"", ""CALCRATE"", ""ACTUALRATE"", ""PRODTYPEDESC"", ""BASE_RATE2"", ""DIFF_RATE2"", ""GROUP_RATE2"", ""BALANC_AMT"", ""SPLIT_TIER"", ""TIER_NUM"", ""TIER_AMT"", ""PEDORAMT"", ""TIER_PNUM"", ""TIER_PUNIT"", ""TIER_BASE"", ""TIER_DIFF"", ""TIER_SPRD"", ""GROUP_CODE"", ""SCHRATETYPE"", ""CALCRATE1"", ""INTERP"", ""INTERPRATE"", ""COMMITAMT"", ""AMT_OR_PCT"", ""INTEREST_RATE_TYPE"") AS 
                                  SELECT 
                                CAPF.FULLNAME Branch_Name, --Filter For Branch
                                RPTMASTERS.MASTER_REF, -- Filter For Reference
                                FINACCRUALDTLS.STARTDATE, -- date filter as main filter
                                FINACCRUALDTLS.MATURITY, -- another date filter
                                product.longna85 PRODCUT, --Filter For Product
                                --RPTMASTERS.AMT_O_S,
                                (RPTMASTERS.AMT_O_S/ power(10,C8PFOS.c8ced)) AMT_O_S,
                                TRIM(regexp_replace(regexp_replace(regexp_replace(FINACCRUALDTLS.RECCCY, chr(13),''), chr(10) , ''), chr(9) , ''))  RECCCY, 
                                ((RPTMASTERS.AMT_O_S/ power(10,C8PFOS.c8ced))*SPOTRATEOS.SPOTRATE)AS AMT_O_S_EGP,
                                FINACCRUALDTLS.INTTYPEID, 
                                FINACCRUALDTLS.CALCDTE, 
                                FINACCRUALDTLS.EARLY_DATE, 
                                --FINACCRUALDTLS.RECAMT_PD, 
                                (FINACCRUALDTLS.RECAMT_PD/ power(10,c8pf.c8ced)) RECAMT_PD,
                                FINACCRUALDTLS.RECCCY_PD, 
                                ((FINACCRUALDTLS.RECAMT_PD/ power(10,c8pf.c8ced))*SPOTRATE.SPOTRATE)AS RECAMT_PD_EGP,
                                RPTPARTIES.ADDRESS1, 
                                RPTPARTIES.GFCUN, --Filter Customer Full Name (Princibal)
                                RPTPARTIES.CUS_MNM, --Filter Customer Short Name (Princibal)
                                RPTPARTIES.SW_BANK, 
                                RPTPARTIES.SW_CTR, 
                                RPTPARTIES.SW_LOC, 
                                RPTPARTIES.SW_BRANCH, 
                                FINACCRUALDTLS.RECAMT, 
                                FINACCRUALDTLS.DEAL_CCY, 
                                --FINACCRUALDTLS.INTP_AMT, 
                                (FINACCRUALDTLS.INTP_AMT/ power(10,c8pfINTP.c8ced)) INTP_AMT,
                                FINACCRUALDTLS.INTP_CCY, 
                                ((FINACCRUALDTLS.INTP_AMT/ power(10,c8pfINTP.c8ced))*SPOTRATEINTP.SPOTRATE)AS INTP_AMT_EGP,
                                FINACCRUALDTLS.CYCLEEND, 
                                FINACCRUALDTLS.PASTDUEDTE, 
                                FINACCRUALDTLS.EXTRADAY, 
                                FINACCRUALDTLS.RATE_TYPE, 
                                ATTACHPARTN.PARTPN_REF, 
                                PTPPERCENT.PTNSHARE, 
                                FINACCRUALDTLS.PRODTYPENAME, --Filter For Product Type from PRODTYPE table
                                FINACCRUALDTLS.IDB, 
                                FINACCRUALDTLS.INTPERUNIT, 
                                FINACCRUALDTLS.INTPERNUM, 
                                FINACCRUALDTLS.INTPERDAY, 
                                FINACCRUALDTLS.CCY_SPT, 
                                FINACCRUALDTLS.CCY_SEI, 
                                RPTMASTERS.BHALF_BRN, 
                                PRODLONGNAME.SOVALUE, 
                                MSTRCCYDTLS.CCY_CED, 
                                FINACCRUALDTLS.CALCDTE_PD, 
                                FINACCRUALDTLS.CALCRATE, 
                                FINACCRUALDTLS.ACTUALRATE, 
                                FINACCRUALDTLS.PRODTYPEDESC, 
                                FINACCRUALDTLS.BASE_RATE2, 
                                FINACCRUALDTLS.DIFF_RATE2, 
                                FINACCRUALDTLS.GROUP_RATE2, 
                                FINACCRUALDTLS.BALANC_AMT, 
                                FINACCRUALDTLS.SPLIT_TIER, 
                                FINTIERRATE.TIER_NUM, 
                                FINTIERRATE.TIER_AMT, 
                                FINACCRUALDTLS.PEDORAMT, 
                                FINTIERRATE.TIER_PNUM, 
                                FINTIERRATE.TIER_PUNIT, 
                                FINTIERRATE.TIER_BASE, 
                                FINTIERRATE.TIER_DIFF, 
                                FINTIERRATE.TIER_SPRD, 
                                FINTIERRATE.GROUP_CODE, 
                                FINACCRUALDTLS.SCHRATETYPE, 
                                FINTIERRATE.CALCRATE CALCRATE1, 
                                FINACCRUALDTLS.INTERP, 
                                FINACCRUALDTLS.INTERPRATE, 
                                PTPPERCENT.COMMITAMT, 
                                PTPPERCENT.AMT_OR_PCT,
                                --(FINACCRUALDTLS.INT_TYPE||' '||FINTIERRATE.TIER_RATE) Interest_Rate_Type
                                ((case when INT_TYPE ='S' then 'Interest in advance - standard' 
                                when INT_TYPE ='E' then 'Interest in arrears - standard'
                                when INT_TYPE ='D' then 'Interest in advance - discount'
                                when INT_TYPE ='Y' then 'Interest in advance - discount to yield'
                                when INT_TYPE ='I' then 'Interest in advance - interest to yield'
                                end)||' '||FINTIERRATE.TIER_RATE) Interest_Rate_Type
                                from 
                                TIZONE2.RPTMASTERS@TIZONE2_LINK RPTMASTERS inner join
                                TIZONE2.FINACCRUALDTLS@TIZONE2_LINK FINACCRUALDTLS on RPTMASTERS.KEY97=FINACCRUALDTLS.MASTERKEY inner join
                                TIZONE2.EXEMPL30@TIZONE2_LINK PRODUCT on RPTMASTERS.EXEMPLAR=PRODUCT.KEY97 inner join
                                TIZONE2.CAPF@TIZONE2_LINK CAPF on RPTMASTERS.BHALF_BRN=CAPF.CABRNM inner join
                                TIZONE2.CCYDTLS@TIZONE2_LINK MSTRCCYDTLS on  RPTMASTERS.CCY=MSTRCCYDTLS.CCY_CODE AND RPTMASTERS.SBB_BRN=MSTRCCYDTLS.MBE inner join
                                TIZONE2.RPTPARTIES@TIZONE2_LINK RPTPARTIES on  FINACCRUALDTLS.DEBITPARTY=RPTPARTIES.PARTYKEY left join
                                TIZONE2.ATTACHPARTN@TIZONE2_LINK ATTACHPARTN on FINACCRUALDTLS.PTPDEALKEY=ATTACHPARTN.PTNDTLSKEY left join
                                TIZONE2.FINTIERRATE@TIZONE2_LINK FINTIERRATE on FINACCRUALDTLS.MASTERKEY=FINTIERRATE.MASTERKEY left join
                                TIZONE2.PTPPERCENT@TIZONE2_LINK PTPPERCENT on ATTACHPARTN.PTNDTLSKEY=PTPPERCENT.PTNDTLSKEY inner join
                                TIZONE2.PRODLONGNAME@TIZONE2_LINK PRODLONGNAME on PRODUCT.CODE79=PRODLONGNAME.PRODCODE left join
                                TIZONE2.C8PF@TIZONE2_LINK C8PF on FINACCRUALDTLS.RECCCY_PD=C8PF.C8CCY left join
                                TIZONE2.SPOTRATE@TIZONE2_LINK on FINACCRUALDTLS.RECCCY_PD = SPOTRATE.currency  AND SPOTRATE.branch = 'BMEG' left join
                                TIZONE2.C8PF@TIZONE2_LINK c8pfINTP on FINACCRUALDTLS.INTP_CCY=c8pfINTP.C8CCY left join
                                TIZONE2.SPOTRATE@TIZONE2_LINK SPOTRATEINTP on FINACCRUALDTLS.INTP_CCY = SPOTRATEINTP.currency  AND SPOTRATEINTP.branch = 'BMEG' left join
                                TIZONE2.C8PF@TIZONE2_LINK C8PFOS on FINACCRUALDTLS.RECCCY=C8PFOS.C8CCY left join
                                TIZONE2.SPOTRATE@TIZONE2_LINK SPOTRATEOS on FINACCRUALDTLS.RECCCY = SPOTRATEOS.currency AND SPOTRATEOS.branch = 'BMEG' 
                                ORDER BY 
                                RPTMASTERS.BHALF_BRN, 
                                PRODLONGNAME.SOVALUE, 
                                FINACCRUALDTLS.PRODTYPENAME,
                                FINACCRUALDTLS.DEAL_CCY, 
                                RPTMASTERS.MASTER_REF, 
                                FINTIERRATE.TIER_NUM");
            //ART_TI_FULL_JOURNAL_REPORT
            migrationBuilder.Sql($@" CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_FULL_JOURNAL_REPORT"" (""DATAITEM"", ""USERNAME"", ""MTCE_TYPE"", ""MCMTCETYPE"", ""MCUSERNAME"", ""AREA_CODE"", ""AREA"", ""JKEY"", ""DATETIME"", ""MCOWNER"", ""ENTRYTIMEUTC"", ""MCACTION"", ""MCNOTE"", ""DATA_AFTER"", ""DATABEFORE"") AS 
                                      select ""DATAITEM"",""USERNAME"",""MTCE_TYPE"",""MCMTCETYPE"",""MCUSERNAME"",""AREA_CODE"",""AREA"",""JKEY"",""DATETIME"",""MCOWNER"",""ENTRYTIMEUTC"",""MCACTION"",""MCNOTE"",""DATA_AFTER"",""DATABEFORE"" from 
                                    TIZONE2.ART_TI_FULL_JOURNAL_REPORT@TIZONE2_LINK");
            //ART_TI_INTERFACE_DETAILS_REPORT
            migrationBuilder.Sql($@"
             CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_INTERFACE_DETAILS_REPORT"" (""TRANID"", ""GZH97NANMD"", ""GZH97NACC"", ""GZH97NBOACC"", ""TRFILE"", ""GZH97NACT"", ""GZH97NCA2"", ""GZH97NEAN1"", ""GZBRNM"", ""GZH97NACTC"", ""GZCUS1"", ""GZH97NCTP1"", ""GZDLP"", ""GZH97NEAN2"", ""GZG461TPRD"", ""GZG461PCCY"", ""GZG461EXT"", ""GZG461TSLD"", ""GZG331PURD"", ""GZG331PCCY"", ""GZG331EXT"", ""GZG331SLED"", ""GZG331PSD1"", ""GZH97NRECN"", ""GZG461PSD1"", ""GZ361MDT"", ""TRETXT"", ""USER_CODES"", ""GZ361RAT"", ""GZ361SDT"", ""GZH97NNR1"", ""GZH97NNR2"", ""GZH97NNR3"", ""GZH97NNR4"", ""GZ361NCD"", ""GZG891DTE"", ""GZG891ACC"", ""GZG891CCY"", ""TRTYPE"", ""REFERENCE"", ""GZG331SCCY"", ""GZG461SCCY"", ""GZG461TSAM"", ""GZG461SCED"", ""GZG331SAM"", ""GZG331SCED"", ""TRSEQ"", ""TRSTAT"", ""GZH97NUC1"", ""GZH97NUC2"", ""GZH97NSRC"", ""USER_OPTIONS"", ""GZH97NPC"", ""GZH97NTCD"", ""VALUE_DATE"", ""GZ361D1F"", ""GZAMT"", ""GZCCY"", ""GZAMT_EGP"", ""GZG361CED"", ""GZG331PAM"", ""GZG331PCED"", ""GZG891CED"", ""GZH97NCED"", ""GZG461TPAM"", ""GZG461PCED"", ""GZH97NNEGP"") AS 
                              SELECT 
                            INTERFACEDETAILS.TRANID, 
                            INTERFACEDETAILS.GZH97NANMD, 
                            INTERFACEDETAILS.GZH97NACC, 
                            INTERFACEDETAILS.GZH97NBOACC, 
                            INTERFACEDETAILS.TRFILE, 
                            INTERFACEDETAILS.GZH97NACT, 
                            INTERFACEDETAILS.GZH97NCA2, 
                            INTERFACEDETAILS.GZH97NEAN1, 
                            INTERFACEDETAILS.GZBRNM, 
                            INTERFACEDETAILS.GZH97NACTC, 
                            INTERFACEDETAILS.GZCUS1, 
                            INTERFACEDETAILS.GZH97NCTP1, 
                            INTERFACEDETAILS.GZDLP, 
                            INTERFACEDETAILS.GZH97NEAN2, 
                            INTERFACEDETAILS.GZG461TPRD, 
                            INTERFACEDETAILS.GZG461PCCY, 
                            INTERFACEDETAILS.GZG461EXT, 
                            INTERFACEDETAILS.GZG461TSLD, 
                            INTERFACEDETAILS.GZG331PURD, 
                            INTERFACEDETAILS.GZG331PCCY, 
                            INTERFACEDETAILS.GZG331EXT, 
                            INTERFACEDETAILS.GZG331SLED, 
                            INTERFACEDETAILS.GZG331PSD1, 
                            INTERFACEDETAILS.GZH97NRECN, 
                            INTERFACEDETAILS.GZG461PSD1, 
                            INTERFACEDETAILS.GZ361MDT, 
                            INTERFACEDETAILS.TRETXT, 
                            (INTERFACEDETAILS.GZH97NUDF1||' '||INTERFACEDETAILS.GZH97NUDF2||' '||INTERFACEDETAILS.GZH97NUDF3) User_Codes,
                            INTERFACEDETAILS.GZ361RAT, 
                            INTERFACEDETAILS.GZ361SDT, 
                            INTERFACEDETAILS.GZH97NNR1, 
                            INTERFACEDETAILS.GZH97NNR2, 
                            INTERFACEDETAILS.GZH97NNR3, 
                            INTERFACEDETAILS.GZH97NNR4, 
                            INTERFACEDETAILS.GZ361NCD, 
                            INTERFACEDETAILS.GZG891DTE, 
                            INTERFACEDETAILS.GZG891ACC, 
                            INTERFACEDETAILS.GZG891CCY, 
                            INTERFACEDETAILS.TRTYPE, 
                            (INTERFACEDETAILS.GZDLR ||' '||INTERFACEDETAILS.GZH97NEVTREF) Reference, 
                            INTERFACEDETAILS.GZG331SCCY, 
                            INTERFACEDETAILS.GZG461SCCY, 
                            INTERFACEDETAILS.GZG461TSAM, 
                            INTERFACEDETAILS.GZG461SCED, 
                            INTERFACEDETAILS.GZG331SAM, 
                            INTERFACEDETAILS.GZG331SCED, 
                            INTERFACEDETAILS.TRSEQ, 
                            INTERFACEDETAILS.TRSTAT, 
                            INTERFACEDETAILS.GZH97NUC1, 
                            INTERFACEDETAILS.GZH97NUC2, 
                            INTERFACEDETAILS.GZH97NSRC, 
                            (INTERFACEDETAILS.GZH97NUDF4||' '||INTERFACEDETAILS.GZH97NUDF5) User_Options,
                            INTERFACEDETAILS.GZH97NPC, 
                            INTERFACEDETAILS.GZH97NTCD, 
                            to_date(to_char(to_date(Substr(INTERFACEDETAILS.GZH97NDTE,2,LENGTH(INTERFACEDETAILS.GZH97NDTE)), 'yymmdd'), 'dd-mm-yyyy'),'dd-mm-yyyy') Value_Date,
                            INTERFACEDETAILS.GZ361D1F, 
                            --INTERFACEDETAILS.GZAMT, 
                            (INTERFACEDETAILS.GZAMT/ power(10,c8pf.c8ced)) GZAMT,
                            INTERFACEDETAILS.GZCCY, 
                            ((INTERFACEDETAILS.GZAMT/ power(10,c8pf.c8ced))*SPOTRATE.SPOTRATE)AS GZAMT_EGP,
                            INTERFACEDETAILS.GZG361CED, 
                            INTERFACEDETAILS.GZG331PAM, 
                            INTERFACEDETAILS.GZG331PCED, 
                            INTERFACEDETAILS.GZG891CED, 
                            INTERFACEDETAILS.GZH97NCED, 
                            INTERFACEDETAILS.GZG461TPAM, 
                            INTERFACEDETAILS.GZG461PCED, 
                            INTERFACEDETAILS.GZH97NNEGP
                            FROM   
                            TIZONE2.INTERFACEDETAILS@TIZONE2_LINK INTERFACEDETAILS LEFT JOIN 
                            TIZONE2.C8PF@TIZONE2_LINK C8PF ON INTERFACEDETAILS.GZCCY=C8PF.C8CCY LEFT JOIN 
                            TIZONE2.SPOTRATE@TIZONE2_LINK ON (INTERFACEDETAILS.GZCCY = SPOTRATE.currency AND SPOTRATE.branch = 'BMEG')
                             ORDER BY INTERFACEDETAILS.TRANID, INTERFACEDETAILS.TRSEQ");
            //ART_TI_MASTER_EVENT_HISTORY
            migrationBuilder.Sql($@"
            CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_MASTER_EVENT_HISTORY"" (""EVENT_REF"", ""MASTER_REF"", ""PRODUCT"", ""ADDRESS1"", ""STATUS"", ""OUTSTAMT"", ""OUTSTCCY"", ""OUTSTAMT_EGP"", ""EXPIRY_DAT"", ""BOOKOFFDAT"", ""DEACT_DATE"", ""STARTED_FILTER"", ""STARTED"", ""CROSS_REF"", ""AMOUNT"", ""CCY"", ""AMOUNT_EGP"", ""STATUS_EV"", ""SHORTNAME"", ""STEPDESCR"", ""STEP_STATUS"", ""BRANCH_CODE"", ""BRANCH_NAME"", ""GFCUN"", ""CUS_MNM"", ""SW_BANK"", ""SW_CTR"", ""SW_LOC"", ""SW_BRANCH"", ""TEAM"", ""EXTRAINFO"", ""LANGUAGE"", ""ISFINISHED"", ""STEPKEY"") AS 
                                      SELECT 
                                    (trim(BASEEVENT.REFNO_PFIX)||' '||trim(BASEEVENT.REFNO_SERL)) Event_Ref,
                                    RPTMASTERS.MASTER_REF,-- Filter For reference
                                    EXEMPL30.longna85 Product, -- Filter For Product
                                    PCP_PARTY.ADDRESS1, 
                                    RPTMASTERS.STATUS, -- Filter For Status
                                    --MSTROAMT.OUTSTAMT,
                                    (MSTROAMT.OUTSTAMT/ power(10,C8PFOUT.c8ced)) OUTSTAMT,
                                    MSTROAMT.OUTSTCCY, 
                                    ((MSTROAMT.OUTSTAMT/ power(10,C8PFOUT.c8ced))*SPOTRATEOUT.SPOTRATE)AS OUTSTAMT_EGP,
                                    --MSTROAMT.OUTCCYCED, 
                                    RPTMASTERS.EXPIRY_DAT, 
                                    RPTMASTERS.BOOKOFFDAT, 
                                    RPTMASTERS.DEACT_DATE, 
                                    (to_date(substr(EVENTTSTAMPS.STARTED, 1, instr(EVENTTSTAMPS.STARTED, '-', 1, 3)-1),'yyyy-mm-dd'))STARTED_Filter,--Filter for start & end dates
                                    EVENTTSTAMPS.STARTED, 
                                    BASEEVENT.CROSS_REF, 
                                    --BASEEVENT.AMOUNT, 
                                    (BASEEVENT.AMOUNT/ power(10,C8PFBASE.c8ced)) AMOUNT,
                                    TRIM(regexp_replace(regexp_replace(regexp_replace(BASEEVENT.CCY, chr(13),''), chr(10) , ''), chr(9) , ''))  CCY, 
                                    ((BASEEVENT.AMOUNT/ power(10,C8PFBASE.c8ced))*SPOTRATEBASE.SPOTRATE)AS AMOUNT_EGP,
                                    BASEEVENT.STATUS_EV, 
                                    EVENTSHORTNAME.SHORTNAME, 
                                    EVENTSTEPNAMES.STEPDESCR, 
                                    stepst.stdesc Step_Status,
                                    RPTMASTERS.BHALF_BRN Branch_Code, -- Filter For Branch Code 
                                    --CCYDTLS.CCY_CED, 
                                    --BASEEVENT.STATUS,
                                    CAPF.FULLNAME Branch_Name, -- Filter For Branch Name 
                                    PCP_PARTY.GFCUN, 
                                    PCP_PARTY.CUS_MNM, 
                                    PCP_PARTY.SW_BANK, 
                                    PCP_PARTY.SW_CTR, 
                                    PCP_PARTY.SW_LOC, 
                                    PCP_PARTY.SW_BRANCH,
                                    RPTMASTERS.workgroup Team, -- Filter For Team
                                    BASEEVENT.EXTRAINFO, 
                                    EVENTSHORTNAME.LANGUAGE, 
                                    --EVENTSTEP.STATUS, 

                                    EVENTSTEP.ISFINISHED, 
                                    EVENTSTEPNAMES.STEPKEY
                                     FROM   
                                     TIZONE2.RPTMASTERS@TIZONE2_LINK RPTMASTERS inner join TIZONE2.BASEEVENT@TIZONE2_LINK  BASEEVENT on RPTMASTERS.KEY97=BASEEVENT.MASTER_KEY
                                     inner join TIZONE2.MSTROAMT@TIZONE2_LINK  MSTROAMT on RPTMASTERS.KEY97=MSTROAMT.MASTERKEY
                                     inner join TIZONE2.RPTPARTIES@TIZONE2_LINK  PCP_PARTY on RPTMASTERS.PCP_PTY=PCP_PARTY.PARTYKEY 
                                     inner join TIZONE2.CAPF@TIZONE2_LINK  CAPF on RPTMASTERS.BHALF_BRN=CAPF.CABRNM
                                     inner join TIZONE2.EVENTTSTAMPS@TIZONE2_LINK  EVENTTSTAMPS on BASEEVENT.KEY97=EVENTTSTAMPS.EVENTKEY 
                                     inner join TIZONE2.EVENTCCY@TIZONE2_LINK  EVENTCCY on BASEEVENT.KEY97=EVENTCCY.EVENTKEY
                                     inner join TIZONE2.EVENTSHORTNAME@TIZONE2_LINK  EVENTSHORTNAME on BASEEVENT.KEY97=EVENTSHORTNAME.EVENTKEY
                                     inner join TIZONE2.EVENTSTEP@TIZONE2_LINK  EVENTSTEP on BASEEVENT.KEY97=EVENTSTEP.EVENT_KEY
                                     inner join TIZONE2.EVENTSTEPNAMES@TIZONE2_LINK  EVENTSTEPNAMES on EVENTSTEP.KEY97=EVENTSTEPNAMES.STEPKEY
                                     left join TIZONE2.CCYDTLS@TIZONE2_LINK  CCYDTLS on EVENTCCY.SBB_BRN=CCYDTLS.MBE and EVENTCCY.CCY=CCYDTLS.CCY_CODE and EVENTSTEP.ISFINISHED='Y'
                                     inner join TIZONE2.EXEMPL30@TIZONE2_LINK  on RPTMASTERS.EXEMPLAR = EXEMPL30.KEY97
                                     left join TIZONE2.ART_EVENT_STEP_STATUS@TIZONE2_LINK  stepst on EVENTSTEP.STATUS = stepst.stcode LEFT JOIN 
                                     TIZONE2.C8PF@TIZONE2_LINK  C8PFOUT ON MSTROAMT.OUTSTCCY=C8PFOUT.C8CCY LEFT JOIN 
                                     TIZONE2.SPOTRATE@TIZONE2_LINK  SPOTRATEOUT ON (MSTROAMT.OUTSTCCY = SPOTRATEOUT.currency AND SPOTRATEOUT.branch = 'BMEG') LEFT JOIN 
                                     TIZONE2.C8PF@TIZONE2_LINK  C8PFBASE ON BASEEVENT.CCY=C8PFBASE.C8CCY LEFT JOIN 
                                     TIZONE2.SPOTRATE@TIZONE2_LINK  SPOTRATEBASE ON (BASEEVENT.CCY = SPOTRATEBASE.currency AND SPOTRATEBASE.branch = 'BMEG')
                                    -- WHERE  
                                    --
                                    --rptmasters.master_ref='ILC/MBW/12/0093 '
                                    ORDER BY RPTMASTERS.BHALF_BRN, RPTMASTERS.MASTER_REF");
            //ART_TI_MASTEVEHIST_PROD_FILTER
            migrationBuilder.Sql($@"
            CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_MASTEVEHIST_PROD_FILTER"" (""PRODUCT"") AS 
             select distinct product from TIZONE2.art_ti_master_event_history@TIZONE2_LINK");
            //ART_TI_MASTEVEHIST_STATUS_FILTER
            migrationBuilder.Sql($@"
             CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_MASTEVEHIST_STATUS_FILTER"" (""STATUS"") AS 
             select distinct status from TIZONE2.art_ti_master_event_history@TIZONE2_LINK");
            //ART_TI_OS_ACTIVITY_REPORT
            migrationBuilder.Sql($@"
           CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_OS_ACTIVITY_REPORT"" (""BRANCH_NAME"", ""TEAM"", ""MASTER_REF"", ""PRODUCT"", ""DESCRIP"", ""ADDRESS1"", ""AMOUNT"", ""CCY"", ""AMOUNT_EGP"") AS 
            
              SELECT
            CAPF.FULLNAME Branch_Name, --For Branch Name Filter
            TEAM.DESCRI56 Team,
            RPTMASTERS.MASTER_REF, --For Reference Filter
            PRODLONGNAME.SOVALUE Product, --For Product Filter
            PRODTYPE.DESCRIP,
            PCP_PARTY.ADDRESS1,
            (RPTMASTERS.AMOUNT / power(10, c8pf.c8ced)) AMOUNT,
            RPTMASTERS.CCY,
            ((RPTMASTERS.AMOUNT / power(10, c8pf.c8ced)) * SPOTRATE.SPOTRATE)AS AMOUNT_EGP
            --RPTMASTERS.WORKGROUP Team, --For Team Filter

            --PCP_PARTY.GFCUN,
            --PCP_PARTY.CUS_MNM,
            --PCP_PARTY.SW_BANK,
            --PCP_PARTY.SW_CTR,
            --PCP_PARTY.SW_LOC,
            --PCP_PARTY.SW_BRANCH,
            --MSTRCCYDTLS.CCY_SPT,
            --MSTRCCYDTLS.CCY_SEI,
            ----RPTMASTERS.AMOUNT,
            --
            --RPTMASTERS.AMT_O_S,
            ----RPTMASTERS.LIAB_AMT,
            --(RPTMASTERS.LIAB_AMT / power(10, C8PFLIAB.c8ced)) LIAB_AMT,
            --RPTMASTERS.LIAB_CCY,
            --((RPTMASTERS.LIAB_AMT / power(10, C8PFLIAB.c8ced)) * SPOTRATELIAB.SPOTRATE)AS LIAB_AMT_EGP,
            --LIABCCYDTLS.CCY_SPT CCY_SPT1,
            --LIABCCYDTLS.CCY_SEI CCY_SEI1,
            --RPTMASTERS.EXPIRY_DAT,
            --ALLRLMSTRS.RELMSTRREF,
            --
            --PRODSHORTNAME.SOVALUE,
            --RPTMASTERS.BHALF_BRN,
            --MSTRCCYDTLS.CCY_CED,
            --LIABCCYDTLS.CCY_CED CCY_CED1
            

            FROM
            TIZONE2.RPTMASTERS@TIZONE2_LINK RPTMASTERS,
            TIZONE2.CCYDTLS@TIZONE2_LINK MSTRCCYDTLS,
            TIZONE2.RPTPARTIES@TIZONE2_LINK PCP_PARTY,
            TIZONE2.EXEMPL30@TIZONE2_LINK PRODUCT,
            TIZONE2.PRODTYPE@TIZONE2_LINK PRODTYPE,
            TIZONE2.WORKGR44@TIZONE2_LINK TEAM,
            TIZONE2.CCYDTLS@TIZONE2_LINK LIABCCYDTLS,
            TIZONE2.ALLRLMSTRS@TIZONE2_LINK ALLRLMSTRS,
            TIZONE2.CAPF@TIZONE2_LINK CAPF,
            TIZONE2.PRODLONGNAME@TIZONE2_LINK PRODLONGNAME,
            TIZONE2.PRODSHORTNAME@TIZONE2_LINK PRODSHORTNAME,
            TIZONE2.C8PF@TIZONE2_LINK C8PF,
            TIZONE2.SPOTRATE@TIZONE2_LINK--,
            --TIZONE2.C8PF C8PFLIAB,
            --SPOTRATE SPOTRATELIAB
            

            WHERE
            ((RPTMASTERS.SBB_BRN = MSTRCCYDTLS.MBE)
            AND(RPTMASTERS.CCY = MSTRCCYDTLS.CCY_CODE))
            AND(RPTMASTERS.PCP_PTY = PCP_PARTY.PARTYKEY)
            AND(RPTMASTERS.EXEMPLAR = PRODUCT.KEY97)
            AND(RPTMASTERS.PRODTYPE = PRODTYPE.KEY97(+))
            AND(RPTMASTERS.WORKGROUP = TEAM.CODE79(+))
            AND((RPTMASTERS.SBB_BRN = LIABCCYDTLS.MBE(+))
            AND(RPTMASTERS.LIAB_CCY = LIABCCYDTLS.CCY_CODE(+)))
            AND(RPTMASTERS.KEY97 = ALLRLMSTRS.MASTERKEY(+))
            AND(RPTMASTERS.BHALF_BRN = CAPF.CABRNM)
            AND(PRODUCT.CODE79 = PRODLONGNAME.PRODCODE(+))
            AND(PRODUCT.CODE79 = PRODSHORTNAME.PRODCODE(+))
            AND(RPTMASTERS.CCY = C8PF.C8CCY(+))
            AND(RPTMASTERS.CCY = SPOTRATE.currency(+) AND SPOTRATE.branch = 'BMEG')
            --AND(RPTMASTERS.LIAB_CCY = C8PFLIAB.C8CCY(+))
            --AND(RPTMASTERS.LIAB_CCY = SPOTRATELIAB.currency(+) AND SPOTRATELIAB.branch = 'MBWW')
            

            ORDER BY RPTMASTERS.BHALF_BRN, RPTMASTERS.WORKGROUP, PRODSHORTNAME.SOVALUE, PRODTYPE.DESCRIP, RPTMASTERS.MASTER_REF

            ");
            //ART_TI_OS_LIABILITY_REPORT
            migrationBuilder.Sql($@"
  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_OS_LIABILITY_REPORT"" (""GFCUN"", ""SOVALUE"", ""LIAB_CCY"", ""TOTLIABAMT"", ""TOTLIABAMT_EGP"") AS 
  SELECT
RPTPARTIES.GFCUN,
PRODSHORTNAME.SOVALUE,
RPTMASTERS.LIAB_CCY,
SUM(RPTMASTERS.TOTLIABAMT / power(10, c8pfLIAB.c8ced)) TOTLIABAMT,
SUM((RPTMASTERS.TOTLIABAMT / power(10, c8pfLIAB.c8ced)) * SPOTRATE_LIAB.SPOTRATE)AS TOTLIABAMT_EGP--,

--BSMSTLIAB.SUMLIABAMT,
--RPTPARTIES.CUS_MNM,
--RPTPARTIES.COUNTRY,
--RPTPARTIES.GFGRP,
--CCYDTLS.CCY_CED,
--CCYDTLS.CCY_SPT,
--RPTMASTERS.MASTER_REF, --For reference Filter
--CCYDTLS.CCY_SEI,
--RPTMASTERS.CCY,
--RPTMASTERS.TOTLIABAMT,


--C7PF.C7CNM,
--TAPF.TAGRD

FROM
TIZONE2.RPTMASTERS@TIZONE2_LINK RPTMASTERS,
TIZONE2.CCYDTLS@TIZONE2_LINK CCYDTLS,
TIZONE2.EXEMPL30@TIZONE2_LINK PRODUCT,
TIZONE2.RPTPARTIES@TIZONE2_LINK RPTPARTIES,
TIZONE2.BSMSTLIAB@TIZONE2_LINK BSMSTLIAB,
TIZONE2.PRODSHORTNAME@TIZONE2_LINK PRODSHORTNAME,
TIZONE2.C7PF@TIZONE2_LINK C7PF,
TIZONE2.TAPF@TIZONE2_LINK TAPF,
TIZONE2.C8PF@TIZONE2_LINK c8pfLIAB,
SPOTRATE@TIZONE2_LINK SPOTRATE_LIAB

WHERE
((RPTMASTERS.SBB_BRN = CCYDTLS.MBE)
AND(RPTMASTERS.LIAB_CCY = CCYDTLS.CCY_CODE))
AND(RPTMASTERS.EXEMPLAR = PRODUCT.KEY97)
AND(RPTMASTERS.PCP_PTY = RPTPARTIES.PARTYKEY)
AND(RPTMASTERS.KEY97 = BSMSTLIAB.MASTERKEY(+))
AND(PRODUCT.CODE79 = PRODSHORTNAME.PRODCODE(+))
AND(RPTPARTIES.COUNTRY = C7PF.C7CNA(+))
AND((RPTPARTIES.GFGRP = TAPF.TAGRP(+))
AND(RPTPARTIES.GFCUS1_SBB = TAPF.TASBB(+)))
AND RPTMASTERS.TOTLIABAMT IS  NOT  NULL
AND RPTMASTERS.TOTLIABAMT <> 0
AND(RPTMASTERS.LIAB_CCY = c8pfLIAB.C8CCY(+))
AND(RPTMASTERS.LIAB_CCY = SPOTRATE_LIAB.currency(+) AND SPOTRATE_LIAB.branch = 'BMEG')
GROUP BY
RPTPARTIES.GFCUN,
            PRODSHORTNAME.SOVALUE,
            RPTMASTERS.LIAB_CCY
            ");
            //ART_TI_OS_TRANS_AWAITI_APPRL_REPORT
            migrationBuilder.Sql($@"
 CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_OS_TRANS_AWAITI_APPRL_REPORT"" (""DESCRI56"", ""REFNO_PFIX"", ""REFNO_SERL"", ""EVENT_REFERENCE"", ""TOUCHED"", ""AMOUNT"", ""CCY"", ""AMOUNT_EGP"", ""FULLNAME"", ""WORKGROUP"", ""MASTER_REF"", ""CCY_CED"", ""BHALF_BRN"", ""PCP_ADDRESS1"", ""PCP_GFCUN"", ""PCP_CUS_MNM"", ""PCP_SW_BANK"", ""PCP_SW_CTR"", ""PCP_SW_LOC"", ""PCP_SW_BRANCH"", ""NPCP_ADDRESS1"", ""NPCP_GFCUN"", ""NPCP_CUS_MNM"", ""NPCP_SW_BANK"", ""NPCP_SW_CTR"", ""NPCP_SW_LOC"", ""NPCP_SW_BRANCH"", ""STARTED"", ""LANGUAGE"", ""SHORTNAME"", ""STATUS"", ""ISFINISHED"", ""TYPE"", ""LSTMODUSER"", ""DESCR"") AS 
  SELECT
 TEAM.DESCRI56,
 BASEEVENT.REFNO_PFIX,
 BASEEVENT.REFNO_SERL,
 (BASEEVENT.REFNO_PFIX || ' ' || BASEEVENT.REFNO_SERL)Event_Reference,
 BASEEVENT.TOUCHED,
 --BASEEVENT.AMOUNT,
 (BASEEVENT.AMOUNT / power(10, c8pf.c8ced)) AMOUNT,
 BASEEVENT.CCY,
 ((BASEEVENT.AMOUNT / power(10, c8pf.c8ced)) * SPOTRATE.SPOTRATE)AS AMOUNT_EGP,
 CAPF.FULLNAME,
 ALLRPTMSTRS.WORKGROUP,
 ALLRPTMSTRS.MASTER_REF,
 CCYDTLS.CCY_CED,
 ALLRPTMSTRS.BHALF_BRN,
 PCP_PARTY.ADDRESS1 PCP_ADDRESS1,
 PCP_PARTY.GFCUN PCP_GFCUN,
 PCP_PARTY.CUS_MNM PCP_CUS_MNM,
 PCP_PARTY.SW_BANK PCP_SW_BANK,
 PCP_PARTY.SW_CTR PCP_SW_CTR,
 PCP_PARTY.SW_LOC PCP_SW_LOC,
 PCP_PARTY.SW_BRANCH PCP_SW_BRANCH,
 NPCP_PARTY.ADDRESS1 NPCP_ADDRESS1,
 NPCP_PARTY.GFCUN NPCP_GFCUN,
 NPCP_PARTY.CUS_MNM NPCP_CUS_MNM,
 NPCP_PARTY.SW_BANK NPCP_SW_BANK,
 NPCP_PARTY.SW_CTR NPCP_SW_CTR,
 NPCP_PARTY.SW_LOC NPCP_SW_LOC,
 NPCP_PARTY.SW_BRANCH NPCP_SW_BRANCH,
 TO_TIMESTAMP(regexp_replace(EVENTTSTAMPS.STARTED, '(.{10}).(.+)', '\1 \2'), 'YYYY-MM-DD HH24:MI:SS') STARTED,
 EVENTSHORTNAME.LANGUAGE,
 EVENTSHORTNAME.SHORTNAME,
(case
when EVENTSTEP.STATUS = 'i' then 'Initiated'
when EVENTSTEP.STATUS = 'd' then 'Assigned'
when EVENTSTEP.STATUS = 'p' then 'Pended'
when EVENTSTEP.STATUS = 'w' then 'Awaiting'
when EVENTSTEP.STATUS = 'r' then 'Requested'
when EVENTSTEP.STATUS = 'q' then 'Received'
when EVENTSTEP.STATUS = 'j' then 'Rejected'
when EVENTSTEP.STATUS = 't' then 'Returned'
when EVENTSTEP.STATUS = 'a' then 'Aborted'
when EVENTSTEP.STATUS = 'c' then 'Completed'
end
) STATUS,
 EVENTSTEP.ISFINISHED,
 EVENTSTEP.TYPE,
 EVENTSTEP.LSTMODUSER,
 ORCH_STEP.DESCR
 FROM
 TIZONE2.ALLRPTMSTRS @TIZONE2_LINK ALLRPTMSTRS,
 TIZONE2.RPTPARTIES @TIZONE2_LINK PCP_PARTY,
 TIZONE2.RPTPARTIES @TIZONE2_LINK NPCP_PARTY,
 TIZONE2.WORKGR44 @TIZONE2_LINK TEAM,
 TIZONE2.BASEEVENT @TIZONE2_LINK BASEEVENT,
 TIZONE2.CAPF @TIZONE2_LINK CAPF,
 TIZONE2.EVENTTSTAMPS @TIZONE2_LINK EVENTTSTAMPS, 
 TIZONE2.EVENTCCY @TIZONE2_LINK EVENTCCY,
 TIZONE2.EVENTSHORTNAME @TIZONE2_LINK EVENTSHORTNAME, 
 TIZONE2.EVENTSTEP @TIZONE2_LINK EVENTSTEP, 
 TIZONE2.CCYDTLS @TIZONE2_LINK CCYDTLS , 
 TIZONE2.STEPHIST @TIZONE2_LINK,
 TIZONE2.ORCH_MAP @TIZONE2_LINK,
 TIZONE2.ORCH_STEP @TIZONE2_LINK,
 TIZONE2.C8PF @TIZONE2_LINK C8PF,
 TIZONE2.SPOTRATE @TIZONE2_LINK

 WHERE(ALLRPTMSTRS.PCP_PTY = PCP_PARTY.PARTYKEY) AND
            (ALLRPTMSTRS.NPCP_PTY = NPCP_PARTY.PARTYKEY) AND
 (ALLRPTMSTRS.WORKGROUP = TEAM.CODE79(+)) AND
 (ALLRPTMSTRS.KEY97 = BASEEVENT.MASTER_KEY) AND
 (ALLRPTMSTRS.BHALF_BRN = CAPF.CABRNM) AND
 (BASEEVENT.KEY97 = EVENTTSTAMPS.EVENTKEY) AND
 (BASEEVENT.KEY97 = EVENTCCY.EVENTKEY) AND
 (BASEEVENT.KEY97 = EVENTSHORTNAME.EVENTKEY) AND
            (BASEEVENT.KEY97 = EVENTSTEP.EVENT_KEY) AND
            ((EVENTCCY.CCY = CCYDTLS.CCY_CODE) AND
            (EVENTCCY.SBB_BRN = CCYDTLS.MBE)) AND
            (STEPHIST.EVENT_KEY = BASEEVENT.KEY97) AND
            (ORCH_MAP.KEY97 = STEPHIST.ORCH_MAP) AND
            (ORCH_STEP.KEY97 = ORCH_MAP.ORCH_STEP) AND
            (EVENTSTEP.ISFINISHED = 'N')--AND ORCH_STEP.KEY97 = 234
 AND(BASEEVENT.CCY = C8PF.C8CCY(+))
 AND(BASEEVENT.CCY = SPOTRATE.currency(+) AND SPOTRATE.branch = 'BMEG')
 ORDER BY ALLRPTMSTRS.BHALF_BRN, ALLRPTMSTRS.WORKGROUP, ALLRPTMSTRS.MASTER_REF
            ");
            //ART_TI_OS_TRANS_BY_GATEWAY_REPORT
            migrationBuilder.Sql($@"
  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_OS_TRANS_BY_GATEWAY_REPORT"" (""DESCRIP"", ""PARTPTD"", ""REVOLVING"", ""REV_NEXT"", ""OUTSTAMT"", ""OUTSTCCY"", ""OUTSTAMT_EGP"", ""OUTCCYSEI"", ""FULLNAME"", ""ADDRESS1"", ""SW_BANK"", ""SW_CTR"", ""SW_LOC"", ""SW_BRANCH"", ""CUS_MNM"", ""GFCUN"", ""COUNTRY"", ""STATUS"", ""MASTER_REF"", ""AMOUNT"", ""CCY"", ""AMOUNT_EGP"", ""CTRCT_DATE"", ""EXPIRY_DAT"", ""RELMSTRREF"", ""PRODCODE"", ""SOVALUE"", ""SOVALUE1"", ""BHALF_BRN"", ""TYPEFLAG"") AS 
  SELECT
PRODTYPE.DESCRIP,
LCMASTER.PARTPTD,
LCMASTER.REVOLVING,
LCMASTER.REV_NEXT,
--MSTROAMT.OUTSTAMT,
(MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) OUTSTAMT,
MSTROAMT.OUTSTCCY,
((MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) * SPOTRATEOUT.SPOTRATE)AS OUTSTAMT_EGP,
--MSTROAMT.OUTCCYSPT,
MSTROAMT.OUTCCYSEI,
CAPF.FULLNAME,
RPTPARTIES.ADDRESS1,
RPTPARTIES.SW_BANK,
RPTPARTIES.SW_CTR,
RPTPARTIES.SW_LOC,
RPTPARTIES.SW_BRANCH,
RPTPARTIES.CUS_MNM,
RPTPARTIES.GFCUN,
RPTPARTIES.COUNTRY,
RPTMASTERS.STATUS,
RPTMASTERS.MASTER_REF,
--MSTROAMT.OUTCCYCED,
--CCYDTLS.CCY_CED,
--RPTMASTERS.AMOUNT,
(RPTMASTERS.AMOUNT / power(10, c8pf.c8ced)) AMOUNT,
RPTMASTERS.CCY,
((RPTMASTERS.AMOUNT / power(10, c8pf.c8ced)) * SPOTRATE.SPOTRATE)AS AMOUNT_EGP,
            RPTMASTERS.CTRCT_DATE,
            RPTMASTERS.EXPIRY_DAT,
            ALLRLMSTRS.RELMSTRREF,
            GWYCUSTS.PRODCODE,
PRODLONGNAME.SOVALUE,
PRODSHORTNAME.SOVALUE SOVALUE1,
RPTMASTERS.BHALF_BRN,
RPTMASTERS.TYPEFLAG
FROM
TIZONE2.RPTMASTERS@TIZONE2_LINK RPTMASTERS inner join
TIZONE2.CCYDTLS@TIZONE2_LINK CCYDTLS on RPTMASTERS.CCY = CCYDTLS.CCY_CODE AND RPTMASTERS.SBB_BRN = CCYDTLS.MBE left join
TIZONE2.LCMASTER@TIZONE2_LINK LCMASTER on RPTMASTERS.KEY97 = LCMASTER.KEY97 inner join
TIZONE2.MSTROAMT@TIZONE2_LINK MSTROAMT on RPTMASTERS.KEY97 = MSTROAMT.MASTERKEY left join
TIZONE2.PRODTYPE@TIZONE2_LINK PRODTYPE on RPTMASTERS.PRODTYPE = PRODTYPE.KEY97 left join
TIZONE2.ALLRLMSTRS@TIZONE2_LINK ALLRLMSTRS on RPTMASTERS.KEY97 = ALLRLMSTRS.MASTERKEY left join-- the next tabkle affected the data
TIZONE2.GWYCUSTS@TIZONE2_LINK GWYCUSTS on RPTMASTERS.KEY97 = GWYCUSTS.MASTERKEY
AND  NOT(
GWYCUSTS.PRODCODE = 'BIL' OR GWYCUSTS.PRODCODE = 'COR' OR GWYCUSTS.PRODCODE = 'FAC' OR GWYCUSTS.PRODCODE = 'FCB'
OR GWYCUSTS.PRODCODE = 'FEL' OR GWYCUSTS.PRODCODE = 'FIA' OR GWYCUSTS.PRODCODE = 'FIC' OR GWYCUSTS.PRODCODE = 'FIL'
OR GWYCUSTS.PRODCODE = 'FOC' OR GWYCUSTS.PRODCODE = 'FRB' OR GWYCUSTS.PRODCODE = 'FSA' OR GWYCUSTS.PRODCODE = 'INV'
OR GWYCUSTS.PRODCODE = 'LIC' OR GWYCUSTS.PRODCODE = 'PTN' OR GWYCUSTS.PRODCODE = 'SHG' OR GWYCUSTS.PRODCODE = 'TILC' OR GWYCUSTS.PRODCODE = 'TRF')
left join
TIZONE2.CAPF@TIZONE2_LINK CAPF on RPTMASTERS.BHALF_BRN = CAPF.CABRNM left join-- the next tabkle affected the data
TIZONE2.RPTPARTIES@TIZONE2_LINK RPTPARTIES on GWYCUSTS.PARTYKEY = RPTPARTIES.PARTYKEY left join-- the next tabkle affected the data
TIZONE2.PRODLONGNAME@TIZONE2_LINK PRODLONGNAME on GWYCUSTS.PRODCODE = PRODLONGNAME.PRODCODE left join-- the next tabkle affected the data
TIZONE2.PRODSHORTNAME@TIZONE2_LINK PRODSHORTNAME on GWYCUSTS.PRODCODE = PRODSHORTNAME.PRODCODE  left join
TIZONE2.C8PF@TIZONE2_LINK c8pfOUT on MSTROAMT.OUTSTCCY = c8pfOUT.C8CCY left join
TIZONE2.C8PF@TIZONE2_LINK C8PF on RPTMASTERS.CCY = C8PF.C8CCY left join
TIZONE2.SPOTRATE@TIZONE2_LINK on RPTMASTERS.CCY = SPOTRATE.currency  AND SPOTRATE.branch = 'BMEG' left join
SPOTRATE@TIZONE2_LINK SPOTRATEOUT on MSTROAMT.OUTSTCCY = SPOTRATEOUT.currency AND SPOTRATEOUT.branch = 'BMEG'
where
RPTMASTERS.STATUS <> 'BKF'
            ");
            //ART_TI_OS_TRANS_BY_NONPRI_REPORT
            migrationBuilder.Sql($@"
  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_OS_TRANS_BY_NONPRI_REPORT"" (""DESCRIP"", ""PARTPTD"", ""REVOLVING"", ""CODE79"", ""REV_NEXT"", ""OUTSTAMT"", ""OUTSTCCY"", ""OUTSTAMT_EGP"", ""OUTCCYSEI"", ""BRANCH_NAME"", ""ADDRESS1"", ""SW_BANK"", ""SW_CTR"", ""SW_LOC"", ""SW_BRANCH"", ""CUS_MNM"", ""GFCUN"", ""COUNTRY"", ""STATUS"", ""MASTER_REF"", ""AMOUNT"", ""CCY"", ""AMOUNT_EGP"", ""CTRCT_DATE"", ""EXPIRY_DAT"", ""RELMSTRREF"", ""SOVALUE"", ""SOVALUE1"", ""BHALF_BRN"", ""TYPEFLAG"") AS 
  SELECT
PRODTYPE.DESCRIP,
LCMASTER.PARTPTD,
LCMASTER.REVOLVING,
PRODUCT.CODE79,
LCMASTER.REV_NEXT,
--MSTROAMT.OUTSTAMT,
(MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) OUTSTAMT,
MSTROAMT.OUTSTCCY,
((MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) * SPOTRATEOUT.SPOTRATE)AS OUTSTAMT_EGP,
--MSTROAMT.OUTCCYSPT,
MSTROAMT.OUTCCYSEI,
CAPF.FULLNAME Branch_Name, --Filter For Branch
RPTPARTIES.ADDRESS1,
RPTPARTIES.SW_BANK,
RPTPARTIES.SW_CTR,
RPTPARTIES.SW_LOC,
RPTPARTIES.SW_BRANCH,
RPTPARTIES.CUS_MNM,
RPTPARTIES.GFCUN,
RPTPARTIES.COUNTRY,
RPTMASTERS.STATUS,
RPTMASTERS.MASTER_REF, --Filter For Reference
--MSTROAMT.OUTCCYCED,
--CCYDTLS.CCY_CED,
--RPTMASTERS.AMOUNT,
(RPTMASTERS.AMOUNT / power(10, c8pf.c8ced)) AMOUNT,
RPTMASTERS.CCY,
((RPTMASTERS.AMOUNT / power(10, c8pf.c8ced)) * SPOTRATE.SPOTRATE)AS AMOUNT_EGP,
RPTMASTERS.CTRCT_DATE, --Filter For Dates
RPTMASTERS.EXPIRY_DAT,
ALLRLMSTRS.RELMSTRREF,
PRODLONGNAME.SOVALUE,
PRODSHORTNAME.SOVALUE SOVALUE1,
RPTMASTERS.BHALF_BRN,
RPTMASTERS.TYPEFLAG
FROM
TIZONE2.RPTMASTERS@TIZONE2_LINK RPTMASTERS,
TIZONE2.CCYDTLS@TIZONE2_LINK CCYDTLS,
TIZONE2.LCMASTER@TIZONE2_LINK LCMASTER,
TIZONE2.MSTROAMT@TIZONE2_LINK MSTROAMT,
TIZONE2.PRODTYPE@TIZONE2_LINK PRODTYPE,
TIZONE2.EXEMPL30@TIZONE2_LINK PRODUCT,
TIZONE2.ALLRLMSTRS@TIZONE2_LINK ALLRLMSTRS,
TIZONE2.RPTPARTIES@TIZONE2_LINK RPTPARTIES,
TIZONE2.CAPF@TIZONE2_LINK CAPF,
TIZONE2.PRODLONGNAME@TIZONE2_LINK PRODLONGNAME,
TIZONE2.PRODSHORTNAME@TIZONE2_LINK PRODSHORTNAME,
TIZONE2.C8PF@TIZONE2_LINK c8pfOUT,
TIZONE2.C8PF@TIZONE2_LINK C8PF,
SPOTRATE@TIZONE2_LINK,
SPOTRATE@TIZONE2_LINK SPOTRATEOUT
WHERE
((RPTMASTERS.CCY = CCYDTLS.CCY_CODE)
AND(RPTMASTERS.SBB_BRN = CCYDTLS.MBE))
AND(RPTMASTERS.KEY97 = LCMASTER.KEY97(+))
AND(RPTMASTERS.KEY97 = MSTROAMT.MASTERKEY)
AND(RPTMASTERS.PRODTYPE = PRODTYPE.KEY97(+))
AND(RPTMASTERS.EXEMPLAR = PRODUCT.KEY97)
AND(RPTMASTERS.KEY97 = ALLRLMSTRS.MASTERKEY(+))
AND(RPTMASTERS.NPCP_PTY = RPTPARTIES.PARTYKEY)
AND(RPTMASTERS.BHALF_BRN = CAPF.CABRNM)
AND(PRODUCT.CODE79 = PRODLONGNAME.PRODCODE)
AND(PRODUCT.CODE79 = PRODSHORTNAME.PRODCODE)
AND  NOT
(PRODUCT.CODE79 = 'BIL' OR
PRODUCT.CODE79 = 'COR' OR
PRODUCT.CODE79 = 'FAC' OR
PRODUCT.CODE79 = 'FCB' OR
PRODUCT.CODE79 = 'FEL' OR
PRODUCT.CODE79 = 'FIA' OR
PRODUCT.CODE79 = 'FIC' OR
PRODUCT.CODE79 = 'FIL' OR
PRODUCT.CODE79 = 'FOC' OR
PRODUCT.CODE79 = 'FRB' OR
PRODUCT.CODE79 = 'FSA' OR
PRODUCT.CODE79 = 'INV' OR
PRODUCT.CODE79 = 'LIC' OR
PRODUCT.CODE79 = 'PTN' OR
PRODUCT.CODE79 = 'SHG' OR
PRODUCT.CODE79 = 'TILC' OR
PRODUCT.CODE79 = 'TRF')
AND RPTMASTERS.STATUS <> 'BKF'
AND(MSTROAMT.OUTSTCCY = c8pfOUT.C8CCY(+))
AND(MSTROAMT.OUTSTCCY = SPOTRATEOUT.currency(+) AND SPOTRATEOUT.branch = 'BMEG')

AND(RPTMASTERS.CCY = C8PF.C8CCY(+))
AND(RPTMASTERS.CCY = SPOTRATE.currency(+) AND SPOTRATE.branch = 'BMEG')
ORDER BY RPTMASTERS.BHALF_BRN
            ");
            //ART_TI_OS_TRANS_BY_PRINCIPAL_REPORT
            migrationBuilder.Sql($@"
  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_OS_TRANS_BY_PRINCIPAL_REPORT"" (""DESCRIP"", ""PARTPTD"", ""REVOLVING"", ""CODE79"", ""REV_NEXT"", ""OUTSTAMT"", ""OUTSTCCY"", ""OUTSTAMT_EGP"", ""OUTCCYSPT"", ""OUTCCYSEI"", ""FULLNAME"", ""ADDRESS1"", ""SW_BANK"", ""SW_CTR"", ""SW_LOC"", ""SW_BRANCH"", ""CUS_MNM"", ""GFCUN"", ""COUNTRY"", ""STATUS"", ""MASTER_REF"", ""OUTCCYCED"", ""CCY_CED"", ""AMOUNT"", ""CCY"", ""AMOUNT_EGP"", ""CTRCT_DATE"", ""EXPIRY_DAT"", ""RELMSTRREF"", ""SOVALUE"", ""SOVALUE1"", ""BHALF_BRN"", ""TYPEFLAG"") AS 
  SELECT
PRODTYPE.DESCRIP,
LCMASTER.PARTPTD,
LCMASTER.REVOLVING,
PRODUCT.CODE79,
LCMASTER.REV_NEXT,
--MSTROAMT.OUTSTAMT,
(MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) OUTSTAMT,
MSTROAMT.OUTSTCCY,
((MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) * SPOTRATEOUT.SPOTRATE)AS OUTSTAMT_EGP,
MSTROAMT.OUTCCYSPT,
MSTROAMT.OUTCCYSEI,
CAPF.FULLNAME,
RPTPARTIES.ADDRESS1,
RPTPARTIES.SW_BANK,
RPTPARTIES.SW_CTR,
RPTPARTIES.SW_LOC,
RPTPARTIES.SW_BRANCH,
RPTPARTIES.CUS_MNM,
RPTPARTIES.GFCUN,
RPTPARTIES.COUNTRY,
RPTMASTERS.STATUS,
RPTMASTERS.MASTER_REF,
MSTROAMT.OUTCCYCED,
CCYDTLS.CCY_CED,
--RPTMASTERS.AMOUNT,
(RPTMASTERS.AMOUNT / power(10, c8pf.c8ced)) AMOUNT,
RPTMASTERS.CCY,
((RPTMASTERS.AMOUNT / power(10, c8pf.c8ced)) * SPOTRATE.SPOTRATE)AS AMOUNT_EGP,
RPTMASTERS.CTRCT_DATE,
RPTMASTERS.EXPIRY_DAT,
ALLRLMSTRS.RELMSTRREF,
PRODLONGNAME.SOVALUE,
PRODSHORTNAME.SOVALUE SOVALUE1,
RPTMASTERS.BHALF_BRN,
RPTMASTERS.TYPEFLAG
FROM
TIZONE2.RPTMASTERS@TIZONE2_LINK RPTMASTERS,
TIZONE2.RPTPARTIES@TIZONE2_LINK RPTPARTIES,
TIZONE2.CCYDTLS@TIZONE2_LINK CCYDTLS,
TIZONE2.LCMASTER@TIZONE2_LINK LCMASTER,
TIZONE2.MSTROAMT@TIZONE2_LINK MSTROAMT,
TIZONE2.PRODTYPE@TIZONE2_LINK PRODTYPE,
TIZONE2.EXEMPL30@TIZONE2_LINK PRODUCT,
TIZONE2.ALLRLMSTRS@TIZONE2_LINK ALLRLMSTRS,
TIZONE2.CAPF@TIZONE2_LINK CAPF,
TIZONE2.PRODLONGNAME@TIZONE2_LINK PRODLONGNAME,
TIZONE2.PRODSHORTNAME@TIZONE2_LINK PRODSHORTNAME,
TIZONE2.C8PF@TIZONE2_LINK c8pfOUT,
TIZONE2.C8PF@TIZONE2_LINK C8PF,
SPOTRATE@TIZONE2_LINK,
SPOTRATE@TIZONE2_LINK SPOTRATEOUT
WHERE
(RPTMASTERS.PCP_PTY = RPTPARTIES.PARTYKEY)
AND((RPTMASTERS.CCY = CCYDTLS.CCY_CODE)
AND(RPTMASTERS.SBB_BRN = CCYDTLS.MBE))
AND(RPTMASTERS.KEY97 = LCMASTER.KEY97(+))
AND(RPTMASTERS.KEY97 = MSTROAMT.MASTERKEY)
AND(RPTMASTERS.PRODTYPE = PRODTYPE.KEY97(+))
AND(RPTMASTERS.EXEMPLAR = PRODUCT.KEY97)
AND(RPTMASTERS.KEY97 = ALLRLMSTRS.MASTERKEY(+))
AND(RPTMASTERS.BHALF_BRN = CAPF.CABRNM)
AND(PRODUCT.CODE79 = PRODLONGNAME.PRODCODE)
AND(PRODUCT.CODE79 = PRODSHORTNAME.PRODCODE)
AND  NOT
(PRODUCT.CODE79 = 'BIL'
OR PRODUCT.CODE79 = 'COR'
OR PRODUCT.CODE79 = 'FAC'
OR PRODUCT.CODE79 = 'FCB'
OR PRODUCT.CODE79 = 'FEL'
OR PRODUCT.CODE79 = 'FIA'
OR PRODUCT.CODE79 = 'FIC'
OR PRODUCT.CODE79 = 'FIL'
OR PRODUCT.CODE79 = 'FOC'
OR PRODUCT.CODE79 = 'FRB'
OR PRODUCT.CODE79 = 'FSA'
OR PRODUCT.CODE79 = 'INV'
OR PRODUCT.CODE79 = 'LIC'
OR PRODUCT.CODE79 = 'PTN'
OR PRODUCT.CODE79 = 'SHG'
OR PRODUCT.CODE79 = 'TILC'
OR PRODUCT.CODE79 = 'TRF')
AND RPTMASTERS.STATUS <> 'BKF'

AND(MSTROAMT.OUTSTCCY = c8pfOUT.C8CCY(+))
AND(MSTROAMT.OUTSTCCY = SPOTRATEOUT.currency(+) AND SPOTRATEOUT.branch = 'BMEG')

AND(RPTMASTERS.CCY = C8PF.C8CCY(+))
AND(RPTMASTERS.CCY = SPOTRATE.currency(+) AND SPOTRATE.branch = 'BMEG')
ORDER BY RPTMASTERS.BHALF_BRN
            ");
            //ART_TI_PERIODIC_CHRGS_PAY_REPORT
            migrationBuilder.Sql($@"
  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_PERIODIC_CHRGS_PAY_REPORT"" (""BHALF_BRN"", ""FULLNAME"", ""NPCP_ADDRESS1"", ""NPCP_GFCUN"", ""NPCP_CUS_MNM"", ""NPCP_SW_BANK"", ""NPCP_SW_CTR"", ""NPCP_SW_LOC"", ""NPCP_SW_BRANCH"", ""NPCP_ADDRESS11"", ""CHG_GFCUN1"", ""CHG_CUS_MNM1"", ""CHG_SW_BANK1"", ""CHG_SW_CTR1"", ""CHG_SW_LOC1"", ""CHG_SW_BRANCH1"", ""MASTER_REF"", ""SOVALUE"", ""PCP_ADDRESS1"", ""PCP_GFCUN"", ""PCP_CUS_MNM"", ""PCP_SW_BANK"", ""PCP_SW_CTR"", ""PCP_SW_LOC"", ""PCP_SW_BRANCH"", ""PAYREC"", ""OUTSTAMT"", ""OUTSTCCY"", ""OUTSTAMT_EGP"", ""OUTCCYCED"", ""RELMSTRREF"", ""ID"", ""SUPP_ACC"", ""ACCRUE_AMT"", ""ACCRUE_CCY"", ""ACCRUE_AMT_EGP"", ""CHARGE_AMT"", ""CHARGE_CCY"", ""CHARGE_AMT_EGP"", ""END_DAT"", ""START_DAT"", ""FIRSTSTART"", ""CHGPEXTRADAY"", ""WORKGROUP"", ""DESCR"", ""DESCR1"", ""SCH_AMT"", ""SCH_CCY"", ""SCH_AMT_EGP"", ""DDATE"") AS 
  SELECT
RPTMASTERS.BHALF_BRN,
CAPF.FULLNAME,
NPCP_PARTY.ADDRESS1 NPCP_ADDRESS1,
NPCP_PARTY.GFCUN NPCP_GFCUN,
NPCP_PARTY.CUS_MNM NPCP_CUS_MNM,
NPCP_PARTY.SW_BANK NPCP_SW_BANK,
NPCP_PARTY.SW_CTR NPCP_SW_CTR,
NPCP_PARTY.SW_LOC NPCP_SW_LOC,
NPCP_PARTY.SW_BRANCH NPCP_SW_BRANCH,
CHG_PARTY.ADDRESS1 NPCP_ADDRESS11,
CHG_PARTY.GFCUN CHG_GFCUN1,
CHG_PARTY.CUS_MNM CHG_CUS_MNM1,
CHG_PARTY.SW_BANK CHG_SW_BANK1,
CHG_PARTY.SW_CTR CHG_SW_CTR1,
CHG_PARTY.SW_LOC CHG_SW_LOC1,
CHG_PARTY.SW_BRANCH CHG_SW_BRANCH1,
RPTMASTERS.MASTER_REF,
PRODLONGNAME.SOVALUE,
PCP_PARTY.ADDRESS1 PCP_ADDRESS1,
PCP_PARTY.GFCUN PCP_GFCUN,
PCP_PARTY.CUS_MNM PCP_CUS_MNM,
PCP_PARTY.SW_BANK PCP_SW_BANK,
PCP_PARTY.SW_CTR PCP_SW_CTR,
PCP_PARTY.SW_LOC PCP_SW_LOC,
PCP_PARTY.SW_BRANCH PCP_SW_BRANCH,
(CASE WHEN UPPER(CHGPAYREC.PAYREC) = 'P' THEN 'Pay' WHEN UPPER(CHGPAYREC.PAYREC) = 'R' THEN 'Receive' END)  PAYREC,
--MSTROAMT.OUTSTAMT, 
(MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) OUTSTAMT,
MSTROAMT.OUTSTCCY,
((MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) * SPOTRATEOUT.SPOTRATE)AS OUTSTAMT_EGP,
MSTROAMT.OUTCCYCED, 
RPTMASTERS.RELMSTRREF, 
RELTEMPLTE.ID, 
PERDCHGACCR.SUPP_ACC, 
--PERDCHGACCR.ACCRUE_AMT,
(PERDCHGACCR.ACCRUE_AMT / power(10, c8pfACCRUE.c8ced)) ACCRUE_AMT,
PERDCHGACCR.ACCRUE_CCY, 
((PERDCHGACCR.ACCRUE_AMT / power(10, c8pfACCRUE.c8ced)) * SPOTRATEACCRUE.SPOTRATE)AS ACCRUE_AMT_EGP,
--PERDCHGACCR.CHARGE_AMT, 
(PERDCHGACCR.CHARGE_AMT / power(10, c8pfCHARGE.c8ced)) CHARGE_AMT,
PERDCHGACCR.CHARGE_CCY,
((PERDCHGACCR.CHARGE_AMT / power(10, c8pfCHARGE.c8ced)) * SPOTRATECHARGE.SPOTRATE)AS CHARGE_AMT_EGP,
PERDCHGACCR.END_DAT, 
PERDCHGACCR.START_DAT, 
PERDCHGACCR.FIRSTSTART, 
PERDCHGACCR.CHGPEXTRADAY, 
RPTMASTERS.WORKGROUP, 
MSTRTEAM.DESCR, 
RELTEMPLTE.DESCR DESCR1,
--PROJCHGSRPT.SCH_AMT, 
(PROJCHGSRPT.SCH_AMT / power(10, c8pfSCH.c8ced)) SCH_AMT,
PROJCHGSRPT.SCH_CCY,
((PROJCHGSRPT.SCH_AMT / power(10, c8pfSCH.c8ced)) * SPOTRATESCH.SPOTRATE)AS SCH_AMT_EGP,
PROJCHGSRPT.DDATE
from
TIZONE2.RPTMASTERS @TIZONE2_LINK RPTMASTERS inner join
TIZONE2.PROJCHGSRPT @TIZONE2_LINK PROJCHGSRPT on RPTMASTERS.KEY97 = PROJCHGSRPT.MASTERKEY  inner join
TIZONE2.RPTPARTIES @TIZONE2_LINK CHG_PARTY on CHG_PARTY.PARTYKEY = PROJCHGSRPT.CHG_PTY inner join
TIZONE2.CHGPAYREC @TIZONE2_LINK CHGPAYREC on CHGPAYREC.CHGKEY = PROJCHGSRPT.CHGKEY inner join
TIZONE2.RELTEMPLTE @TIZONE2_LINK RELTEMPLTE on RELTEMPLTE.KEY97 = PROJCHGSRPT.TEMPLATEKEY inner join
TIZONE2.CAPF @TIZONE2_LINK CAPF on RPTMASTERS.BHALF_BRN = CAPF.CABRNM inner join
TIZONE2.MSTRTEAM @TIZONE2_LINK MSTRTEAM on RPTMASTERS.KEY97 = MSTRTEAM.MASTERKEY inner join
TIZONE2.RPTPARTIES @TIZONE2_LINK PCP_PARTY on RPTMASTERS.PCP_PTY = PCP_PARTY.PARTYKEY inner join
TIZONE2.RPTPARTIES @TIZONE2_LINK NPCP_PARTY on RPTMASTERS.NPCP_PTY = NPCP_PARTY.PARTYKEY inner join
TIZONE2.EXEMPL30 @TIZONE2_LINK PRODUCT on RPTMASTERS.EXEMPLAR = PRODUCT.KEY97 inner join
TIZONE2.MSTROAMT @TIZONE2_LINK MSTROAMT on RPTMASTERS.KEY97 = MSTROAMT.MASTERKEY left join
TIZONE2.PRODLONGNAME @TIZONE2_LINK PRODLONGNAME on PRODUCT.CODE79 = PRODLONGNAME.PRODCODE left join
TIZONE2.PERDCHGACCR @TIZONE2_LINK PERDCHGACCR on PROJCHGSRPT.CHGKEY = PERDCHGACCR.PERIOD_CHG left join
TIZONE2.C8PF @TIZONE2_LINK c8pfOUT on MSTROAMT.OUTSTCCY = c8pfOUT.C8CCY left join
TIZONE2.C8PF @TIZONE2_LINK c8pfACCRUE on PERDCHGACCR.ACCRUE_CCY = c8pfACCRUE.C8CCY left join
TIZONE2.C8PF @TIZONE2_LINK c8pfCHARGE on PERDCHGACCR.CHARGE_CCY = c8pfCHARGE.C8CCY left join
TIZONE2.C8PF @TIZONE2_LINK c8pfSCH on PROJCHGSRPT.SCH_CCY = c8pfSCH.C8CCY left join
TIZONE2.SPOTRATE @TIZONE2_LINK SPOTRATEOUT on MSTROAMT.OUTSTCCY = SPOTRATEOUT.currency AND SPOTRATEOUT.branch = 'BMEG' left join
TIZONE2.SPOTRATE @TIZONE2_LINK SPOTRATEACCRUE on PERDCHGACCR.ACCRUE_CCY = SPOTRATEACCRUE.currency AND SPOTRATEACCRUE.branch = 'BMEG' left join
TIZONE2.SPOTRATE @TIZONE2_LINK SPOTRATECHARGE on PERDCHGACCR.CHARGE_CCY = SPOTRATECHARGE.currency  AND SPOTRATECHARGE.branch = 'BMEG' left join
TIZONE2.SPOTRATE @TIZONE2_LINK SPOTRATESCH on PROJCHGSRPT.SCH_CCY = SPOTRATESCH.currency AND SPOTRATESCH.branch = 'BMEG'
            ");
            //ART_TI_PERIODIC_CHRGS_REPORT
            migrationBuilder.Sql($@"
 CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_PERIODIC_CHRGS_REPORT"" (""BHALF_BRN"", ""FULLNAME"", ""WORKGROUP"", ""DESCRI56"", ""ADDRESS1"", ""GFCUN"", ""CUS_MNM"", ""SW_BANK"", ""SW_CTR"", ""SW_LOC"", ""SW_BRANCH"", ""SOVALUE"", ""MASTER_REF"", ""RELMSTRREF"", ""OUTSTAMT"", ""OUTSTCCY"", ""OUTSTAMT_EGP"", ""OUTCCYCED"", ""PAYREC"", ""DAILY_ACC"", ""ADV_ARR"", ""SUPP_ACC"", ""CHARGE_AMT"", ""CHARGE_CCY"", ""CHARGE_AMT_EGP"", ""END_DAT"", ""START_DAT"", ""FIRSTSTART"", ""CHGPEXTRADAY"", ""ACCRUE_AMT"", ""ACCRUE_CCY"", ""ACCRUE_AMT_EGP"", ""ID"", ""DESCR"", ""PERIODIC"") AS 
  SELECT
RPTMASTERS.BHALF_BRN,
CAPF.FULLNAME,
RPTMASTERS.WORKGROUP,
TEAM.DESCRI56,
CHG_PARTY.ADDRESS1,
CHG_PARTY.GFCUN,
CHG_PARTY.CUS_MNM,
CHG_PARTY.SW_BANK,
CHG_PARTY.SW_CTR,
CHG_PARTY.SW_LOC,
CHG_PARTY.SW_BRANCH,
PRODLONGNAME.SOVALUE,
BSCHGSFORRPT.MASTER_REF,
TRIM(regexp_replace(regexp_replace(regexp_replace(""RPTMASTERS"".""RELMSTRREF"", chr(13), ''), chr(10), ''), chr(9), '')) RELMSTRREF,
--MSTROAMT.OUTSTAMT,
(MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) OUTSTAMT,
MSTROAMT.OUTSTCCY,
((MSTROAMT.OUTSTAMT / power(10, c8pfOUT.c8ced)) * SPOTRATEOUT.SPOTRATE)AS OUTSTAMT_EGP,
MSTROAMT.OUTCCYCED,
CHGPAYREC.PAYREC,
       CASE
           WHEN(""PERDCHGACCR"".""END_DAT"" - ""PERDCHGACCR"".""START_DAT"" <> 0)
                AND(""PERDCHGACCR"".""END_DAT"" >= CURRENT_DATE) THEN ROUND((""PERDCHGACCR"".""ACCRUE_AMT"" / (""PERDCHGACCR"".""END_DAT"" - ""PERDCHGACCR"".""START_DAT"")) / POWER(10, ""C8PF"".""C8CED""), 2)
       END AS DAILY_ACC,
(case when TRANSCHED.ADV_ARR = 'S' then 'Amortise' else 'Accrue' end) ADV_ARR,
PERDCHGACCR.SUPP_ACC, 
--PERDCHGACCR.CHARGE_AMT,
(PERDCHGACCR.CHARGE_AMT / power(10, c8pfCHARGE.c8ced)) CHARGE_AMT,
PERDCHGACCR.CHARGE_CCY,
((PERDCHGACCR.CHARGE_AMT / power(10, c8pfCHARGE.c8ced)) * SPOTRATECHARGE.SPOTRATE)AS CHARGE_AMT_EGP,
PERDCHGACCR.END_DAT, 
PERDCHGACCR.START_DAT, 
PERDCHGACCR.FIRSTSTART, 
PERDCHGACCR.CHGPEXTRADAY, 
--PERDCHGACCR.ACCRUE_AMT, 
(PERDCHGACCR.ACCRUE_AMT / power(10, c8pfACCRUE.c8ced)) ACCRUE_AMT,
TRIM(regexp_replace(regexp_replace(regexp_replace(""PERDCHGACCR"".""ACCRUE_CCY"", chr(13), ''), chr(10), ''), chr(9), '')) ACCRUE_CCY, 
((PERDCHGACCR.ACCRUE_AMT / power(10, c8pfACCRUE.c8ced)) * SPOTRATEACCRUE.SPOTRATE)AS ACCRUE_AMT_EGP,
RELTEMPLTE.ID, 
RELTEMPLTE.DESCR, 
TRANSCHED.PERIODIC

FROM

TIZONE2.RPTMASTERS @TIZONE2_LINK  RPTMASTERS, 
TIZONE2.CAPF @TIZONE2_LINK  CAPF, 
TIZONE2.WORKGR44 @TIZONE2_LINK  TEAM, 
TIZONE2.BSCHGSFORRPT @TIZONE2_LINK  BSCHGSFORRPT, 
TIZONE2.MSTROAMT @TIZONE2_LINK  MSTROAMT, 
TIZONE2.EXEMPL30 @TIZONE2_LINK  PRODUCT, 
TIZONE2.RPTPARTIES @TIZONE2_LINK  CHG_PARTY, 
TIZONE2.CHGPAYREC @TIZONE2_LINK  CHGPAYREC, 
TIZONE2.EVENTCHG @TIZONE2_LINK  EVENTCHG, 
TIZONE2.RELTEMPLTE @TIZONE2_LINK  RELTEMPLTE, 
TIZONE2.TRANSCHEDE @TIZONE2_LINK  TRANSCHED, 
TIZONE2.PERDCHGACCR @TIZONE2_LINK  PERDCHGACCR, 
TIZONE2.C8PF @TIZONE2_LINK  C8PF,
TIZONE2.PRODLONGNAME @TIZONE2_LINK  PRODLONGNAME,
TIZONE2.C8PF @TIZONE2_LINK  c8pfOUT,
TIZONE2.C8PF @TIZONE2_LINK  c8pfACCRUE,
TIZONE2.C8PF @TIZONE2_LINK  c8pfCHARGE,
TIZONE2.SPOTRATE @TIZONE2_LINK  SPOTRATEOUT,
TIZONE2.SPOTRATE @TIZONE2_LINK  SPOTRATEACCRUE,
TIZONE2.SPOTRATE @TIZONE2_LINK  SPOTRATECHARGE

WHERE

(RPTMASTERS.BHALF_BRN = CAPF.CABRNM)
AND(RPTMASTERS.WORKGROUP = TEAM.CODE79(+))
AND(RPTMASTERS.KEY97 = BSCHGSFORRPT.MASTERKEY)
AND(RPTMASTERS.KEY97 = MSTROAMT.MASTERKEY)
AND(BSCHGSFORRPT.EXEMPLAR = PRODUCT.KEY97)
AND(BSCHGSFORRPT.CHG_PTY = CHG_PARTY.PARTYKEY)
AND(BSCHGSFORRPT.CHGKEY = CHGPAYREC.CHGKEY)
AND(BSCHGSFORRPT.CHGKEY = EVENTCHG.KEY97)
AND(BSCHGSFORRPT.TEMPLATEKEY = RELTEMPLTE.KEY97)
AND(EVENTCHG.TCHG_SCH = TRANSCHED.KEY97(+))
AND(EVENTCHG.KEY97 = PERDCHGACCR.PERIOD_CHG(+))
AND(""PERDCHGACCR"".""CHARGE_CCY"" = ""C8PF"".""C8CCY"")
AND(PRODUCT.CODE79 = PRODLONGNAME.PRODCODE(+))
AND TRANSCHED.PERIODIC = 'Y'
AND PERDCHGACCR.CHARGE_AMT IS  NOT NULL

AND(MSTROAMT.OUTSTCCY = c8pfOUT.C8CCY(+))
AND(MSTROAMT.OUTSTCCY = SPOTRATEOUT.currency(+) AND SPOTRATEOUT.branch = 'BMEG')

AND(PERDCHGACCR.ACCRUE_CCY = c8pfACCRUE.C8CCY(+))
AND(PERDCHGACCR.ACCRUE_CCY = SPOTRATEACCRUE.currency(+) AND SPOTRATEACCRUE.branch = 'BMEG')

AND(PERDCHGACCR.CHARGE_CCY = c8pfCHARGE.C8CCY(+))
AND(PERDCHGACCR.CHARGE_CCY = SPOTRATECHARGE.currency(+) AND SPOTRATECHARGE.branch = 'BMEG')
ORDER BY RPTMASTERS.BHALF_BRN, RPTMASTERS.WORKGROUP
            ");
            //ART_TI_SYSTEM_TAILORING_REPORT
            migrationBuilder.Sql($@"
  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_SYSTEM_TAILORING_REPORT"" (""TYPEFLAG"", ""OPERAT44"", ""SEQ97"", ""CANAMDBAS"", ""AMENDCHG"", ""AUTOPRINT"", ""SEVERITY"", ""ERROR_TEXT"", ""DEADLINEDAYS"", ""DEADLINEDATE"", ""DEADLINETIME"", ""DEADLINERSECS"", ""USEEVTFM"", ""EVENTLONGNAME"", ""USERNAME"", ""TEAMCODE"", ""MAPPINGTYPE"", ""TEMPLATEID"", ""OBSOLETE"", ""OPTIONAL"", ""PRODLONGNAME"", ""RELEVMAPKEY"", ""ATTACHMENT"", ""STEPTYPE"", ""AMBERDAYS"", ""AMBERDATE"", ""AMBERTIME"", ""AMBERRSECS"", ""REDDAYS"", ""REDDATE"", ""REDTIME"", ""REDRSECS"", ""PARAMSETID"", ""MAPPINGID"", ""PARAMSETDESCR"", ""INUSE"", ""INTINITSTEPID"", ""SWINITSTEPID"", ""BTINITSTEPID"", ""GWINITSTEPID"", ""SWREJSTEPID"", ""BTREJSTEPID"", ""GWREJSTEPID"", ""MAPSTEPID"", ""STEP_TIME"", ""AVAIL_TYPE"", ""TEMPLATEDESCR"", ""TEAMDESCR"", ""MAPPINGSUBID"", ""DEBITCREDIT"", ""TRANCODE"", ""REV_PSTNGS"", ""INTERN_ACC"", ""CONTINGENT"", ""LIABILITY"", ""CHK_LIMIT"", ""POSTINGTYP"", ""MARGIN"", ""TRCRSDLIAB"", ""TRANS_ACC"", ""PROJECTION"", ""SEQUENCE"", ""REJSTEPID"", ""ACTUAL_AMT"", ""AMT_CCY"", ""MAPSTEPDESCR"", ""REJSTEPDESCR"", ""INTINITSTEPDESCR"", ""SWINITSTEPDESCR"", ""BTINITSTEPDESCR"", ""GWINITSTEPDESCR"", ""SWREJSTEPDESCR"", ""BTREJSTEPDESCR"", ""GWREJSTEPDESCR"", ""DOMTYPE"", ""DOMBEHAVIOUR"", ""DOMNAME"", ""DOMDEFAULT"", ""DOMLINKCODE"", ""DOMLINKNAME"", ""DOMCODE"", ""NEXTSTEPID"", ""NEXTSTEPDESCR"", ""FROMSTEPID"", ""FROMSTEPDESCR"", ""AMT_FIELD"", ""LIABAMTTYP"", ""BSPARAMSETID"", ""BSPARAMSETDESCR"", ""FIELD2_SRC"", ""AMOUNT43"", ""CURREN64"", ""TYPE24"", ""RELATI29"", ""DATEAB63"", ""DATE71"", ""DATE_TYPE"", ""REL_DATE"", ""INTEGE18"", ""ACC_SRC"") AS 
  SELECT
CRITERION.TYPEFLAG,
            CRITERION.OPERAT44,
            CRITERION.SEQ97,
            TIMAPPINGS.CANAMDBAS,
            TIMAPPINGS.AMENDCHG,
            TIMAPPINGS.AUTOPRINT,
            TIMAPPINGS.SEVERITY,
            TIMAPPINGS.ERROR_TEXT,
            TIMAPPINGS.DEADLINEDAYS,
            TIMAPPINGS.DEADLINEDATE,
            TIMAPPINGS.DEADLINETIME,
            TIMAPPINGS.DEADLINERSECS,
            TIMAPPINGS.USEEVTFM,
            TIMAPPINGS.EVENTLONGNAME,
            TIMAPPINGS.USERNAME,
            TIMAPPINGS.TEAMCODE,
            TIMAPPINGS.MAPPINGTYPE,
            TIMAPPINGS.TEMPLATEID,
            TIMAPPINGS.OBSOLETE,
            TIMAPPINGS.OPTIONAL,
            TIMAPPINGS.PRODLONGNAME,
            TIMAPPINGS.RELEVMAPKEY,
            (case when TIMAPPINGS.attachment = 'e' then 'Event'
when TIMAPPINGS.attachment = 's' then 'Collection draft'
when TIMAPPINGS.attachment = 'p' then 'Payment'
when TIMAPPINGS.attachment = 'x' then 'Assignment'
when TIMAPPINGS.attachment = 'y' then 'Disbursement'
when TIMAPPINGS.attachment = 'l' then 'Cheque'
when TIMAPPINGS.attachment = 't' then 'Document'
when TIMAPPINGS.attachment = 'g' then 'Guarantee applicant'
when TIMAPPINGS.attachment = 'j' then 'Sub-guarantee amount total'
when TIMAPPINGS.attachment = '5' then 'New sub-guarantee applicant'
end)ATTACHMENT, 
TIMAPPINGS.STEPTYPE, 
TIMAPPINGS.AMBERDAYS, 
TIMAPPINGS.AMBERDATE, 
TIMAPPINGS.AMBERTIME, 
TIMAPPINGS.AMBERRSECS, 
TIMAPPINGS.REDDAYS, 
TIMAPPINGS.REDDATE, 
TIMAPPINGS.REDTIME, 
TIMAPPINGS.REDRSECS, 
TIMAPPINGS.PARAMSETID, 
TIMAPPINGS.MAPPINGID, 
TIMAPPINGS.PARAMSETDESCR, 
TIMAPPINGS.INUSE, 
TIMAPPINGS.INTINITSTEPID, 
TIMAPPINGS.SWINITSTEPID, 
TIMAPPINGS.BTINITSTEPID, 
TIMAPPINGS.GWINITSTEPID, 
TIMAPPINGS.SWREJSTEPID, 
TIMAPPINGS.BTREJSTEPID, 
TIMAPPINGS.GWREJSTEPID, 
TIMAPPINGS.MAPSTEPID, 
TIMAPPINGS.STEP_TIME, 
TIMAPPINGS.AVAIL_TYPE, 
TIMAPPINGS.TEMPLATEDESCR, 
TIMAPPINGS.TEAMDESCR, 
TIMAPPINGS.MAPPINGSUBID, 
TIMAPPINGS.DEBITCREDIT, 
TIMAPPINGS.TRANCODE, 
TIMAPPINGS.REV_PSTNGS, 
TIMAPPINGS.INTERN_ACC, 
TIMAPPINGS.CONTINGENT, 
TIMAPPINGS.LIABILITY, 
TIMAPPINGS.CHK_LIMIT, 
TIMAPPINGS.POSTINGTYP, 
TIMAPPINGS.MARGIN, 
TIMAPPINGS.TRCRSDLIAB, 
TIMAPPINGS.TRANS_ACC, 
TIMAPPINGS.PROJECTION, 
TIMAPPINGS.SEQUENCE, 
TIMAPPINGS.REJSTEPID, 
TIMAPPINGS.ACTUAL_AMT, 
TIMAPPINGS.AMT_CCY, 
TIMAPPINGS.MAPSTEPDESCR, 
TIMAPPINGS.REJSTEPDESCR, 
TIMAPPINGS.INTINITSTEPDESCR, 
TIMAPPINGS.SWINITSTEPDESCR, 
TIMAPPINGS.BTINITSTEPDESCR, 
TIMAPPINGS.GWINITSTEPDESCR, 
TIMAPPINGS.SWREJSTEPDESCR, 
TIMAPPINGS.BTREJSTEPDESCR, 
TIMAPPINGS.GWREJSTEPDESCR, 
TIMAPPINGS.DOMTYPE, 
TIMAPPINGS.DOMBEHAVIOUR, 
TIMAPPINGS.DOMNAME, 
TIMAPPINGS.DOMDEFAULT, 
TIMAPPINGS.DOMLINKCODE, 
TIMAPPINGS.DOMLINKNAME, 
TIMAPPINGS.DOMCODE, 
TIMAPPINGS.NEXTSTEPID, 
TIMAPPINGS.NEXTSTEPDESCR, 
TIMAPPINGS.FROMSTEPID, 
TIMAPPINGS.FROMSTEPDESCR, 
TIMAPPINGS.AMT_FIELD, 
TIMAPPINGS.LIABAMTTYP, 
TIMAPPINGS.BSPARAMSETID, 
TIMAPPINGS.BSPARAMSETDESCR, 
CRITERION.FIELD2_SRC, 
CRITERION.AMOUNT43, 
CRITERION.CURREN64, 
CRITERION.TYPE24, 
CRITERION.RELATI29, 
CRITERION.DATEAB63, 
CRITERION.DATE71, 
CRITERION.DATE_TYPE, 
CRITERION.REL_DATE, 
CRITERION.INTEGE18, 
TIMAPPINGS.ACC_SRC
            FROM

TIZONE2.TIMAPPINGS @TIZONE2_LINK  TIMAPPINGS, 
TIZONE2.CRITERION @TIZONE2_LINK  CRITERION

WHERE
            (TIMAPPINGS.RELEVMAPKEY = CRITERION.MAPPIN08(+))
            ");
            //ART_TI_WATCHLIST_OS_CHECK_REPORT
            migrationBuilder.Sql($@"
  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_WATCHLIST_OS_CHECK_REPORT"" (""DESCRI56"", ""LONGNA85"", ""REFNO_PFIX"", ""REFNO_SERL"", ""TOUCHED"", ""AMOUNT"", ""CCY"", ""AMOUNT_EGP"", ""FULLNAME"", ""WORKGROUP"", ""MASTER_REF"", ""CCY_CED"", ""BHALF_BRN"", ""PCPADDRESS1"", ""PCPGFCUN"", ""PCPCUS_MNM"", ""PCPSW_BANK"", ""PCPSW_CTR"", ""PCPSW_LOC"", ""PCPSW_BRANCH"", ""NPCPADDRESS1"", ""NPCPGFCUN"", ""NPCPCUS_MNM"", ""NPCPSW_BANK"", ""NPCPSW_CTR"", ""NPCPSW_LOC"", ""NPCPSW_BRANCH"", ""STARTED"", ""LANGUAGE"", ""SHORTNAME"", ""STATUS"", ""ISFINISHED"", ""TYPE"", ""LSTMODUSER"", ""DESCR"") AS 
  SELECT
 TEAM.DESCRI56,
            EXEMPL30.LONGNA85,
            BASEEVENT.REFNO_PFIX,
            BASEEVENT.REFNO_SERL,
            BASEEVENT.TOUCHED,
            (BASEEVENT.AMOUNT / power(10, c8pf.c8ced)) AMOUNT,
            BASEEVENT.CCY,
            ((BASEEVENT.AMOUNT / power(10, c8pf.c8ced)) * SPOTRATE.SPOTRATE)AS AMOUNT_EGP,
            CAPF.FULLNAME,
            ALLRPTMSTRS.WORKGROUP,
            ALLRPTMSTRS.MASTER_REF,
            CCYDTLS.CCY_CED,
            ALLRPTMSTRS.BHALF_BRN,
            TRIM(regexp_replace(regexp_replace(regexp_replace(PCP_PARTY.ADDRESS1, chr(13), ''), chr(10), ''), chr(9), '')) PCPADDRESS1,
            PCP_PARTY.GFCUN PCPGFCUN,
            PCP_PARTY.CUS_MNM PCPCUS_MNM,
            PCP_PARTY.SW_BANK PCPSW_BANK,
            PCP_PARTY.SW_CTR PCPSW_CTR,
            PCP_PARTY.SW_LOC PCPSW_LOC,
            PCP_PARTY.SW_BRANCH PCPSW_BRANCH,
            TRIM(regexp_replace(regexp_replace(regexp_replace(NPCP_PARTY.ADDRESS1, chr(13), ''), chr(10), ''), chr(9), '')) NPCPADDRESS1,
            NPCP_PARTY.GFCUN NPCPGFCUN,
            NPCP_PARTY.CUS_MNM NPCPCUS_MNM,
            NPCP_PARTY.SW_BANK NPCPSW_BANK,
            NPCP_PARTY.SW_CTR NPCPSW_CTR,
            NPCP_PARTY.SW_LOC NPCPSW_LOC,
            NPCP_PARTY.SW_BRANCH NPCPSW_BRANCH,
            TO_TIMESTAMP(regexp_replace(EVENTTSTAMPS.STARTED, '(.{10}).(.+)', '\1 \2'), 'YYYY-MM-DD HH24:MI:SS') STARTED,
            EVENTSHORTNAME.LANGUAGE,
            EVENTSHORTNAME.SHORTNAME,
            (case
when eventstep.status = 'i' then 'Initiated'
when eventstep.status = 'd' then 'Assigned'
when eventstep.status = 'p' then 'Pended'
when eventstep.status = 'w' then 'Awaiting'
when eventstep.status = 'r' then 'Requested'
when eventstep.status = 'q' then 'Received'
when eventstep.status = 'j' then 'Rejected'
when eventstep.status = 't' then 'Returned'
when eventstep.status = 'a' then 'Aborted'
when eventstep.status = 'c' then 'Completed'
end)
 STATUS,
 EVENTSTEP.ISFINISHED,
 EVENTSTEP.TYPE,
 EVENTSTEP.LSTMODUSER,
 ORCH_STEP.DESCR
            FROM
 TIZONE2.ALLRPTMSTRS @TIZONE2_LINK ALLRPTMSTRS,
 TIZONE2.RPTPARTIES @TIZONE2_LINK PCP_PARTY,
 TIZONE2.RPTPARTIES @TIZONE2_LINK NPCP_PARTY,
 TIZONE2.WORKGR44 @TIZONE2_LINK TEAM,
 TIZONE2.BASEEVENT @TIZONE2_LINK BASEEVENT,
 TIZONE2.CAPF @TIZONE2_LINK CAPF,
 TIZONE2.EVENTTSTAMPS @TIZONE2_LINK EVENTTSTAMPS, 
 TIZONE2.EVENTCCY @TIZONE2_LINK EVENTCCY,
 TIZONE2.EVENTSHORTNAME @TIZONE2_LINK EVENTSHORTNAME, 
 TIZONE2.EVENTSTEP @TIZONE2_LINK EVENTSTEP, 
 TIZONE2.CCYDTLS @TIZONE2_LINK CCYDTLS , 
 TIZONE2.STEPHIST @TIZONE2_LINK,
            TIZONE2.ORCH_MAP @TIZONE2_LINK,
            TIZONE2.ORCH_STEP @TIZONE2_LINK,
            TIZONE2.EXEMPL30 @TIZONE2_LINK,
            TIZONE2.C8PF @TIZONE2_LINK,
            TIZONE2.SPOTRATE @TIZONE2_LINK

 WHERE(ALLRPTMSTRS.PCP_PTY = PCP_PARTY.PARTYKEY) AND
            (ALLRPTMSTRS.NPCP_PTY = NPCP_PARTY.PARTYKEY) AND
            (ALLRPTMSTRS.WORKGROUP = TEAM.CODE79(+)) AND
            (ALLRPTMSTRS.KEY97 = BASEEVENT.MASTER_KEY) AND
            (ALLRPTMSTRS.BHALF_BRN = CAPF.CABRNM) AND
            (BASEEVENT.KEY97 = EVENTTSTAMPS.EVENTKEY) AND
            (BASEEVENT.KEY97 = EVENTCCY.EVENTKEY) AND
            (BASEEVENT.KEY97 = EVENTSHORTNAME.EVENTKEY) AND
            (BASEEVENT.KEY97 = EVENTSTEP.EVENT_KEY) AND
            ((EVENTCCY.CCY = CCYDTLS.CCY_CODE) AND
            (EVENTCCY.SBB_BRN = CCYDTLS.MBE)) AND
            (STEPHIST.EVENT_KEY = BASEEVENT.KEY97) AND
            (ORCH_MAP.KEY97 = STEPHIST.ORCH_MAP) AND
            (ORCH_STEP.KEY97 = ORCH_MAP.ORCH_STEP) AND
            (EXEMPL30.KEY97 = ALLRPTMSTRS.EXEMPLAR) AND
            (EVENTSTEP.ISFINISHED = 'N')--AND ORCH_STEP.KEY97 = 22
  AND(BASEEVENT.CCY = c8pf.C8CCY(+))
  AND(BASEEVENT.CCY = SPOTRATE.currency(+) AND SPOTRATE.branch = 'BMEG')
 ORDER BY ALLRPTMSTRS.BHALF_BRN, ALLRPTMSTRS.WORKGROUP, ALLRPTMSTRS.MASTER_REF
            ");
            //ART_TI_ECM_AUDIT_REPORT
            migrationBuilder.Sql($@"
            CREATE OR REPLACE FORCE NONEDITIONABLE VIEW ""ART"".""ART_TI_ECM_AUDIT_REPORT"" (""ECM_REFERENCE"", ""BRANCH_ID"", ""ECM_CASE_CREATION_DATE"", ""CUTOMER_NAME"", ""PRODUCT"", ""PRODUCTTYPE"", ""ECM_EVENT"", ""TRANSACTION_AMOUNT"", ""TRANSACTION_CURRENCY"", ""PRIMARY_OWNER"", ""CASE_STAT_CD"", ""UPDATE_USER_ID"", ""COMMENTS"", ""FTI_REFERENCE"", ""EVENT_NAME"", ""EVENT_STATUS"", ""EVENT_CREATION_DATE"", ""MASTER_ASSIGNED_TO"", ""EVENT_STEPS"", ""STEP_STATUS"") AS 
                                      select 
                                    Case_Id ECM_Reference,
                                    behalfOfBranch Branch_ID,
                                    Create_Date ECM_Case_Creation_Date,
                                    applicantName Cutomer_Name,
                                    prod.val_desc product,
                                    prodtype.val_desc productType,
                                    event.val_desc ECM_Event,
                                    transaction_amount , 
                                    transaction_currency,
                                    primary_Owner,
                                    Case_Stat_Cd,
                                    a.update_user_id,
                                    comm.DESCRIPTION Comments,
                                    mstr.master_ref FTI_Reference,
                                    evname.longna85 Event_Name,
                                    (case when Baseevent.STATUS ='i' then 'In progress' 
                                    when Baseevent.STATUS ='c' then 'Completed'
                                    when Baseevent.STATUS ='a' then 'Aborted'
                                    end) Event_Status,
                                    baseevent.start_date Event_Creation_Date,
                                    evstp.ASSNTOUNME Master_Assigned_To,
                                    (case
                                    when evstp.type='x' then 'Abort'
                                    when evstp.type='a1' then 'Review'
                                    when evstp.type='a2' then 'Final review'
                                    when evstp.type='c' then 'Create'
                                    when evstp.type='i' then 'Input'
                                    when evstp.type='l' then 'Log'
                                    when evstp.type='r' then 'Release'
                                    when evstp.type='-' then 'Complete'
                                    when evstp.type='c1' then 'Limit check'
                                    when evstp.type='c2' then 'Final limit check'
                                    when evstp.type='g' then 'Gateway'
                                    when evstp.type='s' then 'SWIFT In'
                                    when evstp.type='rf' then 'Rate fixing'
                                    when evstp.type='a%' then '*Review/Final review*'
                                    when evstp.type='ra' then 'Fix auth'
                                    when evstp.type='m' then 'Limit approval'
                                    when evstp.type='fp' then 'Print'
                                    when evstp.type='w' then 'Watch list check'
                                    when evstp.type='rp' then 'Release pending'
                                    when evstp.type='pr' then 'Post release'
                                    when evstp.type='ie' then 'Exchange'
                                    when evstp.type='er' then 'External review'
                                    when evstp.type='in' then 'Internal'
                                    when evstp.type='sy' then 'Synchronisation'
                                    when evstp.type='b' then 'Batch'
                                    when evstp.type='gi' then 'Gwy auto input'
                                    when evstp.type='bi' then 'EoD auto input'
                                    when evstp.type='ci' then 'Int auto input'
                                    when evstp.type='si' then 'Swft auto input'
                                    when evstp.type='ar' then 'Auto reject'
                                    end
                                    )Event_Steps,
                                    (case
                                    when evstp.STATUS ='i' then 'Initiated'
                                    when evstp.STATUS ='d' then 'Assigned'
                                    when evstp.STATUS ='p' then 'Pended'
                                    when evstp.STATUS ='w' then 'Awaiting'
                                    when evstp.STATUS ='r' then 'Requested'
                                    when evstp.STATUS ='q' then 'Received'
                                    when evstp.STATUS ='j' then 'Rejected'
                                    when evstp.STATUS ='t' then 'Returned'
                                    when evstp.STATUS ='a' then 'Aborted'
                                    when evstp.STATUS ='c' then 'Completed'
                                    end
                                    ) STEP_STATUS
                                    --note.note_text Note
                                    from
                                    dgcmgmt.case_live@DGDB_DGCMGMT a 
                                    left join dgcmgmt.ref_table_val@DGDB_DGCMGMT prod on a.product=prod.val_cd
                                    left join dgcmgmt.ref_table_val@DGDB_DGCMGMT prodtype on a.producttype=prodtype.val_cd
                                    left join dgcmgmt.ref_table_val@DGDB_DGCMGMT event on a.eventname=event.val_cd
                                    left join DGECM_METADATA.COMMENTS@DGDB_DGECM_METADATA comm on a.case_rk=comm.entity_rk
                                    left join TIZONE2.extevent@TIZONE2_LINK ext on a.case_id=trim(ext.ecm_ref)
                                    left join TIZONE2.Baseevent@TIZONE2_LINK on Baseevent.key97 = ext.event
                                    left join TIZONE2.master@TIZONE2_LINK mstr on Baseevent.master_key = mstr.key97
                                    left join TIZONE2.EXEMPL30@TIZONE2_LINK evname on mstr.exemplar = evname.key97
                                    left join TIZONE2.EVENTSTEP@TIZONE2_LINK evstp on BASEEVENT.KEY97=evstp.EVENT_KEY
                                    left join TIZONE2.EVENTSTEPNAMES@TIZONE2_LINK on evstp.KEY97=EVENTSTEPNAMES.STEPKEY");
            #endregion
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
