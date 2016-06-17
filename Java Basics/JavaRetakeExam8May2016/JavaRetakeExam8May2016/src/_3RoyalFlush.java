import jdk.nashorn.internal.runtime.regexp.joni.Regex;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.Stack;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _3RoyalFlush {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<String> clubs = new ArrayList<>();
        List<String> hearts = new ArrayList<>();
        List<String> diamonds = new ArrayList<>();
        List<String> spades = new ArrayList<>();

        String text = "";

        int lines = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < lines; i++) {
            text += scanner.nextLine();
        }

        String pattern = "(2|3|4|5|6|7|8|9|10|J|Q|K|A)(s|d|c|h)";
        Pattern r = Pattern.compile(pattern);
        Matcher m = r.matcher(text);
        int flushes = 0;
        while (m.find()) {
            String card = m.group(1);
            String color = m.group(2);

            String colorName = null;
            List currentStack = null;
            switch (color) {
                case "s":
                    currentStack = spades;
                    colorName = "Spades";
                    break;
                case "c":
                    currentStack = clubs;
                    colorName = "Clubs";
                    break;
                case "d":
                    currentStack = diamonds;
                    colorName = "Diamonds";
                    break;
                case "h":
                    currentStack = hearts;
                    colorName = "Hearts";
                    break;
                default:
                    currentStack = null;
            }


            if (currentStack.size() > 0 && !canContinue(card, (String)currentStack.get(currentStack.size()-1))){
                currentStack.clear();
                if(card.equals("10")){
                    currentStack.add(card);
                }
            }
            else if(currentStack.size() > 0 || card.equals("10")){
                currentStack.add(card);
                if(card.equals("A")){
                    System.out.println("Royal Flush Found - " + colorName);
                    flushes++;
                    currentStack.clear();
                }
            }
        }

        System.out.println("Royal's Royal Flushes - " + flushes + ".");
    }

    private static boolean canContinue(String card, String prevCard) {
        if ((prevCard.equals("10") && card.equals("J")) ||
                (prevCard.equals("J") && card.equals("Q")) ||
                (prevCard.equals("Q") && card.equals("K")) ||
                (prevCard.equals("K") && card.equals("A"))){
            return true;
        }
        return false;
    }
}
