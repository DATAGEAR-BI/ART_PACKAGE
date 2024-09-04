

using ART_PACKAGE.Data.Attributes;



namespace ART_PACKAGE.Areas.Identity.Data;

public enum DbSchema
{
    [Option(DisplayName = "FCF71", ModuleNames = "SASAML,AMLANALYSIS")]
    CORE,
    [Option(DisplayName = "KC", ModuleNames = "SASAML,AMLANALYSIS")]
    KC,
    [Option(DisplayName = "DGCMGMT", ModuleNames = "ECM")]
    DGCMGMT,
    [Option(DisplayName = "DGWLLOGS")]
    DGWLLOGS,
    [Option(DisplayName = "GO AML", ModuleNames = "GOAML")]
    GoAml,
    [Option(DisplayName = "TI Zone", ModuleNames = "FTI")]
    FTI,
    [Option(DisplayName = "DG AML AC", ModuleNames = "DGAML")]
    DGAMLAC,
    [Option(DisplayName = "DG AML Core", ModuleNames = "DGAML")]
    DGAMLCORE,
    [Option(DisplayName = "DGMGMT", ModuleNames = "DGAUDIT")]
    DGMGMT,
    [Option(DisplayName = "DGMGMT AUDIT", ModuleNames = "DGAUDIT")]
    DGMGMT_AUDIT,
}

