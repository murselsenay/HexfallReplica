using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{

    bool canRotate = true;
    float _z;
    List<GameObject> hexList = new List<GameObject>();
    Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta };
    bool canCheck = true;

    public static Tap instance;
    // Start is called before the first frame update
   
    void Start()
    {
        instance = this;
        while (hexList[0].GetComponent<Renderer>().material.color == hexList[1].GetComponent<Renderer>().material.color && hexList[0].GetComponent<Renderer>().material.color == hexList[2].GetComponent<Renderer>().material.color && hexList[1].GetComponent<Renderer>().material.color == hexList[2].GetComponent<Renderer>().material.color)
        {
            hexList[0].GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
            hexList[1].GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
            hexList[2].GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0f && canRotate)
        {
            StartCoroutine(rotateHexs());
            canRotate = false;
        }
        

    }
    private void OnMouseDown()
    {

        Debug.Log("clicked");
        hexList[0].transform.parent = gameObject.transform;
        hexList[1].transform.parent = gameObject.transform;
        hexList[2].transform.parent = gameObject.transform;
    }
    private void OnMouseUp()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Hex")
        {
            hexList.Add(other.gameObject);

        }
    }

    public IEnumerator rotateHexs()
    {

        for (int i = 0; i < 3; i++)
        {
            transform.Rotate(new Vector3(0, 0, 120));
            Debug.Log(_z);
            yield return new WaitForSeconds(1);
        }
        canRotate = true;
    }
}
