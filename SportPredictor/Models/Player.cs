using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportPredictor.Models
{
    public class Player : IEntity
    {
        private string Id { get; }
        public string Name { get; set; }
        public string JerseyNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }

        /// <summary>
        /// Player constructor that gets player data from API
        /// </summary>
        /// <param name="id">Player ID</param>
        public Player(string id)
        {
            string answer = ApiHandler.SendRequest(RequestBuilder(id));
            ParseAnswer(answer);
        }

        public Player(string id, string name, string jersey, string position)
        {
            Id = id;
            Name = name;
            JerseyNumber = jersey;
            Position = position;
        }

        public void ParseAnswer(string answer)
        {
            var jsonObject = JObject.Parse(answer);
            var person = jsonObject["people"][0];
            Name = person["fullName"].ToString();
            BirthDate = DateTime.ParseExact(person["birthDate"].ToString(), "yyyy-MM-dd", null);
            Nationality = person["nationality"].ToString();
        }

        public static string RequestBuilder(string id)
        {
            return string.Format("https://statsapi.web.nhl.com/api/v1/people/{0}", id);
        }
    }
}
