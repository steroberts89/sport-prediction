using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SportPredictor
{
    public class ApiHandler
    {
        public string SendRequest(string url)
        {
            string answer = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                answer = reader.ReadToEnd();
            }
            return answer;
        }

        public List<GameData> ParseAnswer(string answer)
        {
            List<GameData> games = new List<GameData>();
            var jsonObject = JObject.Parse(answer);
            foreach (var date in jsonObject["dates"])
            {
                var gamePeriod = date["games"][0]["linescore"]["currentPeriod"].ToObject<int>();
                var homeScore = date["games"][0]["teams"]["home"]["score"].ToObject<int>();
                var awayScore = date["games"][0]["teams"]["away"]["score"].ToObject<int>();
                string resultLabel = (homeScore > awayScore) ? "H" : "A";
                if(gamePeriod > 3)
                {
                    resultLabel += "OT";
                } else
                {
                    resultLabel += "W";
                }

                if (date["games"][0]["gameType"].ToObject<string>() == "R")
                {
                    GameData game = new GameData
                    {
                        Home = date["games"][0]["teams"]["home"]["team"]["id"].ToObject<string>(),
                        Away = date["games"][0]["teams"]["away"]["team"]["id"].ToObject<string>(),
                        Label = resultLabel,
                        HomeWins = date["games"][0]["teams"]["home"]["leagueRecord"]["wins"].ToObject<int>(),
                        HomeLosses = date["games"][0]["teams"]["home"]["leagueRecord"]["losses"].ToObject<int>(),
                        HomeOT = date["games"][0]["teams"]["home"]["leagueRecord"]["ot"].ToObject<int>(),
                        AwayWins = date["games"][0]["teams"]["away"]["leagueRecord"]["wins"].ToObject<int>(),
                        AwayLosses = date["games"][0]["teams"]["away"]["leagueRecord"]["losses"].ToObject<int>(),
                        AwayOT = date["games"][0]["teams"]["away"]["leagueRecord"]["ot"].ToObject<int>()
                    };
                    games.Add(game);
                }
            }
            return games;
        }
    }
}
