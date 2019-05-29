using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Framework.Utility
{
    public static class JsonConverter
    {
        public static string DynamicObjectToJson(dynamic d)
        {
            try
            {
                return JsonConvert.SerializeObject(d, Formatting.Indented);
            }
            catch (System.Exception)
            {
                return "";
            }
        }
        public static dynamic JsonToDynamicObject(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject(jsonString);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public static T JsonToEntity<T>(string jsonString) where T : new()
        {
            try
            {
                T jsonPL = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);

                return jsonPL;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public static T JsonToEntityByCamel<T>(string jsonString) where T : new()
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<Newtonsoft.Json.JsonConverter> { new CamelCaseOnlyConverter() }
                };

                T jsonPL = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString, settings);

                return jsonPL;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public static string EntityToJson<T>(T t)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(t);
            }
            catch (System.Exception)
            {
                return string.Empty;
            }
        }

        public static string EntityToJsonByCamel<T>(T t)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<Newtonsoft.Json.JsonConverter> { new CamelCaseOnlyConverter() }
                };

                return Newtonsoft.Json.JsonConvert.SerializeObject(t, settings);
            }
            catch (System.Exception)
            {
                return string.Empty;
            }
        }
    }

    public class CamelCaseOnlyConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType,
            object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == Newtonsoft.Json.JsonToken.Null)
                return null;

            try
            {
                var token = (JObject)JToken.Load(reader);

                var isCamelCased = true;
                WalkNode(token, null,
                t =>
                {
                    var nameFirstChar = t.Name[0].ToString();
                    if (!nameFirstChar.Equals(nameFirstChar.ToLower(),
                        StringComparison.CurrentCulture))
                    {
                        isCamelCased = false;
                        return;
                    }
                });

                if (!isCamelCased) return null;

                return token.ToObject(objectType);
            }
            catch (System.Exception) {
            }

            try
            {
                var token = (JArray)JToken.Load(reader);

                var isCamelCased = true;
                WalkNode(token, null,
                t =>
                {
                    var nameFirstChar = t.Name[0].ToString();
                    if (!nameFirstChar.Equals(nameFirstChar.ToLower(),
                        StringComparison.CurrentCulture))
                    {
                        isCamelCased = false;
                        return;
                    }
                });
                if (!isCamelCased) return null;

                return token.ToObject(objectType);
            }
            catch (System.Exception) { }

            return null;
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            JObject o = (JObject)JToken.FromObject(value);
            o.WriteTo(writer);
        }

        private static void WalkNode(JToken node,
                                Action<JObject> objectAction = null,
                                Action<JProperty> propertyAction = null)
        {
            if (node.Type == JTokenType.Object)
            {
                if (objectAction != null) objectAction((JObject)node);
                foreach (JProperty child in node.Children<JProperty>())
                {
                    if (propertyAction != null) propertyAction(child);
                    WalkNode(child.Value, objectAction, propertyAction);
                }
            }
            else if (node.Type == JTokenType.Array)
                foreach (JToken child in node.Children())
                    WalkNode(child, objectAction, propertyAction);
        }
    }
}
