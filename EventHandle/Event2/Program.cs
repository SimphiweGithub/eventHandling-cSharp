using System;

namespace Events2
{

    //Implement a stock market system based on change of events
    //For Stock price aleerts in case of changes - Events
    class Stock
    {
        //Define a delegate for stock price events
        public delegate void PriceChangeEventHandler(decimal oldPrice, decimal newPrice);

        //Declare event of type PriceChangeEventHandler
        public event PriceChangeEventHandler PriceChanged; //PriceChange is a delegate type, as it is an object that references a method with the same signature as the delegate
        private decimal price;

        //Properties for stock price
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price != value) //Check if the price has changed
                {
                    decimal oldPrice = price; //Store the old price
                    price = value; //Set the new price
                    OnPriceChanged(oldPrice, price);
                }
            }
        }
        //Method to raise the PriceChange event
        protected virtual void OnPriceChanged(decimal oldPrice, decimal newPrice)
        {
            PriceChanged?.Invoke(oldPrice, newPrice); //Invoke the event, if it is not null the ? is a nullable that checks if the event has been subscribed to
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock(); //Create a new stock object

            //Subscribe to the PriceChanged event
            stock.PriceChanged += (oldPrice, newPrice) => Console.WriteLine($"Stock price changed from R{oldPrice} to R{newPrice}"); //Anonymous method to handle the event, => is a lambda expression

            //Change the stock price
            stock.Price = 50.75m; //m is used to indicate that the number is a decimal
        }
    }
}
