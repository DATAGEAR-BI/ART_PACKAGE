namespace ART_PACKAGE.Extentions.IQuerable
{
    public static class IQuerableExtentions
    {

        public static IQueryable<IQueryable<T>> Partition<T>(this IQueryable<T> data, int partitionSize)
        {
            var partitions = new List<IQueryable<T>>();
            int total = data.Count();

            for (int i = 0; i < total; i += partitionSize)
            {
                var partition = data.Skip(i).Take(partitionSize);
                partitions.Add(partition);
            }

            return partitions.AsQueryable(); // Return as IQueryable
        }
    }
}
