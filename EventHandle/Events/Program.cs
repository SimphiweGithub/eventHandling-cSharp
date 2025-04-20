using System;


namespace Events
{
    //Declare a delegate
    delegate void ButtonClickEventHandler(); //Same return type as the method referenced
    class Button
    {
        //Decalre event of type ButtonClickEventHandler
        public event ButtonClickEventHandler Click; //ButtonClickEventHandler is a delegate type, as it is an object that references a method with the same signature as the delegate

        //Method to simulae a button click
        public void SimulateClick()
        {
            Console.WriteLine("Button clicked: ");
            OnClick(); //Raise the event
        }

        protected virtual void OnClick()
        {
            Click?.Invoke(); //Invoke the event, if it is not null the ? is a nullable that checks if the event has been subscribed to

            //Method to raise the click event
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                Button button = new Button(); //Create a new button object
               
                //Subscribe to the click event
                button.Click += () => Console.WriteLine("Handling button Click Event!"); //Anonymous method to handle the event, => is a lambda expression
                                                                                         //Lambda expression is a shorthand for creating an anonymous method
                                                                                         //Anonymous method is a method that has no name and is defined inline
                                                                                         //+= is used to subscribe to the event, it adds the method to the event
                                                                                         //In other words the subscribe is a method that is called when the event is raised

            //Simulare button click
            button.SimulateClick(); //Call the SimulateClick method to raise the event
            }
        }
    }

