using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenBuildObj : MonoBehaviour
{
    [SerializeField] private GameObject Bilding;
    [SerializeField] private GameObject Perent;
    [SerializeField] private GameObject StorButton;

    public void SetObject(GameObject obj) {
        Bilding = obj;
    }

    public void ActivButton() {

        if(Bilding.GetComponent<BildingPosition>().CenBuild()) {

            Bilding.GetComponent<BildingPosition>().Build();
            StorButton.SetActive(true);
            Perent.SetActive(false);
        }
    }
}
