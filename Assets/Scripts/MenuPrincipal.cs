using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Clase para controlar el menu principal del juego
public class MenuPrincipal : MonoBehaviour {

    public string escenaInicial;

    public string estaEscena;

    public Button[] botones;

    private int botonSeleccionado;

    private bool puedeInteractuar;

    // Start is called before the first frame update
    void Start() {

        botonSeleccionado = 0;

        puedeInteractuar = true;

        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update() {

        int VerticalInput = (int) Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) { // Navegación con el teclado

            try {

                botones[botonSeleccionado].GetComponent<Button>().Select();

            } catch (System.IndexOutOfRangeException e) {

            }

            botonSeleccionado +=2;
            //botonSeleccionado++;

            if (botonSeleccionado == botones.Length){

                botonSeleccionado = botones.Length - 1;

            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) { // Navegación con el teclado

            try {

                botones[botonSeleccionado].GetComponent<Button>().Select();

            } catch (System.IndexOutOfRangeException e) {

            }

            if (botonSeleccionado > 0) {
                
                botonSeleccionado-=2;
                //botonSeleccionado--;

            }

        }

        if (VerticalInput != 0 && puedeInteractuar) { // Compruebo si se usa el joystick del mando

            puedeInteractuar = false;

            StartCoroutine(cambioMenu(VerticalInput));

        }

        try {

            botones[botonSeleccionado].GetComponent<Button>().Select();

        } catch (System.IndexOutOfRangeException e) {

        }

    }

    public void iniciarPartida() {

        SceneManager.LoadScene(escenaInicial);

    }

    public void salirJuego() {

        Application.Quit();
        Debug.Log("Saliendo del juego");

    }

    private IEnumerator cambioMenu(int input){ // Corutina que me permite controlar el menu con el joystick del mando

        if (input < 0 && botonSeleccionado < botones.Length - 1) {

            botonSeleccionado+=2;
            //botonSeleccionado++;

        } else if (input > 0 && botonSeleccionado > 0) {

            botonSeleccionado-=2;
            //botonSeleccionado--;
        }

        yield return new WaitForSeconds(0.2f);
        puedeInteractuar = true;

    }

}
