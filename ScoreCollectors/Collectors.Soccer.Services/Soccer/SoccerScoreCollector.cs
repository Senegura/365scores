using Collectors.Soccer.Domain;
using Collectors.Soccer.Services.Abstract;

namespace Collectors.Soccer.Services.Soccer
{
    public class SoccerScoreCollector : ISoccerScoreCollector
    {
        public SoccerScore CollectScore()
        {
            return new SoccerScore(DateTime.UtcNow, "UEFA Champions League Qualifiers", ["Linfield", "Shelbourne"]);
        }
    }
}
