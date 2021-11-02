using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPage : MonoBehaviour
{

    private Button backBtn;

    void Awake()
    {
        EventCenter.AddListener(EventType.ShowLevelSelectionPage, Show);

        backBtn = transform.Find("backButton").GetComponent<Button>();
        backBtn.onClick.AddListener(OnBackButtonClicked);
    }
    
    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.ShowLevelSelectionPage, Show);
    }

    private void Show()
    {
        Debug.Log("open selection page");
        gameObject.SetActive(true);
    }

    private void OnBackButtonClicked()
    {
        EventCenter.Broadcast(EventType.ShowMainPage);
        gameObject.SetActive(false);
    }
}
