using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager() { }

    static private GameManager Instance = null;

    static public GameManager GetInstance()
    {
        if (Instance == null)
            Instance = new GameManager();
        return Instance;
    }

    public GameObject Monster;
    private float ftime;
    private bool Count;
    public GameObject Repoint;
    public Transform Center;
    private List<GameObject> RePointList = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            GameObject Obj = Instantiate(Repoint);

            Obj.transform.position = new Vector3(
                Random.Range(Center.position.x - 100, Center.position.x + 100),
                0.0f,
                Random.Range(Center.position.z - 100, Center.position.z + 100)
                );

            Obj.transform.parent = GameObject.Find("WayPointList").transform;

            RePointList.Add(Obj);
        }

        Monster = GameObject.Find("Monster").transform.gameObject;

        ftime = 0;
        Count = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("MousePosition");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                hit.transform.gameObject.SetActive(false);

                Count = false;

                ftime = 2.0f;
                Monster.transform.position = RePointList[Random.Range(1, RePointList.Count)].transform.position;
            }
        }
        if (Count == true)
        {
            ftime -= Time.deltaTime;

            if(ftime < 0)
            {
                ftime = 0;
                Count = false;
                Monster.transform.Find("Cube").gameObject.SetActive(true);
            }
        }
    }

}
