namespace usadmin_dashboard.Models
{
    public class masters_us_grants
    {
        public uint GrantIndex { get; set; }
        public string GrantTitle { get; set; }
        public string LinkURL { get; set; }
        public DateTime PostDate { get; set; }
        public uint PDValue { get; set; }
        public DateTime DeadLineDate { get; set; }
        public uint DDValue { get; set; }
        public string ShortIntro { get; set; }
        public string DonorType { get; set; }
        public uint DonorIndex { get; set; }
        public string DonorAgency { get; set; }
        public string GrantType { get; set; }
        public string GrantSize { get; set; }
        public string GrantLogoImage { get; set; }
        public uint OnGoingGrants { get; set; }
        public string Status { get; set; }
        public string GrantContent { get; set; }
        public string GrantDuration { get; set; }
        public string STCTType { get; set; }
        public string STATESTRING { get; set; }
        public string COUNTYSTRING { get; set; }
        public string ISSUESTRING { get; set; }
        public int WpIndex { get; set; }
        public uint ViewCount { get; set; }
        public string ENTITYSTRING { get; set; }
    }
}
