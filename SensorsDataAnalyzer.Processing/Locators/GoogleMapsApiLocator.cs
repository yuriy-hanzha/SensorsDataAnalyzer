using GoogleMaps.LocationServices;

namespace SensorsDataAnalyzer.Processing
{
    public class GoogleMapsApiLocator
    {
        public string Define(double latitude, double longitude)
        {
            var locationService = new GoogleLocationService();
            Region region = locationService.GetRegionFromLatLong(latitude, longitude);

            return $"{region.ShortCode} {region.Name}";
        }
    }
}
