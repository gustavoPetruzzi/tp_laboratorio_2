using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public delegate void FinDescargaCallback(string html);
        public delegate void ProgresoDescargaCallback(int progreso);

        public event FinDescargaCallback finDescarga;
        public event ProgresoDescargaCallback progresoDescarga;
        /// <summary>
        /// Constructor publico. asigna valor a html y direccion
        /// </summary>
        /// <param name="direccion">objeto de tipo uri que va a ser asignado a direccion</param>
        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }
        /// <summary>
        /// Inicia la descarga de los datos html
        /// </summary>
        public void IniciarDescarga()
        {
            
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted +=  WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion, this.html);
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Funcion privada que va indicando el progreso de la descarga.
        /// </summary>
        /// <param name="sender">Objeto de tipo object</param>
        /// <param name="e">Objeto de tipo DownloadProgressChangedEventArgs </param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            progresoDescarga(e.ProgressPercentage);
        }
        /// <summary>
        /// Funcion privada que va indicando el progreso de la descarga.
        /// </summary>
        /// <param name="sender">Objeto de tipo object</param>
        /// <param name="e">Objeto de tipo DownloadProgressChangedEventArgs</param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            finDescarga(e.Result);
        }
    }
}
