using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InteractionJoueur : MonoBehaviour
{
    [Header("Raycast d'interaction")]
    [SerializeField] float distanceInteraction = 2f; // Distance maximale pour interagir avec un interrupteur
    [SerializeField] LayerMask couchesInteractives; // Couches sur lesquelles le joueur peut


    [Header("Composants")]
    ControlesJoueur controles;
    Animator animator;

    void Start()
    {
        controles = GetComponent<ControlesJoueur>();
        animator = GetComponent<Animator>();
    }


    void OnDrawGizmos()
    {
        // Dessiner un rayon pour visualiser la distance d'interaction dans l'éditeur
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.forward * distanceInteraction);
    }

    void OnTriggerEnter(Collider other)
    {

    }
    public void DetecterInterrupteur()
    {
        Vector3 origine = transform.position + Vector3.up;
        Vector3 direction = transform.forward;
        if (Physics.Raycast(origine, direction, out RaycastHit collision, distanceInteraction, couchesInteractives, QueryTriggerInteraction.Collide))
        {
            Interrupteur scriptInterrupteur = collision.collider.GetComponent<Interrupteur>();
            //detecter  lke script  de l'interfupetru
            if (scriptInterrupteur != null)
            {
                scriptInterrupteur.Activer();

;            }
            //declencher lanimation boutuon
            // activer lanimation sur la porte

        }
        controles.Invoke("RetourEtatLibre", 3f);
    }


}
