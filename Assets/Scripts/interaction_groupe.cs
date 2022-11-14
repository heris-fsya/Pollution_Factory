using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction_groupe : MonoBehaviour
{
    [HideInInspector] public GameObject caseSelected;
    [SerializeField] private GameObject menu;
    /*[SerializeField] GameObject prefabUsineTelephone;
    [SerializeField] GameObject prefabUsineBatterie;
    [SerializeField] GameObject prefabUsineEolienne;
    [SerializeField] GameObject prefabMineLithiumCobalt;
    [SerializeField] GameObject prefabMineCuivre;
    [SerializeField] GameObject prefabMineSilicium;
    [SerializeField] GameObject prefabMineNeodyme;
    [SerializeField] GameObject prefabRecyclage;
    [SerializeField] GameObject prefabSilo;
    [SerializeField] GameObject prefabArbre;*/
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

    public void placerUsineTelephone()
    {
        caseSelected.GetComponent<casse>().creebat((int)nom.UsinePhone);
         menu.SetActive(false);
        menu_opened = false;
        
        
    }

    public void placerUsineBatterie() {
        caseSelected.GetComponent<casse>().creebat((int)nom.UsineCar);
        menu.SetActive(false);
        menu_opened = false;
    }

public void placerUsineEolienne() {
        caseSelected.GetComponent<casse>().creebat((int)nom.UsineEolienne);
        menu.SetActive(false);
        menu_opened = false;
    }

     public void placerMineLithiumCobalt() {
        caseSelected.GetComponent<casse>().creebat((int)nom.MineLithiumCobalt);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerMineCuivre() {
        caseSelected.GetComponent<casse>().creebat((int)nom.MineCuivre);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerMineSilicium() {
        caseSelected.GetComponent<casse>().creebat((int)nom.MineSilicium);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerMineNeodyme() {
        caseSelected.GetComponent<casse>().creebat((int)nom.MineNeodyme);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerRecyclage() {
        caseSelected.GetComponent<casse>().creebat((int)nom.Recyclage);
        menu.SetActive(false);
        menu_opened = false;
    }

    public void placerSilo() {
        caseSelected.GetComponent<casse>().creebat((int)nom.silo);
        menu.SetActive(false);
        menu_opened = false;
    }
}
