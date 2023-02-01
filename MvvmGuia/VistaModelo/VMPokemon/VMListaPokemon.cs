using MvvmGuia.Vistas.Pokemon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmGuia.Datos;
using MvvmGuia.Modelo;
using System.Collections.ObjectModel;

namespace MvvmGuia.VistaModelo.VMPokemon
{
   public class VMListaPokemon : BaseViewModel
    {
        #region VARIABLES
        ObservableCollection<MPokemon> _ListaPokemon;
        #endregion

        #region CONSTRUCTOR
        public VMListaPokemon(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPokemon();
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<MPokemon> ListaPokemon
        {
            get { return _ListaPokemon; }
            set { SetValue(ref _ListaPokemon, value);
                OnpropertyChanged();
            }
        }
        #endregion

        #region PROCESOS
        public async Task MostrarPokemon()
        {
            var funcion = new Dpokemon();
            ListaPokemon = await funcion.MostrarPokemones();
        }
        public async Task IraRegistro()
        {
            await Navigation.PushAsync(new RegistrarPokemon());
        }
        public async Task IrADetalle(MPokemon pokemon)
        {
            await Navigation.PushAsync(new DetallePokemon(pokemon));
        }
        #endregion

        #region COMANDOS
        public ICommand IrARegistroCommand => new Command(async () => await IraRegistro());
        public ICommand IrADetalleCommand => new Command<MPokemon>(async (pokemon) => await IrADetalle(pokemon));
        #endregion

    }
}
