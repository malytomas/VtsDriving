using UnityEngine;

public class Reset : MonoBehaviour
{
    Vector3 initPos;
    Quaternion initRot;

    void Start ()
    {
        initPos = transform.position;
        initRot = transform.rotation;
    }

    void Stop()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Stop();
            transform.position += new Vector3(0, 2, 0);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles[1], 0);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            transform.position = initPos;
            transform.rotation = initRot;
            Stop();
            var a = gameObject.AddComponent<VtsRigidBodyActivate>();
            a.map = FindObjectOfType<VtsMap>().gameObject;
        }
    }
}