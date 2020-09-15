using Newtonsoft.Json;

namespace Lbum.Utils.Utils
{
    /// <summary>
    /// serializador de objetos
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Deserializar json a objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json) => 
            JsonConvert.DeserializeObject<T>(json);
        

        /// <summary>
        /// Serializar objeto a string con formato json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object"></param>
        /// <returns></returns>
        public static string SerializarObjetoJson<T>(T @object) =>
            JsonConvert.SerializeObject(@object);
    }
}