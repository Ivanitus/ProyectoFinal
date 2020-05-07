using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestionara el nivel
public class GestorNivel : MonoBehaviour {

    public static GestorNivel instancia; // Singleton

    public float tiempoEsperaRespawn;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {
        


    }

    // Update is called once per frame
    void Update() {
        


    }

    public void RespawnearJugador() {

        StartCoroutine(RespawnCO()); // StartCoroutine() comienza la ejecucion de una corutina

    }

    private IEnumerator RespawnCO() { // Una CO es una corutina que se ejecuta de forma paralela al flujo de ejecución normal del juego

        ControladorJugador.instancia.gameObject.SetActive(false);

        yield return new WaitForSeconds(tiempoEsperaRespawn); // yield return le dice a RespawnCO que tiene que esperar a que sea true lo que retorne

        ControladorJugador.instancia.gameObject.SetActive(true);

        ControladorJugador.instancia.transform.position = ControladorCheckpoint.instancia.puntoSpawn;

        ControladorVidaJugador.instancia.vidasActuales = ControladorVidaJugador.instancia.vidasMaximas;

        ControladorGUI.instancia.actualizarVidasGUI();

    }

}
