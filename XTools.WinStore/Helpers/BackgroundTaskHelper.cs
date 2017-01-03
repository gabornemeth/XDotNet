using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace XDotNet.Helpers
{
    public class BackgroundTaskHelper
    {
        /// <summary>
        /// Register a background task with the specified taskEntryPoint, name, trigger,
        /// and condition (optional).
        /// </summary>
        /// <param name="taskType">Type of the task.</param>
        /// <param name="name">A name for the background task.</param>
        /// <param name="trigger">The trigger for the background task.</param>
        /// <param name="condition">An optional conditional event that must be true for the task to fire.</param>
        public static async Task<BackgroundTaskRegistration> RegisterAsync(Type taskType, String name, IBackgroundTrigger trigger, IBackgroundCondition condition)
        {
            //if (TaskRequiresBackgroundAccess(name))
            {
                await BackgroundExecutionManager.RequestAccessAsync();
            }

            var builder = new BackgroundTaskBuilder();
            builder.Name = name;
            builder.TaskEntryPoint = taskType.FullName;
            builder.SetTrigger(trigger);

            if (condition != null)
            {
                builder.AddCondition(condition);
                //
                // If the condition changes while the background task is executing then it will
                // be canceled.
                //
                builder.CancelOnConditionLoss = true;
            }

            BackgroundTaskRegistration task = builder.Register();

            //UpdateBackgroundTaskStatus(name, true);

            //
            // Remove previous completion status from local settings.
            //
            //var settings = ApplicationData.Current.LocalSettings;
            //settings.Values.Remove(name);

            return task;
        }

        /// <summary>
        /// Unregister background tasks with specified name.
        /// </summary>
        /// <param name="name">Name of the background task to unregister.</param>
        public static void Unregister(string name)
        {
            //
            // Loop through all background tasks and unregister any with SampleBackgroundTaskName or
            // SampleBackgroundTaskWithConditionName.
            //
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {
                if (cur.Value.Name == name)
                {
                    cur.Value.Unregister(true);
                    break;
                }
            }
        }

        public static bool IsRegistered(string name)
        {
            return BackgroundTaskRegistration.AllTasks.Any(cur => cur.Value.Name == name);
        }
    }
}
