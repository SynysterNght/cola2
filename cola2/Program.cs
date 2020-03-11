using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cola2
{
    class Program
    {
        const string ServiceBusConnectionString = "Endpoint=sb://synysterqueue.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=wvJ84yKh9R0mxlOUkxrapQp90dVJsCh3nuQ/b53rlN0=";
        const string QueueName = "qprueba";
        static IQueueClient queueClient;
        static async Task Main(string[] args)
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
            

            string messageBody = $"Estoy descargando durante probamos en la clase";
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            await queueClient.SendAsync(message);
            Console.WriteLine("Subio el mensaje");
            Console.ReadKey();
            await queueClient.CloseAsync();

        }
        

       
        
    }
}
