using System; 
namespace EspacioCliente; 

public class Cliente
{ 
    private string nombre; 
    private string direccion; 
    private string ? telefono;
    private string DatosRefCliente;

    public Cliente()
    {
        
    }
    public Cliente(string nom,string dire,string telefono,string datref)

    {
        this.nombre=nom;
        this.direccion=dire;
        this.telefono = telefono; 
        this.DatosRefCliente = datref;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string getNombre(){
        return this.nombre;
    }
    public string Telefono { get => telefono; set => telefono = value;  }
    // public string Direccion { get => direccion;  }
    public string Direccion (){
        return this.direccion;
    }
     public void setDireccion (string direcc){
        this.direccion = direcc;
    }
    
    public string DatosRefCliente1 { get => DatosRefCliente; set => DatosRefCliente = value; }
       public override string ToString()
    {
        return $"Dirección: {direccion}, \nNombre Cliente: {nombre},  \nTeléfono: {telefono}, \n Datos de Referencia: {DatosRefCliente}";
    }

   
}