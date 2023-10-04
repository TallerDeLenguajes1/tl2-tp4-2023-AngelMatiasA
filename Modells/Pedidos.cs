using System;
using System.Net.WebSockets;
using EspacioCliente;
using EspacioCadete;
namespace EspacioPedidos;

public class Pedidos
{
    private static int id = 0;
    private int nroPedido;
    private string observacion;
    private Cliente clienteNuevo;

    private Cadete cadetePed;
    // bool entregado = false; 
    string[] arregloEstados = { "Sin Asignar", "En Proceso", "Realizado" };
    private string estado = "";
    private int idCadete;

    public int NroPedido { get => nroPedido; }
    public Cadete CadetePed {get => cadetePed; set => cadetePed = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public string Estado { get => estado; set => estado = value; }

    public Pedidos()
    {
        nroPedido = id++;
        this.idCadete = 0;
        this.estado = arregloEstados[0];
        clienteNuevo = new Cliente();
    }
    public Pedidos(string observacion, string nomcli, string clidire, string cliTelefono, string cliDatRef)
    {
        this.nroPedido = id++;
        this.observacion = observacion;
        this.estado = arregloEstados[0];
        clienteNuevo = new Cliente(nomcli, clidire, cliTelefono, cliDatRef);
        this.idCadete = 0;
    }
    public string getarreglosEstados(int index)
    {
        return arregloEstados[index];
    }
    public int getIdCadetePedidos()
    {
        return this.idCadete;
    }
    public void setIdCadetePedidos(int CadeteId)
    {
        this.idCadete = CadeteId;
    }



    public string NombreClien()
    {
        string nombre = this.clienteNuevo.getNombre();
        return nombre;
    }
    public void SetNombreClien(string nombre)
    {
        this.clienteNuevo.Nombre = nombre;

    }
    public void SetClienDirecc(string direc)
    {
        this.clienteNuevo.setDireccion(direc);

    }
    public void SetClienTelefono(string tel)
    {
        this.clienteNuevo.Telefono = tel;

    }
    public void SetClienDatosRef(string refclien)
    {
        this.clienteNuevo.DatosRefCliente1 = refclien;

    }

    public void VerDireccionCliente()
    {
        Console.WriteLine("Dirección " + clienteNuevo.Direccion());
    }
    public void VerDatosCliente()
    {
        Console.WriteLine("Datos de referencia:  " + clienteNuevo.DatosRefCliente1);
        Console.WriteLine("Telefono:  " + clienteNuevo.Telefono);

    }
    public override string ToString()

    {
        string infoCliente = clienteNuevo.ToString();
        return $"       Pedido nro: {nroPedido}\n" +
         $"Estado: {estado}\n" +
               $"{infoCliente}\n" +
               $"Observación: {observacion}\n" +
               $"Id Cadete al que pertenece: {idCadete}";

    }
}