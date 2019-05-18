using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SportPredictor.Models
{
    public class Team : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public Team(string id)
        {
            string answer = ApiHandler.SendRequest(RequestBuilder(id));
            ParseAnswer(answer);
        }

        public Team(string id, string name, int points)
        {
            Id = id;
            Name = name;
        }

        public void ParseAnswer(string answer)
        {
            var jsonObject = JObject.Parse(answer);
            var team = jsonObject["teams"][0];
            Name = team["name"].ToString();
            List<Player> roster = new List<Player>();
            foreach (var rosterElement in team["roster"]["roster"])
            {
                roster.Add(new Player(
                    rosterElement["person"]["id"].ToString(),
                    rosterElement["person"]["fullName"].ToString(),
                    rosterElement["jerseyNumber"].ToString(),
                    rosterElement["position"]["code"].ToString()
                    )
                );
            }
            Players = roster;
        }

        public static string RequestBuilder(string id)
        {
            return string.Format("https://statsapi.web.nhl.com/api/v1/teams/{0}?expand=team.roster", id);
        }
    }
}
