int lengthOfLongestSubstring(char* s) {
    int wr = 0;
    int maxLenWin = 0;

    short alphabet[256];
    for(short i = 0; i < 256; i++){ alphabet[i] = -1; }

    for(int wl = 0; wl < strlen(s); wl++){

        if(alphabet[s[wl]] >= wr)
            wr = alphabet[s[wl]]+1;

        alphabet[s[wl]] = wl;

        if(wl-wr+1 > maxLenWin)
            maxLenWin = wl-wr+1;
    }
    return maxLenWin;
}