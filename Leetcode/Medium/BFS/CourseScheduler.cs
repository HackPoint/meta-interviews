using Xunit;

namespace Leetcode.Medium.BFS;

/// <summary>
/// ✅ Determines if all courses can be finished given prerequisites.
/// Uses BFS Kahn's Algorithm (topological sort).
///
/// 🛠 Steps:
/// 1. Build adjacency list & indegree array.
/// 2. Push all nodes with indegree=0 into queue.
/// 3. BFS: pop node, decrement indegree of neighbors, push new indegree=0 nodes.
/// 4. If processed nodes == numCourses → true, else false (cycle exists).
///
/// ⏱ Time: O(V + E) — traverse all nodes & edges once.
/// 💾 Space: O(V + E) — adjacency list + indegree array.
///
/// 🧩 Example:
/// numCourses=4, prereq=[[1,0],[2,1],[3,2]]
/// Order: 0→1→2→3 (no cycle) → true
/// </summary>
public class CourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var indegree = new int[numCourses];
        var graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) graph[i] = new List<int>();

        // Build graph
        foreach (var p in prerequisites)
        {
            graph[p[1]].Add(p[0]);
            indegree[p[0]]++;
        }

        var q = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
            if (indegree[i] == 0) q.Enqueue(i);

        int processed = 0;
        while (q.Count > 0)
        {
            int course = q.Dequeue();
            processed++;
            foreach (var next in graph[course])
            {
                if (--indegree[next] == 0)
                    q.Enqueue(next);
            }
        }

        return processed == numCourses;
    }
}
public class CourseScheduleDFS
{
    /// <summary>
    /// ✅ Checks if all courses can be finished using DFS cycle detection.
    ///
    /// State:
    /// 0 = unvisited, 1 = visiting (on stack), 2 = visited.
    /// Cycle exists if we reach a node in "visiting" state again.
    ///
    /// ⏱ Time: O(V + E)
    /// 💾 Space: O(V + E)
    /// </summary>
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) graph[i] = new List<int>();
        foreach (var p in prerequisites) graph[p[1]].Add(p[0]);

        var state = new int[numCourses];

        bool Dfs(int course)
        {
            if (state[course] == 1) return false; // cycle
            if (state[course] == 2) return true;  // already processed

            state[course] = 1; // visiting
            foreach (var next in graph[course])
                if (!Dfs(next)) return false;

            state[course] = 2; // done
            return true;
        }

        for (int i = 0; i < numCourses; i++)
            if (!Dfs(i)) return false;

        return true;
    }
}

public class CourseScheduleDFSTests
{
    [Fact]
    public void NoCycle_ReturnsTrue()
    {
        var solver = new CourseScheduleDFS();
        int[][] prereq = {
            new []{1,0},
            new []{2,1},
            new []{3,2}
        };
        Assert.True(solver.CanFinish(4, prereq));
    }

    [Fact]
    public void HasCycle_ReturnsFalse()
    {
        var solver = new CourseScheduleDFS();
        int[][] prereq = {
            new []{1,0},
            new []{0,1}
        };
        Assert.False(solver.CanFinish(2, prereq));
    }

    [Fact]
    public void SingleCourse_ReturnsTrue()
    {
        var solver = new CourseScheduleDFS();
        Assert.True(solver.CanFinish(1, Array.Empty<int[]>()));
    }
}

public class CourseScheduleTests
{
    [Fact]
    public void NoCycle_ReturnsTrue()
    {
        var solver = new CourseSchedule();
        int[][] prereq = {
            new []{1,0},
            new []{2,1},
            new []{3,2}
        };
        Assert.True(solver.CanFinish(4, prereq));
    }

    [Fact]
    public void HasCycle_ReturnsFalse()
    {
        var solver = new CourseSchedule();
        int[][] prereq = {
            new []{1,0},
            new []{0,1}
        };
        Assert.False(solver.CanFinish(2, prereq));
    }

    [Fact]
    public void NoPrerequisites_ReturnsTrue()
    {
        var solver = new CourseSchedule();
        Assert.True(solver.CanFinish(3, Array.Empty<int[]>()));
    }

    [Fact]
    public void SingleCourse_ReturnsTrue()
    {
        var solver = new CourseSchedule();
        Assert.True(solver.CanFinish(1, Array.Empty<int[]>()));
    }
}