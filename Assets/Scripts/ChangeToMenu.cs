using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToMenu : MonoBehaviour
{
    private float _delay = 70;

    public void FixedUpdate()
    {
        if (_delay > 0)
        {
            _delay -= Time.fixedDeltaTime;

            if (_delay <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
