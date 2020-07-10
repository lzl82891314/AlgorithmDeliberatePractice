function climbStairs(n: number): number {
    if (n < 3) {
        return n;
    }

    let f1 = 1;
    let f2 = 2;
    for (let i = 3; i <= n; i++) {
        f2 += f1;
        f1 = f2 - f1;
    }
    return f2;
}

console.log(climbStairs(10));