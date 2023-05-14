using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anims : MonoBehaviour
{
    private Animator animator;

    public static Anims instance;

    void Start()
    {
        instance = this;

        animator = GetComponent<Animator>();    
    }
    IEnumerator Yanlis()
    {
        yield return new WaitForSeconds(1.5f);

        animator.SetBool("Punch", false);

    }
    public void Tokat()
    {
        animator.SetBool("Punch", true);
        StartCoroutine(Yanlis());
    }
}
