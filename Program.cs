using System.Diagnostics;
using System.Text;

List<string> stations = File.ReadAllLines("stations.txt").ToList();
//Stations with substring 'station':
List<string> StationsThatContainWordStation(List<string> Stations)
{
    List<string> names = [];
    foreach (string line in Stations){ if (line.Contains("Station")) names.Add(line); }
    return names;
}
//foreach (string line in StationsThatContainWordStation(stations)) Console.WriteLine(line);

List<string> StationsThatDontShareLettersWithAWord(List<string> Stations, string word)
{
    List<string> names = [];
    foreach (string Line in Stations)
    {
        string line = Line.ToLower();
        bool b = true;
            foreach (char c in word)
            {
                if (line.Contains(c)) { b = false; }
            }
        if (b) names.Add(line);
        }
    return names;
}
List<string> Words = ["Mackerel", "Piranha", "Sturgeon", "Bacteria"];
//foreach (string word in Words) { Console.WriteLine($"stations that dont share letters with '{word}'"); foreach (string line in StationsThatDontShareLettersWithAWord(stations, word)) Console.WriteLine(line); }

List<string> SameLetterWordStations(List<string> Stations)
{
    List<string> names = [];
    foreach (string line in Stations) 
    {
        List<char> starts = [];
        foreach (char c in line){if (char.IsUpper(c)) starts.Add(c);}
        if (starts.Count() != starts.Distinct().Count()) names.Add(line);
    }
    return names;
}
//foreach (string line in SameLetterWordStations(stations)) Console.WriteLine(line);

string LineWithMostStations(List<string> Stations)
{
    Dictionary<string,int> LinesVals = new Dictionary<string, int> { };
    foreach (string Stop in Stations)
    {
        List<string> lines = Stop.Split(", ").ToList();
        lines.RemoveAt(0);
        foreach (string line in lines)
        {
            if (LinesVals.ContainsKey(line))

                LinesVals[line] += 1;
            else
                LinesVals[line] = 1;
        }
    }
    string highest = LinesVals.MaxBy(kvp => kvp.Value).Key;
    return highest;
}
Console.WriteLine(LineWithMostStations(stations));















//ReadingFromTextFiles();

//WritingToTextFiles();
static void WritingToTextFiles()
{
    // as we know, the stringbuilder is more efficient that using the + to join strings together 
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("line 1");
    int x = 2;
    sb.Append($"line {x}");

    // option 1 - dump it out all in one go
    File.WriteAllText("outputfile.txt", sb.ToString());

    // the "." path is the current directory, ".." is the parent 
    // this could be an absolute path 
    string docPath = ".";
    List<string> lines = new List<string> { "some", "text", "to", "add", "one item per line" };

    // an alternative use for 'using' - this deals with closing nicely 
    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "writeLines.txt")))
    {
        foreach (string line in lines)
            outputFile.WriteLine(line);
    }

    // an alternative place            
    docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    // NB - getting the Downloads folder, for example, is hard. 
    // https://stackoverflow.com/questions/10667012/getting-downloads-folder-in-c
}

static void ReadingFromTextFiles()
{
    // NB - this is local to where you are running, so F5/Run will be different. 
    // Best to copy to bin/Debug/.net{v.0} if you want to Debug 

    // option 1 - grab it all 
    string s = File.ReadAllText("textfile.txt");
    Console.WriteLine(s);

    List<string> lines = File.ReadAllLines("textfile.txt").ToList();



    // option 2 - line by line - note the use of using here 
    using (StreamReader sr = new StreamReader("textfile.txt"))
    {


        // Read the stream to a string, and write the string to the console.
        String line = sr.ReadToEnd();
        Console.WriteLine(line);

    }
    
}