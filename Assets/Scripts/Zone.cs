using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Polymorphism / inheritance
//Zone --> WinZone 
//     --> LoseZone
//     --> PowerUp

//Abstract means, we cant create a instance/component of this class
public abstract class Zone : MonoBehaviour
{
    protected bool isDeactivating = false;

    //Code for this function is written in child/derived classes
    protected abstract void ZoneTrigger(GameObject marble);

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.activeSelf) return;

        if (other.tag == "Marble")
        {
            ZoneTrigger(other.gameObject);
        }
    }


    //overloading two functions with the same name (but with different parameters)
    protected IEnumerator DisableWithDelay(GameObject go, float delay, float returnDelay)
    {
        isDeactivating = true;

        yield return new WaitForSeconds(delay);
        go.SetActive(false);

        //Debug.Log("TESTP");
        yield return new WaitForSeconds(returnDelay);
        //Debug.Log("TEST");

        go.SetActive(true);

        isDeactivating = false;
    }
    protected IEnumerator DisableWithDelay(GameObject go, float delay = 1f)
    {
        isDeactivating = true;

        yield return new WaitForSeconds(delay);
        go.SetActive(false);

        isDeactivating = false;
    }

/*    protected IEnumerator DisableWithDelay(GameObject go)
    {

        yield return new WaitForSeconds(1f);
    }*/

}
