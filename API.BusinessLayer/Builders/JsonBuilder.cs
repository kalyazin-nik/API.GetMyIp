using API.BusinessLayer.Services;
using API.Entity.BusinessLayer;
using API.Entity.Database;
using Newtonsoft.Json;

namespace API.BusinessLayer.Builders;

internal static class JsonBuilder
{
    internal static async Task<TEntity?> GetJsonDeserializeEntityAsync<TEntity>
        (string ip, CancellationToken cancellationToken = default) where TEntity : BaseIntermediateEntity
    {
        using var client = new HttpClient();
        var response = await client.GetAsync($"{DefaultConnection.Url}{ip}", cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            if (!content.Contains("fail"))
                return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<TEntity>(content)!;
        }
        return default;
    }

    internal static string? GetJsonSerializedEntityAsync<TEntity>(TEntity? entity)
        where TEntity : BaseEntity
        => JsonConvert.SerializeObject(entity, Formatting.Indented);
}
