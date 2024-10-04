namespace testcmd;

using System;
using System.Diagnostics;

public class ProjectService
{

    public string CreateProject(string templatePath, string destinationPath)
    {
        var processInfo = new ProcessStartInfo("dotnet", $"new {templatePath} -o {destinationPath} --force")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (var process = new System.Diagnostics.Process { StartInfo = processInfo })
        {
            process.Start();
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (process.ExitCode != 0)
            {
                throw new Exception($"Error creating project: {error}");
            }
        }

        return destinationPath;
    }

    public string ZipProject(string sourcePath, string zipPath)
    {
        if (File.Exists(zipPath))
        {
            File.Delete(zipPath);
        }

        System.IO.Compression.ZipFile.CreateFromDirectory(sourcePath, zipPath);
        return zipPath;
    }

    //public void CreateProject(string templatePath, string destinationPath)
    //{
    //    var processInfo = new ProcessStartInfo("dotnet", $"new {templatePath} -o {destinationPath} --force")
    //    {
    //        RedirectStandardOutput = true,
    //        RedirectStandardError = true,
    //        UseShellExecute = false,
    //        CreateNoWindow = true
    //    };

    //    using (var process = new System.Diagnostics.Process { StartInfo = processInfo })
    //    {
    //        process.Start();
    //        process.WaitForExit();

    //        string output = process.StandardOutput.ReadToEnd();
    //        string error = process.StandardError.ReadToEnd();

    //        if (process.ExitCode != 0)
    //        {
    //            throw new Exception($"Error creating project: {error}");
    //        }
    //    }
    //}
}
