using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase para gestionar los ajustes
public class Ajustes : MonoBehaviour {

    public string menuPrincipalEscena;

    // Start is called before the first frame update
    void Start() {

        

    }

    // Update is called once per frame
    void Update() {

    }

    public void menuPrincipal() {

        SliderSFX.instancia.escribirDatos();

        SliderMusica.instancia.escribirDatos();

        SliderActivarMusica.instancia.escribirDatos();

        SliderActivarEfectos.instancia.escribirDatos();

        SceneManager.LoadScene(menuPrincipalEscena);

    }

}
