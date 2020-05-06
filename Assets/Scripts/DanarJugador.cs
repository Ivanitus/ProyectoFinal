using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para detectar cuando recibe daño el jugador
public class DanarJugador : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Metodo sobreescrito de Unity que detecta cuando se produce una colision
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag=="Player") {

            //Debug.Log("Detectada colision");

            ControladorVidaJugador.instancia.hacerDano();

        }

    }

}
