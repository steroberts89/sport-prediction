using System;
using System.Collections.Generic;
using System.Text;

namespace SportPredictor
{
    public class DataHandler
    {
        public static IEnumerable<GameData> GetGames(string team, string start, string end)
        {
            ApiHandler handler = new ApiHandler();
            string request = string.Format("https://statsapi.web.nhl.com/api/v1/schedule?expand=schedule.linescore&teamId={0}&startDate={1}&endDate={2}", team,start,end);
            string answer = handler.SendRequest(request);
            return handler.ParseAnswer(answer);
        }
    }
}
