using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{
    public PlayableDirector dir;

    void OnEnable()
    {
        dir.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector adir)
    {
        if (dir == adir)
        {
            Debug.Log("Muda");
            SceneManager.LoadScene(1);
        }
    }

    void OnDisable()
    {
        dir.stopped -= OnPlayableDirectorStopped;
    }
}
