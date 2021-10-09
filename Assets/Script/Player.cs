using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool leftOrRight=true;
    public bool LeftOrRight { get {return leftOrRight; }}
    public void ChangeDirection()
    {
        leftOrRight = !leftOrRight;
        initializeThePlayerBool = false;
    }

    [SerializeField] Transform leftCutter, rightCutter,wire;
    [SerializeField] float rotationSpeed = 0.5f;

    [SerializeField] Transform selectedTrans;
    public bool initializeThePlayerBool;
    // Start is called before the first frame update
    void Start()
    {
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {  
        if (!initializeThePlayerBool) InitializeTheChange();
        if (leftOrRight)
        {
           
        }
        else
        {

        }
        Vector2 myRotation = selectedTrans.transform.localRotation.eulerAngles;
        myRotation += Vector2.up * rotationSpeed;
        selectedTrans.rotation = Quaternion.Euler(myRotation);
    }
    void InitializeTheChange()
    {
        UnParent();
        if (leftOrRight)
        {//rotate around right
            rightCutter.SetParent(leftCutter);
            wire.SetParent(leftCutter);
            selectedTrans = leftCutter;
        }else
        {
            //rotate around left
            leftCutter.SetParent(rightCutter);
            wire.SetParent(rightCutter);
            selectedTrans = rightCutter;
        }
        initializeThePlayerBool = true;
    }
    void UnParent()
    {
        rightCutter.SetParent(transform);
        wire.SetParent(transform);
        leftCutter.SetParent(transform);
    }
}
