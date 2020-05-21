using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Clase para controlar el menu principal del juego
public class MenuPrincipal : MonoBehaviour {

    public string escenaInicial;

    public string escenaContinuar;

    public string estaEscena;

    public Button[] botones;

    public Image[] imagenesTeclado;

    public Image[] imagenesMando;

    private int botonSeleccionado;

    private bool puedeInteractuar;

    // Start is called before the first frame update
    void Start() {

        if (PlayerPrefs.HasKey(escenaInicial + "_desbloqueado")) {

            botones[0].gameObject.SetActive(true);

            botonSeleccionado = 0;

        } else {

            botones[0].gameObject.SetActive(false);

            botonSeleccionado = 1;

        }

        puedeInteractuar = true;

        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update() {

        int VerticalInput = (int) Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.DownArrow)) { // Navegación con el teclado

            desactivarImagenesMando();

            activarImagenesTeclado();

            try {

                if (botones[botonSeleccionado].gameObject.activeSelf) {

                    botones[botonSeleccionado].GetComponent<Button>().Select();

                    botonSeleccionado++;

                    if (botonSeleccionado == botones.Length) {

                        botonSeleccionado = botones.Length - 1;

                    }

                }

            } catch (System.IndexOutOfRangeException e) {

            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) { // Navegación con el teclado

            desactivarImagenesMando();

            activarImagenesTeclado();

            try {

                if (botones[botonSeleccionado].gameObject.activeSelf) {

                    botones[botonSeleccionado].GetComponent<Button>().Select();

                    if (botonSeleccionado > 0) {

                        botonSeleccionado--;

                    }

                }

            } catch (System.IndexOutOfRangeException e) {

            }

        }

        if (VerticalInput != 0 && puedeInteractuar) { // Compruebo si se usa el joystick del mando

            desactivarImagenesTeclado();

            activarImagenesMando();

            puedeInteractuar = false;

            StartCoroutine(cambioMenu(VerticalInput));

        }

        try {

            if (botones[botonSeleccionado].gameObject.activeSelf) {

                botones[botonSeleccionado].GetComponent<Button>().Select();

            }

        } catch (System.IndexOutOfRangeException e) {

        }

    }

    public void iniciarPartida() {

        SceneManager.LoadScene(escenaInicial);

        PlayerPrefs.DeleteAll();

    }

    public void continuarPartida() {

        SceneManager.LoadScene(escenaContinuar);

    }

    public void salirJuego() {

        Application.Quit();
        Debug.Log("Saliendo del juego");

    }

    private void desactivarImagenesTeclado() {

        for (int i = 0; i<imagenesTeclado.Length; i++) {

            imagenesTeclado[i].gameObject.SetActive(false);

        }

    }

    private void activarImagenesTeclado() {

        for (int i = 0; i < imagenesTeclado.Length; i++) {

            imagenesTeclado[i].gameObject.SetActive(true);

        }

    }

    private void desactivarImagenesMando() {

        for (int i = 0; i < imagenesMando.Length; i++) {

            imagenesMando[i].gameObject.SetActive(false);

        }

    }

    private void activarImagenesMando() {

        for (int i = 0; i < imagenesMando.Length; i++) {

            imagenesMando[i].gameObject.SetActive(true);

        }

    }


    private IEnumerator cambioMenu(int input){ // Corutina que me permite controlar el menu con el joystick del mando

        if (input < 0 && botonSeleccionado < botones.Length - 1 && botones[botonSeleccionado].gameObject.activeSelf) {

            botonSeleccionado++;

        } else if (input > 0 && botonSeleccionado > 0 && botones[botonSeleccionado].gameObject.activeSelf) {

            botonSeleccionado--;
        }

        yield return new WaitForSeconds(0.2f);
        puedeInteractuar = true;

    }

}
