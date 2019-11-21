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

            Regex rowMeatRegex = new Regex(@"\*(?<rowMeat>.*),");
            Regex bracketedBitRegex = new Regex(@"\[(?<bracketedBit>.*)\]\s*(?<count>\d) times");

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
                    line = line.ToLower();
                    #region Extract important content from line
                    var rowMeat = rowMeatRegex.Match(line).Groups["rowMeat"].Value;
                    var bracketRepeatPattern = bracketedBitRegex.Match(rowMeat);
                    if (bracketRepeatPattern.Success)
                    {
                        var bracketedBit = bracketRepeatPattern.Groups["bracketedBit"].Value;
                        var bracketRepeatCount = int.Parse(bracketRepeatPattern.Groups["count"].Value);

                        StringBuilder rowStringBuilder = new StringBuilder(bracketedBit);

                        for (int i = 0; i < bracketRepeatCount - 1; i++)
                        {
                            rowStringBuilder.Append(", ");
                            rowStringBuilder.Append(bracketedBit);
                        }

                        var rowString = rowStringBuilder.ToString();
                        rowMeat = rowMeat.Replace(bracketRepeatPattern.Value, rowString);
                    }
                    rowMeat = Regex.Replace(rowMeat, ",\\s+", ",");
                    #endregion
                    #region clean line
                    string[] stitches = rowMeat.ToLower().Split(',');
                    Regex stitchSetRegex = new Regex(@"(?<stitch>\D)(?<pattern>\d*)");
                    Regex enumeratedStitchSet = new Regex(@"\D\d+\b");
                    StringBuilder parsedRow = new StringBuilder();
                    foreach (var item in stitches)
                    {
                        Match breakdown = stitchSetRegex.Match(item);
                        Match breakdown2 = enumeratedStitchSet.Match(item);
                        if (breakdown2.Success)
                        {
                            int count = int.Parse(breakdown.Groups["pattern"].Value);
                            string stitch = breakdown.Groups["stitch"].Value;
                                for (int i = 0; i < count; i++)
                                {
                                    parsedRow.Append(stitch+",");
                                }
                        }
                        else
                        {
                            parsedRow.Append(item+",");
                        }
                    }
                    rowDefinitions.Add(parsedRow.ToString());
                }

            }
            foreach (var item in rowDefinitions)
            {
                Console.WriteLine(item);
            }
        }
    }
}
#endregion