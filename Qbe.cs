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


namespace noonLang;

/// <summary>
/// QBE Backend Compiler
/// </summary>
internal sealed class Qbe
{
    /*
      /// <summary>
      /// The Search method takes a series of parameters to specify the search criterion
      /// and returns a dataset containing the result set.
      /// </summary>
      /// <param name="connectionString">the connection string to connect to the
      /// database holding the content to search</param>
      /// <param name="maxRows">The maximum number of rows to
      /// return in the result set</param>
      /// <param name="searchString">The text that we are searching for</param>
      /// <returns>A DataSet instance containing the matching rows. It contains a maximum
      /// number of rows specified by the maxRows parameter</returns>
      public int Search(string connectionString, int maxRows, int searchString)
      {
          return 12;
      }
  */
    static private string qbePath = "";

    /// <summary>
    /// Deploys QBE binary to specified directory
    /// </summary>
    /// <param name="targetDir">Target directory for the QBE compiler</param>
    public static void deployBackendCompiler(string targetDir)
    {
        var names = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
        var resource = System
            .Reflection.Assembly.GetExecutingAssembly()
            .GetManifestResourceStream(names[0]);
        var target = targetDir + "/" + "qbe.exe";
        System.IO.Directory.CreateDirectory(targetDir);
        Qbe.qbePath = target;
        if (resource != null)
        {
            using (
                var file = new System.IO.FileStream(target, FileMode.Create, FileAccess.Write)
            )
            {
                resource.CopyTo(file);
            }
            if (OperatingSystem.IsLinux())
            {
                System.IO.File.SetUnixFileMode(
                    target,
                    UnixFileMode.UserExecute
                        | UnixFileMode.UserRead
                        | UnixFileMode.UserWrite
                        | UnixFileMode.OtherExecute
                        | UnixFileMode.OtherRead
                        | UnixFileMode.OtherWrite
                        | UnixFileMode.GroupExecute
                        | UnixFileMode.GroupRead
                        | UnixFileMode.GroupWrite
                );
            }
        }
    }

    /// <summary>
    /// Run QBE on generated QBE IL file and output assembly
    /// </summary>
    /// <param name="sourceFile">Source directory of the QBE IL file</param>
    /// <param name="targetASMFile">Target directory for the generated assembly file</param>
    /// <param name="targetBinFile">Target directory of the generated binary file</param>
    public static void runBackendCompiler(string sourceFile, string targetASMFile, string targetBinFile)
    {
        var qbeParams = "-o " + targetASMFile + " " + sourceFile;
        System.Diagnostics.Process.Start(Qbe.qbePath, qbeParams);
        var ccParams = "-o " + targetBinFile + " " + targetASMFile;
        System.Diagnostics.Process.Start("cc", ccParams);
    }
}
