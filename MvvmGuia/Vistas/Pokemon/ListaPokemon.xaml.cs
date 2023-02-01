using MvvmGuia.VistaModelo.VMPokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmGuia.Vistas.Pokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPokemon : ContentPage
    {   
        // EN caso de ser lista
        //VMListaPokemon vm;
        public ListaPokemon()
        {
            InitializeComponent();
            BindingContext = new VMListaPokemon(Navigation);
            // En caso de ser lista
            //vm = new VMListaPokemon(Navigation);
            //BindingContext = vm;
            //this.Appearing += ListaPokemon_Appearing;
        }
        // en caso de ser lista
        //private async void ListaPokemon_Appearing(object sender, EventArgs e)
        //{
        //   await vm.MostrarPokemon();
        //}
    }
}