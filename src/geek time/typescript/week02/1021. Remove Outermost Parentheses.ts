function removeOuterParentheses(S: string): string {
    let level = 0;
    let result = '';
    for (let i = 0; i < S.length; i++) {
        const c = S[i];
        if (c === ')') {
            level--;
        }
        if (level > 0) {
            result += c;
        }
        if (c === '(') {
            level++;
        }
    }
    return result;
}
