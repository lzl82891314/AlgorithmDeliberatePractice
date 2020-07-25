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
function lowestCommonAncestor(root: TreeNode, p: TreeNode, q: TreeNode): TreeNode {
    if (!root || root === p || root === q) return root;
    const left = lowestCommonAncestor(root.left, p, q);
    const right = lowestCommonAncestor(root.right, p, q);
    return left !== null ? (right !== null ? root : left) : right;
}
