using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineNameList
{
    public class MedicineList
    {
        public string description { get; set; }
        public string source { get; set; }
        public List<string> drugs { get; set; }
        public string rate { get; set; }
        public string MfgDate { get; set; }
        public string ExpDate { get; set; }

    }

}
