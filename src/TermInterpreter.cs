using System;
using System.Collections.Generic;

namespace Term;
public static class TermInterpreter
{

    /**
        <summary>
            Interpret a TERM config file.
        </summary>
        <param name="path">
            The path to the file that will be interpreted.
        </param>
        <returns>
            A Dictionary containing the keys and values in the interpreted file.
        </returns>
    */
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
}
