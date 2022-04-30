using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour


{

    private Recuadro[,] _RecuadroDelMapa;
    private Nave[,] _MatrizNaves;

    public int AnchoMapa;
    public int AltoMapa;
    public int AnchoRecuadro;
    public int AltoRecuadro;
    public Texture2D TexturaRecuadro;
    public Texture2D TexturaRecuadroPulsada;

    public GameObject Jugador;
    public Enemigo JugadorEnemigo;


    public Recuadro[,] ReacuadroDelMapa
    {
        get { return _RecuadroDelMapa; }
        set { _RecuadroDelMapa = value; }
    }
    public Nave[,] MatrizNaves
    {
        get { return _MatrizNaves; }
        set { _MatrizNaves = value; }
    }


    void InicializarMapa()
    {

        ReacuadroDelMapa = new Recuadro[AnchoMapa, AltoMapa];


        for (int fila = 0; fila < AnchoMapa; fila++)
        {
            for(int columna = 0; columna < AnchoMapa; columna++)
            {
                var posicionInicio = new Vector3(columna * AnchoRecuadro, 0, fila * AltoRecuadro);
                var posicioFin = new Vector3(1, 1, 1);
                var recuadro= new Recuadro(posicionInicio, posicioFin, AnchoRecuadro, AltoRecuadro, fila.ToString() + columna.ToString());
                recuadro.Cubo.GetComponent<Renderer>().material.mainTexture = TexturaRecuadro;
                ReacuadroDelMapa[columna, fila] = recuadro;
            }
        }
        CargarNavesJugadorEnemigo();
    }
    private void CargarNavesJugadorEnemigo()
    {
        Nave EjemploNave= (Nave)InterpretadorJson.ConvertirdeJsonAObjeto("Assets/Json/Naves/EjemploNave.json", typeof(Nave).Name);
        Debug.Log(EjemploNave.RutaPrefab);
        EjemploNave.CargarModelo();
        
        
        Debug.Log(EjemploNave.Posicion);
        Debug.Log(EjemploNave.Ataque);
    }

    // Start is called before the first frame update
    void Start()
    {
        InicializarMapa();
        MatrizNaves = new Nave[AnchoMapa, AltoMapa];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
