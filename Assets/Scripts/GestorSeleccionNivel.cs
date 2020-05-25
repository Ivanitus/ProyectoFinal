using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase para gestionar la seleccion de los niveles
public class GestorSeleccionNivel : MonoBehaviour {

    public JugadorSN jugador;

    private PuntoMapa[] puntos;

    public AudioSource musicaFondo;

    // Start is called before the first frame update
    void Start() {

        if (PlayerPrefs.GetInt("MusicaActivada") == 1) {

            musicaFondo.volume = PlayerPrefs.GetFloat("VolumenMusica");

            musicaFondo.Play();

        }

        puntos = FindObjectsOfType<PuntoMapa>();

        if (PlayerPrefs.HasKey("NivelActual")) {

            for (int i = 0; i < puntos.Length; i++) {

                if (puntos[i].nombreNivel.Equals(PlayerPrefs.GetString("NivelActual"))) {

                    jugador.transform.position = puntos[i].transform.position;

                    jugador.puntoActual = puntos[i];

                }

            }

        }

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void cargarNivel() {

        StartCoroutine(cargarNivelCO());

    }

    private IEnumerator cargarNivelCO() {

        GestorAudio.instancia.reproducirSFX(4);

        ControladorGUISN.instancia.transicinANegro();

        yield return new WaitForSeconds((1f / ControladorGUISN.instancia.velocidadTransicion) + .25f);

        SceneManager.LoadScene(jugador.puntoActual.nombreNivel);

    }

}
