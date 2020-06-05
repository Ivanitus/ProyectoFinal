using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase para controlar la pantalla de victoria
public class Victoria : MonoBehaviour {

    public string menuPrincipalEscena;

    // Start is called before the first frame update
    void Start() {
        


    }

    // Update is called once per frame
    void Update() {
        


    }

    public void menuPrincipal() {

        SceneManager.LoadScene(menuPrincipalEscena); // cargo el menu principal

    }

}
