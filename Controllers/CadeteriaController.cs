using Microsoft.AspNetCore.Mvc;
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
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}