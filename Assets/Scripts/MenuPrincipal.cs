using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Clase para controlar el menu principal del juego
public class MenuPrincipal : Menus {

    public string escenaInicial;

    public string escenaContinuar;

    public string escenaAjustes;

    public string estaEscena;

    public AudioSource musicaFondo;

    private bool puedeInteractuar;

    // Start is called before the first frame update
    void Start() {

        if (!PlayerPrefs.HasKey("VolumenMusica")) {

            PlayerPrefs.SetFloat("VolumenMusica", 1f);

        }

        if (!PlayerPrefs.HasKey("VolumenSFX")) {

            PlayerPrefs.SetFloat("VolumenSFX", 1f);

        }

        if (!PlayerPrefs.HasKey("MusicaActivada")) {

            PlayerPrefs.SetInt("MusicaActivada", 1);

        }

        if (!PlayerPrefs.HasKey("EfectosActivados")) {

            PlayerPrefs.SetInt("EfectosActivados", 1);

        }

        if (PlayerPrefs.GetInt("MusicaActivada") == 1) {

            musicaFondo.volume = PlayerPrefs.GetFloat("VolumenMusica");

            musicaFondo.Play();

        }

        if (PlayerPrefs.HasKey(escenaInicial + "_desbloqueado")) {

            botones[0].gameObject.SetActive(true);

            botonSeleccionado = 0;

        } else if (estaEscena == "Menu_Principal") {

            botones[0].gameObject.SetActive(false);

            botonSeleccionado = 1;

        }

        puedeInteractuar = true;

    }

    // Update is called once per frame
    void Update() {

        int VerticalInput = (int) Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.DownArrow)) { // Navegación con el teclado

            desactivarImagenesMando();

            activarImagenesTeclado();

            try {

                if (botones[botonSeleccionado].gameObject.activeSelf) {

                    seleccionar();

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

                    seleccionar();

                    if (botonSeleccionado > 0) {

                        botonSeleccionado--;

                    }

                }

            } catch (System.IndexOutOfRangeException e) {

            }

        }

        usarJoystick(VerticalInput);

        try {

            seleccionar();

        } catch (System.IndexOutOfRangeException e) {

        }

    }

    public void iniciarPartida() {

        SceneManager.LoadScene(escenaInicial);

        PlayerPrefs.DeleteKey("NivelActual");

        PlayerPrefs.DeleteKey("NivelUno_gemas");
        PlayerPrefs.DeleteKey("NivelUno_tiempo");

        PlayerPrefs.DeleteKey("NivelDos_gemas");
        PlayerPrefs.DeleteKey("NivelDos_tiempo");

        PlayerPrefs.DeleteKey("NivelTres_gemas");
        PlayerPrefs.DeleteKey("NivelTres_tiempo");

        PlayerPrefs.DeleteKey("NivelCuatro_gemas");
        PlayerPrefs.DeleteKey("NivelCuatro_tiempo");

        PlayerPrefs.DeleteKey("NivelCinco_gemas");
        PlayerPrefs.DeleteKey("NivelCinco_tiempo");

        PlayerPrefs.DeleteKey("NivelSeos_gemas");
        PlayerPrefs.DeleteKey("NivelSeis_tiempo");

        PlayerPrefs.DeleteKey("NivelBoss_gemas");
        PlayerPrefs.DeleteKey("NivelBoss_tiempo");

        PlayerPrefs.DeleteKey("NivelUno_desbloqueado");

        PlayerPrefs.DeleteKey("NivelDos_desbloqueado");

        PlayerPrefs.DeleteKey("NivelTres_desbloqueado");

        PlayerPrefs.DeleteKey("NivelCuatro_desbloqueado");

        PlayerPrefs.DeleteKey("NivelCinco_desbloqueado");

        PlayerPrefs.DeleteKey("NivelSeis_desbloqueado");

        PlayerPrefs.DeleteKey("NivelBoss_desbloqueado");

    }

    public void continuarPartida() {

        SceneManager.LoadScene(escenaContinuar);

    }

    public void ajustesJuego() {

        SceneManager.LoadScene(escenaAjustes);

    }

    public void salirJuego() {

        Application.Quit();
        Debug.Log("Saliendo del juego");

    }

    private void usarJoystick(int verticalInput) {

        if (verticalInput != 0 && puedeInteractuar) { // Compruebo si se usa el joystick del mando

            desactivarImagenesTeclado();

            activarImagenesMando();

            puedeInteractuar = false;

            StartCoroutine(cambioMenu(verticalInput));

        }

    }

    private IEnumerator cambioMenu(int input) { // Corutina que me permite controlar el menu con el joystick del mando

        if (input < 0 && botonSeleccionado < botones.Length - 1) {

            botonSeleccionado++;

        } else if (input > 0 && botonSeleccionado > 0) {

            botonSeleccionado--;

        }

        yield return new WaitForSeconds(0.2f);
        puedeInteractuar = true;

    }

}
