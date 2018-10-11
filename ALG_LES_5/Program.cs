//Павлюков Михаил


# include "stdio.h"

int main(void)
{
    int x; int y, n = 0;
    printf("Введите число х: ");
    scanf("%d", x);
    while (x > 0)
    {
        y = (x % 2);
        n = y + n;
        x = int(x / 2);
    }
    printf("%d", n);

    getchar();

    return 0;
}
