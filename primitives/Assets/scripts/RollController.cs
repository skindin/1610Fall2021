using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollController : MonoBehaviour
{
    Rigidbody rigbod;
    InputParam input;
    public List<MeshRenderer> eyes;
    Material eyeMat;
    public float speed = 10;
    bool onGround;
    public bool hasPowerUp = false;
    public float powerUpDuration = 5;
    public float powerUpForce = 10;

    private void Start()
    {
        rigbod = GetComponent<Rigidbody>();
        if (eyes.Count > 0)
        {
            eyeMat = eyes[0].material;
        }
        var controller = GetComponent<PlayerController>();
        if (controller != null)
        {
            input = controller.input;
        }
        else 
        {
            var aiController = GetComponent<AIController>();
            if (aiController != null)
            {
                input = aiController.input;
            }
        }
    }

    void SetEyeMaterial (Material newMat)
    {
        foreach (var eye in eyes)
        {
            eye.material = newMat;
        }
    }

    private void FixedUpdate()
    {
        if (onGround)
        {
            var direction = input.direction;
            //var torqueAxis = new Vector3(direction.z, 0, -direction.x);
            rigbod.AddForce(direction * speed);
        }
    }

    IEnumerator PowerUp(float duration)
    {
        hasPowerUp = true;
        yield return new WaitForSeconds(duration);
        hasPowerUp = false;
        SetEyeMaterial(eyeMat);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("powerUp"))
        {
            StartCoroutine(PowerUp(powerUpDuration));
            SetEyeMaterial(collision.gameObject.GetComponent<MeshRenderer>().material);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ball") && hasPowerUp)
        {
            if (collision.rigidbody != null)
            {
                collision.rigidbody.AddForce((collision.transform.position - transform.position) * powerUpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }
}
