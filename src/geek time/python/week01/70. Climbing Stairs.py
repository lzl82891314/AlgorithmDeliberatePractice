def climbStairs(n: int) -> int :
    if n < 3:
        return n
    f1 = 1
    f2 = 2
    for i in range(3, n + 1):
        f2 += f1
        f1 = f2 - f1
    return f2

if __name__ == "__main__":
    print(climbStairs(10))