using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para activar-desactivar checkpoint
public class Checkpoint : MonoBehaviour {

    public SpriteRenderer renderizador;

    public Sprite checkpointActivo, checkpointDesactivado;

    // Start is called before the first frame update
    void Start() {
        


    }

    // Update is called once per frame
    void Update() {



    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) { // si lo toca el jugador, se activa el checkpoint

            ControladorCheckpoint.instancia.desactivarCheckpoints(); // primero desactivo todos los checkpoints

            renderizador.sprite = checkpointActivo; // activo el checkpoint

            ControladorCheckpoint.instancia.guardarPuntoSpawn(transform.position); // se guarda el punto de spawn

        }

    }

    public void resetCheckpoint() {

        renderizador.sprite = checkpointDesactivado;

    }

}
