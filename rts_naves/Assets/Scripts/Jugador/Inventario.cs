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
        Nave EjemploNave = (Nave)InterpretadorJson.ConvertirdeJsonAObjeto("Assets/Json/Naves/EjemploNave.json", typeof(Nave).Name);
        Debug.Log(EjemploNave.RutaPrefab);
        EjemploNave.CargarModelo();
        ListaNaves.Add(EjemploNave);
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

    private void CargarNavesEnListaInventario()
    {

    }

    private void CargarIventarioEnListView()
    {
        //TODO
        GameObject botonPrueba = Instantiate(PrefabBoton) as GameObject;
        botonPrueba.SetActive(true);

        botonPrueba.transform.SetParent(Contenido.transform, false);
        //var button = GetComponent<UnityEngine.UI.Button>();
        //button.onClick.AddListener(() => FooOnClick());

        GameObject botonPrueba2 = Instantiate(PrefabBoton) as GameObject;
        botonPrueba2.SetActive(true);
        botonPrueba2.transform.SetParent(Contenido.transform, false);
        botonPrueba2.transform.position = new Vector3(Contenido.transform.position.x, Contenido.transform.position.y - 50);

        GameObject botonPrueba3 = Instantiate(PrefabBoton) as GameObject;
        botonPrueba3.SetActive(true);
        botonPrueba3.transform.SetParent(Contenido.transform, false);
        botonPrueba3.transform.position = new Vector3(Contenido.transform.position.x, Contenido.transform.position.y - 100);
    }

    private void InstanciarNave( Nave NaveAInstanciar)
    {
        NaveAInstanciar.Modelo = Instantiate(NaveAInstanciar.Modelo, NaveAInstanciar.Posicion, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
