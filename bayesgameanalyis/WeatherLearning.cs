using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bayesgameanalyis
{
    public partial class WeatherLearning : Form
    {
        bayessportanalysisEntities db;
        public WeatherLearning()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tempComboBox.DataSource = db.Conditions.Select(t => t.temperatura).Distinct().ToList();
            fallingComboBox.DataSource = db.Conditions.Select(t => t.padaline).Distinct().ToList();
            snowComboBox.DataSource = db.Conditions.Select(t => t.visina_snijega).Distinct().ToList();
            windComboBox.DataSource = db.Conditions.Select(t => t.vjetar).Distinct().ToList();
        }

        public WeatherLearning(bayessportanalysisEntities entities)
        {
            db = entities;
            InitializeComponent();
            var forma = Application.OpenForms.Cast<Form>().First(form => form.Name == "StartView") as StartView;
            forma.LabelVisible = false;
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            var size = db.Conditions.Count();
            var conditionsDA = db.Conditions.Where(t => t.igrati);
            var conditionsNE = db.Conditions.Where(t => !t.igrati);
            var cntDa = conditionsDA.Count();
            var cntNe = conditionsNE.Count();
            var tempDa = conditionsDA.Where(t => t.temperatura == (string)tempComboBox.SelectedValue).Count();
            var tempNe = conditionsNE.Where(t => t.temperatura == (string)tempComboBox.SelectedValue).Count();
            var padDa = conditionsDA.Where(t => t.padaline == (string)fallingComboBox.SelectedValue).Count();
            var padNe = conditionsNE.Where(t => t.padaline == (string)fallingComboBox.SelectedValue).Count();
            var snowDa = conditionsDA.Where(t => t.visina_snijega == (string)snowComboBox.SelectedValue).Count();
            var snowNe = conditionsNE.Where(t => t.visina_snijega == (string)snowComboBox.SelectedValue).Count();
            var vlagDa = conditionsDA.Where(t => t.vjetar == (string)windComboBox.SelectedValue).Count();
            var vlagNe = conditionsNE.Where(t => t.vjetar == (string)windComboBox.SelectedValue).Count();

            var probDA = (double)cntDa / size;
            var probNE = (double)cntNe / size;

            var vjDa = calculateProb(probDA,cntDa,tempDa,padDa,snowDa,vlagDa);
            var vjNe = calculateProb(probNE, cntNe, tempNe, padNe, snowNe, vlagNe);
            result.Text = (vjDa >= vjNe) ? "DA" : "NE";
            result.Visible = true;
        }

        public double calculateProb(double prob, int cnt, int temp, int pad, int snow, int vlag)
        {
            return prob * (double)(temp * pad * snow * vlag) / (Math.Pow(cnt, 4.0));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
