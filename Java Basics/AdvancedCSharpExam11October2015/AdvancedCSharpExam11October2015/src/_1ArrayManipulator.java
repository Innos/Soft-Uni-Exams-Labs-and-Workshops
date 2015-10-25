import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class _1ArrayManipulator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] tokens = scanner.nextLine().trim().split(" ");
        ArrayList<Integer> numbers = new ArrayList<>();
        for (int i = 0; i < tokens.length; i++) {
            numbers.add(Integer.parseInt(tokens[i]));
        }

        String line = scanner.nextLine();

        while (!line.equals("end")) {

            String[] parameters = line.split(" ");
            if (parameters[0].equals("exchange")) {
                int index = Integer.parseInt(parameters[1]);
                if (index >= numbers.size() || index < 0) {
                    System.out.println("Invalid index");
                } else {
                    ArrayList<Integer> list = new ArrayList<>();
                    for (int i = index + 1; i < numbers.size(); i++) {
                        list.add(numbers.get(i));
                    }
                    for (int i = 0; i <= index; i++) {
                        list.add(numbers.get(i));
                    }
                    numbers = list;
                }
            } else if (parameters[0].equals("max")) {
                String type = parameters[1];
                int max = Integer.MIN_VALUE;
                int maxIndex = -1;
                int remainder = type.equals("even") ? 0 : 1;
                for (int i = 0; i < numbers.size(); i++) {
                    if (numbers.get(i) % 2 == remainder) {
                        if (numbers.get(i) >= max) {
                            max = numbers.get(i);
                            maxIndex = i;
                        }
                    }
                }
                if (maxIndex != -1) {
                    System.out.println(maxIndex);
                } else {
                    System.out.println("No matches");
                }
            } else if (parameters[0].equals("min")) {
                String type = parameters[1];
                int min = Integer.MAX_VALUE;
                int minIndex = -1;
                int remainder = type.equals("even") ? 0 : 1;

                for (int i = 0; i < numbers.size(); i++) {
                    if (numbers.get(i) % 2 == remainder) {
                        if (numbers.get(i) <= min) {
                            min = numbers.get(i);
                            minIndex = i;
                        }
                    }
                }
                if (minIndex != -1) {
                    System.out.println(minIndex);
                } else {
                    System.out.println("No matches");
                }
            } else if (parameters[0].equals("first")) {
                ArrayList<Integer> firstElements = new ArrayList<>();
                int number = Integer.parseInt(parameters[1]);
                if (number > numbers.size()) {
                    System.out.println("Invalid count");
                } else {
                    String type = parameters[2];
                    int remainder = type.equals("even") ? 0 : 1;

                    for (int i = 0; i < numbers.size(); i++) {
                        if (number == 0) {
                            break;
                        }
                        if (numbers.get(i) % 2 == remainder) {
                            firstElements.add(numbers.get(i));
                            number--;
                        }
                    }
                    System.out.println(firstElements);
                }
            } else if (parameters[0].equals("last")) {
                ArrayList<Integer> lastElements = new ArrayList<>();
                int number = Integer.parseInt(parameters[1]);
                if (number > numbers.size()) {
                    System.out.println("Invalid count");
                } else {
                    String type = parameters[2];
                    int remainder = type.equals("even") ? 0 : 1;

                    for (int i = numbers.size() - 1; i >= 0; i--) {
                        if (number == 0) {
                            break;
                        }
                        if (numbers.get(i) % 2 == remainder) {
                            lastElements.add(numbers.get(i));
                            number--;
                        }
                    }
                    Collections.reverse(lastElements);
                    System.out.println(lastElements);
                }
            }
            line = scanner.nextLine();
        }
        System.out.println(numbers);
    }
}
