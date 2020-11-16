using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Diary
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
            Application.Run(new Form1());

            //Skapa en koppling till databasen
            SQLiteConnection conn = new SQLiteConnection(@"data source=.\MinDB.sqllite");

            //Öppna kommunikationen
            conn.Open();

            //SQL-kod som ska exekveras
            const string query = "SELECT * FROM Students";

            //Kör kommandot
            SQLiteCommand cmd = new SQLiteCommand(query, conn);

            //Skapa en databashanterare
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd)
            {
                AcceptChangesDuringUpdate = true
            };
            //Skapa en dataset för att kunna bearbeta din data
            DataSet ds = new DataSet();

            //Anpassa datan från databasen till .NET objekt
            //För att det inte ska bli något fel anger vi även här namnet på tabellen
            dataAdapter.Fill(ds, "Students");

            //Tala om att ditt dataset får ändras
            ds.AcceptChanges();
        }
    }
}
