/**
 * @file       heap.c
 * @author     Ondřej Ševčík
 * @date       6/2019
 * @brief      Implementing of functions for heap
 * **********************************************************************
 * @par       COPYRIGHT NOTICE (c) 2019 TBU in Zlin. All rights reserved.
 */

/* Private includes -------------------------------------------------------- */
#include "heap.h"

#include <stdlib.h>
#include <string.h>
#include <stdio.h>

bool Heap_Init(tHeap *heap) {
    if (heap == NULL){
        return false;
    }
    
    heap->count = 0;
    heap->maxItems = MAX_ITEMS_START;
    heap->array = myMalloc(MAX_ITEMS_START * sizeof(Data_t));
    
    if (heap->array == NULL){
        return false;
    }
    
    return true;
}

void heapify_bottom_top(tHeap *h,int index){
   
    Data_t temp;
    int parent_node = (index-1)/2;
    
    if (Data_Cmp(&h->array[parent_node], &h->array[index]) > 0) {
        temp = h->array[parent_node];
        h->array[parent_node] = h->array[index];
        h->array[index] = temp;
        heapify_bottom_top(h,parent_node);
    }
}

bool Heap_Insert(tHeap *heap, Data_t insertData) {
    if( heap->count < heap->maxItems){
        heap->array[heap->count] = insertData;
        heapify_bottom_top(heap, heap->count);
        heap->count++;
      }
  return true;
}



void Heap_Destruct(tHeap *heap) {
    if (heap != NULL){
        myFree(heap->array);
        heap->count = 0;
        heap->maxItems = 0;
        heap->array = NULL;
    }
}




bool Heap_FindMin(tHeap heap, Data_t *value){
    
    unsigned int i=0,j=0;
    Data_t t;
    
    if (heap.count == 0 || heap.array == NULL){
        return false;
    }
    
    for(i=0;i<heap.count;i++)
         {
              for(j=i+1;j<heap.count;j++)
              {
                   if(strcmp(heap.array[i].name, heap.array[j].name)>0)
                   {
                        t=heap.array[i];
                        heap.array[i]=heap.array[j];
                        heap.array[j]=t;
                   }
              }
         }
    
    
    *value = heap.array[0];
    return true;
}

bool Heap_DeleteMin(tHeap *heap, Data_t *deleteValue) {
    
    if (heap == NULL || heap->array == NULL || heap->count == 0){
        return false;
    }
    
    if (deleteValue != NULL){
        *deleteValue = heap->array[0];
    }
    
    if (heap->count > 1){
        heap->array[0] = heap->array[heap->count - 1];
    }
    
    heap->count--;
    
    heapify_bottom_top(heap, 0);
    
    return true;
}


void Heap_Print(tHeap heap) { // NO TESTS
    if (heap.count == 0 || heap.array == NULL){
        return;
    }
    
    for (unsigned int i = 0; i < heap.count; ++i){
        Data_Print(&heap.array[i]);
    }
}


bool Heap_Empty(tHeap heap) {
    if (heap.array == NULL && heap.count == 0){
        return true;
    }
    
    return false;
}






unsigned Heap_Count(tHeap heap) {
    if (heap.array == NULL) {
        return 0;
    }
    
    return heap.count;
}

void Heap_Swap(tHeap *heap, unsigned index1, unsigned index2) { // NO TESTS
  
    if (heap == NULL || heap->array == NULL || index1 > heap->count || index2 > heap->count){
        return;
    }
    
    Data_t tmp = heap->array[index1];
    heap->array[index1] = heap->array[index2];
    heap->array[index2] = tmp;
}
