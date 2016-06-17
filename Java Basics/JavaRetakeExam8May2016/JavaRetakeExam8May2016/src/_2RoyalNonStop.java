import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.Scanner;

public class _2RoyalNonStop {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] parameters = scanner.nextLine().split(" ");

        parameters = scanner.nextLine().split(" ");
        BigDecimal lukankaPrice = new BigDecimal(parameters[0]);
        BigDecimal rakijaPrice = new BigDecimal(parameters[1]);


        BigDecimal totalSum = BigDecimal.ZERO;
        int clients = 0;

        String line = scanner.nextLine();
        while (!line.equals("Royal Close")) {
            parameters = line.split(" ");
            int row = Integer.parseInt(parameters[0]);
            int col = Integer.parseInt(parameters[1]);
            BigDecimal sum = BigDecimal.ZERO;

            if (row < col) {

                for (; row >= 0; row--) {
                    BigDecimal price = row % 2 == 0 ? lukankaPrice : rakijaPrice;
                    sum = sum.add((new BigDecimal(row + 1).multiply(new BigDecimal(col + 1))).multiply(price));
                }
                row++;
                col--;

                BigDecimal price = row % 2 == 0 ? lukankaPrice : rakijaPrice;
                for (; col > 0; col--) {
                    sum = sum.add((new BigDecimal(row + 1).multiply(new BigDecimal(col + 1))).multiply(price));
                }

            } else {
                BigDecimal price = row % 2 == 0 ? lukankaPrice : rakijaPrice;
                for (; col >= 0; col--) {
                    sum = sum.add((new BigDecimal(row + 1).multiply(new BigDecimal(col + 1))).multiply(price));
                }
                col++;
                row--;
                for (; row > 0; row--) {
                    price = row % 2 == 0 ? lukankaPrice : rakijaPrice;
                    sum = sum.add((new BigDecimal(row + 1).multiply(new BigDecimal(col + 1))).multiply(price));
                }
            }

            totalSum = totalSum.add(sum);
            clients++;
            line = scanner.nextLine();
        }

        System.out.println(totalSum.setScale(6, RoundingMode.HALF_UP));
        System.out.println(clients);
    }
}
