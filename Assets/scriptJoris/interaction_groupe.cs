using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction_groupe : MonoBehaviour
{
    [HideInInspector] public GameObject caseSelected;
    [SerializeField] private GameObject menu;
    [SerializeField] GameObject prefabUsine;
    [SerializeField] GameObject prefabRecyclage;
    [SerializeField] GameObject prefabMine;
    [SerializeField] GameObject prefabArbre;
    private bool menu_opened = false;
    private bool touch_me = false;

    // Update is called once per frame
    void Update()
    {

        


        if ((Input.touchCount > 0) && (menu_opened == false ))
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out RaycastHit hitinfo))
                {
                    this.CaseClicked(hitinfo.transform.gameObject);
                }
            }   
        }
    }

    void CaseClicked(GameObject objCase)
    {
        caseSelected = objCase;
        this.menu.SetActive(true);
        menu_opened = true;
    }

    enum nom
    {
        Vide = -1,
        Foret,
        Mine,
        Usine,
        Recyclage,
        Mine2,
        Usine2,
        Recyclage2

    }

    public void placerbatiment1()
    {
        caseSelected.GetComponent<casse>().creebat((int)nom.Usine);
        //Instantiate(prefabUsine, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
        
        
    }
}
