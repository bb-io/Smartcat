
namespace Apps.Smartcat.Models.Dtos
{
    public class LanguageStatisticsDTO
    {    
        public string language { get; set; }
        public List<Statistic> statistics { get; set; }
    }

    public class Statistic
    {
        public string name { get; set; }
        public double words { get; set; }
        public double effectiveWordsForBilling { get; set; }
    }
}

