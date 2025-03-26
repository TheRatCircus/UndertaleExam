using UnityEngine;
using System.Collections;

public class SwitchObject : MonoBehaviour
{
    public Animator animator;
    public GameObject PlayerSoul;

    public void StartAnimationWithDelay()
    {
        StartCoroutine(TriggerAnimationWithDelay());
    }

    private IEnumerator TriggerAnimationWithDelay()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetTrigger("TextIn");

        yield return new WaitForSeconds(1.2f);
        PlayerSoul.SetActive(true);
    }
}
