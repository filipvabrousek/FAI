//
//  staticAnalyze.c
//  C-Task-4-correction
//
//  Created by Filip Vabroušek on 10/05/2020.
//  Copyright © 2020 Filip Vabroušek. All rights reserved.
//

#include "staticAnalyze.h"

float deviation(const int * array, unsigned int length){
    if (array == NULL || length == NULL) {
          return 0;
      }
    
    // Standard Deviation
    float sum = 0.0;
    float avg = 0.0;
    float diff = 0.0;
    
    
    // CALCULATE AVERAGE
    for (int i = 0; i < length; i++){
        sum += array[i];
    }
    
    
   
    
    printf("LENGHT (43) [%d]", length);
    
    
    avg = sum / 43;
    
     // CALCULATE DEVIATION
    for (int i = 0; i < length; i++){
        float d = (array[i] - avg) * (array[i] - avg);
        diff += d;
    }
    
    float reso = sqrtf(diff / (length - 1));
    return reso;
}

float average(const int * array, unsigned int length){
// INPUT PARAMETER SAFETY CHECK
if (array == NULL || length == NULL) {
    return 0;
}
    
float sum = 0.0;
for (int i = 0; i < length; i++){
    sum += array[i];
}
return sum / length;
}

void StaticAnalyze_process(const int *input, unsigned int length, char *output, unsigned int outputLen) {
    
     int min = getMin(input, length);
     printf("%d \n", min);
    
  //  int min = getMin(input, length);
   // printf("%d", min);
  /*
    int min = getMin(input, length);
    int max = getMax(input, length);
    double dev = deviation(input, length);
    double avg = average(input, length);
    
    char smin[15];
    sprintf(smin, "%d", min);
    
    char smax[15];
    sprintf(smax, "%d", max);
    

    char sdev[15];
    // VÝPIS VE VĚDECKÉM FORMÁTU POMOCÍ %e
    sprintf(sdev, "%e", dev);

    char savg[15];
    // VÝPIS VE VĚDECKÉM FORMÁTU POMOCÍ %e
    sprintf(savg, "%e", avg);
   
    strcpy(output, "\n AVERAGE:");
    strcat(output, savg);
    
    strcat(output, "\n MIN:");
    strcat(output, smin);
    
    strcat(output, "\n MAX:");
    strcat(output, smax);
    strcat(output, "\n Standard deviation is:");
    strcat(output, sdev);
    strcat(output, "\n"); // space after last line for formatting
    
    int lenOfOutput = strlen(output);
    outputLen = &lenOfOutput;*/
}
