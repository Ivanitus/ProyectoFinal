using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para detectar cuando un jugador pisa a un enemigo
public class ZonaPisada : MonoBehaviour {

    public GameObject efectoMuerte;

    public GameObject coleccionable;
    [Range(0, 100)] public float probabilidadDropeo; // Limito que sea entre 0 y 100

    // Start is called before the first frame update
    void Start() {
       
        

    }

    // Update is called once per frame
    void Update() {
        


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Enemigo")) {

            collision.transform.parent.gameObject.SetActive(false); // Accedo al padre del enemigo y lo desactivo

            Instantiate(efectoMuerte, collision.transform.position, collision.transform.rotation);

            ControladorJugador.instancia.rebotar();

            float drop = Random.Range(0, 100f);

            if (drop <= probabilidadDropeo) {

                Instantiate(coleccionable, collision.transform.position, collision.transform.rotation);

            }

            GestorAudio.instancia.reproducirSFX(3);

        }

    }

}
