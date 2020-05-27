using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBuild : MonoBehaviour
{

    [SerializeField] private GameObject Bilding;

    public void SetObject(GameObject obj) {
        Bilding = obj;
    }

    public void ActivButton() {

        Destroy(Bilding);
    }

}
