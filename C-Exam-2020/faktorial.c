//
//  main.c
//  Ukol-2
//
//  Created by Filip Vabroušek on 01/04/2020.
//  Copyright © 2020 Filip Vabroušek. All rights reserved.
//


#include <stdio.h>

int fakt_rekt(int number){
    if (number < 0){
        return 0;
    }
    
    if (number == 0 || number == 1){
        return 1;
    }
    
    return number * fakt_rekt(number - 1);
}


int main(int argc, const char * argv[]) {
    int res = fakt_rekt(3);
    printf("%d", res);
}
