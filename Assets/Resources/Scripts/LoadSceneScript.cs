using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadSceneScript : MonoBehaviour
{
    public GameObject totyuu;
    private void Start()
    {
        if (PlayerPrefs.GetString("Totyuu") == "") Destroy(totyuu.gameObject);

#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif
    }
    public void LoadToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadToMainReset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main");
    }
}
