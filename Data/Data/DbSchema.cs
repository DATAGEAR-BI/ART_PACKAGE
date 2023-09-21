

using ART_PACKAGE.Data.Attributes;
using System.ComponentModel.DataAnnotations;



namespace ART_PACKAGE.Areas.Identity.Data;

public enum DbSchema
{
    [Option(DisplayName = "FCF71",IsHidden =true)]
    CORE,
    [Option(DisplayName = "KC", IsHidden = true)]
    KC,
    [Option(DisplayName = "DGCMGMT")]
    DGCMGMT,
    [Option(DisplayName = "DGWLLOGS")]
    DGWLLOGS
}

