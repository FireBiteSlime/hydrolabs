using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class faucet : MonoBehaviour
{
    public GameObject top_wall;
    public GameObject bottom_wall;

    public float K;
    public float fulfillTime = 2.5f;

    private int direction = 1;
    /*
    public int waitStartSec;
    public int waitEndSec;
    public ObiEmitter emitter;
    public bool retryOnLifespan;
    */

    // Start is called before the first frame update
    void Start()
    {
        K = shared_data.K == -1 ? K : shared_data.K;

        /*
        if (waitStartSec == 0)
        {
            openFaucet();
        }
        else
        {
            StartCoroutine(openCoroutine());
        }

        if (waitEndSec > 0) StartCoroutine(closeCoroutine());

        if(retryOnLifespan) StartCoroutine(retryCouroutine());
        */
        StartCoroutine(moveFaucetCoroutine(15f));
    }

    /*
    IEnumerator retryCouroutine()
    {
        yield return new WaitForSeconds(this.emitter.lifespan);
        Start();
    }

    IEnumerator openCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitStartSec);
        openFaucet();
    }

    IEnumerator closeCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitEndSec);
        closeFaucet();
    }
    */

    public void onButtonClick()
    {
        moveFaucet();
    }

    IEnumerator moveFaucetCoroutine(float waitForSec)
    {
        yield return new WaitForSeconds(waitForSec);
        moveFaucet();

        StartCoroutine(closeFaucetCoroutine((1f - K) * fulfillTime + fulfillTime));
    }

    IEnumerator closeFaucetCoroutine(float waitForSec)
    {
        yield return new WaitForSeconds(waitForSec);
        moveFaucet();
    }

    private void moveFaucet()
    {
        Vector3 delta = top_wall.transform.position - bottom_wall.transform.position;
        float distance = delta.y - top_wall.GetComponent<SpriteRenderer>().bounds.size.y;

        this.transform.Translate(0, direction * distance * Mathf.Clamp(K, 0, 1), 0);
        direction *= -1;
        shared_data.isSimulatonEnabled = !shared_data.isSimulatonEnabled;
    }
}
