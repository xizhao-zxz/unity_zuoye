using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public enum Direction {up, down, left, right};

    [Header("房间信息")]
    public GameObject roomPrefabs;
    public int roomNumber;
    public Color startColor, endColor;
    [Header("位置信息")]
    public Transform generatorPoint;
    public float x0ffset;
    public float y0ffset;


    //存储已有的房间位置
    //private SortedSet<Vector3> existingRoomPoint;
    private List<GameObject> rooms = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //existingRoomPoint.Add(generatorPoint.position);
        for (int i = 0; i < roomNumber; i++)
        {

            rooms.Add(Instantiate(roomPrefabs, generatorPoint.position, Quaternion.identity));

            //改变Ponit的位置 
            //此方法用于生成大量地图块时可能效率过低，此时应考虑更优秀的算法
            ChangePointPos();
            //此处可能会在已有的坐标参数中循环
            //while(existingRoomPoint.Contains(generatorPoint.position))
            //{
            //    ChangePointPos();
            //}
            //existingRoomPoint.Add(generatorPoint.position);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePointPos()
    {
        Direction dirc = (Direction)Random.Range(0, 4);
        switch (dirc)
        {
            case Direction.up :
                generatorPoint.position += new Vector3(0, y0ffset, 0);
                break;
            case Direction.down:
                generatorPoint.position += new Vector3(0, -y0ffset, 0);
                break;
            case Direction.left:
                generatorPoint.position += new Vector3(-x0ffset, 0, 0);
                break;
            case Direction.right:
                generatorPoint.position += new Vector3(x0ffset, 0, 0);
                break;
        }
    }
}
