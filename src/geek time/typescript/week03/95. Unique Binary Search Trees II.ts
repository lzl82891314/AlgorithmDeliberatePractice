export class TreeNode {
    val: number;
    left: TreeNode | null;
    right: TreeNode | null;
    constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
        this.val = val === undefined ? 0 : val;
        this.left = left === undefined ? null : left;
        this.right = right === undefined ? null : right;
    }
}

export function generateTrees(n: number): Array<TreeNode | null> {
    if (!n) return [];
    return recursiveGenerate(1, n);
}
function recursiveGenerate(start: number, end: number): TreeNode[] {
    const ans: TreeNode[] = [];
    if (start > end) {
        ans.push(null);
        return ans;
    }
    for (let i = start; i <= end; i++) {
        const leftTrees = recursiveGenerate(start, i - 1);
        const rightTrees = recursiveGenerate(i + 1, end);
        leftTrees.forEach((left) => {
            rightTrees.forEach((right) => {
                const tree = new TreeNode(i);
                tree.left = left;
                tree.right = right;
                ans.push(tree);
            });
        });
    }
    return ans;
}
