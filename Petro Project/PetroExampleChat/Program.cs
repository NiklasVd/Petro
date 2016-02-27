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
            Application.Run(mainForm);

            mainForm.FormClosing += OnFormClosing;
        }

        private static void EvaluateCommandArgs()
        {
            var commandArgs = Environment.GetCommandLineArgs();
            foreach (var commandArg in commandArgs)
            {
                switch (commandArg)
                {
                    case "-DeactivateLogging":
                        Debug.ActiveLogging = false;
                        Console.WriteLine("Deactivated active logging. Exceptions and errors are still logged with the initial startup information.");
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
