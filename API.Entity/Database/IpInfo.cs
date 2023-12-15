using Newtonsoft.Json;

namespace API.Entity.Database;

[JsonObject(MemberSerialization.OptIn)]
public class IpInfo : BaseEntity
{
    public string UserId { get; private set; }
    [JsonProperty(PropertyName = "ip")] public string Ip { get; private set; }
    [JsonProperty(PropertyName = "city")] public string City { get; private set; }
    [JsonProperty(PropertyName = "region")] public string Region { get; private set; }
    [JsonProperty(PropertyName = "country")] public string Country { get; private set; }
    [JsonProperty(PropertyName = "loc")] public string Location { get; private set; }
    [JsonProperty(PropertyName = "org")] public string Organization { get; private set; }
    [JsonProperty(PropertyName = "zip")] public string ZipCode { get; private set; }
    [JsonProperty(PropertyName = "timezone")] public string TimeZone { get; private set; }
    [JsonProperty(PropertyName = "readme")] public string Readme { get; set; }
    public virtual User? User { get; set; }

    public IpInfo(string userId, string ip, string city, string region, string country, string location,
        string organization, string zipCode, string timeZone, string readme)
    {
        UserId = userId;
        Ip = ip;
        City = city;
        Region = region;
        Country = country;
        Location = location;
        Organization = organization;
        ZipCode = zipCode;
        TimeZone = timeZone;
        Readme = readme;
    }

    public IpInfo(string guid, string query, string city, string regionName, string countryCode, string lat, string lon,
        string org, string zip, string timezone, string readme)
    {
        UserId = guid;
        Ip = query;
        City = city;
        Region = regionName;
        Country = countryCode;
        Location = $"{lat}, {lon}";
        Organization = org;
        ZipCode = zip;
        TimeZone = timezone;
        Readme = readme;
    }
}
