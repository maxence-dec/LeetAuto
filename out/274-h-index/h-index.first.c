void pushSort(int* citations, int idxAt, int* hLimAt){
    for(int idx = 0; idx <= *hLimAt; idx++){
        if(citations[idx] < citations[idxAt]){
            int tempo = citations[idx];
            citations[idx] = citations[idxAt];
            citations[idxAt] = tempo;
        }
    }
    if(citations[*hLimAt] > *hLimAt)
        (*hLimAt)++;

    return;
}

int hIndex(int* citations, int citationsSize) {
    int hLim = 0;

    for(int idx = 0; idx < citationsSize; idx ++){
        if(citations[idx] > hLim) pushSort(citations, idx, &hLim);
    }
    return hLim;
}