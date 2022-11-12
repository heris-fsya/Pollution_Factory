using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionTours : MonoBehaviour
{

    public barreProgression barre;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bonjour je suis le gestionnaire de tours");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Tu as appuyé, bravoooooooo !");
        barre.variationBarre(0.001f);
    }
}
