//Павлюков Михаил
//Реализация стека на односвязном списке

#define STACK_OVERFLOW  -100
#define STACK_UNDERFLOW -101
#define OUT_OF_MEMORY   -102

typedef int T;
typedef struct Node_tag
{
    T value;
    struct Node_tag *next;
}
Node_t;

void push(Node_t** head, T value)
{
    Node_t* tmp = malloc(sizeof(Node_t));
    if (tmp == NULL)
    {
        exit(STACK_OVERFLOW);
    }
    tmp->next = *head;
    tmp->value = value;
    *head = tmp;
}

Node_t* pop1(Node_t** head)
{
    Node_t *out;
    if ((*head) == NULL)
    {
        exit(STACK_UNDERFLOW);
    }
    out = *head;
    *head = (*head)->next;
    return out;
}

T pop2(Node_t** head)
{
    Node_t *out;
    T value;
    if (*head == NULL)
    {
        exit(STACK_UNDERFLOW);
    }
    out = *head;
    *head = (*head)->next;
    value = out->value;
    free(out);
    return value;
}

T peek(const Node_t* head)
{
    if (head == NULL)
    {
        exit(STACK_UNDERFLOW);
    }
    return head->value;
}

void printStack(const Node_t* head)
{
    printf("stack >");
    while (head)
    {
        printf("%d ", head->value);
        head = head->next;
    }
}

size_t getSize(const Node_t* head)
{
    size_t size = 0;
    while (head)
    {
        size++;
        head = head->next;
    }
    return size;
}

void main()
{
    int i;
    Node_t* head = NULL;
    for (i = 0; i < 300; i++)
    {
        push(&head, i);
    }
    printf("size = %d\n", getSize(head));
    while (head)
    {
        printf("%d ", peek(head));
        printf("%d ", pop2(&head));
    }
    _getch();
}