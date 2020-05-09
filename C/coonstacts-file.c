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
#define MAX 4

/*---------------------------------------------VARIABLES DEFINITIONS---------------------------------------------*/

struct contact {
    char name[30];
    char surname[50];
    char number[10];
};

int length = 1;
struct contact arr_student[MAX] = {
    {"Filip", "Vabroušek", "280830702"}
};

/*---------------------------------------------LIST CONTACTS---------------------------------------------*/
void listContacts(struct contact data[], int len) {
    for (int i = 0; i < len; i++) {
        printf("NAME %s \n", data[i].name);
        printf("SURNAME %s \n", data[i].surname);
        printf("NUMBER %s \n", data[i].number);
        printf("%s", "-------------------------------------");
    }
}

/*---------------------------------------------ADD NEW CONTACT---------------------------------------------*/
void structureAdd() {
        int i = 1; //sizeof(arr_student) / sizeof(arr_student[0]);;
        printf("\nEnter details of student %d\n\n", i+1);
 
        printf("Enter name: ");
        scanf("%s", arr_student[i].name);
 
        printf("Enter surname: ");
        scanf("%s", &arr_student[i].surname);
 
        printf("Enter number: ");
        scanf("%s", &arr_student[i].number);
        printf("\n");
    
        // SHOW WHATS INISIDE AFTER ADDING
        int len = sizeof(arr_student) / sizeof(arr_student[0]);
        listContacts(arr_student, len);
}

/*---------------------------------------------READ FILE---------------------------------------------*/
void readFile(){
    FILE * fp;
    char * line = NULL;
    size_t len = 0;
    ssize_t read;

    
    
    
    
    fp = fopen("EPQA.txt", "r");
    if (fp == NULL)
        exit(EXIT_FAILURE);

    while ((read = getline(&line, &len, fp)) != -1) {
        printf("%s", line);
    }

    fclose(fp);
    if (line){
      free(line);
    }
    
    exit(EXIT_SUCCESS);
}


/*---------------------------------------------SAVE DATA TO THE FILE---------------------------------------------*/
void structuresToFile(struct contact data[], int len){
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
           fprintf(fptr,"%s\n",data[i].name);
           fprintf(fptr,"%s\n",data[i].surname);
           fprintf(fptr,"%s\n",data[i].number);
       }
       fclose(fptr);
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
     printf("C - create text file \n");
     printf("R - read text file");
    
    char task;
    scanf(" %c", &task);
    
    if (task == 'v') {
        int len = sizeof(arr_student) / sizeof(arr_student[0]);
        listContacts(arr_student, len);
    } else if (task == 'k'){
        printf("The PhoneBook was closed");
    } else if (task == 'p') {
        structureAdd();
    } else if (task == 'h'){
        printf("IMPLEMENT SEARCHING");
      // int len = sizeof(data) / sizeof(data[0]);
      // searchByNameOrSurname(data, len);
    } else if (task == 'C'){
        int len = sizeof(arr_student) / sizeof(arr_student[0]);
        structuresToFile(arr_student, len);
    } else if (task == 'R'){
        readFile();
    } else {
        printf("Invalid input. Only 'v', 'k', 'p' 'h' and 'C' are allowed.");
    }
    return 0;
}
