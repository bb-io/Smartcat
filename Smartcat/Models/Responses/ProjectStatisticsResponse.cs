using Apps.Smartcat.Models.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Responses
{
    public class ProjectStatisticsResponse
    {
        public ProjectStatisticsResponse(List<LanguageStatisticsDTO> input)
        {
            var AllStats = new List<StatsPerLang>();
            foreach (var language in input)
            {
                AllStats.Add(new StatsPerLang()
                {
                    Language = language.language,
                    TotalWords = (int?)language.statistics.FirstOrDefault(x => x.name == "total").words,
                    New = (int?)language.statistics.FirstOrDefault(x => x.name == "newWords").words,
                    Repetitions = (int?)language.statistics.FirstOrDefault(x => x.name == "repetitions").words,
                    CrossRepetitions = (int?)language.statistics.FirstOrDefault(x => x.name == "crossFileRepeated").words,
                    match_102 = (int?)language.statistics.FirstOrDefault(x => x.name == "contextMatch_102").words,
                    match_101 = (int?)language.statistics.FirstOrDefault(x => x.name == "contextMatch_101").words,
                    match_100 = (int?)language.statistics.FirstOrDefault(x => x.name == "match_100").words,
                    match_95_99 = (int?)language.statistics.FirstOrDefault(x => x.name == "match_95_99").words,
                    match_85_94 = (int?)language.statistics.FirstOrDefault(x => x.name == "match_85_94").words,
                    match_75_84 = (int?)language.statistics.FirstOrDefault(x => x.name == "match_75_84").words,
                    match_50_74 = (int?)language.statistics.FirstOrDefault(x => x.name == "match_50_74").words,


                }) ;
                
            }
            StatisticsPerLanguage = AllStats;
        }

        [Display("Statistics per language")]
        public IEnumerable<StatsPerLang> StatisticsPerLanguage {get; set;}

    }

    public class StatsPerLang 
    {
        public string Language { get; set; }

        [Display("Total words")]
        public int? TotalWords { get; set; }

        [Display("New words")]
        public int? New { get; set; }
        public int? Repetitions { get; set; }

        [Display("Cross file repetitions")]
        public int? CrossRepetitions { get; set; }

        [Display("102% Match")]
        public int? match_102 { get; set; }

        [Display("101% Match")]
        public int? match_101 { get; set; }

        [Display("100% Match")]
        public int? match_100 { get; set; }

        [Display("95-99% Match")]
        public int? match_95_99 { get; set; }

        [Display("85-94% Match")]
        public int? match_85_94 { get; set; }

        [Display("75-84% Match")]
        public int? match_75_84 { get; set; }

        [Display("50-74% Match")]
        public int? match_50_74 { get; set; }
    }
}
