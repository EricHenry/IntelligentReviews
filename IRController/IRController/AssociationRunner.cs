using System;
using System.Diagnostics;

/// <summary>
/// Summary description for Class1
/// </summary>
public class AssociationRunner
{
    private const string SCRIPT_PATH = "C:\\Users\\Eric\\Documents\\GitHub\\IntelligentReviews\\IRController\\IRController\\AssoRules\\asso.py";
    private string inputPath;
    private string outputPath;
    private int maxAssociationOutput;
    private string runCommand;

    public AssociationRunner(string iPath, string oPath, int max)
	{

        inputPath = iPath;
        outputPath = oPath;
        maxAssociationOutput = max;
	}

    public AssociationRunner(string iPath, string oPath)
    {
        inputPath = iPath;
        outputPath = oPath;
        //maxAssociationOutput = 100;
        runCommand = "/C " + SCRIPT_PATH + " " + inputPath + " " + outputPath;
    }

    public void execute()
    {
        Process process = new System.Diagnostics.Process();
        ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

       // startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "C:\\Python27\\python.exe";
        startInfo.Arguments = runCommand;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;

        process.StartInfo = startInfo;
         process.Start();
    }
}
