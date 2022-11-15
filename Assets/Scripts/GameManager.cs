using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 
  
  

    public List<GameObject> l_canvas = new List<GameObject>();
    public static bool multiTouchEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    l_canvas[0].SetActive(true);
        for (int i = 1; i < 3; i++)
        {
            l_canvas[i].SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
    

    }
}
