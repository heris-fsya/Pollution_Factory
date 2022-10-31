using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour{

     public void changeScene(int sceneNumber){
        SceneManager.LoadScene(sceneNumber);
        Debug.Log("shiba");
     }
     //In the Exit() function, we use the Application.Quit() function.

    
}
