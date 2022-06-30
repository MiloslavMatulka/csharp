using System;
using System.Diagnostics;

/// <summary>
/// Elevate starts a process elevated, command line utility
/// </summary>
public class Elevate {
    public static void Main(string[] args) {
        int i;
        bool isFileOptionDetected = false;
        int j;
        try {
            if (args == null || args.Length == 0 ||
                    (args[0] == "-h" && args.Length == 1)) {
                // Provide help
                Console.WriteLine(Help());
            }
            else {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                for (i = 0; i < args.Length - 1; ++i) {
                    if (args[i] == "-f") {
                        isFileOptionDetected = true;
                        // Provide filename of the program
                        startInfo.FileName = args[i + 1];
                        for (j = 0; j < args.Length - 1; ++j) {
                            if (args[j] == "-s") {
                                int style = Int32.Parse(args[j + 1]);
                                // Set window state of the program
                                switch (style) {
                                    case 0:
                                        startInfo.WindowStyle =
                                            ProcessWindowStyle.Normal;
                                        break;
                                    case 1:
                                        startInfo.WindowStyle =
                                            ProcessWindowStyle.Hidden;
                                        break;
                                    case 2:
                                        startInfo.WindowStyle =
                                            ProcessWindowStyle.Minimized;
                                        break;
                                    case 3:
                                        startInfo.WindowStyle =
                                            ProcessWindowStyle.Maximized;
                                        break;
                                    default:
                                        startInfo.WindowStyle =
                                            ProcessWindowStyle.Normal;
                                        break;
                                }
                            }
                        }
                        // Elevate the program
                        startInfo.Verb = "runas";
                        string parameters = "";
                        for (j = i; j < args.Length - 2; ++j) {
                            // Gather parameters of the program
                            parameters += args[j + 2] + " ";
                        }
                        startInfo.Arguments = parameters;
                        Process process = Process.Start(startInfo);
                        for (j = 0; j < args.Length; ++j) {
                            if (args[j] == "-w") {
                                // Wait for the process to finish
                                process.WaitForExit();
                            }
                        }
                    }
                }
                // Invalid arguments
                if (!isFileOptionDetected) {
                    Console.WriteLine("Error: Invalid arguments combination." +
                        Environment.NewLine + Environment.NewLine + Help());
                }
                else {
                    // Provide help if required within the process
                    for (i = 0; i < args.Length; ++i) {
                        if (args[i] == "-h") {
                            Console.WriteLine(Help());
                        }
                    }
                }
            }
        } catch (Exception e) {
            // Handle errors
            Console.WriteLine("Error: " + e.Message + Environment.NewLine +
                Environment.NewLine + Help());
        }
    }

    /// <summary>Help</summary>
    /// <returns>A string representing help.</returns>
    public static string Help() {
        string help =
            "Elevate starts a process elevated (\"As Administrator\")." +
            Environment.NewLine + "Command line utility." +
            Environment.NewLine + Environment.NewLine +
            "Usage:" + Environment.NewLine +
            "    Elevate [-h] [-w] [-s state] [-f [path\\]filename]" +
            " [a1 [a2...]]" +
            Environment.NewLine +  Environment.NewLine +
            "Options: " + Environment.NewLine +
            "    -h                  Provides help." + Environment.NewLine +
            "    -w                  Waits for the process to finish before" +
            Environment.NewLine +
            "                        returning." +
            Environment.NewLine +
            "    -s state            Defines the window state of the program" +
            Environment.NewLine +
            "                        being launched (0=Normal, 1=Hidden," +
            Environment.NewLine +
            "                        2=Minimized, 3=Maximized)." +
            Environment.NewLine +
            "    -f [path\\]filename  Defines the filename of the program" +
            Environment.NewLine +
            "                        to launch elevated." +
            Environment.NewLine +
            "    a1 [a2...]          Defines optional arguments expected by" +
            Environment.NewLine +
            "                        the program being launched." +
            Environment.NewLine + Environment.NewLine +
            "Notes:" +
            Environment.NewLine +
            "    Keep options in the given order.";
        return help;
    }
}
