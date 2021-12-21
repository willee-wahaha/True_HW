using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour, IPointerClickHandler
{

    public int sceneIndex = 0;

    public void OnPointerClick(PointerEventData e)
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(sceneIndex);
    }

}