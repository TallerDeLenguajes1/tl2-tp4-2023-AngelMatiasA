using System;
using Models;

using System.Text.Json;
using System.IO;
namespace EspacioDatos;
public class AccesoADatosPedidos : AccesoADatos
{

   public   List<Pedidos> obtener(string nombreArchivo)
    {
        if (existeArchivo(nombreArchivo))
        {
            using (var streamReader = new StreamReader(nombreArchivo))
            {
                var json = streamReader.ReadToEnd();
                Console.WriteLine(" Se imprime el json "+json);
                int i = 1;
                 List<Pedidos> Pedidos = JsonSerializer.Deserialize<List<Pedidos>>(json);
                 foreach (var item in Pedidos)
                 {
                    item.NroPedido = i++; 
                    
                 }
                return Pedidos;
            }
        }
        else
        {
            Console.WriteLine($"El archivo {nombreArchivo} no existe.");
            return null;
        }
    }
    
  

    public void Guardar(string nombreArchivo, List<Pedidos> listaPedidos)
    {
        string listaJSON = JsonSerializer.Serialize(listaPedidos);
        File.WriteAllText(nombreArchivo, listaJSON);
    }

      
}
