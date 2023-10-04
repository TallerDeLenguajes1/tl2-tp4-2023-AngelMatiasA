using System;
using EspacioCadeteria;
using EspacioCadete;
using System.Text.Json;
using System.IO;
using EspacioInforme;
namespace EspacioDatos;
public class AccesoJSON : AccesoADatos
{

    
    public override Cadeteria cargarCadeteria(string nombreArchivo){
        /* si o si lo tengo que inicializar aca xq sino el return no lo acepta o 
        hay otra manera?*/
        Cadeteria nuevaCadeteria = new Cadeteria(); 
        if (existeArchivo(nombreArchivo))
        {
            using(var lector = new StreamReader(nombreArchivo))
            {
                var json = lector.ReadToEnd(); 
                nuevaCadeteria = JsonSerializer.Deserialize<Cadeteria>(json);
            }
            
        }

        return nuevaCadeteria;

    }
  
    public override List<Cadete> cargarCadetes(string nombreArchivo)
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

    /* 
      public override List<Cadete> cargarCadetes(string nombreArchivo)
    {
        List<Cadete> cadetes = new List<Cadete>();
        //    List<Cadete> CadetesJson =  new List<Cadete>(); 
        Cadete cadete;
        if (existeArchivo(nombreArchivo))
        {
            using (var streamReader = new StreamReader(nombreArchivo))
            {
                var json = streamReader.ReadToEnd();
                Console.WriteLine(" Se imprime el json "+json);
                 List<Cadete> CadetesJson = JsonSerializer.Deserialize<List<Cadete>>(json);
                 
                 
                 foreach (Cadete cade in CadetesJson)
                 { 
                    cadete = new Cadete(cade.Nombre, cade.Direccion, cade.Telefono); 
                    cadetes.Add(cadete);
                    
                 }
                return cadetes;
            }
        }
        else
        {
            Console.WriteLine($"El archivo {nombreArchivo} no existe.");
            return null;
        }
    }
    
    
    */

    public void GuardarInforme(string nombreArchivo, Informe inform)
    {
        string listaJSON = JsonSerializer.Serialize(inform);
        File.WriteAllText(nombreArchivo, listaJSON);
    }
}
