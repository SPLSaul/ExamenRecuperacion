using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExamenRecuperacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre="";
            int cantidad=0;
            float precio=0f;
            Amazon limpia = new Amazon();
            int opc = 0;
            do
            {
                Console.WriteLine("Menu: \n(1)Capturar Objeto\n(2)Imprimir Datos\n(3)Salir");
                 opc = int.Parse(Console.ReadLine());
                limpia.Limpiar();

                switch (opc)
                {
                    case 1:
                        Console.Write("Ingresa el nombre del producto: ");
                        nombre = Console.ReadLine();
                        limpia.Limpiar();
                        Console.Write("Ingresa la cantidad de productos a comprar: ");
                        cantidad = int.Parse(Console.ReadLine());
                        limpia.Limpiar();
                        Console.Write("Ingresa el precio del producto: ");
                        precio = float.Parse(Console.ReadLine());
                        limpia.Limpiar();
                        limpia = new Amazon(nombre, cantidad, precio);                      
                        limpia.Crear();
                        limpia.Limpiar();
                        break;
                    case 2:
                        limpia.Imprimir();
                        limpia.Limpiar();
                        break;
                    case 3: Console.WriteLine("Programa Finalizado"); break;
                    default: Console.WriteLine("Opcion incorrecta, trata de nuevo"); break;
                } 

                limpia.Limpiar();
            } while (opc != 3);
            

        }
    }
    class Limpieza
    {
        public void Limpiar()
        {
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
    class Amazon:Limpieza
    {
         public string nombre;
         public int cantidad;
        public float precio;
        public Amazon() { }
        public Amazon(string nombre, int cantidad, float precio)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;
        }
        public void Crear()
        {
            
            StreamWriter escritor = new StreamWriter("Compra.txt");
            try
            {                
                escritor.WriteLine($"Articulo: {this.nombre}     Cantidad de productos: {this.cantidad}\nPrecio Unitario {this.precio}    Total a pagar {this.cantidad *this.precio}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error en la creacion del documento {e.Message}");
            }
            finally
            {
                escritor.Close();
            }
        }
        public void Imprimir()
        {            
            StreamReader lector = new StreamReader("Compra.txt");
            try
            {
                int c = 0;
                while (c != -1)
                {
                    c = lector.Read();
                    char letra = (char)c;
                    Console.Write(letra);
                }
            }catch(IOException e)
            {
                Console.WriteLine($"Error en la lectura del documento {e.Message}");
            }
            finally
            {
                lector.Close();
            }
            
        }
    }
}
