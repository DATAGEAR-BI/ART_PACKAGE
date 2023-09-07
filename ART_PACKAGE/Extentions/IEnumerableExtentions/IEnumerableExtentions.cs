namespace ART_PACKAGE.Extentions.IEnumerableExtentions
{
    public static class IEnumerableExtentions
    {
        public static IEnumerable<List<T>> Partition<T>(this IList<T> source, int size)
        {
            for (int i = 0; i < (source.Count / size) + (source.Count % size > 0 ? 1 : 0); i++)
                yield return new List<T>(source.Skip(size * i).Take(size));
        }
    }
}
