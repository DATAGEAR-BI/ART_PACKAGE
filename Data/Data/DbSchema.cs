

using ART_PACKAGE.Data.Attributes;



namespace ART_PACKAGE.Areas.Identity.Data;

public enum DbSchema
{
    [Option(DisplayName = "FCF71", ModuleNames = "SASAML,AMLANALYSIS")]
    CORE,
    [Option(DisplayName = "KC", ModuleNames = "SASAML,AMLANALYSIS")]
    KC,
    [Option(DisplayName = "DGCMGMT", ModuleNames = "ECM,DGINTFRAUD")]
    DGCMGMT,
    [Option(DisplayName = "DGWLLOGS")]
    DGWLLOGS,
    [Option(DisplayName = "GO AML", ModuleNames = "GOAML")]
    GoAml,
    [Option(DisplayName = "TI Zone", ModuleNames = "FTI")]
    FTI,
    [Option(DisplayName = "DG AML", ModuleNames = "DGAML")]
    DGAML,
    [Option(DisplayName = "DG AML", ModuleNames = "DGINTFRAUD")]
    DGAMLCORE,
    [Option(DisplayName = "AC", ModuleNames = "DGINTFRAUD")]
    AC,
    [Option(DisplayName = "ART", ModuleNames = "DGINTFRAUD")]
    ART
}

