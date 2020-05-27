using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CameraMov : MonoBehaviour
{

    [SerializeField] private LayerMask BuildingLayer;
    [SerializeField] private float MinCameraSixe;
    [SerializeField] private float MaxCameraSixe;

    private Vector3 LeftBotEngle;
    private Vector3 RightTopEngle; 
    private Vector3 StartMousPosition;

    private void Update() {

        if(Input.GetMouseButtonDown(0)) {

            StartMousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            CheckBuilding();
        }

        if(Input.GetMouseButton(0)) {

            if(CenMov()) {

                MovCamera();

                CheckGridBorders();
            }
        }

        if(Input.mouseScrollDelta.y != 0) {

            ScrolSizeCamera();
        }

    }

    public void SetGritEngle(Vector3 rightTop,Vector3 leftBot) {
        RightTopEngle = rightTop;
        LeftBotEngle = leftBot;
    }

    private void ScrolSizeCamera() {

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + (-Input.mouseScrollDelta.y), MinCameraSixe, MaxCameraSixe);
    }

    private void MovCamera() {

        Vector3 tempMp = Camera.main.ScreenToWorldPoint(Input.mousePosition) - StartMousPosition;
        
        transform.position = new Vector3(transform.position.x - tempMp.x, transform.position.y, transform.position.z - tempMp.z);
    }

    private void CheckGridBorders() {

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LeftBotEngle.x, RightTopEngle.x),
            transform.position.y, Mathf.Clamp(transform.position.z,LeftBotEngle.z-5f, RightTopEngle.z));
    }
    
    private void CheckBuilding() {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mousOnGround;

        Physics.Raycast(ray, out mousOnGround, BuildingLayer);

        mousOnGround.transform.GetComponent<InfoAboutBuild>()?.PrintInfo();
    }

    private bool CenMov() {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mousOnGround;

        Physics.Raycast(ray, out mousOnGround, BuildingLayer);

        if(mousOnGround.transform.GetComponent<BildingPosition>() == true) {
            return false;
        }
        return true;
    }
}
