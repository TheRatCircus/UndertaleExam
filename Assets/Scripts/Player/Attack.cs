using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public SwitchObject switchObject; 

    public GameObject objectToMove;
    public Vector3 startPosition = new Vector3(-711, 1.2f, 0);
    public Vector3 endPosition = new Vector3(709, 1.2f, 0);
    public float moveDuration = 5f;

    private bool isMoving = false;
    private float moveStartTime;

    public ButtonNavigator buttonNavigator;
    public GameObject objectToEnable;
    public GameObject indicatorDisable;
    public GameObject imageDisable;
    public GameObject damageEffectObject;

    public EnemyHealth enemyHealth;
    public Text damageText;
    public GameObject damageTextObject;

    private float damageAmount = 3f;
    private float damageMultiplier = 1f;

    private bool canPressZ = false;

    private void OnEnable()
    {
        objectToMove.transform.localPosition = startPosition;
        isMoving = true;
        moveStartTime = Time.time;

        canPressZ = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            float elapsedTime = Time.time - moveStartTime;

            if (elapsedTime < moveDuration)
            {
                objectToMove.transform.localPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
            }
            else
            {
                objectToMove.transform.localPosition = endPosition;
                isMoving = false;
                OnMoveEnd();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) && canPressZ)
        {
            canPressZ = false;
            OnMoveEnd();
        }
    }

    private void OnMoveEnd()
    {
        float finalDamage = damageAmount * damageMultiplier;

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(finalDamage);
        }

        if (damageEffectObject != null || damageTextObject != null)
        {
            StartCoroutine(ShowDamageEffectThenText(finalDamage));
        }

        indicatorDisable.SetActive(false);

        StartCoroutine(WaitAndEnableNavigation());
    }

    private IEnumerator ShowDamageEffectThenText(float damage)
    {
        if (damageEffectObject != null)
        {
            damageEffectObject.SetActive(true);
        }

        yield return new WaitForSeconds(0.15f);

        if (damageTextObject != null && damageText != null)
        {
            damageText.text = $"-{damage}";
            damageTextObject.SetActive(true);
        }

        yield return new WaitForSeconds(0.10f);

        if (damageEffectObject != null)
        {
            damageEffectObject.SetActive(false);
        }

        imageDisable.SetActive(false);

        yield return new WaitForSeconds(0.20f);
        if (damageTextObject != null)
        {
            damageTextObject.SetActive(false);

        }
    }

    private IEnumerator WaitAndEnableNavigation()
    {
        yield return new WaitForSeconds(0.5f);
        //buttonNavigator.EnableNavigation();     debug purposes
        objectToEnable.SetActive(true);
        switchObject.StartAnimationWithDelay();
        gameObject.SetActive(false);
    }

    public void SetDamageMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
    }
}
