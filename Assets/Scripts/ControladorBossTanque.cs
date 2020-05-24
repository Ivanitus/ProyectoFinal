using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBossTanque : MonoBehaviour {

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
