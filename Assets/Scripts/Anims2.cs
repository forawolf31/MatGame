using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anims2 : MonoBehaviour
{
    private Animator animator;

    public static Anims2 instance;

    void Start()
    {
        instance = this;

        animator = GetComponent<Animator>();
    }
    IEnumerator Yanlis2()
    {
        yield return new WaitForSeconds(1.5f);

        animator.SetBool("Punch2", false);

    }
    public void Tokat2()
    {
        animator.SetBool("Punch2", true);
        StartCoroutine(Yanlis2());
    }
}
