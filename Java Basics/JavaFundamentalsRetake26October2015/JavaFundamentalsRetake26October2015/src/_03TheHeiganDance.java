import java.util.ArrayList;
import java.util.Scanner;

public class _03TheHeiganDance {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int health = 18500;
        double bossHealth = 3000000;
        int rows = 15;
        int cols = 15;

        int playerRow = rows / 2;
        int playerCol = cols / 2;

        double playerDamage = Double.parseDouble(scanner.nextLine());

        boolean poisoned = false;
        boolean poisonDeath = false;
        boolean eruptionDeath = false;
        boolean won = false;

        String line = scanner.nextLine();
        while (true) {
            String[] parameters = line.split("\\s+");
            String spell = parameters[0];
            int spellRow = Integer.parseInt(parameters[1]);
            int spellCol = Integer.parseInt(parameters[2]);

            bossHealth = bossHealth - playerDamage;
            if(bossHealth <= 0){
                won = true;
            }

            if(poisoned){
                health -= 3500;
                poisoned = false;
            }

            if(health <= 0){
                poisonDeath = true;
                break;
            }

            if(won){
                break;
            }

            if (!isNotDamaged(playerRow,playerCol,spellRow,spellCol)) {
                if (isInsideMatrix(playerRow - 1, playerCol) && isNotDamaged(playerRow - 1, playerCol, spellRow, spellCol)) {
                    playerRow -= 1;
                }
                else if(isInsideMatrix(playerRow, playerCol+1) && isNotDamaged(playerRow, playerCol +1, spellRow, spellCol)) {
                    playerCol += 1;
                }
                else if(isInsideMatrix(playerRow +1, playerCol) && isNotDamaged(playerRow + 1, playerCol, spellRow, spellCol)) {
                    playerRow += 1;
                }
                else if(isInsideMatrix(playerRow, playerCol-1) && isNotDamaged(playerRow, playerCol-1, spellRow, spellCol)) {
                    playerCol -=1;
                }
                else{
                    if(spell.equals("Cloud")){
                        health -= 3500;
                        poisoned = true;
                        if(health <= 0){
                            poisonDeath = true;
                            break;
                        }
                    }
                    else {
                        health -= 6000;
                        if(health <= 0){
                            eruptionDeath = true;
                            break;
                        }
                    }
                }
            }
            line = scanner.nextLine();
        }

        System.out.print("Heigan: ");
        if(won){
            System.out.println("Defeated!");
        }
        else{
            System.out.printf("%.2f\n", bossHealth);
        }

        System.out.print("Player: ");
        if(poisonDeath){
            System.out.println("Killed by Plague Cloud");
        }
        else if(eruptionDeath){
            System.out.println("Killed by Eruption");
        }
        else{
            System.out.printf("%d\n", health);
        }

        System.out.printf("Final position: %d, %d\n",playerRow,playerCol);
    }

    private static boolean isInsideMatrix(int row, int col) {
        if (row < 0 || row > 14 || col < 0 || col > 14) {
            return false;
        }
        return true;
    }

    private static boolean isNotDamaged(int row, int col, int spellRow, int spellCol) {
        if (row < spellRow - 1 || row > spellRow + 1 || col < spellCol - 1 || col > spellCol + 1) {
            return true;
        }
        return false;
    }
}