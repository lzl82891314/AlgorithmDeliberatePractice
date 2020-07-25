export class TreeNode {
    public val: number;
    public left: TreeNode;
    public right: TreeNode;
    constructor(val: number) {
        this.val = val;
        this.left = null;
        this.right = null;
    }
}

function minDepth(root: TreeNode | null): number {
    if (!root) return 0;
    return recursiveFind(root, 1) + 1;
}

function recursiveFind(root: TreeNode | null, level: number): number {
    if (!root) return level - 1;
    if (!root.left && !root.right) return level - 1;
    let left = 2147483647;
    if (root.left) left = recursiveFind(root.left, level + 1);
    let right = 2147483647;
    if (root.right) right = recursiveFind(root.right, level + 1);
    return Math.min(left, right);
}
