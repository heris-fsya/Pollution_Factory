using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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

    private Ressource Lithium, Cuivre, Silicium, Neodyme;
    [SerializeField] float polLithium, polCuivre, polSilicium, polNeodyme;

    private float pollutionParTours = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Lithium=new Ressource("Lithium",1000, 0, polLithium);
        Cuivre= new Ressource("Cuivre", 1000, 0,polCuivre);
        Silicium = new Ressource("Silicium", 5000, 0,polSilicium);
        Neodyme = new Ressource("Neodyme", 5000, 0,polNeodyme);

        nosRessources = new Ressource[]{Lithium, Cuivre, Silicium, Neodyme};
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
            case "MineLithiumCobalt" :
                i = 0;
                break;
            case "MineCuivre" :
                i = 1;
                break;
            case "MineSilicium" :
                i = 2;
                break;
            case "MineNeodyme" :
                i = 3;
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
}
