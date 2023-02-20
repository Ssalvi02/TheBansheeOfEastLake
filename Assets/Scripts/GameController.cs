using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{
    public PlayableDirector dir;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Town");
        }
    }

    void OnEnable()
    {
        dir.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector adir)
    {
        if (dir == adir)
        {
            Debug.Log("Muda");
            SceneManager.LoadScene("Town");
        }
    }

    void OnDisable()
    {
        dir.stopped -= OnPlayableDirectorStopped;
    }
}
