using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    private void Update()
    {
        float fx = Input.GetAxis("Horizontal");
        float fy = Input.GetAxis("Vertical");

        this.transform.Translate(
            new Vector3(fx * Time.deltaTime * 5, 0, fy * Time.deltaTime * 5));
    }
}
