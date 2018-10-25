using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestoned.DataModel.Gdle;
using Newtonsoft.Json;
using DfWeenie = Lifestoned.DataModel.DerethForever.Weenie;
using DfWeenieChange = Lifestoned.DataModel.DerethForever.WeenieChange;

namespace Lifestoned.WeenieMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            // original DF directory that has both /weenies and /sandboxes
            string src = @"C:\dev\behemoth\Lifestoned-DF-Server-Data";

            // output new gdle directory
            string dst = @"C:\dev\behemoth\Lifestoned-GDLE-Server-Data";

            var sourceFiles = Directory.EnumerateFiles(src + "\\weenies");
            string weenieOutput = dst + @"\weenies";

            if (!Directory.Exists(weenieOutput))
                Directory.CreateDirectory(weenieOutput);

            int weenieMigrations = 0;
            int weenieFails = 0;
            Stopwatch repoMigration = new Stopwatch();
            repoMigration.Start();

            foreach (string sourceFile in sourceFiles)
            {
                string content = File.ReadAllText(sourceFile);
                DfWeenie dfWeenie = JsonConvert.DeserializeObject<DfWeenie>(content);

                Console.WriteLine($"Migrating {dfWeenie.WeenieClassId}, {dfWeenie.Name}...");

                if (dfWeenie.IntProperties?.FirstOrDefault(i => i.IntPropertyId == 9007) == null)
                {
                    Console.WriteLine("... is not possible - missing Weenie Type.");
                    continue;
                }

                try
                {
                    Weenie gdleWeenie = Weenie.ConvertFromWeenie(dfWeenie);
                    string migrated = JsonConvert.SerializeObject(gdleWeenie);
                    File.WriteAllText(Path.Combine(weenieOutput, gdleWeenie.WeenieClassId + ".json"), migrated);

                    weenieMigrations++;
                    Console.WriteLine($"... done.");
                }
                catch (Exception ex)
                {
                    weenieFails++;
                    Console.WriteLine($"... failed.");
                }
            }
            repoMigration.Stop();

            int sandboxMigrations = 0;
            int sandboxWeenies = 0;
            int sandboxWeenieFails = 0;
            Stopwatch sandboxMigration = new Stopwatch();

            string tmp = Path.Combine(dst, "sandboxes");
            if (!Directory.Exists(tmp))
                Directory.CreateDirectory(tmp);

            tmp = Path.Combine(tmp, "weenies");
            if (!Directory.Exists(tmp))
                Directory.CreateDirectory(tmp);

            sandboxMigration.Start();
            var sandboxes = Directory.EnumerateDirectories(src + @"\sandboxes\weenies");
            foreach (var sandbox in sandboxes)
            {
                sourceFiles = Directory.EnumerateFiles(sandbox);
                foreach (string sourceFile in sourceFiles)
                {
                    string content = File.ReadAllText(sourceFile);
                    DfWeenieChange dfChange = JsonConvert.DeserializeObject<DfWeenieChange>(content);
                    string sandboxId = sandbox.Substring(sandbox.LastIndexOf("\\") + 1);
                    string sandboxFolder = dst + @"\sandboxes\weenies\" + sandboxId;

                    Console.WriteLine($"Migrating sandbox {sandboxId} - Weenie {dfChange.Weenie.WeenieClassId}, {dfChange.Weenie.Name}...");

                    if (dfChange.Weenie.IntProperties?.FirstOrDefault(i => i.IntPropertyId == 9007) == null)
                    {
                        Console.WriteLine("... is not possible - missing Weenie Type.");
                        continue;
                    }

                    if (!Directory.Exists(sandboxFolder))
                        Directory.CreateDirectory(sandboxFolder);

                    try
                    {
                        WeenieChange gdleWeenieChange = WeenieChange.ConvertFromDF(dfChange);
                        string migrated = JsonConvert.SerializeObject(gdleWeenieChange);
                        File.WriteAllText(Path.Combine(sandboxFolder, gdleWeenieChange.Weenie.WeenieClassId + ".json"), migrated);

                        sandboxWeenies++;
                        Console.WriteLine($"... done.");
                    }
                    catch (Exception ex)
                    {
                        sandboxWeenieFails++;
                        Console.WriteLine($"... failed.");
                    }
                }

                sandboxMigrations++;
            }
            sandboxMigration.Stop();

            Console.WriteLine($"{weenieMigrations} repository weenies migrated successfully ({weenieFails} failed) in {repoMigration.ElapsedMilliseconds} milliseconds.");
            Console.WriteLine($"{sandboxWeenies} weenies in {sandboxMigrations} sandboxes migrated successfully ({sandboxWeenieFails} failed) in {sandboxMigration.ElapsedMilliseconds} milliseconds.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
