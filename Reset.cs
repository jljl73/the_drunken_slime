using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public int CurrentStageNumber;
    // Start is called before the first frame update

    public void ResetScene()
    {
        SceneManager.LoadScene(CurrentStageNumber);
    }
}
