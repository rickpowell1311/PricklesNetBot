using Autofac;
using PricklesNetBot.Infrastructure;
using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Test
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

                Console.ReadKey();

                websocketServer.Stop();
            }
        }

        public class Handler : WebSocketBehavior
        {
            private readonly RocketLeagueHandler handler;

            public Handler(RocketLeagueHandler handler)
            {
                this.handler = handler;
            }

            protected override void OnMessage(MessageEventArgs e)
            {
                var response = handler.Handle(e.RawData);

                Send(response);
            }
        }
    }
}
