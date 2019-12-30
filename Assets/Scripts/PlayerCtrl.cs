using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //플레이어의 이동 속도
    private float Speed;

    // 총알 오브젝트 public으로 만들어서 유니티에서 드래그앤 드롭할 수 있게 했다.
    public GameObject Bullet;

    // 총알 인덱스
    private int BulletIndex;

    private void Start()
    {
        Speed = 3;
    }
    void Update()
    {
        //플레이어 이동
        float fx = Input.GetAxis("Horizontal");
        float fy = Input.GetAxis("Vertical");
        this.transform.Translate(
            new Vector3(fx*Time.deltaTime*Speed,0.0f,fy * Time.deltaTime * Speed));

        // 마우스 왼쪽 버튼 클릭 시 총알 발사 (0 = 왼쪽  1 = 오른 쪽  2 = 휠 클릭)
        if (Input.GetMouseButton(0))
        {
            // 총알을 복제함
            GameObject obj = Instantiate(Bullet);
            // 복제된 총알의 이름을 인덱스 값으로 변경
            obj.transform.name = BulletIndex.ToString();
            // 인덱스 값 증가시킴.
            BulletIndex++;
        }
    }
}
