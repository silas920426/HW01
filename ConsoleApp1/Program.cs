using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Drink> drinks = new List<Drink>();
            List<OrderItem> orders = new List<OrderItem>();

            //新增飲料品項
            AddNewDrink(drinks);

            //顯示飲料清單
            DisplayDrinkMenu(drinks);

            //訂購飲料
            PlaceOrder(orders, drinks);

            //計算價格
            CalculatePrice(orders);
        }

        private static void CalculatePrice(List<OrderItem> myOrders)
        {
            double total = 0.0;
            double sellPrice = 0.0;
            string message = "";

            foreach (var orderitem in myOrders) total += orderitem.SubTotal;

            if (total >= 500)
            {
                message = "訂購滿500元以上者8折";
                sellPrice = total * 0.8;
            }
            else if (total >= 300)
            {
                message = "訂購滿300元以上者85折";
                sellPrice = total * 0.85;
            }
            else if (total >= 200)
            {
                message = "訂購滿200元以上者9折";
                sellPrice = total * 0.9;
            }
            else
            {
                message = "訂購未滿200元以上者不打折";
                sellPrice = total;
            }
            Console.WriteLine();
            Console.WriteLine($"您總共訂購{myOrders.Count}項飲料，總計{total}元。{message}，合計需付款{sellPrice}元");
        }

        private static void PlaceOrder(List<OrderItem> myOrders, List<Drink> myDrinks)
        {
            Console.WriteLine("開始訂購飲料...按下x鍵離開");
            string s;
            int index, quantity, subtotal;
            while (true)
            {
                Console.Write("請輸入您所要訂購的品項編號: ");
                s = Console.ReadLine();
                if (s == "x") break;
                else index = Convert.ToInt32(s);

                Console.Write("請輸入您所要的杯數: ");
                s = Console.ReadLine();
                if (s == "x") break;
                else quantity = Convert.ToInt32(s);

                Drink drink = myDrinks[index];
                subtotal = drink.Price * quantity;

                myOrders.Add(new OrderItem() { Index = index, Quantity = quantity, SubTotal = subtotal });

                Console.WriteLine($"您訂購{drink.Name}{drink.Size}{quantity}杯，每杯{drink.Price}元，小計{subtotal}元。");
            }
        }

        private static void DisplayDrinkMenu(List<Drink> myDrinks)
        {
            // for-loop
            //for (int i = 0; i < drinks.Count; i++)
            //{
            //    Console.WriteLine($"{drinks[i].Name}  {drinks[i].Size} {drinks[i].Price}元");
            //}

            Console.WriteLine("飲料清單");
            Console.WriteLine("-----------------------");
            Console.WriteLine(String.Format("{0,-5}{1,-5}{2,-5}{3,-5}", "編號", "品名", "大小", "價格"));

            // foreach
            int i = 0;
            foreach (Drink drink in myDrinks)
            {
                Console.WriteLine($"{i,-7}{drink.Name,-5}{drink.Size,-5}{drink.Price,-5:C0}");
                i++;
            }
            Console.WriteLine("-----------------------");
        }

        private static void AddNewDrink(List<Drink> myDrinks)
        {
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 60 });
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "小杯", Price = 40 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 60 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "小杯", Price = 40 });
            myDrinks.Add(new Drink() { Name = "可樂", Size = "大杯", Price = 30 });
            myDrinks.Add(new Drink() { Name = "可樂", Size = "小杯", Price = 20 });
        }
    }
}
