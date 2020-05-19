using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase para gestionar la seleccion de los niveles
public class GestorSeleccionNivel : MonoBehaviour {

    public JugadorSN jugador;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void cargarNivel() {

        StartCoroutine(cargarNivelCO());

    }

    private IEnumerator cargarNivelCO() {

        ControladorGUISN.instancia.transicinANegro();

        yield return new WaitForSeconds((1f / ControladorGUISN.instancia.velocidadTransicion) + .25f);

        SceneManager.LoadScene(jugador.puntoActual.nombreNivel);

    }

}
