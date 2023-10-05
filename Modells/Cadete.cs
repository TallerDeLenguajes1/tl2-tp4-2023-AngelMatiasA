using System; 
namespace Models;  




public class Cadete
{
    private static int cant = 0; 
    private int id = 0; 
    private string direccion; 
    private string nombre;
    private string telefono;  
    Pedidos nuevoPedido;

    public int Id { get;  set; }
     public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }

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
  

    
    public Pedidos altaPedido ( string observacion,  string nomcli, string clidire, string cliTelefono, string cliDatRef){ 
        nuevoPedido = new Pedidos(observacion, nomcli, clidire, cliTelefono, cliDatRef );
        // this.listaPedidos.Add(nuevoPedido);
        return nuevoPedido;

    }

   
  
}