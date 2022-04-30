using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TipoModulo
{
    Hospital,
    CargueroMilitar,
    CargueroSanitario,
    ZonasComunes,
    Dormitorios,
    Laser,
    Canon,
    Escudo,
    Hangar,
    Motor,
    Propulsor
}

public class Modulo
{
    private TipoModulo TipoDeModulo;
    private float Dano;
    private float Vida;
    private float Escudos;
    private float DanoInflingido;
    private float DanoRecibido;
    private int CantidadCarga;
    private int NumeroTropas;
    private int NumeroNaves;
    private Nave[] ListaNavesEnHangar;

}
