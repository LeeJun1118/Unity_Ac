using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private ObjectManager() { }
    static private ObjectManager Instance;
    static public ObjectManager GetInstance()
    {
        if (Instance == null)
            Instance = GameObject.FindObjectOfType(typeof(ObjectManager)) as ObjectManager;
        return Instance;

    }


    public Bullet Obj;

    public Transform EnableList;
    public Transform DisableList;

    public List<Bullet> BulletList = new List<Bullet>();
    public Stack<Bullet> BulletStack = new Stack<Bullet>();


    private void Awake()
    {
        EnableList = GameObject.Find("BulletList").transform.Find("EnableList");
        DisableList = GameObject.Find("BulletList").transform.Find("DisableList");
    }

    public void ChangeActive(Bullet _Obj)
    {
        BulletList.Remove(_Obj);
        _Obj.transform.gameObject.transform.parent = DisableList;
        BulletStack.Push(_Obj);
    }


}
