using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Resource_controllerScript : MonoBehaviour
{
    [SerializeField]
    public int Polution /*{ get; private set; }*/;
    //public int nbr;
    public int Nturn;//le nombre de tour fait;

    public int dollard /*{ get; private set; }*/;

    public int polarbre = -1;
    public int polmine = +1;
    public int polusine = +1;
    public int polrecyclage = -1;


    //prod ressource 
    public int LithiumCobalt;
    public int Cuivre;
    public int silicium;
    public int Neo;

    //prod produit
    public int phone { get; private set; }
    public int battery { get; private set; }
    public int aimantEolienne { get; private set; }

    //variable pour le passage de tour
    private int polutionT;




    //nombre de batiment 
    public int arbre;
    public int mine;
    public int usine;
    public int recyclage;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void turn()
    {
        
        if (Nturn % 2 == 0) { polutionT += arbre * polarbre; }

        Polution += polutionT;
        Nturn += 1;
    }

    public void addArbre() { arbre++; }
    public void removeArbre() { arbre--; }

    public void addMine() { mine++; }
    public void removeMine() { mine--; }

    public void addUsine() { usine++;  }
    public void removeUsine() { usine--;  }

    public void addRecyclage() { recyclage++; }
    public void removeRecyclage() { recyclage--;  }





}
