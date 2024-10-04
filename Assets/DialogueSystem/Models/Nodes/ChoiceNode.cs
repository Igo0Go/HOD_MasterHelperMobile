using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� - �����
/// </summary>
[System.Serializable]
public class ChoiceNode : DialogueNode
{
    #region ���� � ��������

    /// <summary>
    /// ���� �������� ����
    /// </summary>
    public override Color �olorInEditor
    {
        get
        {
            for (int i = 0; i < answers.Count; i++)
            {
                if (nextNodesNumbers[i] == -1)
                    return Color.red;
            }
            return Color.gray;
        }
    }

    /// <summary>
    /// ������� ����� �����������
    /// </summary>
    public DialogueCharacter character;

    /// <summary>
    /// �������� �������
    /// </summary>
    public List<Vector2> exitPointOffsetList;

    /// <summary>
    /// �������� ������
    /// </summary>
    public List<AnswerItem> answers;

    /// <summary>
    /// ������ ������� ������ � �����
    /// </summary>
    public int defaultCameraPositionIndex;

    public readonly int answerLimit = 20;
    private readonly Vector2 exitOffset = new Vector3(180, 21);
    #endregion

    #region ������������
    /// <summary>
    /// ������� ���� ������ � ��������� �������� � ��������� �������
    /// </summary>
    /// <param name="pos">������� ���� � ����������� �����</param>
    /// <param name="index">������ ���� � �����</param>
    public ChoiceNode(Vector2 pos, int index) : base(pos, index)
    {
        transformRect = new Rect(pos.x, pos.y, 200, 50);
        exitPointOffsetList = new List<Vector2>();
        answers = new List<AnswerItem>();
        for (int i = 0; i < answerLimit; i++)
        {
            nextNodesNumbers.Add(-1);
        }
    }

    private ChoiceNode(){}
    #endregion

    #region ������
    /// <summary>
    /// �������� ��������� ��� ������ �������� ������
    /// </summary>
    public void AddAnswer()
    {
        if(answers.Count < answerLimit)
        {
            answers.Add(new AnswerItem(character));
            CheckExitOffset();
        }
    }
    /// <summary>
    /// ������� ������� ������ �� ������
    /// </summary>
    /// <param name="number">����� �������� � ������ �������</param>
    public void RemoveAnsver(int number)
    {
        nextNodesNumbers.RemoveAt(number);
        nextNodesNumbers.Add(-1);
        answers.RemoveAt(number);
        CheckExitOffset();
    }
    /// <summary>
    /// �������� ������� �������� ���� � ������������ � ����������� ��������� �������
    /// </summary>
    private void CheckExitOffset()
    {
        exitPointOffsetList.Clear();
        for (int i = 0; i < answers.Count; i++)
        {
            exitPointOffsetList.Add(exitOffset + new Vector2(0, i * 21));
        }
    }
    #endregion
}

/// <summary>
/// ����� ���������� � �������� ������
/// </summary>
[System.Serializable]
public class AnswerItem
{
    /// <summary>
    /// �����, ������������, ��� ������ ������� ����� ������ �������� ����������
    /// </summary>
    public bool variantForAutoChoise;

    /// <summary>
    /// ��������� ��� ����� �������� ������
    /// </summary>
    public AnswerMode answerMode = AnswerMode.AutoChoi�e;

    /// <summary>
    /// �����, ������� ����� ���������� �� ������ ������ ������� (����� ���������� �� �������� �������, � �������, ��� ����������)
    /// </summary>
    public string answerTip;

    /// <summary>
    /// ���� ����������
    /// </summary>
    public DialogueCharacter character;

    /// <summary>
    /// ����� ��� ������ � ����������� ����������
    /// </summary>
    public ConditionItem conditionItem;

    /// <summary>
    /// ��� ������� ������ ����� ������ ��������� ��������������, ������� �������� �� ������������� �����������. � ������ ������ ����
    /// ����� ����� ������ � ������ ���� ������, � ��������� ��������������� �������� �������� �����
    /// </summary>
    public List<StatItem> answerStats;

    public AnswerItem(DialogueCharacter dialogueCharacter)
    {
        character = dialogueCharacter;
    }
}

[System.Serializable]
public class StatItem
{
    public float value = 0;
    public AnswerStatMode mode;

    public StatItem(float value)
    {
        mode = AnswerStatMode.����;
        this.value = value;
    }
}

public enum AnswerMode
{
    Manual = 0,
    AutoChoi�e = 1,
    Condition = 2
}

public enum AnswerStatMode : int
{
    ������������ = 0,
    ���� = 1,
    �������������� = 2,
    �������������� = 3,
    ������ = 4,
    ������ = 5,
}
