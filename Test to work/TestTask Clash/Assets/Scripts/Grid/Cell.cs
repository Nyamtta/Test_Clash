using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private bool ActivCell;
    [SerializeField] private GameObject CellComponent;
    [SerializeField] private Material GrinMaterial;
    [SerializeField] private Material RedMaterial;

    private void Start() {

        ActivCell = true;
    }

    public bool GetActivCell() {

        return ActivCell;
    }

    public void ChowCell() {

        CellComponent.SetActive(!CellComponent.activeSelf);
        
        if(ActivCell == false) {
            CellComponent.GetComponent<MeshRenderer>().material = RedMaterial;
        }
        else
            CellComponent.GetComponent<MeshRenderer>().material = GrinMaterial;
    }

    public void ChengCellActiv() {

        ActivCell = !ActivCell;
    }

}
