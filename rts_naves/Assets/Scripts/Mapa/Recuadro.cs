using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recuadro 
{

    public bool Mostrar;

    private bool _Ocupado;
    private int Ancho;
    private int _Alto;
    private Vector3 PosicionInicio;
    private Vector3 PosicionFin;
    private bool _Clickado;
    public GameObject Cubo;

    public bool Clickado
    {
        get { return _Clickado; }
        set { _Clickado = value; }
    }
    public bool Ocupado
    {
        get { return _Ocupado; }
        set { _Ocupado = value; }
    }
    public int Alto
    {
        get { return _Alto; }
    }

    public Recuadro()
    {

    }

    public Recuadro(Vector3 PosicionInicio, Vector3 PosicionFin, int Ancho, int Alto, string Id)
    {
        this.PosicionInicio = PosicionInicio;
        this.PosicionFin = PosicionFin;
        this.Cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.Cubo.transform.position = PosicionInicio;

        Vector3 escala = this.Cubo.transform.localScale;
        escala.x = escala.x * Ancho;
        escala.z = escala.z * Alto;
        this.Cubo.transform.localScale = escala;
        this.Cubo.name = Id;
        this.Ancho = Ancho;
        this._Alto = Alto;
        Mostrar = true;
        Clickado = false;
        Ocupado = false;



    }

}
