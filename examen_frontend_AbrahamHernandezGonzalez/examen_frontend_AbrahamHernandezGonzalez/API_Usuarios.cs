using examen_backend_AbrahamHernandezGonzalez.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace examen_frontend_AbrahamHernandezGonzalez
{
    public class API_Usuarios
    {
        public List<Usuarios> _lsUsuarios = new List<Usuarios>();
        public Usuarios _Usuarios = new Usuarios();
        string _urlAPI = ConfigurationManager.AppSettings["urlWebAPI"];


        public List<Usuarios> ConsultarTodos()
        {
            var lsUsuarios = new List<Usuarios>();
            try
            {
                using (var client = new HttpClient())
                {
                    Task<HttpResponseMessage> responseTask = client.GetAsync(_urlAPI);
                    //Esperar a que complete la operacion
                    responseTask.Wait();
                    //Obtenemos el objeto httpResponseMenssage a travez de la porpiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = responseTask.Result;
                    // Un true o Falso y el codigo del Estaus 200... Content el contenido del mesaje
                    if (result.IsSuccessStatusCode)
                    {
                        // Devuelve un string para hacer una descerializacion se invoca el read para serializar el contenido http
                        // en una cadena con una operacion asincrona

                        Task<string> readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait(); //Se invoca a fin de esperar a que se complete la operacion asincrona
                        string json = readTask.Result; //Obtenemos el string  en formato json del objeto recibido

                        lsUsuarios = JsonConvert.DeserializeObject<List<Usuarios>>(json);
                        ///Descerializamos el objeto establecido en este caso una lista de estatus
                    }
                    else //Web
                    {
                        throw new Exception($"WebAPI. Response con error.{result.StatusCode}");
                    }
                }



            }
            catch (Exception ex)
            {

                throw new Exception($"WebAPI. Response con error.{ex.Message}");
            }


            return lsUsuarios;


        }

        public Usuarios Consultar(int? id)
        {

            var usuario = new Usuarios();
            //var estatusAlumnos = new List<EstatusAlumnos>();
            try
            {
                using (var client = new HttpClient())
                {

                    Task<HttpResponseMessage> responseTask = client.GetAsync(_urlAPI + $"/{id}");

                    //Esperar a que complete la operacion
                    responseTask.Wait();

                    //Obtenemos el objeto httpResponseMenssage a travez de la porpiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = responseTask.Result;

                    // Un true o Falso y el codigo del Estaus 200... Content el contenido del mesaje
                    if (result.IsSuccessStatusCode)
                    {
                        // Devuelve un string para hacer una descerializacion se invoca el read para serializar el contenido http
                        // en una cadena con una operacion asincrona

                        Task<string> readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait(); //Se invoca a fin de esperar a que se complete la operacion asincrona
                        string json = readTask.Result; //Obtenemos el string  en formato json del objeto recibido

                        usuario = JsonConvert.DeserializeObject<Usuarios>(json);
                        ///Descerializamos el objeto establecido en este caso una lista de estatus



                    }
                    else //Web
                    {
                        throw new Exception($"WebAPI. Response con error.{result.StatusCode}");
                    }
                }



            }
            catch (Exception ex)
            {

                throw new Exception($"WebAPI. Response con error.{ex.Message}");
            }


            return usuario;

        }

        public void Agregar(Usuarios User)
        {
            //var estatusAlumnos = new List<EstatusAlumnos>();
            try
            {
                using (var client = new HttpClient())
                {
                    //Creamos un objeto http instanciando un objeto stringcontent este objeto se crea en el objeto
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(User), Encoding.UTF8);

                    //Asinamos a la propiedad Contentype del encabezado 
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    //
                    var posTask = client.PostAsync(_urlAPI, httpContent);
                    //Invoca al petodo put del objeto client el cual sera enviada la solicitud

                    posTask.Wait();

                    var result = posTask.Result;


                    // Un true o Falso y el codigo del Estaus 200... Content el contenido del mesaje
                    if (!result.IsSuccessStatusCode)
                    {
                        // Devuelve un string para hacer una descerializacion se invoca el read para serializar el contenido http
                        // en una cadena con una operacion asincro
                        throw new Exception($"WebAPI. Response con error.{result.StatusCode}");
                    }

                }



            }
            catch (Exception ex)
            {

                throw new Exception($"WebAPI. Response con error.{ex.Message}");
            }





        }

        public void Actualizar(Usuarios User)
        {

            //var estatusAlumnos = new List<EstatusAlumnos>();
            try
            {
                using (var client = new HttpClient())
                {
                    //Creamos un objeto http instanciando un objeto stringcontent este objeto se crea en el objeto
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(User), Encoding.UTF8);

                    //Asinamos a la propiedad Contentype del encabezado 
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    //
                    var posTask = client.PutAsync(_urlAPI + $"/{User.Id}", httpContent);
                    //Invoca al petodo put del objeto client el cual sera enviada la solicitud

                    posTask.Wait();

                    var result = posTask.Result;


                    // Un true o Falso y el codigo del Estaus 200... Content el contenido del mesaje
                    if (!result.IsSuccessStatusCode)
                    {
                        // Devuelve un string para hacer una descerializacion se invoca el read para serializar el contenido http
                        // en una cadena con una operacion asincro
                        throw new Exception($"WebAPI. Response con error.{result.StatusCode}");
                    }

                }



            }
            catch (Exception ex)
            {

                throw new Exception($"WebAPI. Response con error.{ex.Message}");
            }





        }


        public void Eliminar(int id)
        {

            //var estatusAlumnos = new List<EstatusAlumnos>();
            try
            {
                using (var client = new HttpClient())
                {

                    Task<HttpResponseMessage> responseTask = client.DeleteAsync(_urlAPI + $"/{id}");

                    //Esperar a que complete la operacion
                    responseTask.Wait();

                    //Obtenemos el objeto httpResponseMenssage a travez de la porpiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = responseTask.Result;

                    // Un true o Falso y el codigo del Estaus 200... Content el contenido del mesaje
                    if (!result.IsSuccessStatusCode)
                    {
                        // Devuelve un string para hacer una descerializacion se invoca el read para serializar el contenido http
                        // en una cadena con una operacion asincro
                        throw new Exception($"WebAPI. Response con error.{result.StatusCode}");
                    }

                }



            }
            catch (Exception ex)
            {

                throw new Exception($"WebAPI. Response con error.{ex.Message}");
            }





        }
    }
}