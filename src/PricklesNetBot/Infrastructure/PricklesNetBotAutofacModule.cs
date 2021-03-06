﻿using Autofac;
using PricklesNetBot.Domain.Decision;

namespace PricklesNetBot.Infrastructure
{
    public class PricklesNetBotAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RocketLeagueHandler>().AsSelf();
        }
    }
}
