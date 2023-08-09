using System.IO;
using System.Collections.Generic;
using TermLib;
using System;

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
    /// <exception cref="FileNotFoundException">
    ///     Thrown when the file specified by <paramref name="path"/>
    ///     is not found.
    /// </exception>
    public static Dictionary<string, string> Interpret(string path)
    {

        if (!File.Exists(path)) {
            throw new FileNotFoundException("File " + path + " does not exist.");
        }

        Dictionary<string, string> result = new();
        
        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            string[] property;
            if (line.StartsWith('#') || line == "") { continue; /* Ignores the line if it starts with an # or if it's empty. */ }

            property = line.Split("->");
            if (property[0] != null && property[1] != null)
            {
                float? arithmeticResult  = TermMaths.RunArithmetics(property[1]);
                result.TryAdd(property[0].Trim(), arithmeticResult.ToString() ?? property[1].Trim());
            }
        }
        return result;
    }

    /// <summary>
    ///     Writes a <see langword="dictionary"/> into a term file.
    ///     <br/>
    ///     It automatically generates <see langword="Term configs" /> 
    ///     based on the dictionary provided.
    ///     <br/>
    ///     The method will also format correctly any key in
    ///     the dictionary.
    ///     So if the dictionary contains a key named
    ///     "<see langword="My Key" />" it will be formatted to 
    ///     "<see langword="my_key" />" before writing
    ///     it to the file.
    /// </summary>
    /// <param name="path">
    ///     The path to the term file to write into.
    /// </param>
    /// <param name="termContent">
    ///     The content that will be written in the file.
    /// </param>
    /// <param name="replaceContent">
    ///     If <see langword="true"/>, replace all the contents in
    ///     the term file.
    ///     <br/>
    ///     if <see langword="false"/>, append all the contents to
    ///     the end of the file with a comment
    ///     "<see langword="# Written from C#: " />"
    /// </param>
    /// <exception cref="FileNotFoundException">
    ///     Thrown when the file specified by <paramref name="path"/>
    ///     is not found.
    /// </exception>
    public static void WriteToFile(string path, Dictionary<string, string> termContent, bool replaceContent = true)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File " + path + " does not exist.");
        }

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
