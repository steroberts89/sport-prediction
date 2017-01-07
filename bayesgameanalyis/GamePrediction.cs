using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace bayesgameanalyis
{
    public partial class GamePrediction : Form
    {
        bayessportanalysisEntities db;
        public GamePrediction()
        {
            InitializeComponent();
        }

        public GamePrediction(bayessportanalysisEntities entities)
        {
            InitializeComponent();
            db = entities;

            // Call the Load method to get the data for the given DbSet 
            // from the database. 
            // The data is materialized as entities. The entities are managed by 
            // the DbContext instance. 
            homeCombobox.DataSource = db.Games.Select(t => t.domacin).Distinct().ToList();
            //(homeCombobox.DataSource as List<string>).ForEach(t => t.Trim());
            awayCombobox.DataSource = db.Games.Select(t => t.gost).Distinct().ToList();
            //(awayCombobox.DataSource as List<string>).ForEach(t => t.Trim());
            var forma = Application.OpenForms.Cast<Form>().First(form => form.Name == "StartView") as StartView;
            forma.LabelVisible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gamesList = new List<Games>();
            if (homeWins.Text == "" || homeForm.Text == "" || awayForm.Text == "" || awayWins.Text == "")
            {
                MessageBox.Show("Nedovoljno unesenih podataka");
                return;
            }
            if (homeCombobox.SelectedIndex.Equals(awayCombobox.SelectedIndex))
            {
                MessageBox.Show("Odabrali ste "+ (homeCombobox.SelectedValue).ToString().Trim() +" dvaput.");
            }
            else
            {
                gamesList = db.Games.Where(t => t.domacin == (string)homeCombobox.SelectedValue && t.gost == (string)awayCombobox.SelectedValue).ToList();
                if (gamesList.Count == 0)
                {
                    MessageBox.Show("U bazi ne postoje utakmice izmedju ove dvije momcadi.");
                }
                else
                {
                    brain(gamesList);
                }
            }
        }

        private void brain(List<Games> games)
        {
            var host = games.FirstOrDefault().domacin;
            var guest = games.FirstOrDefault().gost;
            var bayesresult = bayes(host,guest,games);
            overallResult.Visible = true;
            overallResult.Text = ( (bayesresult.Item1 > bayesresult.Item2) ? host.Trim() : guest.Trim() ) 
                + " ce pobjediti s vjerojatnoscu: " + returnFormatted(bayesresult.Item1, bayesresult.Item2);
        }

        private Tuple<double, double> bayes(string host, string guest, List<Games> games)
        {
            var numHomeWins = Int32.Parse(homeWins.Text);
            var numawayWins = Int32.Parse(awayWins.Text);
            var formHome = Int32.Parse(homeForm.Text);
            var formAway = Int32.Parse(awayForm.Text);

            var probabilities = calculateProbability(host, guest);
            var homeWinGames = new List<Games>();
            var awayWinGames = new List<Games>();
            foreach (var game in games)
            {
                // parsiranje rezultata za odredjivanje pobjednika
                var res = Array.ConvertAll(game.rezultat.Trim().Split(':'),int.Parse);
                if (res[0] > res[1]) {
                    homeWinGames.Add(game);
                }
                else {
                    awayWinGames.Add(game);
                }
            }

            var statsHome = new OptionStatProperties(homeWinGames, numHomeWins, formHome, numawayWins, formAway);
            var statsAway = new OptionStatProperties(awayWinGames, numHomeWins, formHome, numawayWins, formAway);
            var evidence = probabilities.Item1 * statsHome.evidencePart + probabilities.Item2 * statsAway.evidencePart;
            var Aupper = probabilities.Item1 * statsHome.evidencePart / evidence;
            var Bupper = probabilities.Item2 * statsAway.evidencePart / evidence;

            return new Tuple<double, double>(Aupper,Bupper);
        }

        /// <summary>
        /// Metoda dohvaca polozaje timova na ljestvici i pomocu tih podataka racuna
        /// opcu vjerojatnost pobjede jednog odnosno drugog tima
        /// </summary>
        /// <param name="host">identifikator domaceg tima</param>
        /// <param name="guest">identifikator gostujuceg tima</param>
        /// <returns>vjerojatnost pobjede domaceg odnosno gostujuceg tima</returns>
        private Tuple<double,double> calculateProbability(string host, string guest)
        {
            var pozicija_host = db.Teams.Where(t => t.kratica == host).Select(t => t.polozaj_ljestvica).First();
            var pozicija_gost = db.Teams.Where(t => t.kratica == guest).Select(t => t.polozaj_ljestvica).First();
            var p_host = ((double)pozicija_gost / (pozicija_gost + pozicija_host));
            var p_gost = ((double)pozicija_host / (pozicija_gost + pozicija_host));
            if (p_host == null || p_gost == null)
            {
                throw new Exception("probabilities of winning are null");
            }
            else
            {
                //return new Tuple<double, double>(p_host.GetValueOrDefault(), p_gost.GetValueOrDefault());
                return new Tuple<double,double>(0.5,0.5);
            }
        }

        private string returnFormatted(double a, double b)
        {
            var toReturn = (a > b) ? a : b;
            return Math.Round(toReturn*100).ToString()+"%";
        }
    }
}
