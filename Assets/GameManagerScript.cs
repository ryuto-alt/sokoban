using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject PlayerPrefab;
    int[,] map =
    {
        {1,0,0,0,1 },
        {0,0,0,0,0 },
        {0,0,1,0,0 },
    };
    GameObject[,] field;


    // Start is called before the first frame update

    //void PrintArray()
    //{
    //    string debugText = "";
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //    Debug.Log(debugText);
    //}

    private Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }
            }

        }
        return new Vector2Int(-1, -1);
    }

    void Start()
    {
        map = new int[,]
        {
            {1,0,0,0,0 },
            {0,0,0,0,0 },
            {0,0,0,0,0 },
        };
        field = new GameObject
        [
            map.GetLength(0),
            map.GetLength(1)
            ];
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(PlayerPrefab, new Vector3(x, map.GetLength(0) - y - 1, 0), Quaternion.identity);
                }
            }
        }
        //Object instance = Instantiate(
        //    PlayerPrefab,
        //    new Vector3(0, 0, 0),
        //    Quaternion.identity

        //    );
        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
        //map = new int[] { 0, 0, 0, 2, 0, 1, 0, 2, 0, 0, 0 };
        //PrintArray();

        //for (int i = 0; i < map.Length; i++)
        //{
        //    debugTXT += map[i].ToString() + ",";
        //}
        //Debug.Log(debugTXT);


    }

    bool MoveNumber(string tag, Vector2Int moveFrom, Vector2Int moveTo)
    {

        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, field.GetLength(0) - moveTo.y, 0);
        if (moveTo.x < 0 || moveTo.x >= field.Length)
        {
            return false;
        }
        if (moveTo.y < 0 || moveTo.y >= field.Length)
        {
            return false;
        }
        //if (field[moveTo.y,moveTo.x] != null && field[moveTo.y,moveTo.x].tag=="Box")
        //{
        //    Vector2Int velocity = moveTo - moveFrom;
        //    bool success = MoveNumber(tag, moveTo, moveTo + velocity);
        //    if (success == false)
        //    {
        //        return false;
        //    }
        //}
        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, field.GetLength(0) - moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    int playerIndex = GetPlayerIndex();

        //    MoveNumber(1, playerIndex, playerIndex + 1);
        //    PrintArray();

        //    string debugText = "";
        //    for (int i = 0; i < map.Length; i++)
        //    {
        //        debugText += map[i].ToString() + ",";
        //    }
        //    Debug.Log(debugText);
        //}


        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    int playerIndex = GetPlayerIndex();

        //    MoveNumber(1, playerIndex, playerIndex - 1);
        //    PrintArray();

        //    string debugText = "";
        //    for (int i = 0; i < map.Length; i++)
        //    {
        //        debugText += map[i].ToString() + ",";
        //    }
        //    Debug.Log(debugText);
        //}

    }



}