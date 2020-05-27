using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GridSystem : MonoBehaviour
{
    
    [SerializeField] private GameObject Cell;
    [SerializeField] private Vector2 GridSize;
    [SerializeField] private GameObject[] Lendscape;

    private List<GameObject> ArreyCell = new List<GameObject>();

    private void Start() {

        InstabtiataGrid();
        
        ActivCameraBorders();
    }

    public void ActivScrenGrid() {

        foreach(var cell in ArreyCell) {

            cell.GetComponent<Cell>().ChowCell();
        }
    }

    private void RandomLandscape(float x,float z) {
        
        Instantiate(Lendscape[Random.Range(0, Lendscape.Length)], new Vector3(transform.position.x - x,
         transform.position.y, transform.position.z - z),
         Quaternion.identity, gameObject.transform);
    }

    private void ActivCameraBorders() {

        Camera.main.GetComponent<CameraMov>().SetGritEngle(ArreyCell.First().transform.position, ArreyCell.Last().transform.position);

    }

    private void InstabtiataGrid() {

        for(int i = 0; i < GridSize.x; i++) {
            for(int j = 0; j < GridSize.y; j++) {

                GameObject temp = Instantiate(Cell, new Vector3(transform.position.x - i,
                    transform.position.y, transform.position.z - j),
                    Quaternion.identity, gameObject.transform);

                if(Random.Range(0, 101) < 2) {

                    RandomLandscape(i, j);
                }

                ArreyCell.Add(temp);
            }
        }

    }

}
