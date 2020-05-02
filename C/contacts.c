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
       
       printf("\n");
       
       // Copy characters from temporary array to phonebook
       for (int i = 0; i < newContactLen; i++) {
           data[len][i] = entireContact[i];
       }
       
       // increment length of the phonebook
       len += 1;
}

// Print all contacts function
void printContacts(char data[][100], int len) {
    for (int i = 0; i < len; i++) {
        printf("%s\n", data[i]);
    }
}



// SEARCHING BY NAME AND SURNAME
void searchUser(char data[][100], int len, char* by){
    for (int i = 0; i < len; i++) {
           printf("%s\n", data[i]);
        if (strncmp(by, data[i], 100) == 0){
            printf("I have found the user! \n");
        } else {
            printf("I haven't found the user. \n");
        }
       }
}


// Find contact by its name
void findContactByName(char phonebook[][100], int len) {
    char name[50];
    char ch;
    
    printf("\nDo you want to search by name (n) or surname (s)?: ");
    scanf("\n%c", &ch);
    
    printf("Please enter a string you want to search: ");
    scanf("%s", name);
    
    
    // Searching name - I know, its not very efficient, but we are in C ... :D
    // I am very pampered by higher programming languages :D (".contains method for example")
    // Also, its case sensitive
    if (ch == 'n') {
        for (int i = 0; i < len; i++) {
            char tmpName[30] = {0};
            int tmpIndex = i;
            int iterator = 0;
        
            for (int y = 0; y <= 30; y++) {
                if (phonebook[i][y] == '-') {
                    break;
                } else {
                    tmpName[iterator] = phonebook[i][y];
                    iterator++;
                }
            }
        
            // Compare names and return the result
            int result = strcmp(name, tmpName);
        
            if (result == 0) {
                printf("\n%s", phonebook[tmpIndex]);
                break;
            }
        }
    } else {
        
        for (int i = 0; i < len; i++) {
            char tmpSurname[50] = {0};
            int tmpIndex = i;
            int iterator = 0;
            int separator = 0;
        
            for (int y = 0; y <= 85; y++) {
                if (phonebook[i][y] == '-') {
                    separator += 1;
                    continue;
                }
                
                if (separator == 1) {
                    tmpSurname[iterator] = phonebook[i][y];
                    iterator++;
                } else if (separator == 2) { break; }
            }
        
            // Compare names and return the result
            int result = strcmp(name, tmpSurname);
        
            if (result == 0) {
                printf("\n%s", phonebook[tmpIndex]);
                break;
            }
            
        }
    }
}

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
}
































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
        printContacts(data, len);
    } else if (task == 'e'){
        printf("PhoneBook closed");
    } else if (task == 'p') {
        printf("ADDING USER");
        addContact();
    } else if (task == 'h'){
       int len = sizeof(data) / sizeof(data[0]);
        
        findContactByName(data, len);
      // findByName(data, len);
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
