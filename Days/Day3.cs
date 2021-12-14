class Day3 {
    public static void Part1(StreamReader sr) {
        List<Queue<char>> map = InputToList(sr);

        long trees = EvaluateSlope(3, 1, map);

        Console.WriteLine(trees);
    }

    public static void Part2(StreamReader sr) {
        List<Queue<char>> map = InputToList(sr);

        List<long> scores = new List<long>();

        scores.Add(EvaluateSlope(1, 1, map));
        scores.Add(EvaluateSlope(3, 1, map));
        scores.Add(EvaluateSlope(5, 1, map));
        scores.Add(EvaluateSlope(7, 1, map));
        scores.Add(EvaluateSlope(1, 2, map));

        long score = 1;
        scores.ForEach(x=> {
            Console.Write($" {x} *");
            score *= x;
        });


        Console.WriteLine($"\nEquals: {score}");
    }

    public static List<Queue<char>> InputToList(StreamReader sr) {
        List<Queue<char>> map = new List<Queue<char>>();

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            Queue<char> row = new Queue<char>();
            
            line.ToList().ForEach(x=>row.Enqueue(x));

            map.Add(row);
        }

        return map;
    }

    public static long EvaluateSlope(int x, int y, List<Queue<char>> map) {
        long trees = 0;
        map = CopyMap(map);

        for(int i = 0; i < map.Count(); i+= y) {
            if(map[i].Peek() == '#')
                trees++;

            map.ForEach(row=> {
                for (int i = 0; i < x; i++)
                {
                    row.Enqueue(row.Dequeue());
                }
            });
        }

        return trees;
    }

    public static List<Queue<char>> CopyMap(List<Queue<char>> original) {
        List<Queue<char>> copy = new List<Queue<char>>();

        original.ForEach(row=> {
            Queue<char> rowCopy = new Queue<char>();
            row.ToList().ForEach(item=>rowCopy.Enqueue(item));
            copy.Add(rowCopy);
        });

        return copy;
    }
}