using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class barreProgression : MonoBehaviour
{

    //public Resource_controllerScript ressource;
    //ressource=GameObject.Find("Resource_controller").GetComponent<Resource_controllerScript>();

    static Image Barre;

    [SerializeField] GameObject TMPpourcentage;
    private TextMeshProUGUI textPourcentage;

    //public float maxBarre { get; set; }

    private float pollutionActuelle = 0;

    //Accessible que dans le fichier
    //private float ValeurBarre;
    //Accessible partout
    /*
    [SerializeField]
    public float valeur {
        get { return ValeurBarre; }
        set {
            //Mathf.Clamp g�re le min/max
            ValeurBarre = Mathf.Clamp (value, 0, maxBarre);
            if(Barre != null){ 
                Debug.Log("Shiba");
                Barre.fillAmount = (1 / maxBarre) * ValeurBarre;
            }
            else{
                Debug.Log("pas glop");
            }

        }
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        
        Barre = GetComponent<Image> ();

        /*
        if(Barre != null){ 
            Debug.Log("allô");
        }
        else{
            Debug.Log("pas glop");
        }
        */

        Barre.fillAmount = 0;

        this.textPourcentage = TMPpourcentage.GetComponent<TextMeshProUGUI>();
        
    }



    public void variationBarre(float variation) {
        if (variation < 1.0f){
            //Debug.Log("variation Barre");
            //Debug.Log("SHIBA : " + variation);
            Barre.fillAmount += variation;
            pollutionActuelle += variation;
        }
        if (pollutionActuelle >= 1.0f){
            Debug.Log("GAME OVER");
        }
        Debug.Log("--------");
        Debug.Log(Barre.fillAmount);

        textPourcentage.SetText("Pourcentage " + Barre.fillAmount*100 + "%");
    }

    

    void Update()
    {
      //print(Barre);
      //Barre.fillAmount += 0.1f;
        
    }

}
