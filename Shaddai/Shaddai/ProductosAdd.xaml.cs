using Shaddai.Model;
using Shaddai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shaddai
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductosAdd : ContentPage
	{
		public ProductosAdd ()
		{
			InitializeComponent ();
            llenarDatos();
		}

        private async void btnRegis_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Producto item = new Producto
                {
                    Nom = Nombre.Text,
                    Version = tVersion.Text,
                    Precio = int.Parse(Precio.Text),
                    Descrip = Descrip.Text,
                    Categoria = Categ.SelectedItem as string,
                    Letra = letraPicker.SelectedItem as string,
                };
                await App.SQLiteDB.SaveProductoASync(item);

                await DisplayAlert("Registro", "Registro Exitoso", "Ok");
                LimpiarControles();
                llenarDatos();

            }
            else
            {
                await DisplayAlert("Registro", "Error de Registro", "Aceptar");
            }
        }

        public async void llenarDatos()
        {
            var itemList = await App.SQLiteDB.GetProductosAsync();
            if (itemList != null)
            {
                listProductos.ItemsSource = itemList;
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(Nombre.Text)) { respuesta = false; }

            else if (string.IsNullOrEmpty(tVersion.Text)) { respuesta = false; }

            else if (string.IsNullOrEmpty(Precio.Text)) { respuesta = false; }

            else if (string.IsNullOrEmpty(Descrip.Text)) { respuesta = false; }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnActua_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idItem.Text))
            {
                Producto item= new Producto()
                {
                    IdItem = Convert.ToInt32(idItem.Text),
                    Nom = Nombre.Text,
                    Version = tVersion.Text,
                    Precio = Convert.ToInt32(Precio.Text),
                    Descrip = Descrip.Text,
                    Categoria = Categ.SelectedItem as string,
                    Letra = letraPicker.SelectedItem as string,
                };
                await App.SQLiteDB.SaveProductoASync(item);
                await DisplayAlert("Registro", "Actualizacion Exitosa", "Ok");
                LimpiarControles();
                idItem.IsVisible = false;
                btnActua.IsVisible = false;
                btnRegis.IsVisible = true;
                llenarDatos();
            }
        }

        private async void listProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Producto)e.SelectedItem;
            btnRegis.IsVisible = false;
            idItem.IsVisible = true;
            btnActua.IsVisible = true;
            btnElimi.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.IdItem.ToString()))
            {
                var item = await App.SQLiteDB.GetProductoById(obj.IdItem);
                if (item != null)
                {
                    idItem.Text = item.IdItem.ToString();
                    Nombre.Text = item.Nom;
                    tVersion.Text = item.Version;
                    Precio.Text = item.Precio.ToString();
                    Descrip.Text = item.Descrip;
                    Categ.SelectedItem = item.Categoria;
                    letraPicker.SelectedItem = item.Letra;
                }
            }
        }

        private async void btnElimi_Clicked(object sender, EventArgs e)
        {
            var item = await App.SQLiteDB.GetProductoById(Convert.ToInt32(idItem.Text));
            if (item != null)
            {
                await App.SQLiteDB.DeleteProductoAsync(item);
                await DisplayAlert("Registro", "Eliminado Exitoso", "Ok");
                LimpiarControles();
                llenarDatos();

                idItem.IsVisible = false;
                btnRegis.IsVisible = true;
                btnActua.IsVisible = false;
                btnElimi.IsVisible = false;
            }
        }

        public void LimpiarControles()
        {
            idItem.Text = "";
            Nombre.Text = "";
            tVersion.Text = "";
            Precio.Text = "";
            Descrip.Text = "";
            Categ.SelectedItem = "";
            letraPicker.SelectedItem = "";
        }

    }
}