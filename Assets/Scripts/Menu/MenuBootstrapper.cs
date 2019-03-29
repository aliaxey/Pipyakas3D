using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBootstrapper : MonoBehaviour{
    Button playButton;
    Dropdown levelSelect;
    void Start() {
        playButton = GameObject.Find("play_btn").GetComponent<Button>();
        levelSelect = GameObject.Find("lvl_menu").GetComponent<Dropdown>();
        playButton.onClick.AddListener(OnStartGame);
    }
    void OnStartGame() {
        /*GameObject levelHolder = Instantiate(new GameObject("LevelHolder"));
        levelHolder.AddComponent<LevelHolder>();
        GetComponent<LevelHolder>().level = 
        DontDestroyOnLoad(levelHolder);*/
        LevelHolder.level = levelSelect.value + 1;
        SceneManager.LoadScene("SampleScene");
    }

}
