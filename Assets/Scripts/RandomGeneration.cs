using UnityEngine;
using System.Collections;

public class RandomGeneration : MonoBehaviour
{
    public GameObject plain;
    private int numberOfObjects; // number of objects to place
    private int currentObjects; // number of placed objects
    public GameObject objectToPlace; // GameObject to place
    public GameObject objectToPlace2; // GameObject to place
    public GameObject objectToPlace3; // GameObject to place
    private int terrainWidth; // terrain size (x)
    private int terrainLength; // terrain size (z)
    private int terrainPosX; // terrain position x
    private int terrainPosZ; // terrain position z
    private int terrainPosY; // terrain position y
    //int tempPosX, tempPosZ = 0;

    void Start()
    {
        terrainLength = (int)plain.transform.localScale.x * 10 / 2;     // / 2 nes koordinates prasideda plain centre o ne kampe
        terrainWidth = (int)plain.transform.localScale.z * 10 / 2;
        // terrain x position
        terrainPosX = (int)plain.transform.position.x;
        // terrain z position
        terrainPosZ = (int)plain.transform.position.z;

        terrainPosY = (int)plain.transform.position.y;
        numberOfObjects = terrainLength / 2;
        float portionSize = (terrainLength / numberOfObjects) * 2;

        float tempPosX = -terrainLength;
        float prevPosX = -terrainLength;

        while (tempPosX < terrainLength)
        {
            float tempPosZ = -terrainWidth;
            float dist = 5f;
            float posx = 0f;
            int count = 0;
            while (dist <= 3 || count <= 100000) // stengiasi kuo tolesne x koordinate rasti
            {
                count++;
                dist = Mathf.Abs(posx - prevPosX);
                posx = Random.Range(tempPosX, tempPosX + Mathf.Sqrt(numberOfObjects)); 
            }
            tempPosX += Mathf.Sqrt(numberOfObjects);
            for (int i = 0; i < 2; i++)
            {
                float posz = Random.Range(tempPosZ, tempPosZ + terrainLength);
                tempPosZ += terrainLength;

                GameObject newObject;

                int randObject = Random.Range(0, 2);

                switch (randObject)     // kad skirtingu tipu malkas generuotu
                {
                    case 0:
                        newObject = (GameObject)Instantiate(objectToPlace, new Vector3(posx, terrainPosY, posz), Quaternion.identity);
                        newObject.transform.Rotate(0, Random.Range(0f,90f), 90f);
                        break;
                    case 1:
                        newObject = (GameObject)Instantiate(objectToPlace2, new Vector3(posx, terrainPosY, posz), Quaternion.identity);
                        newObject.transform.Rotate(0, Random.Range(0f, 90f), 90f);
                        break;
                    case 2:
                        newObject = (GameObject)Instantiate(objectToPlace3, new Vector3(posx, terrainPosY, posz), Quaternion.identity);
                        newObject.transform.Rotate(0, Random.Range(0f, 90f), 90f);
                        break;
                }
                
            }
            prevPosX = posx;
        }
    }
    // Update is called once per frame
    //void Update()
    //{

    //    // generate objects
    //    if (currentObjects <= 40)
    //    {
    //        GameObject newObject;
    //        // generate random x position
    //        int posx = Random.Range(-terrainLength + 2, terrainLength - 2); // -2 kad nuo krastu butu biski toliau

    //        // generate random z position
    //        int posz = Random.Range(-terrainWidth + 2, terrainWidth - 2);

    //        Debug.Log("x- " + posx + " z- " + posz);
    //        // create new gameObject on random position
    //        int randObject = Random.Range(0, 2);

    //        switch (randObject)     // kad skirtingu tipu malkas generuotu
    //        {
    //            case 0:
    //                newObject = (GameObject)Instantiate(objectToPlace, new Vector3(posx, terrainPosY, posz), Quaternion.identity);
    //                break;
    //            case 1:
    //                newObject = (GameObject)Instantiate(objectToPlace2, new Vector3(posx, terrainPosY, posz), Quaternion.identity);
    //                break;
    //            case 2:
    //                newObject = (GameObject)Instantiate(objectToPlace3, new Vector3(posx, terrainPosY, posz), Quaternion.identity);
    //                break;
    //        }
    //        currentObjects += 1;

    //    }


    //}
}
