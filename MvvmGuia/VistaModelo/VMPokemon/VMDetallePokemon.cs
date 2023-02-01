using MvvmGuia.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.VistaModelo.VMPokemon
{
   public class VMDetallePokemon : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public MPokemon pokemonRecibe { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMDetallePokemon(INavigation navigation, MPokemon pokemonTrae)
        {
            Navigation = navigation;
            pokemonRecibe = pokemonTrae;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region PROCESOS
        public async Task volver()
        {
            await Navigation.PopAsync();
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand VolverCommand => new Command(async () => await volver());
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
