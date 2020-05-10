//
//  Min.c
//  C-Task-4
//
//  Created by Filip Vabroušek on 22/04/2020.
//  Copyright © 2020 Filip Vabroušek. All rights reserved.
//

#include "Min.h"
#include <stdbool.h>

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
