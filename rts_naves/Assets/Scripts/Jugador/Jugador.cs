using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    private Dictionary<KeyCode, bool> TeclaPresionada;
    private KeyCode[] ListaKey;

    private Dictionary<int, bool> RatonPresionado;
    private int[] ListaBotones;

    private Vector3 PosicionClick;
    private Mapa ScriptMapa;

    public GameObject MapaObjeto;
    public GameObject Objeto;
    public float VelocidadMovimiento;
    public float VelocidadMovimientoCamaraRaton;
    //private List<Nave> ListaNaves;
    public Inventario InventarioJugador;

    // Start is called before the first frame update
    void Start()
    {

        TeclaPresionada = new Dictionary<KeyCode, bool>();
        ListaKey = new KeyCode[] { KeyCode.LeftControl, KeyCode.Space, KeyCode.A, KeyCode.S, KeyCode.W, KeyCode.D };

        RatonPresionado = new Dictionary<int, bool>();
        ListaBotones = new int[] { 0, 1, 2 };

        ScriptMapa = MapaObjeto.GetComponent<Mapa>();
    }

    // Update is called once per frame
    void Update()
    {

        Teclado();

        Raton();

    }
    public void CargarDatosJugador()
    {
        /*TODO:
         * Cargar Naves del inventario
         * 
         * 
         */
        CargarNaves();


    }
    public void CargarNaves()
    {

    }

    private void Raton()
    {
        foreach (var boton in ListaBotones)
        {
            if (Input.GetMouseButtonDown(boton) || (RatonPresionado.ContainsKey(boton) && RatonPresionado[boton]))
            {
                Debug.Log(boton);
                if (!RatonPresionado.ContainsKey(boton))
                    RatonPresionado.Add(boton, true);

                switch (boton)
                {
                    case 0:
                        /*Debug.Log(ScriptMapa.ReacuadroDelMapa[0,0]);*/
                        GameObject ObjetoClickado = null;
                        PosicionClick = Input.mousePosition;
                        RaycastHit hit;
                        Ray ray = Camera.main.ScreenPointToRay(PosicionClick);
                        if (Physics.Raycast(ray, out hit))
                        {
                            ObjetoClickado = hit.transform.gameObject;
                        }

                        if (InventarioJugador != null)
                        {
                            foreach (var botonInventario in InventarioJugador.ListaBotones)
                            {
                                botonInventario.GetComponent<Button>().onClick.AddListener(() =>
                                {
                                    Debug.Log(botonInventario.name);
                                    int idNave = Convert.ToInt32(botonInventario.name.Split('-')[1]);
                                    Debug.Log("Id Nave: " + idNave);
                                    ScriptMapa.ModoColocacionNave = true;
                                    InventarioJugador.NaveSeleccionada = InventarioJugador.ListaNaves.Find((a) => a.Id == idNave);
                                    Debug.Log("Nave seleccionada: " + InventarioJugador.NaveSeleccionada.Nombre);
                                });
                            }
                        }

                        foreach (var recuadro in ScriptMapa.ReacuadroDelMapa)
                        {
                            if (ObjetoClickado != null && recuadro.Cubo.name == ObjetoClickado.name)
                            {
                                if (recuadro.Clickado)
                                {
                                    recuadro.Clickado = false;
                                    ObjetoClickado.GetComponent<Renderer>().material.mainTexture = ScriptMapa.TexturaRecuadro;
                                }
                                else
                                {
                                    if (ScriptMapa.ModoColocacionNave & (InventarioJugador != null && InventarioJugador.NaveSeleccionada != null))
                                    {
                                        Debug.Log("Instanciar naveeeeeeeeeeeeeeeee");
                                        InventarioJugador.InstanciarNave(InventarioJugador.NaveSeleccionada);
                                    }
                                    else
                                    {
                                        recuadro.Clickado = true;
                                        ObjetoClickado.GetComponent<Renderer>().material.mainTexture = ScriptMapa.TexturaRecuadroPulsada;
                                    }

                                }

                            }
                        }


                        break;
                    case 1:

                        //Debug.Log("raton 1");
                        break;
                    case 2:
                        Objeto.transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * VelocidadMovimientoCamaraRaton, Input.GetAxis("Mouse X") * VelocidadMovimientoCamaraRaton, 0);
                        //Debug.Log("raton 2");
                        break;
                    default:
                        //Debug.Log("Error");
                        break;
                }


            }

            if (boton != 2 || (Input.GetMouseButtonUp(boton) & boton == 2))
            {
                RatonPresionado.Remove(boton);
            }
        }
    }

    private void Teclado()
    {
        foreach (var key in ListaKey)
        {
            if (Input.GetKeyDown(key) || (TeclaPresionada.ContainsKey(key) && TeclaPresionada[key]))
            {
                if (!TeclaPresionada.ContainsKey(key))
                    TeclaPresionada.Add(key, true);

                switch (key)
                {
                    case KeyCode.LeftControl:
                        Objeto.transform.position -= new Vector3(0, VelocidadMovimiento, 0);
                        //Debug.Log("Shift");
                        break;
                    case KeyCode.Space:
                        Objeto.transform.position += new Vector3(0, VelocidadMovimiento, 0);
                        //Debug.Log("Space");
                        break;
                    case KeyCode.A:
                        Objeto.transform.position -= new Vector3(VelocidadMovimiento, 0, 0);
                        //Debug.Log("A");
                        break;
                    case KeyCode.S:
                        Objeto.transform.position -= new Vector3(0, 0, VelocidadMovimiento);
                        //Debug.Log("S");
                        break;
                    case KeyCode.W:
                        Objeto.transform.position += new Vector3(0, 0, VelocidadMovimiento);
                        //Debug.Log("W");
                        break;
                    case KeyCode.D:
                        Objeto.transform.position += new Vector3(VelocidadMovimiento, 0, 0);
                        //Debug.Log("D");
                        break;
                    default:
                        Debug.Log("Error");
                        break;
                }
            }

            if (Input.GetKeyUp(key))
            {
                TeclaPresionada.Remove(key);
            }
        }
    }
}
