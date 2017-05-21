using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace firebase
{
    /// <summary>
    /// Descripción breve de firebaseServer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class firebaseServer : System.Web.Services.WebService
    {

        [WebMethod]
        public void Mensaje(string token,  string body)
        {
           ServerCon oclase = new ServerCon();
            oclase.generarNotificacion(token,body);
        }

        [WebMethod]
        public void MensajeObjeto(MensajeBO obj)
        {
            ServerCon oclase = new ServerCon();
            oclase.GenerarNotificacion(obj);
        }





    }
}

