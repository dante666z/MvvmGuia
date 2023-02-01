using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmGuia.Modelo;
namespace MvvmGuia.VistaModelo
{
    public class VMpagina2 : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<MUsuarios> listaUsuarios { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMpagina2(INavigation navigation)
        {
            Navigation = navigation;
            MostrarUsuarios();
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
        public void MostrarUsuarios()
        {
            listaUsuarios = new List<MUsuarios>
            {
                new MUsuarios
                {
                    Nombre = "Zuriel",
                    Imagen = "coco.png"
                },
                new MUsuarios
                {
                    Nombre = "Carlos",
                    Imagen = "paleta.png"
                },
                new MUsuarios
                {
                    Nombre = "Alejandro",
                    Imagen = "pokebola.png"
                },
            };

        }
        public async Task Alerta(MUsuarios parametros)
        {
            await DisplayAlert("Titulo", parametros.Nombre, "ok");
        }
        #endregion

        #region COMANDOS
        public ICommand VolverCommand => new Command(async () => await Volver());
        //public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        public ICommand AlertaCommand => new Command<MUsuarios>(async (p) => await Alerta(p));
        #endregion
    }
}
