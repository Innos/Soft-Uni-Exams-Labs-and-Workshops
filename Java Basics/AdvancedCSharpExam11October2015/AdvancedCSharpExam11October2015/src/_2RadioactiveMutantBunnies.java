import javafx.geometry.Pos;

import java.util.ArrayList;
import java.util.Scanner;

public class _2RadioactiveMutantBunnies {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] tokens = scanner.nextLine().split(" ");
        int rows = Integer.parseInt(tokens[0]);
        int cols = Integer.parseInt(tokens[1]);

        Position player = new Position(0, 0);
        Position lastPosition = new Position(0, 0);
        ArrayList<Position> bunnies = new ArrayList<>();

        ArrayList<ArrayList<Character>> matrix = new ArrayList<>();

        for (int i = 0; i < rows; i++) {
            matrix.add(new ArrayList<>());
            String line = scanner.nextLine();
            for (int j = 0; j < cols; j++) {
                matrix.get(i).add(line.charAt(j));
                if (line.charAt(j) == 'P') {
                    player = new Position(i, j);
                    lastPosition = new Position(i, j);
                } else if (line.charAt(j) == 'B') {
                    bunnies.add(new Position(i, j));
                }
            }
        }

        String actions = scanner.nextLine();
        boolean died = false;
        boolean won = false;
        int position = 0;
        while (!died && !won) {
            switch (actions.charAt(position)) {
                case 'L':
                    player.col -= 1;
                    break;
                case 'U':
                    player.row -= 1;
                    break;
                case 'R':
                    player.col += 1;
                    break;
                case 'D':
                    player.row += 1;
                    break;
            }

            matrix.get(lastPosition.row).set(lastPosition.col, '.');

            if (player.row < 0 || player.row >= rows || player.col < 0 || player.col >= cols) {
                won = true;
            } else {
                lastPosition = new Position(player.row, player.col);
                matrix.get(player.row).set(player.col, 'P');
            }

            ArrayList<Position> bunniesToAdd = new ArrayList<>();
            for (Position bunny : bunnies) {
                if (bunny.row - 1 >= 0 && matrix.get(bunny.row - 1).get(bunny.col) != 'B') {
                    bunniesToAdd.add(new Position(bunny.row - 1, bunny.col));
                    matrix.get(bunny.row -1).set(bunny.col,'B');
                }
                if (bunny.col - 1 >= 0 && matrix.get(bunny.row).get(bunny.col - 1) != 'B') {
                    bunniesToAdd.add(new Position(bunny.row, bunny.col - 1));
                    matrix.get(bunny.row).set(bunny.col-1, 'B');
                }
                if (bunny.row + 1 < rows && matrix.get(bunny.row + 1).get(bunny.col) != 'B') {
                    bunniesToAdd.add(new Position(bunny.row + 1, bunny.col));
                    matrix.get(bunny.row +1).set(bunny.col, 'B');
                }
                if (bunny.col + 1 < cols && matrix.get(bunny.row).get(bunny.col + 1) != 'B') {
                    bunniesToAdd.add(new Position(bunny.row, bunny.col + 1));
                    matrix.get(bunny.row).set(bunny.col + 1, 'B');
                }
            }
            bunnies.addAll(bunniesToAdd);


            for (Position bunny : bunnies) {

                if (player.row == bunny.row && player.col == bunny.col) {
                    died = true;
                    matrix.get(player.row).set(player.col,'B');
                }
            }

            position++;
        }

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                System.out.print(matrix.get(i).get(j));
            }
            System.out.println();
        }
        if (won) {
            System.out.printf("won: %d %d\n", lastPosition.row, lastPosition.col);
        } else if (died) {
            System.out.printf("dead: %d %d\n", player.row, player.col);
        }
    }
}

class Position {

    public int row;
    public int col;

    public Position(int row, int col) {
        this.row = row;
        this.col = col;
    }
}
