using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSh : MonoBehaviour
{
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void offShield()           // ��������� ���
    {
        animator.SetBool("shit", false);
        gameObject.SetActive(false);
    }
}
