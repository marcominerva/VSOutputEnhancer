using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildActionStart
{
    public class BuildActionCollection
    {
        private sealed class BuildActionValue
        {
            public BuildActionState? State { get; set; }

            public SnapshotSpan? Span { get; set; }

            public bool PreserveStateForNextClassification { get; set; }
        }

        private readonly IDictionary<string, IDictionary<string, BuildActionValue>> data = new Dictionary<string, IDictionary<string, BuildActionValue>>();
        private readonly IDictionary<string, string> latestProjects = new Dictionary<string, string>();
        private readonly IDictionary<string, IDictionary<int, string>> latestParallelProjects = new Dictionary<string, IDictionary<int, string>>();

        public IEnumerable<string> EnumerateProjects(string action)
        {
            return data.TryGetValue(action, out var projects) ? projects.Keys : [];
        }

        public void HandleActionStart(string action, string projectName, int? buildTaskId, SnapshotSpan span)
        {
            var value = GetOrAddValue(action, projectName);
            var preserveState = value.PreserveStateForNextClassification;
            value.PreserveStateForNextClassification = false;
            value.Span = span;
            if (!preserveState)
            {
                value.State = null;
            }

            SetLatestProject(action, projectName, buildTaskId);
        }

        public bool HandleStateChange(string action, string projectName, BuildActionState state)
        {
            var value = GetOrAddValue(action, projectName);
            if (value.State >= state)
            {
                return false;
            }

            value.State = state;
            return true;
        }

        public BuildActionState GetState(string action, string projectName)
        {
            var value = GetOrAddValue(action, projectName);
            return value.State ?? BuildActionState.Unknown;
        }

        public SnapshotSpan GetSpan(string action, string projectName)
        {
            var value = GetOrAddValue(action, projectName);
            return value.Span.Value;
        }

        public void PreserveStateForNextClassification(string action, string projectName)
        {
            var value = GetOrAddValue(action, projectName);
            value.PreserveStateForNextClassification = true;
        }

        public string GetLatestProject(string action, int? buildTaskId)
        {
            if (buildTaskId is null)
            {
                return latestProjects.TryGetValue(action, out var projectName) ? projectName : null;
            }

            if (!latestParallelProjects.TryGetValue(action, out var projects))
            {
                return null;
            }

            return projects.TryGetValue(buildTaskId.Value, out var parallelProjectName) ? parallelProjectName : null;
        }

        public void DeleteAll(string action)
        {
            latestProjects.Remove(action);
            latestParallelProjects.Remove(action);
        }

        private BuildActionValue GetOrAddValue(string action, string projectName)
        {
            if (!data.TryGetValue(action, out var projects))
            {
                projects = new Dictionary<string, BuildActionValue>();
                data.Add(action, projects);
            }

            if (!projects.TryGetValue(projectName, out var result))
            {
                result = new BuildActionValue();
                projects.Add(projectName, result);
            }

            return result;
        }

        private void SetLatestProject(string action, string projectName, int? buildTaskId)
        {
            if (buildTaskId is null)
            {
                latestProjects[action] = projectName;
                return;
            }

            if (!latestParallelProjects.TryGetValue(action, out var projects))
            {
                projects = new Dictionary<int, string>();
                latestParallelProjects.Add(action, projects);
            }

            projects[buildTaskId.Value] = projectName;
        }
    }
}
