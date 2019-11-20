using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace KnittingChartWPF
{
    public static class PatternHelper
    {
        public static List<string> ParseFileToStringArray(FileInfo file)
        {
            List<string> rowDefinitions = new List<string>();
            using StreamReader sr = file.OpenText();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == "")
                {
                    continue;
                }
                rowDefinitions.Add(line);
            }
            return rowDefinitions;
        }

        public static string ParseLineToPatternRow(string line)
        {
            ///pattern = anything between a literal * and the last comma
            Regex rowPatternRegex = new Regex(@"\*(?<pattern>.*),");
            Match rowPatternMatch = rowPatternRegex.Match(line);
            string rowPatternValue = rowPatternMatch.Groups["pattern"].Value;
            string bracketRepeat = ParseBracketsFromPatternLine(rowPatternValue);
            if (bracketRepeat !=null )
            {
                return rowPatternValue.Replace(rowPatternValue, bracketRepeat);
            }
            else
            {
                return rowPatternValue;
            }
        }

        public static string ParseBracketsFromPatternLine(string patternRow)
        {
            List<string> results = new List<string>();

            ///bracket = subrepeats within row between brackets 
            ///count = the number of times racket is to be repeated
            Regex bracketRepeatRegex = new Regex(@"\[(?<bracket>.*)\]\s*(?<count>\d) times");
            Match bracketRepeatMatch = bracketRepeatRegex.Match(patternRow);
            var bracketPattern = bracketRepeatMatch.Groups["bracket"].Value;
            if (bracketRepeatMatch.Success)
            {
                var bracketRepeatCount = int.Parse(bracketRepeatMatch.Groups["count"].Value);

                StringBuilder sb = new StringBuilder(bracketPattern);

                for (int i = 0; i < bracketRepeatCount - 1; i++)
                {
                    sb.Append(", ");
                    sb.Append(bracketPattern);
                }
                var parsedResult = patternRow.Replace(bracketRepeatMatch.Value, sb.ToString());
                return parsedResult;
            }
            else
            {
                return null;
            }
        }
    }
}
//var repeated = sb.ToString();
//patternRow = patternRow.Replace(bracketRepeatMatch.Value, repeated);
//patternRow = Regex.Replace(patternRow, ",\\s+", ",");
//string[] stitches = patternRow.ToLower().Split(',');
//Regex stitchBreakdownRegex = new Regex(@"(?<stitch>\D)(?<pattern>\d*)");
//StringBuilder parsedRow = new StringBuilder();
//foreach (var item in stitches)
//{
//    Match breakdown = stitchBreakdownRegex.Match(item);
//    try
//    {
//        int count = int.Parse(breakdown.Groups["pattern"].Value);
//        for (int i = 0; i < count; i++)
//        {
//            parsedRow.Append(count);
//        }
//    }
//    catch (Exception e)
//    {
//        parsedRow.Append(breakdown.Groups["pattern"].Value);
//    }
//    string stitch = breakdown.Groups["stitch"].Value;
//}
//rowDefinitions.Add(parsedRow.ToString());
//rowDefinitions.Add(rowPattern);