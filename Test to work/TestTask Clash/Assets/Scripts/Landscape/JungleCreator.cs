using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleCreator : MonoBehaviour
{

    [SerializeField] private Transform Left;    
    [SerializeField] private Transform Right;    
    [SerializeField] private Transform Top;    
    [SerializeField] private Transform Bot;
    [SerializeField] private int IterationNumber;
    [SerializeField] private GameObject[] ArreyOfTree;

    private void Start() {

        for(int i = 0; i<= IterationNumber; i++) {

            Instantiate(ArreyOfTree[Random.Range(0, ArreyOfTree.Length)],
                new Vector3(Random.Range(Left.position.x, Right.position.x), 0, Random.Range(Top.position.z, Bot.position.z)),
                Quaternion.identity, transform);
        
        }
    }


}
