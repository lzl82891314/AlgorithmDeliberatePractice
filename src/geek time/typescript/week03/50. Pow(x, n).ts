function myPow(x: number, n: number): number {
    // 分治法最终的时间复杂度是O(logN)
    if (n < 0) {
        n = -n;
        x = 1 / x;
    }
    return pow(x, n);
}

function pow(x: number, n: number): number {
    if (!n) return 1;
    const half = pow(x, n / 2);
    return n % 2 === 0 ? half * half : half * half * x;
}
