using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet Obj;

    private void Start()
    {
        Obj = ObjectManager.GetInstance().Obj;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Bullet Temp = Instantiate(Obj);
            Temp.transform.parent = ObjectManager.GetInstance().EnableList;
            ObjectManager.GetInstance().BulletList.Add(Temp);
        }
    }
}
