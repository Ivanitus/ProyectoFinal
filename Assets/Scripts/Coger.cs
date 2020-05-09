using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para gestionar la accion de coger los coleccionables (gemas, etc)
public class Coger : MonoBehaviour {

    public bool isGema;

    public bool isCereza;

    private bool isRecogido;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player") && !isRecogido) {

            if (isGema) {

                GestorNivel.instancia.gemasRecogidas++;

                isRecogido = true;

                Destroy(gameObject);

                ControladorGUI.instancia.actualizarContadorGemas();

            }

            if (isCereza) {

                if (ControladorVidaJugador.instancia.vidasActuales != ControladorVidaJugador.instancia.vidasMaximas) {

                    ControladorVidaJugador.instancia.curarJugador();

                    isRecogido = true;

                    Destroy(gameObject);

                }

            }

        }

    }

}
