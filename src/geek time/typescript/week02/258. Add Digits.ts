function addDigits(num: number): number {
    if (num < 10) {
        return num;
    }
    let next = 0;
    while (num != 0) {
        next += num % 10;
        num /= 10;
    }
    return addDigits(next);
}

function addDigits_v2(num: number): number {
    return ((num - 1) % 9) + 1;
}
