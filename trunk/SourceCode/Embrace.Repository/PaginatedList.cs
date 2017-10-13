using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ListExtensions
{
    public static PaginatedList<T> ToPagedList<T>(this IQueryable<T> list, int page, int pageSize)
    {
        int count = list.Count();
        var items = list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return new PaginatedList<T>(items, count, page, pageSize);
    }
    public static async Task<PaginatedList<T>> ToAsycPagedList<T>(this IQueryable<T> list, int page, int pageSize)
    {
        return await PaginatedList<T>.CreateAsync(list, page, pageSize);
    }
}
public class PaginatedList<T> : List<T>// where T: IQueryable<T>, IEnumerable<T>, ICollection<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int RowCount { get; set; }
    public int PageSize { get; set; }
    public int FirstRowOnPage
    {

        get { return (PageIndex - 1) * PageSize + 1; }
    }

    public int LastRowOnPage
    {
        get { return Math.Min(PageIndex * PageSize, RowCount); }
    }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        RowCount = count;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        this.AddRange(items);
    }

    public bool HasPreviousPage
    {
        get
        {
            return (PageIndex > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (PageIndex < TotalPages);
        }
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}

