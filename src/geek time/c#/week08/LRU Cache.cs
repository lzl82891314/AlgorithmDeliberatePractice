using System;
using System.Collections.Generic;

namespace week08 {
    public class LRU_Cache {
        private Dictionary<int, Node> cache;
        private Node dummyHead;
        private Node dummyTail;
        private int size;
        private int capacity;

        public LRU_Cache(int capacity) {
            this.capacity = capacity;
            this.dummyHead = new Node();
            this.dummyTail = new Node();
            this.dummyHead.next = this.dummyTail;
            this.dummyTail.pre = this.dummyHead;
            this.cache = new Dictionary<int, Node>();
        }

        public int Get(int key) {
            if (!this.cache.ContainsKey(key)) return -1;
            var node = this.cache[key];
            MoveToHead(node);
            return node.val;
        }
    
        public void Put(int key, int value) {
            if (this.cache.ContainsKey(key)) {
                this.cache[key].val = value;
                MoveToHead(this.cache[key]);
                return;
            }
            AddToHead(new Node(key, value));
        }

        private void MoveToHead(Node node) {
            node.pre.next = node.next;
            node.next.pre = node.pre;
            node.pre = this.dummyHead;
            node.next = this.dummyHead.next;
            this.dummyHead.next.pre = node;
            this.dummyHead.next = node;
        }

        private void AddToHead(Node node) {
            node.pre = this.dummyHead;
            node.next = this.dummyHead.next;
            this.dummyHead.next.pre = node;
            this.dummyHead.next = node;
            this.cache.Add(node.key, node);
            if (this.size == this.capacity) RemoveTail();
            this.size++;
        }

        private void RemoveTail() {
            var node = this.dummyTail.pre;
            this.dummyTail.pre = node.pre;
            node.pre.next = this.dummyTail;
            this.cache.Remove(node.key);
            this.size--;
        }
    }

    public class Node {
        public Node pre;
        public Node next;
        public int key;
        public int val;

        public Node() {}

        public Node(int key, int value) {
            this.key = key;
            this.val = value;
        }
    }
}