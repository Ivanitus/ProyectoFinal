using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar el trampolin
public class Trampolin : MonoBehaviour {

    private Animator animador;

    public float fuerzaRebote;

    // Start is called before the first frame update
    void Start() {

        animador = GetComponent<Animator>(); // cargo el animador del juego

    }

    // Update is called once per frame
    void Update() {
        


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) { // si el jugador lo toca

            GestorAudio.instancia.reproducirSFX(10); // se reproduce el sonido de salto

            ControladorJugador.instancia.rigidbody.velocity = new Vector2(ControladorJugador.instancia.rigidbody.velocity.x, fuerzaRebote); // hago que el jugador salte

            animador.SetTrigger("Rebotar"); // activo el trigger rebotar para activar la animación de salto

        }

    }

}
