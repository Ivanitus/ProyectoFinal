using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase para controlar los movimientos del jugador
public class ControladorJugador : MonoBehaviour {

    public static ControladorJugador instancia; // Singleton

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

    public float duracionKnockback, fuerzaKnockback;
    private float contadorKnockback;

    public float fuerzaRebote; // Variable para guardar la fuerza de rebote al matar a un enemigo

    public bool pararInput;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

        animador = GetComponent<Animator>();

        renderizador = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {

        if (!MenuPausa.instancia.pausado && !pararInput) {

            if (contadorKnockback <= 0) {

                // Input.GetAxis("Horizontal") captura de unity si el jugador quiere que el personaje se mueva a la izquierda (-1) o a la derecha (1)
                rigidbody.velocity = new Vector2(velocidadMovimiento * Input.GetAxis("Horizontal"), rigidbody.velocity.y);

                tocandoSuelo = Physics2D.OverlapCircle(comprobarPuntoSuelo.position, .2f, sueloNivel);

                if (tocandoSuelo) {

                    dobleSalto = true;

                }

                if (Input.GetButtonDown("Jump")) { // Compruebo si el jugador ha presionado el boton "Jump" asignado a saltar

                    if (tocandoSuelo) { // Primer Salto

                        rigidbody.velocity = new Vector2(rigidbody.velocity.x, fuerzaSalto); // Pongo en y la fuerza del salto

                        GestorAudio.instancia.reproducirSFX(10);

                    } else {

                        if (dobleSalto) {

                            rigidbody.velocity = new Vector2(rigidbody.velocity.x, fuerzaSalto); // Pongo en y la fuerza del salto

                            GestorAudio.instancia.reproducirSFX(10);

                            dobleSalto = false;

                        }

                    }

                }

                if (rigidbody.velocity.x < 0) { // Con esto hago que el sprite se ponga mirando a la izquierda o a la derecha dependiendo de su dirección

                    renderizador.flipX = true;

                } else if (rigidbody.velocity.x > 0) {

                    renderizador.flipX = false;

                }

            } else {

                contadorKnockback -= Time.deltaTime;

                if (!renderizador.flipX) {

                    rigidbody.velocity = new Vector2(-fuerzaKnockback, rigidbody.velocity.y);

                } else {

                    rigidbody.velocity = new Vector2(fuerzaKnockback, rigidbody.velocity.y);

                }

            }

        }

        animador.SetFloat("velocidadMovimiento", Mathf.Abs(rigidbody.velocity.x)); // Mathf.Abs() devuelve el valor absoluto
        animador.SetBool("tocandoSuelo", tocandoSuelo);

    }

    public void knockback() {

        contadorKnockback = duracionKnockback;

        rigidbody.velocity = new Vector2(0f, fuerzaKnockback);

        animador.SetTrigger("dano");

    }

    // Metodo que se ejecuta cuando matas a un enemigo
    public void rebotar() {

        rigidbody.velocity = new Vector2(rigidbody.velocity.x, fuerzaRebote);

        GestorAudio.instancia.reproducirSFX(10);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.CompareTag("Plataforma")) {

            transform.parent = collision.transform; // hago hijo de la plataforma al jugador

        }

    }

    private void OnCollisionExit2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Plataforma")) {

            transform.parent = null; // el jugador deja de ser hijo de la plataforma

        }

    }

}
