using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.KYC
{
    public partial class KYCReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Views
            //ART_AUDIT_CORPORATE_VIEW
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_AUDIT_CORPORATE_VIEW
            --------------------------------------------------------

                  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_AUDIT_CORPORATE_VIEW"" (""CASE_RK"", ""BANKING_OR_CORPORATE"", ""CLIENT_NUMBER"", ""NAME_LANGUAGE"", ""CORPORATE_NAME"", ""COMMERCIAL_NAME"", ""CORPORATE_NAME_EN"", ""COMMERCIAL_NAME_EN"", ""TITLE"", ""DEFAULT_BRANCH"", ""INDUSTRY"", ""AML_RISK_CD"", ""KYC_STATUS"", ""TYPE_OF_BUSINESS"", ""TYPE_OF_BUSINESS_OTHER"", ""IDENT_TYPE"", ""IDENT_NUMBER"", ""ID_ISSUE_COUNTRY"", ""IDENT_ISSUE_DATE"", ""IDENT_EXPIRY_DATE"", ""REG_NUMBER_CITY"", ""REG_NUMBER_OFFICE"", ""REGISTRATION_NUMBER"", ""REG_EXPIRY_DATE"", ""REG_NUMBER_LAST_DATE"", ""HEAD_QUARTER_COUNTRY"", ""TAX_ID_NUM"", ""NATIONALITY_COUNTRY"", ""INCORPORATION_COUNTRY_CODE"", ""INCORPORATION_DATE"", ""INCORPORATION_LEGAL_FORM"", ""INCORPORATION_STATE"", ""LEGAL_FORM_OTHERS"", ""LEGAL_FORM_SUB"", ""RISK_REASON"", ""RISK_CODE"", ""CB_RISK_RATE"", ""CLOSING_REASON_ID"", ""CLOSE_DATE"", ""CREATE_DATE"", ""CREATED_BY"", ""NEXT_UPDATE_DATE"", ""UPDATE_DATE"", ""UPDATED_BY"", ""ACTIVITY_TYPE_SUB"", ""BUDGET_DATE_1"", ""BUDGET_DATE_2"", ""BUDGET_DATE_3"", ""FFI_TYPE"", ""GIIN"", ""SALES_VOLUME_1"", ""SALES_VOLUME_2"", ""SALES_VOLUME_3"", ""ACTIVITY_AMOUNT"", ""ACTIVITY_AMOUNT_CURRENCY"", ""ACTIVITY_END_DATE"", ""ACTIVITY_START_DATE"", ""ACTIVITY_TYPE"", ""ACTIVITY_TYPE_DTLS"", ""CHARITY_DONATIONS_IND"", ""FINANCIAL_START_DATE"", ""FOREIGN_CONSULATE_EMBASSY_IND"", ""GOV_ORG_IND"", ""WOMEN_SHARE"", ""DATE_OF_BUDGET"", ""NO_OF_EMPLOYEES"", ""SIZE_OF_SALES"", ""SIZE_OF_TRANSACTION"", ""REFERENCE_EMPLOYEE_ID"", ""CUSTOMER_REFERENCE"", ""BANKING_OR_OTHER_REF"", ""LIMITS_AMOUNT"", ""LIMITS_AMOUNT_CURRENCY"", ""GEO_CODE"", ""BUSINESS_CODE"", ""CALCULATE_ZAKAH_FLAG"", ""CUSTOMER_STATUS"", ""INVESTMENT_BALANCE"", ""SALES_BASIS"", ""LEGAL_STEP_MAIN_CODE"", ""LEGAL_STEP_SUB_CODE"", ""MAIN_LEGAL_FORM"", ""UNDER_ESTABLISHMENT"", ""TOTAL_NO_OF_UNITS"", ""RISK_WEIGHT"", ""WORTH_CODE"", ""LAST_QUERY_DATE"", ""TRADE_ADD_DATE"", ""WORTH_LAST_CALC_DATE"", ""ECONOMIC_ACTIVITY_CODE5"", ""PAID_UP_CAPITAL_AMOUNT"", ""PAID_UP_CAPITAL_CURRENCY"", ""DEALT_BANK_DETAILS"", ""DEAL_ABRD_BANK_DETAILS"", ""OTHER_BANK_ACCOUNTS"", ""CAPITAL_1"", ""CAPITAL_2"", ""CAPITAL_3"", ""ANNUAL_NET_INCOME_CD"", ""NON_PROFIT_ORGANIZATION"", ""COMPANY_STOCK"", ""COMPANY_STOCK_NAME"", ""HOLDING_CORPORATION"", ""HOLDING_CORPORATION_CD"") AS 
                  select 
                a.CASE_RK
                ,r_BANKING_OR_CORPORATE.val_desc BANKING_OR_CORPORATE
                ,a.CLIENT_NUMBER
                ,r_NAME_LANGUAGE.val_desc NAME_LANGUAGE
                ,a.CORPORATE_NAME
                ,a.COMMERCIAL_NAME
                ,a.CORPORATE_NAME_EN
                ,a.COMMERCIAL_NAME_EN
                ,r_TITLE.val_desc TITLE
                ,r_DEFAULT_BRANCH.val_desc DEFAULT_BRANCH
                ,r_INDUSTRY.val_desc INDUSTRY
                ,a.AML_RISK_CD
                ,r_KYC_STATUS.val_desc KYC_STATUS
                ,r_TYPE_OF_BUSINESS.val_desc TYPE_OF_BUSINESS
                ,a.TYPE_OF_BUSINESS_OTHER
                ,r_IDENT_TYPE.val_desc IDENT_TYPE
                ,a.IDENT_NUMBER
                ,r_ID_ISSUE_COUNTRY.val_desc ID_ISSUE_COUNTRY
                ,a.IDENT_ISSUE_DATE
                ,a.IDENT_EXPIRY_DATE
                ,r_REG_NUMBER_CITY.val_desc REG_NUMBER_CITY
                ,r_REG_NUMBER_OFFICE.val_desc REG_NUMBER_OFFICE
                ,a.REGISTRATION_NUMBER
                ,a.REG_EXPIRY_DATE
                ,a.REG_NUMBER_LAST_DATE
                ,r_HEAD_QUARTER_COUNTRY.val_desc HEAD_QUARTER_COUNTRY
                ,a.TAX_ID_NUM
                ,a.NATIONALITY_COUNTRY
                ,r_INCORPORATION_COUNTRY_CODE.val_desc INCORPORATION_COUNTRY_CODE
                ,a.INCORPORATION_DATE
                ,r_INCORPORATION_LEGAL_FORM.val_desc INCORPORATION_LEGAL_FORM
                ,a.INCORPORATION_STATE
                ,a.LEGAL_FORM_OTHERS
                ,r_LEGAL_FORM_SUB.val_desc LEGAL_FORM_SUB
                ,a.RISK_REASON
                ,r_RISK_CODE.val_desc RISK_CODE
                ,r_CB_RISK_RATE.val_desc CB_RISK_RATE
                ,r_CLOSING_REASON_ID.val_desc CLOSING_REASON_ID
                ,a.CLOSE_DATE
                ,a.CREATE_DATE
                ,a.CREATED_BY
                ,a.NEXT_UPDATE_DATE
                ,a.UPDATE_DATE
                ,a.UPDATED_BY

                --BUSINESS_ACTIVITY_INFO_AUD
                ,ACTIVITY_TYPE_SUB.val_desc ACTIVITY_TYPE_SUB
                ,g.BUDGET_DATE_1
                ,g.BUDGET_DATE_2
                ,g.BUDGET_DATE_3
                ,FFI_TYPE.val_desc FFI_TYPE
                ,g.GIIN
                ,g.SALES_VOLUME_1
                ,g.SALES_VOLUME_2
                ,g.SALES_VOLUME_3
                ,g.ACTIVITY_AMOUNT
                ,activity_amount_crcy.val_desc ACTIVITY_AMOUNT_CURRENCY
                ,g.ACTIVITY_END_DATE
                ,g.ACTIVITY_START_DATE
                ,economic_main_code.val_desc ACTIVITY_TYPE
                ,g.ACTIVITY_TYPE_DTLS
                ,CHARITY_DONATIONS_IND.val_desc CHARITY_DONATIONS_IND
                ,g.FINANCIAL_START_DATE
                ,foreign_consulate_embassy_ind.val_desc FOREIGN_CONSULATE_EMBASSY_IND
                ,GOV_ORG_IND.val_desc GOV_ORG_IND
                ,WOMEN_SHARE.val_desc WOMEN_SHARE

                -- CORPORATE_ADDITIONAL_INFO_AUD
                ,b.DATE_OF_BUDGET
                ,b.NO_OF_EMPLOYEES
                ,b.SIZE_OF_SALES
                ,b.SIZE_OF_TRANSACTION
                ,b.REFERENCE_EMPLOYEE_ID
                ,b.CUSTOMER_REFERENCE
                ,b.BANKING_OR_OTHER_REF
                ,b.LIMITS_AMOUNT
                ,r_LIMITS_AMOUNT_CURRENCY.val_desc LIMITS_AMOUNT_CURRENCY
                ,b.GEO_CODE
                ,b.BUSINESS_CODE
                ,b.CALCULATE_ZAKAH_FLAG
                ,b.CUSTOMER_STATUS
                ,b.INVESTMENT_BALANCE
                ,b.SALES_BASIS
                ,b.LEGAL_STEP_MAIN_CODE
                ,b.LEGAL_STEP_SUB_CODE
                ,b.MAIN_LEGAL_FORM
                ,b.UNDER_ESTABLISHMENT
                ,b.TOTAL_NO_OF_UNITS
                ,b.RISK_WEIGHT
                ,b.WORTH_CODE
                ,b.LAST_QUERY_DATE
                ,b.TRADE_ADD_DATE
                ,b.WORTH_LAST_CALC_DATE
                ,b.ECONOMIC_ACTIVITY_CODE5

                --CORPORATE_BANKING_INFO_AUD
                ,d.PAID_UP_CAPITAL_AMOUNT
                ,r_PAID_UP_CAPITAL_CURRENCY.val_desc PAID_UP_CAPITAL_CURRENCY
                ,d.DEALT_BANK_DETAILS
                ,d.DEAL_ABRD_BANK_DETAILS
                ,d.OTHER_BANK_ACCOUNTS
                ,d.CAPITAL_1
                ,d.CAPITAL_2
                ,d.CAPITAL_3

                --TAX_AND_ASSETS_INFO_AUD
                ,f.ANNUAL_NET_INCOME_CD
                ,non_profit_organization.val_desc NON_PROFIT_ORGANIZATION
                ,company_stock.val_desc COMPANY_STOCK
                ,f.COMPANY_STOCK_NAME
                ,holding_corporation.val_desc HOLDING_CORPORATION
                ,f.HOLDING_CORPORATION_CD

                from
                DGKYC.CORPORATE_BASIC_INFO_AUD@DGKYC_LINK a 
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_BANKING_OR_CORPORATE on a.BANKING_OR_CORPORATE = r_BANKING_OR_CORPORATE.val_cd and r_BANKING_OR_CORPORATE.REF_TABLE_NAME='X_RT_KYC_ENTITY_TYPE_CD'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_DEFAULT_BRANCH on a.DEFAULT_BRANCH = r_DEFAULT_BRANCH.val_cd and r_DEFAULT_BRANCH.REF_TABLE_NAME='X_RT_FIB_BRANCHES'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_HEAD_QUARTER_COUNTRY on a.HEAD_QUARTER_COUNTRY = r_HEAD_QUARTER_COUNTRY.val_cd and r_HEAD_QUARTER_COUNTRY.REF_TABLE_NAME='X_RT_COUNTRY'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_INCORPORATION_COUNTRY_CODE on a.INCORPORATION_COUNTRY_CODE = r_INCORPORATION_COUNTRY_CODE.val_cd and r_INCORPORATION_COUNTRY_CODE.REF_TABLE_NAME='X_RT_COUNTRY'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_INCORPORATION_LEGAL_FORM on a.INCORPORATION_LEGAL_FORM = r_INCORPORATION_LEGAL_FORM.val_cd and r_INCORPORATION_LEGAL_FORM.REF_TABLE_NAME='X_RT_LEGAL_MAIN_CODE'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_LEGAL_FORM_SUB on a.LEGAL_FORM_SUB = r_LEGAL_FORM_SUB.val_cd and r_LEGAL_FORM_SUB.REF_TABLE_NAME='X_RT_LEGAL_SUB_CODE'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_CLOSING_REASON_ID on a.CLOSING_REASON_ID = r_CLOSING_REASON_ID.val_cd and r_CLOSING_REASON_ID.REF_TABLE_NAME='X_RT_CLOSING_REASON'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_ID_ISSUE_COUNTRY on a.ID_ISSUE_COUNTRY = r_ID_ISSUE_COUNTRY.val_cd and r_ID_ISSUE_COUNTRY.REF_TABLE_NAME='X_RT_COUNTRY'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_KYC_STATUS on a.KYC_STATUS = r_KYC_STATUS.val_cd and r_KYC_STATUS.REF_TABLE_NAME='X_RT_FIB_KYC_STATUS'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_IDENT_TYPE on a.IDENT_TYPE = r_IDENT_TYPE.val_cd and r_IDENT_TYPE.REF_TABLE_NAME='X_RT_KYC_ID_TYPE'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_REG_NUMBER_CITY on a.REG_NUMBER_CITY = r_REG_NUMBER_CITY.val_cd and r_REG_NUMBER_CITY.REF_TABLE_NAME='X_RT_EGYPT_CITY'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_REG_NUMBER_OFFICE on a.REG_NUMBER_OFFICE = r_REG_NUMBER_OFFICE.val_cd and r_REG_NUMBER_OFFICE.REF_TABLE_NAME='X_RT_COM_REGISTER_OFFICE'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_INDUSTRY on a.INDUSTRY = r_INDUSTRY.val_cd and r_INDUSTRY.REF_TABLE_NAME='X_RT_CUSTOMER_TYPE_ENT'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_NAME_LANGUAGE on a.NAME_LANGUAGE = r_NAME_LANGUAGE.val_cd and r_NAME_LANGUAGE.REF_TABLE_NAME='X_RT_LANGUAGE_CODE'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_CB_RISK_RATE on a.CB_RISK_RATE = r_CB_RISK_RATE.val_cd and r_CB_RISK_RATE.REF_TABLE_NAME='X_RT_AD_GB_RISK'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_TITLE on a.TITLE = r_TITLE.val_cd and r_TITLE.REF_TABLE_NAME='X_RT_NONPERSONAL_TITLE'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_RISK_CODE on a.RISK_CODE = r_RISK_CODE.val_cd and r_RISK_CODE.REF_TABLE_NAME='X_RT_AD_GB_RISK'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_TYPE_OF_BUSINESS on a.TYPE_OF_BUSINESS = r_TYPE_OF_BUSINESS.val_cd and r_TYPE_OF_BUSINESS.REF_TABLE_NAME='X_RT_OCCU_ETNTY_CD'


                left join
                DGKYC.CORPORATE_ADDITIONAL_INFO_AUD@DGKYC_LINK b ON a.case_rk=b.case_rk and a.update_date =b.update_date 
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_LIMITS_AMOUNT_CURRENCY on b.LIMITS_AMOUNT_CURRENCY = r_LIMITS_AMOUNT_CURRENCY.val_cd and r_LIMITS_AMOUNT_CURRENCY.REF_TABLE_NAME='X_RT_CURRENCY'

                LEFT JOIN
                --CORPORATE_ADDRESS_INFO_AUD c ON a.case_rk=c.case_rk and a.update_date =c.update_date LEFT JOIN
                DGKYC.CORPORATE_BANKING_INFO_AUD@DGKYC_LINK d ON a.case_rk=d.case_rk and a.update_date =d.update_date
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_PAID_UP_CAPITAL_CURRENCY on d.PAID_UP_CAPITAL_CURRENCY = r_PAID_UP_CAPITAL_CURRENCY.val_cd and r_PAID_UP_CAPITAL_CURRENCY.REF_TABLE_NAME='X_RT_ACTIVITY_AMOUNT_CRCY'

                 LEFT JOIN
                --CORPORATE_CONTACTS_INFO_AUD e ON a.case_rk=e.case_rk and a.update_date =e.update_date LEFT JOIN
                DGKYC.TAX_AND_ASSETS_INFO_AUD@DGKYC_LINK f ON a.case_rk=f.case_rk and a.update_date =f.update_date 
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK COMPANY_STOCK on f.COMPANY_STOCK = COMPANY_STOCK.val_cd and COMPANY_STOCK.REF_TABLE_NAME='X_RT_Y_N'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK HOLDING_CORPORATION on f.HOLDING_CORPORATION = HOLDING_CORPORATION.val_cd and HOLDING_CORPORATION.REF_TABLE_NAME='X_RT_YES_NO'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK NON_PROFIT_ORGANIZATION on f.NON_PROFIT_ORGANIZATION = NON_PROFIT_ORGANIZATION.val_cd and NON_PROFIT_ORGANIZATION.REF_TABLE_NAME='X_RT_YES_NO'
                LEFT JOIN
                DGKYC.BUSINESS_ACTIVITY_INFO_AUD@DGKYC_LINK g ON a.case_rk=g.case_rk and a.update_date =g.update_date 
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK ACTIVITY_AMOUNT_CRCY on g.ACTIVITY_AMOUNT_CURRENCY = ACTIVITY_AMOUNT_CRCY.val_cd and ACTIVITY_AMOUNT_CRCY.REF_TABLE_NAME='X_RT_ACTIVITY_AMOUNT_CRCY'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK ECONOMIC_MAIN_CODE on g.ACTIVITY_TYPE = ECONOMIC_MAIN_CODE.val_cd and ECONOMIC_MAIN_CODE.REF_TABLE_NAME='X_RT_ECONOMIC_MAIN_CODE'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK CHARITY_DONATIONS_IND on g.CHARITY_DONATIONS_IND = CHARITY_DONATIONS_IND.val_cd and CHARITY_DONATIONS_IND.REF_TABLE_NAME='X_RT_YES_NO'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK FOREIGN_CONSULATE_EMBASSY_IND on g.FOREIGN_CONSULATE_EMBASSY_IND = FOREIGN_CONSULATE_EMBASSY_IND.val_cd and FOREIGN_CONSULATE_EMBASSY_IND.REF_TABLE_NAME='X_RT_YES_NO'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK GOV_ORG_IND on g.GOV_ORG_IND = GOV_ORG_IND.val_cd and GOV_ORG_IND.REF_TABLE_NAME='X_RT_YES_NO'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK WOMEN_SHARE on g.WOMEN_SHARE = WOMEN_SHARE.val_cd and WOMEN_SHARE.REF_TABLE_NAME='X_RT_CURRENCY'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK ACTIVITY_TYPE_SUB on g.ACTIVITY_TYPE_SUB = ACTIVITY_TYPE_SUB.val_cd and ACTIVITY_TYPE_SUB.REF_TABLE_NAME='X_RT_ECONOMIC_SUB_CODE'
                LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK FFI_TYPE on g.FFI_TYPE = FFI_TYPE.val_cd and FFI_TYPE.REF_TABLE_NAME='X_RT_YES_NO'
                --SIGNATORIES_INFO_AUD K ON a.case_rk=K.case_rk and a.update_date =K.update_date LEFT JOIN
                order by a.case_rk,a.update_date desc
                ;");
            //ART_AUDIT_INDIVIDUALS_VIEW
            migrationBuilder.Sql($@"
                    --------------------------------------------------------
                    --  DDL for View ART_AUDIT_INDIVIDUALS_VIEW
                    --------------------------------------------------------


                      CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_AUDIT_INDIVIDUALS_VIEW"" (""CASE_RK"", ""A_K_A"", ""OPENING_REASON_ID"", ""AML_RISK_CD"", ""CITIZEN_OR_RESIDENT"", ""CLIENT_NUMBER"", ""CLOSE_DATE"", ""CLOSING_REASON_ID"", ""CREATE_DATE"", ""CREATED_BY"", ""RISK_CLASS_VALUE"", ""CUSTOMER_TYPE"", ""DEFAULT_BRANCH"", ""NUMBER_OF_DEPENDENTS"", ""FIRST_NAME"", ""FULL_NAME_AR"", ""FULL_NAME_EN"", ""GENDER_CD"", ""EDUCATION_ID"", ""CB_RISK_ID"", ""KYC_STATUS"", ""RACE_ID"", ""LAST_NAME"", ""MARITAL_STATUS_CD"", ""MIDDLE_NAME"", ""MOTHER_NAME"", ""NATIONALITY_CODE1"", ""NATIONALITY_CODE2"", ""NATIONALITY_CODE3"", ""NEXT_UPDATE_DATE"", ""CB_RISK_RATE"", ""RELIGION"", ""RESIDENCE_COUNTRY"", ""RISK_REASON"", ""RISK_CODE"", ""SICTOR_CODE"", ""TITLE"", ""UPDATE_DATE"", ""UPDATED_BY"", ""VISA_TYPE"", ""FIRST_NAME_ENG"", ""LAST_NAME_ENG"", ""MIDDLE_NAME_ENG"", ""NAME_LANGUAGE"", ""EMPLOYEE_INDICATOR"", ""EDUCATION_ID_OTHER"", ""SPOUSE_BUSINESS"", ""SPOUSE_NAME"", ""VISA_EXPIRATION_DATE"", ""CB_RISK_RATE_OTHER"", ""CLOSING_REASON_ID_OTHER"", ""OPENING_REASON_ID_OTHER"", ""RISK_CODE_OTHER"", ""EMPLOYMENT_TYPE"", ""EMPLOYED_OR_BUSINESS"", ""EMPLOYER_BUSINESS_NAME"", ""EMPLOYER_BUSINESS_ADRS"", ""EMPLOYER_BUSINESS_CITY"", ""EMPLOYER_BUSINESS_CTRY"", ""EMPLOYER_BUSINESS_STATE"", ""EMPLOYER_BUSINESS_TOWN"", ""EMPLOYER_PHONE"", ""EMPLOYER_COUNTRY_PHONE_CODE"", ""OCCUPATION"", ""OCCUPATION_DTL"", ""BUSINESS_SECTOR"", ""BUSINESS_SECTOR_OTHERS"", ""PEP_INDICATOR"", ""PEP_INDICATOR_DTLS"", ""PEP_INDICATOR_OTH"", ""SOURCE_OF_INCOME_CD"", ""SOURCE_OF_INCOME_OTHER"", ""ANNUAL_INCOME_CD"", ""MONTH_INCOME"", ""INCOME_ISO_CURRENCY"", ""MONTH_EXPENSE"", ""EXPENSE_ISO_CURRENCY"", ""HOME_CD"", ""TAX_REGULATION_CTRY_CD1"", ""TAX_REGULATION_CTRY_CD2"", ""TAX_REGULATION_CTRY_CD3"", ""TAX_REGULATION_TIN1"", ""TAX_REGULATION_TIN2"", ""TAX_REGULATION_TIN3"", ""RELATION_TO_BANK_CODE"", ""OTHER_BANK_ACCOUNTS"", ""DEALT_BANK_DETAILS"", ""DEAL_ABRD_BANK_DETAILS"", ""BUSINESS_CODE"", ""CALCULATE_ZAKAH_FLAG"", ""CHARITY_FLAG"", ""COMPANY_SALES_AMOUNT_PER_YEAR"", ""CUSTOMER_STATUS"", ""ECONOMIC_MAIN_CODE"", ""ECONOMIC_SUB_CODE"", ""GEO_CODE"", ""LAST_QUERY_DATE"", ""LEGAL_MAIN_CODE"", ""LEGAL_STEP_DATE"", ""LEGAL_STEP_MAIN_CODE"", ""LEGAL_STEP_SUB_CODE"", ""LEGAL_SUB_CODE"", ""REFERRED_PERSON_ADDRESS"", ""REFERRED_PERSON_PHONE"", ""SECTOR_ANALYSES_CODE"", ""WORTH_LAST_CALC_DATE"") AS 
                      select 
                    a.CASE_RK
                    ,a.A_K_A
                    ,r_RT_OPEN_PURPOSE.val_desc OPENING_REASON_ID
                    ,a.AML_RISK_CD
                    ,r_CITIZEN_type.val_desc CITIZEN_OR_RESIDENT
                    ,a.CLIENT_NUMBER
                    ,a.CLOSE_DATE
                    ,RT_CLOSING_REASON.val_desc CLOSING_REASON_ID
                    ,a.CREATE_DATE
                    ,a.CREATED_BY
                    ,a.RISK_CLASS_VALUE
                    ,r_CUST_TYPE.val_desc CUSTOMER_TYPE
                    ,r_branch.val_desc DEFAULT_BRANCH
                    ,RT_CAR_TYPE.val_desc NUMBER_OF_DEPENDENTS
                    ,a.FIRST_NAME
                    ,a.FULL_NAME_AR
                    ,a.FULL_NAME_EN
                    ,RT_GENDER.val_desc GENDER_CD
                    ,r_EDUCATION.val_desc EDUCATION_ID
                    ,a.CB_RISK_ID
                    ,a.KYC_STATUS
                    ,RT_RACE_TYPE.val_desc RACE_ID
                    ,a.LAST_NAME
                    ,r_MARITAL_STATUS.val_desc MARITAL_STATUS_CD
                    ,a.MIDDLE_NAME
                    ,a.MOTHER_NAME
                    ,r_NATIONALITY1.val_desc NATIONALITY_CODE1
                    ,r_NATIONALITY2.val_desc NATIONALITY_CODE2
                    ,r_NATIONALITY3.val_desc NATIONALITY_CODE3
                    ,a.NEXT_UPDATE_DATE
                    ,r_RISK_RATE.val_desc CB_RISK_RATE
                    ,r_RELIGION.val_desc RELIGION
                    ,r_country.val_desc RESIDENCE_COUNTRY
                    ,a.RISK_REASON
                    ,r_RISK_CODE.val_desc RISK_CODE
                    ,r_sector.val_desc SICTOR_CODE
                    ,r_title.val_desc TITLE
                    ,a.UPDATE_DATE
                    ,a.UPDATED_BY
                    ,r_visa_type.val_desc VISA_TYPE
                    --,a.FIRST_NAME_AR
                    ,a.FIRST_NAME_ENG
                    --,a.LAST_NAME_AR
                    ,a.LAST_NAME_ENG
                    --,a.MIDDLE_NAME_AR
                    ,a.MIDDLE_NAME_ENG
                    ,r_langauge.val_desc NAME_LANGUAGE
                    ,r_EMP_IND.val_desc EMPLOYEE_INDICATOR
                    ,a.EDUCATION_ID_OTHER
                    ,a.SPOUSE_BUSINESS
                    ,a.SPOUSE_NAME
                    ,a.VISA_EXPIRATION_DATE
                    ,a.CB_RISK_RATE_OTHER
                    ,a.CLOSING_REASON_ID_OTHER
                    ,a.OPENING_REASON_ID_OTHER
                    ,a.RISK_CODE_OTHER

                    -- EMPLOYMENT_INFO_AUD
                    ,g.EMPLOYMENT_TYPE
                    ,RT_EMPLOYED_BUSINESS.val_desc EMPLOYED_OR_BUSINESS
                    ,g.EMPLOYER_BUSINESS_NAME
                    ,g.EMPLOYER_BUSINESS_ADRS
                    ,g.EMPLOYER_BUSINESS_CITY
                    ,r_EMPLOYER_BUSINESS_CTRY.val_desc EMPLOYER_BUSINESS_CTRY
                    ,g.EMPLOYER_BUSINESS_STATE
                    ,g.EMPLOYER_BUSINESS_TOWN
                    ,g.EMPLOYER_PHONE
                    ,g.EMPLOYER_COUNTRY_PHONE_CODE
                    ,r_OCCUPATION.val_desc OCCUPATION
                    ,g.OCCUPATION_DTL
                    ,r_BUSINESS_SECTOR.val_desc BUSINESS_SECTOR
                    ,g.BUSINESS_SECTOR_OTHERS
                    ,r_PEP_INDICATOR.val_desc PEP_INDICATOR
                    ,r_PEP_INDICATOR_DTLS.val_desc PEP_INDICATOR_DTLS
                    ,g.PEP_INDICATOR_OTH

                    -- TAX_AND_PROPERTIES_INFO_AUD
                    ,l.SOURCE_OF_INCOME_CD
                    ,l.SOURCE_OF_INCOME_OTHER
                    ,l.ANNUAL_INCOME_CD
                    ,l.MONTH_INCOME
                    ,r_INCOME_ISO_CURRENCY.val_desc INCOME_ISO_CURRENCY
                    ,l.MONTH_EXPENSE
                    ,r_EXPENSE_ISO_CURRENCY.val_desc EXPENSE_ISO_CURRENCY
                    ,RT_HOME_TYPE.val_desc HOME_CD
                    ,r_TAX_REGULATION_CTRY_CD1.val_desc TAX_REGULATION_CTRY_CD1
                    ,r_TAX_REGULATION_CTRY_CD2.val_desc TAX_REGULATION_CTRY_CD2
                    ,r_TAX_REGULATION_CTRY_CD3.val_desc TAX_REGULATION_CTRY_CD3
                    ,l.TAX_REGULATION_TIN1
                    ,l.TAX_REGULATION_TIN2
                    ,l.TAX_REGULATION_TIN3

                    -- BANKING_INFO_AUD
                    ,d.RELATION_TO_BANK_CODE
                    ,d.OTHER_BANK_ACCOUNTS
                    ,d.DEALT_BANK_DETAILS
                    ,d.DEAL_ABRD_BANK_DETAILS

                    -- ADDITIONAL_INFO_AUD
                    ,b.BUSINESS_CODE
                    ,b.CALCULATE_ZAKAH_FLAG
                    ,b.CHARITY_FLAG
                    ,b.COMPANY_SALES_AMOUNT_PER_YEAR
                    ,b.CUSTOMER_STATUS
                    ,b.ECONOMIC_MAIN_CODE
                    ,b.ECONOMIC_SUB_CODE
                    ,b.GEO_CODE
                    ,b.LAST_QUERY_DATE
                    ,b.LEGAL_MAIN_CODE
                    ,b.LEGAL_STEP_DATE
                    ,b.LEGAL_STEP_MAIN_CODE
                    ,b.LEGAL_STEP_SUB_CODE
                    ,b.LEGAL_SUB_CODE
                    ,b.REFERRED_PERSON_ADDRESS
                    ,b.REFERRED_PERSON_PHONE
                    ,b.SECTOR_ANALYSES_CODE
                    ,b.WORTH_LAST_CALC_DATE


                    FROM 
                    DGKYC.personal_info_aud@DGKYC_LINK a 
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_langauge on a.name_language = r_langauge.val_cd and r_langauge.REF_TABLE_NAME='X_RT_LANGUAGE_CODE'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_country on a.RESIDENCE_COUNTRY = r_country.val_cd and r_country.REF_TABLE_NAME='X_RT_COUNTRY'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_title on a.TITLE = r_title.val_cd and r_title.REF_TABLE_NAME='X_RT_PREFIX_TITLE'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_visa_type on a.VISA_TYPE = r_visa_type.val_cd and r_visa_type.REF_TABLE_NAME='X_RT_RESIDENCY_TYPE'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_branch on a.DEFAULT_BRANCH = r_branch.val_cd and r_branch.REF_TABLE_NAME='X_RT_FIB_BRANCHES'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_MARITAL_STATUS on a.MARITAL_STATUS_CD = r_MARITAL_STATUS.val_cd and r_MARITAL_STATUS.REF_TABLE_NAME='X_RT_MARITAL_STATUS'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_NATIONALITY1 on a.NATIONALITY_CODE1 = r_NATIONALITY1.val_cd and r_NATIONALITY1.REF_TABLE_NAME='X_RT_AD_RM_NAT'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_NATIONALITY2 on a.NATIONALITY_CODE2 = r_NATIONALITY2.val_cd and r_NATIONALITY2.REF_TABLE_NAME='X_RT_AD_RM_NAT'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_NATIONALITY3 on a.NATIONALITY_CODE3 = r_NATIONALITY3.val_cd and r_NATIONALITY3.REF_TABLE_NAME='X_RT_AD_RM_NAT'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_CITIZEN_type on a.CITIZEN_OR_RESIDENT = r_CITIZEN_type.val_cd and r_CITIZEN_type.REF_TABLE_NAME='X_RT_RESIDENCY_TYPE'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_CUST_TYPE on a.CUSTOMER_TYPE = r_CUST_TYPE.val_cd and r_CUST_TYPE.REF_TABLE_NAME='X_RT_INDV_CUST_TYPE'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK RT_GENDER on a.GENDER_CD = RT_GENDER.val_cd and RT_GENDER.REF_TABLE_NAME='X_RT_GENDER'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_RT_OPEN_PURPOSE on a.OPENING_REASON_ID = r_RT_OPEN_PURPOSE.val_cd and r_RT_OPEN_PURPOSE.REF_TABLE_NAME='X_RT_OPEN_PURPOSE'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_EDUCATION on a.EDUCATION_ID = r_EDUCATION.val_cd and r_EDUCATION.REF_TABLE_NAME='X_RT_AD_RM_EDUCATION'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_RISK_RATE on a.CB_RISK_RATE = r_RISK_RATE.val_cd and r_RISK_RATE.REF_TABLE_NAME='X_RT_AD_GB_RISK'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_RISK_CODE on a.RISK_CODE = r_RISK_CODE.val_cd and r_RISK_CODE.REF_TABLE_NAME='X_RT_AD_GB_RISK'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK RT_CAR_TYPE on a.NUMBER_OF_DEPENDENTS = RT_CAR_TYPE.val_cd and RT_CAR_TYPE.REF_TABLE_NAME='X_RT_CAR_TYPE'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK RT_RACE_TYPE on a.RACE_ID = RT_RACE_TYPE.val_cd and RT_RACE_TYPE.REF_TABLE_NAME='X_RT_AD_RM_RACE'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK RT_CLOSING_REASON on a.CLOSING_REASON_ID = RT_CLOSING_REASON.val_cd and RT_CLOSING_REASON.REF_TABLE_NAME='X_RT_CLOSING_REASON'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_sector on a.SICTOR_CODE = r_sector.val_cd and r_sector.REF_TABLE_NAME='X_RT_OCCU_ETNTY_CD'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_RELIGION on a.RELIGION = r_RELIGION.val_cd and r_RELIGION.REF_TABLE_NAME='X_RT_RELIGION'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_EMP_IND on a.EMPLOYEE_INDICATOR = r_EMP_IND.val_cd and r_EMP_IND.REF_TABLE_NAME='X_RT_YES_NO'

                    LEFT JOIN
                    DGKYC.BANKING_INFO_AUD@DGKYC_LINK D ON a.case_rk=D.case_rk and a.update_date =D.update_date LEFT JOIN
                    DGKYC.EMPLOYMENT_INFO_AUD@DGKYC_LINK G ON a.case_rk=G.case_rk and a.update_date =G.update_date 
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_BUSINESS_SECTOR on g.BUSINESS_SECTOR = r_BUSINESS_SECTOR.val_cd and r_BUSINESS_SECTOR.REF_TABLE_NAME='X_RT_EMPL_CATEGORY'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_OCCUPATION on g.OCCUPATION = r_OCCUPATION.val_cd and r_OCCUPATION.REF_TABLE_NAME='X_RT_OCCUPATION_CD'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK RT_EMPLOYED_BUSINESS on g.EMPLOYED_OR_BUSINESS = RT_EMPLOYED_BUSINESS.val_cd and RT_EMPLOYED_BUSINESS.REF_TABLE_NAME='X_RT_EMPLOYED_BUSINESS'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_EMPLOYER_BUSINESS_CTRY on g.EMPLOYER_BUSINESS_CTRY = r_EMPLOYER_BUSINESS_CTRY.val_cd and r_EMPLOYER_BUSINESS_CTRY.REF_TABLE_NAME='X_RT_COUNTRY'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_PEP_INDICATOR on g.PEP_INDICATOR = r_PEP_INDICATOR.val_cd and r_PEP_INDICATOR.REF_TABLE_NAME='X_RT_PEP'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_PEP_INDICATOR_DTLS on g.PEP_INDICATOR_DTLS = r_PEP_INDICATOR_DTLS.val_cd and r_PEP_INDICATOR_DTLS.REF_TABLE_NAME='X_RT_PEP_DTLS'

                    LEFT JOIN
                    DGKYC.TAX_AND_PROPERTIES_INFO_AUD@DGKYC_LINK L ON a.case_rk=L.case_rk and a.update_date =L.update_date
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_TAX_REGULATION_CTRY_CD1 on L.TAX_REGULATION_CTRY_CD1 = r_TAX_REGULATION_CTRY_CD1.val_cd and r_TAX_REGULATION_CTRY_CD1.REF_TABLE_NAME='X_RT_COUNTRY'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_TAX_REGULATION_CTRY_CD2 on L.TAX_REGULATION_CTRY_CD2 = r_TAX_REGULATION_CTRY_CD2.val_cd and r_TAX_REGULATION_CTRY_CD2.REF_TABLE_NAME='X_RT_COUNTRY'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_TAX_REGULATION_CTRY_CD3 on L.TAX_REGULATION_CTRY_CD3 = r_TAX_REGULATION_CTRY_CD3.val_cd and r_TAX_REGULATION_CTRY_CD3.REF_TABLE_NAME='X_RT_COUNTRY'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK RT_HOME_TYPE on L.HOME_CD = RT_HOME_TYPE.val_cd and RT_HOME_TYPE.REF_TABLE_NAME='X_RT_HOME_TYPE'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_EXPENSE_ISO_CURRENCY on L.EXPENSE_ISO_CURRENCY = r_EXPENSE_ISO_CURRENCY.val_cd and r_EXPENSE_ISO_CURRENCY.REF_TABLE_NAME='X_RT_CURRENCY'
                    LEFT JOIN DGKYC.ref_table_trans@DGKYC_LINK r_INCOME_ISO_CURRENCY on L.INCOME_ISO_CURRENCY = r_INCOME_ISO_CURRENCY.val_cd and r_INCOME_ISO_CURRENCY.REF_TABLE_NAME='X_RT_CURRENCY'

                    LEFT JOIN
                    DGKYC.ADDITIONAL_INFO_AUD@DGKYC_LINK b ON a.case_rk=b.case_rk and a.update_date =b.update_date
                    order by a.case_rk,a.update_date desc;");
            //ART_KYC_EXPIRED_ID
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_EXPIRED_ID
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_EXPIRED_ID"" (""CLIENT_NUMBER"", ""ENTITY_NAME"", ""ID_NUMBER"", ""ID_EXPIRE_DATE"") AS 
              select  b.CLIENT_NUMBER, b.full_name_ar as Entity_Name, a.ID_NUMBER, a.ID_EXPIRE_DATE  from DGKYC.id_info@DGKYC_LINK a join DGKYC.personal_info@DGKYC_LINK b
            on a.case_rk = b.case_rk 
            where 
            ROUND(MONTHS_BETWEEN(ID_EXPIRE_DATE,SYSDATE),2) <= 0
            --and a.CASE_RK  between 4000000 and 5183998
            union all
            select  b.CLIENT_NUMBER, b.industry as Entity_Name, a.ID_NUMBER, a.ID_EXPIRE_DATE  from DGKYC.id_info@DGKYC_LINK a join DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK b
            on a.case_rk = b.case_rk 
            where 
            ROUND(MONTHS_BETWEEN(ID_EXPIRE_DATE,SYSDATE),2) <= 0
            --and a.CASE_RK  between  5183998 and 5209999
            ;");
            //ART_KYC_HIGH_EXPIRED
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_HIGH_EXPIRED
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_HIGH_EXPIRED"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'H'
            and 
            EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) <= 0
            --and a.CASE_RK  between 4000000 and 5183998

            union all

            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.','')) as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'H'
            and 
            EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) <= 0
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_HIGH_ONE_MONTH
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_HIGH_ONE_MONTH
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_HIGH_ONE_MONTH"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"", ""MONTH"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'H'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 0 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=1
            --and a.CASE_RK  between 4000000 and 5183998
            union all
            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.',''))  as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month 
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a
            where a.AML_RISK_CD = 'H'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 0 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=1
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_HIGH_THREE_MONTH
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_HIGH_THREE_MONTH
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_HIGH_THREE_MONTH"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"", ""MONTH"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'H'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 2 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=3
            --and a.CASE_RK  between 4000000 and 5183998
            union all
            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.',''))  as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month 
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a
            where a.AML_RISK_CD = 'H'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 2 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=3
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_HIGH_TWO_MONTH
            migrationBuilder.Sql($@"
             --------------------------------------------------------
             --  DDL for View ART_KYC_HIGH_TWO_MONTH
             --------------------------------------------------------

                  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_HIGH_TWO_MONTH"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"", ""MONTH"") AS 
                  select 
                a.CLIENT_NUMBER,
                (case 
                when AML_RISK_CD = 'H' then 'High'
                when AML_RISK_CD = 'M' then 'Medium'
                when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
                'Individual' Type,
                trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
                when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
                ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month
                from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
                where a.AML_RISK_CD = 'H'
                and 
                ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 1 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=2
                --and a.CASE_RK  between 4000000 and 5183998
                union all
                select 
                a.CLIENT_NUMBER,
                (case 
                when AML_RISK_CD = 'H' then 'High'
                when AML_RISK_CD = 'M' then 'Medium'
                when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
                'Corporate' Type,
                trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
                when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.',''))  as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
                ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month 
                from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a
                where a.AML_RISK_CD = 'H'
                and 
                ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 1 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=2
                --and a.CASE_RK  between 5183998 and 5209999
                ;");
            //ART_KYC_LOW_EXPIRED
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_LOW_EXPIRED
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_LOW_EXPIRED"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'L'
            and 
            EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) <= 0
            --and a.CASE_RK  between 4000000 and 5183998

            union all

            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.','')) as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'L'
            and 
            EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) <= 0
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_LOW_ONE_MONTH
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_LOW_ONE_MONTH
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_LOW_ONE_MONTH"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"", ""MONTH"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'L'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 0 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=1
            --and a.CASE_RK  between 4000000 and 5183998
            union all
            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.',''))  as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month 
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a
            where a.AML_RISK_CD = 'L'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 0 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=1
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_LOW_THREE_MONTH
            migrationBuilder.Sql($@"
             --------------------------------------------------------
             --  DDL for View ART_KYC_LOW_THREE_MONTH
             --------------------------------------------------------

                  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_LOW_THREE_MONTH"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"", ""MONTH"") AS 
                  select 
                a.CLIENT_NUMBER,
                (case 
                when AML_RISK_CD = 'H' then 'High'
                when AML_RISK_CD = 'M' then 'Medium'
                when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
                'Individual' Type,
                trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
                when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
                ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month
                from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
                where a.AML_RISK_CD = 'L'
                and 
                ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 2 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=3
                --and a.CASE_RK  between 4000000 and 5183998
                union all
                select 
                a.CLIENT_NUMBER,
                (case 
                when AML_RISK_CD = 'H' then 'High'
                when AML_RISK_CD = 'M' then 'Medium'
                when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
                'Corporate' Type,
                trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
                when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.',''))  as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
                ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month 
                from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a
                where a.AML_RISK_CD = 'L'
                and 
                ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 2 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=3
                --and a.CASE_RK  between 5183998 and 5209999
                ;");
            //ART_KYC_LOW_TWO_MONTH
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_LOW_TWO_MONTH
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_LOW_TWO_MONTH"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"", ""MONTH"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'L'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 1 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=2
            --and a.CASE_RK  between 4000000 and 5183998
            union all
            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.',''))  as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month 
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a
            where a.AML_RISK_CD = 'L'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 1 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=2
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_MEDIUM_EXPIRED
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_MEDIUM_EXPIRED
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_MEDIUM_EXPIRED"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'M'
            and 
            EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) <= 0
            --and a.CASE_RK  between 4000000 and 5183998

            union all

            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.','')) as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'M'
            and 
            EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) <= 0
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_MEDIUM_ONE_MONTH
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_MEDIUM_ONE_MONTH
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_MEDIUM_ONE_MONTH"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"", ""MONTH"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'M'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 0 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=1
            --and a.CASE_RK  between 4000000 and 5183998
            union all
            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.',''))  as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month 
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a
            where a.AML_RISK_CD = 'M'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 0 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=1
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_MEDIUM_TWO_MONTH
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_MEDIUM_TWO_MONTH
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_MEDIUM_TWO_MONTH"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"", ""MONTH"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'M'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 1 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=2
            --and a.CASE_RK  between 4000000 and 5183998
            union all
            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.',''))  as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month 
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a
            where a.AML_RISK_CD = 'M'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 1 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=2
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_MEDIUM_THREE_MONTH
            migrationBuilder.Sql($@"
            --------------------------------------------------------
            --  DDL for View ART_KYC_MEDIUM_THREE_MONTH
            --------------------------------------------------------

              CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_MEDIUM_THREE_MONTH"" (""CLIENT_NUMBER"", ""AML_RISK"", ""TYPE"", ""ENTITY_NAME"", ""RISK_CLASS/INDUSTRY"", ""NEXT_UPDATE_DATE"", ""MONTH"") AS 
              select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Individual' Type,
            trim(replace((case when full_name_ar like '/%' then substr(full_name_ar,2) 
            when full_name_ar like '%/' then substr(full_name_ar,1,length(full_name_ar)-1) else full_name_ar end),'.','')) as Entity_Name, RISK_CLASS_VALUE ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month
            from DGKYC.PERSONAL_INFO@DGKYC_LINK a 
            where a.AML_RISK_CD = 'M'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 2 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=3
            --and a.CASE_RK  between 4000000 and 5183998
            union all
            select 
            a.CLIENT_NUMBER,
            (case 
            when AML_RISK_CD = 'H' then 'High'
            when AML_RISK_CD = 'M' then 'Medium'
            when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
            'Corporate' Type,
            trim(replace((case when CORPORATE_NAME like '/%' then substr(CORPORATE_NAME,2) 
            when CORPORATE_NAME like '%/' then substr(CORPORATE_NAME,1,length(CORPORATE_NAME)-1) else CORPORATE_NAME end),'.',''))  as Entity_Name, INDUSTRY ""RISK_CLASS/INDUSTRY"", NEXT_UPDATE_DATE,
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2)month 
            from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK a
            where a.AML_RISK_CD = 'M'
            and 
            ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) > 2 and ROUND(MONTHS_BETWEEN(NEXT_UPDATE_DATE,SYSDATE),2) <=3
            --and a.CASE_RK  between 5183998 and 5209999
            ;");
            //ART_KYC_SUMMARY_BY_RISK
            migrationBuilder.Sql($@"
             --------------------------------------------------------
             --  DDL for View ART_KYC_SUMMARY_BY_RISK
             --------------------------------------------------------

                  CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART"".""ART_KYC_SUMMARY_BY_RISK"" (""AML_RISK"", ""TYPE"", ""NUMBER_OF_UPDATED_KYC"", ""NUMBER_OF_NOT_UPDATED_KYC"", ""TOTAL"") AS 
                  select 
                (case 
                when AML_RISK_CD = 'H' then 'High'
                when AML_RISK_CD = 'M' then 'Medium'
                when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
                'Personal' Type,
                count(case when EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) > 0 then client_number end) Number_Of_Updated_KYC,
                count(case when EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) <= 0 or NEXT_UPDATE_DATE is null then client_number end) Number_Of_Not_Updated_KYC,
                count(client_number) Total
                from DGKYC.PERSONAL_INFO@DGKYC_LINK 
                --where CASE_RK  between 4000000 and 5183998
                group by 
                (case 
                when AML_RISK_CD = 'H' then 'High'
                when AML_RISK_CD = 'M' then 'Medium'
                when AML_RISK_CD = 'L' then 'Low' end),
                'Personal'
                union all 
                select 
                (case 
                when AML_RISK_CD = 'H' then 'High'
                when AML_RISK_CD = 'M' then 'Medium'
                when AML_RISK_CD = 'L' then 'Low' end)AML_Risk,
                'Corporate' Type,
                count(case when EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) > 0 then client_number end) Number_Of_Updated_KYC,
                count(case when EXTRACT(day from (NEXT_UPDATE_DATE - SYSDATE)) <= 0 or NEXT_UPDATE_DATE is null then client_number end) Number_Of_Not_Updated_KYC,
                count(client_number) Total
                from DGKYC.CORPORATE_BASIC_INFO@DGKYC_LINK 
                --where CASE_RK  between 5183998 and 5209999
                group by 
                (case 
                when AML_RISK_CD = 'H' then 'High'
                when AML_RISK_CD = 'M' then 'Medium'
                when AML_RISK_CD = 'L' then 'Low' end),
                'Corporate'
                ;");
            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
