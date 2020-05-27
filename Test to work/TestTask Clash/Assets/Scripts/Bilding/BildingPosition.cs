using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BildingPosition : MonoBehaviour {

    [SerializeField] private bool CanBuild;
    [SerializeField] private LayerMask Groundlayer;
    [SerializeField] private LayerMask Buildinglayer;

    private List<GameObject> PositionCells = new List<GameObject>();

    private void Update() {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mousOnGround;
        Physics.Raycast(ray, out mousOnGround, Buildinglayer);

        if(Input.GetMouseButton(0) && Vector3.Distance(mousOnGround.transform.position,transform.position) < 5f) {

            Vector3 SnapCellPosition = PositionCells.First().transform.position;

            foreach(var cell in PositionCells) {

                if(Vector3.Distance(mousOnGround.transform.position, cell.transform.position) < Vector3.Distance(mousOnGround.transform.position, SnapCellPosition)) {

                    SnapCellPosition = cell.transform.position;
                }

            }

            transform.position = new Vector3(SnapCellPosition.x, 0, SnapCellPosition.z);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        
        if(collision.transform.GetComponent<Cell>() == true) {
            PositionCells.Add(collision.transform.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision) {

        if(collision.transform.GetComponent<Cell>() == true) {
            PositionCells.Remove(collision.transform.gameObject);
        }
    }

    public void Build() {

        if(CenBuild()) {
        
            foreach(var tem in PositionCells) {
                tem.GetComponent<Cell>().ChengCellActiv();
            }

            Destroy(GetComponent<BildingPosition>());

        }
    }

    public bool CenBuild() {

        foreach(var temp in PositionCells) {

            if(temp.GetComponent<Cell>().GetActivCell() == false)
                return false;
        }

        return true;
    }

}
