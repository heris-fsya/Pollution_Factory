using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction_groupe : MonoBehaviour
{
    [HideInInspector] public GameObject caseSelected;
    [SerializeField] private GameObject menu;
    [SerializeField] GameObject prefabUsineTelephone;
    [SerializeField] GameObject prefabUsineBatterie;
    [SerializeField] GameObject prefabUsineEolienne;
    [SerializeField] GameObject prefabMineLithiumCobalt;
    [SerializeField] GameObject prefabMineCuivre;
    [SerializeField] GameObject prefabMineSilicium;
    [SerializeField] GameObject prefabMineNeodyme;
    [SerializeField] GameObject prefabRecyclage;
    [SerializeField] GameObject prefabSilo;
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

   public void placerUsineTelephone()
    {
        Instantiate(prefabUsineTelephone, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
        
        
    }

    public void placerUsineBatterie() {
        Instantiate(prefabUsineBatterie, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
    }

public void placerUsineEolienne() {
        Instantiate(prefabUsineEolienne, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
    }

     public void placerMineLithiumCobalt() {
        Instantiate(prefabMineLithiumCobalt, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerMineCuivre() {
        Instantiate(prefabMineCuivre, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerMineSilicium() {
        Instantiate(prefabMineSilicium, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerMineNeodyme() {
        Instantiate(prefabMineNeodyme, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerRecyclage() {
        Instantiate(prefabRecyclage, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerSilo() {
        Instantiate(prefabSilo, caseSelected.transform.position, caseSelected.transform.rotation, caseSelected.transform);
        menu.SetActive(false);
        menu_opened = false;
    }
}
