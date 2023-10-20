using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] MediaItem videoClip;

    private void Start()
    {
        LoadScene();
    }
    public void LoadScene()
    {
        StartCoroutine(DelaySceneLoading(1));
    }

    IEnumerator DelaySceneLoading(int index)
    {
        yield return new WaitForSeconds((float)videoClip.clip.length);
        SceneManager.LoadScene(index);
    }
}
