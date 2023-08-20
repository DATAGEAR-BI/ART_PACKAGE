using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.Segmentation
{
    public partial class SegmentationQueries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View ART_MEB_SEGMENTS_V3
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_MEB_SEGMENTS_V3"" (""MONTH_KEY"", ""PARTY_NUMBER"", ""RISK_CLASSIFICATION"", ""PARTY_TYPE_DESC"", ""INDUSTRY_CODE"", ""INDUSTRY_DESC"", ""OCCUPATION_DESC"", ""SEGMENT_SORTED"", ""AVG_TOTAL_AMT"", ""TOTAL_AMOUNT"", ""MIN_TOTAL_AMT"", ""MAX_TOTAL_AMT"", ""TOTAL_CNT"", ""TOTAL_CREDIT_AMOUNT"", ""AVG_TOTAL_CT_AMT"", ""MIN_TOTAL_CT_AMT"", ""MAX_TOTAL_CT_AMT"", ""TOTAL_CT_CNT"", ""TOTAL_DEBIT_AMOUNT"", ""TOTAL_DEBIT_CNT"", ""AVG_TOTAL_DT_AMT"", ""MAX_TOTAL_DT_AMT"", ""MIN_TOTAL_DT_AMT"", ""AVG_WIRE_C_AMT"", ""MAX_WIRE_C_AMT"", ""TOTAL_WIRE_C_AMT"", ""MIN_WIRE_C_AMT"", ""TOTAL_WIRE_C_CNT"", ""AVG_WIRE_D_AMT"", ""MAX_WIRE_D_AMT"", ""TOTAL_WIRE_D_AMT"", ""MIN_WIRE_D_AMT"", ""TOTAL_WIRE_D_CNT"", ""TOTAL_CASH_C_AMT"", ""TOTAL_CASH_C_CNT"", ""MIN_CASH_C_AMT"", ""AVG_CASH_C_AMT"", ""MAX_CASH_C_AMT"", ""TOTAL_CASH_D_AMT"", ""TOTAL_CASH_D_CNT"", ""AVG_CASH_D_AMT"", ""MIN_CASH_D_AMT"", ""MAX_CASH_D_AMT"", ""TOTAL_CHECK_D_CNT"", ""AVG_CHECK_D_AMT"", ""MAX_CHECK_D_AMT"", ""TOTAL_CHECK_D_AMT"", ""MIN_CHECK_D_AMT"", ""MAX_INTERNALTRANSFER_C_AMT"", ""MIN_INTERNALTRANSFER_C_AMT"", ""TOTAL_INTERNALTRANSFER_C_CNT"", ""TOTAL_INTERNALTRANSFER_C_AMT"", ""AVG_INTERNALTRANSFER_C_AMT"", ""MIN_INTERNALTRANSFER_D_AMT"", ""TOTAL_INTERNALTRANSFER_D_CNT"", ""AVG_INTERNALTRANSFER_D_AMT"", ""TOTAL_INTERNALTRANSFER_D_AMT"", ""MAX_INTERNALTRANSFER_D_AMT"", ""TOTAL_MISC_C_CNT"", ""AVG_MISC_C_AMT"", ""TOTAL_MISC_C_AMT"", ""MIN_MISC_C_AMT"", ""MAX_MISC_C_AMT"", ""TOTAL_WITHDRAWAL_D_CNT"", ""AVG_WITHDRAWAL_D_AMT"", ""TOTAL_WITHDRAWAL_D_AMT"", ""MIN_WITHDRAWAL_D_AMT"", ""MAX_WITHDRAWAL_D_AMT"", ""TOTAL_FEES_D_CNT"", ""AVG_FEES_D_AMT"", ""TOTAL_FEES_D_AMT"", ""MIN_FEES_D_AMT"", ""MAX_FEES_D_AMT"", ""MAX_MLS"", ""ALERTS_CNT"") AS 
  SELECT 
       MONTH_KEY
      ,PARTY_NUMBER
      ,RISK_CLASSIFICATION
      ,PARTY_TYPE_DESC
      ,INDUSTRY_CODE
      ,INDUSTRY_DESC
      ,OCCUPATION_DESC
      ,segment_sorted
      
      ,SUM(AVG_TOT_AMT) AVG_TOTAL_AMT
      ,SUM(TOT_AMOUNT) TOTAL_AMOUNT
      ,SUM(MIN_TOT_AMT) MIN_TOTAL_AMT
      ,SUM(MAX_TOT_AMT) MAX_TOTAL_AMT
      ,SUM(TOT_CNT) TOTAL_CNT
      
      
      ,SUM(TOT_CREDIT_AMOUNT) TOTAL_CREDIT_AMOUNT
      ,SUM(AVG_TOT_C_AMT) AVG_TOTAL_CT_AMT
      ,SUM(MIN_TOT_C_AMT) MIN_TOTAL_CT_AMT
      ,SUM(MAX_TOT_C_AMT) MAX_TOTAL_CT_AMT
      ,SUM(TOT_CREDIT_CNT) TOTAL_CT_CNT
      
      ,SUM(TOT_DEBIT_AMOUNT) TOTAL_DEBIT_AMOUNT
      ,SUM(TOT_DEBIT_CNT) TOTAL_DEBIT_CNT

      ,SUM(AVG_TOT_D_AMT) AVG_TOTAL_DT_AMT
      ,SUM(MAX_TOT_D_AMT) MAX_TOTAL_DT_AMT
      ,SUM(MIN_TOT_D_AMT) MIN_TOTAL_DT_AMT
      
      ,SUM(AVG_WIRE_C_AMT) AVG_WIRE_C_AMT																																																																																																																																																																																																																																																																																																																																																																																																																																																									
      ,SUM(MAX_WIRE_C_AMT) MAX_WIRE_C_AMT
      ,SUM(TOT_WIRE_C_AMT) TOTAL_WIRE_C_AMT
      ,SUM(MIN_WIRE_C_AMT) MIN_WIRE_C_AMT
      ,SUM(TOT_WIRE_C_CNT) TOTAL_WIRE_C_CNT
      
      ,SUM(AVG_WIRE_D_AMT) AVG_WIRE_D_AMT
      ,SUM(MAX_WIRE_D_AMT) MAX_WIRE_D_AMT
      ,SUM(TOT_WIRE_D_AMT) TOTAL_WIRE_D_AMT
      ,SUM(MIN_WIRE_D_AMT) MIN_WIRE_D_AMT
      ,SUM(TOT_WIRE_D_CNT) TOTAL_WIRE_D_CNT
      
      ,SUM(TOT_CASH_C_AMT) TOTAL_CASH_C_AMT
      ,SUM(TOT_CASH_C_CNT) TOTAL_CASH_C_CNT
      ,SUM(MIN_CASH_C_AMT) MIN_CASH_C_AMT
      ,SUM(AVG_CASH_C_AMT) AVG_CASH_C_AMT																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																						
      ,SUM(MAX_CASH_C_AMT) MAX_CASH_C_AMT
      
      ,SUM(TOT_CASH_D_AMT)TOTAL_CASH_D_AMT
      ,SUM(TOT_CASH_D_CNT) TOTAL_CASH_D_CNT
      ,SUM(AVG_CASH_D_AMT) AVG_CASH_D_AMT
      ,SUM(MIN_CASH_D_AMT) MIN_CASH_D_AMT
      ,SUM(MAX_CASH_D_AMT) MAX_CASH_D_AMT
      
      ,SUM(TOT_CHECK_D_CNT) TOTAL_CHECK_D_CNT
      ,SUM(AVG_CHECK_D_AMT) AVG_CHECK_D_AMT
      ,SUM(MAX_CHECK_D_AMT) MAX_CHECK_D_AMT
      ,SUM(TOT_CHECK_D_AMT) TOTAL_CHECK_D_AMT
      ,SUM(MIN_CHECK_D_AMT) MIN_CHECK_D_AMT
      
      ,SUM(MAX_INTERNAL_TRANSFER_C_AMT) MAX_INTERNALTRANSFER_C_AMT
      ,SUM(MIN_INTERNAL_TRANSFER_C_AMT) MIN_INTERNALTRANSFER_C_AMT
      ,SUM(TOT_INTERNAL_TRANSFER_C_CNT)  TOTAL_INTERNALTRANSFER_C_CNT
      ,SUM(TOT_INTERNAL_TRANSFER_C_AMT)  TOTAL_INTERNALTRANSFER_C_AMT
      ,SUM(AVG_INTERNAL_TRANSFER_C_AMT) AVG_INTERNALTRANSFER_C_AMT
      
      ,SUM(MIN_INTERNAL_TRANSFER_D_AMT) MIN_INTERNALTRANSFER_D_AMT
      ,SUM(TOT_INTERNAL_TRANSFER_D_CNT)  TOTAL_INTERNALTRANSFER_D_CNT
      ,SUM(AVG_INTERNAL_TRANSFER_D_AMT) AVG_INTERNALTRANSFER_D_AMT
      ,SUM(TOT_INTERNAL_TRANSFER_D_AMT) TOTAL_INTERNALTRANSFER_D_AMT
      ,SUM(MAX_INTERNAL_TRANSFER_D_AMT) MAX_INTERNALTRANSFER_D_AMT
      
      ,SUM(TOT_MISC_C_CNT) TOTAL_MISC_C_CNT
      ,SUM(AVG_MISC_C_AMT) AVG_MISC_C_AMT
      ,SUM(TOT_MISC_C_AMT) TOTAL_MISC_C_AMT
      ,SUM(MIN_MISC_C_AMT) MIN_MISC_C_AMT
      ,SUM(MAX_MISC_C_AMT) MAX_MISC_C_AMT
      
      ,SUM(TOT_DEBIT_CARD_D_CNT) TOTAL_WITHDRAWAL_D_CNT
      ,SUM(AVG_DEBIT_CARD_D_AMT) AVG_WITHDRAWAL_D_AMT
      ,SUM(TOT_DEBIT_CARD_D_AMT) TOTAL_WITHDRAWAL_D_AMT
      ,SUM(MIN_DEBIT_CARD_D_AMT) MIN_WITHDRAWAL_D_AMT
      ,SUM(MAX_DEBIT_CARD_D_AMT) MAX_WITHDRAWAL_D_AMT
      
      
      ,SUM(TOT_FEE_D_CNT) TOTAL_FEES_D_CNT
      ,SUM(AVG_FEE_D_AMT) AVG_FEES_D_AMT
      ,SUM(TOT_FEE_D_AMT) TOTAL_FEES_D_AMT
      ,SUM(MIN_FEE_D_AMT) MIN_FEES_D_AMT
      ,SUM(MAX_FEE_D_AMT) MAX_FEES_D_AMT
      
      ,SUM(MAX_MLS) MAX_MLS
      ,SUM(ALERTS_CNT) ALERTS_CNT
      
  FROM fcfkc.MEB_SEGMENTS_V3_BK
GROUP BY
       MONTH_KEY
      ,PARTY_NUMBER
      ,RISK_CLASSIFICATION
      ,PARTY_TYPE_DESC
      ,INDUSTRY_CODE
      ,INDUSTRY_DESC
      ,OCCUPATION_DESC
      ,segment_sorted
;");


            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_MEB_SEGMENTS_V3_TB');
   if c > 0 then
      execute immediate 'drop table ART_MEB_SEGMENTS_V3_TB';
   end if;
     execute immediate 'CREATE TABLE ART_MEB_SEGMENTS_V3_TB AS SELECT * FROM ART_MEB_SEGMENTS_V3';
end;");




            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View ART_ALL_SEGS_OUTLIERS_LIMIT
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_ALL_SEGS_OUTLIERS_LIMIT"" (""MONTH_KEY"", ""SEGMENT_SORTED"", ""PARTY_TYPE_DESC"", ""FEATURE"", ""UPPER_OUTLIER_LIMIT"") AS 
  select 
month_key,
segment_sorted,
party_type_desc,
'TOTAL_CASH_C_AMT' feature,
round(avg(Upper_outlier_limit),2) Upper_outlier_limit
from
(
select 
a.month_key,
a.party_type_desc,
a.segment_sorted,
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY a.TOTAL_CASH_C_AMT) OVER (PARTITION BY a.segment_sorted))+
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY a.TOTAL_CASH_C_AMT) OVER (PARTITION BY a.segment_sorted)) - 
 (PERCENTILE_DISC (0.25) WITHIN GROUP (ORDER BY a.TOTAL_CASH_C_AMT) OVER (PARTITION BY a.segment_sorted))
 )*1.5
 )Upper_outlier_limit
FROM 
ART.ART_MEB_SEGMENTS_V3_TB a
)aa
group by 
month_key,
party_type_desc,
segment_sorted

UNION ALL

/*TOTAL_CASH_D_AMT*/

select 
month_key,
segment_sorted,
party_type_desc,
'TOTAL_CASH_D_AMT' feature,
round(avg(Upper_outlier_limit),2) Upper_outlier_limit
from
(
select 
a.month_key,
a.party_type_desc,
a.segment_sorted,
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY a.TOTAL_CASH_D_AMT) OVER (PARTITION BY a.segment_sorted))+
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY a.TOTAL_CASH_D_AMT) OVER (PARTITION BY a.segment_sorted)) - 
 (PERCENTILE_DISC (0.25) WITHIN GROUP (ORDER BY a.TOTAL_CASH_D_AMT) OVER (PARTITION BY a.segment_sorted))
 )*1.5
 )Upper_outlier_limit
FROM 
ART.ART_MEB_SEGMENTS_V3_TB a
)aa
group by 
month_key,
party_type_desc,
segment_sorted 

UNION ALL

/*TOTAL_WIRE_C_AMT*/

select 
month_key,
segment_sorted,
party_type_desc,
'TOTAL_WIRE_C_AMT' feature,
round(avg(Upper_outlier_limit),2) Upper_outlier_limit
from
(
select 
a.month_key,
a.party_type_desc,
a.segment_sorted,
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY a.TOTAL_WIRE_C_AMT) OVER (PARTITION BY a.segment_sorted))+
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY a.TOTAL_WIRE_C_AMT) OVER (PARTITION BY a.segment_sorted)) - 
 (PERCENTILE_DISC (0.25) WITHIN GROUP (ORDER BY a.TOTAL_WIRE_C_AMT) OVER (PARTITION BY a.segment_sorted))
 )*1.5
 )Upper_outlier_limit
FROM 
ART.ART_MEB_SEGMENTS_V3_TB a
)aa
group by 
month_key,
party_type_desc,
segment_sorted 

UNION ALL

/*TOTAL_WIRE_D_AMT*/

select 
month_key,
segment_sorted,
party_type_desc,
'TOTAL_WIRE_D_AMT' feature,
round(avg(Upper_outlier_limit),2) Upper_outlier_limit
from
(
select 
a.month_key,
a.party_type_desc,
a.segment_sorted,
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY (A.TOTAL_WIRE_D_AMT)) OVER (PARTITION BY a.segment_sorted))+
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY (A.TOTAL_WIRE_D_AMT)) OVER (PARTITION BY a.segment_sorted)) - 
 (PERCENTILE_DISC (0.25) WITHIN GROUP (ORDER BY (A.TOTAL_WIRE_D_AMT)) OVER (PARTITION BY a.segment_sorted))
 )*1.5
 )Upper_outlier_limit
FROM 
ART.ART_MEB_SEGMENTS_V3_TB a
)aa
group by 
month_key,
party_type_desc,
segment_sorted 

UNION ALL

/*TOTAL_CHECK_D_AMT*/

select 
month_key,
segment_sorted,
party_type_desc,
'TOTAL_CHECK_D_AMT' feature,
round(avg(Upper_outlier_limit),2) Upper_outlier_limit
from
(
select 
a.month_key,
a.party_type_desc,
a.segment_sorted,
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY (A.TOTAL_CHECK_D_AMT)) OVER (PARTITION BY a.segment_sorted))+
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY (A.TOTAL_CHECK_D_AMT)) OVER (PARTITION BY a.segment_sorted)) - 
 (PERCENTILE_DISC (0.25) WITHIN GROUP (ORDER BY (A.TOTAL_CHECK_D_AMT)) OVER (PARTITION BY a.segment_sorted))
 )*1.5
 )Upper_outlier_limit
FROM 
ART.ART_MEB_SEGMENTS_V3_TB a
)aa
group by 
month_key,
party_type_desc,
segment_sorted 



UNION ALL

/*TOTAL_INTERNALTRANSFER_C_AMT*/
select 
month_key,
segment_sorted,
party_type_desc,
'TOTAL_INTERNALTRANSFER_C_AMT' feature,
round(avg(Upper_outlier_limit),2) Upper_outlier_limit
from
(
select 
a.month_key,
a.party_type_desc,
a.segment_sorted,
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY TOTAL_INTERNALTRANSFER_C_AMT) OVER (PARTITION BY a.segment_sorted))+
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY TOTAL_INTERNALTRANSFER_C_AMT) OVER (PARTITION BY a.segment_sorted)) - 
 (PERCENTILE_DISC (0.25) WITHIN GROUP (ORDER BY TOTAL_INTERNALTRANSFER_C_AMT) OVER (PARTITION BY a.segment_sorted))
 )*1.5
 )Upper_outlier_limit
FROM 
ART.ART_MEB_SEGMENTS_V3_TB a
)aa
group by 
month_key,
party_type_desc,
segment_sorted

UNION ALL

/*TOTAL_INTERNALTRANSFER_D_AMT*/
select 
month_key,
segment_sorted,
party_type_desc,
'TOTAL_INTERNALTRANSFER_D_AMT' feature,
round(avg(Upper_outlier_limit),2) Upper_outlier_limit
from
(
select 
a.month_key,
a.party_type_desc,
a.segment_sorted,
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY TOTAL_INTERNALTRANSFER_D_AMT) OVER (PARTITION BY a.segment_sorted))+
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY TOTAL_INTERNALTRANSFER_D_AMT) OVER (PARTITION BY a.segment_sorted)) - 
 (PERCENTILE_DISC (0.25) WITHIN GROUP (ORDER BY TOTAL_INTERNALTRANSFER_D_AMT) OVER (PARTITION BY a.segment_sorted))
 )*1.5
 )Upper_outlier_limit
FROM 
ART.ART_MEB_SEGMENTS_V3_TB a
)aa
group by 
month_key,
party_type_desc,
segment_sorted

UNION ALL

/*TOTAL_MISC_C_AMT*/
select 
month_key,
segment_sorted,
party_type_desc,
'TOTAL_MISC_C_AMT' feature,
round(avg(Upper_outlier_limit),2) Upper_outlier_limit
from
(
select 
a.month_key,
a.party_type_desc,
a.segment_sorted,
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY a.TOTAL_MISC_C_AMT) OVER (PARTITION BY a.segment_sorted))+
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY a.TOTAL_MISC_C_AMT) OVER (PARTITION BY a.segment_sorted)) - 
 (PERCENTILE_DISC (0.25) WITHIN GROUP (ORDER BY a.TOTAL_MISC_C_AMT) OVER (PARTITION BY a.segment_sorted))
 )*1.5
 )Upper_outlier_limit
FROM 
ART.ART_MEB_SEGMENTS_V3_TB a
)aa
group by 
month_key,
party_type_desc,
segment_sorted


UNION ALL

/*TOTAL_WITHDRAWAL_D_AMT*/
select 
month_key,
segment_sorted,
party_type_desc,
'TOTAL_WITHDRAWAL_D_AMT' feature,
round(avg(Upper_outlier_limit),2) Upper_outlier_limit
from
(
select 
a.month_key,
a.party_type_desc,
a.segment_sorted,
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY (TOTAL_WITHDRAWAL_D_AMT)) OVER (PARTITION BY a.segment_sorted))+
 ((PERCENTILE_DISC (0.75) WITHIN GROUP (ORDER BY (TOTAL_WITHDRAWAL_D_AMT)) OVER (PARTITION BY a.segment_sorted)) - 
 (PERCENTILE_DISC (0.25) WITHIN GROUP (ORDER BY (TOTAL_WITHDRAWAL_D_AMT)) OVER (PARTITION BY a.segment_sorted))
 )*1.5
 )Upper_outlier_limit
FROM 
ART.ART_MEB_SEGMENTS_V3_TB a
)aa
group by 
month_key,
party_type_desc,
segment_sorted
;");

            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) INTO c from user_tables where table_name = upper('ART_ALL_SEGS_OUTLIERS_LIMIT_TB');
   if c > 0 then
      execute immediate 'drop table ART_ALL_SEGS_OUTLIERS_LIMIT_TB';
   end if;
    execute immediate 'CREATE TABLE ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB AS SELECT * FROM ART.ART_ALL_SEGS_OUTLIERS_LIMIT';
end;

");



            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View ART_ALL_SEGMENT_CUST_COUNT
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_ALL_SEGMENT_CUST_COUNT"" (""MONTH_KEY"", ""SEGMENT_SORTED"", ""PARTY_TYPE_DESC"", ""NUMBER_OF_CUSTOMERS"") AS 
  select 
Month_Key,
segment_sorted,
PARTY_TYPE_DESC,
count(party_number) Number_Of_Customers
from ART.ART_MEB_SEGMENTS_V3_TB group by Month_Key,
segment_sorted,
PARTY_TYPE_DESC
;");


            migrationBuilder.Sql($@"--------------------------------------------------------
--  DDL for View ART_ALL_SEGS_FEATRS_STATCS
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_ALL_SEGS_FEATRS_STATCS"" (""MONTH_KEY"", ""SEGMENT_SORTED"", ""PARTY_TYPE_DESC"", ""AVG_TOTAL_AMT"", ""TOTAL_AMOUNT"", ""MIN_TOTAL_AMT"", ""MAX_TOTAL_AMT"", ""TOTAL_CNT"", ""TOTAL_CREDIT_AMOUNT"", ""AVG_TOTAL_CT_AMT"", ""MIN_TOTAL_CT_AMT"", ""MAX_TOTAL_CT_AMT"", ""TOTAL_CT_CNT"", ""TOTAL_DEBIT_AMOUNT"", ""TOTAL_DEBIT_CNT"", ""AVG_TOTAL_DT_AMT"", ""MAX_TOTAL_DT_AMT"", ""MIN_TOTAL_DT_AMT"", ""AVG_WIRE_C_AMT"", ""MAX_WIRE_C_AMT"", ""TOTAL_WIRE_C_AMT"", ""MIN_WIRE_C_AMT"", ""TOTAL_WIRE_C_CNT"", ""AVG_WIRE_D_AMT"", ""MAX_WIRE_D_AMT"", ""TOTAL_WIRE_D_AMT"", ""MIN_WIRE_D_AMT"", ""TOTAL_WIRE_D_CNT"", ""TOTAL_CASH_C_AMT"", ""TOTAL_CASH_C_CNT"", ""MIN_CASH_C_AMT"", ""AVG_CASH_C_AMT"", ""MAX_CASH_C_AMT"", ""TOTAL_CASH_D_AMT"", ""TOTAL_CASH_D_CNT"", ""AVG_CASH_D_AMT"", ""MIN_CASH_D_AMT"", ""MAX_CASH_D_AMT"", ""TOTAL_CHECK_D_CNT"", ""AVG_CHECK_D_AMT"", ""MAX_CHECK_D_AMT"", ""TOTAL_CHECK_D_AMT"", ""MIN_CHECK_D_AMT"", ""MAX_INTERNALTRANSFER_C_AMT"", ""MIN_INTERNALTRANSFER_C_AMT"", ""TOTAL_INTERNALTRANSFER_C_CNT"", ""TOTAL_INTERNALTRANSFER_C_AMT"", ""AVG_INTERNALTRANSFER_C_AMT"", ""MIN_INTERNALTRANSFER_D_AMT"", ""TOTAL_INTERNALTRANSFER_D_CNT"", ""AVG_INTERNALTRANSFER_D_AMT"", ""TOTAL_INTERNALTRANSFER_D_AMT"", ""MAX_INTERNALTRANSFER_D_AMT"", ""TOTAL_MISC_C_CNT"", ""AVG_MISC_C_AMT"", ""TOTAL_MISC_C_AMT"", ""MIN_MISC_C_AMT"", ""MAX_MISC_C_AMT"", ""TOTAL_WITHDRAWAL_D_CNT"", ""AVG_WITHDRAWAL_D_AMT"", ""TOTAL_WITHDRAWAL_D_AMT"", ""MIN_WITHDRAWAL_D_AMT"", ""MAX_WITHDRAWAL_D_AMT"", ""TOTAL_FEES_D_CNT"", ""AVG_FEES_D_AMT"", ""TOTAL_FEES_D_AMT"", ""MIN_FEES_D_AMT"", ""MAX_FEES_D_AMT"") AS 
  SELECT 
MONTH_KEY
,segment_sorted
,PARTY_TYPE_DESC      

,FLOOR(SUM(TOTAL_AMOUNT)/NULLIF(SUM(TOTAL_CNT),0)) AVG_TOTAL_AMT
,FLOOR(SUM(TOTAL_AMOUNT))  TOTAL_AMOUNT
--,FLOOR(MIN_TOTAL_AMT) MIN_TOTAL_AMT
,(SELECT FLOOR(MIN(AA.MIN_TOTAL_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_TOTAL_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_TOTAL_AMT
,FLOOR(MAX(MAX_TOTAL_AMT)) MAX_TOTAL_AMT
,FLOOR(SUM(TOTAL_CNT)) TOTAL_CNT

,FLOOR(SUM(TOTAL_CREDIT_AMOUNT)) TOTAL_CREDIT_AMOUNT
,FLOOR(SUM(TOTAL_CREDIT_AMOUNT)/NULLIF(SUM(TOTAL_CT_CNT),0)) AVG_TOTAL_CT_AMT
--,FLOOR(MIN(MIN_TOTAL_CT_AMT)) MIN_TOTAL_CT_AMT
,(SELECT FLOOR(MIN(AA.MIN_TOTAL_CT_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_TOTAL_CT_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_TOTAL_CT_AMT
,FLOOR(MAX(MAX_TOTAL_CT_AMT)) MAX_TOTAL_CT_AMT
,FLOOR(SUM(TOTAL_CT_CNT)) TOTAL_CT_CNT

,FLOOR(SUM(TOTAL_DEBIT_AMOUNT)) TOTAL_DEBIT_AMOUNT
,FLOOR(SUM(TOTAL_DEBIT_CNT)) TOTAL_DEBIT_CNT
,FLOOR(SUM(TOTAL_DEBIT_AMOUNT)/NULLIF(SUM(TOTAL_DEBIT_CNT),0)) AVG_TOTAL_DT_AMT
,FLOOR(MAX(MAX_TOTAL_DT_AMT)) MAX_TOTAL_DT_AMT
--,FLOOR(MIN(MIN_TOTAL_DT_AMT)) MIN_TOTAL_DT_AMT 
,(SELECT FLOOR(MIN(AA.MIN_TOTAL_DT_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_TOTAL_DT_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_TOTAL_DT_AMT

,FLOOR(SUM(TOTAL_WIRE_C_AMT)/NULLIF(SUM(TOTAL_WIRE_C_CNT),0)) AVG_WIRE_C_AMT
,FLOOR(MAX(MAX_WIRE_C_AMT)) MAX_WIRE_C_AMT
,FLOOR(SUM(TOTAL_WIRE_C_AMT)) TOTAL_WIRE_C_AMT
--,FLOOR(MIN(MIN_WIRE_C_AMT)) MIN_WIRE_C_AMT
,(SELECT FLOOR(MIN(AA.MIN_WIRE_C_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_WIRE_C_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_WIRE_C_AMT
,FLOOR(SUM(TOTAL_WIRE_C_CNT)) TOTAL_WIRE_C_CNT

,FLOOR(SUM(TOTAL_WIRE_D_AMT)/NULLIF(SUM(TOTAL_WIRE_D_CNT),0)) AVG_WIRE_D_AMT
,FLOOR(MAX(MAX_WIRE_D_AMT)) MAX_WIRE_D_AMT
,FLOOR(SUM(TOTAL_WIRE_D_AMT)) TOTAL_WIRE_D_AMT
--,FLOOR(MIN(MIN_WIRE_D_AMT)) MIN_WIRE_D_AMT
,(SELECT FLOOR(MIN(AA.MIN_WIRE_D_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_WIRE_D_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_WIRE_D_AMT
,FLOOR(SUM(TOTAL_WIRE_D_CNT)) TOTAL_WIRE_D_CNT

,FLOOR(SUM(TOTAL_CASH_C_AMT)) TOTAL_CASH_C_AMT
,FLOOR(SUM(TOTAL_CASH_C_CNT)) TOTAL_CASH_C_CNT
--,FLOOR(MIN(MIN_CASH_C_AMT)) MIN_CASH_C_AMT
,(SELECT FLOOR(MIN(AA.MIN_CASH_C_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_CASH_C_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_CASH_C_AMT
,FLOOR(SUM(TOTAL_CASH_C_AMT)/NULLIF(SUM(TOTAL_CASH_C_CNT),0)) AVG_CASH_C_AMT
,FLOOR(MAX(MAX_CASH_C_AMT)) MAX_CASH_C_AMT

,FLOOR(SUM(TOTAL_CASH_D_AMT)) TOTAL_CASH_D_AMT
,FLOOR(SUM(TOTAL_CASH_D_CNT)) TOTAL_CASH_D_CNT
,FLOOR(SUM(TOTAL_CASH_D_AMT)/NULLIF(SUM(TOTAL_CASH_D_CNT),0)) AVG_CASH_D_AMT
--,FLOOR(MIN(MIN_CASH_D_AMT)) MIN_CASH_D_AMT
,(SELECT FLOOR(MIN(AA.MIN_CASH_D_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_CASH_D_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_CASH_D_AMT
,FLOOR(MAX(MAX_CASH_D_AMT)) MAX_CASH_D_AMT

,FLOOR(SUM(TOTAL_CHECK_D_CNT)) TOTAL_CHECK_D_CNT
,FLOOR(SUM(TOTAL_CHECK_D_AMT)/NULLIF(SUM(TOTAL_CHECK_D_CNT),0)) AVG_CHECK_D_AMT
,FLOOR(MAX(MAX_CHECK_D_AMT)) MAX_CHECK_D_AMT
,FLOOR(SUM(TOTAL_CHECK_D_AMT)) TOTAL_CHECK_D_AMT
--,FLOOR(SUM(MIN_CHECK_D_AMT)) MIN_CHECK_D_AMT
,(SELECT FLOOR(MIN(AA.MIN_CHECK_D_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_CHECK_D_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_CHECK_D_AMT

,FLOOR(MAX(MAX_INTERNALTRANSFER_C_AMT)) MAX_INTERNALTRANSFER_C_AMT
--,FLOOR(MIN(MIN_INTERNALTRANSFER_C_AMT)) MIN_INTERNALTRANSFER_C_AMT
,(SELECT FLOOR(MIN(AA.MIN_INTERNALTRANSFER_C_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_INTERNALTRANSFER_C_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_INTERNALTRANSFER_C_AMT
,FLOOR(SUM(TOTAL_INTERNALTRANSFER_C_CNT))  TOTAL_INTERNALTRANSFER_C_CNT
,FLOOR(SUM(TOTAL_INTERNALTRANSFER_C_AMT))  TOTAL_INTERNALTRANSFER_C_AMT
,FLOOR(SUM(TOTAL_INTERNALTRANSFER_C_AMT)/NULLIF(SUM(TOTAL_INTERNALTRANSFER_C_CNT),0)) AVG_INTERNALTRANSFER_C_AMT

--,FLOOR(MIN(MIN_INTERNALTRANSFER_D_AMT)) MIN_INTERNALTRANSFER_D_AMT
,(SELECT FLOOR(MIN(AA.MIN_INTERNALTRANSFER_D_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_INTERNALTRANSFER_D_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_INTERNALTRANSFER_D_AMT
,FLOOR(SUM(TOTAL_INTERNALTRANSFER_D_CNT))  TOTAL_INTERNALTRANSFER_D_CNT
,FLOOR(SUM(TOTAL_INTERNALTRANSFER_D_AMT)/NULLIF(SUM(TOTAL_INTERNALTRANSFER_D_CNT),0)) AVG_INTERNALTRANSFER_D_AMT
,FLOOR(SUM(TOTAL_INTERNALTRANSFER_D_AMT)) TOTAL_INTERNALTRANSFER_D_AMT
,FLOOR(MAX(MAX_INTERNALTRANSFER_D_AMT)) MAX_INTERNALTRANSFER_D_AMT

,FLOOR(SUM(TOTAL_MISC_C_CNT)) TOTAL_MISC_C_CNT
,FLOOR(SUM(TOTAL_MISC_C_AMT)/(CASE WHEN SUM(TOTAL_MISC_C_CNT) = 0 THEN 1 ELSE SUM(TOTAL_MISC_C_CNT) END)) AVG_MISC_C_AMT
,FLOOR(SUM(TOTAL_MISC_C_AMT)) TOTAL_MISC_C_AMT
--,FLOOR(MIN(MIN_MISC_C_AMT)) MIN_MISC_C_AMT
,(SELECT FLOOR(MIN(AA.MIN_MISC_C_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_MISC_C_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_MISC_C_AMT
,FLOOR(MAX(MAX_MISC_C_AMT)) MAX_MISC_C_AMT

,FLOOR(SUM(TOTAL_WITHDRAWAL_D_CNT)) TOTAL_WITHDRAWAL_D_CNT
,FLOOR(SUM(TOTAL_WITHDRAWAL_D_AMT)/(CASE WHEN SUM(TOTAL_WITHDRAWAL_D_CNT) = 0 THEN 1 ELSE SUM(TOTAL_WITHDRAWAL_D_CNT) END)) AVG_WITHDRAWAL_D_AMT
,FLOOR(SUM(TOTAL_WITHDRAWAL_D_AMT)) TOTAL_WITHDRAWAL_D_AMT
--,FLOOR(MIN(MIN_WITHDRAWAL_D_AMT)) MIN_WITHDRAWAL_D_AMT
,(SELECT FLOOR(MIN(AA.MIN_WITHDRAWAL_D_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_WITHDRAWAL_D_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_WITHDRAWAL_D_AMT
,FLOOR(MAX(MAX_WITHDRAWAL_D_AMT)) MAX_WITHDRAWAL_D_AMT


,FLOOR(SUM(TOTAL_FEES_D_CNT)) TOTAL_FEES_D_CNT
,FLOOR(SUM(TOTAL_FEES_D_AMT)/(CASE WHEN SUM(TOTAL_FEES_D_CNT) = 0 THEN 1 ELSE SUM(TOTAL_FEES_D_CNT) END)) AVG_FEES_D_AMT
,FLOOR(SUM(TOTAL_FEES_D_AMT)) TOTAL_FEES_D_AMT
--,FLOOR(MIN(MIN_FEES_D_AMT)) MIN_FEES_D_AMT
,(SELECT FLOOR(MIN(AA.MIN_FEES_D_AMT)) FROM ART.ART_MEB_SEGMENTS_V3_TB AA WHERE AA.MIN_FEES_D_AMT >1 
AND AA.SEGMENT_SORTED=A.segment_sorted
) MIN_FEES_D_AMT
,FLOOR(MAX(MAX_FEES_D_AMT)) MAX_FEES_D_AMT



  FROM ART.ART_MEB_SEGMENTS_V3_TB A

GROUP BY
       MONTH_KEY
      ,segment_sorted
      ,PARTY_TYPE_DESC
;");
            migrationBuilder.Sql($@" CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_ALL_SEGMENTS_OUTLIERS"" (""MONTH_KEY"", ""PARTY_NUMBER"", ""PARTY_NAME"", ""BRANCH_NAME"", ""BRANCH_NUMBER"", ""PARTY_TYPE_DESC"", ""SEGMENT_SORTED"", ""FEATURE"", ""UPPER_OUTLIER_LIMIT"", ""AMOUNT"") AS 
  select 
A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) BRANCH_NUMBER,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE,FLOOR(MAX(B.Upper_outlier_limit))Upper_outlier_limit,FLOOR(sum(A.TOTAL_CASH_C_AMT))AMOUNT 
from
ART.ART_MEB_SEGMENTS_V3_TB a left join ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB b
on a.month_key = b.month_key and a.SEGMENT_SORTED = B.SEGMENT_SORTED 
AND A.PARTY_TYPE_DESC = B.PARTY_TYPE_DESC
left join FCFCORE.fsc_party_dim party on TO_CHAR(a.party_number) = TO_CHAR(party.party_number) and party.change_current_ind='Y'
LEFT JOIN
FCFCORE.FSC_BRANCH_DIM BRANCH on party.STREET_STATE_CODE = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
WHERE (party.party_key > - 1 and party.change_current_ind = 'y')
and
B.feature='TOTAL_CASH_C_AMT'
group by A.Month_Key,A.PARTY_NUMBER,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end),
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end),
party.party_name,A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE
HAVING SUM(TOTAL_CASH_C_AMT) > MAX(B.Upper_outlier_limit)

union all

select 
A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) BRANCH_NUMBER,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE,FLOOR(MAX(B.Upper_outlier_limit))Upper_outlier_limit,FLOOR(sum(A.TOTAL_CASH_D_AMT))AMOUNT 
from
ART.ART_MEB_SEGMENTS_V3_TB a left join ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB b
on a.month_key = b.month_key and a.SEGMENT_SORTED = B.SEGMENT_SORTED 
AND A.PARTY_TYPE_DESC = B.PARTY_TYPE_DESC
left join FCFCORE.fsc_party_dim party on TO_CHAR(a.party_number) = TO_CHAR(party.party_number) and party.change_current_ind='Y'
LEFT JOIN
FCFCORE.FSC_BRANCH_DIM BRANCH on RTRIM(LTRIM(party.STREET_STATE_CODE)) = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
WHERE
B.feature='TOTAL_CASH_D_AMT'
group by A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end),
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) ,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE
HAVING SUM(TOTAL_CASH_D_AMT) > MAX(B.Upper_outlier_limit)

union all

select 
A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) BRANCH_NUMBER,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE,FLOOR(MAX(B.Upper_outlier_limit))Upper_outlier_limit,FLOOR(sum(A.TOTAL_WIRE_C_AMT))AMOUNT 
from
ART.ART_MEB_SEGMENTS_V3_TB a left join ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB b
on a.month_key = b.month_key and a.SEGMENT_SORTED = B.SEGMENT_SORTED 
AND A.PARTY_TYPE_DESC = B.PARTY_TYPE_DESC
left join FCFCORE.fsc_party_dim party on TO_CHAR(a.party_number) = TO_CHAR(party.party_number) and party.change_current_ind='Y'
LEFT JOIN
FCFCORE.FSC_BRANCH_DIM BRANCH on party.STREET_STATE_CODE = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
WHERE (party.party_key > - 1 and party.change_current_ind = 'y')
and
B.feature='TOTAL_WIRE_C_AMT'
group by A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end),
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end),
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE
HAVING SUM(TOTAL_WIRE_C_AMT) > MAX(B.Upper_outlier_limit)

union all

select 
A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) BRANCH_NUMBER,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE,FLOOR(MAX(B.Upper_outlier_limit))Upper_outlier_limit,FLOOR(sum(A.TOTAL_WIRE_D_AMT))AMOUNT 
from
ART.ART_MEB_SEGMENTS_V3_TB a left join ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB b
on a.month_key = b.month_key and a.SEGMENT_SORTED = B.SEGMENT_SORTED 
AND A.PARTY_TYPE_DESC = B.PARTY_TYPE_DESC
left join FCFCORE.fsc_party_dim party on TO_CHAR(a.party_number) = TO_CHAR(party.party_number) and party.change_current_ind='Y'
LEFT JOIN
FCFCORE.FSC_BRANCH_DIM BRANCH on party.STREET_STATE_CODE = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
WHERE (party.party_key > - 1 and party.change_current_ind = 'y')
and
B.feature='TOTAL_WIRE_D_AMT'
group by A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end),
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) ,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE
HAVING SUM(TOTAL_WIRE_D_AMT) > MAX(B.Upper_outlier_limit)


union all

select 
A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) BRANCH_NUMBER,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE,FLOOR(MAX(B.Upper_outlier_limit))Upper_outlier_limit,FLOOR(sum(A.TOTAL_CHECK_D_AMT))AMOUNT 
from
ART.ART_MEB_SEGMENTS_V3_TB a left join ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB b
on a.month_key = b.month_key and a.SEGMENT_SORTED = B.SEGMENT_SORTED 
AND A.PARTY_TYPE_DESC = B.PARTY_TYPE_DESC
left join FCFCORE.fsc_party_dim party on TO_CHAR(a.party_number) = TO_CHAR(party.party_number) and party.change_current_ind='Y'
LEFT JOIN
FCFCORE.FSC_BRANCH_DIM BRANCH on party.STREET_STATE_CODE = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
WHERE (party.party_key > - 1 and party.change_current_ind = 'y')
and
B.feature='TOTAL_CHECK_D_AMT'
group by A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end),
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end),
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE
HAVING SUM(TOTAL_CHECK_D_AMT) > MAX(B.Upper_outlier_limit)

union all

select 
A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) BRANCH_NUMBER,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE,FLOOR(MAX(B.Upper_outlier_limit))Upper_outlier_limit,FLOOR(sum(A.TOTAL_INTERNALTRANSFER_C_AMT))AMOUNT 
from
ART.ART_MEB_SEGMENTS_V3_TB a left join ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB b
on a.month_key = b.month_key and a.SEGMENT_SORTED = B.SEGMENT_SORTED 
AND A.PARTY_TYPE_DESC = B.PARTY_TYPE_DESC
left join FCFCORE.fsc_party_dim party on TO_CHAR(a.party_number) = TO_CHAR(party.party_number) and party.change_current_ind='Y'
LEFT JOIN
FCFCORE.FSC_BRANCH_DIM BRANCH on party.STREET_STATE_CODE = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
WHERE (party.party_key > - 1 and party.change_current_ind = 'y') 
and
B.feature='TOTAL_INTERNALTRANSFER_C_AMT'
group by A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end),
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end),
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE
HAVING SUM(TOTAL_INTERNALTRANSFER_C_AMT) > MAX(B.Upper_outlier_limit)

union all

select 
A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) BRANCH_NUMBER,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE,FLOOR(MAX(B.Upper_outlier_limit))Upper_outlier_limit,FLOOR(sum(A.TOTAL_INTERNALTRANSFER_D_AMT))AMOUNT 
from
ART.ART_MEB_SEGMENTS_V3_TB a left join ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB b
on a.month_key = b.month_key and a.SEGMENT_SORTED = B.SEGMENT_SORTED 
AND A.PARTY_TYPE_DESC = B.PARTY_TYPE_DESC
left join FCFCORE.fsc_party_dim party on TO_CHAR(a.party_number) = TO_CHAR(party.party_number) and party.change_current_ind='Y'
LEFT JOIN
FCFCORE.FSC_BRANCH_DIM BRANCH on party.STREET_STATE_CODE = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
WHERE (party.party_key > - 1 and party.change_current_ind = 'y')
and
B.feature='TOTAL_INTERNALTRANSFER_D_AMT'
group by A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end),
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) ,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE
HAVING SUM(TOTAL_INTERNALTRANSFER_D_AMT) > MAX(B.Upper_outlier_limit)

union all

select 
A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) BRANCH_NUMBER,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE,FLOOR(MAX(B.Upper_outlier_limit))Upper_outlier_limit,FLOOR(sum(A.TOTAL_MISC_C_AMT))AMOUNT 
from
ART.ART_MEB_SEGMENTS_V3_TB a left join ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB b
on a.month_key = b.month_key and a.SEGMENT_SORTED = B.SEGMENT_SORTED 
AND A.PARTY_TYPE_DESC = B.PARTY_TYPE_DESC
left join FCFCORE.fsc_party_dim party on TO_CHAR(a.party_number) = TO_CHAR(party.party_number) and party.change_current_ind='Y'
LEFT JOIN
FCFCORE.FSC_BRANCH_DIM BRANCH on party.STREET_STATE_CODE = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
WHERE (party.party_key > - 1 and party.change_current_ind = 'y')
and
B.feature='TOTAL_MISC_C_AMT'
group by A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end),
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) ,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE
HAVING SUM(TOTAL_MISC_C_AMT) > MAX(B.Upper_outlier_limit)

union all

select 
A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end) BRANCH_NAME,
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) BRANCH_NUMBER,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE,FLOOR(MAX(B.Upper_outlier_limit))Upper_outlier_limit,FLOOR(sum(A.TOTAL_WITHDRAWAL_D_AMT))AMOUNT 
from
ART.ART_MEB_SEGMENTS_V3_TB a left join ART.ART_ALL_SEGS_OUTLIERS_LIMIT_TB b
on a.month_key = b.month_key and a.SEGMENT_SORTED = B.SEGMENT_SORTED 
AND A.PARTY_TYPE_DESC = B.PARTY_TYPE_DESC
left join FCFCORE.fsc_party_dim party on TO_CHAR(a.party_number) = TO_CHAR(party.party_number) and party.change_current_ind='Y'
LEFT JOIN
FCFCORE.FSC_BRANCH_DIM BRANCH on party.STREET_STATE_CODE = BRANCH.BRANCH_NUMBER and BRANCH.CHANGE_CURRENT_IND='Y'
WHERE (party.party_key > - 1 and party.change_current_ind = 'y')
and
B.feature='TOTAL_WITHDRAWAL_D_AMT'
group by A.Month_Key,A.PARTY_NUMBER,party.party_name,
(Case when BRANCH.BRANCH_NAME is null then 'Unknown' else BRANCH.BRANCH_NAME end),
(Case when BRANCH.BRANCH_NUMBER is null then 'Unknown' else BRANCH.BRANCH_NUMBER end) ,
A.PARTY_TYPE_DESC,a.segment_sorted,B.FEATURE
HAVING SUM(TOTAL_WITHDRAWAL_D_AMT) > MAX(B.Upper_outlier_limit)");
            migrationBuilder.Sql($@"  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_CHANGED_SEGMENT"" (""MONTH_KEY"", ""PARTY_NUMBER"", ""RISK_CLASSIFICATION"", ""PARTY_TYPE_DESC"", ""INDUSTRY_CODE"", ""INDUSTRY_DESC"", ""OCCUPATION_DESC"", ""SEGMENT_SORTED"", ""LAST_SEGMENT_ID"", ""CREATION_DATE"") AS 
  select MONTH_KEY, PARTY_NUMBER, RISK_CLASSIFICATION, PARTY_TYPE_DESC, INDUSTRY_CODE, INDUSTRY_DESC, OCCUPATION_DESC,SEGMENT_SORTED, LAST_SEGMENT_ID, CREATION_DATE
from FCFKC.MEB_SEGMENTS_V3
where
SEGMENT_SORTED !=LAST_SEGMENT_ID
");
            migrationBuilder.Sql($@" CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_INDUSTRY_SEGMENT"" (""MONTH_KEY"", ""PARTY_TYPE_DESC"", ""INDUSTRY_DESC"", ""SEGMENT_SORTED"", ""NUMBER_OF_CUSTOMERS"", ""TOTAL_AMOUNT"", ""TOTAL_CREDIT_AMOUNT"", ""TOTAL_DEBIT_AMOUNT"") AS 
  SELECT  
month_key,
party_type_Desc,
(case when party_type_Desc='ORGNIZATION' then 
(case when industry_desc is null then 'Missing' else industry_desc end)
else (case when occupation_desc is null then 'Missing' else occupation_desc end)
end) industry_desc,

segment_sorted,
count(party_number) Number_Of_Customers,
floor(sum(total_amount)) total_amount,
floor(sum(total_credit_amount)) total_credit_amount,
floor(sum(total_debit_amount)) total_debit_amount

FROM 
ART.ART_MEB_SEGMENTS_V3_TB

--where party_type_Desc='ORGNIZATION'
group by month_key,party_type_Desc,
(case when party_type_Desc='ORGNIZATION' then 
(case when industry_desc is null then 'Missing' else industry_desc end)
else (case when occupation_desc is null then 'Missing' else occupation_desc end)
end)
, segment_sorted
");
            migrationBuilder.Sql($@" CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_SEGOUTVSALLCUST"" (""MONTH_KEY"", ""SEGMENT_SORTED"", ""PARTY_TYPE_DESC"", ""NUMBER_OF_CUSTOMERS"", ""NUMBER_OF_OUTLIERS"") AS 
  SELECT 
all_cust_seg.Month_Key, all_cust_seg.segment_sorted, all_cust_seg.PARTY_TYPE_DESC, all_cust_seg.Number_of_Customers, all_cust_out.Number_of_Outliers
FROM     
(
SELECT Month_Key, segment_sorted, PARTY_TYPE_DESC, COUNT(PARTY_NUMBER)  Number_of_Customers
FROM
ART.ART_MEB_SEGMENTS_V3_TB  a
GROUP BY 
Month_Key, segment_sorted, PARTY_TYPE_DESC)  all_cust_seg LEFT OUTER JOIN
(
SELECT 
Month_Key, segment_sorted, PARTY_TYPE_DESC, COUNT(DISTINCT PARTY_NUMBER)  Number_of_Outliers
FROM      
ART.ART_ALL_SEGMENTS_OUTLIERS_TB  a
GROUP BY Month_Key, segment_sorted, PARTY_TYPE_DESC)  all_cust_out ON all_cust_seg.Month_Key = all_cust_out.Month_Key 
AND all_cust_seg.segment_sorted = all_cust_out.segment_sorted AND 
all_cust_seg.PARTY_TYPE_DESC = all_cust_out.PARTY_TYPE_DESC
");

            migrationBuilder.Sql($@"
  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_SEGOUTVSALLOUT"" (""MONTH_KEY"", ""SEGMENT_SORTED"", ""PARTY_TYPE_DESC"", ""NUMBER_OF_OUTLIERS"", ""TOTAL_NUMBER_OF_OUTLIERS"") AS 
  SELECT Month_Key, segment_sorted, PARTY_TYPE_DESC, COUNT(DISTINCT PARTY_NUMBER)  Number_of_Outliers,
(SELECT COUNT(DISTINCT PARTY_NUMBER)  Number_of_Outliers
FROM      ART.ART_ALL_SEGMENTS_OUTLIERS_TB)  Total_Number_of_Outliers
FROM     ART.ART_ALL_SEGMENTS_OUTLIERS_TB  a
GROUP BY Month_Key, segment_sorted, PARTY_TYPE_DESC
");
            migrationBuilder.Sql($@"  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_ALERTS_PER_SEGMENT"" (""MONTH_KEY"", ""PARTY_TYPE_DESC"", ""SEGMENT_SORTED"", ""NUMBER_OF_ALERTS"") AS 
  select 
month_key,
party_type_desc,
segment_sorted,
floor(sum(alerts_cnt))Number_Of_Alerts
from 
ART.ART_MEB_SEGMENTS_V3_TB
group by
month_key,
party_type_desc,
segment_sorted
");
            migrationBuilder.Sql($@"  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_CUSTS_PER_TYPE"" (""MONTH_KEY"", ""PARTY_TYPE_DESC"", ""SEGMENT_SORTED"", ""NUMBER_OF_CUSTOMERS"") AS 
  select 
MONTH_KEY,PARTY_TYPE_DESC,SEGMENT_SORTED,count(PARTY_NUMBER)Number_Of_Customers
from ART.ART_MEB_SEGMENTS_V3_TB
group by
MONTH_KEY,PARTY_TYPE_DESC,SEGMENT_SORTED");


            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_ALL_SEGS_FEATRS_STATCS_TB');
   if c > 0 then
      execute immediate 'drop table ART_ALL_SEGS_FEATRS_STATCS_TB';
   end if;
     execute immediate 'CREATE TABLE ART_ALL_SEGS_FEATRS_STATCS_TB AS SELECT * FROM ART_ALL_SEGS_FEATRS_STATCS';
end;");
            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_INDUSTRY_SEGMENT_TB');
   if c > 0 then
      execute immediate 'drop table ART_INDUSTRY_SEGMENT_TB';
   end if;
     execute immediate 'CREATE TABLE ART_INDUSTRY_SEGMENT_TB AS SELECT * FROM ART_INDUSTRY_SEGMENT';
end;");
            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_ALL_SEGMENTS_OUTLIERS_TB');
   if c > 0 then
      execute immediate 'drop table ART_ALL_SEGMENTS_OUTLIERS_TB';
   end if;
     execute immediate 'CREATE TABLE ART_ALL_SEGMENTS_OUTLIERS_TB AS SELECT * FROM ART_ALL_SEGMENTS_OUTLIERS';
end;");
            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_SEGOUTVSALLOUT_TB');
   if c > 0 then
      execute immediate 'drop table ART_SEGOUTVSALLOUT_TB';
   end if;
     execute immediate 'CREATE TABLE ART_SEGOUTVSALLOUT_TB AS SELECT * FROM ART_SEGOUTVSALLOUT';
end;");
            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_CUSTS_PER_TYPE_TB');
   if c > 0 then
      execute immediate 'drop table ART_CUSTS_PER_TYPE_TB';
   end if;
     execute immediate 'CREATE TABLE ART_CUSTS_PER_TYPE_TB AS SELECT * FROM ART_CUSTS_PER_TYPE';
end;");
            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_SEGOUTVSALLCUST_TB');
   if c > 0 then
      execute immediate 'drop table ART_SEGOUTVSALLCUST_TB';
   end if;
     execute immediate 'CREATE TABLE ART_SEGOUTVSALLCUST_TB AS SELECT * FROM ART_SEGOUTVSALLCUST';
end;");
            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_ALL_SEGMENT_CUST_COUNT_TB');
   if c > 0 then
      execute immediate 'drop table ART_ALL_SEGMENT_CUST_COUNT_TB';
   end if;
     execute immediate 'CREATE TABLE ART_ALL_SEGMENT_CUST_COUNT_TB AS SELECT * FROM ART_ALL_SEGMENT_CUST_COUNT';
end;");
            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_ALERTS_PER_SEGMENT_TB');
   if c > 0 then
      execute immediate 'drop table ART_ALERTS_PER_SEGMENT_TB';
   end if;
     execute immediate 'CREATE TABLE ART_ALERTS_PER_SEGMENT_TB AS SELECT * FROM ART_ALERTS_PER_SEGMENT';
end;");
            migrationBuilder.Sql($@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_CHANGED_SEGMENT_TB');
   if c > 0 then
      execute immediate 'drop table ART_CHANGED_SEGMENT_TB';
   end if;
     execute immediate 'CREATE TABLE ART_CHANGED_SEGMENT_TB AS SELECT * FROM ART_CHANGED_SEGMENT';
end;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
