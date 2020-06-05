using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar las balas del boss
public class BalaBoss : MonoBehaviour {

    public float velocidad;

    // Start is called before the first frame update
    void Start() {

        GestorAudio.instancia.reproducirSFX(2);

    }

    // Update is called once per frame
    void Update() {

        transform.position += new Vector3(-velocidad * transform.localScale.x * Time.deltaTime, 0f, 0f); // movimiento de la bala

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) { // si choca con el jugador, le hacemos daño

            ControladorVidaJugador.instancia.hacerDano();

        }

        GestorAudio.instancia.reproducirSFX(1); // se reproduce el sonido de impacto, toque a la superficie que toque

        Destroy(gameObject); // cuando impacta elimino la bala

    }

}
