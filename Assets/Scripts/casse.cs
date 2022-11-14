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





    enum nom
    {
        Vide = -1,
        Foret,//arbre
        MineLithiumCobalt,
        MineCuivre,
        MineSilicium,
        MineNeodyme,
        UsinePhone,
        UsineEolienne,
        UsineCar,
        Recyclage,
        silo,
        Mine2,// le meme que le 1 en model 3d
        UsinePhone2,
        UsineEolienne2,
        UsineCar2,
        //Recyclage2,
        silo2,
        sapin,
        rocher,
    }


    public void creebat(int n)
    {
        //supresion batiment si existe
        switch (build)
        {
            case 0: ressource.removeArbre(); break;
            case 1: ressource.removeMineLithiumCobalt(); break;
            case 2: ressource.removeMineCuivre(); break;
            case 3: ressource.removeMineNeodyme(); break;
            case 4: ressource.removeMineLithiumCobalt(); break;
            case 5: ressource.removeUsinePhone(); break;
            case 6: ressource.removeUsineEolienne(); break;
            case 7: ressource.removeUsineCar(); break;
            case 8: ressource.removeRecyclage(); break;
            case 9: ressource.removeSilo(); break;
            default: break;
        }

        //ajout batiment
        
        //
        if (build==-1)
        {
            
            building = Instantiate(batiment[n], possition, rotation, transform);
        }
        else 
        {
            building.active=false;
            //Destroy(building);
            building =Instantiate(batiment[n], possition, rotation, transform);
            
        }

        build = n;
        switch (build)
        {
            case 0: ressource.addArbre(); break;
            case 1: ressource.addMineLithiumCobalt(); break;
            case 2: ressource.addMineCuivre(); break;
            case 3: ressource.addMineNeodyme(); break;
            case 4: ressource.addMineLithiumCobalt(); break;
            case 5: ressource.addUsinePhone(); break;
            case 6: ressource.addUsineEolienne(); break;
            case 7: ressource.addUsineCar(); break;
            case 8: ressource.addRecyclage(); break;
            case 9: ressource.addSilo(); break;
            default: break;
        }
    }
}
