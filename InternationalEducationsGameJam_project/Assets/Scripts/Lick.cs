using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lick : MonoBehaviour
{
    public Image SuperLickBar;
    public Animator animator;
    bool isSuperLicking = false;
    bool isNormalLicking = false;
    float tongueStartStretch = 0;
    float tongueCurrentStretch = 0;
    float tongueMaxStretch = 0.2f;
    float tongueSpeed = 1.0f;

    float superLickTimer = 0f;
    float currentTime = 0f;
    float maxTime = 3f;

    LickState currentState = LickState.Input;

    enum LickState
    {
        Input,
        StretchIncrease,
        StretchDecrease
    }

    private void Start()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        LickIt();
        SuperLick();

        SuperLickBar.fillAmount = currentTime / maxTime;
    }
    private void CalculateAngle()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angl = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            transform.rotation = Quaternion.AngleAxis(angl, Vector3.forward);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(-angl, Vector3.forward);
        }
    }
    void LickIt()
    {
        if (currentState == LickState.Input)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && isNormalLicking == false && isSuperLicking == false)
            {
                animator.SetTrigger("Lick");
                tongueSpeed = 1.0f;
                tongueMaxStretch = 0.2f;
                isNormalLicking = true;
                currentState = LickState.StretchIncrease;
                CalculateAngle();
                GetComponentInParent<AudioSource>().Play();
            }
        }
        else if (currentState == LickState.StretchIncrease)
        {
            tongueCurrentStretch += tongueSpeed * Time.deltaTime;
            tongueCurrentStretch = Mathf.Clamp(tongueCurrentStretch, tongueStartStretch, tongueMaxStretch);
            transform.localScale = new Vector3(tongueCurrentStretch, transform.localScale.y, transform.localScale.z);

            if (tongueCurrentStretch >= tongueMaxStretch)
            {
                currentState = LickState.StretchDecrease;
            }
        }
        else if (currentState == LickState.StretchDecrease)
        {
            tongueCurrentStretch -= tongueSpeed * Time.deltaTime;
            tongueCurrentStretch = Mathf.Clamp(tongueCurrentStretch, tongueStartStretch, tongueMaxStretch);
            transform.localScale = new Vector3(tongueCurrentStretch, transform.localScale.y, transform.localScale.z);

            if (tongueCurrentStretch <= tongueStartStretch)
            {
                currentState = LickState.Input;
            }
        }

        isNormalLicking = false;
    }

    void SuperLick()
    {
        if (currentState == LickState.Input)
        {
            if (Input.GetKeyDown(KeyCode.Q) && currentTime >= maxTime && isNormalLicking == false && isSuperLicking == false)
            {
                currentTime = 0f;
                tongueSpeed = 2.0f;
                tongueMaxStretch = 2f;
                isSuperLicking = true;
                currentState = LickState.StretchIncrease;
                CalculateAngle();
                GetComponentInParent<AudioSource>().Play();
            }
        }
        else if (currentState == LickState.StretchIncrease)
        {
            tongueCurrentStretch += tongueSpeed * Time.deltaTime;
            tongueCurrentStretch = Mathf.Clamp(tongueCurrentStretch, tongueStartStretch, tongueMaxStretch);
            transform.localScale = new Vector3(tongueCurrentStretch, transform.localScale.y, transform.localScale.z);

            if (tongueCurrentStretch >= tongueMaxStretch)
            {
                currentState = LickState.StretchDecrease;
            }
        }
        else if (currentState == LickState.StretchDecrease)
        {
            tongueCurrentStretch -= tongueSpeed * Time.deltaTime;
            tongueCurrentStretch = Mathf.Clamp(tongueCurrentStretch, tongueStartStretch, tongueMaxStretch);
            transform.localScale = new Vector3(tongueCurrentStretch, transform.localScale.y, transform.localScale.z);

            if (tongueCurrentStretch <= tongueStartStretch)
            {
                currentState = LickState.Input;
            }

            isSuperLicking = false;
        }
    }

}

