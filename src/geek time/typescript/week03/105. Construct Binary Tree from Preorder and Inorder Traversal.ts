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

function buildTree(preorder: number[], inorder: number[]): TreeNode | null {
    // 此问题最终其实是转化成为了下标计算的问题
    // 明确可以获取到的坐标为：
    // 1. preorder_root
    // 2. inorder_root
    // 3. left_children_tree_length
    // 4. right_children_tree_start
    const hashMap = new Map<number, number>();
    for (let i = 0; i < inorder.length; i++) {
        hashMap.set(inorder[i], i);
    }
    return myBuildTree(preorder, inorder, 0, preorder.length - 1, 0, inorder.length - 1, hashMap);
}

function myBuildTree(
    preorder: number[],
    inorder: number[],
    p_start: number,
    p_end: number,
    i_start: number,
    i_end: number,
    hashMap: Map<number, number>
): TreeNode | null {
    if (p_start > p_end) return null;
    const rootValue = preorder[p_start];
    const i_root = hashMap.get(rootValue);
    const left_children_tree_length: number = i_root - i_start;
    const tree: TreeNode = new TreeNode(rootValue);
    const left = myBuildTree(preorder, inorder, p_start + 1, p_start + left_children_tree_length, i_start, i_root - 1, hashMap);
    const right = myBuildTree(preorder, inorder, p_start + left_children_tree_length + 1, p_end, i_root + 1, i_end, hashMap);
    tree.left = left;
    tree.right = right;
    return tree;
}
