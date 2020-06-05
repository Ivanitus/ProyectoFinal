using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar los puntos del mapa
public class PuntoMapa : MonoBehaviour {

    public PuntoMapa arriba, derecha, abajo, izquierda;

    public bool puntoNivel, bloqueado;

    public string nombreNivel, nivelComprobar, nombreNivelUsuario;

    public int gemasRecogidas, gemasTotales;

    public float tiempoRecord, tiempoObjetivo;

    public GameObject medallaGema, medallaTiempo;

    // Start is called before the first frame update
    void Start() {
        
        if (puntoNivel && nombreNivel != null) { // si es un punto de nivel

            if (PlayerPrefs.HasKey(nombreNivel + "_gemas")) {

                gemasRecogidas = PlayerPrefs.GetInt(nombreNivel + "_gemas");

            }

            if (PlayerPrefs.HasKey(nombreNivel + "_tiempo")) {

                tiempoRecord = PlayerPrefs.GetFloat(nombreNivel + "_tiempo");

            }

            if (gemasRecogidas >= gemasTotales && gemasRecogidas != 0) {

                medallaGema.SetActive(true);

            }

            if (tiempoRecord <= tiempoObjetivo && tiempoRecord != 0) {

                medallaTiempo.SetActive(true);

            }

            bloqueado = true;

            if (nivelComprobar != null) {

                if (PlayerPrefs.HasKey(nivelComprobar + "_desbloqueado")) { // Comprueba si existe un valor en concreto en las PlayerPrefs

                    if (PlayerPrefs.GetInt(nivelComprobar + "_desbloqueado")==1) {

                        bloqueado = false;

                    }

                }

            }

            if (nombreNivel.Equals(nivelComprobar)) {

                bloqueado = false;

            }

        }

    }

    // Update is called once per frame
    void Update() {
        
    }

}
