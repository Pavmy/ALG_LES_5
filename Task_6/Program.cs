//Павлюков Михаил
//* Реализовать очередь.

#include <string.h>
#include <stdlib.h>
#include <stdio.h>

struct STACK
{
    int a;
    STACK* next;
};
STACK* top = NULL;

void push(int c, STACK** b)
{
    STACK* temp = new STACK;
    temp->a = c;
    temp->next = (*b);
    (*b) = temp;
}
int pop(STACK** t)
{
    if ((*t) != NULL)
    {
        STACK* temp = (*t);
        int a = (*t)->a;
        (*t) = (*t)->next;
        delete temp;
        return a;
    }
    else
        return 0;
}

struct QUEUE
{
    char a;
    QUEUE* next;
};

QUEUE* head = NULL, * tail = NULL;

void push_back(char c, QUEUE** b)
{
    if ((*b) != NULL)
    {
        QUEUE* temp = new QUEUE;
        temp->a = c;
        temp->next = NULL;
        (*b)->next = temp;
        (*b) = temp;
    }
    else
    {
        (*b) = new QUEUE;
        (*b)->a = c;
        (*b)->next = NULL;
        head = (*b);
    }
}
char pop_front(QUEUE** t)
{
    if ((*t) != NULL)
    {
        QUEUE* temp = (*t);
        char a = (*t)->a;
        (*t) = (*t)->next;
        delete temp;
        return a;
    }
    else
        return 0;
}

int main()
{
    char c[200], str[10];
    gets(c);
    int a, k = 0;
    for (int i = 0; i < strlen(c); i++)
    {
        if (c[i] == '-' && c[i + 1] >= '0' && c[i + 1] <= '9' && k == 0) k = 1;
        else
        if (c[i] >= '0' && c[i] <= '9') k = 1;
        else
        if (c[i] == ' ' && k == 1)
        {
            k = 0;
            strncpy(str, c, i + 1);
            strcpy(c, &(c[i + 1]));
            i = -1;
            a = atoi(str);
            push(a, &top);
        }
        else
        {
            if (c[i] != ' ') push_back(c[i], &tail);
            strcpy(c, &(c[i + 1]));
            i = -1;
        }

    }
    if (k == 1)
    {
        a = atoi(c);
        push(a, &top);
    }

    while (head != NULL)
        printf("%c ", pop_front(&head));

    while (top != NULL)
        printf("%d ", pop(&top));

    return 0;
}
