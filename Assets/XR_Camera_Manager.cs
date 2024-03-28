using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XR_Camera_Manager : MonoBehaviour
{
    public GameObject XROrigin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        XROrigin.transform.position = new Vector3(this.transform.position.x+0.01f, this.transform.position.y - 0.06f, this.transform.position.z + 0.39f);
        
    }
}
