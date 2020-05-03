using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase para controlar los movimientos del jugador
public class ControladorJugador : MonoBehaviour {

    public Rigidbody2D rigidbody; // Cuerpo del jugador

    public float velocidadMovimiento; // Velocidad a la que se mueve el jugador

    public float fuerzaSalto; // Fuerza con la que salta el jugador

    // Variables para comprobar si el jugador esta tocando el suelo
    private bool tocandoSuelo;
    public Transform comprobarPuntoSuelo;
    public LayerMask sueloNivel;

    // Variables para comprobar si el jugador puede hacer un doble salto
    private bool dobleSalto;

    //Variables para controlar las animaciones del jugador
    private Animator animador;
    private SpriteRenderer renderizador;

    // Start is called before the first frame update
    void Start() {

        animador = GetComponent<Animator>();

        renderizador = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {

        // Input.GetAxis("Horizontal") captura de unity si el jugador quiere que el personaje se mueva a la izquierda (-1) o a la derecha (1)
        rigidbody.velocity = new Vector2(velocidadMovimiento * Input.GetAxis("Horizontal"), rigidbody.velocity.y);

        tocandoSuelo = Physics2D.OverlapCircle(comprobarPuntoSuelo.position, .2f, sueloNivel);

        if (tocandoSuelo) {

            dobleSalto = true;

        }

        if (Input.GetButtonDown("Jump")) { // Compruebo si el jugador ha presionado el boton "Jump" asignado a saltar

            if (tocandoSuelo) { // Primer Salto

                rigidbody.velocity = new Vector2(rigidbody.velocity.x, fuerzaSalto); // Pongo en y la fuerza del salto

            } else {

                if (dobleSalto) {

                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, fuerzaSalto); // Pongo en y la fuerza del salto

                    dobleSalto = false;

                }

            }

        }

        if (rigidbody.velocity.x < 0) { // Con esto hago que el sprite se ponga mirando a la izquierda o a la derecha dependiendo de su dirección

            renderizador.flipX = true;

        } else if (rigidbody.velocity.x > 0) {

            renderizador.flipX = false;

        }

        animador.SetFloat("velocidadMovimiento", Mathf.Abs(rigidbody.velocity.x)); // Mathf.Abs() devuelve el valor absoluto
        animador.SetBool("tocandoSuelo", tocandoSuelo);

    }

}
