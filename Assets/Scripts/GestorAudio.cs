using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para gestionar el audio en el juego
public class GestorAudio : MonoBehaviour {

    public static GestorAudio instancia;

    public AudioSource[] efectosSonido;

    public AudioSource musicaFondo;

    public AudioSource musicaFinalNivel;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {
       
        

    }

    // Update is called once per frame
    void Update() {
        


    }

    public void reproducirSFX(int sonidoAReproducir) {

        efectosSonido[sonidoAReproducir].Stop(); // En el caso de que tengan que sonar varias veces el mismo sonido a la vez, necesitamos pararlos antes de volver a reproducirlo

        efectosSonido[sonidoAReproducir].pitch = Random.Range(.85f, 1.15f); // Hago que el pitch cambie de forma aleatoria para que los efectos de sonido suenen distintos cada vez

        efectosSonido[sonidoAReproducir].Play();

    }

    public void reproducirMusicaFinNivel() {

        musicaFondo.Stop();

        musicaFinalNivel.Play();

    }

}
