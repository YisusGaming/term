using System;
using System.Collections.Generic;

namespace Term;
public static class TermInterpreter
{

    /// <summary>
    ///     Interpret a TERM config file.
    /// </summary>
    /// <param name="path">
    ///    The path to the file that will be interpreted.
    /// </param>
    /// <returns>
    ///    A Dictionary containing the keys and values in the interpreted file.
    /// </returns>
    public static Dictionary<string, string> Interpret(string path)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        
        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            string[] property;
            if (line.StartsWith('#') || line == "") { continue; /* Ignores the line if it starts with an # or if it's empty. */ }

            property = line.Split("->");
            if (property[0] != null && property[1] != null)
            {
                result.TryAdd(property[0].Trim(), property[1].Trim());
            }
        }
        return result;
    }

    public static void WriteToFile(string path, Dictionary<string, string> termContent, bool replaceContent = true)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File " + path + " does not exist.");
        }

        string fileContent = File.ReadAllText(path);
        string newData = "";

        foreach (string key in termContent.Keys)
        {
            string keyFormat = key.Trim().ToLower().Replace(' ', '_');

            newData += keyFormat + " -> " + termContent[key] + "\n";
        }

        if (replaceContent)
        {
            File.WriteAllText(path, newData, System.Text.Encoding.UTF8);
        } 
        else
        {
            File.AppendAllText(path, "\n\n# Written from C#:\n" + newData, System.Text.Encoding.UTF8);
        }
    }
}
