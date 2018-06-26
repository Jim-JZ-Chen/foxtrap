using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Goal : MonoBehaviour
{
    public UnityEvent OnWin;
    public GameObject celebrationGameObject;

    private Camera mainCamera;

    void Awake()
    {
        celebrationGameObject.SetActive(false);
        mainCamera = Camera.main;
    }

    IEnumerator CameraZoom()
    {
        float t = 0f;
        float duration = 1f;
        Vector3 startPosition = mainCamera.transform.localPosition;
        Vector3 endPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 16f, transform.localPosition.z - 10.5f);
        Debug.Log(transform.localPosition);
        while (t < duration)
        {
            t += Time.deltaTime;
            mainCamera.transform.localPosition = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0, duration, t));
            yield return null;
        }

        mainCamera.transform.localPosition = endPosition;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<IPlayerAvatar>() != null)
        {
            celebrationGameObject.SetActive(true);
            StartCoroutine(CameraZoom());
            OnWin.AddListener(OnBackLater);
            OnWin.Invoke();
            collider.GetComponent<Animator>().SetBool("Win", true);
            collider.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
        }
    }
    
    public void OnBackLater()
    {
        Invoke("Back", 2f);
    }
    
    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("title");
    }
}
