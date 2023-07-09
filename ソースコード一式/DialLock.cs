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
    private string Answer;//����
    private string Response = "";//��
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioClip TrueSE;


    public void UpCounter()//�J�E���^�𑝂₷
    {
        Parent = EventSystem.currentSelectedGameObject;//�����ꂽ�I�u�W�F�N�g���擾
        TextMeshProUGUI ParentText = Parent.transform.parent.gameObject.GetComponent<TextMeshProUGUI>();//���Ŏ擾�����e�̃I�u�W�F�N�g��Text���擾
        char c=char.Parse(ParentText.text);//char�^�ɕύX
        if (ParentText.text == "Z") ParentText.text = "A";//�A���t�@�x�b�g�̂Ƃ�
        else if (ParentText.text == "9") ParentText.text = "0";//�����̂Ƃ�
        else
        {
            c = (char)((int)c + 1);//����1���₷
            ParentText.text = c.ToString();//string�^�ɕύX
        }
    }

    public void DownCounter()//�J�E���^�����炷
    {
        Parent = EventSystem.currentSelectedGameObject;//�����ꂽ�I�u�W�F�N�g���擾
        TextMeshProUGUI ParentText = Parent.transform.parent.gameObject.GetComponent<TextMeshProUGUI>();//���Ŏ擾�����e�̃I�u�W�F�N�g��Text���擾
        char c = char.Parse(ParentText.text);//char�^�ɕύX
        if (ParentText.text == "A") ParentText.text = "Z";//�A���t�@�x�b�g�̂Ƃ�
        else if (ParentText.text == "0") ParentText.text = "9";//�����̂Ƃ�
        else
        {
            c = (char)((int)c - 1);//�����P���炷
            ParentText.text = c.ToString();//string�^�ɕύX
        }
    }

    public void MatchingAnswer()//�𓚊m�F
    {
        string ResponName = EventSystem.currentSelectedGameObject.name;//�����ꂽ�I�u�W�F�N�g�̖��O���擾
        Response = "";//�𓚂����Z�b�g
        for(int i=0;i<CountText.Length; i++)
        {
            Response += CountText[i].text;//�J�E���^��S���AResponse�ɓ����
        }
        if (Response == Answer)//�𓚂������Ă���Ƃ�
        {
            TrueAnimator.SetTrigger("TrueText");
            AudioSource.PlayOneShot(TrueSE);
            OpenAnimation.SetTrigger("Open" + ResponName);
            EventSystem.currentSelectedGameObject.GetComponent<Button>().interactable = false;//�񓚃{�^�����g���Ȃ��悤�ɂ���
        }
        else
        {
            FalseAnimator.SetTrigger("FalseText");
        }
    }
}
