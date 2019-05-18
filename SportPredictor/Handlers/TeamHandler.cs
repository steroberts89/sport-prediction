using Newtonsoft.Json.Linq;
using SportPredictor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportPredictor.Handlers
{
    public class TeamHandler
    {
        private List<Team> _teams;

        public TeamHandler()
        {
            _teams = ParseAnswer(ApiHandler.SendRequest(RequestBuilder("2018","2019")));
        }

        public static string RequestBuilder(string start, string end)
        {
            return string.Format("https://statsapi.web.nhl.com/api/v1/standings?season={0}{1}", start, end);
        }

        public static List<Team> ParseAnswer(string answer)
        {
            List<Team> teams = new List<Team>();
            var jsonObject = JObject.Parse(answer);
            foreach (var record in jsonObject["records"])
            {
                foreach (var teamRecord in record["teamRecords"])
                {
                    teams.Add(new Team(teamRecord["team"]["id"].ToString(), teamRecord["team"]["name"].ToString(), teamRecord["points"].ToObject<int>()));
                }
            }
            return teams;
        }

        public string getTeamNameById(string id)
        {
            return _teams.Find(x => x.Id == id).Name;
        }
    }
}
