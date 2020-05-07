using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase controladora del checkpoint
public class ControladorCheckpoint : MonoBehaviour {

    public static ControladorCheckpoint instancia;

    private Checkpoint[] checkpoints;

    public Vector3 puntoSpawn;

    private void Awake() {

        instancia = this;

    }

    // Start is called before the first frame update
    void Start()  {

        checkpoints = FindObjectsOfType<Checkpoint>();

        puntoSpawn = ControladorJugador.instancia.transform.position;

    }

    // Update is called once per frame
    void Update()  {
        


    }

    public void desactivarCheckpoints() {

        for(int i = 0; i < checkpoints.Length; i++) {

            checkpoints[i].resetCheckpoint();

        }

    }

    public void guardarPuntoSpawn(Vector3 puntoSpawnNuevo) {

        puntoSpawn = puntoSpawnNuevo;

    }

}
