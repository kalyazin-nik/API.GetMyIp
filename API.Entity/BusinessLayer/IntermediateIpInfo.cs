namespace API.Entity.BusinessLayer;

public class IntermediateIpInfo(string status, string country, string countyCode, string region, string regionName,
        string city, string zip, string lat, string lon, string timezone, string isp, string org, string As, string query)
    : BaseIntermediateEntity
{
    public string Status { get; set; } = status;
    public string Country { get; set; } = country;
    public string CountryCode { get; set; } = countyCode;
    public string Region { get; set; } = region;
    public string RegionName { get; set; } = regionName;
    public string City { get; set; } = city;
    public string Zip { get; set; } = zip;
    public string Lat { get; set; } = lat;
    public string Lon { get; set; } = lon;
    public string Timezone { get; set; } = timezone;
    public string Isp { get; set; } = isp;
    public string Org { get; set; } = org;
    public string As { get; set; } = As;
    public string Query { get; set; } = query;
}
