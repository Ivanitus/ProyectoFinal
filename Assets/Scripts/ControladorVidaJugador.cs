using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar la vida del jugador
public class ControladorVidaJugador : MonoBehaviour {

    public static ControladorVidaJugador instancia; // Singleton

    public int vidasActuales, vidasMaximas;

    public float tiempoInvencible; // Variable para definir el tiempo de invencibilidad del jugador una vez reciba daño

    private float contadorInvencible;

    private SpriteRenderer renderizador;

    public GameObject efectoMuerte;

    // Metodo sobreescrito de Unity que se ejecuta justo antes de Start()
    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

        vidasActuales = vidasMaximas;

        renderizador = GetComponent<SpriteRenderer>(); // Cargo el SpriteRenderer

    }

    // Update is called once per frame
    void Update() {
        
        if (contadorInvencible > 0) {

            contadorInvencible -= Time.deltaTime; // Disminuyo el contador hasta llegar a 0

            if (contadorInvencible <= 0) {

                renderizador.color = new Color(renderizador.color.r, renderizador.color.g, renderizador.color.b, 1f); // Restauro el alfa del jugador

            }

        }

    }

    public void hacerDano() {

        if (contadorInvencible <= 0) { // Si el jugador no es invencible

            vidasActuales--;

            if (vidasActuales <= 0)
            {

                vidasActuales = 0;

                //gameObject.SetActive(false); //gameObject hace referencia al objeto al que está anclado el script

                Instantiate(efectoMuerte, transform.position, transform.rotation); // Creo una instancia del objeto efectoMuerte y le paso la posicion y rotacion del item

                GestorNivel.instancia.RespawnearJugador();

            }
            else
            {

                contadorInvencible = tiempoInvencible;

                renderizador.color = new Color(renderizador.color.r, renderizador.color.g, renderizador.color.b, .55f); // Cuando es invisible, bajo el alfa del sprite del jugador

                ControladorJugador.instancia.knockback();

            }

            ControladorGUI.instancia.actualizarVidasGUI(); // Llamo al metodo actualizarVidasGui() de la instancia de la clase ControladorGUI

        }

    }

    public void curarJugador() {

        vidasActuales++;

        if (vidasActuales > vidasMaximas) {

            vidasActuales = vidasMaximas;

        }

        ControladorGUI.instancia.actualizarVidasGUI();

    }

}
