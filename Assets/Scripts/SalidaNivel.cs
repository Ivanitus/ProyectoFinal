﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar la salida del nivel (final)
public class SalidaNivel : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) { // si el jugador toca el area de salida del nivel

            GestorNivel.instancia.finNivel();

        }

    }

}
