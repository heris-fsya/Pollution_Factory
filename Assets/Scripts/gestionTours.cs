using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// Pour utiliser un bouton :
// -> Assigner le script à un gameobject
// -> Dans le onclick du bouton, on assigne l'objet 
// -> Dans la partie fonction, on choisi le composant a utiliser et la fonction a utiliser

public class gestionTours : MonoBehaviour
{

    private barreProgression barre;

    private ressourceManager r;

    [SerializeField] GameObject TMPtours;
    private TextMeshProUGUI textTours;

    private int compteur = 1;

    //private float variationPatate = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bonjour je suis le gestionnaire de tours");
        this.barre = GetComponent<barreProgression>();
        this.textTours = TMPtours.GetComponent<TextMeshProUGUI>();
        this.r = GetComponent<ressourceManager>();
    }

    //Toujours mettre un test sur si c'est null ou pas en cas de getComponent

   

    //public void SetVariation(float f){
    //    this.variationPatate += f;
    //}


    // Update is called once per frame
    public void OnClick()
    {
        if(barre != null){
            print("calculPollutionTour");
            Debug.Log(r.calculPollutionTour());
            barre.variationBarre(r.calculPollutionTour());

        }
        else{
            Debug.Log("barre = null");
        }

        textTours.SetText("Tours : " + compteur);
        compteur ++;
        //variationPatate = 0f;
    }
}
