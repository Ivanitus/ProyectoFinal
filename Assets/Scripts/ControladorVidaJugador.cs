using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar la vida del jugador
public class ControladorVidaJugador : MonoBehaviour {

    public static ControladorVidaJugador instancia; // Singleton

    public int vidasActuales, vidasMaximas;

    // Metodo sobreescrito de Unity que se ejecuta justo antes de Start()
    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

        vidasActuales = vidasMaximas;

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void hacerDano() {

        vidasActuales--;

        if(vidasActuales <= 0) {

            gameObject.SetActive(false); //gameObject hace referencia al objeto al que está anclado el script

        }

    }

}
