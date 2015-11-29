
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>

char * readLine();
void Resize();
void die(const char * msg);

static char * sb;
static unsigned long long size;
static unsigned long long used;

char * readLine() {
    char * buffer = (char *) malloc(60 * sizeof (char));
    unsigned long long size = 60;

    unsigned long long counter = 0;
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
    sb = (char*)calloc(60, sizeof (char));
    size = 60;
    used = 0;
    char * line = readLine();
    while (strcmp(line, "over") != 0) {
        char * a = sb;
        char * command = strtok(line, "-");
        char * string = strtok(NULL, "-");
        unsigned long long stringLen = strlen(string);
        if (strcmp(command, "concat") == 0) {
            
            while (used + stringLen >= size) {
                Resize();
            }
            memcpy(sb+used,string,stringLen);
            used += stringLen;
            sb[used] = '\0';
            
        } else if (strcmp(command, "insert") == 0) {
            
            char * pos = strtok(NULL, "-");
            unsigned long long position = strtoull(pos, NULL, 10);

            while (used + stringLen >= size) {
                Resize();
            }
            unsigned long long remainderLen = strlen(sb + position);
            char temp[remainderLen];
            memcpy(temp,sb+position,remainderLen);
            memcpy(sb + position, string, stringLen);
            memcpy(sb+position + stringLen,temp,remainderLen);
            used += stringLen;
            sb[used] = '\0';
            
        } else if (strcmp(command, "replace") == 0) {
            
            char * replacement = strtok(NULL, "-");
            unsigned long long replacementLen = strlen(replacement);
            long long sizeDifference = replacementLen - stringLen;

            char * match = strstr(sb, string);
            while (match != NULL) {
                //after each replace
                while (used + sizeDifference >= size) {
                    long long offset = match - sb;
                    Resize();
                    match = sb + offset;
                }
                unsigned long long remainderLen = strlen(match + stringLen);
                char temp[remainderLen];
                memcpy(temp, match + stringLen, remainderLen);
                memcpy(match, replacement, replacementLen);
                memcpy(match + replacementLen, temp, remainderLen);
                used += sizeDifference;
                sb[used] = '\0';
                match = strstr(match+replacementLen, string);
            }
        }
        free(line);
        line = readLine();
    }
    free(line);
    printf("%s", sb);
    free(sb);
    return (EXIT_SUCCESS);
}

void Resize() {
    sb = (char *) realloc(sb, size * 2);
    if (sb == NULL) {
        die("Cannot find free space!");
    }
    size = size * 2;
}

void die(const char * msg) {
    if (errno) {
        perror(msg);
    } else {
        printf("ERROR %s\n", msg);
    }
    exit(1);
}


