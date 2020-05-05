using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar la camara (seguimiento del jugador, etc.)
public class ControladorCamara : MonoBehaviour {

    public Transform objetivo; // Variable que carga la posición del objetivo (jugador)

    public Transform fondo, fondoDelante; // Variables para cargar la posicion del fondo y del fondo más "cercano"

    public float alturaMinima, alturaMaxima; // Variables para configurar la altura minima y maxima de la camara en el nivel

    //private float ultimaPosicionX; // Variable para cargar la ultima posicion de X
    private Vector2 ultimaPosicion;

    // Start is called before the first frame update
    void Start() {

        //ultimaPosicionX = transform.position.x;

        ultimaPosicion = transform.position;

    }

    // Update is called once per frame
    void Update() {

        /*// transform.position carga la posicion del transform del objeto que tiene asociado el script
        transform.position = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z); // Le paso a la posicion un Vector 3 con la x del jugador, y la 'y' y 'z' de la camara

        float yRestringida = Mathf.Clamp(transform.position.y, alturaMinima, alturaMaxima);
        transform.position = new Vector3(transform.position.x, yRestringida, transform.position.z);*/

        // Posicion camara que sigue al objetivo, en este caso el jugador, con limite de altura en la camara
        transform.position = new Vector3(objetivo.position.x, Mathf.Clamp(objetivo.position.y, alturaMinima, alturaMaxima), transform.position.z);

        // Paralaje del fondo
        //float cuantoMoverEnX = transform.position.x - ultimaPosicionX; // Calculo cuanto tengo que mover el fondo en X
        Vector2 cuantoMover = new Vector2(transform.position.x - ultimaPosicion.x, transform.position.y - ultimaPosicion.y);

        fondo.position += new Vector3(cuantoMover.x, cuantoMover.y, 0f);
        fondoDelante.position += new Vector3(cuantoMover.x * .5f, cuantoMover.y, 0f) * .5f; // Al ser el fondo cercano, tengo que moverlo mas lento respecto la camara

        //ultimaPosicionX = transform.position.x;
        ultimaPosicion = transform.position;

    }
}
