int hIndex(int* citations, int citationsSize) {
    int* bucket = (int*)calloc(citationsSize+1, sizeof(int));
    for(int i = 0; i < citationsSize; i++)
        bucket[citations[i] >= citationsSize? citationsSize : citations[i]]++;

    int cptH = 0;
    for(int j = citationsSize; j >= 0; j--){
        cptH += bucket[j];
        if(cptH>=j) return j;
    }
    return 0;
}