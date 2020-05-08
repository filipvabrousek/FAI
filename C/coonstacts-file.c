//
//  main.c
//  C-Task-02-05-20
//
//  Created by Filip Vabroušek on 01/05/2020.
//  Copyright © 2020 Filip Vabroušek. All rights reserved.
//

#include <stdio.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

 int len = 1;

static char data[][100] = {
    "Filip-Vabrousek-126157162",
    "Karel-Sykora-12839282",
    "Tereza-Barosova-87651429"
};

struct contact
{
    char name[30];
    char surname[50];
    char number[10];
};

void addContact(){
       char name[30];
       char surname[50];
       char phone[10];
       char entireContact[90];
    
       printf("\nEnter name: ");
       scanf("%s", name);
       
       printf("Enter surname: ");
       scanf("%s", surname);
       
       printf("Enter number: ");
       scanf("%s", phone);
       
       strcpy(entireContact, name);
       strcat(entireContact, ",");
       strcat(entireContact, surname);
       strcat(entireContact, ",");
       strcat(entireContact, phone);
     
       int newContactLen = sizeof(entireContact) / sizeof(entireContact[0]);
       printf("\n"); // MAKE SPACE :)
       
       // fill 2D data array
       for (int i = 0; i < newContactLen; i++) {
           data[len][i] = entireContact[i];
       }
        
       len += 1; // MAKE SPACE FOR OTHER ELEMENTS
}



// List contacts
void listContacts(char data[][100], int len) {
    for (int i = 0; i < len; i++) {
        printf("%s\n", data[i]);
    }
}


void loadDataToFile(char data[][100], int len){
    printf("I am creating text file with contents of the PhoneBook.");
    
    
    // 1 - ZADÁNÍ CESTY K SOUBORU
    printf("Zadejte cestu k souboru.");
    char name[20];
    scanf("%s", &name);
    
    // 2 - VYTVOŘENÍ SOUBORU
    FILE *fptr;
    fptr = fopen(name,"w");

    // 3 - CHYBA PŘI VYTVÁŘENÍ SOUBORU
    if(fptr == NULL) {
       printf("Error in file creation.");
       exit(1);
    }
     
    // 4 - ZÁPIS DAT DO SOUBORU
    for (int i = 0; i < len; i++) {
        fprintf(fptr,"%s\n",data[i]);
    }
    
    
    fclose(fptr);
}



void openFile(/*char name[][100]*/){
    
    char string[300];
    
    // 1 - ZADÁNÍ NÁZVU SOUBORU
      printf("Zadejte cestu k souboru.");
      char name[300];
      scanf("%s", &name);
    
    // 2 -
    FILE *fptr;

      if ((fptr = fopen(name,"r")) == NULL){
          printf("Error! opening file");
          // Program exits if the file pointer returns NULL.
          exit(1);
      }

      fscanf(fptr,"%s", &name);
    printf("%s", name);
    
    
    
    
    
}





// Search by name or surname
void searchByNameOrSurname(char data[][100], int len) {
    char name[50];
    char ch;
    
    printf("\n Search by name (N)");
    printf("\n Search by surname (S)");
    printf("\n");
    
    scanf("\n%c", &ch);
        
        if (ch == 'N') {
               printf("Enter searched name: ");
               scanf("%s", name);
           
               for (int i = 0; i < len; i++) {
                   int temp = i;
                   int iterator = 0;
                   char tempn[30] = {0};
                  
               
                   for (int y = 0; y <= 30; y++) {
                       if (data[i][y] == '-') { // VALUE AFTER FIRST "-"
                           break;
                       } else {
                           tempn[iterator] = data[i][y];
                           iterator++;
                       }
                   }
               
                   int result = strcmp(name, tempn); // STRCMP WILL RETURN 0 IF STRINGS ARE EQUAL
               
                   if (result == 0) {
                       printf("\n%s", data[temp]); // GET DATA FROM ORIGINAL ARRAY AT INDEX "TEMP"
                       break; // IF STRINGS ARE EQUAL, STOPS THE LOOP
                   }
               }
           } else if (ch == 'S') {
               printf("Enter searched surname: ");
               scanf("%s", name);
               
               for (int i = 0; i < len; i++) {
                   int it = 0;
                   int separator = 0;
                   char tempS[50] = {0};
                   int tmpIndex = i;
                  
               
                   for (int y = 0; y <= 85; y++) { // VALUE AFTER SECOND "-"
                       if (data[i][y] == '-') {
                           separator += 1;
                           continue;
                       }
                       
                       if (separator == 1) {
                           tempS[it] = data[i][y];
                           it++;
                       } else if (separator == 2) { break; }
                   }
               
     
                   int result = strcmp(name, tempS); // STRCMP WILL RETURN 0 IF STRINGS ARE EQUAL
               
                   if (result == 0) {
                       printf("\n%s", data[tmpIndex]); // GET DATA FROM ORIGINAL ARRAY AT INDEX "TEMP"
                       break; // IF STRINGS ARE EQUAL, STOP THE LOOP
                   }
               }
           } else {
               printf("INVALID INPUT.");
           }
}





int main(int argc, const char * argv[]) {
     printf("Menu \n");
     printf("Zadejte příkazy: \n");
    
     printf("p - pridej \n");
     printf("v - vypis \n");
     printf("h - hledej \n");
     printf("k - konec \n");
     printf("C - vytvor textovy soubor \n");
     printf("R - precti textovy soubor");
    
    char task;
    scanf(" %c", &task);
    
    if (task == 'v') {
        int len = sizeof(data) / sizeof(data[0]);
        listContacts(data, len);
    } else if (task == 'k'){
        printf("The PhoneBook was closed");
    } else if (task == 'p') {
        printf("ADDING USER");
        addContact();
    } else if (task == 'h'){
       int len = sizeof(data) / sizeof(data[0]);
       searchByNameOrSurname(data, len);
    } else if (task == 'C'){
        int len = sizeof(data) / sizeof(data[0]);
        loadDataToFile(data, len);
    } else if (task == 'R'){
        openFile();
    } else {
        printf("Invalid input. Only 'v', 'k', 'p' 'h' and 'C' are allowed.");
    }
    return 0;
}
