﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http;

namespace API_Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        

            private readonly ILogger<UsuarioController> _logger;

            public UsuarioController(ILogger<UsuarioController> logger)
            {
                _logger = logger;
            }
        //http://apiservicios.ecuasolmovsa.com:3009/api/Usuarios?usuario=5001&password=5001u
        [HttpGet(Name = "getUser")]
        
        public async Task<string> Get(string usuario, string password)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Usuarios?usuario=" + usuario + "&password=" + password;

                    // Hacer una petición GET a la URL y esperar la respuesta
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    // Leer el contenido de la respuesta como una cadena de caracteres
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Mostrar el cuerpo de la respuesta en la consola
                    Console.WriteLine(responseBody);
                    return responseBody;
                }
                //return "Holi";
            }
            catch (Exception error) {
                return ("erooor: "+ error);
            }
        }

        [HttpGet("Emisores")]
        
        public async Task<string> Get()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/GetEmisor";

                    // Hacer una petición GET a la URL y esperar la respuesta
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    // Leer el contenido de la respuesta como una cadena de caracteres
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Mostrar el cuerpo de la respuesta en la consola
                    Console.WriteLine(responseBody);
                    return responseBody;
                }
                //return "Holi";
            }
            catch (Exception error)
            {
                return ("erooor: " + error);
            }
        }

        [HttpGet("Costos")]

        public async Task<string> GetEmisores()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/CentroCostosSelect";

                    // Hacer una petición GET a la URL y esperar la respuesta
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    // Leer el contenido de la respuesta como una cadena de caracteres
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Mostrar el cuerpo de la respuesta en la consola
                    Console.WriteLine(responseBody);
                    return responseBody;
                }
                //return "Holi";
            }
            catch (Exception error)
            {
                return ("erooor: " + error);
            }
        }

    }
}
