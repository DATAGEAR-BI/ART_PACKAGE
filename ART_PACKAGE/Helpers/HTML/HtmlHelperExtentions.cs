
using ART_PACKAGE.Data.Attributes;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

using System.Reflection;

namespace ART_PACKAGE.Helpers.HTMLHelpers
{
    public static class HtmlHelperExtentions
    {
        public static HtmlString EnumToString<T>(this IHtmlHelper helper)
        {
            var values = Enum.GetValues(typeof(T)).Cast<int>();
            var enumDictionary = values.ToDictionary(value => Enum.GetName(typeof(T), value));

            return new HtmlString(JsonConvert.SerializeObject(enumDictionary));
        }

        public static IEnumerable<SelectListItem> GetEnumValuesWithDisplayName<T>(this IHtmlHelper helper) where T : Enum
        {
            var result = typeof(T).GetMembers(BindingFlags.Static | BindingFlags.Public).Where(x =>
            {
                var displayAttr = x.GetCustomAttribute<OptionAttribute>();
                return !displayAttr.IsHidden;
            }).Select(x =>
            {
                var displayAttr = x.GetCustomAttribute<OptionAttribute>();
                var text = displayAttr is null ? x.Name : displayAttr.DisplayName;
                var value = ((int)Enum.Parse(typeof(T), x.Name)).ToString();
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
