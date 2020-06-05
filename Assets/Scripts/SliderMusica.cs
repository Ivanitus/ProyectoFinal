using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Clase para controlar el slider de la musica
public class SliderMusica : Sliders {

    public static SliderMusica instancia;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

        textoPorcentaje.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("VolumenMusica") * 100) + "%";

        slider.SetValueWithoutNotify(PlayerPrefs.GetFloat("VolumenMusica"));

    }

    // Update is called once per frame
    void Update() {



    }

    public void escribirDatos() {

        PlayerPrefs.SetFloat("VolumenMusica", slider.value); // guardo los datos

    }

}
