#define MAX_INPUT 256
char expr_cls[MAX_INPUT]

char find_operator(char expr_cls[])
{
    int i;
    for (i = 0; i < strlen(expr_cls); i++)
    {
        switch (expr_cls[i])
        {
            case '+':
            case '-':
            case '*':
            case '/':
                return expr_cls[i]; break;
            default: break;
        }
    }
    return 0;
}
