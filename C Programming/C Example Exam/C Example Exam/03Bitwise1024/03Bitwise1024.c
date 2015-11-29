
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char * readLine();
int findOneBits(unsigned long long number);

char * readLine() {
    char * buffer = (char *) malloc(60 * sizeof (char));
    size_t size = 60;

    int counter = 0;
    char c = fgetc(stdin);

    while (c != '\n' && c != EOF) {

        buffer[counter] = c;
        counter++;

        if (counter == size) {
            buffer = (char *) realloc(buffer, size * 2);
            if (buffer == NULL) {
                printf("Cannot find sufficient free memory!");
                exit(1);
            }
            size = size * 2;
        }
        c = fgetc(stdin);
    }
    char * result = (char*) realloc(buffer, counter + 1);
    result[counter] = '\0';

    return result;
}

int main(int argc, char** argv) {
    int numbersCount;
    scanf("%d%*c", &numbersCount);
    unsigned long long numbers[numbersCount];
    int i;
    for (i = 0; i < numbersCount; i++) {
        scanf("%llu%*c", &numbers[i]);
    }

    char * line = readLine();
    while (strcmp(line, "end") != 0) {
        char * match = strtok(line, " ");
        char * direction = match;
        match = strtok(NULL, " ");
        long position = strtol(match, NULL, 10);
        unsigned long long * a = &numbers[0];
        if (strcmp(direction, "left") == 0) {
            for (i = 0; i < numbersCount; i++) {
                int oneBits = findOneBits(numbers[i] >> position);
                unsigned long long mask = ((unsigned long long) 1 << oneBits) - 1;
                mask = mask << (64 - oneBits);

                //clean the selected area
                long shift = 64 - position;
                if (shift == 64) {
                    numbers[i] = 0;
                } else {
                    numbers[i] = numbers[i] << shift;
                    numbers[i] = numbers[i] >> shift;
                }


                numbers[i] = numbers[i] | mask;
            }
        } else {
            for (i = 0; i < numbersCount; i++) {
                int oneBits = findOneBits(numbers[i] << (63 - position));
                unsigned long long mask = ((unsigned long long) 1 << oneBits) - 1;

                //clean the selected area
                long shift = position + 1;

                if (shift == 64) {
                    numbers[i] = 0;
                } else {
                    numbers[i] = numbers[i] >> shift;
                    numbers[i] = numbers[i] << shift;
                }


                numbers[i] = numbers[i] | mask;
            }
        }
        free(line);
        line = readLine();
    }
    free(line);

    for (i = 0; i < numbersCount; i++) {
        printf("%llu\n", numbers[i]);
    }
    return (EXIT_SUCCESS);
}

int findOneBits(unsigned long long number) {
    int counter = 0;
    while (number > 0) {
        number = number & (number - 1);
        counter++;
    }
    return counter;
}

