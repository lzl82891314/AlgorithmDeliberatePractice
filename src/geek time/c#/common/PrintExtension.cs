using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common {
    public static class PrintExtension {
        public static void Show(this object obj) {
            if (obj.IsSimpleType()) {
                Console.WriteLine(obj);
            }
        }

        public static void Show(this IList list) {
            Console.WriteLine(list.GetShowStr());
        }

        public static void Show<T>(this IList<T> list) {
            Console.WriteLine(list.GetShowStr());
        }

        public static void Show(this ListNode node) {
            Console.WriteLine(node.GetShowStr());
        }

        public static void Show(this int[,] list) {
            Console.WriteLine(list.GetShowStr());
        }

        public static string GetShowStr(this IList list) {
            StringBuilder s = new StringBuilder();
            foreach (var item in list) {
                s.Append($"{item}, ");
            }
            return $"[{s.ToString().TrimEnd(new char[] { ',', ' ' })}]";
        }

        public static string GetShowStr<T>(this IList<T> list) {
            StringBuilder s = new StringBuilder();
            foreach (T item in list) {
                if (item is IList) {
                    var innerList = item as IList;
                    s.Append($"{innerList.GetShowStr()}, ");
                } else {
                    s.Append($"{item}, ");
                }
            }
            return $"[{s.ToString().TrimEnd(new char[] { ',', ' ' })}]";
        }

        public static string GetShowStr(this ListNode node) {
            if (node == null) {
                return "[Null]";
            }
            StringBuilder s = new StringBuilder();
            var cur = node;
            while (cur != null) {
                s.Append($"{cur.val} -> ");
                cur = cur.next;
            }
            return $"[{s.ToString().TrimEnd(new char[] { '-', '>', ' ' })}]";
        }

        public static string GetShowStr(this int[,] list) {
            StringBuilder s = new StringBuilder();
            foreach (int item in list) {
                s.Append($"{item}, ");
            }
            return $"[{s.ToString().TrimEnd(new char[] { ',', ' ' })}]";
        }

        public static bool IsSimpleType<T>(this T obj) {
            var type = obj.GetType();
            if (type == typeof(int) || type == typeof(long) || type == typeof(byte) 
                || type == typeof(DateTime) || type == typeof(float) || type == typeof(double)
                || type == typeof(string) || type == typeof(bool)) {
                return true;
            }
            return false;
        }
    }
}
