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
        XROrigin.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+0.35f);
        
    }
}