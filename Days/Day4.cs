using System.Text.RegularExpressions;

class Day4 {

    public static readonly string[] Fields = new string[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
    public static void Part1(StreamReader sr) {
        List<Dictionary<string, string>> passports = new();
        Dictionary<string, string> currPassport = new();

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            if(line.Trim() == "") {
                passports.Add(currPassport);
                currPassport = new();
                continue;
            }

            string[] fields = line.Split(" ");
            foreach(string field in fields) {
                string[] pair = field.Split(":");
                if(pair[0] != "cid") currPassport.Add(pair[0], pair[1]);
            }
        }
        passports.Add(currPassport);

        int validPassports = 0;

        foreach(Dictionary<string, string> passport in passports) {
            if(passport.Keys.Count >= 7) validPassports++;
        }

        Console.WriteLine(validPassports);
    }

    public static void Part2(StreamReader sr) {
        List<Dictionary<string, string>> passports = new();
        Dictionary<string, string> currPassport = new();

        for(string line = sr.ReadLine(); line != null; line = sr.ReadLine()) {
            if(line.Trim() == "") {
                passports.Add(currPassport);
                currPassport = new();
                continue;
            }
            
            string[] fields = line.Split(" ");
            foreach(string field in fields) {
                string[] pair = field.Split(":");
                if(pair[0] != "cid") currPassport.Add(pair[0], pair[1]);
            }
        }
        passports.Add(currPassport);

        int validPassports = 0;

        foreach(Dictionary<string, string> passport in passports) {
            if(IsValid(passport)) validPassports++;
        }

        Console.WriteLine(validPassports);
    }

    public static bool IsValid(Dictionary<string, string> passport) {
        foreach(string field in Fields) {
            if(!passport.ContainsKey(field)) return false;

            string value = passport[field];
            int numValue = 0;
            int.TryParse(value, System.Globalization.NumberStyles.Integer, null, out numValue);
            switch(field) {
                case "byr":
                    if(value.Length != 4 || numValue < 1920 || numValue > 2002) return false;
                    break;
                case "iyr":
                    if(value.Length != 4 || numValue < 2010 || numValue > 2020) return false;
                    break;
                case "eyr":
                    if(value.Length != 4 || numValue < 2020 || numValue > 2030) return false;
                    break;
                case "hgt":
                    Match match = Regex.Match(value, "(?<hgt>\\d+)(?<unit>cm|in)");
                    if(!match.Success) return false;
                    numValue = int.Parse(match.Groups["hgt"].ToString());
                    if(!((match.Groups["unit"].ToString() == "cm" && numValue >= 150 && numValue <= 193) || (match.Groups["unit"].ToString() == "in" && numValue >= 59 && numValue <= 76))) return false;
                    break;
                case "hcl":
                    if(!Regex.Match(value, "#[a-f0-9]{6}").Success) return false;
                    break;
                case "ecl":
                    if(!new string[]{"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(value)) return false;
                    break;
                case "pid":
                    if(!Regex.Match(value, "\\d{9}").Success) return false;
                    if(value.Length != 9) return false;
                    break;
                default: 
                    return false;
            }
        }

        return true;
    }
}