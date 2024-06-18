using api.Data; // This includes the namespace api.Data so that classes and methods within that namespace can be used in this file.
using api.Mappers;
using Microsoft.AspNetCore.Mvc; // This includes ASP.NET Core MVC components, enabling the use of controllers, actions, and routing.

namespace api.Controller
{
    [Route("api/stock")]
    [ApiController] // This attribute indicates that this class is an API controller and provides automatic model state validation, among other things.
    public class StockController : ControllerBase //StockController that inherits from ControllerBase, which provides basic functionality for handling HTTP requests.
    {
        private readonly ApplicationDBContext dbContext; // Declares a read-only field to hold the database context.

        // This is a constructor that takes an ApplicationDBContext parameter. The provided context is assigned to the dbContext field.
        // This is an example of dependency injection, where ApplicationDBContext is injected into the controller by the dependency injection framework.
        public StockController(ApplicationDBContext context)
        {
            dbContext = context;
        }

        //Get all stocks
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = dbContext.Stock.ToList().Select(s=>s.ToStockDto()); //This retrieves all stock records from the database as a list.
            return Ok(stocks);
        }

        //Get stock by Id
        [HttpGet("{id}")] //This attribute specifies that this action responds to HTTP GET requests with a URL parameter (id).
        public IActionResult GetById([FromRoute] int id)
        { //This method takes an id parameter from the route and returns an IActionResult. [FromRoute]int id: This is model binding, where the value of id in the URL is automatically bound to the id parameter of the method.
            var stock = dbContext.Stock.Find(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
    }
}
