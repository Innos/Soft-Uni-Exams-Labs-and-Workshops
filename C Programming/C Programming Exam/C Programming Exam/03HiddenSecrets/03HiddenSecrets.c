
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define BUFFER_SIZE 64
#define CODE_SIZE 4

void die(const char * msg);
void printHelp();
int readCode(char * code);

int main(int argc, char** argv) {
    if (argc == 1) {
        printHelp();
    } else {
        int filesCount = argc - 1;
        char ** files = argv + 1;
        char * extension = strrchr(argv[1], '.');
        size_t extensionLen = strlen(extension);
        // 7 so we can fit in "merged" and the null terminator
        char name[7 + extensionLen];
        sprintf(name,"merged%s",extension);
        name[6 + extensionLen] = '\0';
        FILE * dest = fopen(name, "w");
        if (!dest) {
            die(NULL);
        }

        int i;
        for (i = 0; i < filesCount; i++) {
            FILE * src = fopen(files[i], "r");
            if (!src) {
                fclose(dest);
                die(files[i]);
            }
            char buffer[BUFFER_SIZE];
            while (!feof(src)) {
                int bytesRead = fread(buffer, 1, BUFFER_SIZE, src);
                int code = readCode(buffer+(bytesRead-CODE_SIZE));
                //apple
                if(code == 1)
                {
                    fwrite(buffer,1,bytesRead-CODE_SIZE,dest);
                }
                else if(code == 2)
                {
                    int dataSize = (bytesRead - CODE_SIZE) /2;
                    fwrite(buffer,1,dataSize,dest);
                }
            }
            fclose(src);
        }
        fclose(dest);
        printf("Eureka!");
    }
    return (EXIT_SUCCESS);
}

void printHelp() {
    printf("Usage: [<src-file-1> <src-file-2> ...]");
}

void die(const char * msg) {
    printf("%s: No such file or directory", msg);
    exit(1);
}

int readCode(char * code)
{
    if(code[0] == '3' && code[1] == '4' && code[2] == '5' && code[3] == '6')
    {
        //apple
        return 1;
    }
    else if(code[0] == '!' && code[1] == '"' && code[2] == '#' && code[3] == '$')
    {
        //leaf
        return 2;
    }
    else if(code[0] == '+' && code[1] == ',' && code[2] == '-' && code[3] == '.')
    {
        //cross
        return 3;
    }
    else{
        // no symbol?
        return 0;
    }
}

