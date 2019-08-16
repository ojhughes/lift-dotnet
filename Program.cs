using System;
using System.Linq;
using ConsoleTables;
using Microsoft.Extensions.CommandLineUtils;

namespace lift_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.Name = "lift";
            app.OnExecute(() =>
            {
                Console.WriteLine("cloudlift.sh is a tool for enriching your application so it can be deployed to " +
                                  "multiple cloud platforms with minimal effort.");
                return 0;
            });
            app.Command("platform", (platformCommand) =>
            {
                platformCommand.Command("list", (platformListCommand) =>
                {
                    var table = new ConsoleTable("Name", "Alias", "Type", "Profile", "Description");
                    table.AddRow("gke_cf-sandbox-ohughes", "ci-build", "kubernetes", "qa", "Google Kubernetes Engine")
                        .AddRow("api.run.pivotal.io - FrameworksAndRuntimes/ohughes", "pws-ohughes", "cloudfoundry",
                            "prod", "Cloud Foundry version 2.138.0");

                    table.Write(Format.Alternative);
                });
            });
        }
    }
}