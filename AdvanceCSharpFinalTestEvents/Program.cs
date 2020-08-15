using System;

namespace AdvanceCSharpFinalTestEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            //5)    Associate the event with the event handler
            var eventclass = new EventClass();
            eventclass.name = "Renuka";

            var eventHandleClass = new EventHandleClass();
            eventHandleClass.MyEvent += eventclass.HandleEvent;

            //calling the event to occur
            eventHandleClass.EventHandlerMethod();
        }
    }
    //4)    Create code the will be run when the event occurs
    public class EventClass
    {
        public string name { get; set; }

        public void HandleEvent(object sender, MyEventArgs e)
        {
            Console.WriteLine("HadlingEvent {0}", e.message);
        }
    }

    //3)    Declare the code for the event
    public class EventHandleClass
    {
        public event MyEventHandlerDelegate MyEvent;

        public void EventHandlerMethod()
        {

            MyEventHandlerDelegate myHandler = MyEvent;
            if (myHandler != null)
            {
                myHandler(this, new MyEventArgs("My Event Handler"));
            }

        }
    }

    //2)    Set up the delegate for the event
    public delegate void MyEventHandlerDelegate(object source, MyEventArgs e);

    //1)    Create a class to pass as an argument for the event handlers
    public class MyEventArgs : EventArgs
    {
        public string message;
        public MyEventArgs(string str)
        {
            message = str;
        }

    }

}
