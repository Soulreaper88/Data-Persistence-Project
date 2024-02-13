using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    public TextMeshProUGUI nome;
    public TextMeshProUGUI previusName;
    private void Start()
    {
        previusName.SetText(DataManager.instance.nameEnter);
    }
    public void NewNameSelected()
    {
         DataManager.instance.nameEnter = nome.text;
    }
    public void Startnew()
    {
        DataManager.instance.SaveName();
        SceneManager.LoadScene(1);
    }
    public void ResetScore()
    {
        DataManager.instance.bestNameEnter = null;
        DataManager.instance.bestScore = 0;
    }
    public void Exit()
    {
       

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else

Application.Quit();

#endif

    }

}
