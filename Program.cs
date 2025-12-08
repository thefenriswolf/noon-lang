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
//using System.CommandLine.Parsing;
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
        //https://learn.microsoft.com/en-us/dotnet/standard/commandline/get-started-tutorial
        Option<FileInfo> fileOption = new("--file") { Description = "Input file" };
        RootCommand rootCommand = new("Sample app for System.CommandLine");
        rootCommand.Options.Add(fileOption);
        rootCommand.SetAction(parseResult =>
        {
            FileInfo? parsedFile = parseResult.GetValue(fileOption);
            Console.WriteLine(parsedFile);
        });
        ParseResult parseResult = rootCommand.Parse(args);
        parseResult.Invoke();

        /// @todo read source file
        deployBackendCompiler("build");
        runBackendCompiler("build/test.ssa", "build/test.s", "test.bin");
    }
}
