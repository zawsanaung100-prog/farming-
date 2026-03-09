using UnityEngine;
using System.Collections;

public class PlayerFishing : MonoBehaviour
{
    public GameObject fishingRod;
    public GameObject caughtFish;

    private bool nearWater = false;
    private bool isFishing = false;

    void Start()
    {
        if (fishingRod != null)
            fishingRod.SetActive(false);

        if (caughtFish != null)
            caughtFish.SetActive(false);
    }

    void Update()
    {
        if (nearWater && !isFishing && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FishingRoutine());
        }
    }

    IEnumerator FishingRoutine()
    {
        isFishing = true;

        // Show rod
        if (fishingRod != null)
        {
            fishingRod.SetActive(true);

            Transform rod = fishingRod.transform;
            Quaternion startRot = rod.localRotation;
            Quaternion castRot = Quaternion.Euler(0, 0, -25f);

            float time = 0f;

            while (time < 0.15f)
            {
                rod.localRotation = Quaternion.Lerp(startRot, castRot, time / 0.15f);
                time += Time.deltaTime;
                yield return null;
            }

            rod.localRotation = castRot;

            // wait for fish
            yield return new WaitForSeconds(1.5f);

            // show fish
            if (caughtFish != null)
            {
                caughtFish.SetActive(true);
                yield return new WaitForSeconds(1f);
                caughtFish.SetActive(false);
            }

            // return rod
            time = 0f;

            while (time < 0.15f)
            {
                rod.localRotation = Quaternion.Lerp(castRot, startRot, time / 0.15f);
                time += Time.deltaTime;
                yield return null;
            }

            rod.localRotation = startRot;

            fishingRod.SetActive(false);
        }

        isFishing = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            nearWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            nearWater = false;
        }
    }
}