namespace Dashboard.Domain.Pagination
{
    public class PaginationModel
    {
        public int Page { get; set; }
        public int NumberPerPage { get; set; }
        public String? Filter {  get; set; }
    }
} 
