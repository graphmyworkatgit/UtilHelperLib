using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;

namespace UtilHelper.Core
{
    public class LaunchProgram

    {
        public static IEnumerable<String> KillPRocesses(params string[] processNames)
        {
            HashSet<String> pset = new HashSet<string>();
            IList<String> psalive = new List<String>();
            Process[] processes = Process.GetProcesses();

            foreach(var pname in processNames)
            {
                pset.Add(pname);
            }

            foreach(var ps in processes)
            {
                if(pset.Contains(ps.ProcessName))
                {
                    try
                    {
                        ps.Kill();
                    }
                    catch
                    {
                        psalive.Add(ps.ProcessName);
                    }
                }
            }
            return psalive;
        }

        public void KillAnProcess(string processName)
        {
            foreach(var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
            if(Process.GetProcessesByName(processName).Length > 0)
            {
                KillAnProcess(processName);
            }
        }

        public Dictionary<string, StringBuilder> RunProcess(string RunString, string ProcessPath)
        {
            Dictionary<string, StringBuilder> returnArg =
                new Dictionary<string, StringBuilder>();

            StringBuilder sb = new StringBuilder();
            try
            {
                var psiProcess = new ProcessStartInfo
                {
                    FileName = "cmd",
                    WorkingDirectory = @"c:\",
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };
                var pNpmRun = Process.Start(psiProcess);
                Debug.WriteLine(RunString);
                pNpmRun.StandardInput.WriteLine(RunString);
                pNpmRun.StandardInput.WriteLine("exit \"%ERRORLEVEL%\"");

                sb.Append(pNpmRun.StandardOutput.Read());
                returnArg.Add("output", sb);
                sb.Clear();

                var tenMin = 3 * 60 * 1000;
                if(pNpmRun.WaitForExit(tenMin))
                {
                    returnArg.Add("exitcode", sb.Append(pNpmRun.ExitCode.ToString()));
                    Debug.WriteLine($"ExitCode from Npm = '{pNpmRun.ExitCode.ToString()}'");
                    return returnArg;
                }
                else
                {
                    pNpmRun.Kill();
                    throw new TimeoutException("Command did not complete in 10mints");
                }

            }catch(Exception e)
            {
                throw new Exception($"Error '{e.Message}' for incoming" +
                    $"command '{RunString}' in Launch Program");
            }
            
        }
    }
}
