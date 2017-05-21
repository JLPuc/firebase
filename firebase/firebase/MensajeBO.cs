using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace firebase
{
    public class MensajeBO
    {

         private string token;

    public string getToken() {
        return token;
    }

    public void setToken(string token) {
        this.token = token;
    }

    public string getTitulo() {
        return titulo;
    }

    public void setTitulo(string titulo) {
        this.titulo = titulo;
    }

    public string getBody() {
        return body;
    }

    public void setBody(string body) {
        this.body = body;
    }

    private string titulo;
    private string body;


    }
}