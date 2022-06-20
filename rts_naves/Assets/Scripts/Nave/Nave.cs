using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TipoNave
{
    Crucero,
    Fragata,
    Bombardero,
    Caza,
    PortaTropas,
    PortaCazas,
    Suministros
}

[System.Serializable]
public class Nave
{
    public int Id;
    public Modulo[,] MatrizModulos;
    public Nave[] ListaNavesEnHangar;
    //public TipoNave TipoDeNave;
    public float Precio;
    public float Defensa;//Este se calculará según los modulos
    public float Ataque;//Este se calculará según los modulos
    public float Escudos;//Este se calculará según los modulos
    public float Vida;
    public float Velocidad;//Este se calculará según los modulos
    public float DanoInflingido;//Este se calculará según los modulos
    public float DanoRecibido;//Este se calculará según los modulos
    public int NumeroNaves;
    public int NumeroTropas;
    public int NumeroMunicion;
    public Vector3 Posicion;
    public GameObject Modelo;
    public string RutaPrefab;
    public Vector3 Escala;
    public string Nombre;
    public bool Colocada;

    public void CargarModelo()
    {
        Modelo = (GameObject)Resources.Load(RutaPrefab, typeof(GameObject));
        //this.Modelo = Instantiate(this.Modelo, this.Posicion, Quaternion.Euler(new Vector3(0, 0, 0)));
        this.Modelo.name = "Nave-"+Id.ToString();
        this.Modelo.transform.position = this.Posicion;
        this.Colocada = false;

        //Modelo.transform.localScale = Escala;
    }

}
