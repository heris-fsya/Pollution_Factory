using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;




public class Ressource
{
   private string nomRessource;
   private int valeurRessource;
   private int quantiteRessource;   
   private float valeurPollutionParTours;


   public Ressource(string n, int v, int q, float vpt)
   { 
   this.nomRessource = n; this.valeurRessource = v; this.quantiteRessource = q; this.valeurPollutionParTours = vpt;
   }

   public Ressource(Ressource n) { nomRessource = n.getName(); valeurRessource = n.getValeurRessource(); quantiteRessource = n.getQuantite(); valeurPollutionParTours = n.getPollutionTours(); }

   public string getName() { return nomRessource; }
   public int getValeurRessource() { return valeurRessource; }
   public int getQuantite() { return quantiteRessource; }
   public float getPollutionTours() { return valeurPollutionParTours; }

   public void setQuantite(int quantite) { this.quantiteRessource = quantite; }

   public void ajouteUn() {this.quantiteRessource ++;}

}

public class ressourceManager : MonoBehaviour
{

    [SerializeField] int argent = 10000;

    private Ressource[] nosRessources;

    private Ressource Lithium, Cuivre, Silicium, Neodyme, Telephone, Batterie, Eolienne, Recyclage,Silo;
    [SerializeField] float polLithium, polCuivre, polSilicium, polNeodyme;

    private float pollutionParTours = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Lithium=new Ressource("Lithium",1000, 0, polLithium);
        Cuivre= new Ressource("Cuivre", 1000, 0,polCuivre);
        Silicium = new Ressource("Silicium", 5000, 0,polSilicium);
        Neodyme = new Ressource("Neodyme", 5000, 0,polNeodyme);
        Telephone = new Ressource("Telephone", 1000, 0,0.1f);
        Batterie = new Ressource("Batterie", 1000, 0,0.1f);
        Eolienne = new Ressource("Eolienne", 1000, 0,0.1f);
        Recyclage = new Ressource("Recyclage", 1000, 0,-0.2f);
        Silo =  new Ressource("Silo", 500, 0,0f);

        nosRessources = new Ressource[]{Lithium, Cuivre, Silicium, Neodyme, Telephone, Batterie, Eolienne, Recyclage, Silo};


    }

    public float calculPollutionTour(){
        pollutionParTours = 0;
        foreach(Ressource r in nosRessources){
            pollutionParTours += r.getQuantite() * r.getPollutionTours();
        }
        return pollutionParTours;
    }

    public Ressource trouveRessource(GameObject go){
        int i;
        switch (go.name){ 
            case "MineLithiumCobalt_3D":
                i = 0;
                break;
            case "MineCuivre_3D" :
                i = 1;
                break;
            case "MineSilicium_3D":
                i = 2;
                break;
            case "MineNeodyme_3D":
                i = 3;
                break;
            case "UsinePhone_3D":
                i = 4;
                break;
            case "UsineCar_3D":
                i = 5;
                break;
            case "UsineEolienne_3D":
                i = 6;
                break;
            case "sapin_3D":
                i = 7;
                break;
            case "silo_3D":
                i = 8;
                break;
            default : 
                Debug.Log("FUCK");
                return null;
       
        }
        return nosRessources[i];
    }

    public bool argentOK(Ressource r){
        return r.getValeurRessource() <= argent;
    }

    public void buy(Ressource r){
        argent -= r.getValeurRessource();
        r.ajouteUn();
    }

    public int getArgent(){
        return argent;
    }

    #region variable produit

    public int phoneT, batteryT, aimantEolienneT;//prod produit (nom+T pour tour l'évolution du produit sur un tour)


    //prix produit en $
    private int phoneVal = 600;
    private int batteryVal = 5000;
    private int aimantEolienneVal = 20000;

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

  
    #endregion

    #region fontion batiment

    public void addSilo() { silo++; maxStockage += siloStockagevalue; }
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
    public void addUsinePhone() { UsinePhone++; }
    public void removeUsinePhone() { UsinePhone--; }
    public void addUsineEolienne() { UsineEolienne++; }
    public void removeUsineEolienne() { UsineEolienne--; }
    public void addUsineCar() { UsineCar++; }
    public void removeUsineCar() { UsineCar--; }
    #endregion


    public void addRecyclage() { recyclage++; }
    public void removeRecyclage() { recyclage--; }

    #endregion



}


