using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class ClsDirectorios
    {
        string DirectorioRaiz = "C:\\ControlDosimetro";
        string DirectorioCreado = "";
        public enum Directorios
        {
            Errores,
            Reportes
        }

        /// <summary>
        /// Creo los directorios para la App, según el objeto que se desee guardar.
        /// </summary>
        /// <param name="CodigoDirectorio"></param>
        /// <returns></returns>
        public string CreaDirectorios(int CodigoDirectorio)
        {
            Directory.CreateDirectory(DirectorioRaiz);
            switch (CodigoDirectorio)
            {
                case 0:
                    //Crea directorio Errores
                    DirectorioCreado = DirectorioRaiz + "\\" + Directorios.Errores;
                    Directory.CreateDirectory(DirectorioCreado);
                    break;
                case 1:
                    //Crea directorio Reportes
                    DirectorioCreado = DirectorioRaiz + "\\" + Directorios.Reportes;
                    Directory.CreateDirectory(DirectorioCreado);
                    break;
                default:
                    //Crea directorio Errores
                    break;
            }
            return DirectorioCreado;
        }
    }
}
