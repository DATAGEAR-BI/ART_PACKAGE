

using ART_PACKAGE.Data.Attributes;
using System.ComponentModel.DataAnnotations;



namespace ART_PACKAGE.Areas.Identity.Data;

public enum DbSchema
{
    [Option(DisplayName = "FCF71")]
    CORE,
    [Option(DisplayName = "KC")]
    KC,
    [Option(DisplayName = "DGCMGMT")]
    DGCMGMT
}

