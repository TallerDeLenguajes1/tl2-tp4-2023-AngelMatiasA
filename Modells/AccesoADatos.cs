using  System; 
using System.Collections; 
using System.IO;
using System.Runtime.CompilerServices;
using EspacioCadete; 
using EspacioCadeteria;
using EspacioPedidos;

namespace EspacioDatos; 

public abstract class AccesoADatos
{
     
    
    public AccesoADatos(){

    }

    protected bool existeArchivo(string nombreArchivo){
        try
        {
            if(File.Exists(nombreArchivo)){
                using (var stream = File.OpenRead(nombreArchivo))
                {
                    if ( stream.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else 
            {
                return false;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Se produjo un error al intentar abrir el archivo: {ex.Message}");
            return false;
        }
    }
   
    public abstract  List<Cadete> cargarCadetes(string nombreArchivo); 
    public abstract Cadeteria cargarCadeteria(string nombreArchivo);



//metodo para agilizar el testing
      //public abstract List<Pedidos> CargarPedidos(string nombreArchivo);
   
    
}