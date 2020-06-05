using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar slider activar musica
public class SliderActivarMusica : Sliders {

    public static SliderActivarMusica instancia;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

        slider.SetValueWithoutNotify(PlayerPrefs.GetInt("MusicaActivada"));

    }

    // Update is called once per frame
    void Update() {
        


    }

    public void escribirDatos() {

        PlayerPrefs.SetInt("MusicaActivada", (int)slider.value); // guardo las preferencias

    }

}
