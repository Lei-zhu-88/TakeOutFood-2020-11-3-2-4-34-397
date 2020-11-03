using System.Collections.Generic;
using TakeOutFood;

namespace TakeOutFoodTest
{
    public class SalesPromotionRepositoryTestImpl : ISalesPromotionRepository
    {
        public List<SalesPromotion> FindAll(List<Item> inputItems, int[] countItems)
        {
            return TestData.ALL_SALES_PROMOTIONS;
        }
    }
}
