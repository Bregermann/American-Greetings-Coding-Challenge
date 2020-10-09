using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(AudioSource))]
public class ColorChanging : MonoBehaviour
{
    private const float DOUBLE_CLICK_TIME = .5f;

    public LayerMask clickMask;
    private Renderer rend;
    private AudioSource clickSound;
    private float lastClickTime;

    public int timesDoubleClicked;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        clickSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, clickMask))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    float timeSinceLastClick = Time.time - lastClickTime;
                    if (timeSinceLastClick <= DOUBLE_CLICK_TIME)
                    {
                        // On Double Click
                        lastClickTime = 0;
                        rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.0f, 1f);
                        clickSound.Play();
                        timesDoubleClicked++;
                        Debug.Log(timesDoubleClicked);
                    }
                    else
                    {
                        // On Single Click
                        lastClickTime = Time.time;
                    }
                }
                else
                {
                    lastClickTime = 0;
                }
            }
            else
            {
                lastClickTime = 0;
            }
        }
    }
}
