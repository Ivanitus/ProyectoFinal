using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar las minas del boss final (tanque)
public class MinaBossTanque : MonoBehaviour {

    public GameObject explosion;

    // Start is called before the first frame update
    void Start() {
      
        

    }

    // Update is called once per frame
    void Update() {
        


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) { // si choca con el jugador

            explotar();

            ControladorVidaJugador.instancia.hacerDano();

            GestorAudio.instancia.reproducirSFX(3);

        }

    }

    public void explotar() {

        Destroy(gameObject); // destruyo la mina

        GestorAudio.instancia.reproducirSFX(3); // reproduzco el sonido de la conexion

        Instantiate(explosion, transform.position, transform.rotation); // instancio la animacion de la explosion

    }

}
