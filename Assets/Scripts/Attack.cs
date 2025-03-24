using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class Attack : MonoBehaviour
{
    public GameObject objectToMove;
    public Vector3 startPosition = new Vector3(-711, 1.2f, 0);
    public Vector3 endPosition = new Vector3(709, 1.2f, 0);
    public float moveDuration = 5f;

    private bool isMoving = false;
    private float moveStartTime;

    public ButtonNavigator buttonNavigator;  
    public GameObject objectToEnable;
    public GameObject indicatiorDisable;
    public GameObject ImageDisable;

    private void OnEnable()
    {
        objectToMove.transform.localPosition = startPosition;
        isMoving = true;
        moveStartTime = Time.time;
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
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(WaitAndEnableNavigation());
            indicatiorDisable.SetActive(false);
            ImageDisable.SetActive(false);
        }
    }

    private IEnumerator WaitAndEnableNavigation()
    {
        yield return new WaitForSeconds(0.5f);  
        buttonNavigator.EnableNavigation(); 
        objectToEnable.SetActive(true); 
        gameObject.SetActive(false);  
    }
}
