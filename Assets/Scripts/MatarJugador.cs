using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarJugador : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) { // si se choca con el jugador

            GestorAudio.instancia.reproducirSFX(8);

            if (ControladorVidaJugador.instancia.vidasJugadorActuales > 0) {

                GestorNivel.instancia.RespawnearJugador(); // respawnea el jugador

            } else {

                GestorNivel.instancia.muerteJugador(); // mata al jugador

            }

        }

    }

}
