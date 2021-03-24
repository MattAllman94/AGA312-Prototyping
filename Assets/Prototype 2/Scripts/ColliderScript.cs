using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : JMC
{

    public float fixedScale = 1;
    public GameObject parent;
    public RootScript root;

    private void Update()
    {
        transform.localScale = new Vector3(fixedScale / parent.transform.localScale.x, fixedScale / parent.transform.localScale.y, fixedScale / parent.transform.localScale.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nutrient"))
        {
            root.LockRoot();
            Debug.Log("Collect");
            _SM2.SpawnRoot(this.gameObject);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Water"))
        {
            root.LockRoot();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (root.waterLevel < 50)
        {
            root.waterLevel += Time.deltaTime;
            root.isDrinking = true;
        }
    }
}
