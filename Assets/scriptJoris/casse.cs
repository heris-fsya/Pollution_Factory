using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class casse : MonoBehaviour
{
   
    public GameObject[] batiment;// vide puis on charge un batiment (trouvé une supression)
    public Vector3 possition;
    public Quaternion rotation;
    private int build = -1;
    private GameObject building=null;
    //public ligneScript ligneScript;
    public Resource_controllerScript ressource;
    enum nom
    {
        Vide = -1,
        Foret,//arbre
        Mine,
        UsinePhone,
        UsineEolienne,
        UsineCar,
        Recyclage,
        silo,
        Mine2,
        UsinePhone2,
        UsineEolienne2,
        UsineCar2,
        //Recyclage2,
        silo2,
        sapin,
        rocher,

    }

    public bool one = true;

    

    // Start is called before the first frame update
    void Start()
    {
        possition = (transform.position)+possition;
        ressource=GameObject.Find("Resource_controller").GetComponent<Resource_controllerScript>();
        

        //Debug.Log();
    }

    // Update is called once per frame
    void Update()
    {
        //selection();
        
    }

    void turn()
    {

        

    }

    



    
   public void creebat(int n)
    {
        //supresion batiment si existe
        switch (build)
        {
            case 0: ; break;
            case 1: ; break;
            case 2: ; break;
            case 3: ; break;
            default:break;
        }

        //ajout batiment
        build = n;
        switch (build)
        {
            case 0: ressource.addArbre(); break;
            case 1: ressource.addMine(); break;
            case 2: ressource.addUsine(); break;
            case 3: ressource.addRecyclage(); break;
            default: break;
        }
        //
        if (building.IsUnityNull())
        {
            
            building = Instantiate(batiment[n], possition, rotation, transform);
        }
        else 
        { 

            Destroy(building);
            building =Instantiate(batiment[n], possition, rotation, transform);
            
        }
    }
}
