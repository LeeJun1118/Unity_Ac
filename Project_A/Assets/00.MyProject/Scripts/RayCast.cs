using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public GameObject EffectObj;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            StartRay(ray);
        }
    }

    void StartRay(Ray _ray)
    {
        RaycastHit Hit;

        if (Physics.Raycast(_ray, out Hit, Mathf.Infinity))
        {
            Debug.Log("Raycast");

            if (Hit.transform.tag.Equals("Wall"))
            {
                Debug.Log("Hit: Wall");
                if (Hit.transform.name.Equals("Cube"))
                {
                    Debug.Log("Hit: Cube");

                    GameObject obj = Instantiate(EffectObj);

                    obj.transform.position = Hit.point;
                    obj.transform.parent = GameObject.Find("EffectList").transform;
                    Hit.transform.gameObject.SetActive(false);
                }
            }
        }
    }


}
