using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
     //** 플레이의 이동속도
     private float Speed;

     //** 따라다닐 카메라 컴퍼넌를 받아옴.
     public Camera MyCamera;

     //** 줌 속도
     public float ZoomSpeed = 10.0f;

     //** 줌 거리
     private float ZoomDistance;

     //** 총알 오브젝트
     public GameObject BulletPrefab;


     private void Awake()
     {
          //** 카메라의 컴퍼넌트를 받아옴.
          MyCamera = GameObject.Find("Camera").GetComponent<Camera>();
     }


     private void Start()
     {
          //** 이동속도
          Speed = 3;
     }


     void Update()
     {
          //** Player Move    Start

          float fx = Input.GetAxis("Horizontal");
          float fy = Input.GetAxis("Vertical");


          this.transform.Translate(new Vector3(fx * Speed * Time.deltaTime, 0.0f, fy * Speed * Time.deltaTime));

          //** Player Move    End







          //** User Screen    Start

          //** 마우스의 Horizontal
          float MouseX = Input.GetAxis("Mouse X");

          //** 마우스의 Vertical
          float MouseY = Input.GetAxis("Mouse Y");


          //** 좌/우 화면은 Player의 회전값을 변경함.
          this.transform.Rotate(Vector3.up * MouseX);

          //** 상/하 화면은 카메라의 화전값을 변경함.
          MyCamera.transform.Rotate(-Vector3.right * MouseY);

          //** User Screen    End



          




          //** Camera Zoom    Start
          //** 마우스 휠 움직임 감지 후 값 변경.
          float fZoomCheck = Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;

          //** 감지확인.
          if (fZoomCheck != 0)
          {
               //** 확인된 값을 거리로 변경.
               ZoomDistance = fZoomCheck;

               //** 코루틴 함수 호출.
               StartCoroutine("Zoom");
          }
          //** Camera Zoom    End






          if(Input.GetMouseButton(0))
          {
               GameObject Obj = Instantiate(BulletPrefab);
          }
     }

    


     IEnumerator Zoom()  //** Field of View
     {
          /*
           * Smooth mode 로 변경해야함.
           */


          //** 반복
          while (true)
          {
               //** 현재 함수가 종료된 후 new WaitForSeconds() 함수의 매개변수 값만큼 대기후 다시 호출됨.
               yield return new WaitForSeconds(Time.deltaTime * 2f);
               //** 다시 호출 되었을 때에는 현재 위치부터 시작됨.


               if (0 < ZoomDistance)
               {
                    //** 프레임호출 시간만큼 값을 차감.
                    ZoomDistance -= Time.deltaTime;

                    //** 대략 0 에 가까운 값이 되면 빠저나감.
                    if (ZoomDistance < 0.5f)
                    {
                         ZoomDistance = 0;
                         break;
                    }
               }
               else
               {
                    //** 프레임호출 시간만큼 값을 더함.
                    ZoomDistance += Time.deltaTime;

                    //** 대략 0 에 가까운 값이 되면 빠저나감.
                    if (ZoomDistance > -0.5f)
                    {
                         ZoomDistance = 0;
                         break;
                    }
               }


               //** ZoomDistance 값 만큼 변경.
               MyCamera.fieldOfView -= ZoomDistance;


               //** zoom 최소치
               if (MyCamera.fieldOfView < 45f)
                    MyCamera.fieldOfView = 45f;


               //** zoom 최대치
               if (MyCamera.fieldOfView > 80f)
                    MyCamera.fieldOfView = 80f;
          }
     }
}
 