//
//  main.c
//  Ukol-2
//
//  Created by Filip Vabroušek on 01/04/2020.
//  Copyright © 2020 Filip Vabroušek. All rights reserved.
//


#include <stdio.h>

int getMax(const int * array, unsigned int length){
    // INPUT PARAMETER SAFETY CHECK
    if (length <= 0 || array == NULL) { return false; }
    int min = array[0];
   
    // GET MAXIMUM VALUE
    for (int i = 0; i < length; i++){
        if (min < array[i]){
            min = array[i];
        }
    }
    return min;
}


int getMin(const int * array, unsigned int length){
   // INPUT PARAMETER SAFETY CHECK
    if (length <= 0 || array == NULL) { return false; }
    int max = array[0];
   
  // GET MAXIMUM VALUE
    for (int i = 0; i < length; i++){
        if (max > array[i]){
            max = array[i];
        }
    }
    return max;
}

int main(int argc, const char * argv[]) {
    int res = fakt_rekt(3);
    printf("%d", res);
    
    
    int min = getMin(input, length);
        printf("%d \n", min);
}
