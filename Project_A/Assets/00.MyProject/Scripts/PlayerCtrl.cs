using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //플레이어의 이동 속도
    private float Speed;

    //따라다닐 카메라 컴퍼넌트를 받아옴
    public Camera MyCamera;

    //줌 속도
    public float ZoomSpeed = 10.0f;

    //줌 거리
    private float ZoomDistance;

    //총알 오브젝트
    public GameObject BulletPrefab;


    private void Awake()
    {
        MyCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private void Start()
    {
        Speed = 3;
    }
    void Update()
    {
        //플레이어 이동
        float fx = Input.GetAxis("Horizontal");
        float fy = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(fx * Time.deltaTime * Speed,0.0f,fy * Time.deltaTime * Speed));


        //마우스 이동
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        //좌우 화면은 Player의 회전값을 반영
        this.transform.Rotate(Vector3.up * MouseX);

        //상화 화면은 Camera의 회전값을 반영함
        MyCamera.transform.Rotate(-Vector3.right * MouseY);



        //카메라 줌
        //마우스 휠 움직임 감지 후 값 변경
        float fZoomCheck = Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;

        //감지 확인
        if(fZoomCheck != 0)
        {
            //확인된 값을 거리로 변경
            ZoomDistance = fZoomCheck;
            //코루틴 함수 호출
            StartCoroutine("Zoom");
        }

        //마우스 왼쪽 버튼 누르면
        if (Input.GetMouseButton(0))
        {
            //총알 복제
            GameObject Obj = Instantiate(BulletPrefab);
        }
    }


    IEnumerator Zoom()
    {

        while (true)
        {
            //현재 함수가 종료된 후 new WaintForSeconds() 함수의 매개변수 값만큼 대기 후 다시 호출 됨.
            yield return new WaitForSeconds(Time.deltaTime * 2f);
            //다시 호출 되었을 때에는 현재 위치부터 시작됨


            if(0 < ZoomDistance)
            {
                //프레임 호출 시간 만큼 값을 차감
                ZoomDistance -= Time.deltaTime;

                //대략 0에 가까운 값이 되면 빠져나감
                if(ZoomDistance < 0.5f)
                {
                    ZoomDistance = 0;
                    break;
                }
            }
            else
            {
                //프레임 호출 시간만큼 값을 더함
                ZoomDistance += Time.deltaTime;

                //대략 0에 가까운 값이 되면 빠져나감
                if (ZoomDistance > -0.5f)
                {
                    ZoomDistance = 0;
                    break;
                }
            }

            //ZoomDistance 값만큼 변경
            MyCamera.fieldOfView -= ZoomDistance;

            //줌 최소치
            if (MyCamera.fieldOfView < 45f)
                MyCamera.fieldOfView = 45f;

            //줌 최대치
            if (MyCamera.fieldOfView > 80)
                MyCamera.fieldOfView = 80f;
        }
    }
}
