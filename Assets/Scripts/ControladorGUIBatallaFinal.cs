using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Clase para controlar la interfaz grafica de la batalla final
public class ControladorGUIBatallaFinal : MonoBehaviour {

    public static ControladorGUIBatallaFinal instancia;

    public Image tanqueUno, tanqueDos, tanqueTres, tanqueCuatro, tanqueCinco, tanqueSeis;

    public Text textoBoss;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start() {
        
        

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void activarImagenesTexto() {

        tanqueUno.gameObject.SetActive(true);
        tanqueDos.gameObject.SetActive(true);
        tanqueTres.gameObject.SetActive(true);
        tanqueCuatro.gameObject.SetActive(true);
        tanqueCinco.gameObject.SetActive(true);
        tanqueSeis.gameObject.SetActive(true);

        textoBoss.gameObject.SetActive(true);

    }

    public void actualizarGUIBatallaFinal() {

        switch(ControladorBossTanque.instancia.vida) {

            case 6:

                tanqueUno.gameObject.SetActive(true);

                tanqueDos.gameObject.SetActive(true);

                tanqueTres.gameObject.SetActive(true);

                tanqueCuatro.gameObject.SetActive(true);

                tanqueCinco.gameObject.SetActive(true);

                tanqueSeis.gameObject.SetActive(true);

                break;

            case 5:

                tanqueUno.gameObject.SetActive(true);

                tanqueDos.gameObject.SetActive(true);

                tanqueTres.gameObject.SetActive(true);

                tanqueCuatro.gameObject.SetActive(true);

                tanqueCinco.gameObject.SetActive(true);

                tanqueSeis.gameObject.SetActive(false);

                break;

            case 4:

                tanqueUno.gameObject.SetActive(true);

                tanqueDos.gameObject.SetActive(true);

                tanqueTres.gameObject.SetActive(true);

                tanqueCuatro.gameObject.SetActive(true);

                tanqueCinco.gameObject.SetActive(false);

                tanqueSeis.gameObject.SetActive(false);

                break;

            case 3:

                tanqueUno.gameObject.SetActive(true);

                tanqueDos.gameObject.SetActive(true);

                tanqueTres.gameObject.SetActive(true);

                tanqueCuatro.gameObject.SetActive(false);

                tanqueCinco.gameObject.SetActive(false);

                tanqueSeis.gameObject.SetActive(false);

                break;

            case 2:

                tanqueUno.gameObject.SetActive(true);

                tanqueDos.gameObject.SetActive(true);

                tanqueTres.gameObject.SetActive(false);

                tanqueCuatro.gameObject.SetActive(false);

                tanqueCinco.gameObject.SetActive(false);

                tanqueSeis.gameObject.SetActive(false);

                break;

            case 1:

                tanqueUno.gameObject.SetActive(true);

                tanqueDos.gameObject.SetActive(false);

                tanqueTres.gameObject.SetActive(false);

                tanqueCuatro.gameObject.SetActive(false);

                tanqueCinco.gameObject.SetActive(false);

                tanqueSeis.gameObject.SetActive(false);

                break;

            case 0:

                tanqueUno.gameObject.SetActive(false);

                tanqueDos.gameObject.SetActive(false);

                tanqueTres.gameObject.SetActive(false);

                tanqueCuatro.gameObject.SetActive(false);

                tanqueCinco.gameObject.SetActive(false);

                tanqueSeis.gameObject.SetActive(false);

                textoBoss.gameObject.SetActive(false);

                break;

            default:

                tanqueUno.gameObject.SetActive(false);

                tanqueDos.gameObject.SetActive(false);

                tanqueTres.gameObject.SetActive(false);

                tanqueCuatro.gameObject.SetActive(false);

                tanqueCinco.gameObject.SetActive(false);

                tanqueSeis.gameObject.SetActive(false);

                textoBoss.gameObject.SetActive(false);

                break;
        }

    }

}
