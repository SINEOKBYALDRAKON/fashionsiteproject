using fashionsiteproject.Shop.Data.Models;
using fashionsiteproject.Shop.Data.Enums;

namespace fashionsiteproject.Shop.Data
{
    public interface IOrder
    {
        void CreateOrder(Order order);
        Order GetById(int orderId);

        IEnumerable<Order> GetByUserId(string userId);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetUserLatestOrders(int count, string userId);
        IEnumerable<Order> GetUserMostPopular(string userId);
        IEnumerable<Order> GetFilteredOrders(
            string userId = "",
            OrderBy orderBy = OrderBy.None,
            int offsetForBeggining = 0,
            int limit = 0,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            DateTime? minDate = null,
            DateTime? maxDate = null
            );

    }
}
