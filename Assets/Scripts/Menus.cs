using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Clase de la que heredaran las dos clases del menu principal y menu de pausa
public class Menus : MonoBehaviour {

    public Button[] botones;

    public Image[] imagenesTeclado;

    public Image[] imagenesMando;

    protected int botonSeleccionado;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    protected void seleccionar() {

        botones[botonSeleccionado].GetComponent<Button>().Select();

    }

    protected void desactivarImagenesTeclado() {

        for (int i = 0; i < imagenesTeclado.Length; i++) {

            imagenesTeclado[i].gameObject.SetActive(false);

        }

    }

    protected void activarImagenesTeclado() {

        for (int i = 0; i < imagenesTeclado.Length; i++) {

            imagenesTeclado[i].gameObject.SetActive(true);

        }

    }

    protected void desactivarImagenesMando() {

        for (int i = 0; i < imagenesMando.Length; i++) {

            imagenesMando[i].gameObject.SetActive(false);

        }

    }

    protected void activarImagenesMando() {

        for (int i = 0; i < imagenesMando.Length; i++) {

            imagenesMando[i].gameObject.SetActive(true);

        }

    }

}
