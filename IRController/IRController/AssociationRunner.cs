using System;
using System.Diagnostics;

/// <summary>
/// Summary description for Class1
/// </summary>
public class AssociationRunner
{
    private const string SCRIPT_PATH = "\\AssoRules\\asso.py";
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
        runCommand = "/C python " + SCRIPT_PATH + " " + inputPath + " " + outputPath;
    }

    public void execute()
    {
        Process process = new System.Diagnostics.Process();
        ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

       // startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = runCommand;

        process.StartInfo = startInfo;
        process.Start();
    }
}
