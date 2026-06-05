namespace eHealthMonitor.BusinessLayer.Structure
{
    public static class JwtSettings
    {
        public const string Issuer = "eHealthMonitorApi";
        public const string Audience = "eHealthMonitorClients";
        public const int ExpireMinutes = 60;
    }
}
