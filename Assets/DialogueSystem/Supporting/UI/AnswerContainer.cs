using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerContainer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("������, ������� ����� �������� ������������ ��� ���� ������-�������, ������� ����� ����������� �����������." +
        " ���������� - ������ Content.")]
    private Transform answerContainerContent;

    [SerializeField]
    [Tooltip("������, ������� �������� ���� UI, ��������� � ���������� ������: ���� ��� ��������� � �.�.")]
    private GameObject answerContainerObject;

    [SerializeField]
    [Tooltip("������ ������ ��� ������ ��������. ����� ��������������, ����� ������������� ������ ���������.")]
    private GameObject answerUIprefab;

    private List<AnswerUI> answers;

    public void PrepareAllAnswers(List<AnswerItem> answerItems, DialogueScenePoint point, DialogueCharacter character)
    {
        ClearAllAnswers();
        answerContainerObject.SetActive(true);
        answers = new List<AnswerUI>();
        for (int i = 0; i < answerItems.Count; i++)
        {
            if(AnserIsAvailable(answerItems[i], character))
            {
                answers.Add(Instantiate(answerUIprefab, answerContainerContent).GetComponent<AnswerUI>());
                answers[answers.Count-1].PrepareAnswer(answerItems[i], i, point);
            }
        }
    }

    public void ClearAllAnswers()
    {
        if(answers != null)
        {
            foreach (var item in answers)
            {
                item.PrepareToDestroy();
            }

            answers.Clear();
        }
        answerContainerObject.SetActive(false);
    }

    private bool AnserIsAvailable(AnswerItem answerItem, DialogueCharacter character)
    {
        bool result = true;

        for (int i = 0; i < answerItem.answerStats.Count; i++)
        {
            if(answerItem.answerMode == AnswerMode.AutoChoi�e)
            {
                switch (answerItem.answerStats[i].mode)
                {
                    case AnswerStatMode.������������:
                        break;
                    case AnswerStatMode.����:
                        break;
                    case AnswerStatMode.��������������:
                        result = character.characterStats[i].statValue >= answerItem.answerStats[i].value;
                        break;
                    case AnswerStatMode.��������������:
                        result = character.characterStats[i].statValue <= answerItem.answerStats[i].value;
                        break;
                    case AnswerStatMode.������:
                        result = character.characterStats[i].statValue > answerItem.answerStats[i].value;
                        break;
                    case AnswerStatMode.������:
                        result = character.characterStats[i].statValue < answerItem.answerStats[i].value;
                        break;
                    default:
                        break;
                }
            }
            else if(answerItem.answerMode == AnswerMode.Condition)
            {
                result = answerItem.conditionItem.CheckCondition();
            }

            if (!result)
                return result;
        }

        return result;
    }
}
