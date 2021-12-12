class Day2 {
    public static void Part1(StreamReader sr) {
        List<string> validPasswords = new List<string>();
        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            string[] data = line.Split(" ");

            int[] limits = Program.StringArrayToInt(data[0].Split("-"));
            char ch = data[1][0];
            string password = data[2];

            int apperance = 0;
            foreach(char letter in password) {
                if(letter == ch) 
                    apperance++;
            }

            if(apperance >= limits[0] && apperance <= limits[1])
                validPasswords.Add(password);
        }

        Console.WriteLine(validPasswords.Count());
    }

    public static void Part2(StreamReader sr) {
        List<string> validPasswords = new List<string>();
        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            string[] data = line.Split(" ");

            int[] limits = Program.StringArrayToInt(data[0].Split("-"));
            char ch = data[1][0];
            string password = data[2];
            bool[] positions = new bool[2];

            positions[0] = password[limits[0] - 1] == ch;
            positions[1] = password[limits[1] - 1] == ch;

            if(positions[0] ^ positions[1])
                validPasswords.Add(password);
        }

        Console.WriteLine(validPasswords.Count());
    }
}