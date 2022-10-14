using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casse : MonoBehaviour
{
   
    public GameObject[] batiment;// vide puis on charge un batiment (trouvé une supression)
    public Vector3 possition;
    public Quaternion rotation;

        // Start is called before the first frame update
        void Start()
    {
        possition = (transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        selection();
    }
    private int one = 0;
    void selection()
    {

        if (one == 0) { creebat(0 ); one += 1; }
        
    }
    
    void creebat(int n)
    {
        
        Instantiate(batiment[n], possition, rotation, transform);
    }
}
