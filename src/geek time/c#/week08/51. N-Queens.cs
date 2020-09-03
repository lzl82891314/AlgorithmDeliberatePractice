using System;
using System.Collections.Generic;
using System.Text;

namespace week08 {
    public partial class Solution {
        public IList<IList<string>> SolveNQueens(int n) {
            var ans = new List<IList<string>>();
            if (n <= 0) return ans;
            var columnHash = new HashSet<int>();
            var obliqueLeftHash = new HashSet<int>();
            var obliqueRightHash = new HashSet<int>();
            var queens = new int[n];
            Array.Fill(queens, -1);
            Backtracking(0, n, columnHash, obliqueLeftHash, obliqueRightHash, queens, ans);
            return ans;
        }
        private bool IsValid(int row, int column, HashSet<int> columnHash, HashSet<int> obliqueLeftHash, HashSet<int> obliqueRightHash) {
            // 判断列
            if (columnHash.Contains(column)) return false;
            // 判断斜线（方法：通过横纵坐标计算和差分别获得两个斜线值）
            if (obliqueLeftHash.Contains(row - column)) return false;
            if (obliqueRightHash.Contains(row + column)) return false;
            return true;
        }
        private void TrySolve(int row, int column, HashSet<int> columnHash, HashSet<int> obliqueLeftHash, HashSet<int> obliqueRightHash, int[] queens) {
            columnHash.Add(column);
            obliqueLeftHash.Add(row - column);
            obliqueRightHash.Add(row + column);
            queens[row] = column;
        }
        private void RestoreStatus(int row, int column, HashSet<int> columnHash, HashSet<int> obliqueLeftHash, HashSet<int> obliqueRightHash, int[] queens) {
            columnHash.Remove(column);
            obliqueLeftHash.Remove(row - column);
            obliqueRightHash.Remove(row + column);
            queens[row] = -1;
        }
        private void Backtracking(int row, int n, HashSet<int> columnHash, HashSet<int> obliqueLeftHash, HashSet<int> obliqueRightHash, int[] queens, IList<IList<string>> ans) {
            if (row == n) {
                ans.Add(GenerateBoard(queens));
                return;
            }
            for (var column = 0; column < n; column++) {
                if (IsValid(row, column, columnHash, obliqueLeftHash, obliqueRightHash)) {
                    TrySolve(row, column, columnHash, obliqueLeftHash, obliqueRightHash, queens);
                    Backtracking(row + 1, n, columnHash, obliqueLeftHash, obliqueRightHash, queens, ans);
                    RestoreStatus(row, column, columnHash, obliqueLeftHash, obliqueRightHash, queens);
                }
            }
        }
        private IList<string> GenerateBoard(int[] queens) {
            var list = new List<string>();
            for (var i = 0; i < queens.Length; i++) {
                var cur = string.Empty;
                for (var j = 0; j < queens.Length; j++) {
                    cur += queens[i] == j ? "Q" : ".";
                }
                list.Add(cur);
            }
            return list;
        }
    }
}
