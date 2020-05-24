using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar el Boss final (tanque)
public class ControladorBossTanque : MonoBehaviour {

    public enum estadosBoss { DISPARANDO, DANADO, MOVIENDO }; // estados del boss (Disparando=quieto y/o disparando, DANADO=recibe daño, MOVIENDO=se mueve)
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

    // Start is called before the first frame update
    void Start() {

        estadoActual = estadosBoss.DISPARANDO;

    }

    // Update is called once per frame
    void Update() {
        
        switch(estadoActual) {

            case estadosBoss.DISPARANDO:
                break;

            case estadosBoss.DANADO:

                if (contadorDano > 0) {

                    contadorDano -= Time.deltaTime;

                    if (contadorDano <= 0) {

                        estadoActual = estadosBoss.MOVIENDO;

                    }

                }

                break;

            case estadosBoss.MOVIENDO:

                if (moverDerecha) {

                    boss.position += new Vector3(velocidadMovimiento * Time.deltaTime, 0f, 0f);

                    if (boss.position.x > puntoDerecha.position.x) {

                        boss.localScale = Vector3.one; // Lo oriento hacia la izquierda con localscale para cambiar tambien el punto de disparo

                        moverDerecha = false;

                        finalizarMovimiento();

                    }

                } else {

                    boss.position -= new Vector3(velocidadMovimiento * Time.deltaTime, 0f, 0f);

                    if (boss.position.x < puntoIzquierda.position.x) {

                        boss.localScale = new Vector3(-1f, 1f, 1f); // Lo oriento hacia la derecha con localscale para cambiar tambien el punto de disparo

                        moverDerecha = true;

                        finalizarMovimiento();

                    }

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

    public void recibirGolpe() {

        estadoActual = estadosBoss.DANADO;

        contadorDano = tiempoDano;

        animador.SetTrigger("Danado");

    }

    private void finalizarMovimiento() {

        estadoActual = estadosBoss.DISPARANDO;

        contadorDisparo = tiempoEntreDisparos;

        animador.SetTrigger("PararMovimiento");

    }

}
