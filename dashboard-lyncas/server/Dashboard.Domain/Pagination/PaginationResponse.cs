﻿namespace Dashboard.Domain.Pagination
{
    public class PaginationResponse<T>
    {
        public List<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }

}
