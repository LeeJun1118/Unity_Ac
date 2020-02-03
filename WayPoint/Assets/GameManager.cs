using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameManager() { }

    static private GameManager Instance = null;

    static public GameManager GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new GameManager();

            return Instance;
        }
    }
    /*

    static public GameManager GetInstance()
    {
         if (Instance == null)
              Instance = new GameManager();
         return Instance;
    }
    */



    //** 가장 간단한 Singleton
    /*
    public void Awake()
    {
         Instance = this;
    }
    */


    //** 자기 자신이 객체 상태로 포함되는 Singleton
    /* 
    static private GameObject Container;

    static public GameManager GetInstance
    {
         get
         {
              if (Instance == null)
              {
                   Container = new GameObject();
                   Container.name = "GameManager";
                   Instance = Container.AddComponent(typeof(GameManager)) as GameManager;
              }
              return Instance;
         }
    }
    */


    /*public void Awake()
    {
        Instance = this;
    }*/

    // 플레이어 파싱 
    public GameObject Player;

    // 플레이어 리스폰 시간
    private float ftime;

    // 플레이어 리스폰 시작 타이밍 
    private bool Count;

    //리스폰 될 위치
    public GameObject RePoint;

    // RePoint가 현재 좌표를 중심으로 여러개가 생성될 것.
    public Transform Center;

    // 여러개가 생성되면 한곳에서 관리하기 위해 List로 만들어줌
    private List<GameObject> RePointList = new List<GameObject>();

    private void Start()
    {
        // RePoint 를 10개 만든다 
        for (int i = 0; i < 10; i++)
        {
            // 복사해주고
            GameObject Obj = Instantiate(RePoint);

            //복사된 객체의 좌표를 랜덤으로 지정함. 이때 Y좌표는 고정시킨다. 
            Obj.transform.position = new Vector3(
                Random.Range(Center.position.x - 3, Center.position.x + 3),
                0.0f,
                Random.Range(Center.position.z - 5, Center.position.z + 5));

            // 복사된 객체의 부모를 미리 만들어둔 "WayPointList" 로 둔다. 
            Obj.transform.parent = GameObject.Find("WayPointList").transform;

            // 모든 초기화가 종료되면 List에 넣는다.
            RePointList.Add(Obj);
        }

        // 플레이어 파싱 
        Player = GameObject.Find("Player").transform.gameObject;

        // 시간 초기화
        ftime = 0;

        // 플레이어가 나올 타이밍은 false
        Count = false;
    }

    void Update()
    {
        // 마우스 좌측 버튼을 클릭하면
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mousePosition");

            // 레이 캐스팅을 시작한다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 타격 될 정보를 받는 곳.
            RaycastHit hit;

            // 만약 ray의 방향으로 가상의 레이저를 Mathf.Infinity(무한대) 만큼 쏘았을 때 타격(hit)되었다면 
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("Raycast");

                // hit된 대상의 정보중 이름이 "Player"라면 
                if (!hit.transform.name.Equals("Player"))
                {
                    Debug.Log("hit");

                    //hit된 객체를 SetActive(false) Disable시킨다. "Player"를 hit 했지만 Disable 되는 객체는 "Capsule"이다. 
                    hit.transform.gameObject.SetActive(false);

                    // 그리고 플레이어의 count를 시작한다.ㅣ
                    Count = true;

                    // 카운트는 3초로 한다.
                    ftime = 3.0f;

                    // 플레이어의 위치를 리스폰될 위치를 저장해둔 곳의 리스트 중 랜덤한 위치를 선택해 그 위치를 리스폰 위치로 지정한다.
                    Player.transform.position = RePointList[Random.Range(1, RePointList.Count)].transform.position;

                }
            }
        }

        // 카운트가 진행 될 것이고
        if (Count == true)
        {
            // 프레임 타임 만큼 빼준다.
            ftime -= Time.deltaTime;

            // 카운트가 시간이 0보다 작아지면 3초가 넘은 것으로 간주하고 
            if (ftime < 0)
            {
                // 타임을 초기화 해준다.
                ftime = 0;

                // 카운트를 false 로 만들어 더 이상 시간이 흐르지 않게 한다. 
                Count = false;

                // 그리고 "Player"를 부모로 뒀던 "Capsule"을 다시 enable 시켜준다.
                Player.transform.Find("Capsule").gameObject.SetActive(true);
            }
        }

    }
}
