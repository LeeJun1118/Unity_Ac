using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
     //** 총알의 속도
     public float BulletSpeed;

     //** 총알 시작 위치
     public Transform BulletPos;

     //** 물리컴퍼넌트
     private Rigidbody Rigid;


     void Start()
     {
          //** 총알의 속도
          BulletSpeed = 1000.0f;

          //** 복제된 총알 객체를 "BulletList" 라는 비어있는 게임오브젝트에 보관.
          this.transform.parent = GameObject.Find("BulletList").transform;

          //** 현재 오브젝트 물리 컴퍼넌트를 추가함.
          Rigid = GetComponent<Rigidbody>();

          //** 월드상에 있는 BulletPoint 를 찾아 그 transform 을 BulletPoint 에줌.
          BulletPos = GameObject.Find("BulletPoint").transform.GetComponent<Transform>();

          //** 총알의 포지션을 플레이의 포지션으로 셋팅
          this.transform.position = BulletPos.transform.position;


          /* 물리컴퍼넌트가 추가된 객체에 
           * (PlayerTransPos.transform.forward) 플레이어가 바라보고있는 방향으로 
           * (BulletSpeed * 3) 만큼의 힘을 가함.
           */

          Rigid.AddForce(BulletPos.transform.forward * BulletSpeed * 3);
     }


     private void OnTriggerEnter(Collider other)
     {
          Destroy(this.gameObject);
     }
}
