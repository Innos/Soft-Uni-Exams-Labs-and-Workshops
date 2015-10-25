import java.util.*;
import java.util.stream.Collectors;

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
                OptionalInt max = OptionalInt.empty();
                if (type.equals("even")) {
                    max = numbers.stream().mapToInt(x->x).filter(x->x % 2 == 0).max();
                } else if (type.equals("odd")) {
                    max = numbers.stream().mapToInt(x->x).filter(x->x % 2 == 1).max();
                }
                if(!max.isPresent()){
                    System.out.println("No matches");
                } else {
                    System.out.println(numbers.lastIndexOf(max.getAsInt()));
                }
            } else if (parameters[0].equals("min")) {
                String type = parameters[1];
                OptionalInt min = OptionalInt.empty();
                if (type.equals("even")) {
                    min = numbers.stream().mapToInt(x->x).filter(x->x % 2 == 0).min();
                } else if (type.equals("odd")) {
                    min = numbers.stream().mapToInt(x->x).filter(x->x % 2 == 1).min();
                }
                if(!min.isPresent()){
                    System.out.println("No matches");
                } else {
                    System.out.println(numbers.lastIndexOf(min.getAsInt()));
                }
            } else if (parameters[0].equals("first")) {
                ArrayList<Integer> firstElements = new ArrayList<>();
                int number = Integer.parseInt(parameters[1]);
                if (number > numbers.size()) {
                    System.out.println("Invalid count");
                } else {
                    String type = parameters[2];
                    int remainder = 0;
                    if (type.equals("even")) {
                        remainder = 0;
                    } else if (type.equals("odd")) {
                        remainder = 1;
                    }

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
                    int remainder = 0;
                    if (type.equals("even")) {
                        remainder = 0;
                    } else if (type.equals("odd")) {
                        remainder = 1;
                    }

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
