using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCreator : MonoBehaviour
{

    [SerializeField] private CenBuildObj cenBuild;
    [SerializeField] private RestartBuild restarBuild;


    public void CreateBuld(GameObject buid) {

        GameObject buildTemp = Instantiate(buid, transform.position, Quaternion.identity, transform);

        cenBuild.SetObject(buildTemp);
        restarBuild.SetObject(buildTemp);

    }
}
