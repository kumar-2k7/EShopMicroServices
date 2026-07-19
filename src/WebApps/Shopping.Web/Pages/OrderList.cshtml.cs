namespace Shopping.Web.Pages
{
    public class OrderListModel
        (IOrderingService orderingService, ILogger<OrderListModel> logger)
        : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // assumption customerId is passed in from the UI authenticated user swn
            var customerId = new Guid("11111111-1111-1111-1111-111111111111");

            var response = await orderingService.GetOrdersByCustomer(customerId);
            Orders = response.Orders;

            return Page();
        }
    }
}
