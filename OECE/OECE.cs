using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OECE
{
    public class OECE
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public bool LoPossiedo { get; set; }
        public bool LoVoglio { get; set; }

        public static List<OECE> OECEList = new List<OECE>();
    }
}