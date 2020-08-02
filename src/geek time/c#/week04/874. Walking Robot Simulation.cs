using System;
using System.Collections.Generic;

namespace week04 {
    public partial class Solution {
        public int RobotSim(int[] commands, int[][] obstacles) {
            if (commands == null || commands.Length == 0) return 0;
            var x = 0; var y = 0; var direction = 0; var ans = 0;
            var obstacleSet = new HashSet<string>();
            foreach(var obstacle in obstacles) 
                obstacleSet.Add($"{obstacle[0]}_{obstacle[1]}");
            foreach(var command in commands) {
                if (command < 0) {
                    direction = GetDirection(command, direction);
                    continue;
                }
                var step = command;
                while (step-- > 0) {
                    var newPosition = GetNewPosition(direction, x, y);
                    if (!obstacleSet.Contains($"{newPosition.Item1}_{newPosition.Item2}")) {
                        x = newPosition.Item1;
                        y = newPosition.Item2;
                        ans = Math.Max(ans, x * x + y * y);
                    }
                }
            }
            return ans;
        }
        private int GetDirection(int command, int pre) {
            if (command == -1)
                pre += 1; 
            else if (command == -2)
                pre += 3;
            return pre % 4;
        }
        private (int, int) GetNewPosition(int direction, int x, int y) {
            if (direction == 0)
                y += 1;
            else if (direction == 1)
                x += 1;
            else if (direction == 2)
                y -= 1;
            else 
                x -= 1;
            return (x, y);
        }
    }   
}