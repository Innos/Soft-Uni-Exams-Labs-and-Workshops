import java.math.BigDecimal;
import java.math.BigInteger;
import java.math.RoundingMode;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;

public class asa {
    public static void main(String[] args) {
        BigDecimal a = new BigDecimal("10000000.2345678");
        a = a.multiply(new BigDecimal(10000));
        BigDecimal[] twoBudgets = a.divideAndRemainder(new BigDecimal(10000));
        BigInteger first = twoBudgets[0].abs().toBigInteger();
        BigInteger second = twoBudgets[1].abs().toBigInteger();
        System.out.printf("%d %d",first,second);
    }
}