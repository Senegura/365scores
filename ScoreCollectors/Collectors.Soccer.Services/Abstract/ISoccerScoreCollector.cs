using Collectors.Soccer.Domain;

namespace Collectors.Soccer.Services.Abstract
{
    public interface ISoccerScoreCollector
    {
        SoccerScore CollectScore();
    }
}
