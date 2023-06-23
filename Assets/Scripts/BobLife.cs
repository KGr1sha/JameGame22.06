using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobLife : MonoBehaviour
{
    private bool isHit = false;
    [SerializeField] Animator animator;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isHit)
        {
            isHit = true;
            animator.SetBool("isHit", true);
            StartCoroutine(UnderHit());
        }
        else
            if (collision.gameObject.tag == "Enemy" && isHit)
            {
                Debug.Log("Death");
            }
    }




    private IEnumerator UnderHit()
    {
        
        yield return new WaitForSeconds(4.5f);
        Debug.Log("nothit");
        isHit = false;
        animator.SetBool("isHit", false);
    }


}