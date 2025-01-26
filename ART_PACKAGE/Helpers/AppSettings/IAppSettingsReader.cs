using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ART_PACKAGE.Helpers.AppSettings
{
    public interface IAppSettingsReader
    {
        T GetValue<T>(string key);
        string GetEncodedValue(string key);
    }
}
