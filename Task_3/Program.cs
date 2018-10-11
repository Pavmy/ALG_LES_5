//Павлюков Михаил
//4 *создать функцию копирующую односвязный список


#include <assert.h>
#include <stdio.h>
#include <stdlib.h> // malloc

typedef struct Node* pNode;
typedef void (* node_visitor_t) (pNode);

struct Node
{
    int data;
    pNode next;
    pNode other;
};

static pNode newnode(pNode head, int data)
{
    pNode node = (pNode)malloc(sizeof(*node));
    if (!node)
    {
        perror("malloc");
        exit(1);
    }
    node->next = head;
    node->data = data;
    node->other = NULL;
    return node;
}

static void push_front(pNode* phead, int data)
{
    assert(phead);
    *phead = newnode(*phead, data);
}

static void visit(pNode head, node_visitor_t visitor)
{
    while (head)
    {
        pNode t = head->next;
        visitor(head);
        head = t;
    }
}

static void destroy(pNode head)
{
    visit(head, (node_visitor_t)free);
}

static void print_node(pNode node)
{
    printf("%d ", node->data);
}

static pNode copy_list(pNode head)
{
    if (!head) return NULL;
    pNode node = head, copied = NULL, cnode = NULL;
    for (; node; node = node->next->next)
    {
        cnode = newnode(node->next, node->data);
        cnode->other = node->other;
        if (node == head)
            copied = cnode;
  
        node->next = cnode;
    }
    for (node = head; node && node->next;
         node = node->next->next)
        if (node->other)
            node->next->other = node->other->next;
        else
            node->next->other = NULL;
    node = head; cnode = copied;
    for (; cnode && cnode->next; node = node->next, cnode = cnode->next)
    {
        node->next = node->next->next;
        cnode->next = cnode->next->next;
    }
    node->next = NULL;
    return copied;
}

int main(void)
{
    pNode head = NULL;

    size_t i = 10;
    while (i-- > 0)
        push_front(&head, i);

    head->other = head;
    head->next->other = head;
    head->next->next->other = NULL;
    head->next->next->next->other = head->next->next->next->next->next->next;

    visit(head, print_node);
    puts("\n");

    pNode copied = copy_list(head);
    visit(copied, print_node);
    puts("\n");
    visit(head, print_node);
    puts("\n");

    assert(head->other == head);
    assert(head->next->other == head);
    assert(head->next->next->other == NULL);
    assert(head->next->next->next->other == head->next->next->next->next->next->next);
    assert(copied->other == copied);
    assert(copied->next->other == copied);
    assert(copied->next->next->other == NULL);
    assert(copied->next->next->next->other == copied->next->next->next->next->next->next);

    pNode node = head, cnode = copied;
    for (; node; node = node->next, cnode = cnode->next)
    {
        assert(node->data == cnode->data);
        assert(node->next != cnode->next || node->next == NULL);
        assert(node->other != cnode->other || node->other == NULL);
    }

    destroy(copied);
    destroy(head);
    return 0;
}
