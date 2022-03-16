using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private List<Podium> InteractivePlaces;
    
    public bool PuzzleComplite()
    {
        foreach (var interactivePlace in InteractivePlaces)
        {
            if (interactivePlace.IsActive() == false)
            {
                Debug.Log("��� �� ���");
                return false;
            }
        }
        Debug.Log("�� �� ����");
        return true;
    }
}
