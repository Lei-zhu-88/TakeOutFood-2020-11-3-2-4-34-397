namespace TakeOutFood
{
    using System;
    using System.Collections.Generic;

    public class App
    {
        private IItemRepository itemRepository;
        private ISalesPromotionRepository salesPromotionRepository;
        int[] countItems;
        double totalPrice = 0;
        string[] outputItemsString;

        public App(IItemRepository itemRepository, ISalesPromotionRepository salesPromotionRepository)
        {
            this.itemRepository = itemRepository;
            this.salesPromotionRepository = salesPromotionRepository;
        }





        public string BestCharge(List<string> inputs)
        {
            countItems = new int[inputs.Count];//把input的每一个item对应数量记下来
            
            var inputItems = FindAll(inputs);
            FindAll(inputItems, countItems);
            string output = "=========== Order details=========== /n";

            foreach (string item in inputs)
            {
               // output +=  ;
            }
            
            


            return output;
        }





        private List<Item> FindAll(List<string> inputs)
        {

            List<Item> allItems = new List<Item>()
            {
                new Item("ITEM0001", "Braised chicken", 18.00),
                new Item("ITEM0013", "Chinese hamburger", 6.00),
                new Item("ITEM0022", "Cold noodles", 8.00),
                new Item("ITEM0030", "coca-cola", 2.00),

            };

            

            List<Item> allInputItems = new List<Item>();
            for (int i = 0; i < inputs.Count; i++)
            {

                var stringArray = inputs[i].Split();
                foreach (Item item in allItems)
                {
                    if (stringArray[0] == item.Id)
                    {
                        allInputItems.Add(item);
                        countItems[i] = inputs[i][2];
                    }
                   // Console.WriteLine(allInputItems);
                }

            }

            return allInputItems;
        }


        List<SalesPromotion> FindAll(List<Item> inputItems, int[] countItems)
        {
            int countSingeItems = 0;
            List<string> outputItems = new List<string>();


            foreach (int count in countItems)
            {
                if (count == 1)
                {
                    countSingeItems += 1;
                }
                
            }

            if (countSingeItems == 0)
            {
                outputItems.Add("");

                for (int i = 0; i < countItems.Length; i++)
                {
                    totalPrice += inputItems[i].Price * countItems[i];
                }
                
            }
            else
            {
                string promoteItemName;
                //double maxPrice = 0.00;
                for (int i = 0; i < countItems.Length; i++)
                {
                    if (countItems[i] == 1)
                    {
                      outputItems.Add(inputItems[i].Id);
                      
                        totalPrice += inputItems[i].Price * 0.50;
                    }
                    else
                    {
                        totalPrice += inputItems[i].Price * countItems[i];
                    }
                }
            }



            var ALL_SALES_PROMOTIONS = new List<SalesPromotion>() { new SalesPromotion("50%_DISCOUNT_ON_SPECIFIED_ITEMS", "Half price for certain dishes", outputItems) };

            

            return ALL_SALES_PROMOTIONS;


        }
    }
}
