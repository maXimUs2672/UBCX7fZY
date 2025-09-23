// 代码生成时间: 2025-09-24 00:55:01
 * A simple task scheduler that allows for scheduling tasks to run at specific intervals
 * using Unity's coroutine system.
 *
 * Features:
 * - Schedule tasks to run after a delay
 * - Schedule tasks to run repeatedly at a set interval
 * - Cancel scheduled tasks
 * - Error handling for tasks that throw exceptions
 *
 * Usage:
 * - Create an instance of TaskScheduler
 * - Use the ScheduleTask method to schedule tasks
 * - Use the CancelTask method to cancel scheduled tasks
 */
using System;
using System.Collections;
using UnityEngine;

public class TaskScheduler : MonoBehaviour
{
    private Dictionary<string, Coroutine> scheduledTasks = new Dictionary<string, Coroutine>();

    // Schedules a task to run after a delay
    public void ScheduleTask(IEnumerator task, float delay, string taskId = null)
    {
        StartCoroutine(RunTaskAfterDelay(task, delay, taskId));
    }

    // Schedules a task to run repeatedly at a set interval
    public void ScheduleRepeatingTask(IEnumerator task, float interval, string taskId = null)
    {
        StartCoroutine(RunTaskRepeating(task, interval, taskId));
    }

    // Cancels a scheduled task by its ID
    public void CancelTask(string taskId)
    {
        if (scheduledTasks.ContainsKey(taskId))
        {
            StopCoroutine(scheduledTasks[taskId]);
            scheduledTasks.Remove(taskId);
        }
    }

    private IEnumerator RunTaskAfterDelay(IEnumerator task, float delay, string taskId)
    {
        yield return new WaitForSeconds(delay);
        try
        {
            yield return StartCoroutine(task);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Task failed with error: {ex.Message}");
        }
    }

    private IEnumerator RunTaskRepeating(IEnumerator task, float interval, string taskId)
    {
        while (true)
        {
            try
            {
                yield return StartCoroutine(task);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Task failed with error: {ex.Message}");
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
