/*
    noon-lang compiler
    Copyright (C) 2025 Stefan Rohrbacher

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.CommandLine;
using System.CommandLine.Parsing;
using static noonLang.Qbe;

namespace noonLang;

/// <summary>
/// Main Program
/// </summary>
internal static class Program
{
    /// <summary>
    /// Program entry point
    /// </summary>
    private static void Main(string[] args)
    {
        parseArgs(args);
    }

    static void parseArgs(string[] args)
    {
        //https://learn.microsoft.com/en-us/dotnet/standard/commandline/get-started-tutorial
        Option<FileInfo> inputFile = new("--file", "-f")
        {
            Description = "Input file",
            Required = true,
        };
        Option<string> outputFile = new("--output", "-o")
        {
            Description = "Output file",
            Required = false,
        };
        RootCommand rootCommand = new("noon-lang compiler");
        rootCommand.Options.Add(inputFile);
        rootCommand.Options.Add(outputFile);
        rootCommand.SetAction(parseResult =>
        {
            FileInfo? inFile = parseResult.GetValue(inputFile);
            string IF = "";
            if (inFile is not null)
            {
                IF = inFile.ToString();
            }
            string outFile = parseResult.GetValue(outputFile) ?? "a.out";
            /// @todo read source file
            deployBackendCompiler("build");
            runBackendCompiler(IF, outFile);
        });
        ParseResult parseResult = rootCommand.Parse(args);
        parseResult.Invoke();
    }
}
