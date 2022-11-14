using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;




public class Resource_controllerScript : MonoBehaviour
{

    #region variable génerale

    
    public int Polution;//polution génerale
    
    int maxPolution = 1000;//valeur de game over
    
    private int polutionT;//variable pour le passage de tour

    public int Nturn;//le nombre de tour fait;

    public int dollard /*{ get; private set; }*/;

    #endregion







    //public bool nextTurn;











    

    #region variable ressource

    private Ressource LithiumCobalt, Cuivre, Silicium, Neo;//stock ressource 
    
    public int LithiumCobaltT, CuivreT, SiliciumT, NeoT;//prod ressource (nom+T pour tour l'évolution de la ressource sur un tour)

    #endregion

    #region variable produit

    public int phoneT, batteryT, aimantEolienneT;//prod produit (nom+T pour tour l'évolution du produit sur un tour)


    //prix produit en $
    private int phoneVal=600;
    private int batteryVal=5000;
    private int aimantEolienneVal=20000;

    //prix produit ressource
    
    private Ressource[] phoneRes, batteryRes, aimantEolienneRes;

    public Tuple<String, int>[] phoneCost = 
        {   new Tuple<String, int>("LithiumCobalt", 5),
            new Tuple<String, int>("Cuivre", 5), 
            new Tuple<String, int>("Silicium", 0), 
            new Tuple<String, int>("Neodyme",5)};

    public Tuple<String, int>[] batteryCost =
    {   new Tuple<String, int>("LithiumCobalt", 5),
            new Tuple<String, int>("Cuivre", 5),
            new Tuple<String, int>("Silicium", 5),
            new Tuple<String, int>("Neodyme",0)};

    public Tuple<String, int>[] aimantEolienneCost =
    {   new Tuple<String, int>("LithiumCobalt", 5),
            new Tuple<String, int>("Cuivre", 5),
            new Tuple<String, int>("Silicium", 0),
            new Tuple<String, int>("Neodyme",5)};




    #endregion




    #region variable batiment

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


    public int polarbre = -1;
    public int polmine = +1;
    public int polusine = +1;
    public int polrecyclage = -1;
    public int siloStockagevalue = +100;

    public int maxStockage = 100;


    //nombre de batiment 
    public int arbre;
    public int MineLithiumCobalt;
    public int MineCuivre;
    public int MineSilicium;
    public int MineNeodyme;
    public int UsinePhone;
    public int UsineEolienne;
    public int UsineCar;
    public int recyclage;
    public int silo;

    /*//se qui reste a faire
    Mine2
    UsinePhone2
    UsineEolienne2
    UsineCar2
    silo2
    sapin
    rocher*/

    #endregion



    #region fonctio génerale

    void Start()
    {
        //nextTurn = false;
        
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
       // if (nextTurn) { turn(); }
    }

    
    

    void turn()// passage du tour
    {
        //nextTurn = false;


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

    #endregion

    #region fontion batiment

    public void addSilo() { silo++;maxStockage += siloStockagevalue; }
    public void removeSilo() { silo--; maxStockage -= siloStockagevalue; }

    public void addArbre() { arbre++; }
    public void removeArbre() { arbre--; }

    #region fontion batiment Mine

    public void addMineLithiumCobalt() { MineLithiumCobalt++; }
    public void removeMineLithiumCobalt() { MineLithiumCobalt--; }

    public void addMineCuivre() { MineCuivre++; }
    public void removeMineCuivre() { MineCuivre--; }

    public void addMineSilicium() { MineSilicium++; }
    public void removeMineSilicium() { MineSilicium--; }

    public void addMineNeodyme() { MineNeodyme++; }
    public void removeMineNeodyme() { MineNeodyme--; }

    #endregion



    #region fontion batiment Usine
    public void addUsinePhone() { UsinePhone++;  }
    public void removeUsinePhone() { UsinePhone--;  }
    public void addUsineEolienne() { UsineEolienne++; }
    public void removeUsineEolienne() { UsineEolienne--; }
    public void addUsineCar() { UsineCar++; }
    public void removeUsineCar() { UsineCar--; }
    #endregion


    public void addRecyclage() { recyclage++; }
    public void removeRecyclage() { recyclage--;  }

    #endregion



}




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

    public bool memeNomQue(Ressource n) { return string.Equals(n.getName(), nom); }

    public Ressource clonageQ(int n) // la meme ressource dans des quantitée dif
    {
        Ressource t = new Ressource(this);
        t.setQuantite(n);
        return t;
    }


}

