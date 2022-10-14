using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public int speedVertical;
    public int speedHorizontal;
    public int speedUP;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Zoom(int a) 
    {
        transform.Translate(Vector3.forward * 5f * Time.fixedDeltaTime  * speedVertical*a);
    }
    

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 5f * Time.fixedDeltaTime * Input.GetAxis("Vertical")* speedVertical);
        transform.Translate(Vector3.right * 5f * Time.fixedDeltaTime * Input.GetAxis("Horizontal")* speedHorizontal);
        transform.Translate(Vector3.up * 5f * Time.fixedDeltaTime * Input.GetAxis("Horizontal") * speedUP);

        if(Input.GetButton("Jump"))
            { Zoom(1);  }
 


    }
}
