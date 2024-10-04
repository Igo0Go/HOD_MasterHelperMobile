using UnityEngine;

/// <summary>
/// ���� - �������
/// </summary>
[System.Serializable]
public class ReplicaNode : DialogueNode
{
    #region ���� � ��������
    /// <summary>
    /// ��������� ����
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
    /// ������������ ���� ���������� � �������
    /// </summary>
    public ReplicInfo replicaInformation;

    /// <summary>
    /// �������� ������
    /// </summary>
    public readonly Vector2 exitPointOffset = new Vector3(130, 21);
    #endregion

    #region ������������

    /// <summary>
    /// ������� ���� ������� � ��������� �������� � ��������� �����������
    /// </summary>
    /// <param name="pos">���������� ���� � �����</param>
    /// <param name="index">������ ����</param>
    public ReplicaNode(Vector2 pos, int index) : base(pos, index)
    {
        transformRect = new Rect(pos.x, pos.y, 150, 50);
        replicaInformation = new ReplicInfo();
        nextNodesNumbers.Add(-1);
    }

    private ReplicaNode(){}

    #endregion
}

/// <summary>
/// ����� � ����������� �� �������. ����������� ��� ����� ��������, ��� � � �������.
/// </summary>
[System.Serializable]
public class ReplicInfo
{
    /// <summary>
    /// ������� ��� �������
    /// </summary>
    public bool alreadyUsed;

    /// <summary>
    /// ������� ����� ����������
    /// </summary>
    public DialogueCharacter character;

    /// <summary>
    /// ��������� ������� ������� (����� ���� ������, ���� �� �� ����������� ������� � �������)
    /// </summary>
    public AudioClip clip;

    /// <summary>
    /// ������������ ��������� ���������� �� ����� �������
    /// </summary>
    public DialogueAnimType animType;

    /// <summary>
    /// ������� ������� ������ �� ����� �������
    /// </summary>
    public int camPositionNumber;

    /// <summary>
    /// ����� ���������
    /// </summary>
    public string replicaText;

    /// <summary>
    /// ������� ����� ���������� � �������. ��� ����� �������� ��� �������������
    /// </summary>
    public ReplicInfo()
    {
        alreadyUsed = false;
    }
}
