using System.Collections;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private GameObject target;
    private float speed;
    private float resizeTimer;
    private Vector3 initialSize;
    private Coroutine lerpTo;

    private void Start()
    {
        speed = 0.05f;
        target = GameObject.FindGameObjectWithTag("follow");
        resizeTimer = 3;
        initialSize = transform.localScale;
    }

    private void Update()
    {
        speed = (0.5f * (OutlineGameController.points + 0.05f));
        resizeTimer -= Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        if (resizeTimer <= 0)
        {
            resizeTimer = 3;
            if (lerpTo != null)
            {
                StopCoroutine(lerpTo);
            }
            float n = Random.Range(1.0f, 3.0f);
            lerpTo = StartCoroutine(LerpTo(initialSize * n));
        }
    }

    private IEnumerator LerpTo(Vector3 newSize)
    {
        var startSize = transform.localScale;
        var percentComplete = 0f;
        while (transform.localScale != newSize)
        {
            transform.localScale = Vector3.Lerp(startSize, newSize, percentComplete / 1);
            percentComplete += Time.deltaTime;
            yield return null;
        }
    }
}
