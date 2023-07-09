using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Animations;
using TMPro;


public class DialLock : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] CountText;
    private GameObject Parent;
    [SerializeField]
    private EventSystem EventSystem;
    [SerializeField]
    private Animator OpenAnimation;
    [SerializeField]
    private Animator TrueAnimator;
    [SerializeField] 
    private Animator FalseAnimator;
    [SerializeField]
    private string Answer;//答え
    private string Response = "";//解答
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip TrueSE;


    public void UpCounter()//カウンタを増やす
    {
        Parent = EventSystem.currentSelectedGameObject;//押されたオブジェクトを取得
        TextMeshProUGUI ParentText = Parent.transform.parent.gameObject.GetComponent<TextMeshProUGUI>();//↑で取得した親のオブジェクトのTextを取得
        char c=char.Parse(ParentText.text);//char型に変更
        if (ParentText.text == "Z") ParentText.text = "A";//アルファベットのとき
        else if (ParentText.text == "9") ParentText.text = "0";//数字のとき
        else
        {
            c = (char)((int)c + 1);//桁を1増やす
            ParentText.text = c.ToString();//string型に変更
        }
    }

    public void DownCounter()//カウンタを減らす
    {
        Parent = EventSystem.currentSelectedGameObject;//押されたオブジェクトを取得
        TextMeshProUGUI ParentText = Parent.transform.parent.gameObject.GetComponent<TextMeshProUGUI>();//↑で取得した親のオブジェクトのTextを取得
        char c = char.Parse(ParentText.text);//char型に変更
        if (ParentText.text == "A") ParentText.text = "Z";//アルファベットのとき
        else if (ParentText.text == "0") ParentText.text = "9";//数字のとき
        else
        {
            c = (char)((int)c - 1);//桁を１減らす
            ParentText.text = c.ToString();//string型に変更
        }
    }

    public void MatchingAnswer()//解答確認
    {
        string ResponName = EventSystem.currentSelectedGameObject.name;//押されたオブジェクトの名前を取得
        Response = "";//解答をリセット
        for(int i=0;i<CountText.Length; i++)
        {
            Response += CountText[i].text;//カウンタを全部、Responseに入れる
        }
        if (Response == Answer)//解答があっているとき
        {
            TrueAnimator.SetTrigger("TrueText");
            AudioSource.PlayOneShot(TrueSE);
            OpenAnimation.SetTrigger("Open" + ResponName);
            EventSystem.currentSelectedGameObject.GetComponent<Button>().interactable = false;//回答ボタンを使えないようにする
        }
        else
        {
            FalseAnimator.SetTrigger("FalseText");
        }
    }
}
