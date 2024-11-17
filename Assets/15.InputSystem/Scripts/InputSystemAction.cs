using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;


namespace MyProject
{
    [RequireComponent(typeof(Animator), typeof(RigBuilder), typeof(PlayerInput))]
    public class InputSystemAction : MonoBehaviour
    {
        private Animator animator;
        private Rig rig;

        private WaitUntil untilReload;
        private WaitForSeconds waitSecReloadLen;
        private bool isReloading;
        public AnimationClip reloadClip;

        private WaitUntil untilGrenade;
        private WaitForSeconds waitSecGrenadeLen;
        private bool isGrenadeToss;
        public AnimationClip grenadeClip;

        private InputAction fireAction;
        private bool isFiring;
        private WaitUntil untilFire;
        private WaitForSeconds waitSecFireLen;
        public AnimationClip fireClip;

        private InputAction reloadAction;

        private InputAction grenadeAction;

        public InputActionAsset controlDefine;


        public GameObject camRig;
        private Camera cam;
        public GameObject camZoomPos;

        public RawImage crossHair;

        private void Awake()
        {
            controlDefine = GetComponent<PlayerInput>().actions;
            reloadAction = controlDefine.FindAction("Reload");
            grenadeAction = controlDefine.FindAction("Grenade");
            fireAction = controlDefine.FindAction("Fire");
            animator = GetComponent<Animator>();
            rig = GetComponent<RigBuilder>().layers[0].rig;
            cam = camRig.GetComponentInChildren<Camera>();
        }

        private void OnEnable()
        {
            reloadAction.performed += OnReloadEvent;
            reloadAction.canceled += OnReloadEvent;
            grenadeAction.performed += OnGrenadeEvent;
            grenadeAction.canceled += OnGrenadeEvent;
            fireAction.performed += OnFire;
            fireAction.canceled += OnFire;
        }

        private void OnDisable()
        {
            reloadAction.performed -= OnReloadEvent;
            reloadAction.canceled -= OnReloadEvent;
            grenadeAction.performed -= OnGrenadeEvent;
            grenadeAction.canceled -= OnGrenadeEvent;
            fireAction.performed -= OnFire;
            fireAction.canceled -= OnFire;
        }

        private void Start()
        {
            StartCoroutine(ReloadCoroutine());
            StartCoroutine(GrenadeCoroutine());
            StartCoroutine(FireCoroutine());
        }


        private void Update()
        {

            ZoomInOut();
        }

        private void ZoomInOut()
        {
            if (Input.GetMouseButtonDown(1))
            {
                cam.transform.position = camZoomPos.transform.position;
                cam.fieldOfView = 20;
            }
            if(Input.GetMouseButtonUp(1))
            {
                cam.transform.position = camRig.transform.position;
                cam.fieldOfView = 60;
            }
        }

        private IEnumerator FireCoroutine()
        {
            untilFire = new WaitUntil(() => isFiring);
            waitSecFireLen = new WaitForSeconds(fireClip.length);
            while (true)
            {
                Ray ray = new Ray(crossHair.transform.position, crossHair.transform.forward);
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 0.2f);
                yield return untilFire;
                yield return waitSecFireLen;
            }
        }

        private IEnumerator ReloadCoroutine()
        {
            untilReload = new WaitUntil(() => isReloading);
            waitSecReloadLen = new WaitForSeconds(reloadClip.length);
            while (true)
            {
                yield return untilReload;
                yield return waitSecReloadLen;
                isReloading = false;
                rig.weight = 1f;
            }
        }
        private IEnumerator GrenadeCoroutine()
        {
            untilGrenade = new WaitUntil(() => isGrenadeToss);
            waitSecGrenadeLen = new WaitForSeconds(grenadeClip.length);
            while (true)
            {
                yield return untilGrenade;
                yield return waitSecGrenadeLen;
                isGrenadeToss = false;
                rig.weight = 1f;
            }
        }

        public void OnFire(Context context)
        {
            if (context.performed)
            {
                isFiring = true;
                animator.SetTrigger("Fire");
            }
            if (context.canceled)
            {
                isFiring = false;
            }
        }

        public void OnGrenadeEvent(Context context)
        {
            if (isGrenadeToss || isReloading) return;
            if (context.performed)
            {
                rig.weight = 0f;
                isGrenadeToss = true;
                animator.SetTrigger("Grenade");
            }
        }

        public void OnReloadEvent(Context context)
        {
            if (isReloading || isGrenadeToss) return;
            if (context.performed)
            {
                rig.weight = 0f;
                isReloading = true;
                animator.SetTrigger("Reload");
            }
        }
        public void OnReloadEnd()
        {
            print("OnReloadEnd Called by Animation Event!");
        }

        private void OnReload(InputValue value)
        {
            //print($"OnRealod »£√‚µ . isPressed : {value.isPressed} | {value.Get<Single>()}");
            if (isReloading) return;

            //rig.weight = 0f;
            //isReloading = true;
            //animator.SetTrigger("Relaod");
        }

    }
}
