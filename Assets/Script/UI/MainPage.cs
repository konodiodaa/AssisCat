using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainPage : MonoBehaviour
{

    private Image mainTitle;
    private Button startBtn;
    private Button quitBtn;

    void Awake()
    {
        EventCenter.AddListener(EventType.ShowMainPage, Show);
        EventCenter.AddListener(EventType.QuitGame, Quit);

        mainTitle =transform.Find("MainTitle").GetComponent<Image>();
        startBtn = transform.Find("StartBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartButtonClicked);
        quitBtn = transform.Find("QuitBtn").GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {

        InitalAnimation();
    }

    void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.ShowMainPage, Show);
        EventCenter.RemoveListener(EventType.QuitGame, Quit);
    }

    private void Show()
    {
        gameObject.SetActive(true);
        InitalAnimation();
    }

    private void OnQuitButtonClicked()
    {
       // EventCenter.Broadcast(EventType.QuitGame);
        gameObject.SetActive(false);
        Quit();
    }

    private void OnStartButtonClicked()
    {
        Debug.Log("close main page and open level page");
        EventCenter.Broadcast(EventType.ShowLevelSelectionPage);
        gameObject.SetActive(false);
    }

    private void Quit()
    {
        
        Debug.Log("Quit game");
    }

    private void InitalAnimation()
    {
        mainTitle.transform.localPosition = new Vector3(0, 200, 0);
        mainTitle.color = new Color(mainTitle.color.r, mainTitle.color.g, mainTitle.color.b, 0f);
        mainTitle.DOFade(1.0f, 1f);
        mainTitle.gameObject.transform.DOLocalMoveY(10, 1f);

        startBtn.transform.localPosition = new Vector3(700, -107, 0);
        startBtn.GetComponent<Image>().color = new Color(mainTitle.color.r, mainTitle.color.g, mainTitle.color.b, 0f);
        startBtn.GetComponent<Image>().DOFade(1.0f, 1f);
        startBtn.gameObject.transform.DOLocalMoveX(450, 1f);

        quitBtn.transform.localPosition = new Vector3(700, -162, 0);
        quitBtn.GetComponent<Image>().color = new Color(mainTitle.color.r, mainTitle.color.g, mainTitle.color.b, 0f);
        quitBtn.GetComponent<Image>().DOFade(1.0f, 1f);
        quitBtn.gameObject.transform.DOLocalMoveX(450, 1f);
    }
}
