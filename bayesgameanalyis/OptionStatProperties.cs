using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bayesgameanalyis
{
    class OptionStatProperties
    {
        public double condHomeForm, condAwayForm, condHomeWins, condAwayWins;
        public double evidencePart;
        public StatisticalProperty homeForm, homeWins, awayForm, awayWins;

        public OptionStatProperties(List<Games> games, int hForm, int hWins, int aForm, int aWins)
        {
            homeForm = new StatisticalProperty("domaci_niz", games.Select(t => t.domacin_niz).ToList());
            homeWins = new StatisticalProperty("domaci_pobjede", games.Select(t => t.pobjede_domacin).ToList());
            awayForm = new StatisticalProperty("gost_niz", games.Select(t => t.gost_niz).ToList());
            awayWins = new StatisticalProperty("gost_pobjede", games.Select(t => t.pobjede_gost).ToList());

            condHomeForm = calculate(homeForm, hForm);
            condHomeWins = calculate(homeWins, hWins);
            condAwayForm = calculate(awayForm, aForm);
            condAwayWins = calculate(awayWins, aWins);

            evidencePart = condAwayForm * condAwayWins * condHomeForm * condHomeWins;
        }

        private double calculate(StatisticalProperty property, int value)
        {
            return Math.Pow(Math.E,(double)(-Math.Pow(value-property.mean,2)/(2*property.variance))) / Math.Sqrt(2 * Math.PI * property.variance);
        }
    }
}
