using API.BusinessLayer.Services;
using API.Entity.BusinessLayer;
using API.Entity.Database;

namespace API.BusinessLayer.Builders;

public static class EntityBuilder
{
    public static void CreateUser(string guid, string ip)
    {
        var buffer = JsonBuilder.GetJsonDeserializeEntityAsync<IntermediateIpInfo>(ip).Result;
        if (buffer is not null)
        {
            var ipInfo = new IpInfo(guid, buffer.Query, buffer.City, buffer.RegionName, buffer.CountryCode,
                buffer.Lat, buffer.Lon, buffer.Org, buffer.Zip, buffer.Timezone, "empty");
            var user = new User(guid) { IpInfo = ipInfo, CreatedAt = DateTime.Now };
            ipInfo.User = user;

            DatabaseService.Add(user);
        }
    }

    private static bool TryGetUser(string guid, out User? user)
    {
        user = DatabaseService.GetEntity<User>(guid);
        return user is not null;
    }

    public static bool ContainsUser(string guid)
    {
        return DatabaseService.GetEntity<User>(guid) is not null;
    }

    public static string GetIpInfo(string guid)
    {
        var ipInfo = DatabaseService.GetEntity<IpInfo>(guid);
        return ipInfo is not null ? JsonBuilder.GetJsonSerializedEntityAsync(ipInfo)! : "{ null }";
    }
}
