using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public Light redLight;
    public Light yellowLight;
    public Light greenLight;

    public float redTime = 5f;
    public float yellowTime = 2f;
    public float greenTime = 5f;

    private float timer = 0f;
    private TrafficLightState currentState;

    private enum TrafficLightState
    {
        Red,
        Yellow,
        Green
    }

    void Start()
    {
        currentState = TrafficLightState.Red;
        redLight.enabled = true;
        yellowLight.enabled = false;
        greenLight.enabled = false;
        timer = redTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            ChangeState();
        }
    }

    void ChangeState()
    {
        switch (currentState)
        {
            case TrafficLightState.Red:
                currentState = TrafficLightState.Green;
                redLight.enabled = false;
                yellowLight.enabled = false;
                greenLight.enabled = true;
                timer = greenTime;
                break;

            case TrafficLightState.Yellow:
                currentState = TrafficLightState.Red;
                redLight.enabled = true;
                yellowLight.enabled = false;
                greenLight.enabled = false;
                timer = redTime;
                break;

            case TrafficLightState.Green:
                currentState = TrafficLightState.Yellow;
                redLight.enabled = false;
                yellowLight.enabled = true;
                greenLight.enabled = false;
                timer = yellowTime;
                break;
        }
    }
}