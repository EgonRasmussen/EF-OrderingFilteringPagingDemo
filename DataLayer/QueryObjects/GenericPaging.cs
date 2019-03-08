﻿using System;
using System.Linq;

namespace DataLayer.QueryObjects
{
    public static class GenericPaging
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumZeroStart, int pageSize)
        {
            if (pageSize == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize cannot be zero.");
            }
            if (pageNumZeroStart != 0)
            {
                query = query.Skip(pageNumZeroStart * pageSize);    // Skips number of pages
            }
            return query.Take(pageSize);                            // Takes the number for this page size
        }
    }
}
