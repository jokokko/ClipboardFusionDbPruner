using System.IO;
using ClipboardFusionDbPruner.Services;
using Microsoft.Win32;

namespace ClipboardFusionDbPruner
{
    internal static class Program
    {
        private static void Main()
        {
            string DbFromRegistry()
            {
                var cfDb = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Binary Fortress Software\ClipboardFusion", "DatabaseLocation", null);

                cfDb = Path.Combine(cfDb, "clipboardfusion.db");

                var pw = StringHelper.Get();

                return $"Data Source={cfDb};Version=3;Password={pw};";
            }
            
            var cstringClipboardFusion = DbFromRegistry();
            var pruner = new Services.ClipboardFusionDbPruner();
            pruner.Prune(cstringClipboardFusion);
        }
    }
}
