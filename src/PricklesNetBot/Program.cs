using Autofac;
using PricklesNetBot.Infrastructure;
using PricklesNetBot.Infrastructure.Inputs;
using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace PricklesNetBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<PricklesNetBotAutofacModule>();

            using (var container = builder.Build())
            using (var scope = container.BeginLifetimeScope())
            {
                var handler = scope.Resolve<RocketLeagueHandler>();

                var websocketServer = new WebSocketServer("ws://localhost:12345");
                websocketServer.AddWebSocketService("/", () => new Handler(handler));
                websocketServer.Start();

                while (true)
                {
                    Console.WriteLine("Type p to set a property value, or e to exit");
                    var response = Console.ReadLine().ToLowerInvariant();

                    if (response == "p")
                    {
                        ChangeConstants.Go();
                    }
                    else if (response == "e")
                    {
                        break;
                    }
                }

                websocketServer.Stop();
            }
        }

        public class Handler : WebSocketBehavior
        {
            private readonly RocketLeagueHandler handler;

            private static Object locker = new Object();

            public Handler(RocketLeagueHandler handler)
            {
                this.handler = handler;
            }

            protected override void OnMessage(MessageEventArgs e)
            {
                lock (locker)
                {
                    var response = handler.Handle(e.RawData);
                    Send(response);
                }
            }
        }
    }
}
