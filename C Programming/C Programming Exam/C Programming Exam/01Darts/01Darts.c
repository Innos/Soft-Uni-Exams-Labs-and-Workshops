
#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

int main(int argc, char** argv) {

    double boardX, boardY, boardRadius;
    scanf("%lf %lf %lf%*c", &boardX, &boardY, &boardRadius);
    double headX, headY, headRadius;
    scanf("%lf %lf %lf%*c", &headX, &headY, &headRadius);
    double armTopLeftX, armTopLeftY, armBotRightX, armBotRightY;
    scanf("%lf %lf %lf %lf%*c", &armTopLeftX, &armTopLeftY, &armBotRightX, &armBotRightY);
    int shots;
    scanf("%d%*c", &shots);
    int sum = 0;
    int hits = 0;
    int shotsMade = 0;
    int health = 100;
    int i;
    for (i = 0; i < shots; i++) {
        double shotX, shotY;
        scanf("%lf %lf%*c", &shotX, &shotY);
        double distanceBoardX = shotX - boardX;
        double distanceBoardY = shotY - boardY;
        bool onBoard = (distanceBoardX * distanceBoardX) + (distanceBoardY * distanceBoardY) <= (boardRadius * boardRadius);
        double distanceHeadX = shotX - headX;
        double distanceHeadY = shotY - headY;
        bool inHead = (distanceHeadX * distanceHeadX) + (distanceHeadY * distanceHeadY) <= (headRadius * headRadius);
        bool inArm = (shotX >= armTopLeftX && shotX <= armBotRightX) && (shotY <= armTopLeftY && shotY >= armBotRightY);
        shotsMade++;
        if (onBoard) {
            if (inHead) {
                sum += 25;
                health -= 25;
            } else if (inArm) {
                sum += 25;
                health -= 30;
            } else {
                sum += 50;
            }
            hits++;
            if (health <= 0) {
                health = 0;
                break;
            }
        } else if (inHead) {
            health -= 25;
            if (health <= 0) {
                health = 0;
                break;
            }
        } else if (inArm) {
            health -= 30;
            if (health <= 0) {
                health = 0;
                break;
            }
        }
    }
    printf("Points: %d\n",sum);
    printf("Hit ratio: %d%%\n",(hits*100)/shotsMade);
    printf("Bay Mile: %d",health);
    return (EXIT_SUCCESS);
}

