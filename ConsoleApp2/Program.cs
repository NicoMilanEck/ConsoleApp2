using System;
using System.Globalization;
using System.IO;
using System.Timers;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

class Program
{

    public static void Main(String[] args)
    {

        string fileName = @"C:\Users\nicoe\source\repos\ConsoleApp2\ConsoleApp2\Input\3.in";
        using (StreamReader sr = File.OpenText(fileName))



        {
            string[] lines = File.ReadAllLines(fileName);


            string[] stats = lines[0].Split(" ");


            IDictionary<int, List<TimeSpan>> Runs = new Dictionary<int, List<TimeSpan>>();

            int[] statsInt = Array.ConvertAll(stats, int.Parse);

            int lapIndex = statsInt[0];
            int minLaps = statsInt[1];
            int runnerNumber = statsInt[2];

            lines = lines.Skip(1).ToArray();

            List<string> laps = new List<string>();


            foreach (string line in lines)
            {
                string[] runnerAndTime = line.Split(" ");
                TimeSpan time = TimeSpan.Parse("0:0:" + runnerAndTime[1].Replace(".", ":"));


                int tempI = Int32.Parse(runnerAndTime[0]);

                if (Runs.ContainsKey(tempI))
                {

                    Runs[tempI].Add(time);
                }
                else
                {

                    List<TimeSpan> tempList = new List<TimeSpan>();
                    tempList.Add(time);
                    Runs.Add(tempI, tempList);
                }



            }
            IDictionary<int, TimeSpan> rankings = new Dictionary<int, TimeSpan>();


            foreach (KeyValuePair<int, List<TimeSpan>> entry in Runs)
            {

                if (entry.Value.Count == minLaps) { 

                TimeSpan ts1 = new TimeSpan();

                foreach (TimeSpan timeSpan in entry.Value)
                {
                    ts1 = ts1.Add(timeSpan);
                }

                rankings.Add(entry.Key, ts1);
                }

            }

            var sortedRankings = rankings.OrderBy(entry => entry.Value).ThenBy(entry => entry.Key).ToList();

            foreach (KeyValuePair<int, TimeSpan> ranking in sortedRankings)
            {
                Console.WriteLine(ranking.Key.ToString(), ranking.Value.ToString());
            }

        }











    }




}
