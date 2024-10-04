using UnityEngine;

/// <summary>
/// ����-������
/// </summary>
[System.Serializable]
public class LinkNode : DialogueNode
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
            return Color.blue;
        }
    }

    /// <summary>
    /// ������ ����, �� ������� ����� ������������� ��� �������
    /// </summary>
    public int NextNodeNumber
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
    /// <summary>
    /// �������� ������
    /// </summary>
    public readonly Vector2 exitPointOffset = new Vector2(130, 21);

    /// <summary>
    /// ������� ����-������ � ��������� �������� � ��������� �������
    /// </summary>
    /// <param name="pos">������� ���� � ����������� �����</param>
    /// <param name="index">������ ���� � �����</param>
    public LinkNode(Vector2 pos, int index) : base(pos, index)
    {
        transformRect = new Rect(pos.x, pos.y, 150, 50);
        nextNodesNumbers.Add(-1);
    }

    protected LinkNode() { }
}
