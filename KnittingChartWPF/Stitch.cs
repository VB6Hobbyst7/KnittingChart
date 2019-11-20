using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace KnittingChartWPF
{
    public class Stitch
    {
        public string StitchName { get; set; }
        public string Description { get; set; }
        public string StitchKey { get; set; }

        public int StitchCount { get; set; }
        public StitchType StitchType { get; set; }
        public Regex Regex { get; set; }
        public Icon Icon { get; set; }

        public Stitch()
        {
            StitchCount = 1;
        }
    }
    public class KnitStitch : Stitch
    {
        public KnitStitch() : base()
        {
            StitchName = "Knit";
            Description = "Just a knit stitch";
            StitchKey = "K";
            StitchType = StitchType.Normal;
            Regex = new Regex(@"K\d",RegexOptions.IgnoreCase);
        }
    }
    public class PurlStitch : Stitch
    {
        public PurlStitch()
        {
            StitchName = "Knit"; StitchName = "Purl";
            StitchKey = "P";
            Description = "How are you using this chart if you don't know how to purl?";
            StitchType = StitchType.Normal;
            Regex = new Regex(@"P\d");
        }
    }
    public class YOStitch : Stitch
    {
        public YOStitch()
        {
            StitchKey = "YO";
            StitchName = "Yarn Over";
            Description = "Just drap the yarn over the needle once";
            StitchType = StitchType.Normal;
            Regex = new Regex(@"YO");
        }
    }
    public class K2GStitch : Stitch
    {
        public K2GStitch()
        {
            StitchName = "Knit 2 Together";
            StitchKey = "K2G";
            Description = "Make a knit stitch through two stitches at a time";
            StitchType = StitchType.Normal;
            Regex = new Regex(@"K2G\d");
        }
    }
    public class P2GStitch : Stitch
    {
        public P2GStitch()
        {
            Description = "Purl through two stitches at a time";
            StitchKey = "P2G";
            StitchName = "Purl 2 Together";
            StitchType = StitchType.Normal;
            Regex = new Regex(@"P2G\d");
        }
    }
    public class SSKStitch : Stitch
    {
        public SSKStitch()
        {
            StitchName = "Slip slip knit";
            StitchKey = "SSK";
            Description = "Slip two stitches purlwise; put stitches back on left needles; knit both stitches through the back loop";

            StitchType = StitchType.Normal;
            Regex = new Regex(@"SSK");
        }
    }
    public class SSPStitch : Stitch
    {
        public SSPStitch()
        {
            StitchName = "Slip slip purl";
            StitchKey = "SSP";
            Description = "Slip two stitches purlwise; put stitches back on left needle; purl 2 stitches through back loop";
            StitchType = StitchType.Normal;
            Regex = new Regex(@"SSP\d");
        }
    }
}
public enum StitchType
{
    Normal,
    Increase,
    Descrease
}

