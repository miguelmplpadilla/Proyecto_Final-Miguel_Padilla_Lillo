using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public Animator animator;
    public GameObject player;
    public bool gun = false;
    private bool shooting = false;

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            gun = false;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            gun = true;
        }
        
        animator.SetBool("gun",gun);

        if (gun == true) {

            if (Input.GetKeyDown(KeyCode.Mouse0)) {

                if (shooting == false) {
                    shoot();
                    shooting = true;
                }

            }
            
        }
    }

    void shoot() {
        player.SendMessageUpwards("stoping");
        
    }
}
