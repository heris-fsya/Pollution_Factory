using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class mapControler : MonoBehaviour
{
    public int polution;
    public int polarbre = -1;
    public int polmine = +1;
    public int polusine = +1;
    public int polrecyclage = -1;
    public ligneScript[] ligne;



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

    private void Awake()
    {
        

    }
    void Start()
    {
        setPol();
        polution = 0;
    }

    // Update is called once per frame

    int cycle = 0;
    void Update()
    {
        if (cycle % 200 == 0) { turn(); }
        cycle++;
    }
   public void setPol()
    {
        for (int x=0; x<ligne.Length; x++) 
        { 
            ligne[x].setPolutionArbre(polarbre);
            ligne[x].setPolutionMine(polmine);
            ligne[x].setPolutionUsine(polusine);
            ligne[x].setPolutionRecyclage(polrecyclage);
        }

    }

    void turn()
    {
        
        for (int x = 0; x < ligne.Length; x++)
        { polution+=ligne[x].Pol();
            ressource(ligne[x].ressource());
        }


        
    }

   private void ressource(int[] res) 
    {
        this.LithiumCobalt += res[0];
        this.Cuivre += res[1];
        this.Sili += res[2];
        this.Neo += res[3];
        this.tel += res[4];
        this.bat += res[5];
        this.panSol += res[6];
        this.aimEole += res[7];
    }

    };


