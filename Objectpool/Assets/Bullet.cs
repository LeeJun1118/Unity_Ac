using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.transform.gameObject.SetActive(false);
        ObjectManager.GetInstance().ChangeActive(this);
    }
}
