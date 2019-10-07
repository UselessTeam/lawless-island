using UnityEngine;
using UnityEngine.UI;

public class RandomTextBehavior : MonoBehaviour
{
    public Text field;

    private float intensity = 1f;
    public float time = 1.5f;
    public float movementAmplitude = 16f;

    public string[] sentences;

    void Start()
    {
        field.text = sentences[Random.Range(0, sentences.Length)];
    }

    void Update()
    {
        float prop = Time.deltaTime/time;
        intensity -= prop;
        if(intensity <= 0f) {
            Destroy(gameObject);
        }
        field.transform.Translate(0f, movementAmplitude*prop, 0f);
        field.color = new Color(1f, 1f, 1f, Mathf.Min(1f, 1.5f*intensity));
    }
}
