namespace Collectors.Soccer.Domain
{
    public readonly record struct SoccerScore(DateTime EventTime, string CompetitionName, string[] Teams);
}
