﻿using ART_PACKAGE.Areas.Identity.Data;
using Data.Data.AmlAnalysis;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Extentions.WebApplicationExttentions
{
    public static class WebAppExtentions
    {
        public static void ApplyModulesMigrations(this WebApplication app)
        {
            List<string>? modules = app.Configuration.GetSection("Modules").Get<List<string>>();
            using IServiceScope scope = app.Services.CreateScope();
            AuthContext authContext = scope.ServiceProvider.GetRequiredService<AuthContext>();
            if (authContext.Database.GetPendingMigrations().Any())
            {
                authContext.Database.Migrate();
            }

            if (modules.Contains("ECM"))
            {

                EcmContext ecmContext = scope.ServiceProvider.GetRequiredService<EcmContext>();

                if (ecmContext.Database.GetPendingMigrations().Any())
                {
                    ecmContext.Database.Migrate();
                }
            }

            if (modules.Contains("SEG"))
            {
                SegmentationContext SegContext = scope.ServiceProvider.GetRequiredService<SegmentationContext>();

                if (SegContext.Database.GetPendingMigrations().Any())
                {
                    SegContext.Database.Migrate();
                }
            }
            if (modules.Contains("GOAML"))
            {
                ArtGoAmlContext GoAmlContext = scope.ServiceProvider.GetRequiredService<ArtGoAmlContext>();

                if (GoAmlContext.Database.GetPendingMigrations().Any())
                {
                    GoAmlContext.Database.Migrate();
                }
            }
            if (modules.Contains("SASAML"))
            {
                SasAmlContext sasAmlContext = scope.ServiceProvider.GetRequiredService<SasAmlContext>();

                if (sasAmlContext.Database.GetPendingMigrations().Any())
                {
                    sasAmlContext.Database.Migrate();
                }
            }

            if (modules.Contains("DGAML"))
            {
                ArtDgAmlContext DgAmlContext = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();

                if (DgAmlContext.Database.GetPendingMigrations().Any())
                {
                    DgAmlContext.Database.Migrate();
                }
            }
            if (modules.Contains("DGAUDIT"))
            {
                ArtAuditContext DgAuditContext = scope.ServiceProvider.GetRequiredService<ArtAuditContext>();

                if (DgAuditContext.Database.GetPendingMigrations().Any())
                {
                    DgAuditContext.Database.Migrate();
                }
            }
            if (modules.Contains("AMLANALYSIS"))
            {
                AmlAnalysisContext amlAnalysisContext = scope.ServiceProvider.GetRequiredService<AmlAnalysisContext>();

                if (amlAnalysisContext.Database.GetPendingMigrations().Any())
                {
                    amlAnalysisContext.Database.Migrate();
                }
            }
            if (modules.Contains("FTI"))
            {
                FTIContext fti = scope.ServiceProvider.GetRequiredService<FTIContext>();

                if (fti.Database.GetPendingMigrations().Any())
                {
                    fti.Database.Migrate();
                }
            }
        }
    }
}