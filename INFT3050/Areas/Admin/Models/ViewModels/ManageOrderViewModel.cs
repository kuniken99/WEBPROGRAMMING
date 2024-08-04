using INFT3050.Models;
namespace INFT3050.Areas.Admin.Models
{
    public class ManageOrderViewModel
    {
        public List<Order> ManageOrders { get; set; }
        public List<User> CustomerUser { get; set; }

    }
}
