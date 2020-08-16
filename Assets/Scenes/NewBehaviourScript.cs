using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i=2; i<10; i++){
            for(int j=1; j<10; j++){
                Debug.Log(i + " X " + j + "=" + i*j);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
