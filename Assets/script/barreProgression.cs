using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class barreProgression : MonoBehaviour
{

    //public Resource_controllerScript ressource;
    //ressource=GameObject.Find("Resource_controller").GetComponent<Resource_controllerScript>();

    static Image Barre;

    public float maxBarre { get; set; }

    public bool termine = true;

    //Accessible que dans le fichier
    private float ValeurBarre;
    //Accessible partout

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

    // Start is called before the first frame update
    void Start()
    {
        
        Barre = GetComponent<Image> ();
        if(Barre != null){ 
            Debug.Log("allô");
        }
        else{
            Debug.Log("pas glop");
        }

        Barre.fillAmount = 0;
        
    }



    public void variationBarre(float variation) {
        if (variation > 0){
            if (variation < 1.0f){
                Debug.Log("variation Barre");
                Barre.fillAmount += variation;
            }
        }
    }

    

    void Update()
    {
        
      variationBarre(0.001f);
        
    }

}
