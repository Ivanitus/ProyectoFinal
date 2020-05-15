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

            if (contadorMovimiento > 0) {

                contadorMovimiento -= Time.deltaTime;

                if (moverDerecha) {

                    rigidbody.velocity = new Vector2(velocidadMovimiento, rigidbody.velocity.y);

                    renderizador.flipX = true;

                    if (transform.position.x > puntoDerecho.position.x) {

                        moverDerecha = false;

                    }

                } else {

                    rigidbody.velocity = new Vector2(-velocidadMovimiento, rigidbody.velocity.y);

                    renderizador.flipX = false;

                    if (transform.position.x < puntoIzquierdo.position.x) {

                        moverDerecha = true;

                    }

                }

                if (contadorMovimiento <= 0) {

                    contadorEspera = Random.Range(tiempoEspera * .5f, tiempoEspera * 1.5f);

                }

                anim.SetBool("isMoviendo", true);

            } else if (tiempoEspera > 0) {

                contadorEspera -= Time.deltaTime;

                rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);

                if (contadorEspera <= 0) {

                    contadorMovimiento = Random.Range(tiempoMovimiento * .5f, tiempoMovimiento * 1.5f);

                }

                anim.SetBool("isMoviendo", false);

            }

    }

}
