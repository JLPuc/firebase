using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace firebase
{
    public class ServerCon
    {
        public AndroidFCMPushNotificationStatus generarNotificacion(string token, string body)
        {
            // se declara un objeto para conocer el resultado de la operación de las notificaciones
            AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();
            // Se obtienen los dispositivos registrados en la base de datos

            try
            {
                result.Successful = false;
                result.Error = null;
                // se asigna a una variable el API Key del servidor
                var serverApiKey = "AAAAZBELpcE:APA91bHdTPXQpi1625eqZO8qukaKp86DFWDtXS5JxIPfckFQtlRUpFuFA7jSBft-r5Kw4lO1XIxEv3hXisuI9d9Txog_xdDamZKPDJ5GTVT2ByEKUlDZYqb67R3eMZT4s5LdiTG5P7DZ";
                // se asigna a una variable el ID del remitente (servidor)
                var senderId = "429782705601";
                // se asigna a una variable el nombre del evento 
                // var value = "algo";
                // se obtiene la tabla de los dispositivos

                // se asigna a una variable el Token del dispositivo (según la fila)
                var deviceId = Convert.ToString(token);
                
                var cuerpo = Convert.ToString(body);

                // se crea un WebReques para el envío de las notividaciones
                WebRequest tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send ");
                // método "post" para declarar que es una notificación
                tRequest.Method = "post";
                // declarar tipo de contenido (android lo maneja por archivos json)
                tRequest.ContentType = "application/json";
                // declaración de variable data para contener la información en formato json
                var data = new
                {
                    // se asigna a qué dispositivo va dirigida la notificación
                    to = deviceId,
                    notification = new
                    {
                        // se asigna el texto de la notificación
                        body = cuerpo,
                        title = "Banca Móvil Digital",
                        icon = "myicon",
                        sound = "Enabled"
                   
                    }
                };

                // variable para convertir la información en formato json
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);

                // arreglo de bytes para asignar los datos del formato json
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                // se agrega la autorización por medio del API Key del servidor
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
                // se agrega el remitente
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                tRequest.ContentLength = byteArray.Length;

                // se realiza el proceso de envío de la notificación al servidor y ser reenviado todos los dispositivos móviles
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                result.Response = sResponseFromServer;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }

            return result;
        }


        public AndroidFCMPushNotificationStatus GenerarNotificacion(MensajeBO obj)
        {

            MensajeBO msbo = (MensajeBO)obj;
            // se declara un objeto para conocer el resultado de la operación de las notificaciones
            AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();
            // Se obtienen los dispositivos registrados en la base de datos

            try
            {
                result.Successful = false;
                result.Error = null;
                // se asigna a una variable el API Key del servidor
                var serverApiKey = "AAAAZBELpcE:APA91bHdTPXQpi1625eqZO8qukaKp86DFWDtXS5JxIPfckFQtlRUpFuFA7jSBft-r5Kw4lO1XIxEv3hXisuI9d9Txog_xdDamZKPDJ5GTVT2ByEKUlDZYqb67R3eMZT4s5LdiTG5P7DZ";
                // se asigna a una variable el ID del remitente (servidor)
                var senderId = "429782705601";
                // se asigna a una variable el nombre del evento 
                // var value = "algo";
                // se obtiene la tabla de los dispositivos

                // se asigna a una variable el Token del dispositivo (según la fila)
                var deviceId = Convert.ToString(msbo.getToken());
                var titulo = Convert.ToString(msbo.getTitulo());
                var cuerpo = Convert.ToString(msbo.getBody());

                // se crea un WebReques para el envío de las notividaciones
                WebRequest tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send ");
                // método "post" para declarar que es una notificación
                tRequest.Method = "post";
                // declarar tipo de contenido (android lo maneja por archivos json)
                tRequest.ContentType = "application/json";
                // declaración de variable data para contener la información en formato json
                var data = new
                {
                    // se asigna a qué dispositivo va dirigida la notificación
                    to = deviceId,
                    notification = new
                    {
                        // se asigna el texto de la notificación
                        body = cuerpo,
                        title = titulo,
                        icon = "myicon",
                        sound = "Enabled"

                    }
                };

                // variable para convertir la información en formato json
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);

                // arreglo de bytes para asignar los datos del formato json
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                // se agrega la autorización por medio del API Key del servidor
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
                // se agrega el remitente
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                tRequest.ContentLength = byteArray.Length;

                // se realiza el proceso de envío de la notificación al servidor y ser reenviado todos los dispositivos móviles
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                result.Response = sResponseFromServer;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }

            return result;
        }

        public class AndroidFCMPushNotificationStatus
        {
            public bool Successful
            {
                get;
                set;
            }

            public string Response
            {
                get;
                set;
            }
            public Exception Error
            {
                get;
                set;
            }
        }
    }
}