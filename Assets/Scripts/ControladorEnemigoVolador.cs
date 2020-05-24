using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar el movimiento de los enemigos que vuelan (aguilas)
public class ControladorEnemigoVolador : Volar {

    public SpriteRenderer renderizador;

    public float distanciaParaAtacarJugador;

    public float velocidadPerseguir;

    private Vector3 objetivoAtaque;

    public float tiempoEsperaDespuesAtaque;

    private float contadorAtaque;

    // Start is called before the first frame update
    void Start() {

        for (int i = 0; i < puntos.Length; i++) {

            puntos[i].parent = null;

        }

    }

    // Update is called once per frame
    void Update() {

        if (contadorAtaque > 0) {

            contadorAtaque -= Time.deltaTime;

        } else {

            if (Vector3.Distance(transform.position, ControladorJugador.instancia.transform.position) > distanciaParaAtacarJugador) {

                objetivoAtaque = Vector3.zero;

                transform.position = Vector3.MoveTowards(transform.position, puntos[puntoActual].position, velocidadMovimiento * Time.deltaTime);

                if (Vector3.Distance(transform.position, puntos[puntoActual].position) < .05f) {

                    puntoActual++;

                    if (puntoActual >= puntos.Length) {

                        puntoActual = 0;

                    }

                }

                if (transform.position.x < puntos[puntoActual].position.x) {

                    renderizador.flipX = true;

                } else if (transform.position.x > puntos[puntoActual].position.x) {

                    renderizador.flipX = false;

                }

            } else {

                // Atacando al jugador

                if (objetivoAtaque == Vector3.zero) { // Vector3.zero tiene todos los valores a 0 (x, y, z)

                    objetivoAtaque = ControladorJugador.instancia.transform.position;

                }

                transform.position = Vector3.MoveTowards(transform.position, objetivoAtaque, velocidadPerseguir * Time.deltaTime);

                if (transform.position.x < objetivoAtaque.x) {

                    renderizador.flipX = true;

                } else {

                    renderizador.flipX = false;

                }

                if (Vector3.Distance(transform.position, objetivoAtaque) <= .1f) {

                    contadorAtaque = tiempoEsperaDespuesAtaque;

                    objetivoAtaque = Vector3.zero;

                }

            }

        }

    }

}
