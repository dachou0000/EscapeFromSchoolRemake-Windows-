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
        /*Item�Ȃ�Close�Ɂ@Close�Ȃ�Item�ɕ�����ς���*/
        if (Switch) ItemButton.text = "Item";
        else { ItemButton.text = "Close"; }
        Switch = !Switch;//Switch���]
        WindowAnimator.SetBool("Move", Switch);
    }

    public void ItemGet(GameObject Item)//�A�C�e�����擾
    {
        Image ColliderImage = Item.GetComponentInChildren<Image>();//Item�^�O�t�����I�u�W�F�N�g�̎q�v�f����Image���擾
        ItemImages[ItemInt].sprite = ColliderImage.sprite;//ItemList�ɓ����
        ItemInt++;
        Item.SetActive(false);//�擾�����A�C�e���������Ȃ�����
    }

    public void ItemSet()//�A�C�e���̏ڍׂ��m�F
    {
        GameObject PushButton = ItemEvent.currentSelectedGameObject;//�����ꂽ�{�^�����擾
        Image ButtonImage = PushButton.GetComponent<Image>();//���Ŏ擾�����I�u�W�F�N�g��Image���R�s�[
        ItemPanel.sprite = ButtonImage.sprite;//�傫���\������
    }
}
