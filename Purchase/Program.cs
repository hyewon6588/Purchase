using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Purchased Products List");
            Console.WriteLine("==================================");

            Purchase purchase1 = new Purchase(ProductCategory.Electronics, 2);
            purchase1.CalculateCost();
            Console.WriteLine(purchase1.ToString());

            Console.WriteLine("==================================");

            Purchase purchase2 = new Purchase();
            purchase2.Category = ProductCategory.Beverages;
            purchase2.Quantities = 5;
            purchase2.CalculateCost();
            Console.WriteLine(purchase2.ToString());

            Console.WriteLine("==================================");

            Purchase purchase3 = new Purchase(ProductCategory.Miscellaneous);
            purchase3.CalculateCost();
            Console.WriteLine(purchase3.ToString());

            Console.WriteLine("==================================");

            Purchase purchase4 = new Purchase(ProductCategory.CleaningSupplies);
            purchase4.Quantities = 3;
            purchase4.CalculateCost();
            Console.WriteLine(purchase4.ToString());
            Console.WriteLine("==================================");
        }
    }

    public enum ProductCategory
    {
        Grocery, Electronics, Beverages, CleaningSupplies, Miscellaneous
    }

    public class Purchase
    {
        static int PURCHASE_ID = 1;
        public ProductCategory Category;
        public int Quantities;
        double Cost;

        public Purchase()
        {
            Purchase.PURCHASE_ID++;
        }

        public Purchase(ProductCategory Category, int quantities = 1)
        {
            this.Category = Category;
            this.Cost = 0;
            Purchase.PURCHASE_ID++;
            this.Quantities = quantities;
        }

        public void CalculateCost()
        {
            int pricePerUnit = 0;
            double discountRate = 0;
            const double TAXRATE = 1.13;

            switch (this.Category)
            {
                case ProductCategory.Grocery:
                    pricePerUnit = 1;
                    discountRate = 0.2;
                    break;
                case ProductCategory.Electronics:
                    pricePerUnit = 15;
                    discountRate = 0.1;
                    break;
                case ProductCategory.Beverages:
                    pricePerUnit = 10;
                    discountRate = 0.05;
                    break;
                case ProductCategory.CleaningSupplies:
                    pricePerUnit = 5;
                    discountRate = 0.25;
                    break;
                case ProductCategory.Miscellaneous:
                    pricePerUnit = 20;
                    discountRate = 0;
                    break;
            }
            this.Cost = pricePerUnit * this.Quantities * (1 - discountRate) * TAXRATE;
        }

        public override string ToString()
        {
            return $"Purchase ID : {Purchase.PURCHASE_ID}\n Category : {this.Category}\n Quantities : {this.Quantities}\n Final purchase cost : {this.Cost,2:c}.";
        }
    }
}
