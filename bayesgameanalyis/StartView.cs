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
            base.OnLoad(e);
            db = new bayessportanalysisEntities();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.db.Dispose();
        }

        private void WeatherButton_Click(object sender, EventArgs e)
        {
            LabelVisible = true;
            db.Conditions.Load();
            var weatherForm = new WeatherLearning(db);
            weatherForm.Show();
        }

        private void ScoreButton_Click(object sender, EventArgs e)
        {
            LabelVisible = true;
            db.Games.Load();
            db.Teams.Load();
            var scoreForm = new GamePrediction(db);
            scoreForm.Show();
        }

        public bool LabelVisible
        {
            get
            {
                return this.LoadingLabel.Visible;
            }
            set
            {
                this.LoadingLabel.Visible = value;
            }
        }
    }
}
