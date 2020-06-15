//
//  main.c
//  Ukol-2
//
//  Created by Filip Vabroušek on 01/04/2020.
//  Copyright © 2020 Filip Vabroušek. All rights reserved.
//

#include <stdio.h>


float average(float array[], unsigned int length) {
    float total = 0.0;
    
    for (int i = 0; i < length; i++){
        total = total + array[i];
    }
    
    float avg = total / length;
    return avg;
}


void reverse(int* array, int size){
    for (int i = 0; i < (size / 2); i++){
        int swap = array[size - 1 - i];
        array[size - 1 - i] = array[i];
        array[i] = swap;
    }
}

void printArray(int array[], int size) {
    for (int i = 0; i < size; i++) {
        printf("%u\n", array[i]);
    }
}


int main(int argc, const char * argv[]) {
    printf("------FLOATING AVERAGE--------m \n");
    float arr[3] = {1.0, 2.0, 3.0};

    float res = average(arr, 3);
    printf("Average: %.2f", res);
    
    
    int rev[3] = {1, 2, 3};
    
    printf("\n ------ORIGINAL ARRAY--------m \n");
    printArray(rev, 3);

    printf("-------REVERSED ARRAY-------m \n");
    reverse(rev, 3);
    printArray(rev, 3);
    
    return 0;
}
