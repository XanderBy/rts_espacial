using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    public GameObject Contenido;
    public GameObject PrefabBoton;
    public List<Nave> ListaNaves;
    public List<GameObject> ListaBotones;
    public Nave NaveSeleccionadaInventario;
    public GameObject MenuContextualInferior;

    // Start is called before the first frame update
    void Start()
    {
        ListaBotones= new List<GameObject>();
        ListaNaves = new List<Nave>();
        ListaNaves = InterpretadorJson.ObtenerListadoTodosFicheros<Nave>("Assets/Json/Naves/", typeof(Nave).Name);

        cargarModeloListadoNaves();
        CargarIventarioEnListView();

    }
    void FooOnClick()
    {
        Debug.Log("Ta-Da!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void cargarModeloListadoNaves()
    {

        foreach (var nave in ListaNaves)
        {
            nave.CargarModelo();
            //nave.Modelo = Instantiate(nave.Modelo, nave.Posicion, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
    private void CargarNavesEnListaInventario()
    {

    }

    private void CargarIventarioEnListView()
    {
        LimpiarListadoBotones();
        float posicionYVariableBoton = Contenido.transform.position.y;
        foreach (var nave in ListaNaves)
        {
            
            if (!nave.Colocada)
            {
                GameObject botonInventario = Instantiate(PrefabBoton) as GameObject;
                botonInventario.GetComponentInChildren<Text>().text = nave.Nombre;
                botonInventario.name = "BotonInventario-" + nave.Id;
                botonInventario.SetActive(true);
                botonInventario.transform.SetParent(Contenido.transform, false);
                posicionYVariableBoton -= ((RectTransform)botonInventario.transform).rect.height;
                botonInventario.transform.position = new Vector3(Contenido.transform.position.x, posicionYVariableBoton);
                ListaBotones.Add(botonInventario);
            }
                
        }
    }

    public void InstanciarNave( Nave NaveAInstanciar)
    {
        NaveAInstanciar.Colocada = true;
        NaveAInstanciar.Modelo = Instantiate(NaveAInstanciar.Modelo, NaveAInstanciar.Posicion, Quaternion.Euler(new Vector3(0, 0, 0)));
        //var BotonABorrar=this.ListaBotones.Find((a) => a.name == "BotonInventario-" + NaveAInstanciar.Id);
        //this.ListaBotones.Remove(BotonABorrar);
        //Destroy(BotonABorrar);
        CargarIventarioEnListView();
    }

    public void LimpiarListadoBotones()
    {
        Debug.Log(this.ListaBotones.Count);
        foreach (var boton in this.ListaBotones)
            Destroy(boton);

        ListaBotones.Clear();
    }

}
