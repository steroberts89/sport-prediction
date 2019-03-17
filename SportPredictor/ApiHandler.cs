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

        public List<GameData> ParseAnswer(string answer, PredictionTypes type)
        {
            List<GameData> games = new List<GameData>();
            var jsonObject = JObject.Parse(answer);
            foreach (var date in jsonObject["dates"])
            {
                foreach (var game in date["games"])
                {
                    var gamePeriod = game["linescore"]["currentPeriod"].ToObject<int>();
                    var homeScore = game["teams"]["home"]["score"].ToObject<int>();
                    var awayScore = game["teams"]["away"]["score"].ToObject<int>();
                    string resultLabel = (homeScore > awayScore) ? "H" : "A";
                    if (type == PredictionTypes.Multiclass)
                    {
                        if (gamePeriod > 3)
                        {
                            resultLabel += "OT";
                        }
                        else
                        {
                            resultLabel += "W";
                        }
                    }

                    if (game["gameType"].ToObject<string>() == "R")
                    {
                        games.Add(new GameData
                        {
                            Home = game["teams"]["home"]["team"]["id"].ToObject<string>(),
                            Away = game["teams"]["away"]["team"]["id"].ToObject<string>(),
                            Label = resultLabel,
                            HomeWins = game["teams"]["home"]["leagueRecord"]["wins"].ToObject<int>(),
                            HomeLosses = game["teams"]["home"]["leagueRecord"]["losses"].ToObject<int>(),
                            HomeOT = game["teams"]["home"]["leagueRecord"]["ot"].ToObject<int>(),
                            AwayWins = game["teams"]["away"]["leagueRecord"]["wins"].ToObject<int>(),
                            AwayLosses = game["teams"]["away"]["leagueRecord"]["losses"].ToObject<int>(),
                            AwayOT = game["teams"]["away"]["leagueRecord"]["ot"].ToObject<int>()
                        });
                    }
                }
            }
            return games;
        }
    }
}
