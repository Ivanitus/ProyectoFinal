using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para activar la batalla contra el boss
public class ActivadorBoss : MonoBehaviour {

    public GameObject batallaBoss;

    // Start is called before the first frame update
    void Start() {


        
    }

    // Update is called once per frame
    void Update() {
      
        

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) { // si el jugador entra en la zona

            batallaBoss.SetActive(true); // se activa el boss
            
            gameObject.SetActive(false); // se desactiva el activador

            ControladorVidaJugador.instancia.vidasJugadorActuales = 1;

            ControladorGUI.instancia.actualizarVidasJugador();

            ControladorGUIBatallaFinal.instancia.activarImagenesTexto(); // se muestra la vida del boss y su nombre

            GestorAudio.instancia.reproducirMusicaBoss();

        }

    }

}
