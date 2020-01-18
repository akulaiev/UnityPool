using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefs : MonoBehaviour {

    public void ResetData() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Player", "Sonic");
        PlayerPrefs.SetInt("UnlockedLevels", 0);
        PlayerPrefs.SetInt("LostLives", 0);
        PlayerPrefs.SetInt("BestScore", 0);
        PlayerPrefs.Save();
    }
}
