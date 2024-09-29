using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtCustomerRenewalDetailsConfig:ReportConfig
    {

        public ArtCustomerRenewalDetailsConfig()
        {
            var DisplayNames = new Dictionary<string, GridColumnConfiguration>
{
    { "PartyName", new GridColumnConfiguration { DisplayName = "Party Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "PartyNumber", new GridColumnConfiguration { DisplayName = "Party Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "PartyType", new GridColumnConfiguration { DisplayName = "Party Type", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "PartyOccupation", new GridColumnConfiguration { DisplayName = "Party Occupation", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "ExpiredDate", new GridColumnConfiguration { DisplayName = "Expired Date", Format = "yyyy-MM-dd", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "DateField", new GridColumnConfiguration { DisplayName = "Date Field", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "ActionRequired", new GridColumnConfiguration { DisplayName = "Action Required", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "LastContactDate", new GridColumnConfiguration { DisplayName = "Last Contact Date", Format = "yyyy-MM-dd HH:mm:ss", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "ChangeBeginDate", new GridColumnConfiguration { DisplayName = "Change Begin Date", Format = "yyyy-MM-dd", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "ChangeCurrentInd", new GridColumnConfiguration { DisplayName = "Change Current Indicator", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "KycExpiryInd", new GridColumnConfiguration { DisplayName = "KYC Expiry Indicator", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
    { "RiskClassification", new GridColumnConfiguration { DisplayName = "Risk Classification", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
};
        }
    }
}
