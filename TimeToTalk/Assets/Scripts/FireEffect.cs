using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    
    public Animator Talking;

    public void Update()
    {
        //if (Talking.GetCurrentAnimatorStateInfo(0).IsName("Fireef"))   //가장 마지막에 실행된 애니메이션이 "Fireef"인가?
        if (Talking.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)   //가장 마지막에 실행된 애니메이션의 길이를 0~1.0f으로 했을때 1.0f인가, 즉 끝났는가.
        StopA();
    }
    public void StopA()
    {
        this.gameObject.SetActive(false);
        
    }
}
