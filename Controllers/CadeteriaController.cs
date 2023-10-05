using Microsoft.AspNetCore.Mvc;
using EspacioDatos;
using Models;

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

namespace tl2_tp4_2023_AngelMatiasA.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    

    private readonly ILogger<WeatherForecastController> _logger;
    private Cadeteria cadeteria; 
    private AccesoJSON datosJson;
    private AccesoCSV datosCsv;

    public CadeteriaController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        datosJson = new AccesoJSON();
        datosCsv = new AccesoCSV();
        cadeteria = datosJson.cargarCadeteria("Cadeteria.json"); 
        cadeteria.Cadetes = datosJson.cargarCadetes("Cadete.json");
        cadeteria.asignarPedidosTesting(datosCsv.CargarPedidos("Pedidos.csv"));
        
    } 

    [HttpGet(Name = "GetCadetes")]
    public ActionResult<List<Cadete>> getCadetes(){
        var cadetes = cadeteria.getListaCadetes();
        return Ok(cadetes);
    }

    /*[HttpGet(Name = "GetWeatherForecast")]
    */
}