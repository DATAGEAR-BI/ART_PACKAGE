﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations.AmlAnalysis
{
    public partial class addAmlanalysis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ART_DB");

            migrationBuilder.Sql($@"
                CREATE VIEW ART_DB.ART_AML_ANALYSIS_VIEW AS
                SELECT * FROM fcf71_update2.FCFKC.ART_AML_ANALYSIS_VIEW
            ");
            
            
            migrationBuilder.CreateTable(
                name: "ART_AML_ANALYSIS_VIEW_TB",
                schema: "ART_DB",
                columns: table => new
                {
                    PREDICTION = table.Column<double>(type: "float", nullable: true),
                    PARTY_NUMBER = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    MONTH_KEY = table.Column<string>(type: "varchar(24)", unicode: false, maxLength: 24, nullable: true),
                    RISK_CLASSIFICATION = table.Column<int>(type: "int", nullable: true),
                    PARTY_TYPE_DESC = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    INDUSTRY_CODE = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    INDUSTRY_DESC = table.Column<string>(type: "varchar(1020)", unicode: false, maxLength: 1020, nullable: true),
                    OCCUPATION_CODE = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    OCCUPATION_DESC = table.Column<string>(type: "varchar(220)", unicode: false, maxLength: 220, nullable: true),
                    TOTAL_CREDIT_AMOUNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_DEBIT_AMOUNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CREDIT_CNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_DEBIT_CNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_AMOUNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CNT = table.Column<double>(type: "float", nullable: true),
                    NUMBER_OF_LOCATIONS = table.Column<double>(type: "float", nullable: true),
                    AVG_WIRE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_WIRE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_WIRE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_WIRE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_WIRE_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MAX_WIRE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_WIRE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_WIRE_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_WIRE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_WIRE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_BUYSECURITY_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_BUYSECURITY_C_CNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_BUYSECURITY_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_BUYSECURITY_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_BUYSECURITY_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CASH_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CASH_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_CASH_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_CASH_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_CASH_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_CASH_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CASH_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CASH_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_CASH_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_CASH_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CHECK_D_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_CHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_CHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_CHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_CLEARINGCHECK_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_CLEARINGCHECK_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_CLEARINGCHECK_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CLEARINGCHECK_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CLEARINGCHECK_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MAX_CLEARINGCHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_CLEARINGCHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CLEARINGCHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_CLEARINGCHECK_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_CLEARINGCHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_DERIVATIVES_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_DERIVATIVES_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_DERIVATIVES_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_DERIVATIVES_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_DERIVATIVES_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MAX_DERIVATIVES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_DERIVATIVES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_DERIVATIVES_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_DERIVATIVES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_DERIVATIVES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_INHOUSECHECK_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_INHOUSECHECK_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_INHOUSECHECK_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_INHOUSECHECK_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_INHOUSECHECK_C_CNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_INHOUSECHECK_D_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_INHOUSECHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_INHOUSECHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_INHOUSECHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_INHOUSECHECK_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_INTERNALTRANSFER_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_INTERNALTRANSFER_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_INTERNALTRANSFER_C_CNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_INTERNALTRANSFER_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_INTERNALTRANSFER_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_INTERNALTRANSFER_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_INTERNALTRANSFER_D_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_INTERNALTRANSFER_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_INTERNALTRANSFER_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_INTERNALTRANSFER_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_LC_BL_CLCN_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_LC_BL_CLCN_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LC_BL_CLCN_C_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_LC_BL_CLCN_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LC_BL_CLCN_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LC_BL_CLCN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_LC_BL_CLCN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_LC_BL_CLCN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_LC_BL_CLCN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LC_BL_CLCN_D_CNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LCCOLLECTION_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MAX_LCCOLLECTION_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_LCCOLLECTION_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_LCCOLLECTION_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LCCOLLECTION_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LCCOLLECTION_D_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_LCCOLLECTION_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_LCCOLLECTION_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LCCOLLECTION_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_LCCOLLECTION_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LOAN_C_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_LOAN_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_LOAN_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LOAN_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_LOAN_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LOAN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_LOAN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_LOAN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LOAN_D_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_LOAN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_LOANDISBURSEMENT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_LOANDISBURSEMENT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_LOANDISBURSEMENT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LOANDISBURSEMENT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LOANDISBURSEMENT_C_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_LOANTOP_UP_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_LOANTOP_UP_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LOANTOP_UP_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_LOANTOP_UP_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MAX_LOANTOP_UP_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_MNGRSCHCKISSNCE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_MNGRSCHCKISSNCE_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MAX_MNGRSCHCKISSNCE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_MNGRSCHCKISSNCE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_MNGRSCHCKISSNCE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_MNGRSCHCKISSNCE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_MNGRSCHCKISSNCE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_MNGRSCHCKISSNCE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_MNGRSCHCKISSNCE_D_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_MNGRSCHCKISSNCE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_MISC_C_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_MISC_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_MISC_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_MISC_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_MISC_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_MISC_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_MISC_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_MISC_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_MISC_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_MISC_D_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_OUTWRDCHQRTRN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_OUTWRDCHQRTRN_D_CNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_OUTWRDCHQRTRN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_OUTWRDCHQRTRN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_OUTWRDCHQRTRN_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_PYMNTOFINSTLLMNT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_PYMNTOFINSTLLMNT_D_CNT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_PYMNTOFINSTLLMNT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_PYMNTOFINSTLLMNT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_PYMNTOFINSTLLMNT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_RETURNEDWIRES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_RETURNEDWIRES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_RETURNEDWIRES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_RETURNEDWIRES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_RETURNEDWIRES_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MAX_RETURNCHEQUE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_RETURNCHEQUE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_RETURNCHEQUE_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_RETURNCHEQUE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_RETURNCHEQUE_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SALARYCREDIT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SALARYCREDIT_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_SALARYCREDIT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_SALARYCREDIT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_SALARYCREDIT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_SALARYDEBIT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SALARYDEBIT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SALARYDEBIT_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_SALARYDEBIT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_SALARYDEBIT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SECURITIES_C_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_SECURITIES_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_SECURITIES_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SECURITIES_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_SECURITIES_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_SECURITIES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_SECURITIES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_SECURITIES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SECURITIES_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SECURITIES_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MAX_SELLSECURITY_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_SELLSECURITY_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SELLSECURITY_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_SELLSECURITY_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_SELLSECURITY_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TDREDEMPTION_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TDREDEMPTION_C_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_TDREDEMPTION_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_TDREDEMPTION_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_TDREDEMPTION_C_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_TDREDEMPTION_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TDREDEMPTION_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TDREDEMPTION_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_TDREDEMPTION_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_TDREDEMPTION_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TERMDEPOSIT_C_CNT = table.Column<double>(type: "float", nullable: true),
                    AVG_TERMDEPOSIT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_TERMDEPOSIT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TERMDEPOSIT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_TERMDEPOSIT_C_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_TERMDEPOSIT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MIN_TERMDEPOSIT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_TERMDEPOSIT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TERMDEPOSIT_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TERMDEPOSIT_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MAX_TTISSUANCE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    AVG_TTISSUANCE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TTISSUANCE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    TOTAL_TTISSUANCE_D_CNT = table.Column<double>(type: "float", nullable: true),
                    MIN_TTISSUANCE_D_AMT = table.Column<double>(type: "float", nullable: true),
                    MAX_MLS = table.Column<int>(type: "int", nullable: true),
                    ALERTS_CNT = table.Column<double>(type: "float", nullable: true),
                    PARTY_NAME = table.Column<string>(type: "varchar(800)", unicode: false, maxLength: 800, nullable: true),
                    ALERTS_COUNT = table.Column<int>(type: "int", nullable: true),
                    CLOSED_ALERTS_COUNT = table.Column<double>(type: "float", nullable: true),
                    SEGMENT = table.Column<decimal>(type: "numeric(13,0)", nullable: true),
                    SEGMENT_SORTED = table.Column<decimal>(type: "numeric(13,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ArtAmlAnalysisRules",
                schema: "ART_DB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadableOutPut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sql = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RouteToUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtAmlAnalysisRules", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ART_AML_ANALYSIS_VIEW_TB",
                schema: "ART_DB");

            migrationBuilder.DropTable(
                name: "ArtAmlAnalysisRules",
                schema: "ART_DB");
        }
    }
}