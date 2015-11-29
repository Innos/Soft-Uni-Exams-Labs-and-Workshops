

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char * readLine();

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
    char * line = readLine();
    size_t len = strlen(line);
    char string[len];
    memset(string, 0, sizeof (string));
    char * block = strtok(line, "|");
    while (block) {
        char * openingBracket = strchr(block, '{');
        char * closingBracket = strrchr(block, '}');
        if (openingBracket != NULL && closingBracket != NULL) {

            size_t matchSize = (closingBracket - openingBracket) - 1;
            strncat(string, openingBracket + 1, matchSize);
        }
        char * a = string;
        block = strtok(NULL, "|");
    }

    free(line);

    line = readLine();
    while (strcmp(line, "end") != 0) {

        char * token = strtok(line, " ");
        token = strtok(NULL, " ");
        long startPosition = strtol(token, NULL, 10);
        token = strtok(NULL, " ");
        long endPosition = strtol(token, NULL, 10);
        token = strtok(NULL, " ");
        long length = strtol(token, NULL, 10);
        if (startPosition > endPosition) {
            long temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
        }
        size_t stringSize = strlen(string);
        if (startPosition < 0 || endPosition < 0 ||length < 0 ||  startPosition + length > endPosition || endPosition + length > stringSize) {
            printf("Invalid command parameters\n");
        } else {
            char * start = string + startPosition;
            char * end = string + endPosition;
            char temp1[length + 1];
            char temp2[length + 1];

            memcpy(temp1, start, length);
            memcpy(temp2, end, length);
            memcpy(start, temp2, length);
            memcpy(end, temp1, length);
        }

        free(line);
        line = readLine();
    }
    free(line);
    printf("%s\n", string);
    return (EXIT_SUCCESS);
}

