using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Редактор
{
    public class geometry
    {
        public  string figure { get; set; }
        public  string Linelength { get; set; }
        public  string width { get; set; }
       private geometry() { }
       public geometry(string figures, string linelength, string widths)
        {
            figure = figures;
            Linelength = linelength;
            width = widths;
        }
    }
}
