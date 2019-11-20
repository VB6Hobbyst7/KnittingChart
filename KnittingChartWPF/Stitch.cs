using System;
using System.Collections.Generic;
using System.Text;

namespace KnittingChartWPF
{
    public class Stitch
    {
        public string StitchName { get; set; }
        public string Description { get; set; }
        public string StitchKey { get; set; }
        public StitchType StitchType { get; set; }
    }
    public enum StitchType
    {
        Normal,
        Increase,
        Descrease
    }

}
