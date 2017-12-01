using Newtonsoft.Json;

namespace Jarvus {

    public class Json {

        public static string SerializeObject(object data) {
            return JsonConvert.SerializeObject(
                                data,
                                Formatting.Indented,
                                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
                );
        }
    }
}