#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#define ARRAY_LEN (0x100)
#define OUTPUT_LEN (0x400)

unsigned int StaticAnalyze_load( char* data, char delimiter, int* array, unsigned int length ){
    char *token = data;
    int i=0;

    while( i < ARRAY_LEN && token != NULL ) {
        array[i] = atoi(token);
        token = strchr(token, delimiter);
        if (token) {
            ++token;
        }
        i++;
    }
    return length;
}

int main(int argc, const char * argv[]) {
    char *data =  "13,654,24,48,1,79,14456,-13,654,13,46,465,0,65,16,54,1,67,4,6,74,165,"
       "4,-654,616,51,654,1,654,654,-61,654647,67,13,45,1,54,2,15,15,47,1,54";
    int array[ARRAY_LEN]; // array, I need to fill-in with integers from the string above
    unsigned int loaded = StaticAnalyze_load(data, ',', array, ARRAY_LEN);
    
    if (loaded > 0){
        printf("Element at index 2 is %d", array[2]);
    }
    
    return 0;
}
