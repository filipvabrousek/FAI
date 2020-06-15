//
//  main.c
//  Ukol-2
//
//  Created by Filip Vabroušek on 01/04/2020.
//  Copyright © 2020 Filip Vabroušek. All rights reserved.
//


#include <stdio.h>

int main(int argc, const char * argv[]) {
    
    char s[1000];
       int c=0,j;
       printf("Enter string: ");
       gets(s);
    
       for(j = 0; s[j] != '\0'; j++) {
           if(s[j]=='0' || s[j]=='1'|| s[j]=='2'||
           s[j]=='3'|| s[j]=='4'|| s[j]=='5'||
              s[j]=='6'|| s[j]=='7'|| s[j]=='8'|| s[j]=='9'){
                c++;
           }
       }
    
       printf("\nNumber of digits in string = %d", c);
}
