using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmGuia.Modelo;
using MvvmGuia.Datos;

namespace MvvmGuia.VistaModelo.VMPokemon
{
   public class VMRegistrarPokemon : BaseViewModel
    {
        #region VARIABLES
        string _TxtColorFondo;
        string _TxtColorPoder;
        string _TxtNombre;
        string _TxtNro;
        string _TxtPoder;
        string _TxtIcono;
        #endregion

        #region CONSTRUCTOR
        public VMRegistrarPokemon(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string TxtcolorFondo
        {
            get { return _TxtColorFondo; }
            set { SetValue(ref _TxtColorFondo, value); }
        }
        public string TxtColorPoder
        {
            get { return _TxtColorPoder; }
            set { SetValue(ref _TxtColorPoder, value); }
        }
        public string TxtNombre
        {
            get { return _TxtNombre; }
            set { SetValue(ref _TxtNombre, value); }
        }
        public string TxtNro
        {
            get { return _TxtNro; }
            set { SetValue(ref _TxtNro, value); }
        }
        public string TxtPoder
        {
            get { return _TxtPoder; }
            set { SetValue(ref _TxtPoder, value); }
        }
        public string TxtIcono
        {
            get { return _TxtIcono; }
            set { SetValue(ref _TxtIcono, value); }
        }
        #endregion

        #region PROCESOS
        public async Task Insertar()
        {
            // Instanciamos datos pokemon y modelo para parametros
            var funcion = new Dpokemon();
            var parametros = new MPokemon()
            {
                // Pasamos los valores
                Colorfondo = TxtcolorFondo,
                Colorpoder = TxtColorPoder,
                Icono = TxtIcono,
                Nombre = TxtNombre,
                Nroorden = TxtNro,
                Poder = TxtPoder
            };
            // Insertamos en la base de datos mediante el metodo
            await funcion.InsertarPokemon(parametros);
            // al terminar regresamos a la lista
            await Volver();
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand InsertarCommand => new Command(async () => await Insertar());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion
    }
}
