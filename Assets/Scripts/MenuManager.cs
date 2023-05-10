using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform  Man;

    [SerializeField]
    private Transform Goblin;

    void Start()
    {
        Man.transform.GetComponent<RectTransform>().DOLocalMoveX(-650f, 1f).SetEase(Ease.OutBack);
        Goblin.transform.GetComponent<RectTransform>().DOLocalMoveX(600, 1f).SetEase(Ease.OutBack);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
