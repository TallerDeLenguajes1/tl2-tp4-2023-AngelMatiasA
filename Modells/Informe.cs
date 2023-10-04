using EspacioCadeteria; 
using EspacioCadete;
using EspacioPedidos;
using System.Linq;
using System.Collections; 
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace EspacioInforme; 

public class Informe
{ 
    /*Mostrar  el monto ganado  y la cantidad de envíos de cada cadete y el totalEnvixCad. 
    Muestre también la cantidad de envíos promedio por cadete. */
   private double enviPromedXCadete; 
   private int totalEnvios;
   Cadeteria cadeteria; 
   private List<LisInforme> nuevaLisInf;


    public int TotalEnvios { get => totalEnvios; set => totalEnvios = value; }
    public double EnviPromedXCadete { get => enviPromedXCadete; set => enviPromedXCadete = value; }
    public List<LisInforme> NuevaLisInf {  get => nuevaLisInf; set => nuevaLisInf = value; }

    public Informe (){     
   }

   public Informe (Cadeteria nuevacadeteria){
         nuevaLisInf = new List<LisInforme>();
      
        CargarInforme( nuevacadeteria);
   
   }

    public  void CargarInforme (Cadeteria nuevacadeteria){
          this.cadeteria = nuevacadeteria;
          int totalEnvixCad= 0; 
          LisInforme lisinforme;
          int cantidadDeCadetes = cadeteria.getListaCadetes().Count;
          nuevaLisInf = new List<LisInforme>();

       
        foreach (Cadete cadete in this.cadeteria.getListaCadetes())
        {
            totalEnvixCad = 0; 
        lisinforme = new LisInforme();
                            
            Console.WriteLine($"el pedido es para {cadete.Direccion} cadete nro {cadete.Nombre}");

          
            totalEnvixCad = cadeteria.getListaPedidos()
            .Where(
                pedido => String.Equals(pedido.Estado, pedido.getarreglosEstados(2), StringComparison.OrdinalIgnoreCase) 
                && pedido.CadetePed != null && pedido.CadetePed.Id == cadete.Id
                ).ToList().Count;
            lisinforme.CantPorCadete = totalEnvixCad;
            lisinforme.MontoGanado =totalEnvixCad *500;
            lisinforme.NombreCadete=cadete.Nombre; 
            lisinforme.IdCadete=cadete.Id; 
            nuevaLisInf.Add(lisinforme); 
            TotalEnvios +=  totalEnvixCad;
        } 
        EnviPromedXCadete = Convert.ToDouble(totalEnvios) / Convert.ToDouble(cantidadDeCadetes);

    } 
    public void mostrarInforme (){
        Console.WriteLine("Informe \n \n "); 
        Console.WriteLine($"El total de envios es de {totalEnvios}");
        
        Console.WriteLine($"El promedio de envios por cadetes  es de {EnviPromedXCadete}");
        
        foreach (var inform in this.nuevaLisInf)
        {
            Console.WriteLine("Cadete nro " + inform.getIdCade());
            Console.WriteLine("Nombre : "+ inform.getNomCade());
            Console.WriteLine("Cantidad de envios"+ inform.getCantxCade());
            Console.WriteLine("Monto ganado "+ inform.getMontoGanadoCade());
        }

    }
        public double montosGanado(List<Cadete> cadetes){
        double totalEnvixCad = 0; 
        foreach (Cadete cadete in cadetes)
        {
            // foreach (Pedidos pedido in cadete.ListaPedidos)
            // {
            //     if(pedido.Estado == pedido.getarreglosEstados(2)){
            //         totalEnvixCad +=500;
            //     }
            // }
            
            
        }

        return totalEnvixCad;
    }
    
}//fin de la clase Informe

//comienza la clase ejecinforme


public class LisInforme
{

   private int idCadete= 0;
   private string nombreCadete = "" ; 
   private int cantPorCadete = 0;
   private double montoGanado= 0.0; 
    
   

    public int IdCadete {  get => idCadete; set => idCadete = value; }
    public string NombreCadete {  get => nombreCadete; set => nombreCadete = value; }
    public int CantPorCadete {  get => cantPorCadete; set => cantPorCadete = value; }
    public double MontoGanado {  get => montoGanado; set => montoGanado = value; }
   

    public LisInforme(){

   }
    public LisInforme(int id, string nombre, int cant, double ganancias){ 
       
        this.idCadete = id; 
        this.nombreCadete = nombre; 
        this.cantPorCadete = cant; 
        this.montoGanado = ganancias;

   }
      public int getIdCade(){

    return this.idCadete;
   }
   public void setIdCade(int id){

     this.idCadete = id;
   }
   public int getCantxCade(){

    return this.cantPorCadete;
   }
   public void setCantxCade(int cant){

     this.cantPorCadete = cant;
   }
     public string getNomCade(){

    return this.nombreCadete;
   }
   public void setNomCade(string nombre){

     this.nombreCadete = nombre;
   }
   
  
     public double getMontoGanadoCade(){

    return this.montoGanado;
   }
   public void setMontoGanadoCade( double ganado){

     this.montoGanado = ganado;
   }

}