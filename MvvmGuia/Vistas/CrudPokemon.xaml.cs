using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmGuia.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrudPokemon : ContentPage
    {
        public CrudPokemon()
        {
            InitializeComponent();
        }
    }
}