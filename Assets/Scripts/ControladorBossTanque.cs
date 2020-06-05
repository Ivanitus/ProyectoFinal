using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar el Boss final (tanque)
public class ControladorBossTanque : MonoBehaviour {

    public static ControladorBossTanque instancia;

    public enum estadosBoss { DISPARANDO, DANADO, MOVIENDO, FINALIZADO }; // estados del boss (Disparando=quieto y/o disparando, DANADO=recibe daño, MOVIENDO=se mueve)
    public estadosBoss estadoActual;

    // Variables jefe
    [Header("Jefe")]
    public Transform boss;
    public Animator animador;

    // Variables movimiento
    [Header("Movimiento")]
    public float velocidadMovimiento;
    public Transform puntoIzquierda, puntoDerecha;
    private bool moverDerecha;

    // Variables minas
    [Header("Minas")]
    public GameObject mina;
    public Transform puntoMina;
    public float tiempoEntreMinas;
    private float contadorMinas;

    // Variables disparos
    [Header("Disparos")]
    public GameObject balas;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos;
    private float contadorDisparo;

    // Variables recibir daño
    [Header("Recibir daño")]
    public float tiempoDano;
    private float contadorDano;
    public GameObject hitbox;

    // Variables vida
    [Header("Vida")]
    public int vida;
    public GameObject explosion, plataformasVictoria;
    private bool derrotado;
    public float aumentarVelocidadDisparos, aumentarVelocidadMinas;
    public GameObject[] gemas;
    public Transform puntoAparicionGemas;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

        estadoActual = estadosBoss.DISPARANDO; // se define el estado como disparando

    }

    // Update is called once per frame
    void Update() {
        
        switch(estadoActual) {

            case estadosBoss.DISPARANDO:

                contadorDisparo -= Time.deltaTime; // es el tiempo entre disparo y disparo

                if (contadorDisparo <= 0) {

                    contadorDisparo = tiempoEntreDisparos;

                    var nuevaBala = Instantiate(balas, puntoDisparo.position, puntoDisparo.rotation); // var es un tipo que solo se puede usar como variable local dentro de un metodo. Instanciamos la bala

                    nuevaBala.transform.localScale = boss.localScale; // se orienta la bala al mismo lado que mira el tanque

                }

                break;

            case estadosBoss.DANADO:

                if (contadorDano > 0) {

                    contadorDano -= Time.deltaTime; // recibe daño

                    if (contadorDano <= 0) {

                        estadoActual = estadosBoss.MOVIENDO;

                        contadorMinas = 0;

                        if (derrotado) { // si se derrota el enemigo

                            boss.gameObject.SetActive(false); // se desactiva el tanque

                            Instantiate(explosion, boss.position, boss.rotation); // se instancia la animacion de explosion

                            plataformasVictoria.SetActive(true); // se activan las plataformas
                            
                            GestorAudio.instancia.pararMusicaBoss(); // se para la musica del boss

                            aparecerGemas(); // aparecen las 25 gemas

                            estadoActual = estadosBoss.FINALIZADO; // se marca el estado del boss como finalizado

                        }

                    }

                }

                break;

            case estadosBoss.MOVIENDO:

                if (moverDerecha) { // si se mueve a la derecha

                    boss.position += new Vector3(velocidadMovimiento * Time.deltaTime, 0f, 0f); // se mueve el tanque hacia la derecha

                    if (boss.position.x > puntoDerecha.position.x) {

                        boss.localScale = Vector3.one; // Lo oriento hacia la izquierda con localscale para cambiar tambien el punto de disparo

                        moverDerecha = false;

                        finalizarMovimiento();

                    }

                } else {

                    boss.position -= new Vector3(velocidadMovimiento * Time.deltaTime, 0f, 0f); // se mueve el tanque hacia la izquierda

                    if (boss.position.x < puntoIzquierda.position.x) {

                        boss.localScale = new Vector3(-1f, 1f, 1f); // Lo oriento hacia la derecha con localscale para cambiar tambien el punto de disparo

                        moverDerecha = true;

                        finalizarMovimiento();

                    }

                }

                contadorMinas -= Time.deltaTime; // tiempo de despliegue entre minas

                if (contadorMinas <= 0) {

                    contadorMinas = tiempoEntreMinas;

                    Instantiate(mina, puntoMina.position, puntoMina.rotation); // instancio las minas

                }

                break;

            default:
                break;

        }

        #if UNITY_EDITOR // Cualquier codigo debajo de esta linea solo se ejecutara si estamos en el editor de Unity

        if (Input.GetKeyDown(KeyCode.H)) {

            recibirGolpe();

        }

        #endif

    }

    // Metodo para realizar el daño al boss
    public void recibirGolpe() {

        estadoActual = estadosBoss.DANADO; // cambio el estado a dañado

        contadorDano = tiempoDano;

        animador.SetTrigger("Danado"); // cambio el trigger de la animacion de daño

        GestorAudio.instancia.reproducirSFX(0);

        MinaBossTanque[] minas = FindObjectsOfType<MinaBossTanque>(); // guardo todas las minas que haya en el nivel en este array

        if (minas.Length > 0) {

            for (int i = 0; i < minas.Length; i++) {

                minas[i].explotar(); // exploto las minas que se hayan guardado en el array

            }

        }

        vida--; // resto 1 vida al boss

        if (vida <= 0) {

            derrotado = true;

        } else {

            tiempoEntreDisparos /= aumentarVelocidadDisparos; // disminuyo el tiempo entre disparos

            tiempoEntreMinas /= aumentarVelocidadMinas; // disminuyo el tiempo entre minas

        }

        ControladorGUIBatallaFinal.instancia.actualizarGUIBatallaFinal();

    }

    // Metodo para finalizar el movimiento del boss
    private void finalizarMovimiento() {

        estadoActual = estadosBoss.DISPARANDO;

        contadorDisparo = 0f;

        animador.SetTrigger("PararMovimiento"); // activo el trigger parar movimiento para parar la animación de movimiento del boss

        hitbox.SetActive(true); // hago vulnerable al boss

    }

    // Metodo para hacer aperecer las gemas
    private void aparecerGemas() {

        for(int i = 0; i < gemas.Length; i++) {

            Instantiate(gemas[i], puntoAparicionGemas.position, puntoAparicionGemas.rotation);

            puntoAparicionGemas.position = new Vector3(puntoAparicionGemas.position.x + .35f, puntoAparicionGemas.position.y, puntoAparicionGemas.position.z);

        }

    }

}
