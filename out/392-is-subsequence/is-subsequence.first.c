bool isSubsequence(char* s, char* t) {
    int sLen = strlen(s);
    int cptS = 0;

    int tLen = strlen(t);
    for(int i = 0; i < tLen; i++){
        if(s[cptS] == t[i]) cptS++;
        if(cptS == sLen) return true;
    }
    return false || sLen == 0;
}