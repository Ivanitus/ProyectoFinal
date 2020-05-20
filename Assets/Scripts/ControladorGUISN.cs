using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Clase para controlar la interfaz grafica de la pantalla de seleccion de nivel
public class ControladorGUISN : MonoBehaviour {

    public static ControladorGUISN instancia;

    public Image pantallaTransicion;

    public float velocidadTransicion;

    private bool debeTransicionANegro, debeTransicionDesdeNegro;

    public GameObject panelInformacionNivel;

    public Text nombreNivel, gemasEncontradas, gemasNivel, record, tiempoObjetivo;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {

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

            if (pantallaTransicion.color.a == 0f) {

                debeTransicionDesdeNegro = false;

            }

        }

    }

    public void transicinANegro() {

        debeTransicionANegro = true;
        debeTransicionDesdeNegro = false;

    }

    public void transicionDesdeNegro() {

        debeTransicionANegro = false;
        debeTransicionDesdeNegro = true;

    }

    public void mostrarInformacion(PuntoMapa informacionNivel) {

        nombreNivel.text = informacionNivel.nombreNivelUsuario;

        gemasEncontradas.text = "ENCONTRADAS: " + informacionNivel.gemasRecogidas; // No hace falta cambiar int a string ya que c# lo convierte automaticamente al detectar un string previo
        gemasNivel.text = "EN EL NIVEL: " + informacionNivel.gemasTotales;

        tiempoObjetivo.text = "OBJETIVO: " + informacionNivel.tiempoObjetivo + "s";

        if (informacionNivel.tiempoRecord == 0) {

            record.text = "RECORD: ----";

        } else {

            record.text = "RECORD: " + informacionNivel.tiempoRecord.ToString("F2") + "s"; // En este caso si uso el ToString, pero pasando "F2", lo cual indica es que queremos un float con dos decimales

        }

        panelInformacionNivel.SetActive(true);

    }

    public void ocultarInformacion() {

        panelInformacionNivel.SetActive(false);

    }

}
