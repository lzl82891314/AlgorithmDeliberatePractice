export function maxArea(height: number[]): number {
    let i = 0;
    let j = height.length - 1;
    let max = 0;
    while (i < j) {
        let minHeight = height[i] < height[j] ? height[i++] : height[j--];
        max = Math.max(max, (j - i + 1) * minHeight);
    }
    return max;
}
