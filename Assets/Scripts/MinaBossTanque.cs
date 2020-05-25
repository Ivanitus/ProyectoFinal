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
        
        if (collision.CompareTag("Player")) {

            explotar();

            ControladorVidaJugador.instancia.hacerDano();

            GestorAudio.instancia.reproducirSFX(3);

        }

    }

    public void explotar() {

        Destroy(gameObject);

        GestorAudio.instancia.reproducirSFX(3);

        Instantiate(explosion, transform.position, transform.rotation);

    }

}
