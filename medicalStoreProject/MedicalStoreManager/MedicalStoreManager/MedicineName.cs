using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStoreManager
{
    public class MedicineName
    {
        public string description { get; set; }
        public string source { get; set; }
        public List<string> drugs { get; set; }
    }
}
