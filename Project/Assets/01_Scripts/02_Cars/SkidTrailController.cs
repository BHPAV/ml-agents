using UnityEngine;




public class SkidTrailController : MonoBehaviour
{

    //// VARIABLE DECLARATIONS \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private TrailRenderer skidTrail;
    private ParticleSystem smokeTrail;
    private WheelControl wheelControl;
    
    private float waitTime = 0.25f;
    private float startTime;
    private bool waiting = false;

    public float tireTemperature = 0f;
    private float lastTempIncreaseTime = 0f;

    public bool skidding;

    private float smokeTimer = 0f;
    private float smokeTimerMax = 0.25f;


    //// GENERAL OPERATION \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    void Start()
    {
        GetController();
        GetEffects();
    }


    void Update()
    {
        SkidControl();
        //TireSmoke();
        SmokeControl();
    }





    /////CONTROL FUNCTIONS \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void SkidControl()
    {
        skidding = wheelControl.IsSkidding();
        skidTrail.emitting = skidding;
        
        if(skidding)
            //IncreaseTireTemperature();

        if (!skidding && !waiting)
        {
            startTime = Time.time;
            waiting = true;
        }

        if (waiting && Time.time - startTime > waitTime && !skidding)
        {
            skidTrail.emitting = false;
            waiting = false;
        }
    }

    private void GetEffects()
    {
        Transform fxTransform = transform.Find("FX");
        if (fxTransform != null)
        {
            skidTrail = fxTransform.GetComponent<TrailRenderer>();
            smokeTrail = fxTransform.GetComponent<ParticleSystem>();
        }
    }

    private void GetController()
    {
        wheelControl = GetComponent<WheelControl>();
    }

    public void IncreaseTireTemperature()
    {
        tireTemperature += 1f;
        lastTempIncreaseTime = Time.time;
    }

    private void TireSmoke()
    {
        /*
        tireTemperature = Mathf.Clamp(tireTemperature, 0f, 300f);

        if (tireTemperature > 100f && skidding)
        {
            smokeTrail.Play();
        }
        else if (tireTemperature < 50f || !skidding)
        {
            smokeTrail.Stop();
        }

        if (Time.time - lastTempIncreaseTime > 0.25f)
        {
            tireTemperature -= Time.deltaTime * 10f;
            tireTemperature = Mathf.Clamp(tireTemperature, 0f, 300f);
        }
        */
    }


    private void SmokeControl()
    {
        if (skidding)
        {
            smokeTrail.Play();

            smokeTimer += Time.deltaTime;
            if (smokeTimer >= smokeTimerMax)
            {
                smokeTimer = smokeTimerMax;
            }
        }
        else
        {
            smokeTimer -= Time.deltaTime;
            if (smokeTimer <= 0f)
            {
                smokeTrail.Stop();
                smokeTimer = 0f;
            }
        }
    }


}