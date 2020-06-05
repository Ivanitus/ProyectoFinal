using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Clase de la que herederan las clases que controlan las interfaces graficas
public class ControladorInterfacesGraficas : MonoBehaviour {

    public Image pantallaTransicion;
    public float velocidadTransicion;
    protected bool debeTransicionANegro;
    protected bool debeTransicionDesdeNegro;

    // Start is called before the first frame update
    void Start() {
        

    }

    // Update is called once per frame
    void Update() {
        

    }

    public void transicinANegro() {

        debeTransicionANegro = true;
        debeTransicionDesdeNegro = false;

    }

    public void transicionDesdeNegro() {

        debeTransicionANegro = false;
        debeTransicionDesdeNegro = true;

    }

}
