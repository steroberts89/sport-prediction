using System;
using System.Collections.Generic;
using System.Text;

namespace SportPredictor
{
    public class DataHandler
    {
        private PredictionTypes _predictionType;

        public DataHandler(PredictionTypes type)
        {
            _predictionType = type;
        }

        public IEnumerable<GameData> GetGames(string start, string end)
        {
            ApiHandler handler = new ApiHandler();
            string answer = handler.SendRequest(RequestBuilder(start,end));
            return handler.ParseAnswer(answer,_predictionType);
        }

        public static string RequestBuilder(string start, string end)
        {
            return string.Format("https://statsapi.web.nhl.com/api/v1/schedule?expand=schedule.linescore&startDate={0}&endDate={1}", start, end);
        }

        public static string RequestBuilder(string team, string start, string end)
        {
            return string.Format("https://statsapi.web.nhl.com/api/v1/schedule?expand=schedule.linescore&teamId={0}&startDate={1}&endDate={2}", team, start, end);
        }
    }
}
