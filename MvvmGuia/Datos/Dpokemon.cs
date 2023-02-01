using System;
using System.Collections.Generic;
using System.Text;
using MvvmGuia.Modelo;
using MvvmGuia.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Firebase.Database;

namespace MvvmGuia.Datos
{
    public class Dpokemon
    {
        public async Task InsertarPokemon(MPokemon parametros)
        {
            await Cconexion.firebase
                .Child("Pokemon")
                .PostAsync(new MPokemon()
                {
                    Colorfondo = parametros.Colorfondo,
                    Colorpoder = parametros.Colorpoder,
                    Icono = parametros.Icono,
                    Nombre = parametros.Nombre,
                    Nroorden = parametros.Nroorden,
                    Poder = parametros.Poder,
                });
        }
        public async Task<ObservableCollection<MPokemon>> MostrarPokemones()
        {
            // En caso de utilizar listas seria de esta manera
            //var data = (await Cconexion.firebase
            //    .Child("Pokemon")
            //    .OnceAsync<MPokemon>())
            //    .Where(a=>a.Key != "Modelo")
            //    .Select(item => new MPokemon
            //    {
            //        IdPokemon = item.Key,
            //        Nombre = item.Object.Nombre,
            //        Colorfondo = item.Object.Colorfondo,
            //        Colorpoder = item.Object.Colorpoder,
            //        Nroorden = item.Object.Nroorden,
            //        Poder = item.Object.Poder,
            //        Icono = item.Object.Icono
            //    }).ToList();

            // Para Observable collection
            var data = await Task.Run(() => Cconexion.firebase
                .Child("Pokemon")
                .AsObservable<MPokemon>()
                .AsObservableCollection());
            return data;
        }
    }
}
