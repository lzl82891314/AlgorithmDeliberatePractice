using common;
using System;
using System.Collections;
using System.Collections.Generic;
using week04;
using week07;
using static week03.Solution;

namespace startup {
    class Program {
        static void Main(string[] args) {
            // Week01();
            // Week02();
            // Week03();
            // Week04();
            // Week05();
            // Week06();
            Week07();
            // Week08();
        }

        static void Week01() {
            var foo = new week01.Solution();

            // 15. 3Sum
            foo.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 }).Show();

            // 70. Climbing Stairs
            foo.ClimbingStairs(10).Show();

            // 24. Swap Nodes in Pairs
            var node = new ListNode("[1,2,3,4]");
            node.Show();
            foo.SwapPairs(node).Show();

            // 66. Plus One
            var pre = new int[] { 9, 9, 9, 9 };
            pre.Show<int>();
            foo.PlusOne(pre).Show<int>();

            // 283. Move Zeroes
            var movePre = new int[] { 0, 1, 0, 3, 12 };
            movePre.Show<int>();
            foo.MoveZeroes(movePre);
            movePre.Show<int>();

            // 11. Container With Most Water
            foo.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }).Show();

            // 21. Merge Two Sorted Lists
            var l1 = new ListNode("[1,2,4]");
            var l2 = new ListNode("[1,3,4]");
            l1.Show();
            l2.Show();
            foo.MergeTwoLists(l1, l2).Show();

            // 206. Reverse Linked List
            var p = new ListNode("[1,2,3,4,5]");
            p.Show();
            foo.ReverseList(p).Show();

            // 141. Linked List Cycle
            var pp = new ListNode();
            pp.next = pp;
            foo.HasCycle(pp).Show();

            // 142. Linked List Cycle II
            foo.DetectCycle(pp);

            // 25. Reverse Nodes in k-Group
            var ppp = new ListNode("[1,2]");
            foo.ReverseKGroup(ppp, 2).Show();

            // 315. Count of Smaller Numbers After Self
            var arr = new int[] { 5, 2, 6, 1 };
            foo.CountSmaller(arr).Show();

            // 941. Valid Mountain Array
            foo.ValidMountainArray(new int[] { 0, 3, 2, 1 }).Show();

            // 299. Bulls and Cows
            foo.GetHint("1123", "0111").Show();
        }

        static void Week02() {
            var foo = new week02.Solution();
            // 239. Sliding Window Maximum
            // foo.MaxSlidingWindow(new int[] { 1, -1 }, 1).Show<int>();

            // 49. Group Anagrams
            foo.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        }

        static void Week03() {
            var foo = new week03.Solution();

            // 98. Validate Binary Search Tree
            var tree = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            foo.IsValidBST(tree).Show();

            // 111. Minimum Depth of Binary Tree
            var tree_111 = new TreeNode(1, new TreeNode(2));
            foo.MinDepth(tree_111).Show();

            // 18. 4Sum
            foo.FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);

            // 297. Serialize and Deserialize Binary Tree
            foo.Serialize(new TreeNode(1, new TreeNode(2), new TreeNode(3, new TreeNode(4), new TreeNode(5)))).Show();

            // 77. Combinations
            foo.Combine(4, 2).Show();

            // 46. Permutations
            foo.Permute(new int[] { 1, 2, 3 }).Show();

            // 47. Permutations II
            foo.PermuteUnique(new int[] { 1, 1, 2 }).Show();

            // 17. Letter Combinations of a Phone Number
            foo.LetterCombinations("23").Show();
        }

        static void Week04() {
            var foo = new week04.Solution();

            // 367. Valid Perfect Square
            foo.IsPerfectSquare(1024).Show();

            // 寻找部分有序数组的分界点
            foo.FindIndex(new int[] { 3, 4, 5, 1, 2 }).Show();

            // 127. Word Ladder
            foo.LadderLength("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }).Show();

            // 74. Search a 2D Matrix
            var matrix = new int[][] {
                new int [] {1, 3, 5, 7},
                new int [] {10, 11, 16, 20},
                new int [] {23, 30, 34, 50}
            };
            foo.SearchMatrix(matrix, 3).Show();

            // 153. Find Minimum in Rotated Sorted Array
            foo.FindMin(new int[] { 1 }).Show();

            // 529. Minesweeper
            var board = new char[][] {
                new char[] {'E', 'E', 'E', 'E', 'E' },
                new char[] {'E', 'E', 'M', 'E', 'E' },
                new char[] {'E', 'E', 'E', 'E', 'E' },
                new char[] {'E', 'E', 'E', 'E', 'E' },
            };
            var click = new int[] { 3, 0 };
            var result = foo.UpdateBoard(board, click);
            result.Show<char[]>();

            // 126. Word Ladder II
            // foo.FindLadders("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" }).Show();
            new CodeBySlef().FindLadders("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log" }).Show();
        }

        static void Week05() {
            var foo = new week05.Solution();
            foo.LongestCommonSubsequence("oxcpqrsvwf", "shmtulqrypy").Show();
        }

        static void Week06() {
            var foo = new week06.Solution();
            // 322. Coin Change
            foo.CoinChange(new int[] { 1, 2, 5 }, 11).Show();

            // 1143. Longest Common Subsequence
            foo.LongestCommonSubsequence("bl", "yby").Show();

            // 剑指 Offer 19. 正则表达式匹配
            //foo.IsMatch("aaa", "ab*ac*a").Show();
            //foo.IsMatch("aa", "a").Show();
            //foo.IsMatch("aa", "a*").Show();
            //foo.IsMatch("aa", ".*").Show();
            //foo.IsMatch("aab", "c*a*b").Show();
            // foo.IsMatch("mississippi", "mis*is*p*.").Show();

            // 213. House Robber II
            foo.Rob_II(new int[] { 2, 7, 9, 3, 1 });

            // 152. Maximum Product Subarray
            foo.MaxProduct(new int[] { 2, 3, -2, 4 }).Show();

            // 363. Max Sum of Rectangle No Larger Than K
            //var input = new int[][] {
            //    new int[] { -1, 0, 3 },
            //    new int[] { 3, 3, -4 }
            //};
            var input = new int[][] {
                new int[] { 2, 2, -1 },
            };
            foo.MaxSumSubmatrix(input, 0).Show();

            // 221. Maximal Square
            var charArr = new char[][] {
               new char[] { '0', '0', '0', '1' },
               new char[] { '1', '1', '0', '1' },
               new char[] { '1', '1', '1', '1' },
               new char[] { '0', '1', '1', '1' },
               new char[] { '0', '1', '1', '1' },
            };
            foo.MaximalSquare(charArr).Show();
        }

        static void Week07() {
            var foo = new week07.Solution();

            // 212. Word Search II
            var board = new char[2][] {
                new char[] { 'a', 'b'},
                new char[] { 'a', 'a' }
            };
            foo.FindWords(board, new string[] { "aba", "baa", "bab", "aaab", "aaa", "aaaa", "aaba" }).Show();

            // 127.Word Ladder
            foo.LadderLength("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log" });

            // 130. Surrounded Regions
            var board_130 = new char[][] {
                new char[] { 'X', 'O', 'X', 'X' },
                new char[] { 'O', 'X', 'O', 'X' },
                new char[] { 'X', 'O', 'X', 'O' },
                new char[] { 'O', 'X', 'O', 'X' },
                new char[] { 'X', 'O', 'X', 'O' },
                new char[] { 'O', 'X', 'O', 'X' },
            };
            foo.Solve(board_130);
            foo.Solve_UnionFind(board_130);

            // 126. Word Ladder II
            var testData = new List<string>() {
                "flail", "halon", "lexus", "joint", "pears", "slabs", "lorie", "lapse", "wroth", "yalow", "swear",
                "cavil", "piety", "yogis", "dhaka", "laxer", "tatum", "provo", "truss", "tends", "deana", "dried",
                "hutch", "basho", "flyby", "miler", "fries", "floes", "lingo", "wider", "scary", "marks", "perry",
                "igloo", "melts", "lanny", "satan", "foamy", "perks", "denim", "plugs", "cloak", "cyril", "women",
                "issue", "rocky", "marry", "trash", "merry", "topic", "hicks", "dicky", "prado", "casio", "lapel",
                "diane", "serer", "paige", "parry", "elope", "balds", "dated", "copra", "earth", "marty", "slake",
                "balms", "daryl", "loves", "civet", "sweat", "daley", "touch", "maria", "dacca", "muggy", "chore",
                "felix", "ogled", "acids", "terse", "cults", "darla", "snubs", "boats", "recta", "cohan", "purse",
                "joist", "grosz", "sheri", "steam", "manic", "luisa", "gluts", "spits", "boxer", "abner", "cooke",
                "scowl", "kenya", "hasps", "roger", "edwin", "black", "terns", "folks", "demur", "dingo", "party",
                "brian", "numbs", "forgo", "gunny", "waled", "bucks", "titan", "ruffs", "pizza", "ravel", "poole",
                "suits", "stoic", "segre", "white", "lemur", "belts", "scums", "parks", "gusts", "ozark", "umped",
                "heard", "lorna", "emile", "orbit", "onset", "cruet", "amiss", "fumed", "gelds", "italy", "rakes",
                "loxed", "kilts", "mania", "tombs", "gaped", "merge", "molar", "smith", "tangs", "misty", "wefts",
                "yawns", "smile", "scuff", "width", "paris", "coded", "sodom", "shits", "benny", "pudgy", "mayer",
                "peary", "curve", "tulsa", "ramos", "thick", "dogie", "gourd", "strop", "ahmad", "clove", "tract",
                "calyx", "maris", "wants", "lipid", "pearl", "maybe", "banjo", "south", "blend", "diana", "lanai",
                "waged", "shari", "magic", "duchy", "decca", "wried", "maine", "nutty", "turns", "satyr", "holds",
                "finks", "twits", "peaks", "teems", "peace", "melon", "czars", "robby", "tabby", "shove", "minty",
                "marta", "dregs", "lacks", "casts", "aruba", "stall", "nurse", "jewry", "knuth"
            };
            // foo.FindLadders_DoubleEndedBFS("magic", "pearl", testData);
            // foo.FindLadders_DoubleEndedBFS("a", "c", new string[] { "a", "b", "c" });
            // foo.FindLadders_DoubleEndedBFS("sand", "acne", TestData.GetData_126());

            // 433. Minimum Genetic Mutation
            foo.MinMutation("AACCTTGG", "AATTCCGG", new string[] { "AATTCCGG", "AACCTGGG", "AACCCCGG", "AACCTACC" });
        }

        static void Week08() {
            var foo = new week08.Solution();
            // 51. N-Queens
            foo.SolveNQueens(8)?.Show();

            // 491. Increasing Subsequences
            foo.FindSubsequences(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 1, 1, 1, 1 });
        }
    }
}