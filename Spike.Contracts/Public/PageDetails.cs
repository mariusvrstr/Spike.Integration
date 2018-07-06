using System.Runtime.Serialization;

namespace Spike.Contracts.Public
{
    /// <summary>
    /// The Page Details contains all the page related information
    /// </summary>
    /// <typeparam name="TB">The type of the b.</typeparam>
    [DataContract]
    public class PageDetails<TB>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageDetails{TB}" /> class.
        /// </summary>
        public PageDetails()
        {
            PageNumber = 1;
            PageSize = 20;
            SortOrder = SortOrder.Accending;
        }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        [DataMember]
        public int PageNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        [DataMember]
        public int PageSize { get; set; }
        
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        [DataMember]
        public SortOrder SortOrder { get; set; }
        
        /// <summary>
        /// Gets or sets the sort column.
        /// </summary>
        /// <value>
        /// The sort column.
        /// </value>
        [DataMember]
        public TB SortColumn { get; set; }

        /// <summary>
        /// Gets or sets the remaining items.
        /// </summary>
        /// <value>
        /// The remaining items.
        /// </value>
        [DataMember]
        public int RemainingItems { get; set; }
        
        /// <summary>
        /// Creates the specified page number.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortColumn">The sort column.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="remainingItems">The remaining items.</param>
        /// <returns></returns>
        public static PageDetails<TB> Create(int pageNumber, int pageSize, TB sortColumn, SortOrder sortOrder = SortOrder.Accending, int remainingItems = -1)
        {
            return new PageDetails<TB>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                RemainingItems = remainingItems
            };
        }
    }
}
