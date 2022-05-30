using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public static class InterpretadorJson
{
    public static object ConvertirdeJsonAObjeto(string RutaFichero, string TipoObjeto)
    {
        string StringJson = string.Empty;

        if (RutaFichero == null)
            return null;

        using (StreamReader r = new StreamReader(RutaFichero))
        {
            StringJson = r.ReadToEnd();
        }
        Debug.Log(StringJson);
        switch (TipoObjeto)
        {
            case "Nave":

                return JsonUtility.FromJson<Nave>(StringJson);
                break;
        }
        return null;
    }

    public static List<T> ObtenerListadoTodosFicheros<T>(string RutaDirectorio, string TipoObjeto)
    {
        List<T> res = new List<T>();
        string[] listaFicheros;

        if (!Directory.Exists(RutaDirectorio))
            return res;

        listaFicheros = Directory.GetFiles(RutaDirectorio,"*.json");
        
        foreach (var rutaFichero in listaFicheros)
        {
            Debug.Log("ruta es: "+rutaFichero);
            res.Add((T)ConvertirdeJsonAObjeto(rutaFichero, TipoObjeto));
        }
        
        return res;



    }

}
