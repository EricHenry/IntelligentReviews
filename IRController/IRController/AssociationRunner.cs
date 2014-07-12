using System;
using System.Diagnostics;
using System.Windows.Forms;

/// <summary>
/// Summary description for Class1
/// </summary>
public class AssociationRunner
{
    //Location of the python script within the project folder
    private const string SCRIPT_PATH = "AssoRules\\asso.py";

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
        
        //change directory to IRController to run appropriate files
        runCommand = "/C cd.. & cd.. & ";
        
        //full python command 
        runCommand += "AssoRules\\python.exe \"" + SCRIPT_PATH + "\" \"" + inputPath + "\" \"" + outputPath;
    }

    public void execute()
    {
        //craete a process and its starting info
        Process process = new System.Diagnostics.Process();
        ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

        //hide cmd
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        //run the command prompt
        startInfo.FileName ="cmd.exe";

        //feed arguements to cmd
        startInfo.Arguments = runCommand;

        //give the process the info to run and start
        process.StartInfo = startInfo;
        process.Start();
    }
}
