using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar la palanca
public class Palanca : MonoBehaviour {

    public GameObject objetoAInteractuar;

    private SpriteRenderer renderizador;

    public Sprite spriteDesactivado;

    private bool interaccionado;

    public bool desactivarAlInteraccionar;

    // Start is called before the first frame update
    void Start() {

        renderizador = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {
        


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player") && !interaccionado) { // si el jugador la toca y no se ha interaccionado ya

            if (desactivarAlInteraccionar) {

                objetoAInteractuar.SetActive(false);

            } else {

                objetoAInteractuar.SetActive(true);

            }

            renderizador.sprite = spriteDesactivado;

            interaccionado = true;

        }

    }

}
