using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        //By making the class static, it clearly indicates to other developers that this class should not be instantiated and is only meant to provide static methods.
        //This also improves performance slightly since no instances of the class are created.
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
            };
        }
    }
}
