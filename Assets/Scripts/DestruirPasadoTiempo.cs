using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que sirve para destruir objetos pasado un tiempo en concreto
public class DestruirPasadoTiempo : MonoBehaviour {

    public float tiempoVida;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        Destroy(gameObject, tiempoVida); // destruyo el objeto una vez ha pasado su tiempo de vida

    }

}
