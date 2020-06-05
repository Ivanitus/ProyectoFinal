using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Clase para controlar el menu de pausa
public class MenuPausa : Menus {

    public static MenuPausa instancia;

    public string seleccionNivel, menu;

    public GameObject pantallaPausa;

    public bool pausado;

    private bool puedeInteractuar;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

        botonSeleccionado = 0;

        puedeInteractuar = true;

    }

    // Update is called once per frame
    void Update() {

        int VerticalInput = (int)Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Escape)) { // activar al pulsar escape

            desactivarImagenesMando();

            activarImagenesTeclado();

            ejecutarMenuPausa();

        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button7)) { // activar al pulsar el boton start de un mando de xbox

            desactivarImagenesTeclado();

            activarImagenesMando();

            ejecutarMenuPausa();

        }

        if (pantallaPausa.activeSelf) {

            if (Input.GetKeyDown(KeyCode.DownArrow)) { // Navegación con el teclado

                desactivarImagenesMando();

                activarImagenesTeclado();

                try {

                    seleccionar();

                } catch (System.IndexOutOfRangeException e) {

                }

                //botonSeleccionado += 2;
                botonSeleccionado++;

                if (botonSeleccionado == botones.Length) {

                    botonSeleccionado = botones.Length - 1;

                }

            }

            if (Input.GetKeyDown(KeyCode.UpArrow)) { // Navegación con el teclado

                desactivarImagenesMando();

                activarImagenesTeclado();

                try {

                    seleccionar();

                } catch (System.IndexOutOfRangeException e) {

                }

                if (botonSeleccionado > 0) {

                    //botonSeleccionado -= 2;
                    botonSeleccionado--;

                }

            }

            if (VerticalInput != 0 && puedeInteractuar) { // Compruebo si se usa el joystick del mando

                desactivarImagenesTeclado();

                activarImagenesMando();

                puedeInteractuar = false;

                StartCoroutine(cambioMenu(VerticalInput));

            }

            try {

                seleccionar();

            } catch (System.IndexOutOfRangeException e) {

            }

        }

    }

    public void pausarContinuar() { // pausar/continuar partida

        if (pausado) {

            pausado = false;

            pantallaPausa.SetActive(false);

            Time.timeScale = 1f;

        } else {

            pausado = true;

            pantallaPausa.SetActive(true);

            Time.timeScale = 0f;

        }

    }

    public void cargarSeleccionNivel() {

        PlayerPrefs.SetString("NivelActual", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(seleccionNivel);

        Time.timeScale = 1f;

    }

    public void cargarMenu() {

        SceneManager.LoadScene(menu);

        Time.timeScale = 1f;

    }

    private void ejecutarMenuPausa() {

        pausarContinuar();

        try {

            seleccionar();

        } catch (System.IndexOutOfRangeException e) {

        }

    }

    private IEnumerator cambioMenu(int input) { // Corutina que me permite controlar el menu con el joystick del mando

        if (input < 0 && botonSeleccionado < botones.Length - 1) {

            botonSeleccionado++;

        } else if (input > 0 && botonSeleccionado > 0) {

            botonSeleccionado--;
        }

        yield return new WaitForSecondsRealtime(0.2f);
        puedeInteractuar = true;

    }

}
