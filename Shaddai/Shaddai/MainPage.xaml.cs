using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;

namespace Shaddai
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Menu();
            this.Detail = new NavigationPage(new Ctlg());
            App.MasterDet = this;
        }

    }
}
