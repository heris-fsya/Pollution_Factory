using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ligneScript : MonoBehaviour
{
    public mapControler map;
    public casse[] plate;//10 case

    public int polution;
    private int cycle;

    //nb batiment
    public int arbre;
    public int mine;
    public int usine;
    public int recyclage;
    //pol val
    public int polarbre ;
    public int polmine ;
    public int polusine ;
    public int polrecyclage ;

    //prod ressource 
    public int LithiumCobalt;
    public int Cuivre;
    public int Sili;
    public int Neo;

    

    //prod produit
    public int tel;
    public int bat;
    public int panSol;
    public int aimEole;

    void Start()
    {
        LithiumCobalt=0;
        Cuivre=0;
        Sili=0;
        Neo=0;

        tel=0;
        bat=0;
        panSol = 0;
        aimEole = 0;

        cycle = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void addArbre() { arbre++; polution += polarbre; }
    public void removeArbre() { arbre--; polution -= polarbre; }

    public void addMine() { mine++; polution += polmine; }
    public void removeMine() { mine--; polution -= polmine; }

    public void addUsine() { usine++; polution += polusine; }
    public void removeUsine() { usine--; polution -= polusine; }

    public void addRecyclage() { recyclage++; polution += recyclage; }
    public void removeRecyclage() { recyclage--; polution -= recyclage; }







    public void setPolutionArbre(int n)
    {
        polarbre = n;
    }

    public void setPolutionMine(int n)
    {
        polmine = n;
    }
    public void setPolutionUsine(int n)
    {
        polusine = n;
    }
    public void setPolutionRecyclage(int n)
    {
        polrecyclage = n;
    }




    public void addPol(int n)
    {
        polution += n;
    }

    public int Pol()
    {
        cycle++;
        if (cycle % 2 == 0)
        { return polution; }
        else
        { return (polution - arbre* polarbre); 
        
        }
    }

    public int[] ressource()
    {
         int[] ressource = { LithiumCobalt, Cuivre, Sili, Neo, tel , bat , panSol, aimEole };
        return ressource;

    }






}
