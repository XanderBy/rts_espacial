using System;
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

}
