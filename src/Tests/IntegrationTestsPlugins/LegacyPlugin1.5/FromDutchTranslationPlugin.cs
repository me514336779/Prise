﻿using System;
using Legacy.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prise.Plugin;

namespace LegacyPlugin1_5
{
    [Plugin(PluginType = typeof(ITranslationPlugin))]
    public class FromDutchTranslationPlugin : TranslationPluginBase
    {
        internal FromDutchTranslationPlugin(IConfiguration configuration, IDictionaryService dictionaryService)
            : base(configuration, dictionaryService)
        {
        }

        [PluginFactory]
        public static FromDutchTranslationPlugin ThisIsTheFactoryMethod(IServiceProvider pluginServices)
        {
            var configFromHost = pluginServices.GetService<IConfiguration>();

            var dictionaryService = pluginServices.GetService<IDictionaryService>();

            return new FromDutchTranslationPlugin(
                configFromHost, // This service is provided by the Prise.IntegrationTestsHost application and is registered as a Host Type
                dictionaryService // This service is provided by the plugin using the PluginBootstrapper
            );
        }

        protected override string GetLanguageCode() => "nl-BE";
    }
}
