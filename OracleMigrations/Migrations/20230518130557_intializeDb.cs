using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class intializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtSavedCustomReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Schema = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Table = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtSavedCustomReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtSavedCustomReport_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    RoleId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtSavedReportsChart",
                columns: table => new
                {
                    Type = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Column = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ReportId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtSavedReportsChart", x => new { x.ReportId, x.Column, x.Type });
                    table.ForeignKey(
                        name: "FK_ArtSavedReportsChart_ArtSavedCustomReport_ReportId",
                        column: x => x.ReportId,
                        principalTable: "ArtSavedCustomReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtSavedReportsColumns",
                columns: table => new
                {
                    Column = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ReportId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtSavedReportsColumns", x => new { x.ReportId, x.Column });
                    table.ForeignKey(
                        name: "FK_ArtSavedReportsColumns_ArtSavedCustomReport_ReportId",
                        column: x => x.ReportId,
                        principalTable: "ArtSavedCustomReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83393df2-1bfa-471d-9a8a-8bf7c4b3f112", "5a7f54de-0438-489b-8890-4200b7bc54f1", "CutomReport", "CUTOMREPORT" },
                    { "ae3a9d7a-5adf-4cd9-85c4-517e59d08513", "81999050-63d2-4f85-9479-e71e117e5c0e", "Admin", "ADMIN" },
                    { "e60411ee-1127-4f5e-8f03-367ef13017a6", "716d9c6a-bad1-40ee-a900-05ce1973368a", "Home", "HOME" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "ee8af197-0a20-40c8-9142-866f7db66561", "Art_Admin@datagearbi.com", true, false, null, "ART_ADMIN@DATAGEARBI.COM", "ART_ADMIN@DATAGEARBI.COM", "AQAAAAEAACcQAAAAEGBtG+0sBXZmCmDvSBPhn4wLD9RwWf72ZnOQlrBg+KxVkYyaWDA5CQctBsFx/gyqXg==", null, false, "79c023e3-841e-4d28-93cd-68b434a4432e", false, "Art_Admin@datagearbi.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "83393df2-1bfa-471d-9a8a-8bf7c4b3f112", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ae3a9d7a-5adf-4cd9-85c4-517e59d08513", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e60411ee-1127-4f5e-8f03-367ef13017a6", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtSavedCustomReport_UserId",
                table: "ArtSavedCustomReport",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "\"NormalizedName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "\"NormalizedUserName\" IS NOT NULL");

            if (ProjType.GetType().Equals(ProjType.AML))
            {
                //create AML Views
                migrationBuilder.Sql($@"
                USE [ART_DB]
                GO
                CREATE SCHEMA [ART_DB];
                GO
                /****** Object:  View [FCFKC].[ART_HOME_ALERTS_PER_STATUS]    Script Date: 5/22/2023 10:11:01 AM ******/

                create view ART_DB.ART_HOME_ALERTS_PER_STATUS as
                select  (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end) ALERT_STATUS,
                count(FSK_ALERT.alert_id) Alerts_Count
                FROM fcf71.fcfkc.FSK_ALERT FSK_ALERT 
                LEFT JOIN 
                fcf71.FCFKC.FSK_LOV ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                group by (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end);


                -------------------------------------------------------------------------------

                /****** Object:  View [FCFKC].[ART_HOME_ALERTS_PER_DATE]    Script Date: 5/22/2023 10:22:37 AM ******/

                create view [ART_DB].[ART_HOME_ALERTS_PER_DATE] as
                select Year_ Year,Month__ Month,Day_ Day,Number_Of_ALerts from
                (select 
                EXTRACT(YEAR FROM a.create_date) Year_,
                EXTRACT(Month FROM a.create_date) Month_,
                to_Char(a.create_date,'Month') Month__,
                EXTRACT(Day FROM a.create_date) Day_,
                count(a.alert_id) Number_Of_ALerts
                from  fcf71.fcfkc.FSK_ALERT a
                group by 
                EXTRACT(YEAR FROM a.create_date),
                EXTRACT(Month FROM a.create_date) ,
                to_Char(a.create_date,'Month'),
                EXTRACT(Day FROM a.create_date)
                EXTRACT(YEAR FROM a.create_date) desc,EXTRACT(Month FROM a.create_date)  desc,EXTRACT(Day FROM a.create_date) desc
                );



                ---------------------------------------------------------------------------

                /****** Object:  View [FCFCORE].[ART_HOME_NUMBER_OF_CUSTOMERS]    Script Date: 5/22/2023 11:12:40 AM ******/

                create view [ART_DB].[ART_HOME_NUMBER_OF_CUSTOMERS] AS
                select  count(*) Number_Of_Customers
                FROM fcf71.fcfcore.FSC_PARTY_DIM a
                where a.change_current_ind = 'Y';

                ---------------------------------------------------------------------------

                /****** Object:  View [FCFCORE].[ART_HOME_NUMBER_OF_PEP_CUSTOMERS]    Script Date: 5/22/2023 11:21:05 AM ******/

                create view [ART_DB].[ART_HOME_NUMBER_OF_PEP_CUSTOMERS] AS
                select  count(*) Number_Of_PEP_Customers
                FROM fcf71.fcfcore.FSC_PARTY_DIM a
                where a.change_current_ind = 'Y'
                and a.politically_exposed_person_ind = 'Y';

                ----------------------------------------------------------------------

                /****** Object:  View [FCFCORE].[ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS]    Script Date: 5/22/2023 11:20:09 AM ******/

                create view [ART_DB].[ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS] AS
                select  count(*) Number_Of_High_Risk_Customers
                FROM fcf71.fcfcore.FSC_PARTY_DIM a
                where a.change_current_ind = 'Y'
                and a.risk_classification = '3';

                ---------------------------------------------------------------------------

                /****** Object:  View [FCFCORE].[ART_HOME_Number_Of_Accounts]    Script Date: 5/22/2023 11:22:35 AM ******/

                create view [ART_DB].[ART_HOME_Number_Of_Accounts] AS
                select  count(*) Number_Of_Accounts
                FROM fcf71.fcfcore.FSC_ACCOUNT_DIM a
                where a.change_current_ind = 'Y';



            
            ");
            }
            else if (ProjType.GetType().Equals(ProjType.SANCTION))
            {
                //create ECM Views
                migrationBuilder.Sql($@"
                                        
                                        USE [ART_DB]
                                        GO
                                        CREATE SCHEMA [ART_DB];
                                        GO
                                        --------------------------------------------------------
                                        --  DDL for View ART_HOME_CASES_DATE
                                        --------------------------------------------------------

                                          CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART_DB"".""ART_HOME_CASES_DATE"" (""YEAR"", ""MONTH"", ""DAY"", ""NUMBER_OF_CASES"") AS 
                                          select Year_ Year,Month__ Month,Day_ Day,Number_Of_Cases from
                                        (
                                        select
                                        EXTRACT(YEAR FROM a.create_date) Year_,
                                        EXTRACT(Month FROM a.create_date) Month_,
                                        to_Char(a.create_date,'Month') Month__,
                                        EXTRACT(Day FROM a.create_date) Day_,
                                        count(a.case_rk) Number_Of_Cases
                                        from
                                        dgecm.dgcmgmt.case_live A 

                                        --where
                                        --A.CASE_STAT_CD IN ('MSC','SMT','ST','HIT','SC','NOHIT','SP','POSTPOND','SO','SN')
                                        group by 
                                        EXTRACT(YEAR FROM a.create_date),
                                        EXTRACT(Month FROM a.create_date) ,
                                        to_Char(a.create_date,'Month'),
                                        EXTRACT(Day FROM a.create_date)
                                        order by  EXTRACT(YEAR FROM a.create_date) desc,EXTRACT(Month FROM a.create_date)  desc,EXTRACT(Day FROM a.create_date) desc
                                        )
                                        ;
                                        --------------------------------------------------------
                                        --  DDL for View ART_HOME_CASES_STATUS
                                        --------------------------------------------------------

                                          CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART_DB"".""ART_HOME_CASES_STATUS"" (""CASE_STATUS"", ""NUMBER_OF_CASES"") AS 
                                          select 
                                        (CASE 
                                           WHEN A.CASE_STAT_CD IN ('MSC','SC','NOHIT') THEN 'NoHit' 
                                           WHEN A.CASE_STAT_CD IN ('SMT','ST','HIT') THEN 'Hit' 
                                           WHEN A.CASE_STAT_CD IN ('POSTPOND','SP') THEN 'Postponed' 
                                           WHEN A.CASE_STAT_CD ='SO' THEN 'Open' 
                                           WHEN A.CASE_STAT_CD ='SN' THEN 'New' END) CASE_STATUS,
                                           count(a.case_rk) Number_Of_Cases
                                        from
                                        dgecm.dgcmgmt.case_live A 
                                        --where
                                        --A.CASE_STAT_CD IN ('MSC','SMT','ST','HIT','SC','NOHIT','SP','POSTPOND','SO','SN')
                                        group by
                                        (CASE 
                                           WHEN A.CASE_STAT_CD IN ('MSC','SC','NOHIT') THEN 'NoHit' 
                                           WHEN A.CASE_STAT_CD IN ('SMT','ST','HIT') THEN 'Hit' 
                                           WHEN A.CASE_STAT_CD IN ('POSTPOND','SP') THEN 'Postponed' 
                                           WHEN A.CASE_STAT_CD ='SO' THEN 'Open' 
                                           WHEN A.CASE_STAT_CD ='SN' THEN 'New' END);
                                        --------------------------------------------------------
                                        --  DDL for View ART_HOME_CASES_TYPES
                                        --------------------------------------------------------

                                          CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART_DB"".""ART_HOME_CASES_TYPES"" (""CASE_TYPE"", ""NUMBER_OF_CASES"") AS 
                                          select 
                                        (CASE 
                                          WHEN CASE_TYPE.VAL_DESC = 'Sanction Customer Manual ' THEN 'Manual Customer Search'
                                          WHEN CASE_TYPE.VAL_DESC = 'Sanction Web search' THEN 'Watchlist Manual Search' 
                                          ELSE CASE_TYPE.VAL_DESC END)CASE_TYPE,
                                           count(a.case_rk) Number_Of_Cases
  
                                          from
                                        dgecm.dgcmgmt.case_live A 
                                        LEFT JOIN dgecm.dgcmgmt.REF_TABLE_VAL CASE_TYPE 
                                        ON CASE_TYPE.VAL_CD = a.CASE_TYPE_CD
                                        AND CASE_TYPE.REF_TABLE_NAME='RT_CASE_TYPE'

                                        --where
                                        --A.CASE_STAT_CD IN ('MSC','SMT','ST','HIT','SC','NOHIT','SP','POSTPOND','SO','SN')
                                        group by
                                          (CASE 
                                          WHEN CASE_TYPE.VAL_DESC = 'Sanction Customer Manual ' THEN 'Manual Customer Search'
                                          WHEN CASE_TYPE.VAL_DESC = 'Sanction Web search' THEN 'Watchlist Manual Search' 
                                          ELSE CASE_TYPE.VAL_DESC END);


                ");
            }
            else if (ProjType.GetType().Equals(ProjType.AML_AND_SANCTION))
            {
                //create AML Views
                migrationBuilder.Sql($@"
                USE [ART_DB]
                GO
                CREATE SCHEMA [ART_DB];
                GO
                /****** Object:  View [FCFKC].[ART_HOME_ALERTS_PER_STATUS]    Script Date: 5/22/2023 10:11:01 AM ******/

                create view ART_DB.ART_HOME_ALERTS_PER_STATUS as
                select  (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end) ALERT_STATUS,
                count(FSK_ALERT.alert_id) Alerts_Count
                FROM fcf71.fcfkc.FSK_ALERT FSK_ALERT 
                LEFT JOIN 
                fcf71.FCFKC.FSK_LOV ALERT_STATUS ON FSK_ALERT.ALERT_STATUS_CODE = Alert_Status.Lov_Type_Code
                and ALERT_STATUS.LOV_TYPE_NAME='RT_ALERT_STATUS' AND ALERT_STATUS.Lov_Language_Desc='en'
                group by (case when ALERT_STATUS.LOV_TYPE_DESC is null then 'Unknown' else ALERT_STATUS.LOV_TYPE_DESC end);


                -------------------------------------------------------------------------------

                /****** Object:  View [FCFKC].[ART_HOME_ALERTS_PER_DATE]    Script Date: 5/22/2023 10:22:37 AM ******/

                create view [ART_DB].[ART_HOME_ALERTS_PER_DATE] as
                select Year_ Year,Month__ Month,Day_ Day,Number_Of_ALerts from
                (select 
                EXTRACT(YEAR FROM a.create_date) Year_,
                EXTRACT(Month FROM a.create_date) Month_,
                to_Char(a.create_date,'Month') Month__,
                EXTRACT(Day FROM a.create_date) Day_,
                count(a.alert_id) Number_Of_ALerts
                from  fcf71.fcfkc.FSK_ALERT a
                group by 
                EXTRACT(YEAR FROM a.create_date),
                EXTRACT(Month FROM a.create_date) ,
                to_Char(a.create_date,'Month'),
                EXTRACT(Day FROM a.create_date)
                EXTRACT(YEAR FROM a.create_date) desc,EXTRACT(Month FROM a.create_date)  desc,EXTRACT(Day FROM a.create_date) desc
                );



                ---------------------------------------------------------------------------

                /****** Object:  View [FCFCORE].[ART_HOME_NUMBER_OF_CUSTOMERS]    Script Date: 5/22/2023 11:12:40 AM ******/

                create view [ART_DB].[ART_HOME_NUMBER_OF_CUSTOMERS] AS
                select  count(*) Number_Of_Customers
                FROM fcf71.fcfcore.FSC_PARTY_DIM a
                where a.change_current_ind = 'Y';

                ---------------------------------------------------------------------------

                /****** Object:  View [FCFCORE].[ART_HOME_NUMBER_OF_PEP_CUSTOMERS]    Script Date: 5/22/2023 11:21:05 AM ******/

                create view [ART_DB].[ART_HOME_NUMBER_OF_PEP_CUSTOMERS] AS
                select  count(*) Number_Of_PEP_Customers
                FROM fcf71.fcfcore.FSC_PARTY_DIM a
                where a.change_current_ind = 'Y'
                and a.politically_exposed_person_ind = 'Y';

                ----------------------------------------------------------------------

                /****** Object:  View [FCFCORE].[ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS]    Script Date: 5/22/2023 11:20:09 AM ******/

                create view [ART_DB].[ART_HOME_NUMBER_OF_High_Risk_CUSTOMERS] AS
                select  count(*) Number_Of_High_Risk_Customers
                FROM fcf71.fcfcore.FSC_PARTY_DIM a
                where a.change_current_ind = 'Y'
                and a.risk_classification = '3';

                ---------------------------------------------------------------------------

                /****** Object:  View [FCFCORE].[ART_HOME_Number_Of_Accounts]    Script Date: 5/22/2023 11:22:35 AM ******/

                create view [ART_DB].[ART_HOME_Number_Of_Accounts] AS
                select  count(*) Number_Of_Accounts
                FROM fcf71.fcfcore.FSC_ACCOUNT_DIM a
                where a.change_current_ind = 'Y';



            
            ");

                //create ECM Views
                migrationBuilder.Sql($@"
                                        
                                        USE [ART_DB]
                                        GO
                                        CREATE SCHEMA [ART_DB];
                                        GO
                                        --------------------------------------------------------
                                        --  DDL for View ART_HOME_CASES_DATE
                                        --------------------------------------------------------

                                          CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART_DB"".""ART_HOME_CASES_DATE"" (""YEAR"", ""MONTH"", ""DAY"", ""NUMBER_OF_CASES"") AS 
                                          select Year_ Year,Month__ Month,Day_ Day,Number_Of_Cases from
                                        (
                                        select
                                        EXTRACT(YEAR FROM a.create_date) Year_,
                                        EXTRACT(Month FROM a.create_date) Month_,
                                        to_Char(a.create_date,'Month') Month__,
                                        EXTRACT(Day FROM a.create_date) Day_,
                                        count(a.case_rk) Number_Of_Cases
                                        from
                                        dgecm.dgcmgmt.case_live A 

                                        --where
                                        --A.CASE_STAT_CD IN ('MSC','SMT','ST','HIT','SC','NOHIT','SP','POSTPOND','SO','SN')
                                        group by 
                                        EXTRACT(YEAR FROM a.create_date),
                                        EXTRACT(Month FROM a.create_date) ,
                                        to_Char(a.create_date,'Month'),
                                        EXTRACT(Day FROM a.create_date)
                                        order by  EXTRACT(YEAR FROM a.create_date) desc,EXTRACT(Month FROM a.create_date)  desc,EXTRACT(Day FROM a.create_date) desc
                                        )
                                        ;
                                        --------------------------------------------------------
                                        --  DDL for View ART_HOME_CASES_STATUS
                                        --------------------------------------------------------

                                          CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART_DB"".""ART_HOME_CASES_STATUS"" (""CASE_STATUS"", ""NUMBER_OF_CASES"") AS 
                                          select 
                                        (CASE 
                                           WHEN A.CASE_STAT_CD IN ('MSC','SC','NOHIT') THEN 'NoHit' 
                                           WHEN A.CASE_STAT_CD IN ('SMT','ST','HIT') THEN 'Hit' 
                                           WHEN A.CASE_STAT_CD IN ('POSTPOND','SP') THEN 'Postponed' 
                                           WHEN A.CASE_STAT_CD ='SO' THEN 'Open' 
                                           WHEN A.CASE_STAT_CD ='SN' THEN 'New' END) CASE_STATUS,
                                           count(a.case_rk) Number_Of_Cases
                                        from
                                        dgecm.dgcmgmt.case_live A 
                                        --where
                                        --A.CASE_STAT_CD IN ('MSC','SMT','ST','HIT','SC','NOHIT','SP','POSTPOND','SO','SN')
                                        group by
                                        (CASE 
                                           WHEN A.CASE_STAT_CD IN ('MSC','SC','NOHIT') THEN 'NoHit' 
                                           WHEN A.CASE_STAT_CD IN ('SMT','ST','HIT') THEN 'Hit' 
                                           WHEN A.CASE_STAT_CD IN ('POSTPOND','SP') THEN 'Postponed' 
                                           WHEN A.CASE_STAT_CD ='SO' THEN 'Open' 
                                           WHEN A.CASE_STAT_CD ='SN' THEN 'New' END);
                                        --------------------------------------------------------
                                        --  DDL for View ART_HOME_CASES_TYPES
                                        --------------------------------------------------------

                                          CREATE OR REPLACE FORCE EDITIONABLE VIEW ""ART_DB"".""ART_HOME_CASES_TYPES"" (""CASE_TYPE"", ""NUMBER_OF_CASES"") AS 
                                          select 
                                        (CASE 
                                          WHEN CASE_TYPE.VAL_DESC = 'Sanction Customer Manual ' THEN 'Manual Customer Search'
                                          WHEN CASE_TYPE.VAL_DESC = 'Sanction Web search' THEN 'Watchlist Manual Search' 
                                          ELSE CASE_TYPE.VAL_DESC END)CASE_TYPE,
                                           count(a.case_rk) Number_Of_Cases
  
                                          from
                                        dgecm.dgcmgmt.case_live A 
                                        LEFT JOIN dgecm.dgcmgmt.REF_TABLE_VAL CASE_TYPE 
                                        ON CASE_TYPE.VAL_CD = a.CASE_TYPE_CD
                                        AND CASE_TYPE.REF_TABLE_NAME='RT_CASE_TYPE'

                                        --where
                                        --A.CASE_STAT_CD IN ('MSC','SMT','ST','HIT','SC','NOHIT','SP','POSTPOND','SO','SN')
                                        group by
                                          (CASE 
                                          WHEN CASE_TYPE.VAL_DESC = 'Sanction Customer Manual ' THEN 'Manual Customer Search'
                                          WHEN CASE_TYPE.VAL_DESC = 'Sanction Web search' THEN 'Watchlist Manual Search' 
                                          ELSE CASE_TYPE.VAL_DESC END);


                "); //create ECM Views
                migrationBuilder.Sql($@"
                                        
                                        USE [ART_DB]
                                        GO
                                        CREATE SCHEMA [ART_DB];
                                        GO
                                        /****** Object:  View [ART_DB].[ART_HOME_CASES_DATE]    Script Date: 5/21/2023 4:03:07 PM ******/
                                        SET ANSI_NULLS ON
                                        GO

                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                         CREATE VIEW [ART_DB].[ART_HOME_CASES_DATE] (""YEAR"", ""MONTH"", ""DAY"", ""NUMBER_OF_CASES"") AS 
                                          select Year_ Year,Month__ Month,Day_ Day,Number_Of_Cases from
                                        (
                                        select
                                        YEAR(a.create_date) Year_,
                                        Month(a.create_date) Month_,
                                        FORMAT(a.create_date,'MMM') Month__,
                                        Day(a.create_date) Day_,
                                        count(a.case_rk) Number_Of_Cases
                                        from
                                        dgecm.dgcmgmt.case_live A
                                        group by 
                                        YEAR(a.create_date),
                                        Month(a.create_date),
                                        FORMAT(a.create_date,'MMM') ,
                                        Day(a.create_date)
                                        order by YEAR(a.create_date) desc,
                                        Month(a.create_date) desc,
                                        Day(a.create_date)  desc offset 0 rows) aaa
                                        ;
                                        GO
                                        -------------------------------------------------------------------------------------------------



                                        USE [ART_DB]
                                        GO

                                        /****** Object:  View [ART_DB].[ART_HOME_CASES_STATUS]    Script Date: 5/21/2023 4:03:37 PM ******/
                                        SET ANSI_NULLS ON
                                        GO

                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                         CREATE VIEW [ART_DB].[ART_HOME_CASES_STATUS] (""CASE_STATUS"", ""NUMBER_OF_CASES"") AS
                                         select 
                                         b.val_desc CASE_STATUS,
                                           count(a.case_rk) Number_Of_Cases
                                        from
                                        dgecm.dgcmgmt.case_live A 
                                        LEFT JOIN
                                        DGCMGMT.REF_TABLE_VAL b ON lower(b.VAL_CD) = lower(a.CASE_STAT_CD) AND b.REF_TABLE_NAME = 'RT_CASE_STATUS'
                                        group by
                                        b.val_desc;
                                        GO


                                        ---------------------------------------------------------------------------------------------------


                                        USE [ART_DB]
                                        GO

                                        /****** Object:  View [ART_DB].[ART_HOME_CASES_TYPES]    Script Date: 5/21/2023 4:04:26 PM ******/
                                        SET ANSI_NULLS ON
                                        GO

                                        SET QUOTED_IDENTIFIER ON
                                        GO

                                           CREATE VIEW [ART_DB].[ART_HOME_CASES_TYPES] (""CASE_TYPE"", ""NUMBER_OF_CASES"") AS 
                                         select 
                                        CASE_TYPE.VAL_DESC CASE_TYPE,
                                           count(a.case_rk) Number_Of_Cases
  
                                          from
                                        dgecm.dgcmgmt.case_live A 
                                        LEFT JOIN dgecm.dgcmgmt.REF_TABLE_VAL CASE_TYPE 
                                        ON CASE_TYPE.VAL_CD = a.CASE_TYPE_CD
                                        AND CASE_TYPE.REF_TABLE_NAME='RT_CASE_TYPE'
                                        group by
                                          CASE_TYPE.VAL_DESC;
                                        GO");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtSavedReportsChart");

            migrationBuilder.DropTable(
                name: "ArtSavedReportsColumns");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ArtSavedCustomReport");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
