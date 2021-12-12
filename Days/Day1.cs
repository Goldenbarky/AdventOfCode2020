class Day1 {
    public static void Part1(StreamReader sr) {
        List<string> input = new List<string>();
        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            input.Add(line);
        }

        int[] taxes = Program.StringArrayToInt(input.ToArray());

        int answer = -1;
        for(int i = 0; i < taxes.Count(); i++) {
            for(int j = i+1; j < taxes.Count(); j++) {
                if(taxes[i] + taxes[j] == 2020) {
                    answer = taxes[i] * taxes[j];
                    goto End;
                }
            }
        }
        End:

        Console.WriteLine(answer);
    }

    public static void Part2(StreamReader sr) {
        List<string> input = new List<string>();
        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            input.Add(line);
        }

        int[] taxes = Program.StringArrayToInt(input.ToArray());

        int answer = -1;
        for(int i = 0; i < taxes.Count(); i++) {
            for(int j = i+1; j < taxes.Count(); j++) {
                for(int k = j+1; k < taxes.Count(); k++) {
                    if(taxes[i] + taxes[j] + taxes[k] == 2020) {
                        answer = taxes[i] * taxes[j] * taxes[k];
                        goto End;
                    }
                }
            }
        }
        End:

        Console.WriteLine(answer);
    }
}