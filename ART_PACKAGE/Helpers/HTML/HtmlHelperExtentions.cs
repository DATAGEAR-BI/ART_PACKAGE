
using ART_PACKAGE.Data.Attributes;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

using System.Reflection;

namespace ART_PACKAGE.Helpers.HTMLHelpers
{
    public static class HtmlHelperExtentions
    {
        public static HtmlString EnumToString<T>(this IHtmlHelper helper)
        {
            IEnumerable<int> values = Enum.GetValues(typeof(T)).Cast<int>();
            Dictionary<string?, int> enumDictionary = values.ToDictionary(value => Enum.GetName(typeof(T), value));

            return new HtmlString(JsonConvert.SerializeObject(enumDictionary));
        }

        public static IEnumerable<SelectListItem> GetEnumValuesWithDisplayName<T>(this IHtmlHelper helper) where T : Enum
        {
            IEnumerable<SelectListItem> result = typeof(T).GetMembers(BindingFlags.Static | BindingFlags.Public).Where(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                return displayAttr == null || !displayAttr.IsHidden;
            }).Select(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                string text = displayAttr is null ? x.Name : displayAttr.DisplayName;
                string value = ((int)Enum.Parse(typeof(T), x.Name)).ToString();
                return new SelectListItem
                {
                    Text = text,
                    Value = value
                };

            });
            return result;



        }
    }
}
