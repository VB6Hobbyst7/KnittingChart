using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using KnittingChartWPF;

namespace ParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternPath = @"C:\Users\linma\source\repos\KnittingChart\ParserConsole\TravelingCableHat.txt";

            KnitStitch knit = new KnitStitch();

            FileInfo file = new FileInfo(patternPath);
            List<string> patternRows = PatternHelper.ParseFileToStringArray(file);
            foreach (string item in patternRows)
            {
                string patternLine = PatternHelper.ParseLineToPatternRow(item);
                var stitches = patternLine.Split(',');
                MatchCollection purlMatches = knit.Regex.Matches(patternLine);
                //MatchCollection knitMatches = knitID.Matches(patternLine);
            }
        }
    }
}
