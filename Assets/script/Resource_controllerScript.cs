using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public class Ressource
{
   private string nom;
   private int valeur;
   private int quantite;


    public Ressource(string n, int v, int q)
    { nom = n; valeur = v; quantite = q; }
    public Ressource(Ressource n) { nom = n.getName(); valeur = n.getValeur(); quantite = n.getQuantite(); }

    public string getName() { return nom; }
    public int getValeur() { return valeur; }

    public int getQuantite() { return quantite; }

    public void setQuantite(int quantite) { this.quantite = quantite; }

    public int turn(int quantiteT, int maxStockage)
    {
        int n = 0;
        quantite += quantiteT;
        if (quantite > maxStockage) { quantite = maxStockage; }
        if (quantite < 0) { n -= valeur * quantite; quantite = 0; }

        return n;
    }

    public bool plusGrandQue(Ressource n) { return n.getQuantite() < quantite; }

    public bool memeNomQue(Ressource n) { return string.Equals(n.getName(), nom);  }

    public Ressource clonageQ(int n) // la meme ressource dans des quantitée dif
    { Ressource t= new Ressource(this);
        t.setQuantite(n);
        return t;
    }


}

public class Resource_controllerScript : MonoBehaviour
{
    public bool nextTurn;

    [SerializeField]
    public int Polution /*{ get; private set; }*/;
    //public int nbr;
    public int Nturn;//le nombre de tour fait;

    

    public int dollard /*{ get; private set; }*/;

    public int polarbre = -1;
    public int polmine = +1;
    public int polusine = +1;
    public int polrecyclage = -1;
    public int siloStockagevalue = +100;

    public int maxStockage=-100;

    //stock ressource 
    

    


    private Ressource LithiumCobalt;
    private Ressource Cuivre;
    private Ressource Silicium;
    private Ressource Neo;

    //prod ressource (nom+T pour tour l'évolution de la ressource sur un tour)
    public int LithiumCobaltT;
    public int CuivreT;
    public int SiliciumT;
    public int NeoT;

    //prod produit (nom+T pour tour l'évolution du produit sur un tour)
    public int phoneT;
    public int batteryT;//voiture
    public int aimantEolienneT;

    /*//stock produit pour géner de la polution
    public int phone;
    public int battery;
    public int aimantEolienne;*/

    //prix produit en $
    private int phoneVal=600;
    private int batteryVal=5000;
    private int aimantEolienneVal=20000;

    //prix produit ressource
    
    private Ressource[] phoneRes ;
    private Ressource[] batteryRes  ;
    private Ressource[] aimantEolienneRes  ;

    //variable pour le passage de tour
    private int polutionT;


    enum nom// liste des batiment pour référence 
    {
        Vide = -1,
        Foret,//arbre
        Mine,
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

    //nombre de batiment 
    public int arbre;
    public int mine;
    public int usine;
    public int silo;
    public int recyclage;


    void Start()
    {
        nextTurn = false;
        
        LithiumCobalt=new Ressource("LithiumCobalt",100, 0);
        Cuivre= new Ressource("Cuivre", 100, 0);
        Silicium = new Ressource("Silicium", 100, 0);
        Neo = new Ressource("Neodyme", 100, 0);

        
        phoneRes = new Ressource[] 
        { LithiumCobalt.clonageQ(6), Cuivre.clonageQ(6) };

        batteryRes= new Ressource[] 
        { LithiumCobalt.clonageQ(15), Cuivre.clonageQ(15), Silicium.clonageQ(15) };

        aimantEolienneRes = new Ressource[] 
        { Cuivre.clonageQ(60), Neo.clonageQ(60) };

    }

    
    void Update()
    {
        if (nextTurn) { turn(); }
    }

    
 

    void turn()// passage du tour
    {
        nextTurn = false;


        LithiumCobalt.turn(LithiumCobaltT,maxStockage);
        Cuivre.turn(CuivreT, maxStockage);
        Silicium.turn(SiliciumT, maxStockage);
        Neo.turn(NeoT, maxStockage);

        dollard+=phoneT* phoneVal;
        dollard+=batteryT* batteryVal;
        dollard+=aimantEolienneT* aimantEolienneVal;



        if (Nturn % 2 == 0) { polutionT += arbre * polarbre; }

        Polution += polutionT;
        Nturn += 1;
    }

    public void addSilo() { silo++;maxStockage += siloStockagevalue; }
    public void removeSilo() { silo--; maxStockage -= siloStockagevalue; }

    public void addArbre() { arbre++; }
    public void removeArbre() { arbre--; }

    public void addMine() { mine++; }
    public void removeMine() { mine--; }

    public void addUsine() { usine++;  }
    public void removeUsine() { usine--;  }

    public void addRecyclage() { recyclage++; }
    public void removeRecyclage() { recyclage--;  }





}
