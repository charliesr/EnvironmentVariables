using System;
using System.Management.Automation;
using System.IO;
using System.Reflection;

namespace EnvironmentVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            var script = string.Empty;
            try
            {
                script = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\EnvVar.ps1");
            }
            catch (FileNotFoundException notFound)
            {
                Console.WriteLine(notFound.Message);
            }

            try
            {
                using (PowerShell ps = PowerShell.Create())
                {
                    if (!string.IsNullOrEmpty(script))
                    {
                        ps.AddScript(script);
                        ps.Invoke();
                    }
                    else
                    {
                        throw new GetValueException("El contenido del script esta vacio");
                    }


                }
            }
            catch (GetValueException valueException)
            {
                Console.WriteLine(valueException.Message);
            }

            Console.WriteLine(Environment.GetEnvironmentVariable("ConnetionString", EnvironmentVariableTarget.User));
            Console.ReadLine();

        }
    }
}
