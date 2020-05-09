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
    {"Filip", "Vabrousek", "280830702"}
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
        int i = 1;
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
    
    // 1 - ENTER THE PATH TO THE FILE
    printf("Zadejte cestu k souboru.");
    char name[20];
    scanf("%s", &name);
    
    // 2 - OPEN THE FILE
    fp = fopen(name, "r");
    
    // 3 - IF THERE IS AN ERROR WHILE CREATING THE FILE, EXIT
    if (fp == NULL){
         exit(EXIT_FAILURE);
    }
       

    // 4 - READ LINE-BY-LINE
    while ((read = getline(&line, &len, fp)) != -1) {
        printf("%s", line);
    }

    // 5 - CLOSE THE FILE AND FREE MEMORY
    fclose(fp);
    if (line){
      free(line);
    }
    
    exit(EXIT_SUCCESS);
}



/*---------------------------------------------SAVE DATA TO THE FILE---------------------------------------------*/
void structuresToFile(struct contact data[], int len){
    printf("I am creating text file with contents of the PhoneBook.");
       
       // 1 - ENTER THE PATH TO THE FILE
       printf("Zadejte cestu k souboru.");
       char name[20];
       scanf("%s", &name);
       
       // 2 - CREATE THE FILE
       FILE *fptr;
       fptr = fopen(name,"w");

       // 3 - ERROR WHILE CREATING THE FILE, EXIT
       if(fptr == NULL) {
          printf("Error in file creation.");
          exit(1);
       }
        
       // 4 - WRITE DATA TO FILE
       for (int i = 0; i < len; i++) {
           fprintf(fptr,"%s\n",data[i].name);
           fprintf(fptr,"%s\n",data[i].surname);
           fprintf(fptr,"%s\n",data[i].number);
       }
    
        // 5 - CLOSE THE FILE
       fclose(fptr);
}

/*---------------------------------------------SEARCH IN PHONEBOOK---------------------------------------------*/
void searchName(struct contact data[], int len, char name[], bool byName){
    if (byName){
        for (int i = 0; i < len; i++){
            if (strcmp(data[i].name, name) == 0){
                printf("I have found user: %s \n", name);
                printf("NAME: %s \n", data[i].name);
                printf("SURNAME %s \n", data[i].surname);
                printf("NUMBER %s \n", data[i].number);
            }
        }
    } else {
        for (int i = 0; i < len; i++){
            if (strcmp(data[i].surname, name) == 0){
                 printf("I have found user: %s \n", name);
                 printf("NAME: %s \n", data[i].name);
                 printf("SURNAME %s \n", data[i].surname);
                 printf("NUMBER %s \n", data[i].number);
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
        char choice[1];
        char searched[50];
        int len = sizeof(arr_student) / sizeof(arr_student[0]);

        printf("Search by name (N) or surname (S) \n");
        scanf("%s", choice);
        
        if (strcmp(choice, "N") == 0){
            printf("Enter searched name \n");
            scanf("%s", searched);
            searchName(arr_student, len, searched, true);
        } else if (strcmp(choice, "S") == 0){
            printf("Enter searched surname \n");
            scanf("%s", searched);
            searchName(arr_student, len, searched, false);
            
        } else { printf("INVALID INPUTS!");}
    } else if (task == 'C'){
        int len = sizeof(arr_student) / sizeof(arr_student[0]);
        structuresToFile(arr_student, len);
    } else if (task == 'R'){
        readFile();
    } else {
        printf("Invalid input. Only 'v', 'k', 'p' 'h', 'C' and 'R' are allowed.");
    }
    return 0;
}
