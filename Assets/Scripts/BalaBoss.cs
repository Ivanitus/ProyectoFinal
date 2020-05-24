using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar las balas del boss
public class BalaBoss : MonoBehaviour {

    public float velocidad;

    // Start is called before the first frame update
    void Start() {
       
        

    }

    // Update is called once per frame
    void Update() {

        transform.position += new Vector3(-velocidad * transform.localScale.x * Time.deltaTime, 0f, 0f);

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            ControladorVidaJugador.instancia.hacerDano();

        }

        Destroy(gameObject);

    }

}
