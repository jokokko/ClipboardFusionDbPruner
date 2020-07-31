using System;
using System.Text;
using PetaPoco;

namespace ClipboardFusionDbPruner.Services
{
    internal sealed class ClipboardFusionDbPruner
    {
        public void Prune(string cstringClipboardFusion)
        {
            var imageBlob = BitConverter.ToString(Encoding.Unicode.GetBytes(@"{""Bitmap"""))
                .Replace("-", string.Empty);

            var stmnt = $@"
DELETE
FROM tblLocalRecentItems
WHERE substr(ItemData, 1, 18) = x'{imageBlob}'";

            using (var cf = new Database(cstringClipboardFusion, "System.Data.SQLite"))
            {
                var rowsDeleted = cf.Execute(stmnt);
                Console.WriteLine($"Deleted {rowsDeleted} rows.");
                if (rowsDeleted > 0)
                {
                    cf.Execute("VACUUM");
                    Console.WriteLine("VACUUMed");
                }
            }
        }
    }
}