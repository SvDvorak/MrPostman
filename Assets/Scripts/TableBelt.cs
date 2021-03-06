﻿using UnityEngine;

public class TableBelt : MonoBehaviour
{
    public float ConstantSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private ConveyorSubjectBehavior SetupCollisionObject(Collider collider) 
    {
        var isConveyorSubject = collider.gameObject.GetComponent<LetterEntity>() != null;
        if (!isConveyorSubject)
        {
            return null;
        }

        var conveyorSubjectScript = collider.GetComponent<ConveyorSubjectBehavior>();
        if (conveyorSubjectScript == null)
        {
            conveyorSubjectScript = collider.gameObject.AddComponent<ConveyorSubjectBehavior>();
        }

        conveyorSubjectScript.ConstantSpeed = ConstantSpeed;
        return conveyorSubjectScript;
    }

    public void OnTriggerEnter(Collider collider)
    {
        var conveyorSubjectScript = SetupCollisionObject(collider);
        if (conveyorSubjectScript != null)
        {
            conveyorSubjectScript.EnteredConveyorBelt(transform);
        }
    }
}
