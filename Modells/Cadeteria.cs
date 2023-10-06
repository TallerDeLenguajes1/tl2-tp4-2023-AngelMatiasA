using System;
using System.Linq;
using EspacioDatos;
using System.Text.Json;

        

namespace Models;  


public class Cadeteria
{
    private static Cadeteria instance = null;
    private static readonly object lockObject = new object();
    private static AccesoCSV accesoCsv; 
    private static AccesoJSON accesoJson;
    private static Informe informe;
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
   public static Cadeteria Instance
   {
        get
        {
            lock(lockObject)
            {
                if(instance == null)
                {
                    accesoJson = new AccesoJSON();
                    accesoCsv = new AccesoCSV();
                    instance = new Cadeteria();
                    instance = Cadeteria.accesoJson.cargarCadeteria("Cadeteria.json");
                    instance.Cadetes = Cadeteria.accesoJson.cargarCadetes("Cadete.json");
                    instance.asignarPedidosTesting(accesoCsv.CargarPedidos("Pedidos.csv"));


                }
                return instance;
            }
        }
   }

   public string NombreCadeteria { get; set; }
    public string TelefonoCadeteria { get; set; }
    public List<Cadete>? Cadetes {  get => cadetes; set => cadetes = value; }

     public string getInformeJson(){
        informe = new Informe(instance); 
        string informeJson = JsonSerializer.Serialize(informe);
        return informeJson;
   }

   
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
    public Pedidos agregarPedido(Pedidos pedido){
        lisPedCadeteria.Add(pedido);
        return pedido;
    }



    public Pedidos cambiarEStadoPedido(int idPedido, int estado){
        Pedidos pedido = null;
        estado --;
         pedido = this.lisPedCadeteria.FirstOrDefault(p=>p.NroPedido == idPedido); 
        if (pedido!= null){
            pedido.Estado = pedido.getarreglosEstados(estado);
        }
        return pedido;

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
 
 /*EN ESTE CASO SERIA MEJOR QUE DEVUELVA UN PEDIDO ?*/
     public bool asignarPedidos(int idPedido, int idCadete)
    {
        var asignado = false;
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
            asignado = true;
          
        }
    }
        return asignado;
    }


    
    public List<Cadete> mostrarCadetes()
    {
        
        return this.cadetes;
    } 
   
//hacerlo q busqe x id tmb.. hya una pequeña incongruencia cuando el usuario
//no ingresa el nombre o no coincide.. igual se le remueve de la lista del otro
//usuario.. estaria bueno una tipo promesa...
    public bool reasignarPedidos(int idPedido, int idCadete)
    {
        var reasignado = asignarPedidos(idPedido, idCadete);
        return reasignado;
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