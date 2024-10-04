using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIController : MonoBehaviour
{
    [Tooltip("������ ��� ���������")] 
    [SerializeField]
    private TextPanel subsPanel;

    [Tooltip("����� � ������ ����������")]
    [SerializeField]
    private TextPanel characterNamePanel;

    [Tooltip("����� ��������")]
    [SerializeField]
    private GameObject skipPanel;

    [Tooltip("������-���������")]
    [SerializeField]
    private TextPanel infoTipPanel;

    [Tooltip("������ ��� ���������")]
    [SerializeField]
    private UISlidePanel messagePanel;

    [Tooltip("����� ���������")]
    [SerializeField]
    private Text messageText;

    [Tooltip("��������� � ���������� ������")]
    public AnswerContainer answerContainer;

    [SerializeField]
    [Tooltip("�������� �� ��� ���������� �� ����� ������")]
    private bool showName = false;


    private void Start()
    {
        skipPanel.SetActive(false);
        subsPanel.panel.SetActive(false);
        infoTipPanel.panel.SetActive(false);
        characterNamePanel.panel.SetActive(false);
    }

    public void SetInfoTipString(string tipString)
    {
        infoTipPanel.contentText.text = tipString;
    }

    public void PrepareSubs(ReplicInfo info)
    {
        subsPanel.panel.SetActive(true);

        subsPanel.contentText.color = info.character.color;
        subsPanel.contentText.text = info.replicaText;
        if(showName)
        {
            characterNamePanel.panel.SetActive(true);
            characterNamePanel.contentText.color = info.character.color;
            characterNamePanel.contentText.text = info.character.characterName;
        }
    }
    public void HideSubs()
    {
        subsPanel.panel.SetActive(false);
    }

    public void SetSkipTipState(bool value) => skipPanel.SetActive(value);
    public void SetInfoTipState(bool value) => infoTipPanel.panel.SetActive(value);
    public void SetNamePanelState(bool value) => characterNamePanel.panel.SetActive(value);


    public void UseMessage(string messageString)
    {
        messageText.text = messageString;
        messagePanel.OpenPanel();
    }
    public void HideMessage()
    {
        messagePanel.HidePanel();
    }
}
