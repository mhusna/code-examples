﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product hdd = new Product(50);
            hdd.ProductName = "Hdd";

            Product gsm = new Product(50);
            gsm.ProductName = "Gsm";
            gsm.StockControlEvent += Gsm_StockControlEvent;

            for (int i = 0; i < 10; i++)
            {
                hdd.Sell(10);
                gsm.Sell(10);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static void Gsm_StockControlEvent()
        {
            Console.WriteLine("Gsm about to finish !!!");
        }
    }
}
