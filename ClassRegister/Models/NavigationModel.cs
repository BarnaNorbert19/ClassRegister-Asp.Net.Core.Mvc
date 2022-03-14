namespace ClassRegister.Models
{
    public class NavigationModel
    {
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
        public int DisplayRange { get; private set; }
        public int PageSize { get; private set; }
        public int CurrentPage
        {
            get => _currentPage;
            private set
            {
                if (value < 1)
                    _currentPage = 1;

                else if (value > TotalPages)
                    _currentPage = TotalPages;

                else
                    _currentPage = value;
            }
        }
        private int _currentPage;
        public int DisplayStart
        {
            get => _displayStart;
            private set
            {
                if (value < 1)
                    _displayStart = 1;

                else if (value > TotalPages)
                    _displayStart = TotalPages;

                else
                    _displayStart = value;
            }
        }
        private int _displayStart;
        public int DisplayEnd
        {
            get => _displayEnd;
            private set
            {
                if (value < 1)
                    _displayEnd = 1;

                else if (value > TotalPages)
                    _displayEnd = TotalPages;

                else
                    _displayEnd = value;
            }
        }
        private int _displayEnd;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalItems">Total number of items, that you want to display in parts</param>
        /// <param name="displayRange">How many pages you want to see at once</param>
        /// <param name="pageSize">How many items are on one page</param>
        /// <param name="currentPage">The current page that you are on</param>
        public NavigationModel(int totalItems, int displayRange, int pageSize, int currentPage)
        {
            int totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);
            int displayStart = currentPage - displayRange;
            int displayEnd = currentPage + displayRange;

            TotalItems = totalItems;
            DisplayRange = displayRange;
            PageSize = pageSize;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            DisplayEnd = displayEnd;
            DisplayStart = displayStart;
        }
        
    }
}
