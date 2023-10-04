using System; 
using EspacioPedidos; 
namespace EspacioCadete;  




public class Cadete
{
    private static int cant = 0; 
    private int id = 0; 
    private string direccion; 
    private string nombre;
    private string telefono;  
    List<Pedidos> listaPedidos;

    Pedidos nuevoPedido;

    public List<Pedidos> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
    // public string Telefono { get => telefono; set => telefono = value; }
    // public string Direccion { get => direccion; set => direccion = value; }
    // public int Id { get => id; set => id = value; }
    // public string Nombre { get => nombre; set => nombre = value; }
     public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public int Id { get;  set; }

    public Cadete (){
        this.id = cant; 
        cant++;
    }
     public Cadete (string nombre, string direccion, string telefono){
        this.id = cant;
        this.nombre = nombre; 
        this.direccion = direccion ; 
        this.telefono = telefono;
        cant++;
    }
  

    //esta no se usaria porque hay q agregar pedido dependientemente del cadete
    // public Pedidos altaPedido ( string observacion,  string nomcli, string clidire, string cliTelefono, string cliDatRef){ 
    //     nuevoPedido = new Pedidos(observacion, nomcli, clidire, cliTelefono, cliDatRef );
    //     return nuevoPedido;

    // }
    // public void agregarPedido ( string observacion,  string nomcli, string clidire, string cliTelefono, string cliDatRef){ 
    //     nuevoPedido = new Pedidos(observacion, nomcli, clidire, cliTelefono, cliDatRef );
    //     this.listaPedidos.Add(nuevoPedido);

    // }
    public Pedidos altaPedido ( string observacion,  string nomcli, string clidire, string cliTelefono, string cliDatRef){ 
        nuevoPedido = new Pedidos(observacion, nomcli, clidire, cliTelefono, cliDatRef );
        // this.listaPedidos.Add(nuevoPedido);
        return nuevoPedido;

    }

    /*

     public void asignarPedido ( Pedidos pedidoAsignar){ 
        pedidoAsignar.Estado = pedidoAsignar.getarreglosEstados(1);
        pedidoAsignar.setIdCadetePedidos(this.Id);
        this.listaPedidos.Add(pedidoAsignar); 


    }
    //este metodo invocarlo en cadeteria dentro d la funcion 
    // reasignarPedido.. lo busco al pedido y me fijo el id de
    //cadete (tipo foreign key) que tiene el pedido
    //y hago un foreach para buscar esecadete y ahi le 
    //remuevo de su lista y lo reasigno a otro con asignar pedido
 
 
    public void RemoverPedido(int idPedido){ 
        Pedidos pedidoAux = null;
        foreach (Pedidos item in this.listaPedidos)
        {
            if (item.NroPedido == idPedido)
            { 
                pedidoAux = item;
                
            }

        }
        
        if (pedidoAux!= null)
        {
            this.listaPedidos.Remove(pedidoAux);
            Console.WriteLine($" pedido removido con exito del cadete nro " + 
            $"{this.id}, ${this.nombre}");
            
        }
        else
        {
            Console.WriteLine("no se encontro el pedido");
        }
        
    }
   
   */

  
}