using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar el jugador de la pantalla de seleccion de nivel
public class JugadorSN : MonoBehaviour {

    public PuntoMapa puntoActual;

    public float velocidadMovimiento;

    private bool cargandoNivel;

    public GestorSeleccionNivel gestor;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        transform.position = Vector3.MoveTowards(transform.position, puntoActual.transform.position, velocidadMovimiento * Time.deltaTime);

        if (Vector3.Distance(transform.position, puntoActual.transform.position) < .1f && !cargandoNivel) { // Bloqueo el input si el personaje se está moviendo

            if (Input.GetAxisRaw("Horizontal") > .5f) { // Derecha

                if (puntoActual.derecha != null) {

                    setSiguientePunto(puntoActual.derecha);

                }

            } else if (Input.GetAxisRaw("Horizontal") < -.5f) { // Izquierda

                if (puntoActual.izquierda != null) {

                    setSiguientePunto(puntoActual.izquierda);

                }

            } else if (Input.GetAxisRaw("Vertical") > .5f) { // Arriba

                if (puntoActual.arriba != null) {

                    setSiguientePunto(puntoActual.arriba);

                }

            } else if (Input.GetAxisRaw("Vertical") < -.5f) { // Abajo

                if (puntoActual.abajo != null) {

                    setSiguientePunto(puntoActual.abajo);

                }

            }

            if (puntoActual.puntoNivel && puntoActual.nombreNivel != "" && !puntoActual.bloqueado) { // si el nivel esta desbloqueado

                ControladorGUISN.instancia.mostrarInformacion(puntoActual);

                if (Input.GetButtonDown("Submit")) {

                    cargandoNivel = true;

                    gestor.cargarNivel();

                }

            }

        }

    }

    private void setSiguientePunto(PuntoMapa siguientePunto) { // establezco el siguiente punto por el que te tienes que desplazar por el mapa

        puntoActual = siguientePunto;

        ControladorGUISN.instancia.ocultarInformacion();

        GestorAudio.instancia.reproducirSFX(5);

    }

}
