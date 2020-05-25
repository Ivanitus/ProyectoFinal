using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar el slider de SFX de los ajustes 
public class SliderSFX : Sliders {

    public static SliderSFX instancia;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

        textoPorcentaje.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("VolumenSFX") * 100) + "%";

        slider.SetValueWithoutNotify(PlayerPrefs.GetFloat("VolumenSFX"));

    }

    // Update is called once per frame
    void Update() {
        


    }

    public void escribirDatos() {

        PlayerPrefs.SetFloat("VolumenSFX", slider.value);

    }

}
