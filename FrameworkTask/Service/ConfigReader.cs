using Microsoft.Extensions.Configuration;
using FrameworkTask.Model;

namespace FrameworkTask.Service
{
    internal static class ConfigReader
    {
        public static ComputeEngineRequestModel Read(string configPath)
        {
            ComputeEngineRequestModel model = new();
            ConfigurationBuilder builder = new();
            builder.AddJsonFile(configPath);
            IConfiguration config = builder.Build();
            config.Bind(model);
            return model;
        }
    }
}
