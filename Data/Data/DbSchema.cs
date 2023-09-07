

using ART_PACKAGE.Data.Attributes;



namespace ART_PACKAGE.Areas.Identity.Data;

public enum DbSchema
{
    [Option(DisplayName = "DGCMGMT", IsHidden = true)]
    DGCMGMT,
    [Option(DisplayName = "DGWLLOGS", IsHidden = true)]
    DGWLLOGS,
    [Option(DisplayName = "TI")]
    TI
}

