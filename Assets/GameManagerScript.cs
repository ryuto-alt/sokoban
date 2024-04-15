using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int[] map;


    // Start is called before the first frame update
    void Start()
    {
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
        PrintArray();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetPlayerIndex();

        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetPlayerIndexLeft();
        }

    }

    private void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);

    }


    private void GetPlayerIndex()
    {
        int playerIndex = -1;
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                playerIndex = i;
                break;
            }


        }

        if (playerIndex < map.Length - 1)
        {
            map[playerIndex + 1] = 1;
            map[playerIndex] = 0;
        }

        MoveNumber(1, playerIndex, playerIndex + 1);
        
        PrintArray();

    }

    private void GetPlayerIndexLeft()
    {
        int playerIndex = -1;
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                playerIndex = i;
                break;
            }
        }
        if (playerIndex > 0)
        {
            map[playerIndex - 1] = 1;
            map[playerIndex] = 0;
        }


        MoveNumber(1, playerIndex, playerIndex + 1);
        PrintArray();
    }

    private bool MoveNumber(int number, int moveFrom, int moveto)
    {
        if (moveto < 0 || moveto >= map.Length) { return false; }

        if (map[moveto] == 2)
        {
            int velocity = moveto - moveFrom;


            bool success = MoveNumber(2, moveto, moveto + velocity);

            if (!success) { return false; }
        }

        map[moveto] = number;
        map[moveFrom] = 0;
        return true;
    }

}
