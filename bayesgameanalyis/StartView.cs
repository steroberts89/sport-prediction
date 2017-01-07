using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bayesgameanalyis
{
    public partial class StartView : Form
    {
        bayessportanalysisEntities db;
        public StartView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                db = new bayessportanalysisEntities();
                db.Conditions.Load();
                db.Games.Load();
                db.Teams.Load();
            }
            catch (Exception)
            {
                if(MessageBox.Show("Dogodila se greška kod dohvaćanja podataka iz baze, provjeriti internet vezu ili "+
                    "kontaktirati bruno.blazeka@fer.hr. Ponovno pokrenuti?",
                    "Greška kod dohvaćanja baze",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    this.Close();
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            db.Dispose();
        }

        private void WeatherButton_Click(object sender, EventArgs e)
        {
            LabelVisible = true;
            var weatherForm = new WeatherLearning(db);
            weatherForm.Show();
        }

        private void ScoreButton_Click(object sender, EventArgs e)
        {
            LabelVisible = true;
            var scoreForm = new GamePrediction(db);
            scoreForm.Show();
        }

        public bool LabelVisible
        {
            get
            {
                return LoadingLabel.Visible;
            }
            set
            {
                LoadingLabel.Visible = value;
            }
        }
    }
}
