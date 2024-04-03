namespace CineAimane.Helpers
{
	public class PaginationHelper
	{
		public int TotalItems { get; }
		public int CurrentPage { get; }
		public int PageSize { get; }
		public int TotalPages { get; }
		public int StartPage { get; }
		public int EndPage { get; }
		public PaginationHelper() { }
		public PaginationHelper(int totalItems, int currentPage, int pageSize)
		{
			int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
			int startPage = currentPage - 5;
			int endPage = currentPage + 4;
			if (startPage < 1)
			{
				endPage -= startPage - 1;
				startPage = 1;
			}
			if (endPage > totalPages)
			{
				endPage = totalPages;
				if (endPage > 10)
				{
					startPage = endPage - 9;
				}
			}
			TotalItems = totalItems;
			CurrentPage = currentPage;
			PageSize = pageSize;
			TotalPages = totalPages;
			StartPage = startPage;
			EndPage = endPage;
		}
	}
}