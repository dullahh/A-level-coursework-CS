using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot: MonoBehaviour
{
    public Camera playerCamera;
    public bool Firing, ReadyToFire; // 2 boolean variables created however theyre not yet assigned anything
    bool reChamber = true;
    public float FireRate = 0.9f;
    public GameObject projectilePreFab; // a game object is simply an object in unity that can possess components which can perform functions,
                                        // prefab is a special feature that can be assigned to GameObjects that allows them to be reused
    public Transform ProjectileSpawnPoint;
    public float projectileVelocity = 100;
    public float projectileLifetime = 5f;
    public float bulletsFired = 0;// the variable that'll hold the amount of shots fired

    public enum FireMode
    {
        Single,
        fullAuto,
    }

    public FireMode currentFireMode;


    private void awake()
    {
        ReadyToFire = true; //ready to fire at the beginning
    }

    // Update is called once per frame
  
    void Update()
    {
        if (currentFireMode == FireMode.fullAuto)
        {
            Firing = Input.GetKey(KeyCode.Mouse0); //holding the mouse button
        }
        else if (currentFireMode == FireMode.Single)
        {
            Firing = Input.GetKeyDown(KeyCode.Mouse0);

        }

        if (ReadyToFire && Firing) // both of these Boolean variables must be true if the user is to shoot again
        {
            bulletShooting();
        }

    }
    
    private void bulletShooting() //private void because we do not expect any return values
    {
        bulletsFired++;// this accumulates 1 to the count each time this function is called
        ReadyToFire = false;
        Vector3 FiringDirection = TrajectoryCalculation().normalized;
        

        GameObject projectile = Instantiate(projectilePreFab, ProjectileSpawnPoint.position, Quaternion.identity);
        // this'll formulate the actual projectile, its starting position and its starting orientation(which is the identity quaternion--> its a rotation of nothing)


        projectile.GetComponent<Rigidbody>().AddForce(FiringDirection * projectileVelocity, ForceMode.Impulse); // forward means the x axis relative to the orientation of the weapon

        
        StartCoroutine(DestroyProjectileAfterLifetime(projectile, projectileLifetime));
      

        if (reChamber == true)
        {
            Invoke("reChambering", FireRate); //invoke allows us to schedule the calling of this method at a later time
            reChamber = false;
        }
    }
    private void reChambering()
    {
        ReadyToFire = true;
        reChamber = true;
    }

    public Vector3 TrajectoryCalculation()
    {
        Ray viewPoint = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // the 3 arguements provided here for the vector is so that the ray comes directly from the centre of the player's view
        RaycastHit hit;

        Vector3 targetLocation;// the name of the point that the player is directly looking at
        if (Physics.Raycast(viewPoint, out hit))
        {
            targetLocation = hit.point; //a specific point will be assigned as a target if the player's view is centred at an object
        }
        else
        {
            targetLocation = viewPoint.GetPoint(100); 
            // the player center of vision may not always be facing an object(e.g the sky), so the target point will be 100
            // units ahead of the player's view( a unit being a measurement of distance).
        }

        Vector3 trajectory = targetLocation - ProjectileSpawnPoint.position;

       

        return trajectory + new Vector3(0, 0, 0);
    }

    private IEnumerator DestroyProjectileAfterLifetime(GameObject projectile, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(projectile);
    }

}