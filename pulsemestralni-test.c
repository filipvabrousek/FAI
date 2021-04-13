//
//  main.c
//  Exam-2
//
//  Created by Filip Vabroušek on 13.04.2021.
//



/*
#include <stdio.h>

int main(int argc, const char * argv[]) {
    // insert code here...
    printf("Hello, World!\n");
    
    
    return 0;
}
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "mALLOC.h"

// #include "myMalloc.h"
#define MAX_ITEMS_START \
  4 /**< Maximum items in heap that can be stored when initializing heap */



typedef struct {
    char name[255];        /**< jmeno cloveka */
    double age, weight, height; /**< vek, vaha, vyska */
} Data_t;


typedef struct List_Node_s {
  Data_t data;              /**< DATA part of an item */
  struct List_Node_s* next; /**<    pointer at next item */
  struct List_Node_s* previous;
} List_Node_t;

typedef List_Node_t* List_Node_Ptr_t;

/** @struct List_t
 * Definition of list as a pointer at first and active item.
 *
 */
typedef struct {
  List_Node_t* first;  /**< Pointer at first item in list */
  List_Node_t* active; /**< Pointer at active item in list */
List_Node_t* previous;
    List_Node_t* next;
  List_Node_t* lastElementOfList;
} List_t;



void List_Init(List_t * const list) {
    if (list == NULL) return;
    list->active = NULL;
    list->first = NULL;
    list->next = NULL;
    list->lastElementOfList = NULL;
    list->previous = NULL;
}





void List_Insert_First(List_t * const list, Data_t data) {
    
    if (list == NULL){
        return;
    }
    
    List_Node_Ptr_t newNode = myMalloc(sizeof(List_Node_t));
    
    if (newNode == NULL){
        return;
    }
    
    newNode->data = data;
    newNode->previous = NULL;
    newNode->next = NULL;
    
    if (list->first == NULL){
        list->first = newNode;
        list->lastElementOfList = list->first;
        return;
    }
    
    List_Node_Ptr_t originalNode = list->first;
    list->first = newNode;
    newNode->next = originalNode;
    list->previous = newNode;
}







void List_Delete_First(List_t * const list) {
    if (list == NULL || list->first == NULL) return;
           if (list->first != NULL) {
               if(list->next == NULL) {
                   list->lastElementOfList = NULL;
                   list->first = NULL;
                               
               } else {
                   list->first->next->previous = NULL;
                   list->first = list->first->next;
               }
           }
}


int main(int argc, const char * argv[]) {
   
    
    static List_t list;

    static const Data_t mPeoplePool[] = {
                                          {.age = 23, .weight = 70, .height = 150, .name = "John"},
                                          {.age = 35, .weight = 78, .height = 176, .name = "Catherine"},
                                          {.age = 47, .weight = 83, .height = 178, .name = "Tanner"},
    };
    
    List_Insert_First(&list, mPeoplePool[0]);
    List_Delete_First(&list);
    List_Init(&list);
    
}














/*
typedef struct {
    char name[20];
} NAME;

int main(int argc, const char * argv[]) {
    
    NAME* names = myMalloc(sizeof(NAME) * MAX_ITEMS_START);
    NAME me = {.name = "Filip"};
    names[0] = me;
    names[1] = me;
    names[2] = me;
    names[3] = me;
    names[4] = me;
    
    printf("Hello, %s", names[4].name);
    
    
    
    int sizeOfArray = sizeof(*names) / sizeof(names[0]);
    
    for (unsigned int i = 0; i < sizeOfArray; i++){
        NAME p = names[i];
        printf("%s is NAME", p.name);
    }
    
    
    return 0;
}

*/
