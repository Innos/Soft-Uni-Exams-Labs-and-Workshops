

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char * readLine();
int getBitAt(unsigned long * numbers, int row, int col);
void move(unsigned long * numbers, int destRow, int destCol, int prevRow, int prevCol);

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
    unsigned long numbers[numbersCount];
    int i;
    for (i = 0; i < numbersCount; i++) {
        scanf("%lu%*c", &numbers[i]);
    }
    int playerRow = 0;
    int playerCol = 0;
    int currentRow = 0;
    int currentCol = 0;
    char * line = readLine();
    while (strcmp(line, "end") != 0) {
        if (strcmp(line, "up") == 0) {
            currentRow--;
            if (currentRow < 0) {
                currentRow = numbersCount - 1;
            }
            if (getBitAt(numbers, currentRow, currentCol) == 1) {
                printf("GAME OVER. Stepped a mine at %d %d\n", currentRow, currentCol);
                break;
            }
            else{
                move(numbers,currentRow,currentCol,playerRow,playerCol);
                playerRow = currentRow;
                playerCol = currentCol;
            }
        }
        else if(strcmp(line,"down") == 0)
        {
            currentRow++;
            currentRow = currentRow % numbersCount;
            if (getBitAt(numbers, currentRow, currentCol) == 1) {
                printf("GAME OVER. Stepped a mine at %d %d\n", currentRow, currentCol);
                break;
            }
            else{
                move(numbers,currentRow,currentCol,playerRow,playerCol);
                playerRow = currentRow;
                playerCol = currentCol;
            }
        }
        else if(strcmp(line,"left") == 0)
        {
            currentCol++;
            currentCol = currentCol % 32;
            if (getBitAt(numbers, currentRow, currentCol) == 1) {
                printf("GAME OVER. Stepped a mine at %d %d\n", currentRow, currentCol);
                break;
            }
            else{
                move(numbers,currentRow,currentCol,playerRow,playerCol);
                playerRow = currentRow;
                playerCol = currentCol;
            }
        }
        else if(strcmp(line,"right") == 0)
        {
            currentCol--;
            if(currentCol < 0)
            {
                currentCol = 31;
            }
            if (getBitAt(numbers, currentRow, currentCol) == 1) {
                printf("GAME OVER. Stepped a mine at %d %d\n", currentRow, currentCol);
                break;
            }
            else{
                move(numbers,currentRow,currentCol,playerRow,playerCol);
                playerRow = currentRow;
                playerCol = currentCol;
            }
        }
        free(line);
        line = readLine();
    }
    free(line);
    
    for(i=0;i<numbersCount;i++)
    {
        printf("%lu\n",numbers[i]);
    }
    return (EXIT_SUCCESS);
}

int getBitAt(unsigned long * numbers, int row, int col) {
    return ((numbers[row] >> col) & 1);
}

void move(unsigned long * numbers, int destRow, int destCol, int prevRow, int prevCol) {
    unsigned long mask = ~((unsigned long) 1 << prevCol);
    numbers[prevRow] = numbers[prevRow] & mask;
    mask = (unsigned long)1 << destCol;
    numbers[destRow] = numbers[destRow] | mask;
}

