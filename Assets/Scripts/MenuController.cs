using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private int id;
    private Button bt;

    private void Start()
    {
        bt = GetComponent<Button>();
        bt.onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        switch (id)
        {
            case 0:
                SceneManager.LoadScene("IntroCutscene");
                break;
            case 1:
                // SceneManager.LoadScene("Intro");
                break;
            case 2:
                // SceneManager.LoadScene("Intro");
                break;
            case 3:
                Application.Quit();
                break;
        }
    }


}
