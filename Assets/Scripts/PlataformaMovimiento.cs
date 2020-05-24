using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar la plataforma con movimiento
public class PlataformaMovimiento : Volar {

    public Transform plataforma;

    // Start is called before the first frame update
    void Start() {
        

    }

    // Update is called once per frame
    void Update() {

        plataforma.position = Vector3.MoveTowards(plataforma.position, puntos[puntoActual].position, velocidadMovimiento * Time.deltaTime);

        if (Vector3.Distance(plataforma.position, puntos[puntoActual].position) < .05f) {

            puntoActual++;

            if (puntoActual >= puntos.Length) {

                puntoActual = 0;

            }

        }

    }

}
