using System;
using EspacioCadeteria;  
using EspacioCadete; 
using EspacioPedidos;
using System.Text.Json; 
using System.IO;
using EspacioInforme;
namespace EspacioDatos; 
 
public class AccesoCSV: AccesoADatos
{
    Cadete nuevoCadete = new Cadete();  
    
    public AccesoCSV(){

    }

  
    

    public override Cadeteria cargarCadeteria(string nombreArchivo){
        Cadeteria nuevaCadeteria = new Cadeteria(); 
        if (existeArchivo(nombreArchivo))
        {
            using (StreamReader lector = new StreamReader(nombreArchivo) )
            {
                string pirmeraLinea = lector.ReadLine();
                Cadete nuevoCadete = new Cadete();
                var linea = lector.ReadLine(); 
                var values = linea.Split(';');
                nuevaCadeteria.NombreCadeteria= values[0];
                nuevaCadeteria.TelefonoCadeteria= values[1];
             
                
            }
            
        }

        return nuevaCadeteria;

    }


     public override List<Cadete> cargarCadetes(string nombreArchivo){
          List<Cadete> CadetesCsv =  new List<Cadete>();  
          
        if (existeArchivo(nombreArchivo))
        {
           using(StreamReader lector = new StreamReader(nombreArchivo))
            {
                string pirmeraLinea = lector.ReadLine();
                int id = 1;
             while (!lector.EndOfStream  )
             { 
                Cadete nuevoCadete = new Cadete();
                var linea = lector.ReadLine(); 
                var values = linea.Split(';');
                nuevoCadete.Nombre = values[0];
                nuevoCadete.Direccion = values[1]; 
                nuevoCadete.Telefono = values[2];  
                nuevoCadete.Id = id; 
                id++;
                CadetesCsv.Add(nuevoCadete);
             }
            }
        }
        return CadetesCsv;
    }

//metodo para agilizar el testing
      public List<Pedidos> CargarPedidos(string nombreArchivo){
        List<Pedidos> PedidosCsv = new List<Pedidos>();  
        if (existeArchivo(nombreArchivo))
        {   
            using(var lector = new StreamReader(nombreArchivo))
            {
                string pirmeraLinea = lector.ReadLine();
             while (!lector.EndOfStream  )
             { 
                 Pedidos nuevoPedido = new Pedidos();
                var linea = lector.ReadLine(); 
                var values = linea.Split(';');
                
                // Console.WriteLine($"largo de la linea es de {values.Length}" );

                nuevoPedido.Observacion =values[0];
                nuevoPedido.SetNombreClien(values[1]);
                nuevoPedido.SetClienDirecc(values[2]);
                nuevoPedido.SetClienTelefono(values[3]);
                nuevoPedido.SetClienDatosRef(values[4]);
                PedidosCsv.Add(nuevoPedido);
             }

            }
             
        }
        return PedidosCsv;
    }
}