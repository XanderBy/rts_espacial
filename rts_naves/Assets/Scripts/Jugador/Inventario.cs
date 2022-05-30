using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    public GameObject Contenido;
    public GameObject PrefabBoton;
    private List<Nave> ListaNaves;
    private Nave NaveSeleccionada;

    // Start is called before the first frame update
    void Start()
    {
        ListaNaves= new List<Nave>();
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
            nave.Modelo = Instantiate(nave.Modelo, nave.Posicion, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
    private void CargarNavesEnListaInventario()
    {

    }

    private void CargarIventarioEnListView()
    {

        float posicionYVariableBoton = Contenido.transform.position.y;
        foreach (var nave in ListaNaves)
        {
            GameObject botonInventario = Instantiate(PrefabBoton) as GameObject;
            botonInventario.GetComponentInChildren<Text>().text = nave.Nombre;
            botonInventario.SetActive(true);
            botonInventario.transform.SetParent(Contenido.transform, false);
            posicionYVariableBoton -= ((RectTransform)botonInventario.transform).rect.height;
            botonInventario.transform.position = new Vector3(Contenido.transform.position.x, posicionYVariableBoton);
        }
    }

    private void InstanciarNave( Nave NaveAInstanciar)
    {
        NaveAInstanciar.Modelo = Instantiate(NaveAInstanciar.Modelo, NaveAInstanciar.Posicion, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
