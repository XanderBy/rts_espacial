using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{

    public GameObject Contenido;
    private List<Nave> ListaNaves;
    // Start is called before the first frame update
    void Start()
    {
        CargarNaves();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CargarNaves()
    {
        //TODO: Hacer que cargue todo el directorio de naves en ListaNaves
    }
}
