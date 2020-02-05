using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // 총알의 속도
    public float BulletSpeed;

    //총알의 시작 위치
    private Transform BulletPos;

    // 물리 Component
    private Rigidbody Rigid;

    void Start()
    {
        BulletSpeed = 1000.0f;

        //복제된 총알 객체를 "BulletList "라는 비어있는 게임 오브젝트에 보관
        this.transform.parent = GameObject.Find("BulletList").transform;

        //현재 오브젝트 물리 컴포넌트를 추가함
        Rigid = GetComponent<Rigidbody>();

        //BulletPoint를 찾아서 그 transform을 BulletPos에 줌
        BulletPos = GameObject.Find("BulletPoint").transform.GetComponent<Transform>();

        //총알의 위치를 플레이어의 위치로 해줌
        this.transform.position = BulletPos.transform.position;

        Rigid.AddForce(BulletPos.transform.forward * BulletSpeed * 3);

    }

    private void OnTriggerEnter(Collider other)
    {
        this.transform.Find("BulletObj").gameObject.SetActive(false);
        this.transform.Find("BuletHit").gameObject.SetActive(true);
        Rigid.isKinematic = true;
    }
}
