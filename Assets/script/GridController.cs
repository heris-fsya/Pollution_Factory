using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridController : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] GameObject prefabCase;
    [SerializeField] int gridX;
    [SerializeField] int gridY;

    GameObject[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        this.GenerateGrid(gridX, gridY);
        Debug.Log(grid[1,2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid(int width, int height)
    {
        this.grid = new GameObject[gridX, gridY];

        for(int x=0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject createdCase = Instantiate(prefabCase, new Vector3(20 * x, 0, 20 * y), Quaternion.identity, parentObject.transform);
                if((x%2 == 0 && y%2 != 0) || (x % 2 != 0 && y % 2 == 0))
                {
                    createdCase.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
                this.grid[x, y] = createdCase;

                CaseScript case_obj = createdCase.GetComponent<CaseScript>();

            }
        }
    }
}
