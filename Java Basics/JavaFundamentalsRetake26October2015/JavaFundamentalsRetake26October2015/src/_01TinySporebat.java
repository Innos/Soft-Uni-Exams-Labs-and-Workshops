import java.util.Scanner;

public class _01TinySporebat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int health = 5800;
        int glowcaps = 0;

        String line = scanner.nextLine();
        boolean dead = false;

        while(!line.equals("Sporeggar") && !dead){

            for (int i = 0; i < line.length() - 1; i++) {
                char currentChar = line.charAt(i);
                if(currentChar == 'L'){
                    health += 200;
                }
                else{
                    health -= currentChar;
                    if(health <= 0){
                        dead = true;
                        break;
                    }
                }
            }
            if(!dead){
                int glowcapPrize = Integer.parseInt(line.substring(line.length()-1));
                glowcaps += glowcapPrize;
            }
            line = scanner.nextLine();
        }

        if(dead){
            System.out.printf("Died. Glowcaps: %d\n", glowcaps);
        }
        else{
            System.out.printf("Health left: %d\n",health);
            if(glowcaps < 30){
                System.out.printf("Safe in Sporeggar, but another %d Glowcaps needed.\n",30 - glowcaps);
            }
            else{
                System.out.printf("Bought the sporebat. Glowcaps left: %d",glowcaps - 30);
            }
        }
    }
}