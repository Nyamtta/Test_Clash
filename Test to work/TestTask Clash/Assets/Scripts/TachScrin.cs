using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TachScrin : MonoBehaviour
{
    [SerializeField] private GameObject CubeTest;

    private void Update() {
        
        if(Input.GetMouseButtonDown(0)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycast, 999f);
            if(raycast.transform.gameObject == CubeTest) {
              // ray
            }
        }

    }


}
