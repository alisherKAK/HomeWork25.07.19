using System;

namespace Mediator
{
    //Mediator
    public abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }

    public abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }

    public class Client : Colleague
    {
        public Client(Mediator mediator) : base(mediator)
        {}

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение клиенту: " + message);
        }
    }

    public class Waiter : Colleague
    {
        public Waiter(Mediator mediator) : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение официанту: " + message);
        }
    }

    public class Cheff : Colleague
    {
        public Cheff(Mediator mediator) : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение повару: " + message);
        }
    }

    public class ManagerMediator : Mediator
    {
        public Client Client;
        public Waiter Waiter;
        public Cheff Cheff;

        public override void Send(string msg, Colleague colleague)
        {
            if(colleague == Client)
            {
                Waiter.Notify(msg);
            }
            else if(colleague == Waiter)
            {
                Cheff.Notify(msg);
            }
            else if(colleague == Cheff)
            {
                Client.Notify(msg);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ManagerMediator managerMediator = new ManagerMediator();
            Client client = new Client(managerMediator);
            Waiter waiter = new Waiter(managerMediator);
            Cheff cheff = new Cheff(managerMediator);

            managerMediator.Client = client;
            managerMediator.Cheff = cheff;
            managerMediator.Waiter = waiter;

            client.Send("Хочу сделать заказ");
            waiter.Send("Клиент сделал заказ");
            cheff.Send("Заказ будет выполнен в течений 10 мин");
        }
    }
}
