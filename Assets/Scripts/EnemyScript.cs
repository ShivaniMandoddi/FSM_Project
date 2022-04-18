using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public enum STATE
    {
        LOOKFOR, GOTO, ATTACK, DEAD
    }
    public STATE currentState = STATE.LOOKFOR;
    public float enemySpeed;
    public float gotoDistance;
    public float attackDistance;
    public Transform target;
    public string playerTag;
    public float attackTime;
    public float currentTime;
    PlayerController playerController;
    // Update is called once per frame
   
    IEnumerator Start()
    {
        currentTime = attackTime;
        if(target!=null)
        {
            playerController = target.GetComponent<PlayerController>();
        }
        while(true)
        {
            switch (currentState)
            {
                case STATE.LOOKFOR:
                    LookFor();
                    break;
                case STATE.GOTO:
                    Goto();
                    break;
                case STATE.ATTACK:

                    Attack();
                    break;
                case STATE.DEAD:
                    Dead();
                    break;
                default:
                    break;
            }
            yield return 0;
        }
      
    }
    public void LookFor()
    {
        if(Vector3.Distance(target.transform.position,this.transform.position)<gotoDistance)
        {
            currentState = STATE.GOTO;
        }
        Debug.Log("IN LookFor State");
    }
    public void Attack()
    {
        currentTime = currentTime - Time.deltaTime;
        if(currentTime<=0f)
        {
            playerController.health--;
            Debug.Log(playerController.health);
            currentTime = attackTime;
        }
        if(playerController.health<0)
        {
            currentState = STATE.DEAD;
        }
        if(Vector3.Distance(target.transform.position,this.transform.position)>attackDistance)
        {
            currentState = STATE.GOTO;
        }
            Debug.Log("IN Attack State");
    }
    public void Goto()
    {
        if (Vector3.Distance(target.transform.position,this.transform.position)>attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        }
        else
        {
            currentState = STATE.ATTACK;
        }
            Debug.Log("IN GoTo State");
    }
    public void Dead()
    {
        Debug.Log("Game Over!");
    }
}
