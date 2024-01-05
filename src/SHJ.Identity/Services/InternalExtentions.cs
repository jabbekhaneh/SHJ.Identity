namespace SHJ.Identity.Services;

internal static class InternalExtentions
{
    public static (IQueryable<T> Query, int pageSize) ToPagination<T>(this IQueryable<T> source, int take = 20, int pageId = 1)
    {
        var query = source;
        int TotalItemCount = query.Count();
        int pageSize = (int)Math.Ceiling((double)TotalItemCount / take);
        pageId = pageId > pageSize || pageId < 1 ? 1 : pageId;
        var skiped = (pageId - 1) * take;

        return (query.Skip(skiped).Take(take), pageSize);
    }

}
