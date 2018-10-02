using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestoned.DataModel.Gdle;
using Newtonsoft.Json;
using DfWeenie = Lifestoned.DataModel.DerethForever.Weenie;

namespace Lifestoned.WeenieMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            string src = @"C:\dev\behemoth\Lifestoned-GDLE-Server-Data\weenies";
            string dst = @"C:\dev\behemoth\Lifestoned-GDLE-Server-Data\migrated";

            var sourceFiles = Directory.EnumerateFiles(src);
            List<int> failedWeenies = new List<int>();

            foreach(string sourceFile in sourceFiles)
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
                    File.WriteAllText(Path.Combine(dst, gdleWeenie.WeenieClassId + ".json"), migrated);

                    Console.WriteLine($"... done.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"... failed.");
                }
            }
        }
    }
}
