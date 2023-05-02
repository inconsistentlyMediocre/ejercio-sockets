﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSockets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Valores hardocodeados de momento
            string ip = "127.0.0.1";
            int puerto = 2050;

            Cliente cliente = new Cliente(ip, puerto);
            cliente.Iniciar();
            string mensaje = "";
            string respuesta = "";
            while (!mensaje.Equals("chao") && !respuesta.Equals("chao"))
            {
                mensaje = cliente.Enviar(Console.ReadLine());
                respuesta = cliente.Leer();
                Console.WriteLine("El server mando: {0}", respuesta);
            }
        }
    }
}
