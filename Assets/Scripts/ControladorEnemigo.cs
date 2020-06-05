using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla los enemigos
public class ControladorEnemigo : MonoBehaviour {

    public float velocidadMovimiento;

    public Transform puntoIzquierdo, puntoDerecho;

    private bool moverDerecha;

    private Rigidbody2D rigidbody;

    public SpriteRenderer renderizador;

    private Animator anim;

    public float tiempoMovimiento, tiempoEspera;

    private float contadorMovimiento, contadorEspera;

    // Start is called before the first frame update
    void Start() {

        rigidbody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        puntoIzquierdo.parent = null;
        puntoDerecho.parent = null; // Con esto hago que al iniciar el script, puntoIzquierdo y puntoDerecho dejan de ser hijos del enemigo

        moverDerecha = true;

        contadorMovimiento = tiempoMovimiento;

    }

    // Update is called once per frame
    void Update() {

            if (contadorMovimiento > 0) { // si el contador de movimiento es mayor de 0

                contadorMovimiento -= Time.deltaTime; // disminuyo el contador de movimiento con el deltatime

                if (moverDerecha) {

                    rigidbody.velocity = new Vector2(velocidadMovimiento, rigidbody.velocity.y); // muevo el enemigo a la derecha

                    renderizador.flipX = true;

                    if (transform.position.x > puntoDerecho.position.x) { // si llega al punto a la derecha cambio moverderecha a false

                        moverDerecha = false;

                    }

                } else {

                    rigidbody.velocity = new Vector2(-velocidadMovimiento, rigidbody.velocity.y); // muevo el enemigo a la izquierda

                    renderizador.flipX = false;

                    if (transform.position.x < puntoIzquierdo.position.x) { // si llega al punto a la izquierda cambio moverderecha a true

                        moverDerecha = true;

                    }

                }

                if (contadorMovimiento <= 0) {

                    contadorEspera = Random.Range(tiempoEspera * .5f, tiempoEspera * 1.5f); // establezco el tiempo en espera del enemigo a un numero aleatorio

                }

                anim.SetBool("isMoviendo", true); // activo la animacion de movimiento

            } else if (tiempoEspera > 0) { 

                contadorEspera -= Time.deltaTime; // disminuyo el contador de espera con el deltatime

                rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y); // dejo de hacer que se mueva el enemigo

                if (contadorEspera <= 0) {

                    contadorMovimiento = Random.Range(tiempoMovimiento * .5f, tiempoMovimiento * 1.5f); // establezco el tiempo en movimiento del enemigo a un numero aleatorio

                }

                anim.SetBool("isMoviendo", false); // desactivo la animación de movimiento

            }

    }

}
