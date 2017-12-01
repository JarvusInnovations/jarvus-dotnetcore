using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Jarvus {

    public class Logger {

        public static void Debug(ILogger logger, object data){
            logger.LogDebug(Serialize(data));
        }

        public static void Information(ILogger logger, object data){
            logger.LogInformation(Serialize(data));
        }

        public static void Warning(ILogger logger, object data){
            logger.LogWarning(Serialize(data));
        }

        public static string Serialize(object data){
            return Jarvus.Json.SerializeObject(data);
        }

        internal static void Error(ILogger logger, object data){
            logger.LogWarning(Serialize(data));
        }
    }
}