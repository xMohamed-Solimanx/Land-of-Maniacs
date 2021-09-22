using UnityEngine;

namespace Nokobot.Assets.Crossbow
{
    public class CrossbowShoot : MonoBehaviour
    {
        public GameObject arrowPrefab;
        public Transform arrowLocation;

        public float shotPower = 100f;

        void Start()
        {
            if (arrowLocation == null)
                arrowLocation = transform;
        }

        void Update()
        {
            if (SaveScript.Arrows > 0)
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);
                    }
                }
            }
        }
    }
}
//Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);
