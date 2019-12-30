using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // 총알의 속도
    public float BulletSpeed;
    // 플레이어 객체
    private GameObject PlayerTransPos;
    // 물리 Component
    private Rigidbody Rigid;

    void Start()
    {
        BulletSpeed = 1000.0f;
        // GameObject.Find("Player") 현재 배치된 오브젝트 중에 Player라는 이름을 갖고 있는 객체를 찾음
        // 찾은 후에 오브젝트를 PlayerTransPos에 별도로 보관
        PlayerTransPos = GameObject.Find("Player").gameObject;

        // 총알의 포지션을 플레이어의 포지션으로 셋팅
        this.transform.position = PlayerTransPos.transform.position;
        // 복제된 총알 객체를 "BulletPooint"라는 비어있는 게임 오브젝트에 보관.
        this.transform.parent = GameObject.Find("BulletList").transform;

        // 현재 오브젝트 물리 Component를 추가함
        Rigid = GetComponent<Rigidbody>();
        // 물리 Component가 추가된 객체에 플레이어가 바라보고 있는 방향으로 BulletSpeed만큼 힘을 가함
        Rigid.AddForce(PlayerTransPos.transform.forward * BulletSpeed);
    }
}
