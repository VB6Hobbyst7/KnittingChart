using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternPath = @"C:\Users\linma\source\repos\KnittingChart\ParserConsole\TravelingCableHat.txt";
            FileInfo file = new FileInfo(patternPath);

            Regex rowPatternRegex = new Regex(@"\*(?<pattern>.*),");
            Regex bracketRepeatRegex = new Regex(@"\[(?<bracket>.*)\]\s*(?<count>\d) times");

            List<string> rowDefinitions = new List<string>();

            using (StreamReader sr = file.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        continue;
                    }

                    var rowPattern = rowPatternRegex.Match(line).Groups["pattern"].Value;


                    var bracketRepeatPattern = bracketRepeatRegex.Match(rowPattern);
                    if (bracketRepeatPattern.Success)
                    {
                        var bracketPattern = bracketRepeatPattern.Groups["bracket"].Value;
                        var bracketRepeatCount = int.Parse(bracketRepeatPattern.Groups["count"].Value);

                        StringBuilder sb = new StringBuilder(bracketPattern);
                        
                        for (int i = 0; i < bracketRepeatCount - 1; i++)
                        {
                            sb.Append(", ");
                            sb.Append(bracketPattern);
                        }

                        var repeated = sb.ToString();
                        rowPattern = rowPattern.Replace(bracketRepeatPattern.Value, repeated);
                        rowPattern = Regex.Replace(rowPattern, ",\\s+", ",");
                    }
                    rowPattern.ToLower();
                    string[] stitches = rowPattern.ToLower().Split(',');
                    Regex stitchBreakdownRegex = new Regex(@"(?<stitch>\D)(?<pattern>\d*)");
                    StringBuilder parsedRow = new StringBuilder();
                    foreach (var item in stitches)
                    {
                        Match breakdown = stitchBreakdownRegex.Match(item);
                        try
                        {
                            int count = int.Parse(breakdown.Groups["pattern"].Value);
                                for (int i = 0; i < count; i++)
                                {
                                    parsedRow.Append(count);
                                }
                        }
                        catch (Exception e)
                        {
                            parsedRow.Append(breakdown.Groups["pattern"].Value);
                        }
                        string stitch = breakdown.Groups["stitch"].Value;
                    }
                    rowDefinitions.Add(parsedRow.ToString());
                    rowDefinitions.Add(rowPattern);
                }

            }
            foreach (var item in rowDefinitions)
            {
                Console.WriteLine(item);
            }
        }
    }
}
