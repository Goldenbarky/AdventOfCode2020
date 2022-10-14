using System.Diagnostics;

class Day15 {
    public const int Part1End = 30000000;
    public static void Part1(StreamReader sr) {
        var timer = new Stopwatch();

        timer.Start();

        (Dictionary<int, int> intMap, int lastNum) = ReadInput(sr);
        int startingNumsNum = intMap.Keys.Count;

        for(int i = startingNumsNum + 1; i < Part1End; i++) {
            int nextNum = (intMap.ContainsKey(lastNum)) ? i - 1 - intMap[lastNum] : 0;

            //Console.Write(nextNum + ", ");

            intMap[lastNum] = i - 1;

            lastNum = nextNum;
            //if(i % 300000 == 0) Console.WriteLine("Still workin' boss! I'm at " + ((double) i / Part1End) * 100 + "%!!");
        }

        Console.WriteLine();
        Console.WriteLine(lastNum + " is the " + Part1End + "th number spoken");

        timer.Stop();
        Console.WriteLine("I did it boss! In only " + timer.Elapsed.TotalSeconds + " seconds too!");
    }

    public static (Dictionary<int, int>, int) ReadInput(StreamReader sr) {
        string line = sr.ReadLine();
        List<string> input = line.Split(",").ToList();
        Dictionary<int, int> intMap = new();

        for(int i = 0; i < input.Count - 1; i++) {
            intMap.Add(int.Parse(input[i]), i);
            //Console.Write(input[i] + ", ");
        }

        //Console.Write(input.Last() + ", ");

        return (intMap, int.Parse(input.Last()));
    }
}