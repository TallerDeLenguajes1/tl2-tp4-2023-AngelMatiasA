using System;
using EspacioCadete;
using EspacioPedidos;
using System.Linq;
namespace EspacioCadeteria;

public class Cadeteria
{
    private List<Cadete>? cadetes;
    private List<Pedidos>? lisPedCadeteria;
    private Cadete? nuevoCadete;
    private Cadete? objCadete = new Cadete();

    private string nombreCadeteria = "";
    private string telefonoCadeteria = "";

    public Cadeteria()
    {
        cadetes = new List<Cadete>();
        lisPedCadeteria = new List<Pedidos>();

    }
    public Cadeteria ( string pnombre, string ptelefono){
        this.nombreCadeteria = pnombre; 
        this.telefonoCadeteria = ptelefono;
        cadetes = new List<Cadete>();
        lisPedCadeteria = new List<Pedidos>();
    }
    public Cadeteria(List<Cadete> LisCadetes)
    {
        this.cadetes = LisCadetes;
        //lo comento xq uso el asginar pedidos testing para arrancar la lista
        lisPedCadeteria = new List<Pedidos>();


   }

   public string NombreCadeteria { get ; set; }
    public string TelefonoCadeteria { get; set; }
    public List<Cadete>? Cadetes {  get => cadetes; set => cadetes = value; }
   
    public List<Pedidos> getListaPedidos()
    {
        return this.lisPedCadeteria;
    }
    public List<Cadete> getListaCadetes()
    {
        return this.cadetes;
    }
  
  
    public void asignarPedidosTesting (List<Pedidos> pedidos){
        this.lisPedCadeteria = pedidos;

    }
  

    public void altaPedidoCadeteria( string observacion, string nomcli, string clidire, string cliTelefono, string cliDatRef)
    {


        lisPedCadeteria.Add(objCadete.altaPedido(observacion, nomcli, clidire, cliTelefono, cliDatRef));

    } 



    public void cambiarEStadoPedido(int idPedido, int estado){
        estado --;
        var pedido = this.lisPedCadeteria.FirstOrDefault(p=>p.NroPedido == idPedido); 
        if (pedido!= null){
            pedido.Estado = pedido.getarreglosEstados(estado);
        }

    }

   

public List<Pedidos> mostrarPedidosPorEStado(int estado)
{
    estado--; //para que la opcion ingresada disminuya al valor de arrayEstados
    
    List<Pedidos> pedidosFiltrados;

     pedidosFiltrados = this.lisPedCadeteria
        .Where(pedido => String.Equals(pedido.Estado, pedido.getarreglosEstados(estado), StringComparison.OrdinalIgnoreCase))
        .ToList();

   
        return pedidosFiltrados;
    
   
}


    public void agregarCadete(string nombre, string direccion, string telefono)
    {
        nuevoCadete = new Cadete(nombre, direccion, telefono);
        this.cadetes.Add(nuevoCadete);

    }
 
     public void asignarPedidos(int idPedido, int idCadete)
    {
         var pedido = this.lisPedCadeteria
        .FirstOrDefault(p => p.NroPedido == idPedido);

    if (pedido != null)
    {
        var cadete = this.cadetes
            .FirstOrDefault(c => c.Id == idCadete);
        if (cadete != null)
        {
            pedido.CadetePed = cadete;
            pedido.Estado = pedido.getarreglosEstados(1);
          
        }
    }
    }


    
    public List<Cadete> mostrarCadetes()
    {
        
        return this.cadetes;
    } 
   
//hacerlo q busqe x id tmb.. hya una pequeña incongruencia cuando el usuario
//no ingresa el nombre o no coincide.. igual se le remueve de la lista del otro
//usuario.. estaria bueno una tipo promesa...
    public void reasignarPedidos(int idPedido, int idCadete)
    {
        asignarPedidos(idPedido, idCadete);
    }

 
    public  void eliminarPedido( int idPedRemovido){
        var pedido = lisPedCadeteria.FirstOrDefault
        (p => p.NroPedido == idPedRemovido); 
        if (pedido != null)
        {
            lisPedCadeteria.Remove(pedido);
            
        }

        
    } 

  
    public double JornalACobrar(int idCadete ){
        double montoACobrar = 0; 
        var cadete = this.cadetes.FirstOrDefault(c => c.Id == idCadete); 
        if (cadete != null ){
            var cantPedidosRealizados = this.lisPedCadeteria
            .Where(
                pedido => String.Equals(pedido.Estado, pedido.getarreglosEstados(2), StringComparison.OrdinalIgnoreCase) 
                && pedido.CadetePed != null && pedido.CadetePed.Id == cadete.Id
                ).ToList().Count;
                montoACobrar = 500* cantPedidosRealizados;
        }


        return montoACobrar;

    }

}