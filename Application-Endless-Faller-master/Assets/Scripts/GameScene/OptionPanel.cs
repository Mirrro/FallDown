using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{
    public void freezeGame()
    {
        Time.timeScale = 0;
    }
}
