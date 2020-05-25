using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Clase de la que heredaran los sliders de ajustes;
public class Sliders : MonoBehaviour {

    public Text textoPorcentaje;

    public Slider slider;

    // Start is called before the first frame update
    void Start() {
        


    }

    // Update is called once per frame
    void Update() {
        


    }

    public void actualizacionTexto(float valor) {

        textoPorcentaje.text = Mathf.RoundToInt(valor * 100) + "%";

    }

    public void escribirDatos() {



    }

}
