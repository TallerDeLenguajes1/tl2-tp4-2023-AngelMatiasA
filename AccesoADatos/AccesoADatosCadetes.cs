using System;
using Models;

using System.Text.Json;
using System.IO;
namespace EspacioDatos;
public class AccesoADatosCadetes : AccesoADatos
{

    
    
  
    public   List<Cadete> cargarCadetes(string nombreArchivo)
    {
        if (existeArchivo(nombreArchivo))
        {
            using (var streamReader = new StreamReader(nombreArchivo))
            {
                var json = streamReader.ReadToEnd();
                Console.WriteLine(" Se imprime el json "+json);
                int i = 1;
                 List<Cadete> CadetesJson = JsonSerializer.Deserialize<List<Cadete>>(json);
                 foreach (var item in CadetesJson)
                 {
                    item.Id = i++; 
                    
                 }
                return CadetesJson;
            }
        }
        else
        {
            Console.WriteLine($"El archivo {nombreArchivo} no existe.");
            return null;
        }
    }

    
      

    public void Guardar(string nombreArchivo, List<Cadete> cadetesList)
    {
        string listaJSON = JsonSerializer.Serialize(cadetesList);
        File.WriteAllText(nombreArchivo, listaJSON);
    }
}
