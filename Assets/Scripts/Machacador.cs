using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar el machacador
public class Machacador : MonoBehaviour {

    public Transform machacador, objetivoMachacador;

    private Vector3 puntoInicio;

    public float velocidadMachacar, tiempoEsperaMachacar, velocidadReseteo;

    private float contadorTiempoEspera;

    private bool machacando, reseteando;

    // Start is called before the first frame update
    void Start() {

        puntoInicio = machacador.position;

    }

    // Update is called once per frame
    void Update() {
        
        if (!machacando && !reseteando) { // si no esta cayendo ni reseteando

            if (Vector3.Distance(objetivoMachacador.position, ControladorJugador.instancia.transform.position) < 2f) { // si la distancia es menor de 2 con el jugador

                machacando = true;

                contadorTiempoEspera = tiempoEsperaMachacar;

            }

        }

        if (machacando) { // si esta cayendo

            machacador.position = Vector3.MoveTowards(machacador.position, objetivoMachacador.position, velocidadMachacar * Time.deltaTime); // movemos el machacador hacia el objetivo

            if (machacador.position == objetivoMachacador.position) {

                contadorTiempoEspera -= Time.deltaTime;

                if (contadorTiempoEspera <= 0) {

                    machacando = false;

                    reseteando = true;

                }

            }

        }

        if (reseteando) { // si esta reseteando

            machacador.position = Vector3.MoveTowards(machacador.position, puntoInicio, velocidadReseteo * Time.deltaTime);

            if (machacador.position == puntoInicio) {

                reseteando = false;

            }

        }

    }

}
