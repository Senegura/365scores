namespace Scores365.ScoreCms.Domain
{
    public readonly record struct SoccerScore(DateTime EventTime, string CompetitionName, string[] Teams);
}
