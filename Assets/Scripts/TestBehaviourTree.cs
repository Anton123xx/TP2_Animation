using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class TestBehaviourTree : MonoBehaviour
{
    //[SerializeField]
    //Transform[] patrolDestinations;
    //[SerializeField]
    //NavMeshAgent agent;

    //private Node rootBT;

    //private void Awake()
    //{
    //    Vector3[] destinations = patrolDestinations.Select(t => t.position).ToArray();
    //    TaskBT[] tasks0 = new TaskBT[]
    //    {
    //        new Patrol(destinations, agent),
    //    };
    //    TaskBT[] tasks1 = new TaskBT[]
    //    {
    //        new Wait(2)
    //    };
    //    TaskBT[] tasks2 = new TaskBT[]
    //    {
    //        new DummyTask("J'ai attendu 2 secs", TaskState.Success)
    //    };

    //    TaskNode patrolNode = new TaskNode("patrolNode1", tasks0);
    //    TaskNode waitNode = new TaskNode("taskNode1", tasks1);
    //    TaskNode dummyNode = new TaskNode("dummyNode1", tasks2);
    //    Node seq1 = new Sequence("seq1", new[] { patrolNode, waitNode, dummyNode });

    //    rootBT = seq1;
    //    /*
    //    TaskBT[] tasks1 = new TaskBT[]
    //    {
    //        new DummyTask("A1", TaskState.Failure),
    //        new DummyTask("A2", TaskState.Success)
    //    };
    //    TaskBT[] tasks2 = new TaskBT[]
    //    {
    //        new DummyTask("B", TaskState.Success)
    //    };

    //    TaskNode tn1 = new TaskNode("TN1", tasks1);
    //    TaskNode tn2 = new TaskNode("TN2", tasks2);

    //    Sequence seq1 = new Sequence("SEQ1", new Node[] {tn1, tn2});
    //    rootBT = seq1;
    //    */
    //}

    //void Update()
    //{
    //    rootBT.Evaluate();
    //}
}