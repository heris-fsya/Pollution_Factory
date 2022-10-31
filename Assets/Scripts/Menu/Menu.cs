using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour{

    [SerializeField] List<GameObject> allMenus = new List<GameObject>();

    public void ShowMenu(GameObject menu){

        foreach( GameObject menu_tmp in allMenus ){
            menu_tmp.SetActive(false);
        }

        menu.SetActive(true);
    }
    
}
