using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hexagonPrefab;
    public GameObject target;
    private float _x, _y;
    private float offsetX;
    private float offsetY = -0.25f;
    Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow,Color.magenta };


    public GameObject tapPrefab;
    public GameObject tapTarget;
    private float tapOffsetX = -0.1f;
    private float tapOffsetY = 0;
    Vector2 tapTargetStartPos;




    // Start is called before the first frame update
    void Start()
    {
        tapTargetStartPos = tapTarget.transform.position;
        CreateGrid();
       
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }

    void CreateGrid()
    {

        _x = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int k = 0; k < 9; k++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GameObject insHexagon = Instantiate(hexagonPrefab, new Vector2(target.transform.position.x + offsetX, target.transform.position.y + offsetY), target.transform.rotation);
                    insHexagon.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                    offsetX += 1.3f;
                }
                offsetX = _x;
                offsetY -= 0.7f;
            }
            offsetX = 0.65f;
            offsetY = -0.60f;
            _x = 0.65f;

        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                GameObject insTap = Instantiate(tapPrefab, new Vector2(tapTarget.transform.position.x + tapOffsetX, tapTarget.transform.position.y - tapOffsetY), target.transform.rotation);
                tapOffsetY += 0.35f;
                tapOffsetX *= -1;
            }
            tapOffsetY = 0;
            tapTarget.transform.position = new Vector2(tapTarget.transform.position.x + 1.3f, tapTarget.transform.position.y);
        }
        tapTarget.transform.position = tapTargetStartPos;
        tapTarget.transform.position = new Vector2(tapTarget.transform.position.x + 0.65f, tapTarget.transform.position.y);
        tapOffsetX = 0.1f;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                GameObject insTap = Instantiate(tapPrefab, new Vector2(tapTarget.transform.position.x + tapOffsetX, tapTarget.transform.position.y - tapOffsetY), target.transform.rotation);
                tapOffsetY += 0.35f;
                tapOffsetX *= -1;
            }
            tapOffsetY = 0;
            tapTarget.transform.position = new Vector2(tapTarget.transform.position.x + 1.3f, tapTarget.transform.position.y);
        }

    }
   

}
