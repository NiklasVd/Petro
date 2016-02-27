using Petro.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetroExampleChat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            mainForm.FormClosing += OnFormClosing;

            Application.Run(mainForm);

            Debug.LogInformation($"Petro Example Chat\nBy Case-o-Matic\n\nUsing Petro Version {Properties.Resources.Version}");
            EvaluateCommandArgs();
        }

        private static void EvaluateCommandArgs()
        {
            var commandArgs = Environment.GetCommandLineArgs();
            foreach (var commandArg in commandArgs)
            {
                if (commandArg.Contains(@"C:\"))
                    continue; // Standard startup parameter can be ignored

                switch (commandArg)
                {
                    case "-ActivateLogging":
                        Debug.ActiveLogging = true;
                        Console.WriteLine("Activated active logging. Exceptions and errors are logged with the initial startup information wether or not this property is active.");
                        break;

                    case "-ActivateTelemetry":
                        Debug.ActiveTelemetry = true;
                        Console.WriteLine("Activated telemetry sending. Data includes hardware and application performance information that helps to improve Petro.");
                        break;

                    default:
                        Console.WriteLine($"The starting parameter \"{commandArg}\" is unknown.");
                        break;
                }
            }
        }

        private static void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.StoreLogMessages();
        }
    }
}
