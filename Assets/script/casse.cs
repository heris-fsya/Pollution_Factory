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
    private int polution;
    private int build = -1;
    private GameObject building=null;
    public ligneScript ligneScript;



    // Start is called before the first frame update
    void Start()
    {
        possition = (transform.position)+possition;
       
        //Debug.Log();
    }

    // Update is called once per frame
    void Update()
    {
        selection();
    }

    void turn()
    {

        

    }

    public bool one = true;

    public int n = -1;
    void selection()
    {
        
        if (one  && build!=n) { creebat(n ); /*one = !one;*/ }
        
    }
    
    void creebat(int n)
    {

        switch (build)
        {
            case 0: ligneScript.removeArbre(); break;
            case 1: ligneScript.removeMine(); break;
            case 2: ligneScript.removeUsine(); break;
            case 3: ligneScript.removeRecyclage(); break;
            default:break;
        }
        build = n;
        switch (build)
        {
            case 0: ligneScript.addArbre(); break;
            case 1: ligneScript.addMine(); break;
            case 2: ligneScript.addUsine(); break;
            case 3: ligneScript.addRecyclage(); break;
            default: break;
        }
        //Debug.Log(building.IsUnityNull());
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
