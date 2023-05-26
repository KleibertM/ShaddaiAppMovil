using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
namespace Shaddai
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ctlg : ContentPage
    {
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();
        public Ctlg()
        {
            InitializeComponent();
            imageSources.Add("ban1.jpg");
            imageSources.Add("ban2.jpg");
            imageSources.Add("ban3.jpg");
            imageSources.Add("ban4.jpg");

            imgSlider.Images = imageSources;
            imgSliders.Images = imageSources;
        }
    }
}
