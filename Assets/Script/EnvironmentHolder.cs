using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHolder : MonoBehaviour
{
    public CollideableObjects[] environments;

    public List<GameObject> instantiatedEnvironmentObj;
    public int objectToInstantiate=50;
    
    Vector2 sizeOfPlane = new Vector2(20, 20);

    int environmentObjectPresent;

    // Start is called before the first frame update
    void Start()
    {
        instantiatedEnvironmentObj = new List<GameObject>();
        for (int i = 0; i < environments.Length; i++)
        {
            for (int j = 0; j < objectToInstantiate; j++)
            {
                GameObject obj = Instantiate(environments[0].gameObject, transform);
                obj.transform.position = new Vector3(Random.Range(-sizeOfPlane.x, sizeOfPlane.x),1, 
                    Random.Range(-sizeOfPlane.y, sizeOfPlane.y));
                obj.GetComponent<CollideableObjects>().parent = this;
                instantiatedEnvironmentObj.Add(obj);
                environmentObjectPresent++;
            }
        }
    }

    public void ObjectIsRemoved()
    {
        environmentObjectPresent--;
    }
    private void Update()
    {
        //check for refill
        if (environmentObjectPresent < 10)
        {
            for (int i = 0; i < instantiatedEnvironmentObj.Count; i++)
            {  
                if (!instantiatedEnvironmentObj[i].activeSelf)
                {
                    instantiatedEnvironmentObj[i].SetActive(true);
                    environmentObjectPresent++;
                }
               
            }
        }
    }
}
