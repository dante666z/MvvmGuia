using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmGuia.Modelo;
using MvvmGuia.Vistas;

namespace MvvmGuia.VistaModelo
{
    public class VMMenuPrincipal : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<ModeloMenuPrincipal> listaPaginas { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMMenuPrincipal(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPaginas();
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
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void MostrarPaginas()
        {
            listaPaginas = new List<ModeloMenuPrincipal>
            {
                new ModeloMenuPrincipal
                {
                    Pagina = "Entry, datepicker, picker, labels, navegación",
                    Icono = "paleta.png"
                },
                new ModeloMenuPrincipal
                {
                    Pagina = "Collection view sin enlace a Base de datos",
                    Icono = "coco.png"
                },
                new ModeloMenuPrincipal
                {
                    Pagina = "Crud pokemon",
                    Icono = "pokebola.png"
                },
            };

        }
        public async Task Navegar(ModeloMenuPrincipal parametros)
        {
            string pagina;
            pagina = parametros.Pagina;
            if(pagina.Contains("Entry, datepicker"))
            {
                await Navigation.PushAsync(new Pagina1());
            }
            if (pagina.Contains("Collection view sin enlace"))
            {
                await Navigation.PushAsync(new Pagina2());
            }
            if (pagina.Contains("Crud pokemon"))
            {
                await Navigation.PushAsync(new CrudPokemon());
            }
        }
        #endregion

        #region COMANDOS
        //public ICommand VolverCommand => new Command(async () => await Volver());
        //public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        public ICommand NavegarCommand => new Command<ModeloMenuPrincipal>(async (p) => await Navegar(p));
        #endregion
    }
}
