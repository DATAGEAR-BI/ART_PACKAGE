namespace ART_PACKAGE.Helpers.Global
{
    public class Result<T>
    {
        public bool Succeed { get; set; }
        public T? Data { get; set; }
    }
}
