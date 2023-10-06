using System;
using Models;

using System.Text.Json;
using System.IO;
namespace EspacioDatos;
public class AccesoADatosCadeteria : AccesoADatos
{

    
    public  Cadeteria cargarCadeteria(string nombreArchivo){
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
  
 

    public void Guardar(string nombreArchivo, Cadeteria cadeteria)
    {
        string listaJSON = JsonSerializer.Serialize(cadeteria);
        File.WriteAllText(nombreArchivo, listaJSON);
    }
}
