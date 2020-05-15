using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Clase para controlar la interfaz gráfica del usuario (GUI)
public class ControladorGUI : MonoBehaviour {

    public static ControladorGUI instancia; // Singleton

    public Image corazonUno, corazonDos, corazonTres;

    public Sprite corazonLleno, corazonMedioLleno, corazonVacio;

    public Text textoGemas;

    public Image pantallaTransicion;

    public float velocidadTransicion;

    private bool debeTransicionANegro, debeTransicionDesdeNegro;

    // Metodo que se ejecuta justo antes del Start()
    private void Awake() {

        instancia = this;
        
    }

    // Start is called before the first frame update
    void Start() {

        actualizarContadorGemas();

        transicionDesdeNegro();

    }

    // Update is called once per frame
    void Update() {
        
        if (debeTransicionANegro) {

            pantallaTransicion.color = new Color(pantallaTransicion.color.r, pantallaTransicion.color.g, pantallaTransicion.color.b, Mathf.MoveTowards(pantallaTransicion.color.a, 1f, velocidadTransicion * Time.deltaTime));

            if (pantallaTransicion.color.a == 1f) {

                debeTransicionANegro = false;

            }

        }

        if (debeTransicionDesdeNegro) {

            pantallaTransicion.color = new Color(pantallaTransicion.color.r, pantallaTransicion.color.g, pantallaTransicion.color.b, Mathf.MoveTowards(pantallaTransicion.color.a, 0f, velocidadTransicion * Time.deltaTime));

            if (pantallaTransicion.color.a == 0f)
            {

                debeTransicionDesdeNegro = false;

            }

        }

    }

    public void actualizarVidasGUI() { // Metodo para cambiar las vidas desplegadas en la interfaz

        // Cargo las vidasActuales de la instancia de la clase ControladorVidaJugador
        switch(ControladorVidaJugador.instancia.vidasActuales) {

            case 6:
                corazonUno.sprite = corazonLleno;
                corazonDos.sprite = corazonLleno;
                corazonTres.sprite = corazonLleno;
                break;

            case 5:
                corazonUno.sprite = corazonLleno;
                corazonDos.sprite = corazonLleno;
                corazonTres.sprite = corazonMedioLleno;
                break;

            case 4:
                corazonUno.sprite = corazonLleno;
                corazonDos.sprite = corazonLleno;
                corazonTres.sprite = corazonVacio;
                break;

            case 3:
                corazonUno.sprite = corazonLleno;
                corazonDos.sprite = corazonMedioLleno;
                corazonTres.sprite = corazonVacio;
                break;

            case 2:
                corazonUno.sprite = corazonLleno;
                corazonDos.sprite = corazonVacio;
                corazonTres.sprite = corazonVacio;
                break;

            case 1:
                corazonUno.sprite = corazonMedioLleno;
                corazonDos.sprite = corazonVacio;
                corazonTres.sprite = corazonVacio;
                break;

            case 0:
                corazonUno.sprite = corazonVacio;
                corazonDos.sprite = corazonVacio;
                corazonTres.sprite = corazonVacio;
                break;

            default:
                corazonUno.sprite = corazonVacio;
                corazonDos.sprite = corazonVacio;
                corazonTres.sprite = corazonVacio;
                break;

        }

    }

    public void actualizarContadorGemas() {

        textoGemas.text = GestorNivel.instancia.gemasRecogidas.ToString();

    }

    public void transicinANegro()
    {

        debeTransicionANegro = true;
        debeTransicionDesdeNegro = false;

    }

    public void transicionDesdeNegro()
    {

        debeTransicionANegro = false;
        debeTransicionDesdeNegro = true;

    }

}
