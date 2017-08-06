using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class CaliforniaCountyListBuilder : CountyListBuilder
    {
        public CaliforniaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "CA";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ALAM","ALPI","AMAD","BUTT","CALA",
                "CCOS","COLU","DELN","ELDO","FRES",
                "GLEN","HUMB","IMPE","INYO","KERN",
                "KING","LAKE","LANG","LASS","MADE",
                "MARN","MARP","MEND","MERC","MODO",
                "MONO","MONT","NAPA","NEVA","ORAN",
                "PLAC","PLUM","RIVE","SACR","SBAR",
                "SBEN","SBER","SCLA","SCRU","SDIE",
                "SFRA","SHAS","SIER","SISK","SJOA",
                "SLUI","SMAT","SOLA","SONO","STAN",
                "SUTT","TEHA","TRIN","TULA","TUOL",
                "VENT","YOLO","YUBA" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ALAM": return "Alameda";
                case "ALPI": return "Alpine";
                case "AMAD": return "Amador";
                case "BUTT": return "Butte";
                case "CALA": return "Calaveras";
                case "CCOS": return "Contra Costa";
                case "COLU": return "Colusa";
                case "DELN": return "Del Norte";
                case "ELDO": return "El Dorado";
                case "FRES": return "Fresno";
                case "GLEN": return "Glenn";
                case "HUMB": return "Humboldt";
                case "IMPE": return "Imperial";
                case "INYO": return "Inyo";
                case "KERN": return "Kern";
                case "KING": return "Kings";
                case "LAKE": return "Lake";
                case "LANG": return "Los Angeles";
                case "LASS": return "Lassen";
                case "MADE": return "Madera";
                case "MARN": return "Marin";
                case "MARP": return "Mariposa";
                case "MEND": return "Mendocino";
                case "MERC": return "Merced";
                case "MODO": return "Modoc";
                case "MONO": return "Mono";
                case "MONT": return "Monterey";
                case "NAPA": return "Napa";
                case "NEVA": return "Nevada";
                case "ORAN": return "Orange";
                case "PLAC": return "Placer";
                case "PLUM": return "Plumas";
                case "RIVE": return "Riverside";
                case "SACR": return "Sacramento";
                case "SBAR": return "Santa Barbara";
                case "SBEN": return "San Benito";
                case "SBER": return "San Bernardino";
                case "SCLA": return "Santa Clara";
                case "SCRU": return "Santa Cruz";
                case "SDIE": return "San Diego";
                case "SFRA": return "San Francisco";
                case "SHAS": return "Shasta";
                case "SIER": return "Sierra";
                case "SISK": return "Siskiyou";
                case "SJOA": return "San Joaquin";
                case "SLUI": return "San Luis Obispo";
                case "SMAT": return "San Mateo";
                case "SOLA": return "Solano";
                case "SONO": return "Sonoma";
                case "STAN": return "Stanislaus";
                case "SUTT": return "Sutter";
                case "TEHA": return "Tehama";
                case "TRIN": return "Trinity";
                case "TULA": return "Tulare";
                case "TUOL": return "Tuolumne";
                case "VENT": return "Ventura";
                case "YOLO": return "Yolo";
                case "YUBA": return "Yuba";
                default: return String.Empty;
            }
        }
    }
}
