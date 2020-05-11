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
        
        if (collision.CompareTag("Player")) {

            ControladorCheckpoint.instancia.desactivarCheckpoints();

            renderizador.sprite = checkpointActivo;

            ControladorCheckpoint.instancia.guardarPuntoSpawn(transform.position);

            //GestorAudio.instancia.reproducirSFX(12);

        }

    }

    public void resetCheckpoint() {

        renderizador.sprite = checkpointDesactivado;

    }

}
