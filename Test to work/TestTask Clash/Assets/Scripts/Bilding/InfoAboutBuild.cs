using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAboutBuild : MonoBehaviour
{
    public string NameBuilding { get; private set; }
    public Vector2 BuildingCellSize { get; private set; }
    public int IdenIdentifier { get; private set; }

    private void Start() {

        NameBuilding = gameObject.name;
        BuildingCellSize = new Vector2(transform.localScale.x, transform.localScale.z);
    }

    public void PrintInfo() {

        print("Name:  " + NameBuilding);
        print("Cell size:  " + (int)BuildingCellSize.x +' ' + (int)BuildingCellSize.y);
        print("IdenIdentifier:  " + gameObject.transform.position.GetHashCode());
    }

}
