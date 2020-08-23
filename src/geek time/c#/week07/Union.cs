using System;

namespace week07 {
    public class UnionFind {
        public int count = 0;
        private int[] parent;

        public UnionFind(int n) {
            count = n;
            parent = new int[n];
            for (int i = 0; i < parent.Length; i++)
                // 初始状态，所有的节点都指向自己
                parent[i] = i;
        }

        public int Find(int p) {
            // 只有指向自己的节点是父亲节点
            while (p != parent[p]) {
                // 此操作即找到了p的父亲节点，又将p向上合并至父亲的父亲节点，从而做到降低链表的长度             
                parent[p] = parent[parent[p]];
                p = parent[p];
            }
            return p;
        }

        public void Union(int p, int q) {
            // 合并两个节点即合并两个节点的父亲节点
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ) return;
            // 如果两个节点的父亲节点不同，则将其中随机的一个指向另一个即可
            parent[rootP] = rootQ;
            // 合并之后，并查集中的分支数量会减少
            count--;
        }
    }
}