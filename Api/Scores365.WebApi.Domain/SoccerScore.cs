namespace Scores365.WebApi.Domain
{
    public readonly record struct SoccerScore(DateTime EventTime, string CompetitionName, string[] Teams);
}
