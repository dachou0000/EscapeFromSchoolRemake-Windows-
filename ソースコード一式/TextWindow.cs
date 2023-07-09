using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI EventText;
    [SerializeField]
    private string[] MessageEnd;
    private int MessageInt = 0;

    public IEnumerator TextAnimation()//�ꕶ�����o�͂���
    {
        EventText.text = "";
        for (int i = 0; i < MessageEnd[MessageInt].Length; i++)
        {
            EventText.text += MessageEnd[MessageInt][i];
            yield return new WaitForSeconds(0.09f);

        }
        //EndingAnimation.SetTrigger("EventText");
        int limit = MessageEnd.Length - 1;//false�̂Ƃ��J��Ԃ�
        if (limit > MessageInt) { MessageInt++; }        
    }

    public void Erase()//�e�L�X�g�̕�������
    {
        EventText.text = "";
    }

    public void Stage1toStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Stage2toEnd()
    {
        SceneManager.LoadScene("End");
    }
}

