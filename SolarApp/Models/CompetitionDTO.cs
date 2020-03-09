namespace SolarApp.Models
{
    public class CompetitionDTO
    {
        public int competitionid { get; set; }
        public string CompetitionTitle { get; set; }
        public string CompetitionDescription { get; set; }
        public string CompetitionUrlAddress { get; set; }
        public string Date { get; set; }
        //public IEnumerable<Result> CompetitionResults { get; set; } = new List<Result>();
    }
}
