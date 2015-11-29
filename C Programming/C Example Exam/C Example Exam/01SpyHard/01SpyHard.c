
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

char * readLine();
char * NumberInNumeralSystem(long number, int system);

char * readLine() {
    char * buffer = (char *)malloc(60 * sizeof (char));
    size_t size = 60;

    int counter = 0;
    char c = fgetc(stdin);

    while (c != '\n' && c != EOF) {

        buffer[counter] = c;
        counter++;

        if (counter == size) {
            buffer = (char *)realloc(buffer, size * 2);
            if (buffer == NULL) {
                printf("Cannot find sufficient free memory!");
                exit(1);
            }
            size = size * 2;
        }
        c = fgetc(stdin);
    }
    char * result = (char*)realloc(buffer, counter + 1);
    result[counter] = '\0';

    return result;
}

int main(int argc, char** argv) {
    int numeralSystem;
    scanf("%d%*c",&numeralSystem);
    char * line = readLine();
    int symbols = strlen(line);
    long sum = 0;
    int i;
    for(i=0;i<symbols;i++)
    {
        if(isalpha(line[i]))
        {
            sum += tolower(line[i]) - ('a' - 1);
        }
        else{
            sum += line[i];
        }
    }   
    char * number = NumberInNumeralSystem(sum,numeralSystem);
    printf("%d%d%s\n",numeralSystem,symbols,number);
    free(number);
    return (EXIT_SUCCESS);
}

char * NumberInNumeralSystem(long number, int system)
{
    char temp [100];
    int counter = 0;
    while(number > 0)
    {
        char digit = (number % system) + '0';
        number = number/ system;
        temp[counter] = digit;
        counter++;
    }
    
    char * newNumber = (char *)malloc(counter+1);
    int i,j = 0;
    for(i = counter-1; i>= 0;i--)
    {
        newNumber[j] = temp[i];
        j++;
    }
    newNumber[j] = '\0';
    return newNumber;
}

