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
#include <assert.h>
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


/*

// Find contact by its name
void findByName(char data[][100], int len) {
    char name[50];
    char ch;
    
    // 1 - MOŽNOST VOLBY
    printf("Search by name: (N) \n");
    printf("Search by surname: (S) \n");
    scanf("\n%c", &ch);
    
    // 2 - OŠTŘENÍ VSTUPU
    if (ch == 'N' || ch == 'S'){
        printf("Enter a text you want to search: \n");
        scanf("%s", name);
    } else {
        printf("Only 'N' and 'S' characters are allowed.");
    }

    // 3 - HLEDÁME PODLE JMÉNA
    if (ch == 'N') {
        for (int i = 0; i < len; i++) {
            char tmpName[30] = {0};
            int tmpIndex = i;
            int iterator = 0;
            
            for (int y = 0; y <= 30; y++) {
                if (data[i][y] == '-') { // NARAZILI JSME NA PRVNÍ POMLČKU (NÁSLEDUJE JMÉNO)
                    break;
                } else {
                    tmpName[iterator] = data[i][y];
                    iterator++;
                }
            }
        
            int result = strcmp(name, tmpName);
        
            if (result == 0) {
                printf("\n%s", data[tmpIndex]);
                break;
            } else {
                printf("Uživatel nenalezen.");
                break;
            }
        }
    } else if (ch == 'S') { // 4 - HLEDÁME PODLE PŘIJÍMENÍ
        for (int i = 0; i < len; i++) {
            char tmpSurname[50] = {0};
            int tmpIndex = i;
            int iterator = 0;
            int separator = 0;
        
            for (int y = 0; y <= 85; y++) {
                if (data[i][y] == '-') {
                    separator += 1;
                    continue;
                }
                
                if (separator == 1) { // NÁSLEDUJE PŘIJÍMENÍ
                    tmpSurname[iterator] = data[i][y];
                    iterator++;
                } else if (separator == 2) { break; }
            }
        
           
            // zjištění výsledku
            int result = strcmp(name, tmpSurname);
        
            if (result == 0) {
                printf("\n%s", data[tmpIndex]);
                break;
            } else { // result != 0 ==> nenašli jsme uživatele
                printf("Uživatel nenalezen.");
                break;
            }
            
        }
    }
}*/
































int main(int argc, const char * argv[]) {
    
     printf("Menu \n");
     printf("Zadejte příkazy: \n");
    
     printf("p - pridej \n");
     printf("v - vypis \n");
     printf("h - hledej \n");
     printf("k - konec \n");
    
    char task;
    scanf(" %c", &task);
    
    if (task == 'v') {
        int len = sizeof(data) / sizeof(data[0]);
        listContacts(data, len);
    } else if (task == 'e'){
        printf("PhoneBook closed");
    } else if (task == 'p') {
        printf("ADDING USER");
        addContact();
    } else if (task == 'h'){
       int len = sizeof(data) / sizeof(data[0]);
        
       // findContactByName(data, len);
       searchByNameOrSurname(data, len);
    } else {
        printf("Character not found");
    }
    
    
    
    
    
  
   
    
    
  
/*
  char name[5];
     printf("What's your name? ");
     if (fgets(name, 40, stdin))
     {
         printf("d %s!\n", name);
     }
    
    
    for (int i = 0; i < 5; i++){
             printf("%c", name[i]);
    }
    
 
 */
    
    
    
     /* gets( str );

      printf( "\nYou entered: ");
      puts( str );*/
    
    
    
    

    
    
   /* for (int i = 0; i < 100; i++){
             printf("String is %c", str[i]);
       
    }*/
    
    return 0;
}
