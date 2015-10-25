import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class _3ShmoogleCounter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        StringBuilder textSB = new StringBuilder();
        String line = scanner.nextLine();
        while (!line.equals("//END_OF_CODE")) {
            textSB.append(line + "\n");
            line = scanner.nextLine();
        }

        String text = textSB.toString();
        Pattern doublePattern = Pattern.compile("double\\s+(?<double>[a-z][a-zA-Z]*)");
        Pattern intPattern = Pattern.compile("int\\s+(?<int>[a-z][a-zA-Z]*)");

        Matcher doubleMatcher = doublePattern.matcher(text);
        Matcher intMatcher = intPattern.matcher(text);

        ArrayList<String> doubles = new ArrayList<>();
        ArrayList<String> ints = new ArrayList<>();
        while (doubleMatcher.find()) {
            doubles.add(doubleMatcher.group("double"));
        }
        while (intMatcher.find()) {
            ints.add(intMatcher.group("int"));
        }
        Collections.sort(doubles);
        Collections.sort(ints);

        System.out.printf("Doubles: %s\n", doubles.size() == 0 ? "None" : doubles.stream().reduce((sum, p) -> sum + ", " + p).get().toString());
        System.out.printf("Ints: %s\n", ints.size() == 0 ? "None" : ints.stream().reduce((sum, p) -> sum + ", " + p).get().toString());
    }
}
