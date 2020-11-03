namespace TakeOutFood
{
    using System;
    using System.Collections.Generic;

    public class App
    {
        private IItemRepository itemRepository;
        private ISalesPromotionRepository salesPromotionRepository;
        int [] countItems;
        double totalSavePrice = 0.00;
        double totalPrice = 0.00;
        List<string> outputListString = new List<string>();
        string outputPromote;

        public App(IItemRepository itemRepository, ISalesPromotionRepository salesPromotionRepository)
        {
            this.itemRepository = itemRepository;
            this.salesPromotionRepository = salesPromotionRepository;
        }





        public string BestCharge(List<string> inputs)
        {
            countItems = new int[inputs.Count];//把input的每一个item对应数量记下来


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
                        countItems[i] = int.Parse(stringArray[2]);
                        outputListString.Add(item.Name + " x " + stringArray[2] + " = " + (item.Price * countItems[i]) + " yuan");
                    }
                    // Console.WriteLine(allInputItems);
                }

            }


            int countSingeItems = 0;
            List<string> outputItems = new List<string>();

            var ALL_SALES_PROMOTIONS = new List<SalesPromotion>();
            SalesPromotion salesPromote = null;


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
                    totalPrice += allInputItems[i].Price * countItems[i];
                }
                outputPromote += "Total：" + totalPrice + " yuan\n";


            }
            else
            {
                string promoteItemName = "";
                //double maxPrice = 0.00;
                for (int i = 0; i < countItems.Length; i++)
                {
                    totalPrice += allInputItems[i].Price * countItems[i];
                    if (countItems[i] == 1)
                    {
                        outputItems.Add(allInputItems[i].Id);
                        //salesPromote.DisplayName+= inputItems[i].Name;

                        totalSavePrice += allInputItems[i].Price * 0.50;
                        promoteItemName += allInputItems[i].Name + ", ";
                    }


                }
                promoteItemName = promoteItemName.Remove(promoteItemName.Length - 2);
                totalPrice -= totalSavePrice;
                salesPromote = new SalesPromotion("50%_DISCOUNT_ON_SPECIFIED_ITEMS", promoteItemName, outputItems);

                ALL_SALES_PROMOTIONS.Add(salesPromote);

                outputPromote += "Promotion used:\n";
                outputPromote += "Half price for certain dishes (" + promoteItemName + "), saving " + totalSavePrice + " yuan\n";
                outputPromote += "-----------------------------------\nTotal：" + totalPrice + " yuan\n";


            }

            string output = "============= Order details =============\n";

            foreach (string item in outputListString)
            {
                output += item + "\n";
            }
            output += "-----------------------------------\n";
            output += outputPromote;
            output += "===================================";
            return output;
        }


    }
}
