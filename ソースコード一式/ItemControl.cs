using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemControl : MonoBehaviour
{
    [SerializeField]
    private Animator WindowAnimator;
    private bool Switch=false;
    [SerializeField]
    private EventSystem ItemEvent;
    [SerializeField]
    private Image[] ItemImages;
    [SerializeField]
    private Image ItemPanel;
    [SerializeField]
    private TextMeshProUGUI ItemButton;
    private int ItemInt = 0;
    
    public void ItemAnimation()
    {
        /*ItemならCloseに　CloseならItemに文字を変える*/
        if (Switch) ItemButton.text = "Item";
        else { ItemButton.text = "Close"; }
        Switch = !Switch;//Switch反転
        WindowAnimator.SetBool("Move", Switch);
    }

    public void ItemGet(GameObject Item)//アイテムを取得
    {
        Image ColliderImage = Item.GetComponentInChildren<Image>();//Itemタグ付けたオブジェクトの子要素からImageを取得
        ItemImages[ItemInt].sprite = ColliderImage.sprite;//ItemListに入れる
        ItemInt++;
        Item.SetActive(false);//取得したアイテムを見えなくする
    }

    public void ItemSet()//アイテムの詳細を確認
    {
        GameObject PushButton = ItemEvent.currentSelectedGameObject;//押されたボタンを取得
        Image ButtonImage = PushButton.GetComponent<Image>();//↑で取得したオブジェクトのImageをコピー
        ItemPanel.sprite = ButtonImage.sprite;//大きく表示する
    }
}
