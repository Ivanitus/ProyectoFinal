using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que gestionara el nivel
public class GestorNivel : MonoBehaviour {

    public static GestorNivel instancia; // Singleton

    public float tiempoEsperaRespawn;

    public int gemasRecogidas;

    public string siguienteNivel;

    public float tiempoNivel;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

        tiempoNivel = 0f;

    }

    // Update is called once per frame
    void Update() {

        tiempoNivel += Time.deltaTime; // Sumo al tiempo del nivel el deltatime

        ControladorGUI.instancia.textoTiempo.text = tiempoNivel.ToString("F1") + "s";

    }

    public void RespawnearJugador() {

        StartCoroutine(RespawnCO()); // StartCoroutine() comienza la ejecucion de una corutina

    }

    private IEnumerator RespawnCO() { // Una CO es una corutina que se ejecuta de forma paralela al flujo de ejecución normal del juego

        ControladorJugador.instancia.gameObject.SetActive(false);

        GestorAudio.instancia.reproducirSFX(8);

        yield return new WaitForSeconds(tiempoEsperaRespawn - (1f / ControladorGUI.instancia.velocidadTransicion)); // yield return le dice a RespawnCO que tiene que esperar a que sea true lo que retorne

        ControladorGUI.instancia.transicinANegro(); // Ejecuto la transicion a negro

        yield return new WaitForSeconds((1f / ControladorGUI.instancia.velocidadTransicion) + .2f);

        ControladorGUI.instancia.transicionDesdeNegro(); // Ejecuto la transicion desde negro 

        ControladorJugador.instancia.gameObject.SetActive(true);

        ControladorJugador.instancia.transform.position = ControladorCheckpoint.instancia.puntoSpawn;

        ControladorVidaJugador.instancia.vidasActuales = ControladorVidaJugador.instancia.vidasMaximas;

        ControladorVidaJugador.instancia.vidasJugadorActuales--;

        ControladorGUI.instancia.actualizarVidasGUI();

        ControladorGUI.instancia.actualizarVidasJugador();

    }

    public void muerteJugador() {

        StartCoroutine(muerteJugadorCO());

    }

    private IEnumerator muerteJugadorCO() {

        ControladorJugador.instancia.gameObject.SetActive(false);

        GestorAudio.instancia.reproducirSFX(8);

        yield return new WaitForSeconds(tiempoEsperaRespawn - (1f / ControladorGUI.instancia.velocidadTransicion));

        ControladorGUI.instancia.transicinANegro();

        yield return new WaitForSeconds((1f / ControladorGUI.instancia.velocidadTransicion) + 2f);

        PlayerPrefs.SetString("NivelActual", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(MenuPausa.instancia.seleccionNivel);

    }

    public void finNivel() {

        StartCoroutine(finNivelCO());

    }

    private IEnumerator finNivelCO() {

        GestorAudio.instancia.reproducirMusicaFinNivel();

        ControladorJugador.instancia.pararInput = true; // Quito el control al usuario

        ControladorCamara.instancia.pararSeguimiento = true; // Paro el seguimiento de la cámara

        ControladorGUI.instancia.textoNivelCompletado.SetActive(true); // Muestro el texto de nivel completado

        yield return new WaitForSeconds(1.5f); // Espero 1.5 segundos

        ControladorGUI.instancia.transicinANegro(); // Hago la transición a negro

        yield return new WaitForSeconds((1f / ControladorGUI.instancia.velocidadTransicion) + 2f); // Espero 1 segundo dividido por la velocidad de la transición + 2 segundos

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_desbloqueado", 1);

        PlayerPrefs.SetString("NivelActual", SceneManager.GetActiveScene().name);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gemas")) {

            if (gemasRecogidas > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gemas")) {

                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gemas", gemasRecogidas);

            }

        } else {

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gemas", gemasRecogidas);

        }

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_tiempo")) {

            if (tiempoNivel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_tiempo")) {

                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_tiempo", tiempoNivel);

            }

        } else {

            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_tiempo", tiempoNivel);

        }

        SceneManager.LoadScene(siguienteNivel); // Cargo el siguiente nivel

    }

}
