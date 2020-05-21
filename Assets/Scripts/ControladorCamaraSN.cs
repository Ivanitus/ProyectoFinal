﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar la camara en la seleccion de nivel
public class ControladorCamaraSN : MonoBehaviour {

    public Vector2 posicionMinima, posicionMaxima;

    public Transform objetivo;

    // Start is called before the first frame update
    void Start() {
        
    }
    
    void LateUpdate() { // LateUpdate se ejecuta una vez han sido ejecutados todos los update

        float posX = Mathf.Clamp(objetivo.position.x, posicionMinima.x, posicionMaxima.x);

        float posY = Mathf.Clamp(objetivo.position.y, posicionMinima.y, posicionMaxima.y);

        transform.position = new Vector3(posX, posY, transform.position.z);

    }

}
