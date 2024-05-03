namespace MentorProject.VMs
{
	public class PaginatedList<T>
	{
        public PaginatedList(List<T> items, int currentPage, int totalPages, int pageSize)
		{
			this.Items = items;
			this.CurrentPage = currentPage;
			this.TotalPages = totalPages;
			this.PageSize = pageSize;
		}
		public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious { get { return CurrentPage > 1; } }
        public bool HasNext { get { return CurrentPage < TotalPages; } }
        public static PaginatedList<T> Create(IQueryable<T> query, int currentPage, int pageSize)
        {
            int totalPages = (int)Math.Ceiling(query.Count() / (decimal)pageSize);
            var items = query.Skip((currentPage-1)*pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, currentPage, totalPages,pageSize);
        }
    }
}
