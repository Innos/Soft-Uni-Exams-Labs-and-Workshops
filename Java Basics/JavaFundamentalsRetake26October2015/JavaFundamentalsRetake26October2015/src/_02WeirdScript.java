import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _02WeirdScript {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int number = Integer.parseInt(scanner.nextLine());

        int keyNumber = (number - 1) % 52;
        char keyToken = 0;
        if (keyNumber < 26) {
            keyToken = (char) ('a' + keyNumber);
        } else {
            keyToken = (char) ('A' + keyNumber % 26);
        }
        String key = String.format("%s%s", keyToken, keyToken);
        Pattern keyPattern = Pattern.compile(key + "(?<result>.{0,50}?)" + key);

        StringBuilder textSB = new StringBuilder();
        String line = scanner.nextLine();
        while (!line.equals("End")) {
            textSB.append(line);
            line = scanner.nextLine();
        }

        String text = textSB.toString();

        Matcher keyMatcher = keyPattern.matcher(text);
        while (keyMatcher.find()) {
            if(keyMatcher.group("result").length()>0){
                System.out.println(keyMatcher.group("result"));
            }


        }
    }
}