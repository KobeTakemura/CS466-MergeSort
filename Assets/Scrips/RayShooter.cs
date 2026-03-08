using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RayShooter : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private Image reticleImage;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color targetColor = Color.green;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Safe default so you don't get null refs on start
        if (reticleImage != null)
            reticleImage.color = normalColor;
    }

    void Update()
    {
        // Always cast from center (VR-friendly)
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // Hover feedback (reticle color change)
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            bool aimingAtTarget = hit.transform.GetComponentInParent<ReactiveTarget>() != null;
            if (reticleImage != null)
                reticleImage.color = aimingAtTarget ? targetColor : normalColor;
        }
        else
        {
            if (reticleImage != null)
                reticleImage.color = normalColor;
        }

        // Fire trigger (desktop click for now; later add tap/dwell)
        bool fired = Input.GetMouseButtonDown(0);

        if (!fired) return;

        // Prevent shooting through UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            ReactiveTarget target = hit.transform.GetComponentInParent<ReactiveTarget>();
            if (target != null)
            {
                target.ReactToHit();
            }
            else
            {
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1f);
        Destroy(sphere);
    }
}