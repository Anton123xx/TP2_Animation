using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum TaskState { Running, Success, Failure }
public abstract class TaskBT
{
    public abstract TaskState Execute();
}

public class TaskNode : Node
{
    //protected List<TaskBT> Tasks { get; private set; } = new();
    //private int CurrentTaskIndex { get; set; }

    //public TaskNode(string tag, IEnumerable<TaskBT> tasks)
    //    : base(tag)
    //{
    //    foreach (TaskBT task in tasks)
    //    {
    //        AddTask(task);
    //    }
    //}

    //public void AddTask(TaskBT task) => Tasks.Add(task);

    //protected override NodeState InnerEvaluate()
    //{
    //    bool executeNextTask = true;
    //    int taskCount = Tasks.Count;

    //    while (executeNextTask)
    //    {
    //        TaskBT currentTask = Tasks[CurrentTaskIndex];
    //        TaskState currentTaskState = currentTask.Execute();

    //        switch (currentTaskState)
    //        {
    //            case TaskState.Failure:
    //                State = NodeState.Failure;
    //                return State;
    //            case TaskState.Running:
    //                executeNextTask = false;
    //                break;
    //            case TaskState.Success:
    //                if (CurrentTaskIndex == taskCount - 1)
    //                {
    //                    CurrentTaskIndex = 0;
    //                    State = NodeState.Success;
    //                    return State;
    //                }

    //                ++CurrentTaskIndex;
    //                break;
    //        }
    //    }
    //}
}