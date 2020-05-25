using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para controlar slider activar musica
public class SliderActivarEfectos : Sliders
{

    public static SliderActivarEfectos instancia;

    private void Awake()
    {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start()
    {

        slider.SetValueWithoutNotify(PlayerPrefs.GetInt("EfectosActivados"));

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void escribirDatos()
    {

        PlayerPrefs.SetInt("EfectosActivados", (int)slider.value);

    }

}
