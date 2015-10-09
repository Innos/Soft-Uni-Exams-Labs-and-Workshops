import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class DragonTrap {
    private static List<Point> cellCoordinates = new ArrayList<>();
    private static List<Character> townsfolk = new ArrayList<>();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<char[]> matrix = new ArrayList<>();
        List<char[]> original = new ArrayList<>();
        int rows = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < rows; i++) {
            String line = scanner.nextLine();
            matrix.add(line.toCharArray());
            original.add(line.toCharArray());
        }
        String line = scanner.nextLine();
        while (!line.equals("End")) {
            String[] parameters = line.replace("(", "").replace(")", "").split("\\s");
            int row = Integer.parseInt(parameters[0]);
            int col = Integer.parseInt(parameters[1]);
            int radius = Integer.parseInt(parameters[2]);
            int rotations = Integer.parseInt(parameters[3]);
            int perimeter = radius * 8;
            int startRow = row - radius;
            int startCol = col - radius;
            int endRow = row + radius;
            int endCol = col + radius;
            Point start = new Point(startRow, startCol);
            Point end = new Point(endRow, endCol);

            GetElementsToRotate(matrix, start, end, perimeter);
            if(townsfolk.size() > 1){
                ApplyRotations(rotations);
                SetRotatedElements(matrix,start,end,perimeter);
            }

            townsfolk.clear();
            line = scanner.nextLine();
        }
        PrintResult(original, matrix);

    }

    private static void PrintResult(List<char[]> original, List<char[]> matrix) {
        int differences = 0;
        for (int row = 0; row < original.size(); row++) {
            for (int col = 0; col < original.get(row).length; col++) {
                System.out.print(matrix.get(row)[col]);
                if (original.get(row)[col] != matrix.get(row)[col]) {
                    differences++;
                }
            }
            System.out.println();
        }
        System.out.printf("Symbols changed: %d\n", differences);
    }

    private static void GetElementsToRotate(List<char[]> matrix, Point start, Point end, int perimeter) {
        int col = start.col;
        int row = start.row;

        String direction = "right";

        for (int i = 0; i < perimeter; i++) {

            if (direction.equals("right") && col > end.col) {
                direction = "down";
                col--;
                row++;
            }
            if (direction.equals("down") && row > end.row) {
                direction = "left";
                row--;
                col--;
            }
            if (direction.equals("left") && col < start.col) {
                direction = "up";
                col++;
                row--;
            }
            if (direction.equals("up") && row < start.row) {
                direction = "right";
                col++;
                row++;
            }

            if (row < 0 || row >= matrix.size() || col < 0 || col >= matrix.get(row).length) {
            } else {
                townsfolk.add(matrix.get(row)[col]);
            }

            switch (direction) {
                case "right":
                    col++;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "up":
                    row--;
                    break;
            }


        }
    }

    private static void SetRotatedElements(List<char[]> matrix,Point start, Point end, int perimeter) {
        int elementIndex = 0;
        int row = start.row;
        int col = start.col;

        String direction = "right";

        for (int i = 0; i < perimeter; i++) {

            if (direction.equals("right") && col > end.col) {
                direction = "down";
                col--;
                row++;
            }
            if (direction.equals("down") && row > end.row) {
                direction = "left";
                row--;
                col--;
            }
            if (direction.equals("left") && col < start.col) {
                direction = "up";
                col++;
                row--;
            }
            if (direction.equals("up") && row < start.row) {
                direction = "right";
                col++;
                row++;
            }

            if (row < 0 || row >= matrix.size() || col < 0 || col >= matrix.get(row).length) {
            } else {
                matrix.get(row)[col] = townsfolk.get(elementIndex);
                elementIndex++;
            }

            switch (direction) {
                case "right":
                    col++;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "up":
                    row--;
                    break;
            }


        }
    }

    private static void ApplyRotations(int rotations) {
        if(rotations == 0){
            return;
        }
        if (rotations > 0) {
            int posRotations = rotations % townsfolk.size();
            for (int i = 0; i < posRotations; i++) {
                Character temp = townsfolk.get(townsfolk.size() - 1);
                for (int j = townsfolk.size() - 1; j > 0; j--) {
                    townsfolk.set(j, townsfolk.get(j - 1));
                }
                townsfolk.set(0, temp);
            }
        } else {
            int negRotations = Math.abs(rotations % townsfolk.size());
            for (int i = 0; i < negRotations; i++) {
                Character temp = townsfolk.get(0);
                for (int j = 0; j < townsfolk.size() - 1; j++) {
                    townsfolk.set(j, townsfolk.get(j + 1));
                }
                townsfolk.set(townsfolk.size() - 1, temp);
            }
        }
    }
}

class Point {
    public int row;
    public int col;

    public Point(int row, int col) {
        this.row = row;
        this.col = col;
    }
}

