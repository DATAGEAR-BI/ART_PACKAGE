namespace ART_PACKAGE.Data.Attributes
{

    public class OptionAttribute : Attribute
    {
        public string DisplayName { get; set; } = string.Empty;
        public bool IsHidden { get; set; } = false;
    }
}
