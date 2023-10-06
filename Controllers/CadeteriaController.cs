using Microsoft.AspNetCore.Mvc;
using Models;



namespace tl2_tp4_2023_AngelMatiasA.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    

    private readonly ILogger<WeatherForecastController> _logger;
    private Cadeteria cadeteria; 


    public CadeteriaController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.Instance;
        
    } 

    [HttpGet("Cadetes")]
    public ActionResult<List<Cadete>> getCadetes(){
        var cadetes = cadeteria.getListaCadetes();
        return Ok(cadetes);
    }
     [HttpGet("Pedidos")]
    public ActionResult<List<Pedidos>> GetPedidos(){
        var pedidos = cadeteria.getListaPedidos();
        return Ok(pedidos);
    }
    [HttpPost("Pedido")]
    public ActionResult<Pedidos> agregarPedido(Pedidos pedido){
        var pedidoAgregado = cadeteria.agregarPedido(pedido);
        if (pedidoAgregado!=null)
        {
             
            return Ok(pedidoAgregado);
            
        }
        return BadRequest(null);
         

    }

    [HttpPut("Asignar")]
    public ActionResult<bool> AsignarPedido(int idPedido, int idCadete)
    {
        var asignado = cadeteria.asignarPedidos(idPedido, idCadete);
        if (asignado)
        {
            return Ok(asignado);
            
        }
        return BadRequest(null);
    }

    [HttpPut("Estado")]
    public ActionResult<Pedidos> CambiarEstadoPedido(int idPedido,int NuevoEstado)
    {
        var pedido = cadeteria.cambiarEStadoPedido(idPedido, NuevoEstado);
        if (pedido!= null)
        {
            return Ok(pedido);
            
        }
        return BadRequest(null);
    }

       
    [HttpPut("CambioCadete")]
    public ActionResult<bool> CambiarCadetePedido(int idPedido,int idNuevoCadete)
    {
        var reasignado = cadeteria.reasignarPedidos(idPedido, idNuevoCadete);
        if (reasignado)
        {
            return Ok(reasignado);
            
        }
        return BadRequest(null);
    }

/* 
c) Cree un Controlador Para la cadetería llamado CadeteriaController, y en el
Implemente un endpoint para cada una de las operaciones ya existentes,
siguiendo la siguiente forma:
● [Get] GetPedidos() => Retorna una lista de Pedidos
● [Get] GetCadetes() => Retorna una lista de Cadetes
● [Get] GetInforme() => Retorna un objeto Informe
● [Post] AgregarPedido(Pedido pedido)
● [Put] AsignarPedido(int idPedido, int idCadete)
● [Put] CambiarEstadoPedido(int idPedido,int NuevoEstado)
● [Put] CambiarCadetePedido(int idPedido,int idNuevoCadete)
Recuerde que debe siempre debe retornar una respuesta a cada petición, respetando los
códigos de estado vistos en clase.
Tip:
Se recomienda inicializar la cadeteria siguiendo un patrón Singleton, tal como se mostró
en la teoría.


*/
   
}