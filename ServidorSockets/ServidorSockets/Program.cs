using ServidorSockets.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServidorSockets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            if (servidor.Iniciar())
            {
                //OK, puede conectar
                Console.WriteLine("servidor iniciado");
                Console.WriteLine("Esperando Cliente");
                Socket socketCliente = servidor.ObtenerCliente();
                //Construir mecanismo de escritura y lectura
                ClienteCom cliente = new ClienteCom(socketCliente);
                string mensaje = "";
                string respuesta = "";
                while (!mensaje.Equals("chao") && !respuesta.Equals("chao"))
                {   
                    //ahora el protocolo de cominicacion 
                    mensaje = cliente.Escribir(Console.ReadLine());
                    respuesta = cliente.Leer();
                    Console.WriteLine("El cliente mando: {0}", respuesta);
                }
                cliente.Desconectar();
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Error, el puerto {0} esta en uso", puerto);

            }
        }
    }
}