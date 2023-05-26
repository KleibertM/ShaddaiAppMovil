using Joss.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Shaddai
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }

        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tienda.db3"
                        ));
                }
                return db;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
