using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para gestionar la hitbox del boss final (tanque)
public class HitboxBossTanque : MonoBehaviour {

    public ControladorBossTanque controladorBoss;

    // Start is called before the first frame update
    void Start() {
        


    }

    // Update is called once per frame
    void Update() {
        


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player") && ControladorJugador.instancia.transform.position.y > transform.position.y) {

            controladorBoss.recibirGolpe();

            ControladorJugador.instancia.rebotar();

            gameObject.SetActive(false);

        }

    }

}
