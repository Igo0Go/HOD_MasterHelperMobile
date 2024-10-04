using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����-������������
/// </summary>
[System.Serializable]
public class RandomizerNode : DialogueNode
{
    /// <summary>
    /// ���� �������� ����
    /// </summary>
    public override Color �olorInEditor
    {
        get
        {
            foreach (var item in nextNodesNumbers)
            {
                if (item == -1 && !finalNode)
                    return Color.red;
            }
            return Color.magenta;
        }
    }

    /// <summary>
    /// �������� ������� ������ ����� ���������� ������
    /// </summary>
    public List<Vector2> exitPointsOffsetList;

    /// <summary>
    /// ������� �� ������ �� ���� ����� ���������� ������
    /// </summary>
    public bool withRemoving;

    public readonly Vector2 exitPointOffset = new Vector2(130, 21);

    /// <summary>
    /// ������ �� ���� �� ���������
    /// </summary>
    public int defaultNextNodeNumber
    {
        get
        {
            return nextNodesNumbers[0];
        }
        set
        {
            nextNodesNumbers[0] = value;
        }
    }

    public List<bool> accessList;

    /// <summary>
    /// ������� ����-������������ � ��������� �������� � ��������� �������
    /// </summary>
    /// <param name="pos">������� ���� � ����������� �����</param>
    /// <param name="index">������ ���� � �����</param>
    public RandomizerNode(Vector2 pos, int index) : base(pos, index)
    {
        transformRect = new Rect(pos.x, pos.y, 150, 85);
        exitPointsOffsetList = new List<Vector2>();
        nextNodesNumbers.Add(-1);
        accessList = new List<bool>();
    }

    protected RandomizerNode() { }

    /// <summary>
    /// �������� ���� � ������ ��� ���������� ������
    /// </summary>
    /// <param name="index">������ ����</param>
    public void AddLinkNumber(int index)
    {
        nextNodesNumbers.Add(index);
        accessList.Add(true);
        CheckExitOffsetForRandomLink();
    }

    /// <summary>
    /// ������� ���� �� ������ ��� ���������� ������
    /// </summary>
    /// <param name="numberInList">������ ����</param>
    public void RemoveLinkNumber(int numberInList)
    {
        nextNodesNumbers.RemoveAt(numberInList);
        accessList.RemoveAt(numberInList - 1);
        CheckExitOffsetForRandomLink();
    }

    /// <summary>
    /// �������� ��������� ��������� ���� ��� �������� ���� �� ���������, ���� ������ ���������� ������ ����
    /// </summary>
    /// <returns>������ ���������� ����</returns>
    public int GetNextLink()
    {
        List<int> bufer = new List<int>();

        for (int i = 1; i < nextNodesNumbers.Count; i++)
        {
            if (accessList[i - 1])
            {
                bufer.Add(i);
            }
        }

        if (bufer.Count == 0)
        {
            return defaultNextNodeNumber;
        }

        int resultPositionInList = Random.Range(0, bufer.Count);
        int resultIndex = bufer[resultPositionInList];

        if(withRemoving)
        {
            accessList[resultIndex - 1] = false;
        }
        return nextNodesNumbers[resultIndex];
    }

    /// <summary>
    /// ������� ������ �� ���� ��������� ����
    /// </summary>
    public void ReturnAcces()
    {
        for (int i = 0; i < accessList.Count; i++)
        {
            accessList[i] = true;
        }
    }

    private void CheckExitOffsetForRandomLink()
    {
        exitPointsOffsetList.Clear();
        for (int i = 1; i < nextNodesNumbers.Count; i++)
        {
            exitPointsOffsetList.Add(exitPointOffset + new Vector2(0, (i-1) * 21));
        }
    }
}
