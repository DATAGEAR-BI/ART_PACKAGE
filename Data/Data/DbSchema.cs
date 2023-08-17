

using ART_PACKAGE.Data.Attributes;
using System.ComponentModel.DataAnnotations;



namespace ART_PACKAGE.Areas.Identity.Data;

public enum DbSchema
{
    [Option(DisplayName = "ACTIVITI_DB")]
    ACTIVITIDB,
    [Option(DisplayName = "DG_ADMIN")]
    DGADMIN,
    [Option(DisplayName = "DG_CALENDAR")]
    DGCALENDAR,
    [Option(DisplayName = "DG_NOTIFICATION")]
    DGNOTIFICATION,
    [Option(DisplayName = "DGECM")]
    DGECM,
    [Option(DisplayName = "DG_ECMMETEDATA")]
    DGECMMETADATA,
    [Option(DisplayName ="DGUSERMANAGMENT")]
    DGUSERMANAGMENT,
    [Option(DisplayName ="TI")]
    TI
}

