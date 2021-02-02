using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lick : MonoBehaviour
{
    bool isLicking = false;
    float tongueStartStretch = 0;
    float tongueCurrentStretch = 0;
    float tongueMaxStretch = 0.2f;
    float tongueSpeed = 2.0f;

    LickState currentState = LickState.Input;

    enum LickState
    {
        Input,
        StretchIncrease,
        StretchDecrease
    }

    private void Update()
    {
        if(currentState == LickState.Input)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Input -> stretch increase");
                currentState = LickState.StretchIncrease;
            }
        }
        else if(currentState == LickState.StretchIncrease)
        {
            tongueCurrentStretch += tongueSpeed * Time.deltaTime;
            tongueCurrentStretch = Mathf.Clamp(tongueCurrentStretch, tongueStartStretch, tongueMaxStretch);
            transform.localScale = new Vector3(tongueCurrentStretch, transform.localScale.y, transform.localScale.z);

            if(tongueCurrentStretch >= tongueMaxStretch)
            {
                Debug.Log("Stretch increase -> stretch decrease");
                currentState = LickState.StretchDecrease;
            }
        }
        else if(currentState == LickState.StretchDecrease)
        {
            tongueCurrentStretch -= tongueSpeed * Time.deltaTime;
            tongueCurrentStretch = Mathf.Clamp(tongueCurrentStretch, tongueStartStretch, tongueMaxStretch);
            transform.localScale = new Vector3(tongueCurrentStretch, transform.localScale.y, transform.localScale.z);

            if(tongueCurrentStretch <= tongueStartStretch)
            {
                Debug.Log("stretch decrease -> Input");
                currentState = LickState.Input;
            }
        }
    }
}

