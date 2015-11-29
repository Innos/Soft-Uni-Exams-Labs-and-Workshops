
#include <stdio.h>
#include <stdlib.h>

#define BUFFER_SIZE 4096

void die(const char * msg);

void printHelp();

int main(int argc, char** argv) {
    if (argc != 3) {
        printHelp();
    } else {
        char * source = argv[1];
        char * destination = argv[2];
        FILE * src = fopen(source,"r");
        if(!src)
        {
            die(source);
        }
        FILE * dest = fopen(destination,"w");
        if(!dest)
        {
            die(destination);
        }
        char buffer[BUFFER_SIZE];
        while(!feof(src))
        {
            int bytesRead = fread(buffer,1,BUFFER_SIZE,src);
            int mid = bytesRead /2;
            fwrite(buffer+mid,1,mid,dest);
            fwrite(buffer,1,bytesRead - mid,dest);
        }
        printf("Success!");
        fclose(src);
        fclose(dest);
    }
    return (EXIT_SUCCESS);
}

void printHelp() {
    printf("Usage: <src-file> <dest-file>");
}

void die(const char * msg) {
    printf("%s: No such file or directory", msg);
    exit(1);
}
