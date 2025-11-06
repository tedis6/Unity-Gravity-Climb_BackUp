using UnityEngine;

public class CeilingFlipSimpleOffset : MonoBehaviour
{
    [SerializeField] KeyCode toggleKey = KeyCode.G;
    [SerializeField] float gravityMagnitude = 9.81f;

    [Header("Offsets")]
    [SerializeField] float preFlipLift = 0.15f;   // Abstand vor dem Flip (weg von aktueller Fläche)
    [SerializeField] float postFlipNudge = 0.05f; // minimaler Abstand nach dem Flip (in neue Up-Richtung)

    Rigidbody rb;
    bool onCeiling = false; // false=Boden, true=Decke

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            // Vor dem Flip: weg von aktueller Fläche (Boden -> +Y, Decke -> -Y)
            Vector3 preDir = onCeiling ? Vector3.down : Vector3.up;
            transform.position += preDir * preFlipLift;

            // ---- Vorwärts-Geschwindigkeit sichern ----
            Vector3 oldFwd = transform.forward;
            float fwdSpeed = Vector3.Dot(rb.velocity, oldFwd);
            Vector3 lateral = rb.velocity - oldFwd * fwdSpeed;

            // Flip: 180° ROLL um die lokale Vorwärtsachse (Z), so bleibt "Front" gleich
            onCeiling = !onCeiling;
            transform.rotation = Quaternion.AngleAxis(180f, transform.forward) * transform.rotation;

            // Nach dem Flip: kleiner Nudge in neue Up-Richtung (weg von Ziel-Fläche)
            transform.position += transform.up * postFlipNudge;

            // ---- Geschwindigkeit auf neue Orientierung übertragen ----
            Vector3 newFwd = transform.forward;                  // gleich wie vorher dank Roll, zur Sicherheit trotzdem neu lesen
            Vector3 newVel = newFwd * fwdSpeed                   // Vorwärts-Komponente bleibt erhalten
                            + Vector3.ProjectOnPlane(lateral, transform.up); // Seitenanteil an neue Up-Achse anpassen
            rb.velocity = newVel;

            // Optional: Drehgeschwindigkeit auf neue Up-Ebene projizieren (stabiler)
            rb.angularVelocity = Vector3.ProjectOnPlane(rb.angularVelocity, transform.up);
        }
    }

    void FixedUpdate()
    {
        Vector3 dir = onCeiling ? Vector3.up : Vector3.down;
        rb.AddForce(dir * gravityMagnitude, ForceMode.Acceleration);
    }
}
