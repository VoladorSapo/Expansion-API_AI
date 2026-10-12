using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEditor;

public class UnityObjectConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
        => typeof(UnityEngine.Object).IsAssignableFrom(objectType);

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var obj = value as UnityEngine.Object;

        // Unity's == also catches destroyed objects
        if (obj == null ||
            !AssetDatabase.TryGetGUIDAndLocalFileIdentifier(obj, out string guid, out long fileId))
        {
            writer.WriteNull();
            return;
        }

        writer.WriteStartObject();
        writer.WritePropertyName("guid");
        writer.WriteValue(guid);
        writer.WritePropertyName("fileId");
        writer.WriteValue(fileId);
        writer.WriteEndObject();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;

        var token = JObject.Load(reader);
        string guid = token.Value<string>("guid");
        long fileId = token.Value<long>("fileId");

        string path = AssetDatabase.GUIDToAssetPath(guid);
        if (string.IsNullOrEmpty(path)) return null;

        foreach (var asset in AssetDatabase.LoadAllAssetsAtPath(path))
        {
            if (asset == null || !objectType.IsInstanceOfType(asset)) continue;

            if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(asset, out _, out long id) && id == fileId)
                return asset;
        }
        return null;
    }
}